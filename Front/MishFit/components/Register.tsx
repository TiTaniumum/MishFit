import { StyleSheet, Text, View } from 'react-native'
import React, { useEffect } from 'react'

export default function Register() {
  useEffect(() => {
    const handleRegister = async () => {
      try {
        const response = await fetch('http://178.90.42.61:55555/api/v1/Meals', {
          method: 'GET',

          // body: JSON.stringify({
          //   "email": "anurbbekov2@gmail.com",
          //   "password": "1233123123"
          //   // sex: 1,
          //   // birthDate: "2024-08-27",
          //   // weight: 100,
          //   // height: 100,
          //   // stepsGoal: 10000,
          //   // weightGoal: 100,
          // }),
        });

        if (!response.ok) {
          throw new Error(`Ошибка: ${response.statusText}`);
        }

        const data = await response.json();
        console.log(data);
      } catch (err) {
        console.log(err);
      }
    };

    handleRegister();
  }, []);


  return (
    <View>
      <Text>register</Text>
    </View>
  )
}

const styles = StyleSheet.create({})