<template>
	<div class="todoitemcomponent">
		<input
			class="todoItem"
			type="text"
			name="title"
			v-model="todoItem.title"
			v-on:keydown="unfocus"
		/>
	</div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import { TodoItem } from "../models/TodoItem";

@Options({
	name: "TodoItemComponent",
	components: {},
	props: {
		todoItem: TodoItem,
	},
	methods: {
		unfocus: function (event: any): void {
			if (event.keyCode == 13) {
				event.target.blur();
			}
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
}
</style>
