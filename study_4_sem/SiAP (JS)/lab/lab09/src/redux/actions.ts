import { ADD_TODO, TOGGLE_TODO, EDIT_TODO, DELETE_TODO, SET_EDIT_ID, SET_EDIT_TEXT, Todo } from './types';

let nextTodoId = 1;

export const addTodo = (text: string) => ({
    type: ADD_TODO,
    payload: { id: nextTodoId++, text, completed: false } as Todo,
});

export const toggleTodo = (id: number) => ({
    type: TOGGLE_TODO,
    payload: id,
});

export const editTodo = (id: number, text: string) => ({
    type: EDIT_TODO,
    payload: { id, text },
});

export const deleteTodo = (id: number) => ({
    type: DELETE_TODO,
    payload: id,
});

export const setEditId = (id: number | null) => ({
    type: SET_EDIT_ID,
    payload: id,
});

export const setEditText = (text: string) => ({
    type: SET_EDIT_TEXT,
    payload: text,
});