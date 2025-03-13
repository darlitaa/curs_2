var pr = new Promise(function (res, rej) {
    rej('ku');
});
pr
    .then(function () { return console.log(1); })
    .catch(function () { return console.log(2); })
    .catch(function () { return console.log(3); })
    .then(function () { return console.log(4); })
    .then(function () { return console.log(5); });
