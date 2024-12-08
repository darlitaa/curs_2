let i = 2;
let a = ++i; // a = 3, i = 3 префиксный инкремент
let b = i++; // b = 3, i = 4 постфиксный инкремент
    
if (a == b) 
    console.log ("a равно b    " + "a: " + a + " b: " + b);
if (a > b) 
    console.log ("a больше b    " + "a: " + a + " b: " + b);
if (a < b) 
    console.log ("a меньше b    " + "a: " + a + " b: " + b);