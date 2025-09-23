import axios from "axios";

const API_URL = "https://localhost:7043/api/products";

const handleError = (error) => {
  if (error.response) {
    throw new Error(
      `Server Error (${error.response.status}):
            ${error.response.data?.message || error.message}`
    );
  } else if (error.request) {
    throw new Error(
      "No Response from Server.Please checkthe server ot Try after sometime"
    );
  } else {
    throw new Error(`Error :${error.message}`);
  }
};

export const getAllProducts = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

export const getProductById = async (product_id) => {
  try {
    console.log("id in getPtoductBy Id " + product_id);

    const response = await axios.get(`${API_URL}/${product_id}`);
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

export const createProduct = async (product) => {
  try {
    const response = await axios.post(API_URL, product);
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

export const updateProduct = async (id, product) => {
  try {
    console.log("id in service " + id);

    const response = await axios.put(`${API_URL}/${id}`, product);
    return response.data;
  } catch (error) {
    handleError(error);
  }
};

export const deleteProduct = async (id) => {
  try {
    const response = await axios.delete(`${API_URL}/${id}`);
    return response.data;
  } catch (error) {
    handleError(error);
  }
};
