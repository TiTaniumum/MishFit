import { StyleSheet, Text, View, ScrollView, TextInput, Button as RNButton } from 'react-native';
import React, { useState } from 'react';
import { Colors } from '@/constants/Colors';
import InputField from './InputField';
import Button from './Button';
import AsyncStorage from '@react-native-async-storage/async-storage';
interface RegisterProps {
  onRegisterSuccess: () => void; // Функция обратного вызова для успешной регистрации
}

export default function Register({ onRegisterSuccess }: RegisterProps) {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [birthDate, setBirthDate] = useState('');
  const [weight, setWeight] = useState('');
  const [height, setHeight] = useState('');
  const [stepsGoal, setStepsGoal] = useState('');
  const [weightGoal, setWeightGoal] = useState('');

  const handleRegister = async () => {
    try {
      const response = await fetch('http://178.90.42.61:55555/api/v1/Users/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          email,
          password,
          // birthDate,
          weight,
          height,
          stepsGoal,
          weightGoal,
        }),
      });

      if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`Ошибка: ${response.statusText}. Тело ответа: ${errorText}`);
      }

      const data = await response.json();
      console.log('Регистрация успешна:', data);
      await AsyncStorage.setItem('userId', data.id.toString());
      console.log(data.id.toString());
      onRegisterSuccess(); // Вызов функции обратного вызова
    } catch (err) {
      console.error('Ошибка при регистрации:', err);
    }
  };

  return (
    <ScrollView contentContainerStyle={styles.wrapper}>
      <Text style={styles.header}>Регистрация</Text>
      <Text style={styles.subHeader}>Создайте аккаунт чтобы продолжить</Text>
      <InputField
        label="Почта *"
        value={email}
        onChangeText={setEmail}
        placeholder="example@gmail.com"
      />
      <InputField
        label="Пароль *"
        value={password}
        onChangeText={setPassword}
        placeholder="Введите пароль"
        secureTextEntry={true}
      />
      <InputField
        label="Повторите пароль *"
        value={confirmPassword}
        onChangeText={setConfirmPassword}
        placeholder="Повторите пароль"
        secureTextEntry={true}
      />
      <InputField
        label="День рождения"
        value={birthDate}
        onChangeText={setBirthDate}
        placeholder="2024-08-27"
      />
      <InputField
        label="Вес (кг)"
        value={weight}
        onChangeText={setWeight}
        placeholder="Введите вес"
        keyboardType="numeric"
      />
      <InputField
        label="Рост (см)"
        value={height}
        onChangeText={setHeight}
        placeholder="Введите рост"
        keyboardType="numeric"
      />
      <InputField
        label="Цель по весу"
        value={weightGoal}
        onChangeText={setWeightGoal}
        placeholder="90"
        keyboardType="numeric"
      />
      <InputField
        label="Цель по шагам"
        value={stepsGoal}
        onChangeText={setStepsGoal}
        placeholder="10000"
        keyboardType="numeric"
      />
      <Button title='Регистрация' onPress={handleRegister} />
    </ScrollView>
  );
}

const styles = StyleSheet.create({
  wrapper: {
    padding: 15,
    width: '100%'
  },
  header: {
    fontSize: 18,
    fontWeight: '800',
    color: Colors.primary,
    marginBottom: 8,
  },
  subHeader: {
    marginBottom: 24,
  },
});
