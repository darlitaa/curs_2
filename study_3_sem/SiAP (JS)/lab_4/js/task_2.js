function addStudent(student){
    studentsList.add(student);
}

function removeStudent(gradeNumber){
    for(student of studentsList){
        if(student.gradeNumber == gradeNumber){
            studentsList.delete(student);
        }
    }
}

function filterByGroup(set, group){
    let filteredStudents = new Set();
    for(let student of set){
        if(student.group == group){
            filteredStudents.add(student);
        }
    }
    return filteredStudents;
}

function sortByGradeNubmer(set){
    let arr = Array.from(set);
    set.clear();
    arr.sort((el1, el2) => el1.gradeNumber > el2.gradeNumber ? 1 : -1);
    for (const element of arr) {
        set.add(element);
    }
}

let studentsList = new Set();

addStudent({gradeNumber: 345, group: 6, fio: "Литвинчук"});
addStudent({gradeNumber: 167, group: 4, fio: "Кучерук"});
addStudent({gradeNumber: 789, group: 6, fio: "Лускина"});
addStudent({gradeNumber: 561, group: 4, fio: "Романов"});

let filter = filterByGroup(studentsList, 4);
console.log(filter);

removeStudent(345);
console.log(studentsList);

sortByGradeNubmer(studentsList);
console.log(studentsList);