let numbers = [2, 3, 4];

Object.defineProperty(numbers, "sum", {
    get: function() {
        let sum = 0;

        this.forEach(elem => sum += elem )
        return sum;
    },
    configurable : false,
})

console.log("сумма чисел: " + numbers.sum);