//task 1
var array = [
    { id: 1, name: 'Vasya', group: 10 },
    { id: 2, name: 'Ivan', group: 11 },
    { id: 3, name: 'Masha', group: 12 },
    { id: 4, name: 'Petya', group: 10 },
    { id: 5, name: 'Kira', group: 11 },
];
var car = {}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';
var car1 = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';
var car2 = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';
var arrayCars = [{
        cars: [car1, car2]
    }];
var group = {
    students: [],
    studentsFilter: function (groupNumber) {
        return this.students.filter(function (student) { return student.group === groupNumber; });
    },
    marksFilter: function (mark) {
        return this.students.filter(function (student) { return student.marks.some(function (m) { return m.mark === mark; }); });
    },
    deleteStudent: function (id) {
        this.students = this.students.filter(function (student) { return student.id !== id; });
    },
};
var student1 = {
    id: 1,
    name: "Дарья",
    group: 6,
    marks: [{
            subject: "математика",
            mark: 8,
            done: true,
        }]
};
var student2 = {
    id: 2,
    name: "Ольга",
    group: 6,
    marks: [{
            subject: "физика",
            mark: 9,
            done: true,
        }]
};
var student3 = {
    id: 3,
    name: "Игорь",
    group: 7,
    marks: [{
            subject: "физика",
            mark: 8,
            done: true,
        }]
};
group.students.push(student1, student2, student3);
console.log(group.studentsFilter(6));
console.log(group.marksFilter(8));
group.deleteStudent(1);
console.log(group.students);
