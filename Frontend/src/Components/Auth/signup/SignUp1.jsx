import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const SignUp1 = () => {
  const [formData, setFormData] = useState({
    name: "",
    email: "",
    password: "",
    phonenumber: "",
    city: "",
    address: "",
    role: "ROLE_USER",
  });
  const navigate = useNavigate();

  const [message, setMessage] = useState("");

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    console.log(formData);

    try {
      console.log(formData);

      const response = await axios.post(
        "http://localhost:5161/api/Auth/adduser",
        formData,
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      setMessage("Signup successful! Please log in.");
      setFormData({
        name: "",
        email: "",
        password: "",
        phonenumber: "",
        city: "",
        address: "",
        role: "ROLE_USER", // Reset to default value
      });
      console.log("Signup Response:", response);
      navigate("/login"); // Redirect to login page
    } catch (error) {
      const errorMsg =
        error.response?.data?.message || "An error occurred during signup.";
      setMessage(errorMsg);
      console.error("Signup Error:", error);
    }
  };

  return (
    <div className="max-w-md mx-auto p-4 bg-white shadow-lg rounded-md m-5">
      <h2 className="text-xl font-bold mb-4 ">Signup</h2>
      {message && <p className="mb-4 text-sm text-green-500">{message}</p>}
      <form onSubmit={handleSubmit}>
        <div className="mb-4">
          <label htmlFor="name" className="block text-sm font-medium">
            Name
          </label>
          <input
            type="text"
            id="name"
            name="name"
            value={formData.name}
            onChange={handleChange}
            required
            className="w-full px-3 py-2 border rounded-md"
          />
        </div>

        <div className="mb-4">
          <label htmlFor="email" className="block text-sm font-medium">
            Email
          </label>
          <input
            type="email"
            id="email"
            name="email"
            value={formData.email}
            onChange={handleChange}
            required
            className="w-full px-3 py-2 border rounded-md"
          />
        </div>

        <div className="mb-4">
          <label htmlFor="password" className="block text-sm font-medium">
            Password
          </label>
          <input
            type="password"
            id="password"
            name="password"
            value={formData.password}
            onChange={handleChange}
            required
            className="w-full px-3 py-2 border rounded-md"
          />
        </div>

        <div className="mb-4">
          <label htmlFor="city" className="block text-sm font-medium">
            City
          </label>
          <input
            type="text"
            id="city"
            name="city"
            value={formData.city}
            onChange={handleChange}
            required
            className="w-full px-3 py-2 border rounded-md"
          />
        </div>

        <div className="mb-4">
          <label htmlFor="address" className="block text-sm font-medium">
            Address
          </label>
          <input
            type="text"
            id="address"
            name="address"
            value={formData.address}
            onChange={handleChange}
            required
            className="w-full px-3 py-2 border rounded-md"
          />
        </div>

        <div className="mb-4">
          <label htmlFor="phonenumber" className="block text-sm font-medium">
            Phone Number
          </label>
          <input
            type="number"
            id="phonenumber"
            name="phonenumber"
            value={formData.phonenumber}
            onChange={handleChange}
            required
            className="w-full px-3 py-2 border rounded-md"
          />
        </div>

        <div className="mb-4">
          <label htmlFor="role" className="block text-sm font-medium">
            User Role
          </label>
          <select
            id="role"
            name="role"
            value={formData.userRoles}
            onChange={handleChange}
            className="w-full px-3 py-2 border rounded-md"
          >
            <option value="ROLE_USER">Customer</option>
            <option value="ROLE_SHOP">Shop</option>
            <option value="ROLE_DELIVERY">Delivery</option>
          </select>
        </div>

        <button
          type="submit"
          className="w-full px-4 py-2 text-white bg-blue-600 rounded-md hover:bg-blue-700"
        >
          Signup
        </button>
      </form>
    </div>
  );
};

export default SignUp1;
