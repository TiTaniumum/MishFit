import React, { useState } from 'react';
import { View, Text, StyleSheet, ScrollView, TouchableOpacity, TextInput } from 'react-native';
import Svg, { Path } from 'react-native-svg';
import * as Progress from 'react-native-progress';

export default function Trackers() {
    const [waterIntake, setWaterIntake] = useState<number>(0);
    const [inputValue, setInputValue] = useState<string>('200');
    const dailyIntake = 3000; // Суточная норма (мл)

    const handleAddWater = () => {
        const numericInputValue = parseInt(inputValue) || 0;
        setWaterIntake((prev) => Math.min(prev + numericInputValue, dailyIntake));
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
        const newValue = Math.min(currentValue + 200, dailyIntake);
        setInputValue(newValue.toString());
    };

    const handleDecreaseInput = () => {
        const currentValue = parseInt(inputValue) || 0;
        const newValue = Math.max(currentValue - 200, 0);
        setInputValue(newValue.toString());
    };

    const handleClearWater = () => {
        setWaterIntake(0);
        setInputValue('200');
    };

    return (
        <ScrollView style={styles.container}>
            <View style={styles.tabContainer}>
                <TouchableOpacity style={styles.tabActive}>
                    <Text style={styles.tabTextActive}>Водный баланс</Text>
                </TouchableOpacity>
                <TouchableOpacity style={styles.tab}>
                    <Text style={styles.tabText}>Калории</Text>
                </TouchableOpacity>
                <TouchableOpacity style={styles.tab}>
                    <Text style={styles.tabText}>Упражнения</Text>
                </TouchableOpacity>
                <TouchableOpacity style={styles.tab}>
                    <Text style={styles.tabText}>Сон</Text>
                </TouchableOpacity>
            </View>

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
                width={400}
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
        </ScrollView>
    );
}
const styles = StyleSheet.create({
    container: {
        flex: 1,
        padding: 16,
        backgroundColor: '#cfd9e3',
    },
    tabContainer: {
        flexDirection: 'row',
        marginBottom: 16,
        marginTop: 45,
    },
    tab: {
        flex: 1,
        padding: 12,
        alignItems: 'center',
        backgroundColor: '#fff',
        borderRadius: 10,
        marginRight: 5,
    },
    tabActive: {
        flex: 1,
        padding: 12,
        alignItems: 'center',
        backgroundColor: '#6554d7',
        borderRadius: 10,
        marginRight: 5,
    },
    tabText: {
        color: '#333',
        fontSize: 14,
    },
    progressBar: {
        marginVertical: 20,
    },
    tabTextActive: {
        color: '#fff',
        fontSize: 14,
    },
    waterBalanceContainer: {
        flexDirection: 'row',
        justifyContent: 'center',
        alignItems: 'center',
        marginBottom: 20,
        paddingLeft: 80,
    },
    waterImage: {
        justifyContent: 'center',
        alignItems: 'center',
    },
    clearButtonContainer: {
        backgroundColor: '#FF6347',
        padding: 10,
        borderRadius: 10,
        width: 80,
    },
    clearButton: {
        color: '#fff',
        fontSize: 16,
    },
    waterIntakeText: {
        fontSize: 24,
        color: '#333',
        marginBottom: 20,
        textAlign: 'center',
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
    },
});
