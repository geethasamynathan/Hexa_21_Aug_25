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
    <div>
      <h2> Edit Prodcut</h2>
      <form onSubmit={handleSubmit}>
        <input
          name="product_id"
          placeholder="id"
          value={product.product_id || ""}
          readOnly
          onChange={handleChange}
        />
        <input
          name="product_name"
          placeholder="name"
          value={product.product_name || ""}
          onChange={handleChange}
        />
        <input
          name="brand_id"
          placeholder="Brand Id"
          value={product.brand_id || ""}
          onChange={handleChange}
        />
        <input
          name="category_id"
          placeholder="Category_Id"
          value={product.category_id || ""}
          onChange={handleChange}
        />
        <input
          name="model_year"
          placeholder="Model Year"
          value={product.model_year || ""}
          onChange={handleChange}
        />
        <input
          name="list_price"
          placeholder="List Price"
          value={product.list_price || ""}
          onChange={handleChange}
        />

        <button type="submit">Update</button>
      </form>
    </div>
  );
}
