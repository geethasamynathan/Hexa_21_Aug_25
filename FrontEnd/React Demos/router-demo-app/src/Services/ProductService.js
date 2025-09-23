export async function getAllProducts() {
  const result = await fetch("https://fakestoreapi.com/products");
  if (!result.ok) {
    throw new Error(" Something went wrong while fetch products");
  }
  return result.json();
}
