//task 1
function createPhoneNumber(arr) {
    return "(" + arr[0] + arr[1] + arr[2] + ")" + " " + arr[3] + arr[4] + arr[5] +
        "-" + arr[6] + arr[7] + arr[8] + arr[9];
}
console.log(createPhoneNumber([2, 3, 8, 3, 0, 4, 7, 1, 5, 6]));
//task 2
var Challenge = /** @class */ (function () {
    function Challenge() {
    }
    Challenge.solution = function (num) {
        if (num < 0) {
            return 0;
        }
        var sum = 0;
        for (var i = 1; i < num; i++) {
            if (i % 3 == 0 || i % 5 == 0) {
                sum += i;
            }
        }
        return sum;
    };
    return Challenge;
}());
console.log(Challenge.solution(10));
console.log(Challenge.solution(-5));
//task 3
function rotateArray(numbers, k) {
    for (var i = 0; i < k; i++) {
        var temp = numbers[numbers.length - 1];
        numbers.splice(numbers.length - 1, 1);
        numbers.splice(0, 0, temp);
    }
}
var array = [1, 2, 3, 4, 5, 6, 7];
rotateArray(array, 3);
console.log(array);
//task 4
function mergeArrays(arr1, arr2) {
    arr1 = arr1.concat(arr2);
    arr1.sort();
    return getArrayMedian(arr1);
}
function getArrayMedian(arr) {
    if (arr.length % 2 == 0) {
        return (arr[arr.length / 2] + arr[arr.length / 2 - 1]) / 2;
    }
    else {
        return arr[Math.floor(arr.length / 2)];
    }
}
console.log(mergeArrays([1, 3], [2]));
console.log(mergeArrays([1, 2], [3, 4]));
