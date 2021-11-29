<template>
	<div class="calendarView">
		<Calendar class="calendar" />
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
import TodoItemComponent from "@/components/TodoItemComponent.vue";
import Calendar from "@/components/Calendar.vue";
import { TodoItem } from "@/models/TodoItem";

@Options({
	name: "CalendarView",
	components: {
		TodoItemComponent,
		Calendar,
	},
	methods: {},
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
export default class CalendarView extends Vue {}
</script>

<style lang="less" scoped>
.calendarView {
	display: flex;
	width: 100%;
	flex-direction: row;
	.calendar {
		height: 100%;
		width: 75vw;
	}
	.todolist {
		flex: 1;
		height: 100%;
		width: 15rem;
		background-color: rgb(245, 245, 245);
	}
}
</style>
