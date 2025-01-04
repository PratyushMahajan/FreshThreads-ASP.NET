import React, { useState } from 'react';
import { Container, Row, Col, Button, Form } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import "../style/s.css";

function SignupForm() {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [selectedOption, setSelectedOption] = useState('');
  
  // Track focus state for each field
  const [isFirstNameFocused, setIsFirstNameFocused] = useState(false);
  const [isLastNameFocused, setIsLastNameFocused] = useState(false);
  const [isPhoneNumberFocused, setIsPhoneNumberFocused] = useState(false);
  const [isEmailFocused, setIsEmailFocused] = useState(false);
  const [isPasswordFocused, setIsPasswordFocused] = useState(false);
  
  const [isFormVisible, setFormVisible] = useState(false);

  const handleFormToggle = () => {
    setFormVisible(!isFormVisible);
  };

  const handleSubmit = (event) => {
    event.preventDefault();

    // Basic validation
    if (!selectedOption || !firstName || !lastName || !phoneNumber || !email || !password) {
      setError('All fields are required.');
      return;
    }

    if (!/^\d{10}$/.test(phoneNumber)) {
      setError('Phone number must be 10 digits.');
      return;
    }

    const emailPattern = /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/;
    if (!emailPattern.test(email)) {
      setError('Please enter a valid email address.');
      return;
    }

    if (password.length < 6) {
      setError('Password must be at least 6 characters long.');
      return;
    }

    setError(''); // Clear error if no validation errors
    console.log('Form submitted:', { firstName, lastName, phoneNumber, email, password });
  };

  const handlePhoneNumberChange = (e) => {
    const value = e.target.value.replace(/[^0-9]/g, '');
    setPhoneNumber(value);
  };

  const isFormValid = firstName && lastName && phoneNumber && email && password &&
    /^\d{10}$/.test(phoneNumber) && /^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/.test(email) && password.length >= 6;

  return (
    <Container fluid>
      <Row className="align-items-center d-flex" style={{ minHeight: '100vh' }}>
        <Col md={6} className="text-center align-items-center">
          <h1 className="text-center font-weight-bold mb-4" style={{ color: '#1e1f21' }}>Welcome to Laundry Service</h1>
          <p className="text-center font-weight-grey mb-4">Save 3 hours this week by using our services.</p>
          <Button
            className="btn btn-primary btn-lg rounded-4 p-4 mb-3 w-75"
            style={{ backgroundColor: '#535bcd', border: 'none', maxWidth: '425px' }}
            onClick={handleFormToggle}
          >
            {isFormVisible ? 'Close' : 'Sign up with email'}
          </Button>
          <p className="text-center mt-5 fs-5" style={{ color: "grey" }}>
            Already have an account?<br />
            <Link to="/login" className='text-decoration-none text-primary-custom'>Login Instead</Link>
          </p>
          <p className="text-center mt-5 fs-5" style={{ color: "grey" }}>
            <Link to="/" className='text-decoration-none text-primary-custom'>Go to Home</Link>
          </p>
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
          <form onSubmit={handleSubmit}>
            {error && <div className="error-message" style={{ color: 'red', marginBottom: '10px' }}>{error}</div>}

            <div className={`ct-form-container d-flex flex-column justify-content-center align-items-center position-fixed top-0 start-0 w-100 h-100 bg-light ${isFormVisible ? 'show' : ''}`}>
              
              <div className="container-fluid d-flex justify-content-center align-items-center">
                <Row className="justify-content-center align-items-center vh-100">
                  <Col className="p-4">

                  <h2 className="font-weight-bold mb-4">Let's Get Started!</h2>
                  
                    <div className="mb-2 w-100 ">
                      <select
                        aria-label="Select an option"
                        value={selectedOption}
                        onChange={(e) => setSelectedOption(e.target.value)}
                        required
                        className=" responsive-input justify-content-center align-items-center fs-5 p-3 w-100"
                        style={{maxWidth:'400px'}}
                      >
                        <option value="">Register As</option>
                        <option value="option1">User</option>
                        <option value="option2">Shop-Owner</option>
                        <option value="option3">Delivery-Partner</option>
                      </select>
                    </div>
                    {error && <div className="text-danger">{error}</div>}

                    <div className="mb-2">
                      <input
                        type="text"
                        id="firstName"
                        placeholder="First name"
                        value={firstName}
                        onChange={(e) => setFirstName(e.target.value)}
                        onFocus={() => setIsFirstNameFocused(true)}
                        onBlur={() => setIsFirstNameFocused(false)}
                        required
                        className="rounded-4 p-3 mb-1 border-0 responsive-input"
                      />
                      {isFirstNameFocused && !firstName && <div className="form-text text-danger mb-1">Please Enter your First name</div>}
                    </div>

                    <div className="mb-2">
                      <input
                        type="text"
                        id="lastName"
                        placeholder="Last name"
                        value={lastName}
                        onChange={(e) => setLastName(e.target.value)}
                        onFocus={() => setIsLastNameFocused(true)}
                        onBlur={() => setIsLastNameFocused(false)}
                        required
                        className=" rounded-4 p-3 mb-1 border-0 responsive-input w-100"
                        style={{maxWidth:'18rem'}}
                      />
                      {isLastNameFocused && !lastName && <div className="form-text text-danger mb-1">Please Enter your Last name</div>}
                    </div>

                    <div className="mb-2">
                      <input
                        type="tel"
                        id="phoneNumber"
                        placeholder="Phone Number"
                        value={phoneNumber}
                        onChange={handlePhoneNumberChange}
                        onFocus={() => setIsPhoneNumberFocused(true)}
                        onBlur={() => setIsPhoneNumberFocused(false)}
                        required
                        className="rounded-4 p-3 mb-1 border-0 responsive-input"
                      />
                      {isPhoneNumberFocused && !/^\d{10}$/.test(phoneNumber) && <div className="form-text text-danger mb-1">Phone number must be 10 digits.</div>}
                    </div>

                    <div className="mb-2">
                      <input
                        type="email"
                        id="email"
                        placeholder="Email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        onFocus={() => setIsEmailFocused(true)}
                        onBlur={() => setIsEmailFocused(false)}
                        required
                        className="rounded-4 p-3 mb-1 border-0 responsive-input"
                      />
                      {isEmailFocused && !/^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/.test(email) && <div className="form-text text-danger mb-1">Please enter a valid email address.</div>}
                    </div>

                    <div className="mb-2">
                      <input
                        type="password"
                        id="password"
                        placeholder="Create Password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        onFocus={() => setIsPasswordFocused(true)}
                        onBlur={() => setIsPasswordFocused(false)}
                        required
                        className="rounded-4 p-3 mb-1 border-0 responsive-input"
                      />
                      {isPasswordFocused && password.length < 6 && <div className="form-text text-danger mb-1">Password must be at least 6 characters long.</div>}
                    </div>

                    <Button
                      type="submit"
                      disabled={!isFormValid}
                      className="ct-button btn btn-primary btn-lg rounded-4 p-4 mb-3 w-100"
                      style={{ backgroundColor: '#535bcd', border: 'none', maxWidth: '400px' }}
                    >
                      Sign Up
                    </Button>
                    <p className="text-center mt-5 fs-5" style={{ color: "grey" }}>
                      <Link to="/" className='text-decoration-none text-primary-custom'>Go to Home</Link>
                    </p>
                  </Col>
                </Row>
              </div>
            </div>
          </form>
        </div>
      </div>
    </Container>
  );
}

export default SignupForm;
