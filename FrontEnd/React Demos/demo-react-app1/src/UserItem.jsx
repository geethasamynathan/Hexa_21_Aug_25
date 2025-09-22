import React from "react";
import UserCard from "./UsercardUsingPROPS";

export default function UserItem({ user }) {
  return (
    <>
      <div style={{ marginTop: "20px" }}>
        <h2>Selected User Information</h2>
        <UserCard user={user} />
      </div>
    </>
  );
}
