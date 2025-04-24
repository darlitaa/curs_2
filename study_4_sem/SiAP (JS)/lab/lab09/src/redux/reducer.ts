import { ADD_TODO, TOGGLE_TODO, EDIT_TODO, DELETE_TODO, TodoState, SET_EDIT_ID, SET_EDIT_TEXT } from './types';

const initialState: TodoState = {
    todos: [],
    currentEditId: null,
    currentEditText: '',
};

export const todoReducer = (state = initialState, action: any): TodoState => {
    switch (action.type) {
        case ADD_TODO:
            return { ...state, todos: [...state.todos, action.payload] };
        case TOGGLE_TODO:
            return {
                ...state,
                todos: state.todos.map(todo =>
                    todo.id === action.payload ? { ...todo, completed: !todo.completed } : todo
                ),
            };
        case EDIT_TODO:
            return {
                ...state,
                todos: state.todos.map(todo =>
                    todo.id === action.payload.id ? { ...todo, text: action.payload.text } : todo
                ),
            };
        case DELETE_TODO:
            return {
                ...state,
                todos: state.todos.filter(todo => todo.id !== action.payload),
            };
        case SET_EDIT_ID:
            return { ...state, currentEditId: action.payload };
        case SET_EDIT_TEXT:
            return { ...state, currentEditText: action.payload };
        default:
            return state;
    }
};