import { useSelector } from "react-redux";
import React from "react";

export default function Dashboard() {
  const { items } = useSelector((state) => state.products);

  const total = items.length;
  const avgPrice =
    total > 0
      ? (items.reduce((a, c) => a + c.list_price, 0) / total).toFixed(2)
      : 0;
  return (
    <div className="p-3 bg-light border rounded shadow-sm mb-4">
      <h5 className="text-primary">📊 Dashboard Summary</h5>
      <p className="mb-1">
        Total Products: <strong>{total}</strong>
      </p>
      <p className="mb-0">
        Average Price: <strong>{avgPrice}</strong>
      </p>
    </div>
  );
}
