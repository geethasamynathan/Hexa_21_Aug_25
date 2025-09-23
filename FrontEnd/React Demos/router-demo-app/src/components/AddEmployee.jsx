import React from "react";

export default function AddEmployee() {
  return (
    <div>
      <h2> Add new Employee (Manager Only) </h2>
      <form>
        <input type="text" placeholder="Employee Name" />
        <br />
        <input type="text" placeholder="Role" />
        <br />
        <button type="submit">Add</button>
      </form>
    </div>
  );
}
