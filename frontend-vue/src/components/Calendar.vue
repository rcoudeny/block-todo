<template>
	<div class="calendarWrapper" v-on:drop="drop" v-on:dragover="allowDrop">
		<div class="navigationWrapper">
			<div></div>
			<button class="" v-on:click="prevWeek">&lt;</button>
			<button class="" v-on:click="nextWeek">&gt;</button>
			<div class="monthInfo" v-if="daysToShow.length > 0">
				{{ daysToShow[0].getDate() }}
				{{ getMonthString(daysToShow[0]) }} -
				{{ daysToShow[daysToShow.length - 1].getDate() }}
				{{ getMonthString(daysToShow[daysToShow.length - 1]) }}
			</div>
			<button v-on:click="resetToday">Vandaag</button>
			<div>
				<button v-on:click="zoomOut">-</button>
				<button v-on:click="zoomIn">+</button>
			</div>
		</div>
		<div class="daysToShowWrapper">
			<div class="dayWrapper" v-for="day in daysToShow" v-bind:key="day.getTime()">
				<div>{{ getDayString(day) }}</div>
				<div>{{ day.getDate() }}</div>
				<div class="hourWrapper" v-for="hour in hoursToShow" v-bind:key="hour">
					{{ hour }}
				</div>
			</div>
		</div>
	</div>
</template>

<script lang="ts">
import { TodoItem } from "@/models/TodoItem";
import { Options, Vue } from "vue-class-component";

@Options({
	name: "Calendar",
	components: {},
	mounted: function () {
		this.scrollWeek(0);
	},
	data() {
		return {
			daysToShow: [],
			referenceDay: new Date(),
			zoomLevel: 2,
		};
	},
	computed: {
		hoursToShow(): Array<number> {
			var from: number = 7;
			var to: number = 22;
			var hoursToShow: Array<number> = [];
			for (var i = from; i < to + 1; i++) {
				hoursToShow.push(i);
			}
			return hoursToShow;
		},
	},
	methods: {
		zoom: function (zoomLevel: number): void {
			if (!zoomLevel) zoomLevel = this.zoomLevel;
			if (zoomLevel < 1) {
				zoomLevel = 1;
			} else if (zoomLevel > 8) {
				zoomLevel = 8;
			}
			this.zoomLevel = zoomLevel;
			var elements: HTMLCollectionOf<Element> = document.getElementsByClassName(
				"hourWrapper"
			);
			for (var i = 0; i < elements.length; i++) {
				(elements[i] as HTMLElement).style.height = this.zoomLevel * 2 + "em";
			}
		},
		zoomIn: function (): void {
			this.zoom(this.zoomLevel + 1);
		},
		zoomOut: function (): void {
			this.zoom(this.zoomLevel - 1);
		},
		getMonthString: function (date: Date): string {
			return date.toDateString().substr(4, 3);
		},
		getDayString: function (date: Date): string {
			var days: Array<string> = [
				"Sunday",
				"Monday",
				"Tuesday",
				"Wednesday",
				"Thursday",
				"Friday",
				"Saturday",
			];
			return days[date.getDay()];
		},
		resetToday: function (): void {
			this.setReferenceDay(new Date());
		},
		nextWeek: function (): void {
			this.scrollWeek(1);
		},
		prevWeek: function (): void {
			this.scrollWeek(-1);
		},
		scrollWeek: function (skip: number): void {
			this.updateReferenceDay(
				new Date(this.referenceDay.getTime() + skip * 7 * 24 * 60 * 60 * 1000)
			);
		},
		drop: function (event: DragEvent): void {
			console.log(event);

			if (!event.dataTransfer) {
				return;
			}

			var id: string = event.dataTransfer.getData("text/plain");
			var target: HTMLElement = event.target as HTMLElement;
			var targetRect: DOMRect = target.getBoundingClientRect();

			var elementsInDom: HTMLCollectionOf<Element> = document.getElementsByClassName(
				"dayWrapper"
			);
			for (var i = 0; i < elementsInDom.length; i++) {
				if (elementsInDom[i] === target.closest(".dayWrapper")) {
					var todoItemStartTime: Date = new Date(this.daysToShow[i].getTime());
					todoItemStartTime.setHours(
						parseInt(
							(target.closest(".hourWrapper") as HTMLElement).innerText
						)
					);
					todoItemStartTime.setMinutes(
						this._calculateClosestMinute(
							((event.clientY - targetRect.top) / targetRect.height) * 60
						)
					);
					todoItemStartTime.setSeconds(0);
					console.log(todoItemStartTime);
					var todoItemToUpdate = this.$store.getters.allTodoItems.filter(
						function (todoItem: TodoItem) {
							console.log(todoItem);
							console.log(id);

							return todoItem.id === id;
						}
					);
					console.log(todoItemToUpdate);
					break;
				}
			}
		},
		_calculateClosestMinute: function (acMinute: number): number {
			var minuteAccuraty = 30;
			if ((acMinute % minuteAccuraty) / minuteAccuraty > 0.5) {
				acMinute = (Math.floor(acMinute / minuteAccuraty) + 1) * minuteAccuraty;
			} else {
				acMinute = Math.floor(acMinute / minuteAccuraty) * minuteAccuraty;
			}
			return acMinute;
		},
		allowDrop: function (event: Event): void {
			// console.log(event);
			event.preventDefault();
		},
		updateReferenceDay: function (date: Date) {
			var that = this;
			that.referenceDay = date;
			that.daysToShow = that.getWeek(that.referenceDay);
			setTimeout(function () {
				that.zoom();
			});
		},
		getWeek: function (date: Date): Array<Date> {
			var week: Array<Date> = new Array();
			// Starting Monday not Sunday
			var tmpDate = new Date(date.getTime());
			tmpDate.setDate(tmpDate.getDate() - tmpDate.getDay() + 1);
			for (var i = 0; i < 7; i++) {
				week.push(new Date(tmpDate));
				tmpDate.setDate(tmpDate.getDate() + 1);
			}
			return week;
		},
	},
})
export default class Calendar extends Vue {}
</script>

<style lang="less" scoped>
button:hover {
	cursor: pointer;
}
.navigationWrapper {
	display: flex;
	.monthInfo {
		width: 10em;
	}
}
.daysToShowWrapper {
	display: flex;
	flex-direction: row;
	justify-content: space-evenly;
	.dayWrapper {
		width: 100%;
		border: 1px solid black;
		border-right: none;
		&:last-child {
			border-right: 1px solid black;
		}
		.hourWrapper {
			text-align: left;
			border-top: 1px solid black;
		}
	}
}
</style>
