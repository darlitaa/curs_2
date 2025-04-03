import { useState } from 'react';
import ReactDOM from 'react-dom/client';

import Button from './Button';
import AddtSign from './AddtSign';
import Calc from './Calc';

const root = ReactDOM.createRoot(document.getElementById('root') as HTMLElement);
root.render(<Calculator></Calculator>);

document.addEventListener('keyup',(event:KeyboardEvent) => {
  let button:HTMLElement = document.getElementById(event.key) as HTMLElement;
  button?.click();
})

interface ControlsProps {
  expression: string,
  darkTheme: boolean,
  history: string,
  setInput: React.Dispatch<React.SetStateAction<string>>,
  setResult: React.Dispatch<React.SetStateAction<number>>,
  setHistory: React.Dispatch<React.SetStateAction<string>>,  
}

function Controls({ expression, darkTheme, history, setInput, setResult, setHistory }: ControlsProps) {
  return (
    <div id='controls'>
      <Button darkTheme={!darkTheme} keyName="1" name="1" callback={() => { setInput(expression + "1") }} />
      <Button darkTheme={!darkTheme} keyName="2" name="2" callback={() => { setInput(expression + "2") }} />
      <Button darkTheme={!darkTheme} keyName="3" name="3" callback={() => { setInput(expression + "3") }} />
      <Button darkTheme={!darkTheme} keyName="+" name="+" callback={() => { setInput(AddtSign(expression, "+")) }} />
      <Button darkTheme={!darkTheme} keyName="4" name="4" callback={() => { setInput(expression + "4") }} />
      <Button darkTheme={!darkTheme} keyName="5" name="5" callback={() => { setInput(expression + "5") }} />
      <Button darkTheme={!darkTheme} keyName="6" name="6" callback={() => { setInput(expression + "6") }} />
      <Button darkTheme={!darkTheme} keyName="-" name="-" callback={() => { setInput(AddtSign(expression, "-")) }} />
      <Button darkTheme={!darkTheme} keyName="7" name="7" callback={() => { setInput(expression + "7") }} />
      <Button darkTheme={!darkTheme} keyName="8" name="8" callback={() => { setInput(expression + "8") }} />
      <Button darkTheme={!darkTheme} keyName="9" name="9" callback={() => { setInput(expression + "9") }} />
      <Button darkTheme={!darkTheme} keyName="*" name="*" callback={() => { setInput(AddtSign(expression, "*")) }} />
      <Button darkTheme={!darkTheme} keyName="." name="." callback={() => { setInput(AddtSign(expression, ".")) }} />
      <Button darkTheme={!darkTheme} keyName="0" name="0" callback={() => { setInput(expression + "0") }} />
      <Button darkTheme={!darkTheme} keyName="Backspace" name="&larr;" callback={() => { setInput(expression.slice(0, expression.length - 1)) }} />
      <Button darkTheme={!darkTheme} keyName="/" name="/" callback={() => { setInput(AddtSign(expression, "/")) }} />
      <Button darkTheme={!darkTheme} keyName="c" name="C" callback={() => { setInput("") }} />
      <Button darkTheme={!darkTheme} keyName="Enter" name="=" callback={() => { Calc(expression, history, setHistory, setResult); }} />
    </div>
  );
}

export default function Calculator(){
  const [darkTheme, setTheme] = useState(false);
  const [result, setResult] = useState(0);
  const [expression, setInput] = useState("");
  const [history, setHistory] = useState("");
  
  return(
  <div id = 'calc' data-darkTheme = {darkTheme}>
    <Button darkTheme = {darkTheme} keyName = 't' name = 'сменить тему' callback={() => {setTheme(!darkTheme)}}></Button>
    Результат:
    <div id = 'blocks'>{result}</div>  
    Ввод примера:
    <div id = 'blocks'>{expression}</div>
    <Controls darkTheme = {darkTheme} history = {history} setHistory = {setHistory} setResult = {setResult} expression = {expression} setInput = {setInput}></Controls>
    История вычислений:
    <div id = 'history'>{history}</div>    
  </div>)
}