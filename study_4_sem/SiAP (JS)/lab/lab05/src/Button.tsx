import React from 'react';

interface ButtonProps {
  title: string;
  callback: () => void;
  disabled?: boolean;
}

export default function Button({ title, callback, disabled }: ButtonProps): React.ReactElement {
  return (
    <button onClick={callback} disabled={disabled}>
      {title}
    </button>
  );
}
