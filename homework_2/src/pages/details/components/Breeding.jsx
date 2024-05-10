import React from "react";

const Breeding = ({ data }) => {
    const meters = (data.height / 10).toFixed(1);
    const feet = Math.floor(meters / 0.3048);
    const inches = Number((meters / 0.3048 - feet).toFixed(1).toString().split('.')[1].charAt(0));
    const inchesStr = (inches < 10) ? `0${inches}` : `${inches}`;
    var feetAndInches = ''
    if (inches === 0){
        feetAndInches = `${feet}'`
    }
    else if (feet === 0){
        feetAndInches = `${inchesStr}''`
    }
    else{
        feetAndInches = `${feet}' ${inchesStr}''`
    }
    const kg = data.weight / 10; 
    const lbs = (kg * 2.20462).toFixed(1);

    return (
        <div className="general" style={{ transform: `translateX(100%)`, animation: `slideLeft 1.5s ease forwards`}}>
            <p>Breeding</p>
            <div className="height-weight">
                <div className="stats">
                    <span>Height</span>
                    <div className="stat-container">
                        <span>{feetAndInches}</span>
                        <span>{meters} m</span>
                    </div>
                </div>
                <div className="stats">
                    <span>Weight</span>
                    <div className="stat-container">
                        <span>{lbs} lbs</span>
                        <span>{kg} kg</span>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Breeding;