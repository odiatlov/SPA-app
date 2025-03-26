import { useEffect, useState } from "react";
import config from "../config";
import { House } from "../types/house";

//Hook for fetching data
const usefetchHouses = (): House[] => {
    const [houses, setHouses] = useState<House[]>([]);
    
    //The houses will be fetched only when the component is first rendered 
    useEffect(() => {
        const fetchHouses = async () => {
            const rsp = await fetch(`${config.baseApiUrl}/houses`);
            const houses = await rsp.json();
            setHouses(houses);
          }
          fetchHouses();  
    }, []);

    return houses;
}

export default usefetchHouses;