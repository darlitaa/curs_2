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
var _Report = /** @class */ (function () {
    function _Report(title, content) {
        this.title = title;
        this.content = content;
    }
    return _Report;
}());
var HTMLReport = /** @class */ (function (_super) {
    __extends(HTMLReport, _super);
    function HTMLReport() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    HTMLReport.prototype.generate = function () {
        return "<h1>".concat(this.title, "</h1><p>").concat(this.content, "</p>");
    };
    return HTMLReport;
}(_Report));
var JSONReport = /** @class */ (function (_super) {
    __extends(JSONReport, _super);
    function JSONReport() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    JSONReport.prototype.generate = function () {
        return {
            title: this.title,
            content: this.content,
        };
    };
    return JSONReport;
}(_Report));
var report1 = new HTMLReport("Отчёт 1", "Содержание отчёта");
console.log(report1.generate());
var report2 = new JSONReport("Отчёт 2", "Содержание отчёта");
console.log(report2.generate());
