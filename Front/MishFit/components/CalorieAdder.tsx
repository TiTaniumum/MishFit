import Meal, { mealsMock } from "@/Interfaces.tsx/Meal";
import { useState } from "react";
import {
  TextInput,
  TouchableOpacity,
  View,
  StyleSheet,
  Text,
  Alert,
} from "react-native";
import { Collapsible } from "./Collapsible";
import Animated, { FadeIn } from "react-native-reanimated";
import Tracker, { TrackerType } from "@/Interfaces.tsx/Tracker";
import { useGlobalContext } from "./ContextProvider";
import { Ionicons } from "@expo/vector-icons";

export default function CalorieAdder() {
  const [searchText, setSearchText] = useState("");
  const [meals, setMeals] = useState<Meal[]>(mealsMock);

  const {addTracker} = useGlobalContext();

  function SearchMeals() {
    // TODO: сделать поиск продуктов из бека
  }

  function handleAddTracker(meal: Meal, gramms: string) {
    const parsedValue = parseInt(gramms.replace(/[^0-9]/g, '')) || 0;
    if(parsedValue <= 0){
        Alert.alert("Внимание!","Значение граммов не может быть отрицательным или равно нулю");
        return;
    }
    const newTracker: Tracker = {
        id: 0,
        trackerType: TrackerType.Calorie,
        meal: meal,
        mealGramms: parsedValue,
        activity: null,
        activityType: null,
        activityTimespan: null,
        activitySets: null,
        activityRepititions: null,
        sleepDateTime: null,
        sleepEnd: null,
        sleepQuality: null,
        trackerDateTime: new Date(),
        deleteDateTime: null,
    }
    addTracker(newTracker);
  }

  return (
    <View style={{ gap: 10 }}>
      <View style={styles.Input_Button}>
        <TextInput
          value={searchText}
          onChangeText={setSearchText}
          style={styles.input}
        />
        <TouchableOpacity
          onPress={SearchMeals}
          style={[styles.addButton, styles.button]}
        >
            <Ionicons size={15} color={"white"} name={"search"}/>
        </TouchableOpacity>
      </View>
      {meals?.map((item) => {
        const [gramms, setGramms] = useState("0");
        return (
          <View key={item.id} style={styles.collapsibleStyle}>
            <Collapsible
              title={item.name + " " + item.calories + "ккал / 100г"}
            >
              <Animated.View entering={FadeIn}>
                <Text style={{color:"white"}}>Укажите сколько вы съели в граммах:</Text>
                <View style={styles.Input_Button}>
                  <TextInput
                    value={gramms}
                    keyboardType="numeric"
                    onChangeText={setGramms}
                    style={styles.input}
                  />
                  <TouchableOpacity
                    onPress={() => handleAddTracker(item, gramms)}
                    style={[styles.button, styles.addButton]}
                  >
                    <Text style={{ color: "#6554d7" }}>+</Text>
                  </TouchableOpacity>
                </View>
              </Animated.View>
            </Collapsible>
          </View>
        );
      })}
    </View>
  );
}

const styles = StyleSheet.create({
  addButton: {
    flex: 1,
    padding: 12,
    alignItems: "center",
    backgroundColor: "white",
    borderRadius: 10,
    marginRight: 5,
  },
  collapsableContent: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
  },
  collapsibleStyle: {
    padding: 5,
    borderRadius: 20,
    backgroundColor: "#6554d7",
  },
  Input_Button: {
    flexDirection: "row",
  },
  input: {
    width: "80%",
    color: "#6554d7",
    height: 40,
    borderColor: "#6554d7",
    borderWidth: 2,
    borderRadius: 10,
    textAlign: "center",
    fontSize: 18,
    marginRight: 10,
    backgroundColor: "#fff",
  },
  button: {
    width: "20%",
    backgroundColor: "#6554d7",
  },
});
