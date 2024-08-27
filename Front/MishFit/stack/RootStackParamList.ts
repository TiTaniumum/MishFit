import { createStackNavigator } from '@react-navigation/stack';

export type RootStackParamList = {
    CheckUser: undefined;
    profile: undefined;  // Объявляем маршрут 'profile'
    register: undefined; // Объявляем маршрут 'register'
};

const Stack = createStackNavigator<RootStackParamList>();
