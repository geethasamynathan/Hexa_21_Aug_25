import React from "react";

// export default function UserCard(props) {
//   return (
//     <div style={{ border: "1px solid gray", padding: "10px", margin: "10px" }}>
//       <h2>{props.name}</h2>
//       <p>Position :{props.position}</p>
//     </div>
//   );
// }

export default function UserCard({ user }) {
  return (
    <>
      <h2>User Details</h2>
      {/* {users.map((user) => ( */}
      <div
        key={user.id}
        style={{
          border: "1px solid gray",
          padding: "10px",
          margin: "10px",
          background: "teal",
        }}
      >
        <h2>{user.name}</h2>
        <p>Position :{user.role}</p>
      </div>
      {/* ))} */}
    </>
  );
}
