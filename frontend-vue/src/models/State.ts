import { TodoItem } from "./TodoItem";

export const state = {
    allTodoItems: [] as TodoItem[],
    unplannedTodoItems: [] as TodoItem[],
}

export type State = typeof state