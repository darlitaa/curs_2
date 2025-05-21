import { useDispatch, useSelector } from 'react-redux';
import { addTodo, toggleTodo, editTodo, deleteTodo, setEditId, setEditText } from '../redux/reducer';
import { RootState } from '../redux/store';
import styles from './Todolist.module.css';

const Todolist = () => {
    const inputValue = useSelector((state: RootState) => state.todos.currentEditText);
    const editId = useSelector((state: RootState) => state.todos.currentEditId);
    const todos = useSelector((state: RootState) => state.todos.todos);

    const dispatch = useDispatch();

    const handleAddTodo = () => {
        if (inputValue.trim()) {
            dispatch(addTodo(inputValue));
            dispatch(setEditText(''));
        }
    };

    const handleEditTodo = (id: number) => {
        const todo = todos.find(todo => todo.id === id);
        if (todo) {
            dispatch(setEditText(todo.text));
            dispatch(setEditId(id));
        }
    };

    const handleUpdateTodo = () => {
        if (editId !== null && inputValue.trim()) {
            dispatch(editTodo({ id: editId, text: inputValue }));
            dispatch(setEditText(''));
            dispatch(setEditId(null));
        }
    };

    return (
        <div className={styles.container}>
            <h1>Список дел</h1>
            <div className={styles.inputContainer}>
                <input
                    value={inputValue}
                    onChange={(e) => dispatch(setEditText(e.target.value))}
                    placeholder="Напишите задачу"
                />
                <button onClick={editId !== null ? handleUpdateTodo : handleAddTodo}>
                    {editId ? 'Сохранить' : 'Добавить'}
                </button>
            </div>
            <ul>
                {todos.map(todo => (
                    <li key={todo.id} style={{ textDecoration: todo.completed ? 'line-through' : 'none' }}>
                        <input
                            type="checkbox"
                            checked={todo.completed}
                            onChange={() => dispatch(toggleTodo(todo.id))}
                        />
                        {todo.text}
                        <div>
                            <button className={styles.buttonUpdate} onClick={() => handleEditTodo(todo.id)}>Редактировать</button>
                            <button className={styles.buttonDelete} onClick={() => dispatch(deleteTodo(todo.id))}>Удалить</button>
                        </div>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default Todolist;