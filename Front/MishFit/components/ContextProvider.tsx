import React, {
    createContext,
    useState,
    useContext,
    ReactNode,
    useEffect,
    useRef,
  } from "react";
  import AsyncStorage from "@react-native-async-storage/async-storage";

  type GlobalContext = {
    //-- поля и методы сюда
  };
  
  const Context = createContext<GlobalContext>({} as GlobalContext);
  
  export function ContextProvider({ children }: { children: ReactNode }) {
    // const [value , setValue] = useStete(...);

    return (
      <Context.Provider
        value={{
            //value
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
  