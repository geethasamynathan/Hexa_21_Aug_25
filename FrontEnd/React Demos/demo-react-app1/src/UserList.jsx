import React from "react";
import UserItem from "./UserItem";

export default function UserList({ users, onSelect }) {
  return (
    <>
      <div>
        <h2>
          <center>User List</center>
        </h2>
        <ul>
          {users.map((user) => (
            <li
              key={user.id}
              onClick={() => onSelect(user)}
              style={{
                cursor: "pointer",
                margin: "12px 0",
                padding: "5px",
                borderRadius: "5px",
                width: "300px",
              }}
            >
              <strong>{user.name}</strong> - {user.role}
            </li>
            //   <UserItem key={user.id} user={user} />
          ))}
        </ul>
      </div>
    </>
  );
}
