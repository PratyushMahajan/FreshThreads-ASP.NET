import React, { useState } from "react";
import CustomerProfile from "./CustomerDashboard/CustomerProfile";
import CurrentOrder from "./CustomerDashboard/CurrentOrder";
import PastOrders from "./CustomerDashboard/PastOrders";
import UsualShops from "./CustomerDashboard/UsualShops";

const User = () => {
  // Dummy data for customer profile
  const [customer] = useState({
    name: "Payal",
    email: "payalgajbe@example.com",
    address: "Abc, mumbai",
    contact: "7778889994",
  });

  // Dummy data for current order
  const [currentOrder] = useState({
    orderId: "5",
    items: [
      { name: "white clothes", quantity: 5 },
      { name: "dry clean", quantity: 4 },
    ],
    total: "450",
    status: "cleaning",
  });

  // Dummy data for past orders
  const [pastOrders] = useState([
    { id: "1", date: "2023-11-20", total: "300", status: "Delivered" },
    { id: "2", date: "2023-11-18", total: "140", status: "Delivered" },
    { id: "3", date: "2023-11-15", total: "150", status: "Cancelled" },
  ]);

  // Dummy data for usual shops
  const [usualShops] = useState([
    { name: "The cloths", address: "123 High St, mumbai" },
    { name: "clean", address: "456 Park Lane, navi-mumbai" },
    { name: "ultra clean", address: "789 Kings Road, bkc" },
  ]);

  return (
    <div className="container-fluid py-4">
      <h3>Customer Dashboard</h3>

      {/* Customer Profile */}
      <CustomerProfile customer={customer} />

      {/* Current Order */}
      <CurrentOrder currentOrder={currentOrder} />

      {/* Past Orders */}
      <PastOrders orders={pastOrders} />

      {/* Usual Shops */}
      <UsualShops shops={usualShops} />
    </div>
  );
};

export default User;
