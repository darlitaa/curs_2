let arr1 = [1, [1, 2, [3, 4]], [2, 4]]

let concatenation = arr1.flat().reduce((tempArr, current) => {
    return tempArr.concat(current)
}, []);

console.log(concatenation);