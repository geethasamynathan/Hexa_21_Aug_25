using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTO_Demo1.Models;
using AutoMapper;
using DTO_Demo1.DTOs;

namespace DTO_Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<BooksController> _logger;

        public BooksController(BookDbContext context, ILogger<BooksController> logger,IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
           List<Book> books=await _context.Books.ToListAsync();
            if(books!= null && books.Count > 0)
            {
                var bookDtos = _mapper.Map<List<BookDTO>>(books);
                return Ok(bookDtos);
            }
            else
            {
               return NotFound("No books found");
            }
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            var bookDto = _mapper.Map<BookDTO>(book);
            return bookDto;
        }

        // PUT: api/Books/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookDTO bookDto)
        {
            var book=await  _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(book==null)
                return NotFound("Book not found");
            book.Title= bookDto.Title;
            book.Author = bookDto.Author;
            book.Price = bookDto.Price;
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookDTO>> PostBook(BookPostDTO bookPostDto)
        {
            var book = _mapper.Map<Book>(bookPostDto);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = book.Id }, bookPostDto);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
