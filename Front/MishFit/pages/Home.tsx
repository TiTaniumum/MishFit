import { View, Text, StyleSheet, FlatList, Button } from "react-native";
import { useGlobalContext } from "../components/ContextProvider";
import React, { useState } from "react";


export default function Home({ navigation }: any) {
  
  return (
    <View style={styles.container}>
        <Text>Hello World</Text>
        <Text>Hello everyone</Text>
        <Text>Task1 text</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#fff",
    alignItems: "center",
    justifyContent: "center",
  },
});
