var myPromise = new Promise(function (resolve, reject) {
    setTimeout(function () {
        var num = Math.floor(Math.random() * 100);
        resolve(num);
    }, 3000);
});
myPromise.then(function (result) { return console.log(result); });
