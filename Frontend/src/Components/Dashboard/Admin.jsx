import React, { useEffect, useState } from 'react';
import api from './api';
import './Admin.css';

const Admin = () => {
  const [activeSection, setActiveSection] = useState('orders');
  const [orders, setOrders] = useState([]);
  const [customers, setCustomers] = useState([]);
  const [delivery, setDelivery] = useState([]);
  const [shopOwners, setShopOwners] = useState([]);

  useEffect(() => {
    if (activeSection === 'orders') fetchOrders();
    if (activeSection === 'customers') fetchCustomers();
    if (activeSection === 'delivery') fetchDelivery();
    if (activeSection === 'shopowners') fetchShopOwners();
  }, [activeSection]);

  const fetchOrders = async () => {
    try {
      const response = await api.get('/orders');
      setOrders(response.data);
    } catch (error) {
      console.error('Error fetching orders:', error);
    }
  };

  const fetchCustomers = async () => {
    try {
      const response = await api.get('/customers');
      setCustomers(response.data);
    } catch (error) {
      console.error('Error fetching customers:', error);
    }
  };

  const fetchDelivery = async () => {
    try {
      const response = await api.get('/delivery');
      setDelivery(response.data);
    } catch (error) {
      console.error('Error fetching delivery personnel:', error);
    }
  };

  const fetchShopOwners = async () => {
    try {
      const response = await api.get('/shopowners');
      setShopOwners(response.data);
    } catch (error) {
      console.error('Error fetching shop owners:', error);
    }
  };

  return (
    <div className="container-fluid" style={{ height: '100vh', backgroundColor: '#ffffff' }}>
      <div className="row h-100">
        {/* Sidebar */}
        <aside className="col-2 bg-dark text-white py-3">
          <h4 className="text-center mb-4" style={{ color: 'orange' }}>Admin Control</h4>
          <ul className="nav flex-column">
            <li className="nav-item">
              <button
                className={`nav-link btn ${activeSection === 'orders' ? 'btn-orange' : 'btn-dark'} text-white w-100`}
                onClick={() => setActiveSection('orders')}
              >
                Orders
              </button>
            </li>
            <li className="nav-item mt-2">
              <button
                className={`nav-link btn ${activeSection === 'customers' ? 'btn-orange' : 'btn-dark'} text-white w-100`}
                onClick={() => setActiveSection('customers')}
              >
                Customers
              </button>
            </li>
            <li className="nav-item mt-2">
              <button
                className={`nav-link btn ${activeSection === 'delivery' ? 'btn-orange' : 'btn-dark'} text-white w-100`}
                onClick={() => setActiveSection('delivery')}
              >
                Delivery
              </button>
            </li>
            <li className="nav-item mt-2">
              <button
                className={`nav-link btn ${activeSection === 'shopowners' ? 'btn-orange' : 'btn-dark'} text-white w-100`}
                onClick={() => setActiveSection('shopowners')}
              >
                Shop Owners
              </button>
            </li>
          </ul>
        </aside>

        {/* Main Content */}
        <main className="col-10 py-4">
          <h1 className="text-center mb-5" style={{ color: 'orange' }}>Admin Dashboard</h1>
          {activeSection === 'orders' && (
            <section>
              <h3 className="text-black">All Orders</h3>
              <table className="table table-striped">
                <thead className="bg-orange text-white">
                  <tr>
                    <th>Order ID</th>
                    <th>Items</th>
                    <th>No. of Items</th>
                    <th>Price</th>
                    <th>Pickup</th>
                    <th>Dropoff</th>
                  </tr>
                </thead>
                <tbody>
                  {orders.map((order) => (
                    <tr key={order.orderId}>
                      <td>{order.orderId}</td>
                      <td>{order.items}</td>
                      <td>{order.numberOfItems}</td>
                      <td>{order.price}</td>
                      <td>{order.pickup}</td>
                      <td>{order.dropoff}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </section>
          )}
          {activeSection === 'customers' && (
            <section>
              <h3 className="text-black">All Customers</h3>
              <table className="table table-striped">
                <thead className="bg-orange text-white">
                  <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Contact</th>
                    <th>Address</th>
                  </tr>
                </thead>
                <tbody>
                  {customers.map((customer) => (
                    <tr key={customer.id}>
                      <td>{customer.id}</td>
                      <td>{customer.name}</td>
                      <td>{customer.contact}</td>
                      <td>{customer.address}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </section>
          )}
          {activeSection === 'delivery' && (
            <section>
              <h3 className="text-black">All Delivery Personnel</h3>
              <table className="table table-striped">
                <thead className="bg-orange text-white">
                  <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Contact</th>
                  </tr>
                </thead>
                <tbody>
                  {delivery.map((person) => (
                    <tr key={person.id}>
                      <td>{person.id}</td>
                      <td>{person.name}</td>
                      <td>{person.contact}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </section>
          )}
          {activeSection === 'shopowners' && (
            <section>
              <h3 className="text-black">All Shop Owners</h3>
              <table className="table table-striped">
                <thead className="bg-orange text-white">
                  <tr>
                    <th>ID</th>
                    <th>Shop Name</th>
                    <th>Location</th>
                    <th>Contact</th>
                  </tr>
                </thead>
                <tbody>
                  {shopOwners.map((owner) => (
                    <tr key={owner.id}>
                      <td>{owner.id}</td>
                      <td>{owner.shopName}</td>
                      <td>{owner.location}</td>
                      <td>{owner.contact}</td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </section>
          )}
        </main>
      </div>
    </div>
  );
};

export default Admin;
