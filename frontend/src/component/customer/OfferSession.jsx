import React from 'react'
import hinh from '../../access/customer/images/f1.png'

function OfferSession() {
    const x = ['o1.jpg', 'o2.jpg', 'o2s.jpg']
    const imgs = []
    x.forEach(element => {
        try {
            let img = require(`../../access/customer/images/${element}`);

            imgs.push(img)
            console.log(imgs)
        }
        catch {
            imgs.push("data:image/png;base64,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")
        }
    });
    // const img1 = require("file:///C:/Users/BUI HOA/Downloads/feane-1.0.0/feane-1.0.0/images/o1.jpg");
    // const img2 = require("file:///C:/Users/BUI HOA/Downloads/feane-1.0.0/feane-1.0.0/images/o2.jpg");
    return (
        <>
            {/* offer section */}
            <section className="offer_section layout_padding-bottom">
                <div className="offer_container">
                    <div className="container ">
                        <div className="row">
                            <div className="col-md-6  ">
                                <div className="box ">
                                    <div className="img-box">
                                        <img src="" alt="s" />
                                    </div>
                                    <div className="detail-box">
                                        <h5>Tasty Thursdays</h5>
                                        <h6>
                                            <span>20%</span> Off
                                        </h6>
                                        <a href="">
                                            Order Now{" "}
                                            <svg
                                                version="1.1"
                                                id="Capa_1"
                                                xmlns="http://www.w3.org/2000/svg"
                                                xmlnsXlink="http://www.w3.org/1999/xlink"
                                                x="0px"
                                                y="0px"
                                                viewBox="0 0 456.029 456.029"
                                                style={{ enableBackground: "new 0 0 456.029 456.029" }}
                                                xmlSpace="preserve"
                                            >
                                                <g>
                                                    <g>
                                                        <path
                                                            d="M345.6,338.862c-29.184,0-53.248,23.552-53.248,53.248c0,29.184,23.552,53.248,53.248,53.248
               c29.184,0,53.248-23.552,53.248-53.248C398.336,362.926,374.784,338.862,345.6,338.862z"
                                                        />
                                                    </g>
                                                </g>
                                                <g>
                                                    <g>
                                                        <path
                                                            d="M439.296,84.91c-1.024,0-2.56-0.512-4.096-0.512H112.64l-5.12-34.304C104.448,27.566,84.992,10.67,61.952,10.67H20.48
               C9.216,10.67,0,19.886,0,31.15c0,11.264,9.216,20.48,20.48,20.48h41.472c2.56,0,4.608,2.048,5.12,4.608l31.744,216.064
               c4.096,27.136,27.648,47.616,55.296,47.616h212.992c26.624,0,49.664-18.944,55.296-45.056l33.28-166.4
               C457.728,97.71,450.56,86.958,439.296,84.91z"
                                                        />
                                                    </g>
                                                </g>
                                                <g>
                                                    <g>
                                                        <path
                                                            d="M215.04,389.55c-1.024-28.16-24.576-50.688-52.736-50.688c-29.696,1.536-52.224,26.112-51.2,55.296
               c1.024,28.16,24.064,50.688,52.224,50.688h1.024C193.536,443.31,216.576,418.734,215.04,389.55z"
                                                        />
                                                    </g>
                                                </g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                            </svg>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div className="col-md-6  ">
                                <div className="box ">
                                    <div className="img-box">
                                        <img src="" alt="" />
                                    </div>
                                    <div className="detail-box">
                                        <h5>Pizza Days</h5>
                                        <h6>
                                            <span>15%</span> Off
                                        </h6>
                                        <a href="">
                                            Order Now{" "}
                                            <svg
                                                version="1.1"
                                                id="Capa_1"
                                                xmlns="http://www.w3.org/2000/svg"
                                                xmlnsXlink="http://www.w3.org/1999/xlink"
                                                x="0px"
                                                y="0px"
                                                viewBox="0 0 456.029 456.029"
                                                style={{ enableBackground: "new 0 0 456.029 456.029" }}
                                                xmlSpace="preserve"
                                            >
                                                <g>
                                                    <g>
                                                        <path
                                                            d="M345.6,338.862c-29.184,0-53.248,23.552-53.248,53.248c0,29.184,23.552,53.248,53.248,53.248
               c29.184,0,53.248-23.552,53.248-53.248C398.336,362.926,374.784,338.862,345.6,338.862z"
                                                        />
                                                    </g>
                                                </g>
                                                <g>
                                                    <g>
                                                        <path
                                                            d="M439.296,84.91c-1.024,0-2.56-0.512-4.096-0.512H112.64l-5.12-34.304C104.448,27.566,84.992,10.67,61.952,10.67H20.48
               C9.216,10.67,0,19.886,0,31.15c0,11.264,9.216,20.48,20.48,20.48h41.472c2.56,0,4.608,2.048,5.12,4.608l31.744,216.064
               c4.096,27.136,27.648,47.616,55.296,47.616h212.992c26.624,0,49.664-18.944,55.296-45.056l33.28-166.4
               C457.728,97.71,450.56,86.958,439.296,84.91z"
                                                        />
                                                    </g>
                                                </g>
                                                <g>
                                                    <g>
                                                        <path
                                                            d="M215.04,389.55c-1.024-28.16-24.576-50.688-52.736-50.688c-29.696,1.536-52.224,26.112-51.2,55.296
               c1.024,28.16,24.064,50.688,52.224,50.688h1.024C193.536,443.31,216.576,418.734,215.04,389.55z"
                                                        />
                                                    </g>
                                                </g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                                <g></g>
                                            </svg>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            {/* end offer section */}
            <img src={imgs[2]} alt="" />
        </>

    )
}

export default OfferSession