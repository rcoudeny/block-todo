<template>
	<div v-if="isEditable" class="todoItemComponent editMode">
		<div class="container">
			<input
				class="todoItemTitle"
				type="text"
				name="title"
				v-model="todoItem.title"
				v-on:keydown="unfocus"
				v-on:blur="saveTodoItem"
			/>
			<textarea
				class="todoItemDescription"
				name="title"
				v-model="todoItem.description"
				v-on:blur="saveTodoItem"
			/>
		</div>

		<div class="deleteButton">
			<svg
				v-on:click="deleteTodoItem"
				style="width: 100%; heigth: 100%"
				fill="currentColor"
				viewBox="0 0 20 20"
				xmlns="http://www.w3.org/2000/svg"
			>
				<path
					fill-rule="evenodd"
					style="color: black"
					d="M9 2a1 1 0 00-.894.553L7.382 4H4a1 1 0 000 2v10a2 2 0 002 2h8a2 2 0 002-2V6a1 1 0 100-2h-3.382l-.724-1.447A1 1 0 0011 2H9zM7 8a1 1 0 012 0v6a1 1 0 11-2 0V8zm5-1a1 1 0 00-1 1v6a1 1 0 102 0V8a1 1 0 00-1-1z"
					clip-rule="evenodd"
				></path>
			</svg>
		</div>
	</div>
	<div v-else class="todoItemComponent viewMode container">
		<h3>{{ todoItem.title }}</h3>
		<p>{{ todoItem.description }}</p>
	</div>
</template>

<script lang="ts">
import { TodoItem } from "@/models/TodoItem";
import { Options, Vue } from "vue-class-component";
import { DELETE_TODO_ITEM, UPDATE_TODO_ITEM } from "../store/actions.type";

@Options({
	name: "TodoItemComponent",
	components: {},
	props: {
		todoItem: TodoItem,
		isEditable: Boolean,
	},
	methods: {
		unfocus: function (event: KeyboardEvent): void {
			if (event && event.target && event.key === "Enter") {
				(event.target as HTMLInputElement).blur();
			}
		},
		saveTodoItem: function (): void {
			this.$store.dispatch(UPDATE_TODO_ITEM, this.todoItem);
		},
		deleteTodoItem: function (): void {
			this.$store.dispatch(DELETE_TODO_ITEM, this.todoItem.id);
		},
	},
})
export default class TodoItemComponent extends Vue {}
</script>

<style lang="less" scoped>
.todoItemComponent {
	position: relative;
	width: 100%;
	margin: 0.6rem;
	text-align: left;
	background-color: var(--periwinkle-crayola);
}
.editMode .container {
	width: 100%;
	height: 100%;
	display: flex;
	flex-direction: column;
	.todoItemTitle {
		height: 2rem;
		width: calc(100% - 2rem);
		display: block;
		font-size: 1.17em;
		margin-inline-start: 0px;
		margin-inline-end: 0px;
		font-weight: bold;
	}
	.todoItemDescription {
		height: 10rem;
		overflow: auto;
		// width: 100%;
		font-weight: inherit;
		font-family: inherit;
		overflow-y: scroll;
		resize: none;
	}
}
.deleteButton {
	position: absolute;
	top: 0.6rem;
	right: 0.6rem;
	cursor: pointer;
	width: 1rem;
	height: 1rem;
}
input,
textarea {
	text-align: left;
	border: none;
	background-color: transparent;
	&:not(:focus) {
		border: none;
	}
	&:focus,
	&:focus-visible {
		outline: none;
	}
}
</style>
