import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { Link } from 'react-router-dom';

const JokeCard = ({ joke }) => {

    return (<>
        <div className="card card-body bg-light mb-3">
            <h5>There are 10 types of people in this world...</h5>
            <h5>Those who understand binary and those who don't</h5>
            <span>Likes: 0</span>
            <br />
            <span>Dislikes: 0</span>
        </div>
        <div className="card card-body bg-light mb-3">
            <h5>3 SQL statements walk into a NoSQL bar. Soon, they walk out</h5>
            <h5>They couldn't find a table.</h5>
            <span>Likes: 0</span>
            <br />
            <span>Dislikes: 0</span>
        </div>
    </>
    )
}



export default JokeCard;