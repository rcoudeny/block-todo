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
			<div class="todolist">
				<TodoItemComponent
					v-for="todoItem in todoList"
					v-bind:key="todoItem.id"
					v-bind:todoItem="todoItem"
					v-bind:isEditable="true"
				/>
			</div>
		</div>
		<div v-else>Aan het laden</div>
	</div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import { TodoItem } from "@/models/TodoItem";
import TodoItemComponent from "../components/TodoItemComponent.vue";
import { GET_ALL_TODOITEMS, ADD_TODO_ITEM } from "../store/actions.type";

@Options({
	name: "TodoListEditorView",
	components: {
		TodoItemComponent,
	},
	computed: {
		todoList(): Array<TodoItem> {
			return this.$store.getters.allTodoItems;
		},
	},
	methods: {
		addTodoItem: function (): void {
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
		if (!this.$store.getters.allTodoItems.length) {
			this.$store.dispatch(GET_ALL_TODOITEMS);
		}
	},
})
export default class TodoListEditorView extends Vue {
	data(): {
		todoItemTitle: string;
	} {
		return {
			todoItemTitle: "",
		};
	}
}
</script>

<style lang="less" scoped>
// input:not(:focus) {
// 	border: none;
// 	background-color: lightgray;
// }
.todolist {
	display: flex;
	flex-direction: column;
	align-items: center;
}
</style>
