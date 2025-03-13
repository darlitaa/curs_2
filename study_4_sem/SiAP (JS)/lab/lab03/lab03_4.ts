function createInstance<T>(cls: new (...args: any[]) => T, ...args: any[]): T {
    return new cls(...args);
}

class Product {
    constructor(public name: string, public price: number) {}
}
class Car {
    constructor(public model: string, public year: number) {}
}

const product = createInstance(Product, "Телефон", 50000);
console.log(product);

const car = createInstance(Car, "Toyota", 2020);
console.log(car);