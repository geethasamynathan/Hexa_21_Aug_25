import React, { useState } from "react";
import "./RegistrationForm2.css";
export default function RegistrationForm() {
  const [formData, setFormData] = useState({
    username: "",
    email: "",
    password: "",
    bio: "",
    country: "in",
  });

  const [errors, setErrors] = useState({});
  const [touched, setTouched] = useState({});

  // Validation logic
  const validate = (field, value) => {
    switch (field) {
      case "username":
        if (!value.trim()) return "Username is required";
        break;
      case "email":
        if (!value.includes("@")) return "Enter a valid email";
        break;
      case "password":
        if (value.length < 6) return "Password must be at least 6 characters";
        break;
      default:
        return "";
    }
    return "";
  };

  // Handle input changes
  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({ ...prev, [name]: value }));
    if (touched[name]) {
      setErrors((prev) => ({ ...prev, [name]: validate(name, value) }));
    }
  };

  // Handle blur (leaving field)
  const handleBlur = (e) => {
    const { name, value } = e.target;
    setTouched((prev) => ({ ...prev, [name]: true }));
    setErrors((prev) => ({ ...prev, [name]: validate(name, value) }));
  };

  // Handle form submission
  const handleSubmit = (e) => {
    e.preventDefault();
    const newErrors = {};
    const newTouched = {};

    // Validate all fields
    Object.keys(formData).forEach((field) => {
      const errorMsg = validate(field, formData[field]);
      if (errorMsg) newErrors[field] = errorMsg;
      newTouched[field] = true; // mark all as touched
    });

    setTouched(newTouched);
    setErrors(newErrors);

    // If no errors → success
    if (Object.keys(newErrors).length === 0) {
      alert(`✅ Registration successful!\nWelcome, ${formData.username}`);
    }
  };

  return (
    <div className="form-bg">
      <form className="form-card" onSubmit={handleSubmit}>
        <h2 className="form-title">User Registration</h2>

        {/* Username */}
        <div className="form-group">
          <label>Username</label>
          <input
            type="text"
            name="username"
            value={formData.username}
            onChange={handleChange}
            onBlur={handleBlur}
          />
          {touched.username && errors.username && (
            <p className="error-text">{errors.username}</p>
          )}
        </div>

        {/* Email */}
        <div className="form-group">
          <label>Email</label>
          <input
            type="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
            onBlur={handleBlur}
          />
          {touched.email && errors.email && (
            <p className="error-text">{errors.email}</p>
          )}
        </div>

        {/* Password */}
        <div className="form-group">
          <label>Password</label>
          <input
            type="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
            onBlur={handleBlur}
          />
          {touched.password && errors.password && (
            <p className="error-text">{errors.password}</p>
          )}
        </div>

        {/* Bio */}
        <div className="form-group">
          <label>Bio</label>
          <textarea
            name="bio"
            value={formData.bio}
            onChange={handleChange}
            onBlur={handleBlur}
            rows="3"
          />
        </div>

        {/* Country */}
        <div className="form-group">
          <label>Country</label>
          <select
            name="country"
            value={formData.country}
            onChange={handleChange}
            onBlur={handleBlur}
          >
            <option value="in">India</option>
            <option value="us">USA</option>
            <option value="uk">UK</option>
          </select>
        </div>

        <button type="submit" className="submit-btn">
          Register
        </button>
      </form>
    </div>
  );
}
