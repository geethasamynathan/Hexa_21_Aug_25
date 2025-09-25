import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import ProductList from "./components/ProductList";
import AddProduct from "./components/AddProduct";
import EditProduct from "./components/EditProduct";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Dashboard from "./components/Dashboard";
import Layout from "./components/Layout";
function App() {
  const [count, setCount] = useState(0);

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout />}>
          {/* Default landing page */}
          <Route index element={<ProductList />} />
          <Route path="/Products" element={<ProductList />} />
          <Route path="/add" element={<AddProduct />} />
          <Route path="/edit/:product_id" element={<EditProduct />} />
        </Route>
      </Routes>
      {/* <ProductList /> */}
    </BrowserRouter>
  );
}

export default App;
