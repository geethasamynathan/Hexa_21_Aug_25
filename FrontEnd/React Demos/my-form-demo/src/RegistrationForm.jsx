import React, { useState } from "react";

export default function RegistrationForm() {
  const [formData, setFormData] = useState({
    username: "",
    email: "",
    password: "",
    bio: "",
    country: "in",
  });

  const [errors, setErrors] = useState({});

  // ✅ Validation logic
  const validate = () => {
    const newErrors = {};
    if (!formData.username.trim()) newErrors.username = "Username is required";
    if (!formData.email.includes("@")) newErrors.email = "Enter a valid email";
    if (formData.password.length < 6)
      newErrors.password = "Password must be at least 6 characters";
    return newErrors;
  };

  // ✅ Handle input changes
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
  };

  // ✅ Handle form submission
  const handleSubmit = (e) => {
    e.preventDefault();
    const validationErrors = validate();
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
    } else {
      setErrors({});
      alert(`✅ Registration successful!\nWelcome, ${formData.username}`);
      // In real-world: send data to backend API here
    }
  };

  return (
    <form
      onSubmit={handleSubmit}
      style={{ maxWidth: "400px", margin: "2rem auto" }}
    >
      <h2>User Registration</h2>

      {/* Username */}
      <div>
        <label>Username:</label>
        <br />
        <input
          type="text"
          name="username"
          value={formData.username}
          onChange={handleChange}
        />
        {errors.username && <p style={{ color: "red" }}>{errors.username}</p>}
      </div>

      {/* Email */}
      <div>
        <label>Email:</label>
        <br />
        <input
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
        />
        {errors.email && <p style={{ color: "red" }}>{errors.email}</p>}
      </div>

      {/* Password */}
      <div>
        <label>Password:</label>
        <br />
        <input
          type="password"
          name="password"
          value={formData.password}
          onChange={handleChange}
        />
        {errors.password && <p style={{ color: "red" }}>{errors.password}</p>}
      </div>

      {/* Bio */}
      <div>
        <label>Bio:</label>
        <br />
        <textarea
          name="bio"
          value={formData.bio}
          onChange={handleChange}
          rows="3"
        />
      </div>

      {/* Country */}
      <div>
        <label>Country:</label>
        <br />
        <select name="country" value={formData.country} onChange={handleChange}>
          <option value="in">India</option>
          <option value="us">USA</option>
          <option value="uk">UK</option>
        </select>
      </div>

      <button type="submit" style={{ marginTop: "1rem" }}>
        Register
      </button>
    </form>
  );
}
