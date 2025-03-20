import React, { useState } from 'react';
import Button from './Button';

export default function Counter(): React.ReactElement {
  const [count, setCount] = useState<number>(0);

  const handleIncrease = () => {
    setCount((prevCount) => prevCount + 1);
  };

  const handleReset = () => {
    setCount(0);
  };

  return (
    <div className="counter">
      <h1>{count}</h1>
      <Button
        title="increase"
        callback={handleIncrease}
        disabled={count >= 5}
      />
      <Button
        title="reset"
        callback={handleReset}
        disabled={count === 0}
      />
    </div>
  );
}
