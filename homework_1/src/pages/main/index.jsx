import '../sources/main.css';
import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Card from './components/Card.jsx'
import Seacrh from './components/Search.jsx';
import ErrorMessage from './components/ErrorMessage.jsx';
import loadingGif from '../sources/loading.gif';

const Pokemons = () => {
  const [data, setData] = useState([]);
  const [inputText, setInputText] = useState('');
  const [originalData, setOriginalData] = useState([])
  const [searchResultFound, setSearchResultFound] = useState(true);

  useEffect(() => {
    axios.get(`https://pokeapi.co/api/v2/pokemon?offset=0&limit=1302`)
        .then(response => {
          setData(prevData => [...prevData, ...response.data.results]);
          setOriginalData(prevData => [...prevData, ...response.data.results])
        })
        .catch(error => {
          console.error('Error fetching data:', error);
        })
  }, []);

  const handleChange = (event) => {
    const text = event.target.value;
    setInputText(text);
    const filteredData = originalData.filter((pokemon) => pokemon.name.includes(text.toLowerCase()));
    if(filteredData.length > 0){
      setData(filteredData);
      setSearchResultFound(filteredData.length > 0);
    }
  };

  const handleSubmit = () => {
    const filterData = data.filter((pokemon) => pokemon.name.includes(inputText.toLowerCase()));
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


