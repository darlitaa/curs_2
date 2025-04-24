export interface Todo {
    id: number;
    text: string;
    completed: boolean;
}

export interface TodoState {
    todos: Todo[];
    currentEditId: number | null;
    currentEditText: string;
}

export const ADD_TODO = 'ADD_TODO';
export const TOGGLE_TODO = 'TOGGLE_TODO';
export const EDIT_TODO = 'EDIT_TODO';
export const DELETE_TODO = 'DELETE_TODO';

export const SET_EDIT_ID = 'SET_EDIT_ID';
export const SET_EDIT_TEXT = 'SET_EDIT_TEXT';