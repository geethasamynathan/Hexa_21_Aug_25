import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import RegistrationForm from "./RegistrationForm";
import RegistrationForm2 from "./RegistrationForm2";

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <RegistrationForm2 />
    </>
  );
}

export default App;
