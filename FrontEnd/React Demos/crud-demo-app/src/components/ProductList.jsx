import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getAllProducts, deleteProduct } from "../Services/ProductService";

export default function ProductList() {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    loadProducts();
  }, []);

  const loadProducts = async () => {
    const response = await getAllProducts();
    console.log(response);
    setProducts(response);
  };

  const handleDelete = async (id) => {
    await deleteProduct(id);
    loadProducts();
  };
  return (
    <div>
      <h2> Product Lsit</h2>
      <Link to="/add">➕ Add Product</Link>
      <ul>
        {products.map((p) => (
          <li key={p.product_id}>
            <Link to={`/products/${p.product_id}`}>
              {p.product_id} {p.product_name} - {p.list_price}
            </Link>{" "}
            {" | "}
            <Link to={`/edit/${p.product_id}`}> ✏️ Edit</Link> {" | "}
            <button onClick={() => handleDelete(p.product_id)}>
              🚮 Delete
            </button>
          </li>
        ))}
      </ul>
    </div>
  );
}
