import styles from "./App.module.css";

const INR = new Intl.NumberFormat("en-IN", {
  style: "currency",
  currency: "INR",
  maximumFractionDigits: 0,
});

export default function AppTailwind() {
  const firstName = "Geetha";
  const lastName = "Samynathan";
  const isActive = true;
  const year = 2025;

  const cart = [
    { item: "Shoes", price: 4500, qty: 1 },
    { item: "Bag", price: 3000, qty: 1 },
    { item: "Watch", price: 14500, qty: 2 },
  ];

  const qty = cart.reduce((a, r) => a + r.qty, 0);
  const sum = cart.reduce((a, r) => a + r.price * r.qty, 0);

  return (
    <main className={styles.container}>
      <header className={styles.header}>
        <h1 className={styles.title}>Hey all, Welcome to React.js session</h1>
        <p className={styles.subtitle}>CSS Modules (scoped styles)</p>
      </header>

      <section className={styles.grid}>
        <div>
          <span className={styles.label}>Name: </span>
          <span>
            {firstName} {lastName}
          </span>
        </div>
        <div>
          <span className={styles.label}>Year of Joining: </span>
          <span>{year}</span>
        </div>
        <div>
          <span className={styles.label}>Employment: </span>
          <span
            className={`${styles.badge} ${
              isActive ? styles.active : styles.inactive
            }`}
          >
            {isActive ? "Active" : "Inactive"}
          </span>
        </div>
      </section>

      <section className={styles.tableWrap}>
        <table className={styles.table}>
          <thead>
            <tr>
              <th className={styles.th} style={{ width: "40%" }}>
                Item
              </th>
              <th
                className={`${styles.th} ${styles.num}`}
                style={{ width: "20%" }}
              >
                Price
              </th>
              <th
                className={`${styles.th} ${styles.num}`}
                style={{ width: "20%" }}
              >
                Qty
              </th>
              <th
                className={`${styles.th} ${styles.num}`}
                style={{ width: "20%" }}
              >
                Line Total
              </th>
            </tr>
          </thead>
          <tbody>
            {cart.map((c, i) => (
              <tr key={i}>
                <td className={styles.td}>{c.item}</td>
                <td className={`${styles.td} ${styles.num}`}>
                  {INR.format(c.price)}
                </td>
                <td className={`${styles.td} ${styles.num}`}>{c.qty}</td>
                <td className={`${styles.td} ${styles.num}`}>
                  {INR.format(c.price * c.qty)}
                </td>
              </tr>
            ))}
            <tr className={styles.totals}>
              <td className={styles.td}>Total</td>
              <td className={styles.td}></td>
              <td className={`${styles.td} ${styles.num}`}>{qty}</td>
              <td className={`${styles.td} ${styles.num}`}>
                {INR.format(sum)}
              </td>
            </tr>
          </tbody>
        </table>
      </section>
    </main>
  );
}
