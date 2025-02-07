import React, { useState } from "react";
import { Container, Row, Col, Button, Form } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import axios from "axios";
import "../style/s.css";

function Signup() {
  const [formData, setFormData] = useState({
    firstName: "",
    // lastName: "",
    phoneNumber: "",
    email: "",
    password: "",
    address: "",
    city: "",
    userRole: "ROLE_USER",
  });

  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    // Basic validation
    const { firstName,  phoneNumber, email, password, address, city, userRoles } = formData;

    if (!firstName ||  !phoneNumber || !email || !password || !address || !city || !userRoles) {
      setError("All fields are required.");
      return;
    }

    if (!/^\d{10}$/.test(phoneNumber)) {
      setError("Phone number must be 10 digits.");
      return;
    }

    const emailPattern = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/;
    if (!emailPattern.test(email)) {
      setError("Please enter a valid email address.");
      return;
    }

    if (password.length < 6) {
      setError("Password must be at least 6 characters long.");
      return;
    }
    if (password.length > 24) {
      setError("Password cannot exceed 24 characters.");
      return;
  }
    console.log(formData.firstName)
    try {
      // Axios POST request
     
      const response = await axios.post("http://localhost:5161/api/Auth/adduser", formData);

      if (response.status === 201) {
        alert("Signup successful!");
        navigate("/login"); // Navigate to the login page
      } else {
        setError("Something went wrong. Please try again.");
      }
    } catch (err) {
      setError(err.response?.data?.message || "Signup failed. Please try again.");
    }
  };

  return (
    <Container fluid>
      <Row className="align-items-center d-flex" style={{ minHeight: "100vh" }}>
        <Col md={6} className="text-center align-items-center">
          <h1 className="text-center font-weight-bold mb-4" style={{ color: "#1e1f21" }}>
            Welcome to Laundry Service
          </h1>
          <p className="text-center font-weight-grey mb-4">Save 3 hours this week by using our services.</p>
        </Col>
        <Col md={6} className="p-0 position-relative">
          <img
            src="src/Components/Auth/image/laundryservice2.jpg"
            alt="Laundry"
            className="img-fluid"
            style={{ objectFit: "cover", width: "100%", height: "100%" }}
          />
        </Col>
      </Row>
      <div className="container-fluid my-5 d-flex justify-content-center align-items-center vh-100">
        <div className="signup-form">
          <form onSubmit={handleSubmit}
          style={{
            maxWidth: "600px", // Adjust this value as needed
            width: "140%",
            padding: "20px",
            boxShadow: "0 4px 8px rgba(0, 0, 0, 0.1)",
            backgroundColor: "#fff",
            borderRadius: "10px",
          }}
          >
            <h2 className="text-center font-weight-bold mb-4">Sign Up</h2>
            {error && <div className="error-message" style={{ color: "red", marginBottom: "10px" }}>{error}</div>}
            <div className="mb-2">
              <input
                type="text"
                name="firstName"
                placeholder="First name"
                value={formData.firstName}
                onChange={handleChange}
                required
                className="rounded-4 p-3 mb-1 border-0 responsive-input"
              />
            </div>
            {/* <div className="mb-2">
              <input
                type="text"
                name="lastName"
                placeholder="Last name"
                value={formData.lastName}
                onChange={handleChange}
                required
                className="rounded-4 p-3 mb-1 border-0 responsive-input"
              />
            </div> */}
            <div className="mb-2">
              <input
                type="tel"
                name="phoneNumber"
                placeholder="Phone Number"
                value={formData.phoneNumber}
                onChange={handleChange}
                required
                className="rounded-4 p-3 mb-1 border-0 responsive-input"
              />
            </div>
            <div className="mb-2">
              <input
                type="text"
                name="address"
                placeholder="Address"
                value={formData.address}
                onChange={handleChange}
                required
                className="rounded-4 p-3 mb-1 border-0 responsive-input"
              />
            </div>
            <div className="mb-2">
              <input
                type="text"
                name="city"
                placeholder="City"
                value={formData.city}
                onChange={handleChange}
                required
                className="rounded-4 p-3 mb-1 border-0 responsive-input"
              />
            </div>
            <div className="mb-2">
              <input
                type="email"
                name="email"
                placeholder="Email"
                value={formData.email}
                onChange={handleChange}
                required
                className="rounded-4 p-3 mb-1 border-0 responsive-input"
              />
            </div>
            <div className="mb-2">
              <input
                type="password"
                name="password"
                placeholder="Create Password"
                value={formData.password}
                onChange={handleChange}
                required
                className="rounded-4 p-3 mb-1 border-0 responsive-input"
              />
            </div>
            <div className="mb-2">
              <select
                name="userRoles"
                value={formData.userRole}
                onChange={handleChange}
                required
                className="w-full px-3 py-2 border rounded-md"
              >
                <option value="">Select Role</option>
                <option value="ROLE_USER">Customer</option>
                <option value="ROLE_SHOP">Shop</option>
                <option value="ROLE_DELIVERY">Delivery</option>
              </select>
            </div>
            <Button
              type="submit"
              className="ct-button btn btn-primary btn-lg rounded-4 p-4 mb-3 w-100"
              style={{ backgroundColor: "#535bcd", border: "none", maxWidth: "400px" }}
            >
              Sign Up
            </Button>
          </form>
        </div>
      </div>
    </Container>
  );
}

export default Signup;