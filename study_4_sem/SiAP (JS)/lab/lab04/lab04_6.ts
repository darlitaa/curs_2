let prom2 = () => Promise.resolve(21);

let runAsync = async () => {
    const result = await prom2();
    console.log(result); 
    console.log(result * 2); 
};

runAsync();
