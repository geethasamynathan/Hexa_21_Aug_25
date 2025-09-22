import React, { useState, useEffect } from "react";

const setBodyClass = (theme) => {
  console.log("setBodyClass called");
  console.log("theme" + theme);
  document.body.classList.remove("light", "dark");
  document.body.classList.add(theme);
};
export default function ThemeToggle() {
  const [theme, setTheme] = useState(
    () => localStorage.getItem("theme") || "light"
  );

  useEffect(() => {
    setBodyClass(theme);
    localStorage.setItem("theme", theme);
  }, [theme]);

  const toggleTheme = () =>
    setTheme((prev) => (prev === "light" ? "dark" : "light"));

  return (
    <div>
      <button
        onClick={toggleTheme}
        style={{ padding: "8px 14px", margin: "32px" }}
      >
        Switch to {theme == "light" ? "Dark" : "Light"} Mode
      </button>
    </div>
  );
}
