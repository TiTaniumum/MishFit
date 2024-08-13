import { StatusBar } from "expo-status-bar";
import { StyleSheet, Text, View } from "react-native";
import { ContextProvider } from "./components/ContextProvider";
import { NavigationContainer } from "@react-navigation/native";
import { createNativeStackNavigator } from "@react-navigation/native-stack";

import Home from "./pages/Home";

const RootStack = createNativeStackNavigator();

export default function App() {
  return (
<<<<<<< HEAD
    <View style={styles.container}>
      <Text> App.tsx to start working on your app!</Text>
      {/* Hello Temirlan */}
      <StatusBar style="auto" />
    </View>
=======
    <ContextProvider>
      <NavigationContainer>
        <RootStack.Navigator>
          <RootStack.Group>
            <RootStack.Screen
              name="Home"
              component={Home}
              options={({ navigation }) => ({
                
              })}
            />
          </RootStack.Group>
        </RootStack.Navigator>
      </NavigationContainer>
    </ContextProvider>
>>>>>>> main
  );
}