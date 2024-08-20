import Activity from "./Activity";
import Meal from "./Meal";

export default interface Tracker{
    id: number;
    userId: number;
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
    Calorie,
    Activity,
    Sleep,
}

export enum ActivityType{
    Countable,
    Timespan,
}

export const trackerMock: Tracker[] = [
    {
        id: 12,
        userId: 23,
        trackerType: TrackerType.Calorie,
        meal: {
            id: "123",
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
        userId: 23,
        trackerType: TrackerType.Calorie,
        meal: {
            id: "124",
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
        id: 12,
        userId: 23,
        trackerType: TrackerType.Calorie,
        meal: {
            id: "125",
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
    }
]