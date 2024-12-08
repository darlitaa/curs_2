function getReversedEnglishString(str){
    let result = "";
    for (i = str.length; i >= 0; i--){
        if (str[i] > "A" && str[i] < "z")
        result += str[i];
    }
    return result;
}

console.log(getReversedEnglishString("JavaScr53э? ipt"));