export default interface Meal {
    id: number,
    name: string,
    calories: number
}

export const mealsMock: Meal[] = [
    {
        id: 0,
        name: "Пицца маргарита",
        calories: 50
    },
    {
        id: 1,
        name: "Борщь",
        calories: 30
    },
    {
        id: 2,
        name: "Хинкали",
        calories: 20
    }
]