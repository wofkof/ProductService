function ProductList({ products, onDelete }) {
  return (
    <ul>
      {products.map((p) => (
        <li key={p.id}>
          {p.name} - ${p.price.toFixed(2)}
          <button onClick={() => onDelete(p.id)} style={{ marginLeft: 10 }}>
            Delete
          </button>
        </li>
      ))}
    </ul>
  );
}

export default ProductList;
