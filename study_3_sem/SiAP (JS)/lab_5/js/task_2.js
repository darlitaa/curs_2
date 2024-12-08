function getVolume(length) {
    return (width) => {
        return (height) => {
            return length * width * height;
        }
    }
}

const fixlenght = getVolume(10);

console.log(fixlenght(5)(7));
console.log(fixlenght(8)(6));
console.log(fixlenght(4)(7));