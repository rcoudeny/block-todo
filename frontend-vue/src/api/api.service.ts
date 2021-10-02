import { API_URL } from "./config";
import axios from "axios";
import { TodoItem } from "@/models/TodoItem";
import { AxiosResponse } from "axios";

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
  get(): Promise<AxiosResponse<Array<TodoItem>>> {
    return ApiService.get("TodoItem");
  },
  getUnplanned(): Promise<AxiosResponse<Array<TodoItem>>> {
    return ApiService.get("TodoItem/unplanned");
  },
  post(todoItem: TodoItem): Promise<AxiosResponse<TodoItem>> {
    return ApiService.post("TodoItem", todoItem);
  },
  put(todoItem: TodoItem): Promise<AxiosResponse<TodoItem>> {
    return ApiService.put("TodoItem/" + todoItem.id, todoItem);
  },
  delete(id: string) {
    ApiService.delete("TodoItem/" + id);
  },
};
