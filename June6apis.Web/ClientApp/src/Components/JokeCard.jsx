import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { Link } from 'react-router-dom';

const JokeCard = ({ joke, likedCount, dislikedCount }) => {

    const [likesCount, setLikesCount] = useState();
    const [dislikesCount, setDislikesCount] = useState();

    useEffect(() => {
        getCounts();
    }, []);

   const getCounts = async () => {
        const { id } = joke;
        if (!id) {
            return;
        }
       const { data } = await axios.get(`/api/jokes/getcounts/${joke.id}`);
       setLikesCount(data.likesCount)
       setDislikesCount(data.dislikesCount)
    }
    return (<>
        <div className="card card-body bg-light mb-3">
            <h5>{joke.setup}</h5>
            <h5>{joke.punchline}</h5>
            <span>Likes: {likesCount}</span>
            <br />
            <span>Dislikes: {dislikesCount}</span>
        </div>
    </>
    )
}



export default JokeCard;