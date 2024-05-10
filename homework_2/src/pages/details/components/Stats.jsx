import React from 'react';
import GeneralStats from './GeneralStats.jsx';
import Breeding from './Breeding.jsx';

const Stats = ({ data }) => {
    

    return (
        <div className='stats'>
            <GeneralStats data={data}/>
            <Breeding data={data}/>
        </div>
    );
}

export default Stats;