import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

const Home = () => {
    const [joke, setJoke] = useState({
        id: '',
        setup: '',
        punchline: '',
        userLikedJokes: []
    });

    useEffect(() => {
        const getJoke = async () => {
            const { data } = await axios.get('/api/jokes/getnewjoke');
            setJoke(data);
            console.log(joke);
            console.log(data);
        }
        getJoke();
    }, [])

  

    const refresh = () => {
        window.location.reload();
    }

    return (
        <div className="container" style={{ marginTop: 60 }}>
            <div
                className="row"
                style={{ minHeight: "80vh", display: "flex", alignItems: "center" }}
            >
                <div className="col-md-6 offset-md-3 bg-light p-4 rounded shadow">
                    <div>
                        <h4>{joke.setUp}</h4>
                        <h4>{joke.punchLine}</h4>
                        <div>
                            <div>
                                <Link to="/login">Login to your account to like/dislike this joke</Link>
                            </div>
                            <br />
                            <h4>Likes: {joke.likesCount}</h4>
                            <h4>Dislikes: {joke.dislikesCount}</h4>
                            <h4>
                                <button onClick={refresh} className="btn btn-link">Refresh</button>
                            </h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )


}

export default Home;

