import { useSelector, useDispatch } from 'react-redux';
import { increment, decrement, reset } from '../redux/actions';
import { CounterState } from '../redux/types';
import styles from '../Counter.module.css';

const Counter = () => {
  const dispatch = useDispatch();
  const count = useSelector((state: CounterState) => state.count);
  
  return (
    <div className={styles.counter}>
      <h1>{count}</h1>
      <div className={styles.buttonContainer}>
        <button onClick={() => dispatch(increment())}>+</button>
        <button onClick={() => dispatch(decrement())}>–</button>
        <button onClick={() => dispatch(reset())}>Reset</button>
      </div>
    </div>
  );
};

export default Counter;