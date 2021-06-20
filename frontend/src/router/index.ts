import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import Home from "../views/Home.vue";
import About from "../views/About.vue";
import TodoListView from "../views/TodoListView.vue";
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
    component: TodoListView
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
