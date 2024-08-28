import React, { useState } from 'react';
import { TextInput, StyleSheet, View, Text, ScrollView } from 'react-native';
import { Colors } from '@/constants/Colors';

interface InputFieldProps {
    label: string;
    placeholder: string;
    value: string;
    onChangeText: (text: string) => void;
}

const InputField: React.FC<InputFieldProps> = ({ label, placeholder, value, onChangeText }) => {
    const [isFocused, setIsFocused] = useState(false);

    return (
        <View style={styles.container}>
            <Text style={styles.label}>{label}</Text>
            <TextInput
                style={[styles.input, isFocused && styles.inputFocused]}
                placeholder={placeholder}
                value={value}
                onChangeText={onChangeText}
                onFocus={() => setIsFocused(true)}
                onBlur={() => setIsFocused(false)}
            />
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
        marginBottom: 16,
    },
    label: {
        marginBottom: 8,
        fontSize: 14,
        color: Colors.secondary,
        fontWeight: '700',
    },
    input: {
        borderColor: '#ccc',
        borderWidth: 1,
        paddingHorizontal: 16,
        borderRadius: 12,
        fontSize: 14,
        paddingVertical: 14,
    },
    inputFocused: {
        borderColor: Colors.primary,
    },
});

export default InputField;
