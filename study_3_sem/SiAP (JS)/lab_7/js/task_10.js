let rectangle = {
    width : 10,
    height : 7,

    get square() {
        return "Площадь прямоугольника: " + (this.height * this.width);
    },


    get widthRectangle() {
        return "Ширина текущего прямоугольника:" + this.width;
    },

    set widthRectangle(w) {
        this.width = w;
    },


    get heightRectangle() {
        return "Высота текущего прямоугольника:" + this.height;
    },

    set heightRectangle(h) {
        this.height = h;
    }
}

console.log(rectangle.widthRectangle);
console.log(rectangle.heightRectangle);
console.log(rectangle.square);

rectangle.widthRectangle = 5;
rectangle.heightRectangle = 8;
console.log(rectangle.widthRectangle);
console.log(rectangle.heightRectangle);
console.log(rectangle.square);