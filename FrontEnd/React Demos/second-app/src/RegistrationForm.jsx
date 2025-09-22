import React, { useState } from "react";

export default function RegistrationForm() {
  const [formData, setFormData] = useState({
    username: "",
    email: "",
    password: "",
    address: "",
    country: "in",
  });

  const [errors, setErrors] = useState({});
  const [touched, setTouched] = useState({});

  const validate = (field, value) => {
    switch (field) {
      case "username":
        if (!value.trim()) return "username is required";
        break;
      case "email":
        if (!value.includes("@")) return "Enter valid email";
        break;
      case "password":
        if (value.length < 8) return "Pasword should have atleast 8 chars";
        break;
      default:
        return "";
    }
    return "";
  };
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ prev, [name]: value }));
    if (touched[name]) {
      setErrors((prev) => ({ ...prev, [name]: validate(name, value) }));
    }
  };

  const handleBlur = (e) => {
    const { name, value } = e.target;
    setTouched((prev) => ({ ...prev, [name]: true }));
    setErrors((prev) => ({ ...prev, [name]: validate(name, value) }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const newErrors = {};
    const newTouched = {};

    Object.keys(formData).forEach((field) => {
      const errorMsg = validate(field, formData[field]);
      if (errorMsg) newErrors[field] = errorMsg;
      newTouched[field] = true;
    });

    setTouched(newTouched);
    setErrors(newErrors);

    if (Object.keys(newErrors).length === 0)
      alert(`✅ Registation Success ${formData.username}`);

    // if (Object.keys(validationerrors).length > 0) {
    //   setErrors(validationerrors);
    // } else {
    //   setErrors({});
    //   alert(`✅ Registation Success ${formData.username}`);
    // }
  };
  return (
    <form
      onSubmit={handleSubmit}
      style={{ maxWidth: "400px", margin: "32px auto" }}
    >
      <h2>Registeration Form</h2>
      <div>
        <label>Username:</label>
        <br />
        <input
          type="text"
          name="username"
          value={formData.username}
          onChange={handleChange}
          onBlur={handleBlur}
        />
        {errors.username && touched.username && (
          <p style={{ color: "red" }}>{errors.username}</p>
        )}
      </div>

      <div>
        <label>Email:</label>
        <br />
        <input
          type="text"
          name="email"
          value={formData.email}
          onChange={handleChange}
          onBlur={handleBlur}
        />
        {errors.email && touched.email && (
          <p style={{ color: "red" }}>{errors.email}</p>
        )}
      </div>

      <div>
        <label>Password:</label>
        <br />
        <input
          type="password"
          name="password"
          value={formData.password}
          onChange={handleChange}
          onBlur={handleBlur}
        />
        {errors.password && touched.password && (
          <p style={{ color: "red" }}>{errors.password}</p>
        )}
      </div>
      <div>
        <label>address:</label>
        <br />
        <textarea
          name="address"
          value={formData.address}
          onChange={handleChange}
          onBlur={handleBlur}
          rows="5"
        />
      </div>

      <div>
        <label>Country</label>
        <select name="country" value={formData.country} onChange={handleChange}>
          <option value="in">India</option>
          <option value="us">United States America</option>
          <option value="fr">France</option>
        </select>
      </div>

      <button type="submit" style={{ marginTop: "16px" }}>
        Register
      </button>
    </form>
  );
}
