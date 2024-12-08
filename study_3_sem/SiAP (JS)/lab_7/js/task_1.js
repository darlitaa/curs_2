let person = {
    name : "Даша",
    age : 19,

    greet() {
        return "Привет " + this.name;
    },

    ageAfterYears(years) {
        return "Возраст: " + (this.age + years);
    }
};

console.log(person.greet());
console.log(person.ageAfterYears(5));