import React, { useEffect, useState } from 'react';
import bug from '../../sources/types/bug@2x.png'
import dark from '../../sources/types/dark@2x.png'
import dragon from '../../sources/types/dragon@2x.png'
import electric from '../../sources/types/electric@2x.png'
import fairy from '../../sources/types/fairy@2x.png'
import fight from '../../sources/types/fight@2x.png'
import fire from '../../sources/types/fire@2x.png'
import flying from '../../sources/types/flying@2x.png'
import ghost from '../../sources/types/ghost@2x.png'
import grass from '../../sources/types/grass@2x.png'
import ground from '../../sources/types/ground@2x.png'
import ice from '../../sources/types/ice@2x.png'
import normal from '../../sources/types/normal@2x.png'
import poison from '../../sources/types/poison@2x.png'
import psychic from '../../sources/types/psychic@2x.png'
import rock from '../../sources/types/rock@2x.png'
import steel from '../../sources/types/steel@2x.png'
import water from '../../sources/types/water@2x.png'

const Moves = ({ data }) => {
    return(
        <div className="general" style={{ transform: `translateX(-100%)`, animation: `slideRight 1.5s ease forwards`}}>
            <p>Moves</p>
            <div className="moves-container">
                <div className="moves-list">
                    {data.moves.slice(0, 3).map((move) => <Move key={move.move.name} move={move.move} />)}
                </div>
                <div className="moves-list">
                    {data.moves.slice(3, 6).map((move) => <Move key={move.move.name} move={move.move} />)}
                </div>
            </div>
        </div>
    );
}

const Move = ({ move }) => {
    const [moveData, setMoveData] = useState(null);
    const typesImages = {
        "bug": bug,
        "dark": dark,
        "dragon": dragon,
        "electric": electric,
        "fairy": fairy,
        "fighting": fight,
        "fire": fire,
        "flying": flying,
        "ghost": ghost,
        "grass": grass,
        "ground": ground,
        "ice": ice,
        "normal": normal,
        "poison": poison,
        "psychic": psychic,
        "rock": rock,
        "steel": steel,
        "water": water
    };

    useEffect(() => {
        fetch(`https://pokeapi.co/api/v2/move/${move.name}`)
          .then(response => response.json())
          .then(data => setMoveData(data))
          .catch((error) => {
            console.log('There was an ERROR: ', error);
          });
        }, [move]);

    if (!moveData){
        return <div></div>
    }
    else{
        const nameSplit = moveData.name.split('-');
        const name = nameSplit.map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(' ');

        return (
            <div className={`move ${moveData.type.name}-moves`}>
                <div className='stats'>
                    <img alt={moveData.type.name} src={typesImages[`${moveData.type.name}`]} />
                    <span>{name}</span>
                </div>
            </div>
        );
    }

}

export default Moves;

