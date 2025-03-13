var promise = new Promise(function (res, rej) {
    res('Resolved promise - 1');
});
promise
    .then(function (res) {
    console.log("Resolved promise - 2");
    return "OK";
})
    .then(function (res) {
    console.log(res);
});
