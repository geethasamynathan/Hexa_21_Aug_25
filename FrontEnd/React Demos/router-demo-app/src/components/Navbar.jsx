import { Link } from "react-router-dom";

export default function Navbar() {
  const handleLogout = () => {
    localStorage.removeItem("auth");
    localStorage.removeItem("role");
    window.location.href = "/login";
  };

  return (
    <nav style={{ padding: "10px", background: "#eee" }}>
      <Link to="/">Home</Link> |{""}
      <Link to="/dashboard">Dashboard</Link>|{""}
      <Link to="/employees">Employees</Link> |{""}
      <Link to="/add-employee">Add Employee</Link>|{""}
      <button onClick={handleLogout}>Logout</button>
    </nav>
  );
}
