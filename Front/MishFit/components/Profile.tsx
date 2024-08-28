import { ScrollView, StyleSheet, Text, View, TouchableOpacity, Modal, Image } from 'react-native';
import React, { useEffect, useState } from 'react';
import Avatar from "@/assets/images/profile/avatar.jpg";
import AsyncStorage from '@react-native-async-storage/async-storage';

interface UserData {
    birthDate: string;
    email: string;
    height: number;
    sex: string;
    weight: number;
    weightGoal: number;
    stepsGoal: number;
}

export default function Profile() {
    const [openMenu, setOpenMenu] = useState(false);

    const [userData, setUserData] = useState<UserData>({
        birthDate: '',
        email: '',
        height: 0,
        sex: '',
        weight: 0,
        weightGoal: 0,
        stepsGoal: 0,
    });

    const toggleMenu = () => {
        setOpenMenu(!openMenu);
    };

    useEffect(() => {
        const getUserInfo = async () => {
            // Получение id из хранилища
            const userId = await AsyncStorage.getItem('userId');
            const response = await fetch(`http://178.90.42.61:55555/api/v1/Users/${userId}`);

            if (response.status === 200) {
                const data = await response.json();
                console.log(data);
                // Данные пользователя полученные из data
                setUserData({
                    birthDate: data.birthDate || 'Не указана',
                    email: data.email || 'Не указана',
                    height: Number(data.height) || 0,
                    sex: data.sex ? (data.sex === 'M' ? 'Муж.' : 'Жен.') : 'Не указан',
                    weight: Number(data.weight) || 0, 
                    weightGoal: Number(data.weightGoal) || 0,
                    stepsGoal: Number(data.stepsGoal) || 0,
                });
            }
        }
        getUserInfo();
    }, []);

    // Индекс массы тела
    const bmi = userData.height > 0 ? (userData.weight / ((userData.height / 100) ** 2)).toFixed(1) : 'Не указан';

    return (
        <ScrollView style={styles.container}>
            <Text style={styles.greeting}>Привет!</Text>
            <Text style={styles.email}>{userData.email}</Text>

            <View style={styles.avatarWrapper}>
                <TouchableOpacity style={styles.avatarContainer} >
                    <Image source={Avatar} style={styles.avatar} />
                </TouchableOpacity>
            </View>

            <Text style={styles.sectionTitle}>Ваши данные</Text>
            <View style={styles.userInfoContainer}>
                <View style={styles.userInfoItem}>
                    <Text style={styles.userInfoText}>Дата рождения</Text>
                    <Text style={styles.userInfoText}>{userData.birthDate}</Text>
                </View>
                <View style={styles.userInfoItem}>
                    <Text style={styles.userInfoText}>Пол</Text>
                    <Text style={styles.userInfoText}>{userData.sex}</Text>
                </View>
                <View style={styles.userInfoItem}>
                    <Text style={styles.userInfoText}>Вес</Text>
                    <Text style={styles.userInfoText}>{userData.weight} кг</Text>
                </View>
                <View style={styles.userInfoItem}>
                    <Text style={styles.userInfoText}>Рост</Text>
                    <Text style={styles.userInfoText}>{userData.height} см</Text>
                </View>
                <View style={styles.userInfoItem}>
                    <Text style={styles.userInfoText}>ИМТ</Text>
                    <Text style={styles.userInfoText}>{bmi}</Text>
                </View>
            </View>

            <View style={styles.userTargetContainer}>
                <Text style={styles.userTargetText}>Цель по шагам</Text>
                <Text style={styles.userTarget}>{userData.stepsGoal} шагов</Text>
            </View>

            <View style={styles.userTargetContainer}>
                <Text style={styles.userTargetText}>Цель по весу</Text>
                <Text style={styles.userTarget}>{userData.weightGoal} кг</Text>
            </View>

            <TouchableOpacity style={styles.openMenuBtn} onPress={toggleMenu}>
                <View style={styles.menuStroke}></View>
                <View style={styles.menuStroke}></View>
                <View style={styles.menuStroke}></View>
            </TouchableOpacity>

            <Modal
                transparent={true}
                visible={openMenu}
                animationType="slide"
                onRequestClose={toggleMenu}
            >
                <View style={styles.modalBackground}>
                    <TouchableOpacity style={styles.closeMenu} onPress={toggleMenu}>
                        <Text style={{ color: "#fff", fontSize: 18 }}>Х</Text>
                    </TouchableOpacity>
                    <View style={styles.menuContainer}>
                        <View style={styles.userTargetContainer}>
                            <Text style={styles.userTargetText}>Язык</Text>
                            <Text style={styles.userTarget}>Русский</Text>
                        </View>
                        <View style={styles.userTargetContainer}>
                            <Text style={styles.userTargetText}>Подписка</Text>
                            <Text style={styles.userTarget}>Премиум</Text>
                        </View>
                        <View style={styles.userTargetContainer}>
                            <Text style={styles.userTargetText}>Обратная связь</Text>
                            <Text style={styles.userTarget}>Вопросы и ответы</Text>
                        </View>
                        <View style={styles.userTargetContainer}>
                            <Text style={styles.userTargetText}>Политика</Text>
                            <Text style={styles.userTarget}>Конфиденциальность</Text>
                        </View>
                    </View>
                </View>
            </Modal>
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    container: {
        padding: 15,
        backgroundColor: "#4530B1",
    },
    greeting: {
        fontSize: 24,
        fontWeight: '700',
        color: "#fff",
    },
    email: {
        fontSize: 18,
        fontWeight: '400',
        color: "#fff",
    },
    avatarWrapper: {
        padding: 15,
        borderRadius: 20,
        width: '100%',
        flexDirection: 'row',
        gap: 20,
        justifyContent: "center",
        alignItems: 'center',
    },
    avatar: {
        width: 130,
        height: 130,
    },
    avatarContainer: {
        width: 150,
        height: 150,
        backgroundColor: "#fff",
        borderRadius: 10000,
        justifyContent: "center",
        alignItems: 'center',
        borderColor: '#999',
        borderWidth: 1,
    },
    sectionTitle: {
        fontSize: 22,
        fontWeight: '500',
        color: "#fff",
        marginTop: 20,
    },
    userInfoContainer: {
        marginTop: 15,
        flexDirection: 'column',
        backgroundColor: "#5350D5",
        borderRadius: 10,
    },
    userInfoItem: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        padding: 15,
        width: '100%',
    },
    userInfoText: {
        color: "#fff",
        fontSize: 18,
        fontWeight: '600',
    },
    userTargetContainer: {
        flexDirection: 'column',
    },
    userTargetText: {
        fontSize: 19,
        fontWeight: '600',
        color: "#fff",
        marginTop: 20,
    },
    userTarget: {
        marginTop: 10,
        width: "100%",
        textAlign: "center",
        padding: 20,
        backgroundColor: "#5350D5",
        borderRadius: 10,
        fontSize: 22,
        color: "#fff",
        fontWeight: '500',
    },
    openMenuBtn: {
        position: 'absolute',
        right: 0,
        top: 0,
        borderRadius: 100,
        width: 45,
        height: 45,
        backgroundColor: "#5350D5",
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: "center",
        padding: 10,
        gap: 3,
    },
    menuStroke: {
        width: "100%",
        height: 3,
        backgroundColor: "#FFF",
    },
    modalBackground: {
        backgroundColor: '#4530B1',
        height: '100%',
        padding: 20,
        position: 'relative',
    },
    closeMenu: {
        position: 'absolute',
        right: 15,
        top: 15,
        borderRadius: 100,
        width: 45,
        height: 45,
        backgroundColor: "#5350D5",
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: "center",
        gap: 3,
        zIndex: 100,
    },
    menuContainer: {
        marginTop: 50,
    },
});
