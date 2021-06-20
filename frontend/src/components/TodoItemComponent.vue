<template>
	<div class="todoitemcomponent">
		<input
			class="todoItem"
			type="text"
			name="title"
			v-model="todoItem.title"
			v-on:keydown="unfocus"
			v-on:blur="saveTodoItem"
		/>
		<button v-on:click="deleteTodoItem" type="">Delete</button>
	</div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import { DELETE_TODO_ITEM, UPDATE_TODO_ITEM } from "../store/actions.type";

@Options({
	name: "TodoItemComponent",
	components: {},
	props: {
		todoItem: {},
	},
	methods: {
		unfocus: function (event: any): void {
			if (event.keyCode == 13) {
				event.target.blur();
			}
		},
		saveTodoItem: function (event: any): void {
			// delete this.todoItem.createdOn;
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
.todoItem:not(:focus) {
	border: none;
	background-color: rgb(240, 240, 240);
}
.todoItem:focus {
	border-bottom: 1px solid lightgray;
}
</style>
