import React from "react";
import OrderBadge from "./OrderBadge";
const orders = [
  { id: "A1001", customer: "Geetha", status: "Pending" },
  { id: "A1002", customer: "Tina", status: "Shipped" },
  { id: "A1003", customer: "Fransy", status: "Delayed" },
  { id: "A1004", customer: "Arun", status: "Cancelled" },
];
export default function OrdersList() {
  return (
    <ul>
      {orders.map((o) => (
        <li key={o.id}>
          <strong>{o.id}</strong> <span>{o.customer}</span>
          <OrderBadge status={o.status} />
        </li>
      ))}
    </ul>
  );
}
