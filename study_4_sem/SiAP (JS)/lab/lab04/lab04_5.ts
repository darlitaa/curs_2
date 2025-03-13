let prom1 = new Promise((resolve) => {
    resolve(21);
});

prom1
    .then((res) => {
        console.log(res);
        return res * 2;
    })
    .then((res) => {
        console.log(res);
    })
