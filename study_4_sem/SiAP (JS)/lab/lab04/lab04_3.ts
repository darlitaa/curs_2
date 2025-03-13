let myPromise = (delay: number): Promise<number> => {
  return new Promise((resolve) => {
    setTimeout(() => {
      let num = Math.floor(Math.random() * 100);
      resolve(num);
    }, delay);
  });
}

let generateRandNum = (delay: number): Promise<number> => {
  return myPromise(delay);
}

let delays: number[] = [2000, 2000, 2000];

Promise.all(delays.map(delay => generateRandNum(delay)))
  .then((result) => {
    console.log(result);
  })
