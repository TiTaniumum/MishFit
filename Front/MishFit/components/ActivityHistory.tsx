import React, { PropsWithChildren, useState } from "react";
import { Pressable, TextInput, StyleSheet, View, Text } from "react-native";
import Tracker, { ActivityType } from "@/Interfaces.tsx/Tracker";
import { Collapsible } from "./Collapsible";
import { formatDate, formatTime, useGlobalContext } from "./ContextProvider";
import { ThemedText } from "./ThemedText";
import Animated, { FadeIn } from "react-native-reanimated";
import { TouchableOpacity } from "react-native";

export default function ActivityHistory({
  trackers,
}: {
  trackers: Tracker[][] | null;
}) {
  const { deleteTracker } = useGlobalContext();

  return (
    <View style={{ gap: 10 }}>
      {trackers?.map((item) => {
        return (
          <View
            key={formatDate(item[0].trackerDateTime)}
            style={styles.collapsibleStyle}
          >
            <Collapsible title={formatDate(item[0].trackerDateTime, "history")}>
              <Animated.View entering={FadeIn} style={{ gap: 5 }}>
                {item.map((tracker) => {
                  return (
                    <View key={tracker.id} style={styles.collapsableContent}>
                      <ThemedText>
                        {formatTime(tracker.trackerDateTime)}{" "}
                      </ThemedText>
                      <ThemedText>
                        {tracker.activity?.name}{" "}
                        {tracker.activityType == ActivityType.Timespan ? (
                          <View style={styles.activityContent}>
                            <Text style={{color: 'white'}}>{tracker.activityTimespan}</Text>
                            <Text style={styles.tinyText}>мин</Text>
                          </View>
                        ) : (
                          <View style={styles.activityContent}>
                            <Text style={styles.tinyText}>подх</Text>
                            <View style={{ width: 2 }} />
                            <Text style={{color: 'white'}}>{tracker.activitySets}</Text>
                            <Text style={{color: 'white'}}>/</Text>
                            <Text style={{color: 'white'}}>{tracker.activityRepititions}</Text>
                            <View style={{ width: 2 }} />
                            <Text style={styles.tinyText}>повт</Text>
                          </View>
                        )}
                      </ThemedText>
                      <TouchableOpacity
                        style={styles.deleteButton}
                        onPress={() => {
                          deleteTracker(tracker.id);
                        }}
                      >
                        <Text style={styles.deleteButtonText}>x</Text>
                      </TouchableOpacity>
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
  },
  deleteButtonText: {
    color: "#faaaaa",
  },
  collapsableContent: {
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between",
  },
  activityContent: {
    flexDirection: "row",
    justifyContent: "space-between",
    alignItems: "baseline",
  },
  tinyText: {
    color: "white",
    fontSize: 10,
  },
  collapsibleStyle: {
    padding: 5,
    borderRadius: 10,
    backgroundColor: "#6554d7",
  },
});
