import React, { PropsWithChildren, useState } from "react";
import { Pressable, TextInput, StyleSheet, View, Text } from "react-native";
import Tracker from "@/Interfaces.tsx/Tracker";
import { Collapsible } from "./Collapsible";
import { formatDate, formatTime } from "./ContextProvider";
import { ThemedText } from "./ThemedText";

export default function CalorieHistory({
  trackers,
}: {
  trackers: Tracker[][];
}) {
  return (
    <View>
      {trackers.map((item) => {
        return (
          <Collapsible
            key={formatDate(item[0].trackerDateTime)}
            title={formatDate(item[0].trackerDateTime)}
          >
            {item.map((tracker) => {
              return (
                <View key={tracker.id} style={{flexDirection:'row'}}>
                  <ThemedText>{formatTime(tracker.trackerDateTime)} </ThemedText>
                  <ThemedText>
                    {tracker.meal?.name}{" "}
                    {tracker.meal?.calories !== undefined &&
                    tracker.mealGramms !== null
                      ? (tracker.meal.calories / 100) * tracker.mealGramms
                      : ""}ккал{" "}
                    | {tracker.mealGramms}г
                  </ThemedText>
                  <Pressable
                    onPress={() => {
                      /*TODO*/
                    }}
                  >
                    <ThemedText>X</ThemedText>
                  </Pressable>
                </View>
              );
            })}
          </Collapsible>
        );
      })}
    </View>
  );
}

const styles = StyleSheet.create({});
