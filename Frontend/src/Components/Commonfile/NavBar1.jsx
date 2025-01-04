import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { FaBars, FaTimes } from 'react-icons/fa'; 
import {
    Menu,
    MenuHandler,
    MenuList,
    MenuItem,
    Button,
    ButtonGroup
  } from "@material-tailwind/react";
import logo from '../../assets/logo.png';

const NavBar1 = () => {
  const [isOpen, setIsOpen] = useState(false);

  return (
    <nav className="bg-white shadow-lg">
     
    <div className="flex justify-between  ">
        


      <div className="text-white text-lg font-bold"> <div className="sm:w-[50%] sm:h-[20%]">
        <Link to={'/'}>
        <img src={logo} alt="FreshThreads"   className="lg:mt-5 lg:ml-[150px] lg:w-[450px] lg:h-[40px]" />
        </Link>
      </div>
    </div>
    <div className=" hidden lg:flex   justify-between items-center ">
        <div className="flex space-x-8 items-center ">
        
    <Link to="/" className="py-4 px-2 font-semibold hover:text-green-500 transition duration-300"> <Button  variant="outlined" className='p-2 hover:shadow-[0_4px_20px_rgba(255,255,0,0.7)] transition duration-300 '> Home</Button></Link>
    <Link to="/about" className="py-4 px-2 font-semibold hover:text-green-500 transition duration-300"> <Button variant="outlined"className='p-2 hover:shadow-[0_4px_20px_rgba(255,255,0,0.7)] transition duration-300 '> About US</Button></Link>
    <Link to="/ourservices" className="py-4 px-2 font-semibold hover:text-green-500 transition duration-300"> <Button variant="outlined" className='p-2 hover:shadow-[0_4px_20px_rgba(255,255,0,0.7)] transition duration-300 '> Our Services</Button></Link>
    <Link to="/ourclient" className="py-4 px-2 font-semibold hover:text-green-500 transition duration-300"> <Button variant="outlined" className='p-2 hover:shadow-[0_4px_20px_rgba(255,255,0,0.7)] transition duration-300 '> Our Clients</Button></Link>
    <Link to="/contact" className="py-4 px-2 font-semibold hover:text-green-500 transition duration-300"> <Button variant="outlined"  className='p-2 hover:shadow-[0_4px_20px_rgba(255,255,0,0.7)] transition duration-300 '> Contact Us</Button></Link>
    <Link to="/login" className="font-semibold  hover:text-green-500 transition duration-300"> <Button variant="contained" color="green" className='p-2'> Login</Button></Link>

{/* <div>
<Menu
      animate={{
        mount: { y: 0 },
        unmount: { y: 25 },
      }}
    >        
      <MenuHandler>
      

      <Button variant="outlined" className='p-2 ml-4'> Signup</Button>
      </MenuHandler>
      <MenuList>
      
      <Link to='/use'><MenuItem>Users</MenuItem></Link>
      <Link to='/del'><MenuItem>Delivery</MenuItem></Link>
      <Link to='/shop'><MenuItem>Shops</MenuItem></Link>
      </MenuList>
    </Menu>
</div> */}
    
        </div>
      </div>






          {/* Mobile menu button */}
          <div className=" flex    lg:hidden sm:p-8   items-center">
        <button onClick={() => setIsOpen(!isOpen)} className="p-2 bg-gray-100">
          {/* {console.log(setIsOpen(!open))} */}
          {isOpen ? (                 
            <FaTimes className="w-5 h-5   text-gray-500 hover:text-green-500" />
          ) : (
            <FaBars className="w-10 h-10   text-gray-500 hover:text-green-500" />
          )}
        </button>
      </div>
        </div>
      {/* </div> */}
      {/* Mobile Menu */}
      <div className={`${isOpen ? 'block' : 'hidden'} lg:hidden  `}>
        <Link to="/" className="block text-sm sm:text-2xl px-2 py-4 text-black   hover:bg-gray-300 font-bold transition duration-300">Home</Link>
        <Link to="/about" className="block text-sm sm:text-2xl px-2 py-4 text-black  hover:bg-gray-300 font-bold transition duration-300">About Us</Link>
        <Link to="/ourservice" className="block text-sm sm:text-2xl px-2 py-4 text-black  hover:bg-gray-300 font-bold transition duration-3000">Our Services</Link>
        <Link to="/ourclient" className="block text-sm sm:text-2xl px-2 py-4 text-black  hover:bg-gray-300 font-bold transition duration-300">Our Clients</Link>
        <Link to="/contact" className="block text-sm sm:text-2xl px-2 py-4 text-black  hover:bg-gray-300 font-bold transition duration-300">Contact Us</Link>
        <Link to="/login" className="font-semibold  hover:text-green-500 transition duration-300"> <Button variant="contained" color="green" className='p-2'> Login</Button></Link>
          
        {/* <div className="block text-sm sm:text-2xl  text-black hover:bg-gray-300 font-bold transition duration-300 ">
        
<Menu
      animate={{
        mount: { y: 0 },
        unmount: { y: 25 },
      }}
      
    >
      <MenuHandler 	>
        <Button className='w-5px h-2 mb-2'> Sign up as</Button>
      </MenuHandler>
      <MenuList>
      
      <Link to='/use'><MenuItem>Users</MenuItem></Link>
      <Link to='/del'><MenuItem>Delivery</MenuItem></Link>
      <Link to='/shop'><MenuItem>Shops</MenuItem></Link>
      </MenuList>
    </Menu>
</div> */}
      </div>
    </nav>
  );
};

export default NavBar1;


