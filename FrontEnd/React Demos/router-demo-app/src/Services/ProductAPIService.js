import axios from "axios";

export async function getAllProductsUsingAxios() {
  const result = await axios.get("https://fakestoreapi.com/products");
  return result.data;
}
