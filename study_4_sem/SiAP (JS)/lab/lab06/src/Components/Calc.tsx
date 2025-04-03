import { create, all } from 'mathjs';
const math = create(all);

export default function Calc(
    expression: string, 
    history: string,
    setHistory: React.Dispatch<React.SetStateAction<string>>, 
    setResult: React.Dispatch<React.SetStateAction<number>>): void {
    try {
        var res: number = math.evaluate(expression);
        if (expression !== '' && !history.split("\n").includes(expression)) {
            setHistory(history + expression + " = "+ res +"\n");
        }
        if (res === Infinity || res === -Infinity) {
            alert("деление на ноль!");
        } else if (!Number.isNaN(res)) {
            setResult(res);
        }
        return;
    }
    catch {
        alert("ошибка ")
        return;
    }
}