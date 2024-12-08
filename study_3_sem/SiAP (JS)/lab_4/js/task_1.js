function addItem(set, item){
    console.log(`добавляем элемент ${item}`);
    set.add(item);
}

function removeItem(set, item){
    if(set.has(item)){
        console.log(`удаляем элемент ${item}`);
        set.delete(item);
    }
    else console.log(`элемент ${item} не найден`);
}

function hasItem(set, item){
    if(set.has(item)){
        console.log(`элемент ${item} найден`);
    }
    else console.log(`элемент ${item} не найден`);
}

let fruits = ["apple", "banana", "kiwi"];
let set = new Set(fruits);

console.log(set);
addItem(set, "orange");
removeItem(set, "apple");
hasItem(set, "apple");
hasItem(set, "kiwi");
console.log(`количество элементов: ${set.size}`);
console.log(set);