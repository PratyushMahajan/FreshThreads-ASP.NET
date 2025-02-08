import React, { useState, useEffect } from "react";
import axios from "axios";
import OrderDetails from "./ShopOwnerDashboard/SOrderDetails";
import PickupOverview from "./ShopOwnerDashboard/SPickupOverview";
import PaymentStatus from "./ShopOwnerDashboard/SPaymentStatus";
import ShopDetails from "./ShopOwnerDashboard/SShopDetails";
import { jwtDecode } from "jwt-decode"; 

const ShowOwnerDashboard = ({ userId }) => {
  const [orders, setOrders] = useState([
    { id: "001", user: "Ace", status: "Ready", payment: "paid" },
    { id: "002", user: "Ben", status: "Cleaning", payment: "pending" },
    { id: "003", user: "Charlie", status: "Not Started", payment: "pending" },
  ]);

  const [pickups] = useState([
    { id: "P001", location: "loc A", time: "10:00 AM" },
    { id: "P002", location: "loc B", time: "11:00 AM" },
  ]);

  const [payments, setPayments] = useState({
    completed: 1,
    pending: 2,
  });

  const [shop, setShop] = useState({ 
    name: "", 
    address: "", 
    //shopname: "" 
  });

  useEffect(() => {
    // Get JWT token from localStorage
    const token = localStorage.getItem("token");

    if (!token) {
      console.error("JWT Token not found!");
      return;
    }

    // Decode JWT to extract userId
    const decodedToken = jwtDecode(token);
    console.log("Decoded Token:", decodedToken);

    const userId = decodedToken?.Id; 

    console.log("Extracted userId:", userId);

    if (!userId) {
      console.error("User ID not found in token!");
      return;
    }

    const fetchShopDetails = async () => {
      try {
        const token = localStorage.getItem("token"); // Retrieve token
    
        if (!token) {
          console.error("JWT Token not found!");
          return;
        }
    
        const headers = { Authorization: `Bearer ${token}` }; // Add Auth header
    
        const userResponse = await axios.get(`http://localhost:5161/api/users/${userId}`, { headers });
        const { name, address } = userResponse.data;
    
        // const shopResponse = await axios.get(`http://localhost:5161/api/shop/${userId}`, { headers });
        // const { shopname } = shopResponse.data;
    
        setShop({ 
          name, 
          address, 
          //shopname 
        });
      } catch (error) {
        console.error("Error fetching shop details:", error);
      }
    };
    

    fetchShopDetails();
  }, []);

  // Function to update the status of an order
  const updateOrderStatus = (id, newStatus) => {
    const updatedOrders = orders.map((order) =>
      order.id === id ? { ...order, status: newStatus } : order
    );
    setOrders(updatedOrders);
  };

  // Function to update the payment status of an order
  const updateOrderPayment = (id, newPayment) => {
    const updatedOrders = orders.map((order) =>
      order.id === id ? { ...order, payment: newPayment } : order
    );
    setOrders(updatedOrders);

    // Recalculate payments
    const completed = updatedOrders.filter((order) => order.payment === "paid").length;
    const pending = updatedOrders.filter((order) => order.payment === "pending").length;

    setPayments({ completed, pending });
  };

  return (
    <div className="container-fluid py-4">
      <div className="row d-flex justify-content-center">
        <div className="col-md-12">
          <h3>Owner Dashboard</h3>
          <hr />
          <ShopDetails shop={shop} />
        </div>
        <div className="col-md-12">
          <OrderDetails
            orders={orders}
            updateOrderStatus={updateOrderStatus}
            updateOrderPayment={updateOrderPayment}
          />
        </div>
        <div className="col-md-12">
          <PickupOverview pickups={pickups} />
        </div>
        <div className="col-md-12">
          <PaymentStatus payments={payments} />
        </div>
      </div>
    </div>
  );
};

export default ShowOwnerDashboard;
