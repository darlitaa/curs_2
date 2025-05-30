import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface Todo {
    id: number;
    text: string;
    completed: boolean;
}

interface TodoState {
    todos: Todo[];
    currentEditId: number | null;
    currentEditText: string;
}

const initialState: TodoState = {
    todos: [],
    currentEditId: null,
    currentEditText: '',
};

const todoSlice = createSlice({
    name: 'todos',
    initialState,
    reducers: {
        addTodo: (state, action: PayloadAction<string>) => {
            const newTodo: Todo = {
                id: Date.now(),
                text: action.payload,
                completed: false,
            };
            state.todos.push(newTodo);
        },
        toggleTodo: (state, action: PayloadAction<number>) => {
            const todo = state.todos.find(todo => todo.id === action.payload);
            if (todo) {
                todo.completed = !todo.completed;
            }
        },
        editTodo: (state, action: PayloadAction<{ id: number; text: string }>) => {
            const todo = state.todos.find(todo => todo.id === action.payload.id);
            if (todo) {
                todo.text = action.payload.text;
            }
        },
        deleteTodo: (state, action: PayloadAction<number>) => {
            state.todos = state.todos.filter(todo => todo.id !== action.payload);
        },
        setEditId: (state, action: PayloadAction<number | null>) => {
            state.currentEditId = action.payload;
        },
        setEditText: (state, action: PayloadAction<string>) => {
            state.currentEditText = action.payload;
        },
    },
});

export const {
    addTodo,
    toggleTodo,
    editTodo,
    deleteTodo,
    setEditId,
    setEditText,
} = todoSlice.actions;

export default todoSlice.reducer;