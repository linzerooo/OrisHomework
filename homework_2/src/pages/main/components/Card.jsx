import React, { useState, useEffect } from 'react';
import { Link } from "react-router-dom";
import TypeLabel from './TypeLabel.jsx';

const Card = ({ url }) => {
    const [pokeData, setPokeData] = useState(null);

    useEffect(() => {
        fetch(url)
        .then(response => response.json())
        .then(data => {
            setPokeData(data);
        })
        .catch((error) => {
            console.log('There was an ERROR: ', error);
        });
    }, [url]);


    if (!pokeData) {
        return <div></div>;
    }
    else{
        var id = pokeData.id;
        if (parseInt(pokeData.id) < 10) {
            id = `00${pokeData.id}`;
        } else if (parseInt(pokeData.id) < 100) {
            id = `0${pokeData.id}`;
        } else if (parseInt(pokeData.id) < 1000) {
            id = `${pokeData.id}`;
        }
        
        const nameSplit = pokeData.name.split('-');
        const name = nameSplit.map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(' ');

        return (
            <Link to={`/details/${pokeData.name}`} style={{ textDecoration: 'none' }}>
                <div className='card' key={pokeData.id}>
                    <div className='card-name-container'>
                        <span className='card-name'>{name}</span>
                        <span>#{id}</span>
                    </div>
                    <img alt={pokeData.name} src={pokeData.sprites.other.home.front_default} />
                    <TypeLabel key={pokeData.id} types={pokeData.types} />
                </div>
            </Link>
        );
    }
}

export default Card;