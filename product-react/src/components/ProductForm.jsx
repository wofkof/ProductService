import { useState } from "react";

function ProductForm({ onCreate }) {
  const [form, setForm] = useState({ name: "", price: "", stock: "" });

  const handleSubmit = (e) => {
    e.preventDefault();
    onCreate({
      name: form.name,
      price: parseFloat(form.price),
      stock: parseInt(form.stock),
    });
    setForm({ name: "", price: "", stock: "" });
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Add Product</h2>
      <input
        placeholder="Name"
        value={form.name}
        onChange={(e) => setForm({ ...form, name: e.target.value })}
      />
      <input
        placeholder="Price"
        type="number"
        value={form.price}
        onChange={(e) => setForm({ ...form, price: e.target.value })}
      />
      <input
        placeholder="Stock"
        type="number"
        value={form.stock}
        onChange={(e) => setForm({ ...form, stock: e.target.value })}
      />
      <button type="submit">Create</button>
    </form>
  );
}

export default ProductForm;
