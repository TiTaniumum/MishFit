import React, { PropsWithChildren, useState } from "react";
import { Pressable, TextInput, StyleSheet, View, Text } from "react-native";
import Tracker, { ActivityType } from "@/Interfaces.tsx/Tracker";
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

export default function ActivityHistory({
  trackers,
}: {
  trackers: Tracker[][] | null;
}) {
  function onDeleteButtonPress(id: number) {
    // TODO: запрос в базу данных на удаление трекера
  }

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
                            <Text>{tracker.activityTimespan}</Text>
                            <Text style={styles.tinyText}>мин</Text>
                          </View>
                        ) : (
                          <View style={styles.activityContent}>
                            <Text style={styles.tinyText}>подх</Text>
                            <View style={{ width: 2 }} />
                            <Text>{tracker.activitySets}</Text>
                            <Text>/</Text>
                            <Text>{tracker.activityRepititions}</Text>
                            <View style={{ width: 2 }} />
                            <Text style={styles.tinyText}>повт</Text>
                          </View>
                        )}
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
  activityContent: {
    flexDirection: "row",
    justifyContent: "space-between",
    alignItems: "baseline",
  },
  tinyText: {
    fontSize: 10,
  },
  collapsibleStyle: {
    padding: 5,
    borderRadius: 20,
    backgroundColor: "#6554d7",
  },
});
