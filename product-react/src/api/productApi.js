import axios from "axios";

const api = axios.create({
  baseURL: import.meta.env.VITE_API_URL + "product"
});

export const getAllProducts = () => api.get('/');
export const getProductById = (id) => api.get(`/${id}`);
export const createProduct = (data) => api.post('/', data);
export const updateProduct = (id, data) => api.put(`/${id}`, data);
export const deleteProduct = (id) => api.delete(`/${id}`);
