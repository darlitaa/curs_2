var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var BaseUser = /** @class */ (function () {
    function BaseUser(id, name) {
        this.id = id;
        this.name = name;
    }
    return BaseUser;
}());
var Guest = /** @class */ (function (_super) {
    __extends(Guest, _super);
    function Guest() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Guest.prototype.getRole = function () {
        return "Guest";
    };
    Guest.prototype.getPermissions = function () {
        return ["Просмотр контента"];
    };
    return Guest;
}(BaseUser));
var User = /** @class */ (function (_super) {
    __extends(User, _super);
    function User() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    User.prototype.getRole = function () {
        return "User";
    };
    User.prototype.getPermissions = function () {
        return ["Просмотр контента", "Добавление комментариев"];
    };
    return User;
}(BaseUser));
var Admin = /** @class */ (function (_super) {
    __extends(Admin, _super);
    function Admin() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Admin.prototype.getRole = function () {
        return "Admin";
    };
    Admin.prototype.getPermissions = function () {
        return [
            "Просмотр контента", "Добавление комментариев",
            "Удаление комментариев", "Управление пользователями"
        ];
    };
    return Admin;
}(BaseUser));
var guest = new Guest(1, "Игорь");
console.log(guest.getPermissions());
var user = new User(2, "Ольга");
console.log(user.getPermissions());
var admin = new Admin(3, "Дарья");
console.log(admin.getPermissions());
