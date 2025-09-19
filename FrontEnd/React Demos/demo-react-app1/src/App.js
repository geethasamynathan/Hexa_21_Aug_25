import logo from "./logo.svg";
import "./App.css";

function App() {
  let firstName = "Geetha";
  let lastName = "Samynathan";

  let isActive = true;

  let year_of_joining = 2025;

  const cart = [
    { item: "shoes", price: 4500, qty: 1 },
    { item: "Bag", price: 3000, qty: 1 },
    { item: "Watch", price: 14500, qty: 2 },
  ];
  return (
    <>
      <h1 className="App"> Hey All, Welcome to React Js session</h1>
      <p>
        Name of the User: {firstName} {lastName}
      </p>
      <p> Current Year : {year_of_joining}</p>

      <p>
        Current Employment : {isActive ? "in Active Status" : "InActive status"}
      </p>

      <table border="1">
        <thead>
          <tr>
            <th>Name</th>
            <th>Price</th>
            <th>Quantity</th>
          </tr>
        </thead>
        <tbody>
          {cart.map((c, index) => (
            <tr key={index}>
              <td>{c.item}</td>
              <td>{c.price}</td>
              <td>{c.qty}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default App;

//JSX ==> javascript and XML
