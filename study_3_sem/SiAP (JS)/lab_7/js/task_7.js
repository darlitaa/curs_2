let circle = {
    radius: 5,

    get square() {
        return "площадь круга: " + (Math.PI * this.radius * this.radius);
    },

    get changeRadius() {
        return "радиус круга: " + this.radius;
    },

    set changeRadius(value) {
        this.radius = value;
    }
};

console.log("радиус круга: " + circle.radius);
console.log(circle.square);

circle.changeRadius = 10;
console.log(circle.changeRadius);
console.log(circle.square);