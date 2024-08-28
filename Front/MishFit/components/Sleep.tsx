import React, { useState, useEffect } from 'react';
import { ScrollView, Text, Image, View, TouchableOpacity, Modal, StyleSheet } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage'; // Импорт AsyncStorage для работы с локальным хранилищем
import CircularProgressBar from './CircularProgressBar';
import { Colors } from '@/constants/Colors';
import Moon from "@/assets/images/sleep/moon.jpg";

export default function Sleep() {
    // Состояния для хранения информации о сне
    const [startTime, setStartTime] = useState<Date | null>(null);
    const [endTime, setEndTime] = useState<Date | null>(null);
    const [sleepDuration, setSleepDuration] = useState<number>(0);
    const [sleepRecords, setSleepRecords] = useState<Array<{ day: string, start: Date, end: Date, duration: number }>>([]);
    const [modalVisible, setModalVisible] = useState<boolean>(false);
    const [sleepDurationModalVisible, setSleepDurationModalVisible] = useState<boolean>(false);
    const [elapsedTime, setElapsedTime] = useState<number>(0); // Время, прошедшее в секундах
    const [currentTime, setCurrentTime] = useState<Date>(new Date()); // Текущее время

    // Загрузка данных о сне из AsyncStorage при первом рендере компонента
    useEffect(() => {
        const loadSleepRecords = async () => {
            try {
                // Получение данных о сне из локального хранилища
                const records = await AsyncStorage.getItem('sleepRecords');
                if (records) {
                    // Установка состояния с данными из AsyncStorage
                    setSleepRecords(JSON.parse(records));
                }
            } catch (error) {
                console.error('Ошибка: ', error);
            }
        };

        loadSleepRecords();
    }, []);

    // Таймер для обновления времени и продолжительности сна
    useEffect(() => {
        let timer: NodeJS.Timeout;
        if (sleepDurationModalVisible && startTime) {
            timer = setInterval(() => {
                const now = new Date();
                const elapsed = Math.max(0, Math.floor((now.getTime() - startTime.getTime()) / 1000));
                setElapsedTime(elapsed);
                setCurrentTime(now);
            }, 1000);
        } else {
            setElapsedTime(0);
            setCurrentTime(new Date());
        }

        return () => clearInterval(timer);
    }, [sleepDurationModalVisible, startTime]);

    // Обработка начала отслеживания сна
    const handleStart = () => {
        const today = new Date().toLocaleDateString('ru-RU', { weekday: 'long' });
        const alreadyRecorded = sleepRecords.some(record => record.day === today);
        if (alreadyRecorded) {
            setModalVisible(true); // Показать предупреждение, если данные о сне уже есть
        } else {
            setSleepDurationModalVisible(true); // Показать модальное окно для отслеживания сна
            setStartTime(new Date());
            setEndTime(null);
        }
    };

    // Обработка остановки отслеживания сна и сохранение данных
    const handleStop = async () => {
        if (startTime) {
            const now = new Date();
            const duration = (now.getTime() - startTime.getTime()) / (1000 * 60 * 60); // Продолжительность сна в часах
            const day = now.toLocaleDateString('ru-RU', { weekday: 'long' });
            setEndTime(now);
            setSleepDuration(duration);
            const newRecord = { day, start: startTime, end: now, duration };

            // Обновление состояния и сохранение данных в AsyncStorage
            const updatedRecords = [...sleepRecords, newRecord];
            setSleepRecords(updatedRecords);
            try {
                await AsyncStorage.setItem('sleepRecords', JSON.stringify(updatedRecords));
            } catch (error) {
                console.error('Failed to save sleep records:', error);
            }
        }
    };

    // Форматирование времени в часы, минуты и секунды 
    const formatTime = (seconds: number) => {
        const minutes = Math.floor(seconds / 60);
        const hours = Math.floor(minutes / 60);
        return `${String(hours).padStart(2, '0')}:${String(minutes % 60).padStart(2, '0')}:${String(seconds % 60).padStart(2, '0')}`;
    };

    return (
        <ScrollView style={styles.wrapper}>
            <Text style={styles.sectionTitle}>Данные о снах</Text>
            <ScrollView style={styles.sleepStatistic} horizontal={true}>
                {/* Если нет данных о снах, вывести текст */}
                {sleepRecords.length === 0 ? (
                    <View style={styles.noRecordsContainer}>
                        <Text style={styles.noRecordsText}>Нет данных о снах</Text>
                    </View>
                ) : (
                    // Вывод данных о снах
                    sleepRecords.map((record, index) => (
                        <View key={index} style={styles.progressBarContainer}>
                            <Text style={styles.dateText}>
                                {`${record.day}`}
                            </Text>
                            <CircularProgressBar
                                value={(record.duration / 8) * 100} // Прогресс бара для сна (макс. 8 часов)
                                radius={45}
                                activeStrokeColor={Colors.secondary}
                                activeStrokeSecondaryColor={Colors.secondary}
                                inActiveStrokeColor={Colors.white}
                                title={`${record.duration.toFixed(1)} ч`} // Продолжительность сна в часах
                            />
                        </View>
                    ))
                )}
            </ScrollView>
            <Text style={styles.sectionTitle}>Ложитесь спать?</Text>
            <View>
                <TouchableOpacity onPress={handleStart}>
                    <Text style={styles.buttonText}>Начать отслеживание сна</Text>
                </TouchableOpacity>
            </View>

            {/* Модалка предупреждения */}
            <Modal
                animationType="fade"
                transparent={true}
                visible={modalVisible}
                onRequestClose={() => setModalVisible(false)}
            >
                <View style={styles.modalContainer}>
                    <View style={styles.modalContent}>
                        <Text style={styles.modalText}>Вы уже записали время сна на сегодня!</Text>
                        <TouchableOpacity
                            onPress={() => setModalVisible(false)}
                            style={styles.modalButton}
                        >
                            <Text style={styles.modalButtonText}>ОК</Text>
                        </TouchableOpacity>
                    </View>
                </View>
            </Modal>

            {/* Модалка с отслеживанием сна */}
            <Modal
                animationType="slide"
                visible={sleepDurationModalVisible}
                onRequestClose={() => setSleepDurationModalVisible(false)}
            >
                <View style={styles.modalSleepContainer}>
                    <View style={styles.modalSleepContent}>
                        <Text style={styles.modalSleepText}>Спокойной ночи</Text>
                        <Text style={{ fontSize: 20, fontWeight: '500', color: "#999", marginTop: 20, marginBottom: 40 }}>
                            {currentTime.toLocaleTimeString()}
                        </Text>
                        <Image style={styles.modalMoonImg} source={Moon} />
                        <Text style={{ fontSize: 20, fontWeight: '500', color: "#999" }}>Продолжительность сна</Text>
                        <View style={styles.sleepDuration}>
                            <Text style={styles.sleepDurationText}>{formatTime(elapsedTime)}</Text>
                        </View>
                        <TouchableOpacity
                            onPress={() => {
                                handleStop(); // Сохранение данных о сне
                                setSleepDurationModalVisible(false); // Закрытие модального окна
                            }}
                            style={styles.modalButton}
                        >
                            <Text style={styles.modalSleepButtonText}>Проснуться</Text>
                        </TouchableOpacity>
                    </View>
                </View>
            </Modal>
        </ScrollView>
    );
}


