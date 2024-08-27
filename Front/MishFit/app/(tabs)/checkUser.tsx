import { ScrollView, TouchableOpacity, Text, View, StyleSheet } from 'react-native';
import React, { useEffect, useState } from 'react';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useRouter } from 'expo-router';
import Profile from '@/components/Profile';
import Register from '@/components/Register';
import Unauthorized from '@/components/Unauthorized';
import Auth from '@/components/Auth';
export default function CheckUser() {
    const router = useRouter();
    const [profileSwitch, setProfileSwitch] = useState(0);
    useEffect(() => {
        const userId = 1;

        if (false) {
            setProfileSwitch(1)
        }
        else {
            setProfileSwitch(0)
        }
    }, [])
    return (
        <View>
            {profileSwitch == 0 && (
                <View style={styles.container}>
                    <Text>Вы не авторизовались</Text>
                    <TouchableOpacity onPress={() => { setProfileSwitch(2) }}>
                        <Text>Зарегаться</Text>
                    </TouchableOpacity>
                    <TouchableOpacity onPress={() => { setProfileSwitch(3) }}>
                        <Text>Войти</Text>
                    </TouchableOpacity>
                </View>)}
            {profileSwitch == 1 && (<Profile />)}
            {profileSwitch == 2 && (<Register></Register>)}
            {profileSwitch == 3 && (<Auth></Auth>)}
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',

    }
});
