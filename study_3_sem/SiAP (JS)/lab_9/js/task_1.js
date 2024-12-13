//квадраты
let yellowSquare = {
    color: "yellow",
    getColor() {
        return this.color;
    }
}

function Square(size) {
    this.size = size
}

Square.prototype = Object.create(yellowSquare);

let largerSquare = new Square(500);
let smallerSquare = new Square(100);
smallerSquare.name = "маленький квадрат";
console.log(Object.getPrototypeOf(smallerSquare));
console.log(smallerSquare.name);


//круги
let middleCircle = {
    size: 300
}

function Circle(color) {
    this.color = color;
    this.GetColor = () => this.color;
}

Circle.prototype = Object.create(middleCircle);

let whiteCircle = new Circle("white");
let greenCircle = new Circle("green");
console.log(whiteCircle.size);


//треугольники
let middleTriangle = {
    size: 300,
}

function Triangle(n) {
    this.nlines = n;

    this.GetNLines = () => this.nlines;
}

Triangle.prototype = Object.create(middleTriangle);

let triangle1 = new Triangle(1);
let triangle3 = new Triangle(3);
console.log(triangle3.size);


console.log("Уникальные свойства: ");
console.log(smallerSquare.hasOwnProperty("name"));
console.log(greenCircle.GetColor());
console.log(triangle3.GetNLines());