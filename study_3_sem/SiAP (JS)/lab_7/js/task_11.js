let user = {
    firstName: "Дарья",
    lastName: "Литвинчук",

    get fullName() {
        return "полное имя: " + this.firstName + " " + this.lastName;
    },

    set fullName(value) {
        return [this.firstName, this.lastName] = value.split(" ");
    },
}

console.log(user.fullName);
user.fullName = "Ольга Лускина";
console.log(user.fullName);