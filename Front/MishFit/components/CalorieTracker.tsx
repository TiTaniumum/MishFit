import { View } from "react-native";
import { useGlobalContext } from "./ContextProvider";
import Tracker from "@/Interfaces.tsx/Tracker";
import { useEffect, useState } from "react";
import CalorieHistory from "./CalorieHistory";

export default function CalorieTracker(){
    const {getCalorieTrackers} = useGlobalContext();
    const [calorieTrackers, setCalorieTrackers] = useState<Tracker[][] | null>(null);

    useEffect(()=>{
        setCalorieTrackers(getCalorieTrackers());
    },[]);

    return (
        <View>
            <CalorieHistory trackers={calorieTrackers}/>
        </View>
    )
}