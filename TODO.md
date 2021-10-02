- login
- todo object
  - title
  - description
  - estimated duration (if null, drag and drop on calendar will default to 30 minutes)
  - start time (If null, it's not planned yet)
  - subtodos (start with just text, later can add plannable todo objects)
- Calendar
  - TodoItemComponent moet een non editable versie hebben
  - inplannen gebeurt via panel rechts met todos, en links calendar


1. Use store
   1. Implement add method
   2. Implement getAll method
   3. Implement update method
   4. Implement delete method
2. Improve layout TodoListView while implementing above store
3. Calendar layout
   1. Add non editable TodoItemComponent
   2. Make calendar
   3. Make todo list draggable
   4. Make calendar droppable
   5. Add TodoItems to calendar based on startTime and duration
