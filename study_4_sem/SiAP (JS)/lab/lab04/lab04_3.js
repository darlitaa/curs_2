var myPromise = function (delay) {
    return new Promise(function (resolve) {
        setTimeout(function () {
            var num = Math.floor(Math.random() * 100);
            resolve(num);
        }, delay);
    });
};
var generateRandNum = function (delay) {
    return myPromise(delay);
};
var delays = [2000, 2000, 2000];
Promise.all(delays.map(function (delay) { return generateRandNum(delay); }))
    .then(function (result) {
    console.log(result);
});
