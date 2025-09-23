import { useParams } from "react-router-dom";

const Employees = [
  { id: 1, name: "Karthik", role: "Manager", department: "UI/UX" },
  { id: 2, name: "Vismaya", role: "user", department: "cloud" },
  { id: 3, name: "Sherin", role: "Manager", department: "Operations" },
  {
    id: 4,
    name: "Srimathi",
    role: "user",
    department: "Learning and developement",
  },
  { id: 5, name: "Madhu sai", role: "user", department: "UI/UX" },
];

export default function EmployeeDetail() {
  console.log("EmployeeDetail called");

  const { id } = useParams();
  console.log("id=" + id);

  const employee = Employees.find((e) => e.id == parseInt(id));
  console.log("employee" + employee);

  if (!employee) {
    return <h3> Employee Not Found</h3>;
  }
  return (
    <div>
      <h2>Employee Details</h2>
      <p>
        <b>Name :</b>
        {employee.name}
      </p>
      <p>
        <b>Role :</b>
        {employee.role}
      </p>
      <p>
        <b>department :</b>
        {employee.department}
      </p>
    </div>
  );
}
