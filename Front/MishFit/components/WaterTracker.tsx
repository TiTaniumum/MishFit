import React, {useState, useEffect} from 'react';
import {View, Text, StyleSheet,TextInput, Button} from 'react-native';
import * as Progress from 'react-native-progress'



export default function WaterTracker() {
    const[waterIntake, setWaterIntake] = useState<number>(0) // выпито воды (мл)
    const dailyIntake = 2000; // cуточная норма (мл)
    

    const handLeAddWater = (amount: number) => {
        setWaterIntake((prev) =>  Math.min(prev+amount, dailyIntake))
    }

    const handleDeleteWater = (amount: number) => {
        setWaterIntake((prev) => Math.max(prev-amount, 0))
    }

    return(
        <View style={styles.container}>
            <Text style={styles.title}>Водный баланс</Text>
            <Text style={styles.label}>Текущий объем : {waterIntake}/{dailyIntake}</Text>
            <Progress.Bar
                progress={waterIntake/dailyIntake}
                width={130}
                color="#6554d7"
                style={styles.progressBar}
            />
            <View style={styles.container}>
                <Button title="+100 (мл)" onPress={() => handLeAddWater(100)}/>
                <Button title="+250 (мл)" onPress={() => handLeAddWater(250)}/>
                <Button title="-100 (мл)" onPress={() => handleDeleteWater(100)}/>
                <Button title="-250 (мл)" onPress={() => handleDeleteWater(250)}/>
            </View>
        </View>
    )
}


const styles = StyleSheet.create({
    container: {
        padding:16,
        backgroundColor:'#fff',
        borderRadius:10,
        marginBottom:16,
    },
    title: {
        fontSize: 18,
        fontWeight:"bold",
        marginBottom: 10,
        color:'#333',
        fontFamily: 'System'
    },
    label: {
        fontSize: 16,
        color: '#555',
        marginBottom:10,
        fontFamily:'System'
    },
    progressBar: {
        marginVertical: 20,
    },
    buttonsContainer: {
        flexDirection: 'row',
        justifyContent: 'space-between'
    }
})
