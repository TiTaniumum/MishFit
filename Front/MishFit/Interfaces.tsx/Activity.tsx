import { ActivityType } from "./Tracker"
export default interface Activity {
    id: number,
    name: string,
    activityType: number,
    calories: number
}

export const activitiesMock : Activity[] = [
    {   
        id:0,
        name: "Бегит",
        activityType: ActivityType.Timespan,
        calories: 1,
    },
    {   
        id:1,
        name: "Пешим ходом",
        activityType: ActivityType.Timespan,
        calories: 1,
    },
    {   
        id:2,
        name: "Анжуманья",
        activityType: ActivityType.Countable,
        calories: 3,
    },
    {   
        id:3,
        name: "Пресак",
        activityType: ActivityType.Countable,
        calories: 4,
    },
]