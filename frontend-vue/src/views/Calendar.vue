<template>
	<div class="calendarView">
		<div class="calendar"></div>
		<div class="todolist">
			<TodoItemComponent
				v-for="todoItem in todoList"
				v-bind:key="todoItem.id"
				v-bind:todoItem="todoItem"
				v-bind:isEditable="false"
			/>
		</div>
	</div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import { GET_ALL_TODOITEMS } from "@/store/actions.type";
import TodoItemComponent from "../components/TodoItemComponent.vue";
import { TodoItem } from "@/models/TodoItem";

@Options({
	name: "Calendar",
	components: {
		TodoItemComponent,
	},
	computed: {
		todoList: function (): Array<TodoItem> {
			return this.$store.getters.allTodoItems.filter(function (todoItem: TodoItem) {
				return todoItem.startTime === null;
			});
		},
	},
	mounted() {
		if (!this.$store.getters.allTodoItems.length) {
			this.$store.dispatch(GET_ALL_TODOITEMS);
		}
	},
})
export default class Calendar extends Vue {}
</script>

<style lang="less" scoped>
.calendarView {
	display: flex;
	width: 100%;
	height: 100vh;
	flex-direction: row;
	.calendar {
		flex: 4;
		height: 100%;
		width: 100%;
		background-color: blue;
	}
	.todolist {
		flex: 1;
		height: 100%;
		width: 15rem;
		background-color: rgb(245, 245, 245);
	}
}
</style>
