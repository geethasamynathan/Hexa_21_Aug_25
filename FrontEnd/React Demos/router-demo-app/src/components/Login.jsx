import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = () => {
    if (username === "admin" && password === "testpassword") {
      localStorage.setItem("auth", true);
      localStorage.setItem("role", "manager");
      navigate("/dashboard");
    } else if (username === "user" && password === "test") {
      localStorage.setItem("auth", true);
      localStorage.setItem("role", "employee");
      navigate("/dashboard");
    } else {
      alert("Invalid crredentials . Try with valid credentials");
    }
  };
  return (
    <div>
      <h2> Login Page</h2>
      <input
        type="text"
        placeholder="Username"
        onChange={(e) => setUsername(e.target.value)}
      />{" "}
      <br />
      <input
        type="password"
        placeholder="enter the password"
        onChange={(e) => setPassword(e.target.value)}
      />{" "}
      <br />
      <button onClick={handleLogin}>Login</button>
    </div>
  );
}
