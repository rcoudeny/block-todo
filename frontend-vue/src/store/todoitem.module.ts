import { TodoItem } from "@/models/TodoItem";
import { TodoItemService } from "../api/api.service";
import {
  ADD_TODO_ITEM,
  GET_ALL_TODOITEMS,
  UPDATE_TODO_ITEM,
  DELETE_TODO_ITEM as DELETE_TODOITEM,
  GET_UNPLANNED_TODOITEMS,
} from "./actions.type";

const state = {
  allTodoItems: Array<TodoItem>(),
};

const getters = {
  allTodoItems(state: any): Array<TodoItem> {
    return state.allTodoItems;
  },
  unplannedTodoItems(state: any): Array<TodoItem> {
    return state.unplannedTodoItems;
  },
};

export const actions = {
  async [GET_ALL_TODOITEMS](context: any): Promise<Array<TodoItem>> {
    const { data } = await TodoItemService.get();
    context.commit(GET_ALL_TODOITEMS, data);
    return data;
  },
  async [ADD_TODO_ITEM](context: any, todoItem: TodoItem): Promise<TodoItem> {
    const { data } = await TodoItemService.post(todoItem);
    return data;
  },
  async [UPDATE_TODO_ITEM](
    context: any,
    todoItem: TodoItem
  ): Promise<TodoItem> {
    const { data } = await TodoItemService.put(todoItem);

    return data;
  },
  async [DELETE_TODOITEM](context: any, id: string) {
    await TodoItemService.delete(id);
    context.commit(DELETE_TODOITEM, id);
  },
  async [GET_UNPLANNED_TODOITEMS](context: any): Promise<Array<TodoItem>> {
    const { data } = await TodoItemService.getUnplanned();
    context.commit(GET_UNPLANNED_TODOITEMS, data);
    return data;
  },
};

export const mutations = {
  [GET_ALL_TODOITEMS](state: any, allTodoItems: Array<TodoItem>) {
    state.allTodoItems = allTodoItems;
  },
  [DELETE_TODOITEM](state: any, id: string) {
    state.allTodoItems = state.allTodoItems.filter(function (
      todoItem: TodoItem
    ) {
      return todoItem.id !== id;
    });
  },
  [GET_UNPLANNED_TODOITEMS](state: any, unplannedTodoItems: Array<TodoItem>) {
    state.unplannedTodoItems = unplannedTodoItems;
  },
};

export default {
  state,
  actions,
  getters,
  mutations,
};
