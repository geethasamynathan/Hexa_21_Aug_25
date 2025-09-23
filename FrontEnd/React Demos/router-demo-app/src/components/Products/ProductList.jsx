import React, { useState, useEffect } from "react";
import { getAllProducts } from "../../Services/ProductService";

import { getAllProductsUsingAxios } from "../../Services/ProductAPIService";
export default function ProductList() {
  const [products, setProducts] = useState([]);
  const [error, setError] = useState("");
  useEffect(() => {
    console.log(getAllProductsUsingAxios.data);

    getAllProductsUsingAxios()
      .then(setProducts)
      .catch((err) => setError(err.message));
    // fetch("https://fakestoreapi.com/products")
    //   .then((res) => res.json())
    //   .then((data) => setProducts(data));
  }, []);
  return (
    <div>
      <h2> Product List From API </h2>

      {error && <h3 style={{ color: "Red" }}>{error}</h3>}
      {products.map((p) => (
        <div
          key={p.id}
          style={{ margin: "10px", padding: "10px", background: "beige" }}
        >
          {p.title}
        </div>
      ))}
    </div>
  );
}
