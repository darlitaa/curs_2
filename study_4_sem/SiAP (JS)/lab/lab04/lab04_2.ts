let myPromise = new Promise((resolve, reject) => {
    setTimeout(() => {
        let num = Math.floor(Math.random() * 100);
        resolve(num);
    }, 3000);
});

myPromise.then((result) => console.log(result));
