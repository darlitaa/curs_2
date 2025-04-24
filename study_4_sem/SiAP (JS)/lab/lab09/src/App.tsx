import { Provider } from 'react-redux';
import { store } from './redux/store';
import Todolist from './components/Todolist';

const App = () => {
    return (
        <Provider store={store}>
            <div>
                <Todolist />
            </div>
        </Provider>
    );
};

export default App;