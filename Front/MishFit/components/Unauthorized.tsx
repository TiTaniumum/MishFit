import { StyleSheet, Text, View, TouchableOpacity } from 'react-native'
import React from 'react'

export default function Unauthorized() {
    return (
        <View style={styles.container}>
            <Text>Вы не авторизовались</Text>
            <TouchableOpacity>
                <Text>Войти</Text>
            </TouchableOpacity>
            <TouchableOpacity>
                <Text>Зарегаться</Text>
            </TouchableOpacity>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
    }
})