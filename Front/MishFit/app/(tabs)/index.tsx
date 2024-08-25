import React, { useEffect, useState } from 'react';
import { View, Text, StyleSheet, ScrollView, ImageBackground } from 'react-native';
import * as Progress from 'react-native-progress';
import AsyncStorage from '@react-native-async-storage/async-storage';

// Импорт трекеров
import WaterTracker from '@/components/WaterTracker';
import { useGlobalContext } from '@/components/ContextProvider';


export default function Home() {
  const {waterIntake, dailyIntake} = useGlobalContext();
  const [calories, setCalories] = useState<number>(2378); 

  return (
    <ScrollView style={styles.container}>
      <View style={styles.recommendations}>
        <Text style={styles.text}>Рекомендации</Text>
      </View>
      <View style={styles.section}>
        <Text style={styles.label}>Водный баланс</Text>
        <View style={styles.progressContainer}>
          <Text style={styles.value}>{waterIntake} / {dailyIntake}</Text>
          <Progress.Bar 
            progress={waterIntake / dailyIntake} 
            width={130} 
            color="#6554d7" 
            style={styles.progressBar} 
            height={8}
          />
        </View>
      </View>
      <View style={styles.section}>
        <Text style={styles.label}>Калории</Text>
        <View style={styles.progressContainer}>
          <Text style={styles.value}>{calories} / 2848 ккал</Text>
          <Progress.Bar 
            progress={calories / 2848} 
            width={130} 
            color="#6554d7" 
            style={styles.progressBar} 
            height={8}
          />
        </View>
      </View>
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 16,
    backgroundColor: '#cfd9e3',
  },
  section: {
    backgroundColor: '#fff',
    padding: 20,
    borderRadius: 10,
    marginBottom: 16,
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
  },
  recommendations: {
    backgroundColor: '#6554d7',
    padding: 20,
    borderRadius: 10,
    marginBottom: 28, 
    marginTop: 38,  
    alignItems: 'center',
  },
  text: {
    color: '#fff',
    fontSize: 18,
    fontFamily:"System"
  },
  label: {
    fontSize: 16,
    fontWeight: 'bold',
    color: '#333',
    fontFamily: "System"
  },
  progressContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
    marginTop: 10,
    paddingRight: 15
  },
  value: {
    fontSize: 14,
    fontWeight: '600',
    color: '#555',
    paddingRight: 20,
    fontFamily:"System"
  },
  progressBar: {
    marginTop: 10,
  },
  stepsSection: {
    backgroundColor: '#fff',
    padding: 20,
    borderRadius: 10,
    marginBottom: 16,
  },
  stepsInfo: {
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
  },
  stepsCircleText: {
    fontSize: 12,
  },
});
