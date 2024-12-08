function Book(t, a) {
    this.title = t;
    this.author = a;

    this.getTitle = () => "Название: " + this.title;
    this.getAuthor = () => "Автор: " + this.author;
}

let book1 = new Book("Ловец снов", "Стивен Кинг");
let book2 = new Book("Мертвая зона", "Стивен Кинг");

console.log(book1.getTitle());
console.log(book1.getAuthor());

console.log(book2.getTitle());
console.log(book2.getAuthor());