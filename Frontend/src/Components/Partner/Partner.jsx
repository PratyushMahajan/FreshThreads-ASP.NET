import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom"; // Import useNavigate

const Partner = () => {
  const [shopName, setShopName] = useState("");
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);
  const [userId, setUserId] = useState(null);
  const navigate = useNavigate(); // Initialize navigate

  useEffect(() => {
    const storedUserId = localStorage.getItem("userId");
    console.log("Extracted User ID:", storedUserId);

    if (!storedUserId) {
      alert("User ID is missing. Please log in again.");
      navigate("/login"); // Use navigate instead of href
      return;
    }

    setUserId(storedUserId);
  }, [navigate]); 

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (shopName.trim().length === 0 || shopName.length > 30) {
      alert("Shop name must be between 1 and 30 characters.");
      return;
    }

    const token = localStorage.getItem("token");

    if (!token || !userId) {
      alert("User is not logged in. Please log in again.");
      return;
    }

    setLoading(true);

    try {
      const response = await fetch("http://localhost:5161/api/shop", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify({
          ShopName: shopName,
          UserId: userId,
          Status: "Active",
        }),
      });
      console.log("Data being sent to API:", {
        ShopName: shopName,
        UserId: userId,
        Status: "Active",
      });
      

      if (response.ok) {
        alert("Shop registered successfully!");
        setTimeout(() => {
          navigate("/shopowner"); // Redirect without full page reload
        }, 1000);
      } else {
        const errorData = await response.json();
        alert(`Error: ${errorData.message || "Failed to register shop"}`);
      }
    } catch (error) {
      console.error("Error:", error);
      alert("Network error. Please try again.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="container my-5">
      <h1 className="mb-5">Name of your Shop</h1>
      <form className="partner-form" onSubmit={handleSubmit}>
        <div className="mb-3">
          <input
            type="text"
            className="form-control"
            id="name"
            placeholder="Write here"
            value={shopName}
            onChange={(e) => setShopName(e.target.value)}
          />
          {error && <small className="text-danger">{error}</small>}
        </div>
        <button type="submit" className="btn btn-primary mb-5 mt-3" disabled={!!error || loading}>
          {loading ? "Submitting..." : "Submit"}
        </button>
      </form>
    </div>
  );
};

export default Partner;
