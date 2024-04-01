import React, { useState } from 'react'
import axios from 'axios'

function TestImage() {
    const [img, setImg] = useState()
    function handleImage(e) {
        console.log(e.target.files)
        const data = new FileReader()
        data.addEventListener('load', () => {
            setImg(data.result)
        })
        data.readAsDataURL(e.target.files[0])
        console.log(img)
    }
    function handleApi() {
        // const formData = new FormData()

        const LoginData = {
            Ten: img,
            Hinh: img,
        }
        // formData.append('img', img)
        axios.post('https://localhost:7286/api/Loai/add-cate', LoginData, {
            // withCredentials: true,
            headers: {
                'Content-Type': 'application/json'
            }

        })
            .then(x => console.log(x))
            .catch(x => x.error)
    }
    return (
        <>
            <input type="file" onChange={handleImage} accept='image/*' />
            <img src={img} alt={img} />
            <button onClick={handleApi} type='submit'>Submit</button>
        </>
    )
}

export default TestImage