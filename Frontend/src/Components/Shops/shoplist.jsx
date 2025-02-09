import React from 'react';
import { useSearchParams, useNavigate } from 'react-router-dom';
import { Box, Typography, Button, Grid, Chip } from '@mui/material';

const laundriesData = [
  {
    name: "Filter Out",
    address: "90 DLF Park, Gurgaon",
  },
  {
    name: "Quick Clean Laundry",
    address: "123 Main Street, Mumbai",
  },
  {
    name: "Sparkle Wash",
    address: "45 Park Avenue, Mumbai",
  }
];

const LaundriesPage = () => {
  const [searchParams] = useSearchParams();
  const city = searchParams.get('city');
  const navigate = useNavigate();

  const handleAddItemsClick = () => {
    navigate('/orders');
  };

  return (
    <Box sx={{ fontFamily: 'Poppins, sans-serif' }}>
      {/* Header Section */}
      <Box
        sx={{
          height: '40vh',
          backgroundColor: '#1976d2',
          display: 'flex',
          alignItems: 'center',
          justifyContent: 'center',
          color: '#fff',
          textAlign: 'center',
        }}
      >
        <Typography variant="h3" sx={{ fontFamily: 'Poppins, sans-serif' }}>
          Services available in {city}
        </Typography>
      </Box>


      {/* Laundry List Section */}
      <Grid container spacing={4} sx={{ padding: 2 }}>
        {laundriesData.map((laundry, index) => (
          <Grid
            item
            xs={12}
            key={index}
            sx={{
              width: '100%',
              border: '1px solid #ddd',
              borderRadius: 2,
              padding: 3,
              backgroundColor: '#f9f9f9',
              boxShadow: '0 4px 10px rgba(0,0,0,0.1)',
              display: 'flex',
              justifyContent: 'space-between',
            }}
          >
            {/* Left Section */}
            <Box>
              <Typography
                variant="h5"
                sx={{
                  color: '#1976d2',
                  fontWeight: 'bold',
                  marginBottom: 1,
                  fontFamily: 'Poppins, sans-serif',
                }}
              >
                {laundry.name}
              </Typography>
              <Typography
                variant="body1"
                sx={{
                  color: '#555',
                  marginBottom: 2,
                  fontFamily: 'Poppins, sans-serif',
                }}
              >
                {laundry.address}
              </Typography>
            </Box>

            {/* Right Section */}
            <Box
              sx={{
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'flex-end',
                justifyContent: 'space-between',
              }}
            >
              {/* Proceed Button */}
              <Button
                variant="contained"
                onClick={handleAddItemsClick}
                sx={{
                  width: '200px',
                  height: '40px',
                  borderRadius: '20px',
                  marginRight: '20px',
                  marginBottom: '30px',
                  backgroundColor: '#4caf50',
                  ':hover': { backgroundColor: '#45a049' },
                }}
              >
                <Typography variant="h6" sx={{ fontFamily: 'Poppins, sans-serif' }}>
                  Add Items
                </Typography>
              </Button>
            </Box>
          </Grid>
        ))}
      </Grid>
    </Box>
  );
};

export default LaundriesPage;
