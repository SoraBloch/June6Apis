import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { Link } from 'react-router-dom';
import JokeCard from '../Components/JokeCard';

const ViewAll = () => {

    const [jokes, setJokes] = useState([]);

    useEffect(() => {
        getJokes();
    }, []);

    const getJokes = async () => {
        const { data } = await axios.get('/api/jokes/getalljokes');
        setJokes(data);
    }

    return (
        <div className="container" style={{ marginTop: 60 }}>
            <div className="row">
                <div className="col-md-6 offset-md-3">
                    {jokes.map(joke =>
                        <JokeCard
                            key={joke.id}
                            joke={joke}
                        />)}
                </div>
            </div>
        </div>

    )
}



export default ViewAll;