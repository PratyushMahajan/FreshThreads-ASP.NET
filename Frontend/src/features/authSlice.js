import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

// Async thunk for signup
export const signupUser = createAsyncThunk(
  'auth/signupUser',
  async (userData, { rejectWithValue }) => {
    try {
      const response = await axios.post('http://localhost:5161/api/Auth/adduser', userData);
      return response.data; // Return the response data to be stored in the state
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Signup failed');
    }
  }
);

// Async thunk for login
export const loginUser = createAsyncThunk(
  'auth/loginUser',
  async (userData, { rejectWithValue }) => {
    try {
      const response = await axios.post('http://localhost:5161/api/Auth/login', userData);
     console.log("data",response.data); // Check what data you get from the API

      localStorage.setItem('token', response.data.token);
      localStorage.setItem('role', response.data.role);

      return {
        token: response.data.token,
        role: response.data.role,
        user: { email: response.data.email || userData.email }, // Prefer response email, fallback to userData
      };
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Login failed');
    }
  }
);


const authSlice = createSlice({
  name: 'auth',
  initialState: {
    user: null,
    token: null, // Add token to the initial state
    loading: false,
    error: null,
    role: null,
    email: null, // Add email to the initial state
  },
  reducers: {
    clearError: (state) => {
      state.error = null;
    },
    logout: (state) => {
      state.user = null;
      state.token = null;
      state.email = null;
      localStorage.removeItem('token'); // Clear token from localStorage
    },
  },
  extraReducers: (builder) => {
    builder
      // Signup reducers
      .addCase(signupUser.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(signupUser.fulfilled, (state, action) => {
        state.loading = false;
        state.user = action.payload; // Store the user data
        state.error = null;
      })
      .addCase(signupUser.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload; // Store the error message
      })

      // Login reducers
      .addCase(loginUser.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(loginUser.fulfilled, (state, action) => {
        state.loading = false;
        state.user = action.payload.user; // Store user data
        state.token = action.payload.token; // Store token
        localStorage.setItem('token', action.payload.token); // Save txoken to localStorage
        state.role = action.payload.role;
        state.email = action.payload.user?.email || " "; // Store the email

        state.error = null;
      })
      .addCase(loginUser.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload; // Store the error message
      });
  },
});

export const { clearError, logout } = authSlice.actions;
export default authSlice.reducer;