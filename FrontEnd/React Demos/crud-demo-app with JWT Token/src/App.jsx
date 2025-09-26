import { useEffect, useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import ProductList from "./components/ProductList";
import AddProduct from "./components/AddProduct";
import EditProduct from "./components/EditProduct";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Dashboard from "./components/Dashboard";
import Layout from "./components/Layout";
import Login from "./components/Login";
import RequireAuth from "./components/RequireAuth";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function App() {
  const [token, setToken] = useState(localStorage.getItem("token"));
  const [roles, setRoles] = useState([]);

  useEffect(() => {
    const storedRoles = localStorage.getItem("roles");
    if (storedRoles) {
      setRoles(JSON.parse(storedRoles));
    }
  }, [token]);

  const handleLogout = () => {
    localStorage.clear();
    setToken(null);
    setRoles([]);
  };
  return (
    <>
      <BrowserRouter>
        <Routes>
          {/* Login Page */}
          <Route path="/login" element={<Login onLogin={setToken} />} />

          {/* When logged in → show Layout with Logout */}
          {token ? (
            <Route path="/" element={<Layout onLogout={handleLogout} />}>
              <Route index element={<ProductList roles={roles} />} />

              {/* Admin only */}
              <Route
                path="/add"
                element={
                  <RequireAuth allowedRoles={["Admin"]}>
                    <AddProduct />
                  </RequireAuth>
                }
              />
              <Route
                path="/edit/:product_id"
                element={
                  <RequireAuth allowedRoles={["Admin"]}>
                    <EditProduct />
                  </RequireAuth>
                }
              />
            </Route>
          ) : (
            // Anonymous: show ProductList without actions
            <Route path="/" element={<Layout />}>
              <Route index element={<ProductList roles={[]} />} />
              {/* Any restricted route redirects to login */}
            </Route>
          )}
          <Route
            path="*"
            element={<Navigate to={token ? "/" : "/login"} replace />}
          />
        </Routes>
      </BrowserRouter>
      <ToastContainer position="top-right" autoClose={3000} />
    </>
  );
}

export default App;
