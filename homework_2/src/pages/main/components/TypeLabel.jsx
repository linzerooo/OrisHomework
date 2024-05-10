import React from 'react';

const TypeLabel = ({types}) => {
    return (
      <div className='types'>
        {types.map((type) => <Type type={type.type.name} />)}
      </div>
    );
}
  
const Type = ({type}) => {
    return (
        <div className={type.toLowerCase()}>
          <span>{type.toUpperCase()}</span>
        </div>
    );
}

export default TypeLabel;