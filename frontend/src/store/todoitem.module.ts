import { TodoItem } from "@/models/TodoItem";
import { TodoItemService } from "../api/api.service";
import {
    ADD_TODO_ITEM,
    GET_ALL_TODOITEMS,
    UPDATE_TODO_ITEM,
    DELETE_TODO_ITEM,
} from "./actions.type";

const state = {
    allTodoItems: Array<TodoItem>(),
};

const getters = {
    allTodoItems(state: any) {
        return state.allTodoItems;
    },
};

export const actions = {
    async [GET_ALL_TODOITEMS](context: any) {
        const { data } = await TodoItemService.get();
        context.commit(GET_ALL_TODOITEMS, data);
        return data;
    },
    async [ADD_TODO_ITEM](context: any, todoItem: TodoItem) {
        const { data } = await TodoItemService.post(todoItem);
        return data;
    },
    async [UPDATE_TODO_ITEM](context: any, todoItem: TodoItem) {
        const { data } = await TodoItemService.put(todoItem);

        return data;
    },
    async [DELETE_TODO_ITEM](context: any, id: string) {
        await TodoItemService.delete(id);
        context.commit(DELETE_TODO_ITEM, id);
    },
};

export const mutations = {
    [GET_ALL_TODOITEMS](state: any, allTodoItems: Array<TodoItem>) {
        state.allTodoItems = allTodoItems;
    },
    [DELETE_TODO_ITEM](state: any, id: string) {
        state.allTodoItems = state.allTodoItems.filter(function (todoItem: TodoItem) {
            return todoItem.id !== id;
        })
    }
};

export default {
    state,
    actions,
    getters,
    mutations,
};
