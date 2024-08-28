import React from 'react';
import { View, StyleSheet, TextStyle } from 'react-native';
import CircularProgress from 'react-native-circular-progress-indicator';

interface CircularProgressBarProps {
    value: number; // Значение прогресса
    radius?: number; // Радиус круга
    maxValue?: number; // Максимальное значение прогресса
    duration?: number; // Длительность анимации
    activeStrokeColor?: string; // Цвет активной части круга
    activeStrokeSecondaryColor?: string; // Вторичный цвет активной части (для градиента)
    inActiveStrokeColor?: string; // Цвет неактивной части круга
    inActiveStrokeOpacity?: number; // Прозрачность неактивной части
    activeStrokeWidth?: number; // Ширина активной части
    inActiveStrokeWidth?: number; // Ширина неактивной части
    progressValueColor?: string; // Цвет текста процента
    title?: string; // Текст заголовка внутри круга
    titleColor?: string; // Цвет заголовка
    showProgressValue?: boolean;
    titleStyle?: TextStyle; // Стиль заголовка
}

const CircularProgressBar: React.FC<CircularProgressBarProps> = ({
    value,
    radius = 100,
    maxValue = 100,
    duration = 2000,
    activeStrokeColor = '#3498db',
    activeStrokeSecondaryColor = '#1abc9c',
    inActiveStrokeColor = '#9b59b6',
    inActiveStrokeOpacity = 0.5,
    activeStrokeWidth = 20,
    inActiveStrokeWidth = 20,
    progressValueColor = '#ecf0f1',
    title = 'Progress',
    showProgressValue = false,
    titleColor = '#ecf0f1',
    titleStyle = {},
}) => {
    return (
        <View style={styles.container}>
            <CircularProgress
                value={value}
                radius={radius}
                duration={duration}
                progressValueColor={progressValueColor}
                maxValue={maxValue}
                title={title}
                titleColor={titleColor}
                titleStyle={titleStyle}
                activeStrokeColor={activeStrokeColor}
                activeStrokeSecondaryColor={activeStrokeSecondaryColor}
                inActiveStrokeColor={inActiveStrokeColor}
                inActiveStrokeOpacity={inActiveStrokeOpacity}
                activeStrokeWidth={activeStrokeWidth}
                inActiveStrokeWidth={inActiveStrokeWidth}
                showProgressValue={showProgressValue} 
            />
        </View>
    );
};

const styles = StyleSheet.create({
    container: {
    },
});

export default CircularProgressBar;
