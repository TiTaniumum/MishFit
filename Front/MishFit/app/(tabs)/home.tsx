import React, { useEffect, useState } from 'react';
import { View, Text, StyleSheet, ScrollView } from 'react-native';
import * as Progress from 'react-native-progress';

// Импорт трекеров
import WaterTracker from '@/components/WaterTracker';

export default function Home() {
  const [steps, setSteps] = useState<number>(4500);
  const [water, setWater] = useState<number>(0);
  const [calories, setCalories] = useState<number>(2378); 

  return (
    <ScrollView style={styles.container}>
      <View style={styles.recommendations}>
        <Text style={styles.text}>Рекомендации</Text>
      </View>

      <WaterTracker/> 
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

      <View style={styles.stepsSection}>
        <Text style={styles.label}>Пройдено шагов</Text>
        <View style={styles.stepsInfo}>
          <Text style={styles.value}>{steps} / 6000</Text>
          <Progress.Circle 
            size={80} 
            progress={steps / 6000} 
            showsText={true} 
            formatText={() => `${steps}/6000`} 
            color="#6554d7"
            textStyle={styles.stepsCircleText}
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
    marginTop: 38    ,  
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
