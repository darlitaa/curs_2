let car = {
    make : "Toyota",
    model : "Camry",
    year : 2021
}

Object.defineProperties(car, {
    make : {
        writable : true,
        configurable : true,
    },
    model : {
        writable : true,
        configurable : true,
    },
    year : {
        writable : true,
        configurable : true,
    }
})

console.log(car);


delete car.year;
console.log(car);

car.year = 2020;
console.log(car);

Object.freeze(car);
console.log("действия с объектом когда свойства не изменяемые:");

car.year = 2023;
console.log(car);

delete car.year;
console.log(car);