const styles = StyleSheet.create({
    noRecordsContainer: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        width: '100%',
        textAlign: 'center',
    },
    noRecordsText: {
        fontSize: 18,
        color: Colors.white,
    },
    sleepDuration: {
        paddingVertical: 12,
    },
    sleepDurationText: {
        color: "#fff",
        fontSize: 22,
        fontWeight: 800,
    },
    modalMoonImg: {
        width: '90%',
        height: 250,
        resizeMode: 'contain',
        marginBottom: 100
    },
    modalSleepContainer: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: "#241a54",
    },
    modalSleepContent: {
        width: '100%',
        height: '100%',
        alignItems: 'center',
        padding: 50
    },
    modalSleepText: {
        fontSize: 32,
        fontWeight: 500,
        color: "#DBE9F6"
    },
    modalButton: {
        backgroundColor: Colors.primary,
        borderRadius: 10,
        paddingVertical: 10,
        paddingHorizontal: 20,
    },
    modalSleepButtonText: {
        color: Colors.white,
        fontSize: 18,
    },
    sectionTitle: {
        fontSize: 20,
        fontWeight: '700',
        color: Colors.primary,
    },
    wrapper: {
        marginVertical: 20,
    },
    buttonText: {
        fontSize: 18,
        color: Colors.primary,
        marginVertical: 10,
    },
    dateText: {
        fontSize: 16,
        color: Colors.white,
        marginBottom: 10,
        textAlign: 'center',
    },
    sleepStatistic: {
        marginTop: 20,
        minHeight: 150,
        backgroundColor: Colors.secondary,
        borderRadius: 20,
        marginBottom: 50,
        padding: 20,
    },
    progressBarContainer: {
        marginBottom: 20,
        maxWidth: 90,
        marginRight: 20,
    },
    modalContainer: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: 'rgba(0, 0, 0, 0.5)',
    },
    modalContent: {
        width: 300,
        padding: 20,
        backgroundColor: Colors.white,
        borderRadius: 10,
        alignItems: 'center',
    },
    modalText: {
        fontSize: 18,
        marginBottom: 20,
        textAlign: 'center',
        color: Colors.primary,
    },
    modalButtonText: {
        color: Colors.white,
        fontSize: 16,
    },
    zzzContainer: {
        flexDirection: 'row',
        justifyContent: 'center',
        marginVertical: 20,
    },
    zText: {
        fontSize: 62,
        fontWeight: 'bold',
        color: Colors.white,
        marginHorizontal: 5,
    },
    zText2: {
        fontSize: 62,
        fontWeight: 'bold',
        color: Colors.white,
        marginHorizontal: 5,
        transform: [{ translateY: -30 }],
    },
    zText3: {
        fontSize: 62,
        fontWeight: 'bold',
        color: Colors.white,
        marginHorizontal: 5,
        transform: [{ translateY: -50 }],
    },
    animateZText: {
        transform: [{ translateY: -10 }],
        opacity: 0.2,
    },
    animateZText2: {
        transform: [{ translateY: -40 }],
        opacity: 0.2,
    },
    animateZText3: {
        transform: [{ translateY: -70 }],
        opacity: 0.2,
    },
});
