let array = ["Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"];
let number = parseInt(prompt ("Введите номер дня недели (1-7):", ""));

if (number > 0 && number < 8)
    alert(array[number - 1]);
else alert("некорректный ввод");