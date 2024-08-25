import React, { useState } from 'react';
import { View, Text, StyleSheet, ScrollView, TouchableOpacity, TextInput } from 'react-native';
import Svg, { Path } from 'react-native-svg';
import * as Progress from 'react-native-progress';
import WaterTracker from '@/components/WaterTracker';
import CalorieTracker from '@/components/CalorieTracker';
import ActivityTracker from '@/components/ActivityTracker';

export default function Trackers() {
    const [trackerSwitch, setTrackerSwitch] = useState(0);

    return (
        <ScrollView style={styles.container}>
            <View style={styles.tabContainer}>
                <TouchableOpacity onPress={()=>{setTrackerSwitch(0);}} style={trackerSwitch == 0 ? styles.tabActive : styles.tab}>
                    <Text style={trackerSwitch == 0 ? styles.tabTextActive : styles.tabText}>Водный баланс</Text>
                </TouchableOpacity>
                <TouchableOpacity onPress={()=>{setTrackerSwitch(1);}} style={trackerSwitch == 1 ? styles.tabActive : styles.tab}>
                    <Text style={trackerSwitch == 1 ? styles.tabTextActive : styles.tabText}>Калории</Text>
                </TouchableOpacity>
                <TouchableOpacity onPress={()=>{setTrackerSwitch(2);}} style={trackerSwitch == 2 ? styles.tabActive : styles.tab}>
                    <Text style={trackerSwitch == 2 ? styles.tabTextActive : styles.tabText}>Упражнения</Text>
                </TouchableOpacity>
                <TouchableOpacity onPress={()=>{setTrackerSwitch(3);}} style={trackerSwitch == 3 ? styles.tabActive : styles.tab}>
                    <Text style={trackerSwitch == 3 ? styles.tabTextActive : styles.tabText}>Сон</Text>
                </TouchableOpacity>
            </View>
            {trackerSwitch == 0 && (<WaterTracker/>)}
            {trackerSwitch == 1 && (<CalorieTracker/>)}
            {trackerSwitch == 2 && (<ActivityTracker/>)}
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
