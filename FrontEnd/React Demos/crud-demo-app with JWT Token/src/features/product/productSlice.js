import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import {
  getAllProducts,
  createProduct,
  updateProduct,
  deleteProduct,
  getProductById,
  searchProducts,
} from "../../Services/ProductService";

export const fetchProducts = createAsyncThunk("products/fetch", async () => {
  return await getAllProducts();
});

export const addProduct = createAsyncThunk("products/add", async (product) => {
  return await createProduct(product);
});

export const editProduct = createAsyncThunk(
  "products/edit",
  async ({ id, product }) => {
    return await updateProduct(id, product);
  }
);

export const removeProduct = createAsyncThunk("products/delete", async (id) => {
  await deleteProduct(id);
});
export const searchProductList = createAsyncThunk(
  "products/search",
  async (query) => {
    return await searchProducts(query);
  }
);

const productSlice = createSlice({
  name: "products",
  initialState: { items: [], loading: false, error: null },
  reducers: {},
  extraReducers: (builder) => {
    builder

      //Fetch
      .addCase(fetchProducts.pending, (state) => {
        state.loading = true;
      })
      .addCase(fetchProducts.fulfilled, (state, action) => {
        state.loading = false;
        state.items = action.payload;
      })
      .addCase(fetchProducts.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message;
      })

      //Add
      .addCase(addProduct.fulfilled, (state, action) => {
        state.items.push(action.payload);
      })

      //Edit
      .addCase(editProduct.fulfilled, (state, action) => {
        const index = state.items.findIndex(
          (p) => p.product_id === action.payload.product_id
        );
        if (index >= 0) state.items[index] = action.payload;
      })

      //delete
      .addCase(removeProduct.fulfilled, (state, action) => {
        state.items = state.items.filter(
          (p) => p.product_id !== action.payload
        );
      })

      //search
      .addCase(searchProductList.fulfilled, (state, action) => {
        state.items = action.payload;
      });
  },
});

export default productSlice.reducer;
