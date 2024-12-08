function SumOfCubes (n){
    let sum = 0;
    for (i = 1; i <= n; ++i){
        sum += Math.pow(i, 3);
    }
    return sum;
}
console.log(SumOfCubes(3));