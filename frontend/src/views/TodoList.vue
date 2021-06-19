<template>
	<div class="todolist">
		<div>
			<button v-on:click="addTodoItem">Add todoitem</button>
			<input v-on:keyup.enter="addTodoItem" type="text" v-model="todoItemTitle" />
		</div>
		<div>
			<TodoItemComponent
				v-for="todoItem in todoList"
				v-bind:key="todoItem.id"
				v-bind:todoItem="todoItem"
			/>
		</div>
	</div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import { TodoItem } from "../models/TodoItem";
import TodoItemComponent from "../components/TodoItemComponent.vue";

@Options({
	name: "TodoListView",
	components: {
		TodoItemComponent,
	},
	// computed: {
	// 	todoItemTitle: {
	// 		get() {
	// 			this.todoItemTitle;
	// 		},
	// 		set(newValue) {
	// 			this.todoItemTitle = newValue;
	// 		},
	// 	},
	// },
	methods: {
		addTodoItem: function (event: any): void {
			var todoItem = new TodoItem();
			todoItem.$title = this.todoItemTitle;
			todoItem.$id = this.count;
			this.todoItemTitle = "";
			this.todoList.unshift(todoItem);
			this.count++;
		},
	},
})
export default class TodoListView extends Vue {
	data() {
		return {
			todoList: Array<TodoItem>(),
			todoItemTitle: "",
			count: 0,
		};
	}
}
</script>

<style lang="less" scoped>
// input:not(:focus) {
// 	border: none;
// 	background-color: lightgray;
// }
</style>
