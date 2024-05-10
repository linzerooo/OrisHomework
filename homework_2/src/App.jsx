import React, { useState, useEffect } from 'react';
import axios from 'axios'
import Pokemons from './pages/main/index.jsx'
import PokemonDetailsPage from './pages/details/index.jsx'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import loadingGif from './pages/sources/loading.gif';

function App() {
  const [allPokemons, setAllPokemons] = useState([])
  const [pokemonsCount, setPokemonsCount] = useState(0)
  useEffect(() => {
    if(allPokemons.length === 0){
      axios.get(`https://pokeapi.co/api/v2/pokemon?offset=0&limit=1302`)
      .then(response => {
        setAllPokemons(response.data.results);
        setPokemonsCount(response.data.count);
      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
    }
  }, [allPokemons]);

  if(allPokemons.length === 0){
    return (
      <div className='loading'>
        <img alt='loading' src={loadingGif} />
      </div>
    );
  }
  else{
    console.log(allPokemons)
    return (
      <>
      <BrowserRouter>
        <Routes>
          <Route path="/pokemon" element={<Pokemons allPokemons={allPokemons} pokemonsCount={pokemonsCount}/>} />
          <Route path="/details/:name" element={<PokemonDetailsPage />} />
        </Routes>
      </BrowserRouter>
      </>
    );
  }
}

export default App;
