let correctAnswer = ["марина", "марина федоровна", "кудлацкая марина федоровна"];
let isCorrect = false;

do {
    let userAnswer = prompt("Ввидите имя преподователя:", "");
    if (correctAnswer.includes(userAnswer.toLowerCase())){
        alert ("Данные введены верно");
        isCorrect = true;
    }
    else alert ("Данные введены НЕ верно");
}while (!isCorrect);