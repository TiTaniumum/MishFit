import { ScrollView, StyleSheet, Text, View, TouchableOpacity, Modal, Image } from 'react-native'
import React, { useState } from 'react'
import Avatar from "@/assets/images/profile/avatar.jpg"
export default function Profile() {

    const [openMenu, setOpenMenu] = useState(false);
    const toggleMenu = () => {
        setOpenMenu(!openMenu);
    };

    return (
        <ScrollView style={styles.container}>
            <Text style={{ fontSize: 28, fontWeight: 600, color: "#fff" }}>Hi! Marat</Text>
            <View style={styles.avatarWrapper}>
                <TouchableOpacity style={styles.avatarContainer} >
                    <Image source={Avatar} style={styles.avatar}></Image>
                </TouchableOpacity>
            </View>
            <Text style={{ fontSize: 22, fontWeight: 500, color: "#fff", marginTop: 20 }}>Ваши данные</Text>
            <View style={styles.userInfoContainer}>
                <View style={styles.userInfoItem}>
                    <Text style={styles.userInfoText}>Дата рождения</Text>
                    <Text style={styles.userInfoText}>1995.05.30</Text>
                </View>
                <View style={styles.userInfoItem}>
                    <Text style={styles.userInfoText}>Пол</Text>
                    <Text style={styles.userInfoText}>Муж.</Text>
                </View>
                <View style={styles.userInfoItem}>
                    <Text style={styles.userInfoText}>Вес</Text>
                    <Text style={styles.userInfoText}>90 кг</Text>
                </View>
                <View style={styles.userInfoItem}>
                    <Text style={styles.userInfoText}>Рост</Text>
                    <Text style={styles.userInfoText}>182</Text>
                </View>
                <View style={styles.userInfoItem}>
                    <Text style={styles.userInfoText}>ИМТ</Text>
                    <Text style={styles.userInfoText}>25</Text>
                </View>
            </View>
            <View style={styles.userTargetContianer}>
                <Text style={styles.userTargetText}>Цель по шагам</Text>
                <Text style={styles.userTarget}>6000</Text>
            </View>
            <View style={styles.userTargetContianer}>
                <Text style={styles.userTargetText}>Цель по весу</Text>
                <Text style={styles.userTarget}>80кг</Text>
            </View>
            <TouchableOpacity style={styles.openMenuBtn} onPress={toggleMenu}>
                <View style={styles.menuStorke}></View>
                <View style={styles.menuStorke}></View>
                <View style={styles.menuStorke}></View>
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
                        <View style={styles.userTargetContianer}>
                            <Text style={styles.userTargetText}>Язык</Text>
                            <Text style={styles.userTarget}>Русский</Text>
                        </View>
                        <View style={styles.userTargetContianer}>
                            <Text style={styles.userTargetText}>Подписка</Text>
                            <Text style={styles.userTarget}>Премиум</Text>
                        </View>
                        <View style={styles.userTargetContianer}>
                            <Text style={styles.userTargetText}>Обратная связь</Text>
                            <Text style={styles.userTarget}>Вопросы и отеты</Text>
                        </View>
                        <View style={styles.userTargetContianer}>
                            <Text style={styles.userTargetText}>Политика</Text>
                            <Text style={styles.userTarget}>Конфиденциальность</Text>
                        </View>

                    </View>
                </View>
            </Modal>
            <View>

            </View>
        </ScrollView>
    )
}

const styles = StyleSheet.create({
    menuContainer: {
        marginTop: 50
    },
    modalBackground: {
        backgroundColor: '#4530B1',
        height: '100%',
        padding: 20,
        position: 'relative'
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
        zIndex: 100
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
    menuStorke: {
        width: "100%",
        height: 3,
        backgroundColor: "#FFF"
    },
    container: {
        padding: 15,
        backgroundColor: "#4530B1"
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
    avatarWrapper: {
        padding: 15,
        borderRadius: 20,
        width: '100%',
        flexDirection: 'row',
        gap: 20,
        justifyContent: "center",
        alignItems: 'center',

    },
    userInfoContainer: {
        marginTop: 15,
        flexDirection: 'column',
        backgroundColor: "#5350D5",
        borderRadius: 10,

    },
    stroke: {
        width: "100%",
        height: 1,
        backgroundColor: '#999'
    },
    userWeight: {
        fontSize: 20,
        color: "#fff",
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
        fontWeight: 600
    },
    userTargetContianer: {
        flexDirection: 'column',

    },
    userTargetText: {
        fontSize: 19, fontWeight: 500, color: "#fff", marginTop: 20
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
        fontWeight: 700,
        letterSpacing: 3,
    }
})