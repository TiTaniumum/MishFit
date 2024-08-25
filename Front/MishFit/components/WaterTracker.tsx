import React, { useState, useEffect } from 'react';
import { View, Text, StyleSheet, TextInput, TouchableOpacity } from 'react-native';
import Svg, { Path } from 'react-native-svg';
import * as Progress from 'react-native-progress';
import AsyncStorage from '@react-native-async-storage/async-storage';
import { useGlobalContext } from './ContextProvider';

export default function WaterTracker() {
    const { dailyIntake, waterIntake, setWaterIntake } = useGlobalContext();
    const [inputValue, setInputValue] = useState<string>('50');

    useEffect(() => {
        const loadWaterIntake = async () => {
            try {
                const savedWaterIntake = await AsyncStorage.getItem('waterIntake');
                if (savedWaterIntake) {
                    setWaterIntake(parseInt(savedWaterIntake, 10));
                }
            } catch (error) {
                console.error('Ошибка загрузки данных: ', error);
            }
        };
        loadWaterIntake();
    }, []);

    useEffect(() => {
        const saveWaterIntake = async () => {
            try {
                await AsyncStorage.setItem('waterIntake', waterIntake.toString());
            } catch (error) {
                console.error('Ошибка сохранения данных: ', error);
            }
        };
        saveWaterIntake();
    }, [waterIntake]);

    const handleAddWater = () => {
        const numericInputValue = parseInt(inputValue) || 0;
        setWaterIntake(Math.min(waterIntake + numericInputValue, dailyIntake));
    };

    const handleInputChange = (text: string) => {
        let numericValue = parseInt(text.replace(/[^0-9]/g, '')) || 0;
        if (numericValue > dailyIntake) {
            numericValue = dailyIntake;
        }
        setInputValue(numericValue.toString());
    };

    const handleIncreaseInput = () => {
        const currentValue = parseInt(inputValue) || 0;
        const newValue = Math.min(currentValue + 50, dailyIntake);
        setInputValue(newValue.toString());
    };

    const handleDecreaseInput = () => {
        const currentValue = parseInt(inputValue) || 0;
        const newValue = Math.max(currentValue - 50, 0);
        setInputValue(newValue.toString());
    };

    const handleClearWater = () => {
        setWaterIntake(0);
        AsyncStorage.removeItem('waterIntake');
        setInputValue('50');
    };

    return (
        <View style={styles.container}>
            <Text style={styles.title}>Водный баланс</Text>

            <View style={styles.waterBalanceContainer}>
                <Svg
                    width="100"
                    height="150"
                    viewBox="0 0 200 200"
                    style={styles.waterImage}
                >
                    <Path
                        d="M100,10 C140,60 170,110 170,150 C170,200 130,200 100,200 C70,200 30,200 30,150 C30,110 60,60 100,10 Z"
                        fill="#6554d7"
                    />
                </Svg>
                <TouchableOpacity onPress={handleClearWater} style={styles.clearButtonContainer}>
                    <Text style={styles.clearButton}>Сброс</Text>
                </TouchableOpacity>
            </View>

            <Progress.Bar
                progress={waterIntake / dailyIntake}
                width={200}
                height={10}
                color="#6554d7"
                style={styles.progressBar}
            />

            <Text style={styles.waterIntakeText}>{waterIntake} / {dailyIntake} мл</Text>

            <View style={styles.inputContainer}>
                <TouchableOpacity onPress={handleDecreaseInput} style={styles.circleButton}>
                    <Text style={styles.circleButtonText}>-</Text>
                </TouchableOpacity>

                <TextInput
                    style={styles.input}
                    keyboardType="numeric"
                    value={inputValue}
                    onChangeText={handleInputChange}
                />

                <TouchableOpacity onPress={handleIncreaseInput} style={styles.circleButton}>
                    <Text style={styles.circleButtonText}>+</Text>
                </TouchableOpacity>
            </View>

            <TouchableOpacity onPress={handleAddWater} style={styles.addButton}>
                <Text style={styles.buttonText}>добавить {inputValue} мл</Text>
            </TouchableOpacity>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        padding: 16,
        backgroundColor: '#fff',
        borderRadius: 10,
        marginBottom: 16,
        alignItems: 'center',
    },
    title: {
        fontSize: 18,
        fontWeight: "bold",
        marginBottom: 10,
        color: '#333',
    },
    waterBalanceContainer: {
        flexDirection: 'row',
        justifyContent: 'center',
        alignItems: 'center',
        marginBottom: 20,
    },
    waterImage: {
        justifyContent: 'center',
        alignItems: 'center',
    },
    clearButtonContainer: {
        backgroundColor: '#FF6347',
        padding: 10,
        borderRadius: 10,
        marginLeft: 20,
    },
    clearButton: {
        color: '#fff',
        fontSize: 16,
    },
    progressBar: {
        marginVertical: 20,
    },
    waterIntakeText: {
        fontSize: 24,
        color: '#333',
        marginBottom: 20,
    },
    inputContainer: {
        flexDirection: 'row',
        justifyContent: 'center',
        alignItems: 'center',
        marginBottom: 20,
    },
    input: {
        height: 40,
        width: 100,
        borderColor: '#6554d7',
        borderWidth: 1,
        borderRadius: 10,
        textAlign: 'center',
        fontSize: 18,
        marginHorizontal: 10,
        backgroundColor: '#fff',
    },
    circleButton: {
        width: 50,
        height: 50,
        backgroundColor: '#6554d7',
        borderRadius: 25,
        justifyContent: 'center',
        alignItems: 'center',
    },
    circleButtonText: {
        color: '#fff',
        fontSize: 24,
    },
    buttonText: {
        color: '#fff',
        fontSize: 16,
        textAlign: 'center',
    },
    addButton: {
        backgroundColor: '#6554d7',
        padding: 15,
        borderRadius: 10,
        alignItems: 'center',
        width: '100%',
    },
});
