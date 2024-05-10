import React from 'react';
import pokeball from '../../sources/pokeball.png'

const Seacrh = ({ inputText, handleChange, handleSubmit }) => {
  return (
    <div className='container'>
      <p>Who are you looking for?</p>
      <div className='outer-container'>
        <div className='input-container'>
          <input type='text' placeholder='E.g. Pikachu' value={inputText} onChange={handleChange} />
          <button onClick={handleSubmit}>GO</button>
        </div>
      </div>
      <img src={pokeball} alt='pokeball' />
    </div>
  );
};

export default Seacrh;