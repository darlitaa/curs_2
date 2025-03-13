var prom1 = new Promise(function (resolve) {
    resolve(21);
});
prom1
    .then(function (res) {
    console.log(res);
    return res * 2;
})
    .then(function (res) {
    console.log(res);
});
