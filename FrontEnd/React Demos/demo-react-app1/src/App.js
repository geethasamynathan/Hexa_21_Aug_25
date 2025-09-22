import logo from "./logo.svg";
import "./App.css";
import OrdersList from "./OrdersList";
import ThemeToggle from "./ThemeToggle";

export default function App() {
  return (
    <>
      <div>
        <header>
          <h1 className="App"> React Basics Demo</h1>
        </header>
      </div>
      {/* <OrdersList /> */}
      <ThemeToggle />
    </>
  );
}

// function formatINR(n) {
//   return new Intl.NumberFormat("en-IN", {
//     style: "currency",
//     currency: "INR",
//     maximumFractionDigits: 0,
//   }).format(n);
// }

// export default function App() {
//   const firstName = "Geetha";
//   const lastName = "Samynathan";
//   const isActive = true;
//   const year_of_joining = 2025;

//   const cart = [
//     { item: "Shoes", price: 4500, qty: 1 },
//     { item: "Bag", price: 3000, qty: 1 },
//     { item: "Watch", price: 14500, qty: 2 },
//   ];

//   const totalQty = cart.reduce((s, r) => s + r.qty, 0);
//   const totalAmount = cart.reduce((s, r) => s + r.price * r.qty, 0);

//   return (
//     <main className="container">
//       <header className="header">
//         <h1 className="title">Hey all, Welcome to React.js session</h1>
//         <p className="subtitle">
//           Cart summary with clean alignment & modern styles
//         </p>
//       </header>

//       <section className="userGrid">
//         <div>
//           <span className="label">Name:&nbsp;</span>
//           <span>
//             {firstName} {lastName}
//           </span>
//         </div>
//         <div>
//           <span className="label">Year of Joining:&nbsp;</span>
//           <span>{year_of_joining}</span>
//         </div>
//         <div>
//           <span className="label">Employment:&nbsp;</span>
//           <span
//             className={`badge ${isActive ? "badgeActive" : "badgeInactive"}`}
//           >
//             {isActive ? "Active" : "Inactive"}
//           </span>
//         </div>
//       </section>

//       <section className="tableWrap">
//         <table className="table">
//           <thead>
//             <tr>
//               <th style={{ width: "40%" }}>Item</th>
//               <th className="num" style={{ width: "20%" }}>
//                 Price
//               </th>
//               <th className="num" style={{ width: "20%" }}>
//                 Qty
//               </th>
//               <th className="num" style={{ width: "20%" }}>
//                 Line Total
//               </th>
//             </tr>
//           </thead>
//           <tbody>
//             {cart.map((c, idx) => (
//               <tr key={idx}>
//                 <td>{c.item}</td>
//                 <td className="num">{formatINR(c.price)}</td>
//                 <td className="num">{c.qty}</td>
//                 <td className="num">{formatINR(c.price * c.qty)}</td>
//               </tr>
//             ))}
//             <tr className="totalsRow">
//               <td>Total</td>
//               <td></td>
//               <td className="num">{totalQty}</td>
//               <td className="num">{formatINR(totalAmount)}</td>
//             </tr>
//           </tbody>
//         </table>
//       </section>

//       <p className="note">
//         Tip: avoid <code>border="1"</code> on tables; use CSS for consistent,
//         themeable borders.
//       </p>
//     </main>
//   );
// }

// function App() {
//   let firstName = "Geetha";
//   let lastName = "Samynathan";

//   let isActive = true;

//   let year_of_joining = 2025;

//   const cart = [
//     { item: "shoes", price: 4500, qty: 1 },
//     { item: "Bag", price: 3000, qty: 1 },
//     { item: "Watch", price: 14500, qty: 2 },
//   ];
//   return (
//     <div className="container">
//       <h1 className="title">Hey All, Welcome to React Js session</h1>

//       <div className="user-info">
//         <p>
//           Name of the User: {firstName} {lastName}
//         </p>
//         <p>Current Year: {year_of_joining}</p>
//         <p>
//           Current Employment:{" "}
//           {isActive ? "In Active Status" : "Inactive Status"}
//         </p>
//       </div>

//       <table className="table">
//         <thead>
//           <tr>
//             <th>Item</th>
//             <th>Price (₹)</th>
//             <th>Quantity</th>
//           </tr>
//         </thead>
//         <tbody>
//           {cart.map((c, index) => (
//             <tr key={index}>
//               <td>{c.item}</td>
//               <td>{c.price}</td>
//               <td>{c.qty}</td>
//             </tr>
//           ))}
//         </tbody>
//       </table>
//     </div>
//   );
// }

// export default App;
