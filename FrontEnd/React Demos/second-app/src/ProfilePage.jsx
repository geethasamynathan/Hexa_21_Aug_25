import React from "react";
import { useUser } from "./UserContext";

export default function ProfilePage() {
  const user = useUser();
  return (
    <div>
      <h3> User details</h3>
      <p>Name: {user.name}</p>
      <img
        src={user.avatarUrl}
        alt={user.name}
        style={{ width: "200px", borderRadius: "20%" }}
      />
    </div>
  );
}
