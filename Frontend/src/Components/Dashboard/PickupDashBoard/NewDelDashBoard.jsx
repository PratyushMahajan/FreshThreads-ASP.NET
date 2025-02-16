import React, { useEffect, useState } from "react";
import { Card, Button, Table, Spinner, Alert } from "react-bootstrap";
import axios from "axios";
import "bootstrap/dist/css/bootstrap.min.css";

const NewDelDashboard = () => {
  const [deliveries, setDeliveries] = useState(null);
  const [error, setError] = useState(null);
  
  useEffect(() => {
    fetchDeliveries();
  }, []);

  const fetchDeliveries = async () => {
    try {
      const response = await axios.get("http://localhost:5161/api/Delivery", {
        headers: { Authorization: `Bearer ${localStorage.getItem("token")}` }
      });
      console.log(response)
      setDeliveries(Array.isArray(response.data) ? response.data : response.data.data || []);
    } catch (error) {
      console.error("Error fetching deliveries:", error);
      setError("Failed to load deliveries. Please check your authentication.");
      setDeliveries([]);
    }
  };

  const updateStatus = async (id, newStatus) => {
    try {
      await axios.put(`http://localhost:5161/api/Delivery/update/${id}`, 
        { deliveryId: id, deliveryStatus: newStatus },
        { headers: { Authorization: `Bearer ${localStorage.getItem("token")}` } }
      );
      fetchDeliveries(); // Refresh the data after update
    } catch (error) {
      console.error("Error updating delivery status:", error);
      setError("Failed to update delivery status.");
    }
  };

  return (
    <div className="container mt-4" style={{ backgroundColor: "#fff", padding: "20px", borderRadius: "10px" }}>
      <h2 className="text-center mb-4" style={{ color: "#FF6600" }}>Delivery Dashboard</h2>
      {error && <Alert variant="danger">{error}</Alert>}
      {deliveries === null ? (
        <div className="text-center">
          <Spinner animation="border" variant="warning" />
          <p>Loading deliveries...</p>
        </div>
      ) : (
        <Table striped bordered hover className="shadow" style={{ backgroundColor: "#000", color: "#fff" }}>
          <thead>
            <tr style={{ backgroundColor: "#FF6600", color: "#000" }}>
              <th>ID</th>
              <th>Pickup Time</th>
              {/* <th>Drop Time</th> */}
              <th>Status</th>
              <th>Delivery Person</th>
              <th>Contact</th>
              {/* <th>Actions</th> */}
            </tr>
          </thead>
          <tbody>
  {deliveries.length > 0 ? (
    deliveries.map(({ deliveryId, deliveryDate, dropTime, deliveryStatus, deliveryPersonName, deliveryPersonPhone }) => (
      <tr key={deliveryId}>
        <td>{deliveryId}</td>
        <td>{deliveryDate ? new Date(deliveryDate).toLocaleString() : "N/A"}</td>
        {/* <td>{dropTime ? new Date(dropTime).toLocaleString() : "N/A"}</td> */}
        <td>{deliveryStatus}</td>
        <td>{deliveryPersonName}</td>
        <td>{deliveryPersonPhone}</td>
        {/* <td>
          <Button 
            variant="warning" 
            size="sm" 
            className="me-2"
            onClick={() => updateStatus(deliveryId, "In Progress")}
          >
            Mark In Progress
          </Button>
          <Button 
            variant="success" 
            size="sm" 
            className="me-2"
            onClick={() => updateStatus(deliveryId, "Delivered")}
          >
            Mark Delivered
          </Button>
          <Button 
            variant="danger" 
            size="sm"
            onClick={() => updateStatus(deliveryId, "Canceled")}
          >
            Cancel
          </Button>
        </td> */}
      </tr>
    ))
  ) : (
    <tr>
      <td colSpan="7" className="text-center text-light">No deliveries available.</td>
    </tr>
  )}
</tbody>

        </Table>
      )}
    </div>
  );
};

export default NewDelDashboard;
