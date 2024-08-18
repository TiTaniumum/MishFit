import React, { useState } from 'react';
import { View, Text, StyleSheet } from 'react-native';
import * as Progress from 'react-native-progress';
import { Button, Icon } from 'react-native-elements';

export default function WaterTracker() {
    const [waterIntake, setWaterIntake] = useState<number>(0); // выпито воды (мл)
    const dailyIntake = 3000; // cуточная норма (мл)

    const handLeAddWater = (amount: number) => {
        setWaterIntake((prev) => Math.min(prev + amount, dailyIntake));
    };

    const handleClearWater = () => {
        setWaterIntake(0);
    };

    return (
        <View style={styles.container}>
            <Text style={styles.title}>Водный баланс</Text>
            <Text style={styles.label}>Текущий объем: {waterIntake} / {dailyIntake} мл</Text>
            <Progress.Bar
                progress={waterIntake / dailyIntake}
                width={130}
                color="#6554d7"
                style={styles.progressBar}
            />
            <View style={styles.buttonsContainer}>
                <Button
                    title="CUP"
                    onPress={() => handLeAddWater(100)}
                    icon={
                        <Icon
                            name="cup"
                            type="material-community"
                            size={24}
                            color="white"
                            style={styles.icon}
                        />
                    }
                    buttonStyle={styles.button}
                    titleStyle={styles.buttonTitle}
                    containerStyle={styles.buttonContainer}
                />
                <Button
                    title="BOTTLE"
                    onPress={() => handLeAddWater(500)}
                    icon={
                        <Icon
                            name="bottle-soda"
                            type="material-community"
                            size={24}
                            color="white"
                            style={styles.icon}
                        />
                    }
                    buttonStyle={styles.button}
                    titleStyle={styles.buttonTitle}
                    containerStyle={styles.buttonContainer}
                />
            </View>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        padding: 16,
        backgroundColor: '#fff',
        borderRadius: 10,
        marginBottom: 16,
    },
    title: {
        fontSize: 18,
        fontWeight: "bold",
        marginBottom: 10,
        color: '#333',
        fontFamily: 'System',
    },
    label: {
        fontSize: 16,
        color: '#555',
        marginBottom: 10,
        fontFamily: 'System',
    },
    progressBar: {
        marginVertical: 20,
    },
    buttonsContainer: {
        flexDirection: 'row',
        justifyContent: 'space-between',
        marginBottom: 10,
    },
    button: {
        backgroundColor: '#6554d7', 
        borderRadius: 20,
        paddingHorizontal: 20,
    },
    buttonContainer: {
        flex: 1,
        marginHorizontal: 5,
    },
    buttonContainerSingle: {
        marginTop: 10,
        width: '100%',
    },
    buttonTitle: {
        fontSize: 16,
        marginLeft: 10,
    },
    icon: {
        marginRight: 10,
    },
});
