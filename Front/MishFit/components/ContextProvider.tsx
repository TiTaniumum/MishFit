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

  export function formatDate(date: Date){
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0'); // Months are zero-based
    const day = String(date.getDate()).padStart(2, '0');

    return `${day}.${month}.${year}`;
  };  

  export function formatTime(date: Date){
    const hours = date.getHours();
    const minutes = date.getMinutes();

    return `${hours}:${minutes}`;
  }

  type GlobalContext = {
    getTrackers: () => void;
    getCalorieTrackers: () => Tracker[][];
    getActivityTrackers: () => Tracker[][];
    getSleepTrackers: () => Tracker[][];
  };

  const Context = createContext<GlobalContext>({} as GlobalContext);
  
  export function ContextProvider({ children }: { children: ReactNode }) {
    const [token, setToken] = useState("");
    const [trackers, setTrackers] = useState<null | Tracker[]>(trackerMock);
    
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

    function getCalorieTrackers(){
      if(!trackers) return [];
      const calories = trackers.filter(tracker=> tracker.trackerType == TrackerType.Calorie);
      return groupTrackersByDate(calories);
    }
    
    function getActivityTrackers(){
      if(!trackers) return [];
      const activities = trackers.filter(tracker=> tracker.trackerType == TrackerType.Activity);
      return groupTrackersByDate(activities);
    }

    function getSleepTrackers(){
      if(!trackers) return [];
      const sleeps = trackers.filter(tracker=> tracker.trackerType == TrackerType.Sleep);
      return groupTrackersByDate(sleeps);
    }

    return (
      <Context.Provider
        value={{
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
  