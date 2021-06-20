<template>
	<div class="todolist">
		<div v-if="todoList">
			<div>
				<button v-on:click="addTodoItem">Add todoitem</button>
				<input
					v-on:keyup.enter="addTodoItem"
					type="text"
					v-model="todoItemTitle"
				/>
			</div>
			<div>
				<TodoItemComponent
					v-for="todoItem in todoList"
					v-bind:key="todoItem.id"
					v-bind:todoItem="todoItem"
				/>
			</div>
		</div>
		<div v-else>Aan het laden</div>
	</div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import { TodoItem } from "../models/TodoItem";
import TodoItemComponent from "../components/TodoItemComponent.vue";
import { useStore } from "vuex";
import { GET_ALL_TODOITEMS, ADD_TODO_ITEM } from "../store/actions.type";

@Options({
	name: "TodoListView",
	components: {
		TodoItemComponent,
	},
	computed: {
		todoList() {
			return this.$store.getters.allTodoItems;
		},
	},
	methods: {
		addTodoItem: function (event: any): void {
			var todoItem = new TodoItem();
			todoItem.title = this.todoItemTitle;
			this.todoItemTitle = "";
			this.$store.dispatch(ADD_TODO_ITEM, todoItem).then(function (id: string) {
				todoItem.id = id;
			});
			this.todoList.unshift(todoItem);
		},
	},
	mounted() {
		var store = useStore();
		if (!store.state.allTodoItems) {
			store.dispatch(GET_ALL_TODOITEMS);
		}
	},
})
export default class TodoListView extends Vue {
	data() {
		return {
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
