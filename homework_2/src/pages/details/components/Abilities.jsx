import React from "react";

const Abilities = ({abilities}) => {
    if(!abilities){
        return <div></div>
    }
    else{
        return(
            <div className="general" style={{ marginBottom: 100, transform: `translateX(-100%)`, animation: `slideLeft 1.5s ease forwards`}}>
                <p>Abilities</p>
                <div className="moves-container">
                    <div className="moves-list">
                        {abilities.slice(0, 2).map((ability) => <Ability key={ability} ability={ability} />)}
                    </div>
                </div>
            </div>
        );
    }
}

const Ability = (ability) => {
    const nameSplit = ability.ability.ability.name.split('-');
    const name = nameSplit.map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(' ');
    return(
        <div className={`ability slot-${ability.ability.slot}`}>
            <div className="ability-letter">
                <span className={`ability-letter-slot-${ability.ability.slot}`}>{name[0]}</span>
            </div>
            <span className="ability-name">{name}</span>
        </div>
    );
}

export default Abilities;