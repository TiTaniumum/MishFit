import { StyleSheet, Text, View, TouchableOpacity } from 'react-native'
import React from 'react'
import { useRouter } from 'expo-router';

export default function TabComponent() {
    const router = useRouter();
    const [isLogged, setLogged] = useState(false);

    useEffect(() => {
        const fetchUserId = async () => {
            try {
                // const userId = await AsyncStorage.getItem("userId");
                const userId = 1;
                if (userId == 1) {
                    setLogged(true);
                } else {
                    setLogged(false);
                }
            } catch (error) {
                console.error('Failed to fetch userId from AsyncStorage', error);
            }
        };

        fetchUserId();
    }, []);
    return (
        <View style={styles.tabContainer}>
            <TouchableOpacity onPress={ }>

            </TouchableOpacity>
        </View>
    )
}

const styles = StyleSheet.create({
    tabContainer: {
        gap: 30
    }
})