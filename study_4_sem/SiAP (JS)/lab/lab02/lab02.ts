//task 1

interface person {
    id: number;
    name: string;
    group: number;
}

const array: person[] = [
    {id: 1, name: 'Vasya', group: 10}, 
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]

//task 2

interface CarsType {
    manufacturer?: string;
    model?: string;
}

let car: CarsType = {}; //объект создан!
car.manufacturer = "manufacturer";
car.model = 'model';

//task 3

interface ArrayCarsType {
    cars: CarsType[];
}

const car1: CarsType = {}; //объект создан!
car1.manufacturer = "manufacturer";
car1.model = 'model';

const car2: CarsType = {}; //объект создан!
car2.manufacturer = "manufacturer";
car2.model = 'model';

const arrayCars: Array<ArrayCarsType> = [{
    cars: [car1, car2]
}];

//task4

type MarkFilterType = 1|2|3|4|5|6|7|8|9|10;
type GroupFilterType = 1|2|3|4|5|6|7|8|9|10|11|12;
type DoneType = boolean;

type MarkType = {
    subject: string,
    mark: MarkFilterType, // может принимать значения от 1 до 10
    done: DoneType,
}
type StudentType = {
    id: number,
    name: string,
    group: GroupFilterType, // может принимать значения от 1 до 12
    marks: Array<MarkType>,
}

type GroupType = {
    students: Array<StudentType>,// массив студентов типа StudentType
    studentsFilter: (group: number) => Array<StudentType>, // фильтр по группе
    marksFilter: (mark: number) => Array<StudentType>, // фильтр по  оценке
    deleteStudent: (id: number) => void, // удалить студента по id из  исходного массива
    mark?: MarkFilterType,
    group?: GroupFilterType,
}

var group: GroupType = {
    students: [],
    
    studentsFilter(groupNumber) {
        return this.students.filter(student => student.group === groupNumber);
    },

    marksFilter(mark) {
        return this.students.filter(student => student.marks.some(m => m.mark === mark));
    },

    deleteStudent(id) {
        this.students = this.students.filter(student => student.id !== id);
    },
};


var student1: StudentType = {
    id: 1,
    name: "Дарья",
    group: 6,
    marks: [{
        subject: "математика",
        mark: 8,
        done: true,
    }]
};
var student2: StudentType = {
    id: 2,
    name: "Ольга",
    group: 6,
    marks: [{
        subject: "физика",
        mark: 9,
        done: true,
    }]
};
var student3: StudentType = {
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
console.log(group.marksFilter(9));
group.deleteStudent(1);
console.log(group.students);