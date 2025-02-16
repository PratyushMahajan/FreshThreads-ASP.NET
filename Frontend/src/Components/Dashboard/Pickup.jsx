import React from 'react'
import Header from './PickupDashBoard/Header'
import Sidebar from './PickupDashBoard/Sidebar'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import OrderDetails from './PickupDashBoard/OrderDetails'
import DeliveryManProfile from './PickupDashBoard/DeliveryManProfile'
import CompletedOrders from './PickupDashBoard/CompletedOrders';
import DelNavbar from './PickupDashBoard/DelNavbar';
import NewDelDashboard from './PickupDashBoard/NewDelDashBoard';


const User = () => {
  return (
      <div className="d-flex">
      {/* Sidebar */}
      {/* <Sidebar /> */}

      {/* Main Content */}
      <div className="flex-grow-1">
        {/* Header */}
        {/* <Header /> */}

        <DelNavbar/>
        <NewDelDashboard/>

        {/* Order Details */}
        {/* <DeliveryManProfile/> */}
        {/* <OrderDetails /> */}
        {/* <CompletedOrders/> */}
        {/* made by payal Gajbe*/}
      </div>
    </div>


  )
}

export default User

