import React, { useState, useRef } from "react";

// export default function SimpleForm() {
//   const [email, setEmail] = useState("sample@mail.com");
//   return (
//     <>
//       <form>
//         <input
//           type="email"
//           value={email}
//           onChange={(e) => setEmail(e.target.value)}
//         />
//       </form>
//       <p> {email}</p>
//     </>
//   );
// }

export default function SimpleForm() {
  const emailRef = useRef();
  const [email, setEmail] = useState();

  const handleChange = () => {
    setEmail(emailRef.current.value);
  };
  return (
    <>
      <form>
        <input type="email" ref={emailRef} onChange={handleChange} />
      </form>
      <p> {email}</p>
    </>
  );
}
