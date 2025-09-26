using Auth_Demo1.Authentication;
using Auth_Demo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Auth_Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        private readonly ApplicationDbContext _context;

        private static Dictionary<string, string> _userRefreshTokens = new Dictionary<string, string>();

        public AuthController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            ILogger<AuthController> logger,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var userExists = await _userManager.FindByNameAsync(registerModel.UserName);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User already exists!" });
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var  result= await _userManager.CreateAsync(user, registerModel.Password);
            if(!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     new Response 
                       { Status = "Error", Message = "User creation failed!" });
            }

            if(registerModel.Role =="Admin")
            {
                if(!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                if(await _roleManager.RoleExistsAsync(UserRoles.Admin))
                    await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            if(registerModel.Role == "User")
            {
                if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                if (await _roleManager.RoleExistsAsync(UserRoles.User))
                    await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {

            _logger.LogInformation("Login attempt for user: {UserName}", loginModel.UserName);
            _logger.LogWarning("This is a warning log example."); ;
            _logger.LogError("This is an error log example."); 
            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                // Generate Access Token
                var accessToken = GenerateAccessToken(authClaims);

                // Generate Refresh Token
                var refreshToken = GenerateRefreshToken();

                // ✅ Save Refresh Token in DB
                var newRefreshToken = new RefreshToken
                {
                    Token = refreshToken,
                    UserId = user.Id,
                    Expires = DateTime.Now.AddDays(3),
                    Created = DateTime.Now,
                    IsRevoked = false
                };

                // Revoke old tokens (optional)
                var oldTokens = _context.RefreshTokens
                    .Where(r => r.UserId == user.Id && !r.IsRevoked);
                foreach (var t in oldTokens) t.IsRevoked = true;

                _context.RefreshTokens.Add(newRefreshToken);
                await _context.SaveChangesAsync();
                //await _context.SaveChangesAsync();
                //var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                //    (_configuration["jwt:Secret"]));

                //var token = new JwtSecurityToken(
                //    issuer: _configuration["jwt:ValidIssuer"],
                //    audience: _configuration["jwt:ValidAudience"],
                //    expires: DateTime.Now.AddMinutes(3),
                //    claims: authClaims,
                //    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                //    );

                return Ok(new
                {
                    username = user.UserName,
                    //token = new JwtSecurityTokenHandler().WriteToken(token),
                    token= accessToken,
                    refreshToken = refreshToken,
                    roles = userRoles,
                    expiration = DateTime.Now.AddMinutes(3)

                });
            }
                return Unauthorized();
            
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenModel tokenModel)
        {
            if (tokenModel == null)
                return BadRequest("Invalid request");

            var accessToken = tokenModel.AccessToken;
            var refreshToken = tokenModel.RefreshToken;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity?.Name;

            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return Unauthorized();

            var storedToken = _context.RefreshTokens
                .FirstOrDefault(r => r.UserId == user.Id && r.Token == refreshToken);

            if (storedToken == null || storedToken.IsRevoked || storedToken.Expires < DateTime.Now)
                return Unauthorized("Invalid refresh token");

            // Rotate refresh token
            storedToken.IsRevoked = true;

            var newRefreshToken = new RefreshToken
            {
                Token = GenerateRefreshToken(),
                UserId = user.Id,
                Expires = DateTime.Now.AddDays(3),
                Created = DateTime.Now,
                IsRevoked = false
            };

            _context.RefreshTokens.Add(newRefreshToken);
            await _context.SaveChangesAsync();

            var newAccessToken = GenerateAccessToken(principal.Claims);

            return Ok(new
            {
                token = newAccessToken,
                refreshToken = newRefreshToken.Token
            });
        }

        // ---------------- HELPERS ----------------

        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(3), // short life
                claims: claims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false // ignore expiration
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }
    }

}

