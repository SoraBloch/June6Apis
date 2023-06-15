import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';
import useInterval from '../useInterval';
import { useAuth } from '../AuthContext';

const Home = () => {
    const { user } = useAuth();

    const [joke, setJoke] = useState({
        id: '',
        setup: '',
        punchline: '',
        likesCount: '',
        dislikesCount: ''
    });

    const [status, setStatus] = useState('');

    useEffect(() => {
        getJoke();
    }, []);

    const getJoke = async () => {
        const response = await axios.get('/api/jokes/getnewjoke');
        setJoke(response.data);

        const { data: getStatus } = await axios.get(`/api/jokes/getstatus/${response.data.id}`);
        setStatus(getStatus);
    }

    const getCounts = async () => {
        const { id } = joke;
        if (!id) {
            return;
        }
        const { data } = await axios.get(`/api/jokes/getcounts/${joke.id}`);
        setJoke({ ...joke, likesCount: data.likesCount, dislikesCount: data.dislikesCount });
    }

    useInterval(getCounts, 500);

    const refresh = () => {
        window.location.reload();
    }

    const onLikeClick = async () => {
        console.log("likeclick");
        const { id } = joke;
        await axios.post(`/api/jokes/updatestatus`, { jokeId: id, liked: true });
        setStatus('liked')
    }

    const onDislikeClick = async () => {
        console.log("dilikeclick");
        const { id } = joke;
        if (!id) {
            return;
        }
        await axios.post(`/api/jokes/updatestatus`, { jokeId: id, liked: false });
        setStatus('disliked')
    }

    const liked = status === 'liked';
    const disliked = status === 'disliked';

    return (
        <div className="container" style={{ marginTop: 60 }}>
            <div
                className="row"
                style={{ minHeight: "80vh", display: "flex", alignItems: "center" }}
            >
                <div className="col-md-6 offset-md-3 bg-light p-4 rounded shadow">
                    <div>
                        <h4>{joke.setup}</h4>
                        <h4>{joke.punchline}</h4>
                        <div>
                            {!user ?
                                <div>
                                    <Link to="/login">Login to your account to like/dislike this joke</Link>
                                </div>
                                :
                                <div>
                                    <button disabled={liked} onClick={onLikeClick} className="btn btn-primary">
                                        Like
                                    </button>
                                    <button disabled={disliked} onClick={onDislikeClick} className="btn btn-danger">
                                        Dislike
                                    </button>
                                </div>
                            }
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

