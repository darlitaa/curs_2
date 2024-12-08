function arithmeticMeanOfTheArray (array) {
    let sum = 0;
    for(i = 0; i < array.length; i++){
        sum += (array[i]);
    }
    let mean = sum / array.length;
    return mean;
}

let numbers = [3, 6, 5, 2, 4];
console.log(arithmeticMeanOfTheArray(numbers));