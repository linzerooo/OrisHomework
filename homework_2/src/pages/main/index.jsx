import '../sources/main.css';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Card from './components/Card.jsx'
import Seacrh from './components/Search.jsx';
import ErrorMessage from './components/ErrorMessage.jsx';
import loadingGif from '../sources/loading.gif';

const Pokemons = ({ allPokemons, pokemonsCount }) => {
  const [data, setData] = useState([]);
  const [inputText, setInputText] = useState('');
  const [originalData, setOriginalData] = useState([])
  const [searchResultFound, setSearchResultFound] = useState(true);
  const [offset, setOffset] = useState(0)
  const [fetching, setFetching] = useState(true)
  
  useEffect (() => {
    document.addEventListener('scroll', handleScroll)
    return function () {
      document.removeEventListener('scroll', handleScroll)
    }
  });

  useEffect(() => {
    if(fetching){
      axios.get(`https://pokeapi.co/api/v2/pokemon?offset=${offset}&limit=50`)
      .then(response => {
        setData(prevData => [...prevData, ...response.data.results]);
        setOriginalData(prevData => [...prevData, ...response.data.results])
        setOffset(prevOffset => prevOffset + 50);
      })
      .catch(error => {
          console.error('Error fetching data:', error);
      })
        .finally(() => setFetching(false))
    }
  }, [fetching, offset]);

  const handleChange = (event) => {
    const text = event.target.value;
    setInputText(text);
    const filteredData = originalData.filter((pokemon) => pokemon.name.includes(text.toLowerCase()));
    if(filteredData.length > 0){
      setData(filteredData);
      setSearchResultFound(filteredData.length > 0);
    }
  };

  const handleScroll = (event) => {
    if(event.target.documentElement.scrollHeight - (event.target.documentElement.scrollTop + window.innerHeight) < 600 && data.length < pokemonsCount){
      setFetching(true)
    }
  }

  const handleSubmit = () => {
    const filterData = allPokemons.filter((pokemon) => pokemon.name.includes(inputText.toLowerCase()));
    setData(filterData);
    setSearchResultFound(filterData.length > 0);
  };

  if(!data){
    return (
      <div className='loading'>
        <img alt='loading' src={loadingGif} />
      </div>
    );
  }
  else{
    return (
      <>
        <Seacrh inputText={inputText} handleChange={handleChange} handleSubmit={handleSubmit} />
        {searchResultFound ? (
          <div className='card-list'>
            {
              data.map((pokemon) => <Card key={pokemon.url} url={pokemon.url} />)
            }
          </div>
        ) : (
          <ErrorMessage />
        )}
      </>
    );
  }
  
}

export default Pokemons;


