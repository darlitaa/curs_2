function repeatingLines (n, s){
    let repead = "";
    for (i = 0; i < n; i++){
        for (j = 0; j < s.length; j++){
            repead += s[j];
        }
    }
    return repead;
}

console.log(repeatingLines(5, "meow.."))