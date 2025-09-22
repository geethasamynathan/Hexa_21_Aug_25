import React from "react";
import { useUser } from "./UserContext";

export default function Header() {
  const user = useUser();

  //   const user = {
  //     name: "Tina",
  //     avatarUrl: "https://i.pravatar.cc/150?u=aarav",
  //   };

  return (
    <header>
      <h2>Welcome, {user.name}</h2>
      <img
        src={user.avatarUrl}
        alt={user.name}
        style={{ width: "50px", borderRadius: "50%" }}
      />
    </header>
  );
}
