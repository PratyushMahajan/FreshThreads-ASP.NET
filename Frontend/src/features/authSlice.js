import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { jwtDecode } from "jwt-decode";

// Async thunk for user signup
export const signupUser = createAsyncThunk(
  "auth/signupUser",
  async (userData, { rejectWithValue }) => {
    try {
      const response = await axios.post("http://localhost:5161/api/Auth/adduser", userData);
      return response.data;
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || "Signup failed");
    }
  }
);

// Async thunk for user login
export const loginUser = createAsyncThunk(
  "auth/loginUser",
  async (userData, { rejectWithValue }) => {
    try {
      const response = await axios.post("http://localhost:5161/api/Auth/login", userData);
      console.log("Login Response:", response.data);

      const token = response.data.token;
      localStorage.setItem("token", token);
      localStorage.setItem("role", response.data.role);

      // Decode JWT token
      let decodedToken;
      try {
        decodedToken = jwtDecode(token);
      } catch (error) {
        return rejectWithValue("Invalid token");
      }
      console.log("Decoded Token:", decodedToken);

      return {
        token,
        role: response.data.role,
        user: {
          email: response.data.email || userData.email,
          userId: decodedToken.userId || decodedToken.id,
        },
        shopId: decodedToken.shopId || null, // Extract shopId if available
      };
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || "Login failed");
    }
  }
);

// Fetch user profile using userId
export const fetchUserProfile = createAsyncThunk(
  "auth/fetchUserProfile",
  async (_, { rejectWithValue }) => {
    try {
      const token = localStorage.getItem("token");
      if (!token) throw new Error("No token found");

      const decodedToken = jwtDecode(token);
      console.log("Decoded Token:", decodedToken);

      const userId = decodedToken.userId; 
      console.log("User ID:", userId);

      const response = await axios.get(`http://localhost:5161/api/Users/${userId}`, {
        headers: { Authorization: `Bearer ${token}` },
      });

      return response.data;
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || err.message || "Failed to fetch user profile");
    }
  }
);

// Fetch shop profile using shopId
export const fetchShopProfile = createAsyncThunk(
  "auth/fetchShopProfile",
  async (shopId, { rejectWithValue }) => {
    try {
      const token = localStorage.getItem("token");
      if (!token) throw new Error("No token found");

      console.log(`Fetching Shop Profile for Shop ID: ${shopId}`);

      const response = await axios.get(`http://localhost:5161/api/Shop/${shopId}`, {
        headers: { Authorization: `Bearer ${token}` },
      });

      return response.data;
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || err.message || "Failed to fetch shop profile");
    }
  }
);

// Auth slice
const authSlice = createSlice({
  name: "auth",
  initialState: {
    user: null,
    token: null,
    loading: false,
    error: null,
    role: null,
    email: null,
    userId: null,
    shopId: null,
    shop: null,
  },
  reducers: {
    clearError: (state) => {
      state.error = null;
    },
    logout: (state) => {
      state.user = null;
      state.token = null;
      state.email = null;
      state.userId = null;
      state.shopId = null;
      state.shop = null;
      localStorage.removeItem("token");
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(signupUser.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(signupUser.fulfilled, (state, action) => {
        state.loading = false;
        state.user = action.payload;
      })
      .addCase(signupUser.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload;
      })
      .addCase(loginUser.fulfilled, (state, action) => {
        state.loading = false;
        state.user = action.payload.user;
        state.token = action.payload.token;
        state.role = action.payload.role;
        state.email = action.payload.user?.email || "";
        state.userId = action.payload.user?.userId || null;
        state.shopId = action.payload.shopId || null;
      })
      .addCase(fetchShopProfile.fulfilled, (state, action) => {
        state.loading = false;
        state.shop = action.payload;
      })
      .addCase(fetchShopProfile.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload;
      });
  },
});

export const { clearError, logout } = authSlice.actions;
export default authSlice.reducer;
