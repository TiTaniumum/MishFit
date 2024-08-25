import { Button, View, StyleSheet, Text, TouchableOpacity } from "react-native";
import { useGlobalContext } from "./ContextProvider";
import Tracker from "@/Interfaces.tsx/Tracker";
import { useEffect, useState } from "react";
import CalorieHistory from "./CalorieHistory";
import CalorieAdder from "./CalorieAdder";

export default function CalorieTracker() {
  const { trackers, getCalorieTrackers } = useGlobalContext();
  const [calorieTrackers, setCalorieTrackers] = useState<Tracker[][] | null>(
    null
  );
  const [isSearch, setIsSearch] = useState(false);

  useEffect(() => {
    setCalorieTrackers(getCalorieTrackers());
  }, [trackers]);

  return (
    <View>
      <TouchableOpacity
        onPress={() => {
          setIsSearch(!isSearch);
        }}
        style={[styles.addButton, { marginBottom: 10 }]}
      >
        <Text style={{ color: "white" }}>
          {isSearch ? "Вернуться" : "Добавить трекер"}
        </Text>
      </TouchableOpacity>
      {isSearch ? (
        <CalorieAdder />
      ) : (
        <CalorieHistory trackers={calorieTrackers} />
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  addButton: {
    flex: 1,
    padding: 12,
    alignItems: "center",
    backgroundColor: "#6554d7",
    borderRadius: 10,
    marginRight: 5,
  },
});
