import { Provider } from 'react-redux';
import store from './redux/store';
import Counter from './components/Counter';

const App = () => {
  return (
    <Provider store={store}>
      <div>
        <Counter />
      </div>
    </Provider>
  );
};

export default App;