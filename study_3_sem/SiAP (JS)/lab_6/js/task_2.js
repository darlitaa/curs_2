let user = {
    name: "Dasha",
    age: 19
}

let admin = {
    admin: true,
    ...user
}

console.log(admin);