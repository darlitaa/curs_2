let arr2 = [1, 2, [3, 4, [5, 6, [7, 8, [9, 10]]]]];

let Sum = arr2.flat(Infinity).reduce((sum, current) => sum + current, 0);

console.log(Sum);