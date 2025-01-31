import React, { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux'; 
import { loginUser, clearError } from '../../../features/authSlice'; 
import { Link, useNavigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';

function LoginForm() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [isFormValid, setIsFormValid] = useState(false);

  const dispatch = useDispatch(); // Initialize dispatch
  const navigate = useNavigate();

  // Access loading and error state from Redux
  const { loading, error } = useSelector((state) => state.auth);

  // Validate form whenever email or password changes
  useEffect(() => {
    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    const isEmailValid = emailPattern.test(email);
    const isPasswordValid = password.length >= 6;
    setIsFormValid(isEmailValid && isPasswordValid);
  }, [email, password]);

  const handleEmailChange = (e) => {
    setEmail(e.target.value);
    dispatch(clearError()); // Clear any previous errors
  };

  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
    dispatch(clearError()); // Clear any previous errors
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!isFormValid) {
      return;
    }

    // Dispatch the loginUser action
    const result = await dispatch(loginUser({ email, password }));

    // If login is successful, navigate to the homepage
    if (loginUser.fulfilled.match(result)) {
      navigate('/');
    }
  };

  return (
    <div className="container my-5 d-flex justify-content-center align-items-center vh-100">
      <div className="col-md-6 col-lg-4">
        <form onSubmit={handleSubmit} noValidate>
          {error && <div style={{ color: 'red', marginBottom: '10px' }}>{error}</div>}
          <h1 className="font-weight-bold mb-4 text-center">Welcome Back!</h1>

          <div className="mb-3">
            <input
              type="email"
              id="email"
              placeholder="Email"
              value={email}
              onChange={handleEmailChange}
              required
              className="form-control form-control-lg"
            />
            <div className="form-text text-danger">
              {email && !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email) && 'Enter a valid email address.'}
            </div>
          </div>

          <div className="mb-3">
            <input
              type="password"
              id="password"
              placeholder="Password"
              value={password}
              onChange={handlePasswordChange}
              required
              className="form-control form-control-lg"
            />
            <div className="form-text text-danger">
              {password && password.length < 6 && 'Password must be at least 6 characters long.'}
            </div>
          </div>

          <button
            type="submit"
            className="btn btn-primary btn-lg w-100"
            disabled={!isFormValid || loading} // Disable button while loading
          >
            {loading ? 'Logging In...' : 'Login'} {/* Show loading text */}
          </button>

          <p className="text-center mt-3 fs-5" style={{ color: 'grey' }}>
            Don't have an account?{' '}
            <Link to="/signup" className="text-decoration-none text-primary-custom">
              Sign up
            </Link>
          </p>

          <p className="text-center mt-5 fs-5" style={{ color: 'grey' }}>
            <Link to="/" className="text-decoration-none text-primary-custom">
              Go to Home
            </Link>
          </p>
        </form>
      </div>
    </div>
  );
}

export default LoginForm;