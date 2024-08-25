import { useGlobalContext } from "./ContextProvider";
import Tracker from "@/Interfaces.tsx/Tracker";
import { useEffect, useState } from "react";
import ActivityHistory from "./ActivityHistory";
import { TouchableOpacity, View, Text, StyleSheet } from "react-native";
import ActivityAdder from "./ActivityAdder";

export default function ActivityTracker() {
  const { trackers, getActivityTrackers } = useGlobalContext();
  const [activityTrackers, setActivityTrackers] = useState<Tracker[][] | null>(
    null
  );
  const [isSearch, setIsSearch] = useState(false);

  useEffect(() => {
    setActivityTrackers(getActivityTrackers());
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
        <ActivityAdder/>
      ) : (
          <ActivityHistory trackers={activityTrackers} />
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
