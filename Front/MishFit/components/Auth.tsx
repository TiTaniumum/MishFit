import { StyleSheet, Text, View, ScrollView } from 'react-native';
import React, { useState } from 'react';
import { Colors } from '@/constants/Colors';
import InputField from './InputField';
import Button from './Button';
import AsyncStorage from '@react-native-async-storage/async-storage';

interface AuthProps {
    onRegisterSuccess: () => void; // Добавление функции обратного вызова
}

export default function Auth({ onRegisterSuccess }: AuthProps) {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleRegister = async () => {
        try {
            const response = await fetch('http://178.90.42.61:55555/api/v1/Users/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email, password }),
            });

            if (!response.ok) {
                const errorText = await response.text();
                throw new Error(`Ошибка: ${response.statusText}. Тело ответа: ${errorText}`);
            }

            const data = await response.json();
            console.log('Авторизация успешна:', data);
            await AsyncStorage.setItem('userId', "c0dfb2b0-39b9-4ddf-823d-2a2debe1bae7"); // Используйте ID из ответа
            onRegisterSuccess(); // Вызов функции обратного вызова
        } catch (err) {
            console.error('Ошибка при авторизации:', err);
        }
    };

    return (
        <ScrollView contentContainerStyle={styles.wrapper}>
            <Text style={styles.header}>Авторизация</Text>
            <Text style={styles.subHeader}>Введите ваши данные чтобы продолжить</Text>
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
            <Button title='Войти' onPress={handleRegister} />
        </ScrollView>
    );
}

const styles = StyleSheet.create({
    wrapper: {
        padding: 15,
        width: '100%',
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
