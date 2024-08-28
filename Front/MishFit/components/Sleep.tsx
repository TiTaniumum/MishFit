import React, { useState } from 'react';
import { ScrollView, StyleSheet, Text, View, TouchableOpacity } from 'react-native';
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css'; // Импорт стилей для DatePicker
import CircularProgressBar from './CircularProgressBar';
import { Colors } from '@/constants/Colors';

export default function Sleep() {
    const [date, setDate] = useState<Date | null>(new Date());

    const handleDateChange = (date: Date | null) => {
        setDate(date);
    };

    return (
        <ScrollView>
            <View style={styles.container}>
                <TouchableOpacity>
                    <Text style={styles.dateText}>
                        {date ? date.toLocaleString() : 'Выберите дату и время'}
                    </Text>
                </TouchableOpacity>
                {/* Тут еще не все */}
                <DatePicker
                    selected={date}
                    onChange={handleDateChange}
                    showTimeSelect
                    dateFormat="Pp"
                    className="react-datepicker"
                />
            </View>

            <ScrollView style={styles.sleepStatistic}>
                <CircularProgressBar
                    value={90}
                    radius={45}
                    activeStrokeColor={Colors.primary}
                    activeStrokeSecondaryColor={Colors.primary}
                    inActiveStrokeColor={Colors.white}
                    title='7ч'
                />
            </ScrollView>
        </ScrollView>
    );
}

const styles = StyleSheet.create({
    container: {
        alignItems: 'center',
        marginVertical: 20,
    },
    dateText: {
        fontSize: 18,
        color: Colors.primary,
    },
    sleepStatistic: {
        gap: 10,
        width: '100%',
        padding: 20,
        borderRadius: 20,
        backgroundColor: Colors.secondary,
    },
});
