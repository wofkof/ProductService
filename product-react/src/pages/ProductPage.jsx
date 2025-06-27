import { useEffect, useState } from "react";
import {
  getAllProducts,
  createProduct,
  deleteProduct,
} from "../api/productApi";
import ProductList from "../components/ProductList";
import ProductForm from "../components/ProductForm";

function ProductPage() {
  const [products, setProducts] = useState([]);

  const loadProducts = async () => {
    const res = await getAllProducts();
    setProducts(res.data);
  };

  useEffect(() => {
    loadProducts();
  }, []);

  const handleCreate = async (data) => {
    await createProduct(data);
    loadProducts();
  };

  const handleDelete = async (id) => {
    await deleteProduct(id);
    loadProducts();
  };

  return (
    <div style={{ padding: 20 }}>
      <h1>Product Management</h1>
      <ProductList products={products} onDelete={handleDelete} />
      <ProductForm onCreate={handleCreate} />
    </div>
  );
}

export default ProductPage;
