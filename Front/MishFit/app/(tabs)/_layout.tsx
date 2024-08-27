import { Tabs } from 'expo-router';
import React, { useState, useEffect } from 'react';

import { TabBarIcon } from '@/components/navigation/TabBarIcon';
import { Colors } from '@/constants/Colors';
import { useColorScheme } from '@/hooks/useColorScheme';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default function TabLayout() {
  const colorScheme = useColorScheme();
  const [isLogged, setIsLogged] = useState(false);

  useEffect(() => {
    const checkLoginStatus = async () => {
      const userId = await AsyncStorage.getItem("userId");
      if (userId != null) {
        setIsLogged(true);
      }
      else {
        setIsLogged(false);
      }
    };

    checkLoginStatus();
  }, []);

  return (
    <Tabs
      screenOptions={{
        headerShown: false,
      }}
    >
      <Tabs.Screen
        name="index"
        options={{
          title: 'Главная',
          tabBarIcon: ({ color, focused }) => (
            <TabBarIcon name={focused ? 'home' : 'home-outline'} color={color} />
          ),
        }}
      />
      <Tabs.Screen
        name="trackers"
        options={{
          title: 'Трекеры',
          tabBarIcon: ({ color, focused }) => (
            <TabBarIcon name={focused ? 'analytics' : 'analytics-outline'} color={color} />
          ),
        }}
      />
      <Tabs.Screen
        name="checkUser"
        options={{
          title: 'Профиль',
          tabBarIcon: ({ color, focused }) => (
            <TabBarIcon name={focused ? 'person' : 'person-outline'} color={color} />
          ),
        }}
      />
    </Tabs>
  );
}
