import React from "react";

import styles from "./OrderBadge.module.css";
import "./OrderBadge.css";

const STATUS_TO_CLASS = {
  //   Pending: styles.Pending,
  //   Shipped: styles.Shipped,
  //   Delayed: styles.Delayed,
  //   Cancelled: styles.Cancelled,
  Pending: "Pending",
  Shipped: "Shipped",
  Delayed: "Delayed",
  Cancelled: "Cancelled",
};
export default function OrderBadge({ status }) {
  return (
    <>
      <span className={`badge ${STATUS_TO_CLASS[status] || ""}`}>{status}</span>
    </>
  );
}
