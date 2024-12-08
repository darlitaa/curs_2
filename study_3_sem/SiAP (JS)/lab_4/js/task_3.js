function addGoods(goods, id, name, amount, price) {
    return goods.set(id, { name, amount, price });
}

function getGoodsAmount(goods) {
    return goods.size;
}

function getGoodsPrices(goods) {
    let overallPrice = 0;
    for (obj of goods.values()) {
        overallPrice += obj.price * obj.amount;
    }
    return overallPrice;
}

function deleteGoodsByID(goods, id) {
    if (goods.has(id)) {
        console.log(`Товар №${id} найден (по id). Удаляем`);
        return goods.delete(id);
    }

    else {
        console.log(`Товар ${id} не найден`);
    }
}

function deleteGoodsByName(goods, name) {
    for (let obj of goods) {
        if (obj[1].name == name) {
            console.log(`Товар "${obj[1].name}" найден (по названию). Удаляем`);
            goods.delete(obj[0]);
        }
    }
    return goods;
}

function changeGoodsAmount(goods, ...amount) {
    let i = 0;
    for (let obj of goods.values()) {
        obj.amount = amount[i++];
    }
}

function changeGoodsPrice(goods, id, price) {
    for (obj of goods.keys()) {
        if (obj == id) {
            console.log(`Товар №${id} найден. Изменяю цену товара`);
            goods.get(obj).price = price;
        }
    }
}

let goods = new Map();

addGoods(goods, 1, "Fridge", 5, 900);
addGoods(goods, 2, "Fridge", 3, 800)
addGoods(goods, 3, "Microwave", 12, 120)
addGoods(goods, 4, "Microwave", 10, 124)
addGoods(goods, 5, "WashingMachine", 5, 300)
console.log(goods)
console.log(`Текущее количество товаров: ${getGoodsAmount(goods)}. Их общая цена: ${getGoodsPrices(goods)}$`);

deleteGoodsByID(goods, 2);
console.log(goods)

deleteGoodsByName(goods, "Microwave");
console.log(goods)

changeGoodsAmount(goods, 1, 2);
console.log(goods)

changeGoodsPrice(goods, 5, 280);
console.log(goods)
console.log(`Текущее количество товаров: ${getGoodsAmount(goods)}. Их общая цена: ${getGoodsPrices(goods)}$`);

let map = mew