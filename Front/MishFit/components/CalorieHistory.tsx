import React, { PropsWithChildren, useState } from "react";
import { Pressable, TextInput, StyleSheet, View, Text } from "react-native";
import Tracker from "@/Interfaces.tsx/Tracker";
import { Collapsible } from "./Collapsible";
import { formatDate, formatTime } from "./ContextProvider";
import { ThemedText } from "./ThemedText";
import Animated, {
  FadeIn,
  FadeOut,
  SlideInDown,
  SlideInUp,
  SlideOutDown,
  SlideOutUp,
} from "react-native-reanimated";

export default function CalorieHistory({
  trackers,
}: {
  trackers: Tracker[][];
}) {
  function onDeleteButtonPress(id: number) {
    // TODO: запрос в базу данных на удаление трекера
  }

  return (
    <View style={{ gap: 10 }}>
      {trackers.map((item) => {
        return (
          <View style={styles.collapsibleStyle}>
            <Collapsible
              key={formatDate(item[0].trackerDateTime)}
              title={formatDate(item[0].trackerDateTime, "history")}
            >
              <Animated.View entering={FadeIn} style={{ gap: 5 }}>
                {item.map((tracker) => {
                  return (
                    <View key={tracker.id} style={styles.collapsableContent}>
                      <ThemedText>
                        {formatTime(tracker.trackerDateTime)}{" "}
                      </ThemedText>
                      <ThemedText>
                        {tracker.meal?.name}{" "}
                        {tracker.meal?.calories !== undefined &&
                        tracker.mealGramms !== null
                          ? (tracker.meal.calories / 100) * tracker.mealGramms
                          : ""}
                        ккал | {tracker.mealGramms}г
                      </ThemedText>
                      <Pressable
                        style={styles.deleteButton}
                        onPress={() => {
                          onDeleteButtonPress(tracker.id);
                        }}
                      >
                        <Text style={styles.deleteButtonText}>x</Text>
                      </Pressable>
                    </View>
                  );
                })}
              </Animated.View>
            </Collapsible>
          </View>
        );
      })}
    </View>
  );
}

const styles = StyleSheet.create({
  deleteButton: {
    justifyContent: "center",
    alignItems: "center",
    width: 25,
    height: 25,
    borderRadius: 5,
    borderColor: "#faaaaa",
    borderWidth: 1,
    padding: 5,
  },
  deleteButtonText: {
    color: "#faaaaa",
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
});
