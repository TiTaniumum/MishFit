import React, {
    createContext,
    useState,
    useContext,
    ReactNode,
    useEffect,
    useRef,
  } from "react";
import AsyncStorage from "@react-native-async-storage/async-storage";
import Tracker, { trackerMock, TrackerType } from "@/Interfaces.tsx/Tracker";

  export function formatDate(date: Date, type: string = 'date'){
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are zero-based
    const day = String(date.getDate()).padStart(2, '0');
    const monthStr = date.toLocaleString('default', { month: 'long' });

    switch(type){
      case 'history': return `${year} ${monthStr} ${day}`;
      case 'date': return `${day}.${month}.${year}`;
      default: return `${day}.${month}.${year}`;
    }
  };

  export function formatTime(date: Date){
    const hours = date.getHours();
    const minutes = date.getMinutes();

    return `${hours}:${minutes}`;
  }

  type GlobalContext = {
    waterIntake: number;
    dailyIntake: number;
    setWaterIntake: (value: number)=> void;
    getTrackers: () => void;
    getCalorieTrackers: () => Tracker[][];
    getActivityTrackers: () => Tracker[][];
    getSleepTrackers: () => Tracker[][];
  };

  const Context = createContext<GlobalContext>({} as GlobalContext);
  
  export function ContextProvider({ children }: { children: ReactNode }) {
    const [token, setToken] = useState("");
    const [trackers, setTrackers] = useState<null | Tracker[]>(trackerMock);
    const [waterIntake, setWaterIntake] = useState<number>(0);
    const dailyIntake = 3000;

    function getTrackers(){
      // TODO: запрос в базу данных с использованием token
    }

    function groupTrackersByDate(arr: Tracker[]){
      return Object.values(
        arr.reduce((acc, item) => {
          const date = formatDate(item.trackerDateTime);
          if (!acc[date]) {
            acc[date] = [];
          }
          acc[date].push(item);
          return acc;
        }, {} as Record<string, Tracker[]>)
      );
    }

    function sortGroupedTrackersByDate(arr: Tracker[][]){
      return arr.sort((item1,item2)=>item2[0].trackerDateTime.getDate() - item1[0].trackerDateTime.getDate())
    }

    function getCalorieTrackers(){
      if(!trackers) return [];
      const calories = trackers.filter(tracker=> tracker.trackerType == TrackerType.Calorie);
      return sortGroupedTrackersByDate(groupTrackersByDate(calories));
    }
    
    function getActivityTrackers(){
      if(!trackers) return [];
      const activities = trackers.filter(tracker=> tracker.trackerType == TrackerType.Activity);
      return sortGroupedTrackersByDate(groupTrackersByDate(activities));
    }

    function getSleepTrackers(){
      if(!trackers) return [];
      const sleeps = trackers.filter(tracker=> tracker.trackerType == TrackerType.Sleep);
      return sortGroupedTrackersByDate(groupTrackersByDate(sleeps));
    }

    return (
      <Context.Provider
        value={{
          waterIntake,
          dailyIntake,
          setWaterIntake,
          getTrackers,
          getCalorieTrackers,
          getActivityTrackers,
          getSleepTrackers
        }}
      >
        {children}
      </Context.Provider>
    );
  }
  
  export function useGlobalContext() {
    const context = useContext(Context);
    if (context === undefined) {
      throw new Error("useGlobalContext должен использовать ContextProvider");
    }
    return context;
  }
  