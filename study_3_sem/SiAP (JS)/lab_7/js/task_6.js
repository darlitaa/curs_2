let item  = {
    prise: 20
}

console.log("Цена изначально: " + item.prise); 


item.prise = 40;
console.log("Цена при первом изменении: " + item.prise); 


Object.defineProperty(item, "prise", {
    writable: false,
    configurable: false
});

item.prise = 60;
console.log("Цена при втором изменении: " + item.prise); 

delete item.prise;
console.log("Цена при попытке удалить: " + item.prise); 