import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import Home from "../views/Home.vue";
import About from "../views/About.vue";
import TodoList from "../views/TodoList.vue";
import Calendar from "../views/Calendar.vue";

const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/about",
    name: "About",
    component: About
  },
  {
    path: "/todolist",
    name: "TodoList",
    component: TodoList
  },
  {
    path: "/calendar",
    name: "Calendar",
    component: Calendar
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
