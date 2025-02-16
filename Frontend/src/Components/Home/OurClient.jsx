import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';

const OurClient = () => {
  return (
    <section id="our-clients" className="bg-light py-5">
      <div className="container-fluid">
        <div className="flex items-center justify-center">
          <h1 className="text-5xl font-bold text-orange-500 mt-10" style={{ fontFamily: 'Poppins, sans-serif'}}>Our Clients</h1>
        </div>
        <hr />
        <p className="text-center lead">Trusted by Businesses and Individuals Worldwide</p>

        <div id="clients-slider" className="carousel slide mt-5 mb-5" data-bs-ride="carousel" style={{ width: '80%', height: '400px', margin: '0 auto' }}>
          <div className="carousel-inner">
            <div className="carousel-item active">
              <div className="text-center">
                <h2>Corporate Partnerships</h2>
                <p className='text-justify mt-4' style={{ fontSize: 20}}>
                  We collaborate with leading businesses, hotels, and institutions to provide professional laundry services. Our corporate partners rely on us for quality, reliability, and efficiency, ensuring their staff and guests always have access to fresh, clean garments and linens.
                </p>
              </div>
            </div>
            <div className="carousel-item">
              <div className="text-center">
                <h2>Residential Clients</h2>
                <p className='text-justify mt-4' style={{ fontSize: 20}}>
                  Families and individuals trust us for their daily laundry needs. Our convenient pickup and delivery service allows them to focus on what truly matters, while we take care of their clothes with expert care and precision.
                </p>
              </div>
            </div>
            <div className="carousel-item">
              <div className="text-center">
                <h2>Hospitality & Healthcare</h2>
                <p className='text-justify mt-4' style={{ fontSize: 20}}>
                  From luxury hotels to healthcare facilities, we provide high-standard laundry solutions tailored to industry-specific needs. Our commitment to hygiene and quality ensures the best care for fabrics, linens, and uniforms.
                </p>
              </div>
            </div>
          </div>
          <button className="carousel-control-prev" type="button" data-bs-target="#clients-slider" data-bs-slide="prev">
            <span className="carousel-control-prev-icon" aria-hidden="true"></span>
            <span className="visually-hidden">Previous</span>
          </button>
          <button className="carousel-control-next" type="button" data-bs-target="#clients-slider" data-bs-slide="next">
            <span className="carousel-control-next-icon" aria-hidden="true"></span>
            <span className="visually-hidden">Next</span>
          </button>
        </div>
        <hr />
      </div>
    </section>
  );
};

export default OurClient;
