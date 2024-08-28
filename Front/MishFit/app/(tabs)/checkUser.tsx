import { ScrollView, TouchableOpacity, Text, View, StyleSheet } from 'react-native';
import React, { useEffect, useState } from 'react';
import Profile from '@/components/Profile';
import Register from '@/components/Register';
import Auth from '@/components/Auth';
import AsyncStorage from '@react-native-async-storage/async-storage';

export default function CheckUser() {
    const [profileSwitch, setProfileSwitch] = useState(0);
    useEffect(() => {
        const getUserInfo = async () => {
            const userId = await AsyncStorage.getItem("userId");
            if (userId) {
                setProfileSwitch(1)
            }
        }
        getUserInfo()
    }, [])
    const handleRegisterSuccess = () => {
        setProfileSwitch(1);
    };

    return (
        <ScrollView contentContainerStyle={styles.container}>
            {profileSwitch === 0 && (
                <View>
                    <Text>Вы не авторизовались</Text>
                    <TouchableOpacity onPress={() => setProfileSwitch(2)}>
                        <Text>Зарегаться</Text>
                    </TouchableOpacity>
                    <TouchableOpacity onPress={() => setProfileSwitch(3)}>
                        <Text>Войти</Text>
                    </TouchableOpacity>
                </View>
            )}
            {profileSwitch === 1 && <Profile />}
            {profileSwitch === 2 && <Register onRegisterSuccess={handleRegisterSuccess} />}
            {profileSwitch === 3 && <Auth onRegisterSuccess={handleRegisterSuccess}/>}
        </ScrollView>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
    },
});
