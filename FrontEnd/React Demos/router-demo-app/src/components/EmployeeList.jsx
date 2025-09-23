import { Link } from "react-router-dom";

const employees = [
  { id: 1, name: "Karthik", role: "Manager" },
  { id: 2, name: "Vismaya", role: "user" },
  { id: 3, name: "Sherin", role: "Manager" },
  { id: 4, name: "Srimathi", role: "user" },
  { id: 5, name: "Madhu sai", role: "Manager" },
];

export default function Employees() {
  return (
    <div>
      <h2>Employee List</h2>
      <ul>
        {employees.map((emp) => (
          <li key={emp.id}>
            <Link to={`/employees/${emp.id}`}>
              {emp.name} - {emp.role}
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
}
