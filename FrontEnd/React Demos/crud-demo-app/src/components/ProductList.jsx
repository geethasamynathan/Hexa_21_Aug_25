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
    <div className="container mt-5">
      <h2 className="mb-3 text-success"> Product Lsit</h2>
      <Link to="/add" className=" btn btn-success mb-3">
        ➕ Add Product
      </Link>
      <table className="table table-stripped table-bordered shadow">
        <thead className="table-dark">
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Brand</th>
            <th>Category</th>
            <th> Model Year</th>
            <th>Price</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {products.map((p) => (
            <tr key={p.product_id}>
              <td>{p.product_id}</td>
              <td>{p.product_name}</td>
              <td>{p.brand_id}</td>
              <td>{p.category_id}</td>
              <td>{p.model_year}</td>
              <td>{p.list_price}</td>
              <td>
                <Link to={`/edit/${p.product_id}`}> ✏️ Edit</Link>
                <button onClick={() => handleDelete(p.product_id)}>
                  🚮 Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
