let a = 6;
var b = 5;

alert(window.a);
alert(window.b);

window.b = 7;
alert(b);

function someFunction() {
    return "hello js";
}
alert(window.someFunction());