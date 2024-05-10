import React from "react";
import TypeLabel from '../../main/components/TypeLabel.jsx'

const GeneralStats = ({data}) => {
    var id = data.id;
    if (parseInt(data.id) < 10) {
        id = `00${data.id}`;
    } else if (parseInt(data.id) < 100) {
        id = `0${data.id}`;
    }
    const nameSplit = data.name.split('-');
    const name = nameSplit.map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(' ');
    
    return (
        <div className="general" style={{ transform: `translateX(-100%)`, animation: `slideRight 1.5s ease forwards`}}>
            <div className="namespace-container">
                <div className="namespace">
                    <span>#{id}</span>
                    <h1>{name}</h1>
                </div>
                <TypeLabel types={data.types} />
            </div>
            <div className="stats-and-img">
                <div className="statistics">
                    <span>HP</span>
                    <div className="main-stats">
                        <div className="hp"></div>
                        <div style={{width: data.stats[0].base_stat + 'px'}} className="hp-stat"></div>
                    </div>
                    
                    <span>Attack</span>
                    <div className="main-stats">
                        <div className="attack"></div>
                        <div style={{width: data.stats[1].base_stat + 'px'}} className="attack-stat"></div>
                    </div>

                    <span>Defense</span>
                    <div className="main-stats">
                        <div className="defense"></div>
                        <div style={{width: data.stats[2].base_stat + 'px'}} className="defense-stat"></div>
                    </div>
                    
                    <span>Speed</span>
                    <div className="main-stats">
                        <div className="speed"></div>
                        <div style={{width: data.stats[5].base_stat + 'px'}} className="speed-stat"></div>
                    </div>
                </div>
                <img alt={data.name} src={data.sprites.other.home.front_default} />
            </div>
        </div>
    );
}

export default GeneralStats;