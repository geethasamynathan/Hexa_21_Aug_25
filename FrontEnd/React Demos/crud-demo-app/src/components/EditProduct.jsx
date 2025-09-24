import { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { getProductById, updateProduct } from "../Services/ProductService";

export default function EditProduct() {
  const { product_id } = useParams();
  console.log("id " + product_id);

  const [product, setProduct] = useState({});
  const navigate = useNavigate();

  const loadProduct = async (product_id) => {
    console.log("loadProduct called");

    const response = await getProductById(product_id);
    setProduct(response);
  };

  useEffect(() => {
    loadProduct(product_id);
  }, []);

  const handleChange = (e) => {
    setProduct({
      ...product,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await updateProduct(product_id, product);
    navigate("/");
  };

  return (
    <div className=" container mt-5">
      <h2 className="mb-4 text-warning"> Edit Prodcut</h2>
      <form onSubmit={handleSubmit} className="card p-4 shadow">
        <div className="mb-3">
          <label className="form-label">Product Id</label>
          <input
            name="product_id"
            placeholder="id"
            className="form-control"
            value={product.product_id || ""}
            readOnly
            onChange={handleChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Product Name</label>
          <input
            name="product_name"
            className="form-control"
            placeholder="name"
            value={product.product_name || ""}
            onChange={handleChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Brand Id</label>
          <input
            name="brand_id"
            placeholder="Brand Id"
            className="form-control"
            value={product.brand_id || ""}
            onChange={handleChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Category Id</label>
          <input
            name="category_id"
            className="form-control"
            placeholder="Category_Id"
            value={product.category_id || ""}
            onChange={handleChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Model Year</label>
          <input
            name="model_year"
            className="form-control"
            placeholder="Model Year"
            value={product.model_year || ""}
            onChange={handleChange}
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Price</label>
          <input
            name="list_price"
            placeholder="List Price"
            className="form-control"
            value={product.list_price || ""}
            onChange={handleChange}
          />
          <div />
        </div>
        <button type="submit" className="btn btn-primary w-100">
          Update
        </button>
      </form>
    </div>
  );
}
