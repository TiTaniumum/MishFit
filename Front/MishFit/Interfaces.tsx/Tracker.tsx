import Activity from "./Activity";
import Meal from "./Meal";

export default interface Tracker{
    id: number;
    trackerType: TrackerType;
    meal: Meal | null;
    mealGramms: number | null;
    activity: Activity | null;
    activityType: ActivityType | null;
    activityTimespan: number | null;
    activitySets: number | null;
    activityRepititions: number | null;
    sleepDateTime: Date | null;
    sleepEnd: Date | null;
    sleepQuality: number | null;
    trackerDateTime: Date;
    deleteDateTime: Date | null;
}

export enum TrackerType{
    // Илья попросил заменить на 1
    Calorie = 1,
    Activity,
    Sleep,
}

export enum ActivityType{
    // Илья попросил заменить на 1
    Countable = 1, 
    Timespan,
}

export const trackerMock: Tracker[] = [
    {
        id: 12,
        trackerType: TrackerType.Calorie,
        meal: {
            id: 123,
            name: "Pizza",
            calories: 123,
        },
        mealGramms: 300,
        activity: null,
        activityType: null,
        activityTimespan: null,
        activitySets: null,
        activityRepititions: null,
        sleepDateTime: null,
        sleepEnd: null,
        sleepQuality: null,
        trackerDateTime: new Date("2024-08-17T12:24:00"),
        deleteDateTime: null,
    },
    {
        id: 13,
        trackerType: TrackerType.Calorie,
        meal: {
            id: 124,
            name: "Macaron",
            calories: 123,
        },
        mealGramms: 200,
        activity: null,
        activityType: null,
        activityTimespan: null,
        activitySets: null,
        activityRepititions: null,
        sleepDateTime: null,
        sleepEnd: null,
        sleepQuality: null,
        trackerDateTime: new Date("2024-08-17T12:35:00"),
        deleteDateTime: null,
    },
    {
        id: 14,
        trackerType: TrackerType.Calorie,
        meal: {
            id: 125,
            name: "Spaget",
            calories: 123,
        },
        mealGramms: 300,
        activity: null,
        activityType: null,
        activityTimespan: null,
        activitySets: null,
        activityRepititions: null,
        sleepDateTime: null,
        sleepEnd: null,
        sleepQuality: null,
        trackerDateTime: new Date("2024-08-18T15:45:00"),
        deleteDateTime: null,
    },
    {
        id: 15,
        trackerType: TrackerType.Activity,
        meal: null,
        mealGramms: 300,
        activity: {
            id: 1,
            name: "Бегит",
            activityType: ActivityType.Timespan,
            calories: 123
        },
        activityType: ActivityType.Timespan,
        activityTimespan: 20,
        activitySets: null,
        activityRepititions: null,
        sleepDateTime: null,
        sleepEnd: null,
        sleepQuality: null,
        trackerDateTime: new Date("2024-08-17T12:24:00"),
        deleteDateTime: null,
    },
    {
        id: 16,
        trackerType: TrackerType.Activity,
        meal: null,
        mealGramms: 200,
        activity: {
            id: 2,
            name: "Анжуманя",
            activityType: ActivityType.Countable,
            calories: 10
        },
        activityType: ActivityType.Countable,
        activityTimespan: null,
        activitySets: 5,
        activityRepititions: 10,
        sleepDateTime: null,
        sleepEnd: null,
        sleepQuality: null,
        trackerDateTime: new Date("2024-08-17T12:35:00"),
        deleteDateTime: null,
    },
    {
        id: 17,
        trackerType: TrackerType.Activity,
        meal: null,
        mealGramms: 300,
        activity: {
            id: 3,
            name: "Турник",
            activityType: ActivityType.Countable,
            calories: 200
        },
        activityType: ActivityType.Countable,
        activityTimespan: null,
        activitySets: 3,
        activityRepititions: 5,
        sleepDateTime: null,
        sleepEnd: null,
        sleepQuality: null,
        trackerDateTime: new Date("2024-08-18T15:45:00"),
        deleteDateTime: null,
    }
]