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
import Tracker, { ActivityType, TrackerType } from "@/Interfaces.tsx/Tracker";
import { useGlobalContext } from "./ContextProvider";
import Activity, { activitiesMock } from "@/Interfaces.tsx/Activity";
import { Ionicons } from "@expo/vector-icons";

export default function ActivityAdder() {
  const [searchText, setSearchText] = useState("");
  const [activities, setActivities] = useState<Activity[]>(activitiesMock);

  const { addTracker } = useGlobalContext();

  function SearchActivities() {
    // TODO: сделать поиск продуктов из бека
  }

  function handleAddTracker(
    activity: Activity,
    timespan: string,
    sets: string,
    repetitions: string,
    activityType: ActivityType
  ) {
    const parsedTimespan = parseInt(timespan.replace(/[^0-9]/g, "")) || 0;
    const parsedSets = parseInt(sets.replace(/[^0-9]/g, "")) || 0;
    const parsedRepetitions = parseInt(repetitions.replace(/[^0-9]/g, "")) || 0;

    var newTracker: Tracker;

    if (activityType == ActivityType.Timespan && parsedTimespan <= 0) {
      Alert.alert(
        "Внимание!",
        "Значение минут не может быть отрицательным или равно нулю."
      );
      return;
    }
    if (
      activityType == ActivityType.Countable &&
      parsedSets <= 0 &&
      parsedRepetitions <= 0
    ) {
      Alert.alert(
        "Внимание!",
        "Значение минут не может быть отрицательным или равно нулю."
      );
      return;
    }
    if (activityType == ActivityType.Timespan) {
      newTracker = {
        id: 0,
        trackerType: TrackerType.Activity,
        meal: null,
        mealGramms: null,
        activity: activity,
        activityType: activityType,
        activityTimespan: parsedTimespan,
        activitySets: null,
        activityRepititions: null,
        sleepDateTime: null,
        sleepEnd: null,
        sleepQuality: null,
        trackerDateTime: new Date(),
        deleteDateTime: null,
      };
    } else {
      newTracker = {
        id: 0,
        trackerType: TrackerType.Activity,
        meal: null,
        mealGramms: null,
        activity: activity,
        activityType: activityType,
        activityTimespan: null,
        activitySets: parsedSets,
        activityRepititions: parsedRepetitions,
        sleepDateTime: null,
        sleepEnd: null,
        sleepQuality: null,
        trackerDateTime: new Date(),
        deleteDateTime: null,
      };
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
          onPress={SearchActivities}
          style={[styles.addButton, styles.button]}
        >
          <Ionicons size={15} color={"white"} name={"search"}/>
        </TouchableOpacity>
      </View>
      {activities?.map((item) => {
        const [timespan, setTimespan] = useState("0");
        const [sets, setSets] = useState("0");
        const [repetitions, setRepetitions] = useState("0");
        return (
          <View key={item.id} style={styles.collapsibleStyle}>
            <Collapsible title={item.name}>
              <Animated.View entering={FadeIn}>
                <View style={styles.Input_Button}>
                  {item.activityType == ActivityType.Timespan && (
                    <View style={{width: "80%"}}>
                      <Text style={{ color: "white" }}>
                        Укажите сколько времени вы упражнялись:
                      </Text>
                      <TextInput
                        value={timespan}
                        keyboardType="numeric"
                        onChangeText={setTimespan}
                        style={[styles.input, {width: "100%"}]}
                      />
                    </View>
                  )}
                  {item.activityType == ActivityType.Countable && (
                    <View style={{width: "80%"}}>
                      <Text style={{ color: "white" }}>
                        Укажите количество подходов:
                      </Text>
                      <TextInput
                        value={sets}
                        keyboardType="numeric"
                        onChangeText={setSets}
                        style={[styles.input, {width: "100%"}]}
                      />
                      <Text style={{ color: "white" }}>
                        Укажите количество повторений:
                      </Text>
                      <TextInput
                        value={repetitions}
                        keyboardType="numeric"
                        onChangeText={setRepetitions}
                        style={[styles.input, {width: "100%"}]}
                      />
                    </View>
                  )}
                  <TouchableOpacity
                    onPress={() =>
                      handleAddTracker(
                        item,
                        timespan,
                        sets,
                        repetitions,
                        item.activityType
                      )
                    }
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
    gap: 5,
    alignItems: 'center'
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
