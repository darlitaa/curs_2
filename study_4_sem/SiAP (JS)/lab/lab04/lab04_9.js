var promise = new Promise(function (res, rej) {
    res('Resolved promise - 1');
});
promise
    .then(function (res) {
    console.log(res);
    return res;
})
    .then(function (res1) {
    console.log('Resolved promise - 2');
});
