import '../sources/details.css';
import React, { useState, useEffect } from 'react';
import { useParams } from "react-router-dom";
import Header from './components/Header.jsx';
import GeneralStats from './components/GeneralStats.jsx';
import Breeding from './components/Breeding.jsx';
import Moves from './components/Moves.jsx';
import Abilities from './components/Abilities.jsx';
import loading from '../sources/loading.gif';

const PokemonDetailsPage = () => {
    const [pokeData, setPokeData] = useState(null);
    const {name} = useParams();

    useEffect(() => {
      fetch(`https://pokeapi.co/api/v2/pokemon/${name}`)
        .then(response => response.json())
        .then(data => {
          setPokeData(data);
        })
        .catch((error) => {
          console.log('There was an ERROR: ', error);
        });
    }, [name]);

    if(!pokeData){
      return (
        <div className='loading'>
          <img alt='loading' src={loading} />
        </div>
      );
    }
    else{
      return(
        <>
          <Header />
          <div className='stats'>
            <GeneralStats data={pokeData}/>
            <Breeding data={pokeData}/>
            <Moves data={pokeData}/>
            <Abilities abilities={pokeData.abilities}/>
          </div>
        </>
      ); 
    }
    
  }

  export default PokemonDetailsPage;