import { API_URL } from "./config";
import axios from "axios";
import { TodoItem } from "@/models/TodoItem";

const ApiService = {
    init() {
        axios.defaults.baseURL = API_URL;
    },

    // setHeader() {
    //     axios.defaults.headers.common[
    //         "Authorization"
    //     ] = `Bearer ${JwtService.getToken()}`;
    // },
    // isLoggedIn() {
    //     if (JwtService.getToken()) {
    //         return true;
    //     }
    //     return true;
    // },

    query(resource: any, params: any) {
        return axios.get(resource, params).catch((error) => {
            throw new Error(`[RWV] ApiService ${error}`);
        });
    },

    get(resource: any, id = "") {
        return axios.get(`${resource}/${id}`).catch((error) => {
            throw new Error(`[RWV] ApiService ${error}`);
        });
    },

    post(resource: any, params: any) {
        return axios.post(`${resource}`, params);
    },

    update(resource: any, guid: string, params: any) {
        return axios.put(`${resource}/${guid}`, params);
    },

    put(resource: any, params: any) {
        return axios.put(`${resource}`, params);
    },

    delete(resource: any) {
        return axios.delete(resource).catch((error) => {
            throw new Error(`[RWV] ApiService ${error}`);
        });
    },
};

export default ApiService;

export const TodoItemService = {
    get() {
        return ApiService.get("TodoItem");
    },
    post(todoItem: TodoItem) {
        return ApiService.post("TodoItem", todoItem);
    },
    put(todoItem: TodoItem) {
        return ApiService.put("TodoItem/" + todoItem.id, todoItem);
    },
    delete(id: string) {
        ApiService.delete("TodoItem/" + id);
    }
};
