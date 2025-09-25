# 📘 React Redux (`useSelector`, `useDispatch`) Trainer Notes

## 1. What is Redux?
Redux is a **state management library** for JavaScript apps.  
- In React, each component can have its own state (`useState`).  
- When apps grow, **sharing state across many components becomes messy**.  
- Redux provides a **central store** where all states live. Components can read/write from this store using React-Redux hooks.

---

## 2. React-Redux Hooks (`useSelector`, `useDispatch`)
When we say *“useRedux”*, we usually mean using these hooks:

- **`useSelector`** → lets a component read (subscribe) to data from the store.  
- **`useDispatch`** → lets a component trigger an action that updates the store.  

These replace the older `connect()` HOC.

---

## 3. Where and When to Use Redux?
Use Redux when:
- Many components need the **same global state** (e.g., logged-in user, cart items, notifications).  
- You want **predictable state management** (all updates go through actions → reducers).  
- State updates should be **traceable/debuggable** (Redux DevTools helps track actions).  

Do **NOT** use Redux if:
- Your app is small and state is local to one or two components (just use `useState`, `useContext`).  

---

## 4. Real-World Use Case: **E-Commerce Shopping Cart**
### Problem:
- You have multiple pages: ProductList, ProductDetail, Cart.  
- All need to know which products are in the **cart**.  
- If user adds/removes from cart in one place, the others should **update instantly**.

---

### Step-by-Step Implementation

#### a) Install Redux Toolkit + React Redux
```bash
npm install @reduxjs/toolkit react-redux
```

---

#### b) Create a Redux Store (`store.js`)
```javascript
import { configureStore } from "@reduxjs/toolkit";
import cartReducer from "./cartSlice";

export const store = configureStore({
  reducer: {
    cart: cartReducer,
  },
});
```

---

#### c) Create a Slice (`cartSlice.js`)
```javascript
import { createSlice } from "@reduxjs/toolkit";

const cartSlice = createSlice({
  name: "cart",
  initialState: { items: [] },
  reducers: {
    addItem: (state, action) => {
      state.items.push(action.payload); // add product
    },
    removeItem: (state, action) => {
      state.items = state.items.filter(item => item.id !== action.payload);
    },
    clearCart: (state) => {
      state.items = [];
    }
  }
});

export const { addItem, removeItem, clearCart } = cartSlice.actions;
export default cartSlice.reducer;
```

---

#### d) Provide Store in App (`index.js`)
```javascript
import React from "react";
import ReactDOM from "react-dom/client";
import { Provider } from "react-redux";
import { store } from "./store";
import App from "./App";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <Provider store={store}>
    <App />
  </Provider>
);
```

---

#### e) Using Redux in Components

**ProductList.jsx** → Add to cart  
```javascript
import React from "react";
import { useDispatch } from "react-redux";
import { addItem } from "../cartSlice";

const products = [
  { id: 1, name: "Laptop", price: 80000 },
  { id: 2, name: "Phone", price: 40000 }
];

export default function ProductList() {
  const dispatch = useDispatch();

  return (
    <div>
      <h2>Products</h2>
      {products.map(p => (
        <div key={p.id}>
          {p.name} - ₹{p.price}
          <button onClick={() => dispatch(addItem(p))}>Add to Cart</button>
        </div>
      ))}
    </div>
  );
}
```

---

**Cart.jsx** → Show items from cart  
```javascript
import React from "react";
import { useSelector, useDispatch } from "react-redux";
import { removeItem, clearCart } from "../cartSlice";

export default function Cart() {
  const items = useSelector(state => state.cart.items);
  const dispatch = useDispatch();

  return (
    <div>
      <h2>Your Cart</h2>
      {items.length === 0 && <p>No items in cart.</p>}
      <ul>
        {items.map(item => (
          <li key={item.id}>
            {item.name} - ₹{item.price}
            <button onClick={() => dispatch(removeItem(item.id))}>Remove</button>
          </li>
        ))}
      </ul>
      {items.length > 0 && <button onClick={() => dispatch(clearCart())}>Clear Cart</button>}
    </div>
  );
}
```

---

## 5. Summary
- **`useRedux` (via `useSelector` + `useDispatch`)** connects React components to Redux store.  
- **When to use** → apps with shared global state (auth, cart, notifications, themes).  
- **Real case** → e-commerce cart, authentication flow, or role-based access.  
- Redux ensures: **predictable, scalable, and debuggable state management.**
