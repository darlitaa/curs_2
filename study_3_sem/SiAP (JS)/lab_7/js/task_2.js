let car = {
    model: "mersedes",
    year: 2021,

    getInfo() {
        return "модель: " + this.model + "\n" + "год создания: " + this.year;
    }
}

console.log(car.getInfo());