import { ScrollView, Text, View, StyleSheet } from 'react-native';
import React, { useEffect, useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useRouter } from 'expo-router';

export default function CheckUser() {
    const router = useRouter();
    const [isLogged, setLogged] = useState(false);

    useEffect(() => {
        const fetchUserId = async () => {
            try {
                // const userId = await AsyncStorage.getItem("userId");
                const userId = 1;
                if (userId == 1) {
                    setLogged(true);
                } else {
                    setLogged(false);
                }
            } catch (error) {
                console.error('Failed to fetch userId from AsyncStorage', error);
            }
        };

        fetchUserId();
    }, []);

    useEffect(() => {
        if (isLogged) {
            router.replace('/profile');
        } else {
            router.replace('/register');
        }
    }, [isLogged]);

    return (
        <ScrollView>
            <View style={styles.container}>
                <Text>Проверка пользователя...</Text>
            </View>
        </ScrollView>
    );
}

const styles = StyleSheet.create({
    container: {
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        minHeight: '100%',
    }
});
