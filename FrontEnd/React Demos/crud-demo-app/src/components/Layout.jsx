import React from "react";
import Dashboard from "./Dashboard";
import { Outlet } from "react-router-dom";

export default function Layout() {
  return (
    <div className="container mt-3">
      {/* Dashboard always on top */}
      <Dashboard />

      {/* Page-specific content */}
      <Outlet />
    </div>
  );
}
