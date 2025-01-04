import React from "react";
import { Card } from "react-bootstrap";

const CustomerProfile = ({ customer }) => {
  const { name, email, address, contact } = customer;

  return (
    <Card className="mb-4 shadow">
      <Card.Body>
        {/* <div className="text-center">
          <img
            src="https://via.placeholder.com/150" // Replace with a real image
            alt="Customer Profile"
            className="rounded-circle mb-3"
            style={{ width: "100px", height: "100px", objectFit: "cover" }}
          />
        </div> */}
        <h4 className="text-center mt-4">{name}</h4>
        <p className="text-muted text-center">{email}</p>
        <p className="text-muted text-center">{address}</p>
        <ul className="list-group list-group-flush">
          <li className="list-group-item">
            <strong>Contact: </strong> {contact}
          </li>
        </ul>
      </Card.Body>
    </Card>
  );
};

export default CustomerProfile;
