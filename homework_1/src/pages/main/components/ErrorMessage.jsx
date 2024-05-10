import React from 'react';
import pikachu from '../../sources/pikachu.png'


const ErrorMessage = () => {
    return (
        <div className='error-message'>
          <p>Oops! Try again.</p>
          <span>The Pokemon you're looking for is a unicorn. It doesn't exist in this list.</span>
          <img src={pikachu} alt='pikachu'></img>  
        </div>
    );
}

export default ErrorMessage;