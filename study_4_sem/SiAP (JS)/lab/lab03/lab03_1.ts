abstract class BaseUser  {
    constructor(public id: number,public name: string) {}

    abstract getRole(): string;
    abstract getPermissions(): string[];
}

class Guest extends BaseUser {
    getRole(): string {
        return "Guest";
    }

    getPermissions(): string[] {
        return ["Просмотр контента"];
    }
}

class User extends BaseUser {
    getRole(): string {
        return "User";
    }
    getPermissions(): string[] {
        return ["Просмотр контента","Добавление комментариев"];
    }
}

class Admin extends BaseUser {
    getRole(): string {
        return "Admin";
    }
    getPermissions(): string[] {
        return [
            "Просмотр контента","Добавление комментариев",
            "Удаление комментариев","Управление пользователями"
        ];
    }
}


const guest = new Guest(1, "Игорь");
console.log(guest.getPermissions()); 

const user = new User(2, "Ольга");
console.log(user.getPermissions());

const admin = new Admin(3, "Дарья");
console.log(admin.getPermissions());
