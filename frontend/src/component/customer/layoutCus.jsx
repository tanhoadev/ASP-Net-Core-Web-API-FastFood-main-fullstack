import React, { useEffect } from 'react'
import { Helmet } from 'react-helmet'
import Header from './header'
import SlideSession from './SlideSession'
import '../../access/customer/css/bootstrap.css'
// import '../../access/customer/css/font-awesome.min.css'
import '../../access/customer/css/style.css'
import '../../access/customer/css/responsive.css'
import OfferSession from './OfferSession'
// import JqueryJS from '../../access/customer/js/jquery-3.4.1.min'
// import Bootstrap from '../../access/customer/js/bootstrap'
// import CustomComponent from '../../access/customer/js/custom'
import hero from '../../access/customer/images/hero-bg.jpg'
import FoodSession from './FoodSession'
import TestImage from './TestImage'

function LayoutCus() {
    return (
        <>
            <div className="hero_area">
                <div className="bg-box">
                    <img src={hero} alt="banner" />
                </div>
                <Header />
                <SlideSession />
            </div>
            <OfferSession />
            {/* <script src={CustomComponent}></script> */}
            {/* <FoodSession /> */}
            <TestImage />
        </>
    )
}

export default LayoutCus