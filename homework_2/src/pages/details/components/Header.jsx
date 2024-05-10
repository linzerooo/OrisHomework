import React from "react";
import { Link } from "react-router-dom";
import arrow from '../../sources/arrow-left.svg'
import pokeball from '../../sources/pokeball.png'

const Header = () => {
  return (
    <div className='header'>
        <Link to={`/pokemon`} style={{ textDecoration: 'none' }}>
            <img className="back-button" alt="back" src={arrow} />
        </Link>  
      <img className="pokeball" src={pokeball} alt='pokeball' />
    </div>
  );
};

export default Header;