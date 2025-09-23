import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { createProduct } from "../Services/ProductService";

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
    await createProduct(product);
    navigate("/");
  };

  return (
    <div>
      <h2> Add Prodcut</h2>
      <form onSubmit={handleSubmit}>
        <input name="product_name" placeholder="name" onChange={handleChange} />
        <input name="brand_id" placeholder="Brand Id" onChange={handleChange} />
        <input
          name="category_id"
          placeholder="Category_Id"
          onChange={handleChange}
        />
        <input
          name="model_year"
          placeholder="Model Year"
          onChange={handleChange}
        />
        <input
          name="list_price"
          placeholder="List Price"
          onChange={handleChange}
        />

        <button type="submit">Save</button>
      </form>
    </div>
  );
}
