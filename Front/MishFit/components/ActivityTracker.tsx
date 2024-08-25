import { useGlobalContext } from "./ContextProvider";
import Tracker from "@/Interfaces.tsx/Tracker";
import { useEffect, useState } from "react";
import ActivityHistory from "./ActivityHistory";
import { View } from "react-native";

export default function ActivityTracker(){
    const {getActivityTrackers} = useGlobalContext();
    const [activityTrackers, setActivityTrackers] = useState<Tracker[][] | null>(null);

    useEffect(()=>{
        setActivityTrackers(getActivityTrackers());
    },[]);

    return (
        <View>
            <ActivityHistory trackers={activityTrackers}/>
        </View>
    )
}