class Task {
    constructor(id, name, state) {
        this.id = id;
        this.name = name;
        this.state = state;
    }

    changeName(newName) {
        this.name = newName;
    }

    changeState(newState) {
        this.state = newState;
    }
}

let tasks = [];
let taskId = 1;

function addTask() {
    let taskNameInput = document.getElementById('taskName');
    let taskName = taskNameInput.value;
    if (taskName) {
        let newTask = new Task(taskId++, taskName, 'не выполнено');
        tasks.push(newTask);
        taskNameInput.value = '';
        renderTasks();
    }
}

function renderTasks(filter = 'all') {
    let taskList = document.getElementById('taskList');
    taskList.innerHTML = '';
    let filteredTasks = tasks.filter(task => {
        if (filter === 'completed') return task.state === 'выполнено';
        if (filter === 'not_completed') return task.state === 'не выполнено';
        return true;
    });

    filteredTasks.forEach(task => {
        let li = document.createElement('li');
        li.className = 'taskItem';
        li.innerHTML = `
            <input type="checkbox" onchange="toggleTaskState(${task.id}, this.checked)" ${task.state === 'выполнено' ? 'checked' : ''}>
            <span>${task.name}</span>
            <button class="editButton" onclick="editTask(${task.id})">Редактировать</button>
            <button class="deleteButton" onclick="deleteTask(${task.id})">Удалить</button>
        `;
        taskList.appendChild(li);
    });
}

function toggleTaskState(taskId, checked) {
    let task = tasks.find(t => t.id === taskId);
    if (task) {
        task.changeState(checked ? 'выполнено' : 'не выполнено');
        renderTasks();
    }
}

function deleteTask(taskId) {
    tasks = tasks.filter(task => task.id !== taskId);
    renderTasks();
}

function editTask(taskId) {
    let task = tasks.find(t => t.id === taskId);
    let newName = prompt("Измените название задачи:", task.name);
    if (newName) {
        task.changeName(newName);
        renderTasks();
    }
}

function filterTasks(state) {
    renderTasks(state);
}