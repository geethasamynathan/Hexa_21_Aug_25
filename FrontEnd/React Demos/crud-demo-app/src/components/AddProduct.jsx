import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { createProduct } from "../Services/ProductService";
import { toast } from "react-toastify";
export default function AddProduct() {
  const [product, setProduct] = useState({
    product_name: "",
    brand_id: 0,
    category_id: 0,
    model_year: 0,
    list_price: 0,
  });

  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    // const numeric_fields = [
    //   "brand_id",
    //   "category_id",
    //   "model_year",
    //   "list_price",
    // ];

    // setProduct({
    //   ...product,
    //   [name]: numeric_fields.includes(name) ? Number(value) : value,
    // });
    setProduct({
      ...product,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await createProduct(product);
      toast.success("✅ Product added successfully");
      navigate("/");
    } catch (error) {
      console.log(error);
      toast.error("❌ Failed to add product. Please try again.");
    }
  };

  return (
    <div className="container mt-5">
      <h2 className="mb-4 text-info"> Add Prodcut</h2>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label className="form-label">Product Name</label>
          <input
            className="form-control"
            name="product_name"
            placeholder="name"
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label className="form-label">Brand Id</label>
          <input
            name="brand_id"
            className="form-control"
            placeholder="Brand Id"
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label className="form-label">Category Id</label>
          <input
            name="category_id"
            className="form-control"
            placeholder="Category_Id"
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label className="form-label">Model Year</label>
          <input
            name="model_year"
            className="form-control"
            placeholder="Model Year"
            onChange={handleChange}
          />
        </div>
        <div className="form-group">
          <label className="form-label">List Price</label>
          <input
            name="list_price"
            className="form-control"
            placeholder="List Price"
            onChange={handleChange}
          />
        </div>

        <button type="submit" className="btn btn-success w-100">
          Save
        </button>
      </form>
    </div>
  );
}
