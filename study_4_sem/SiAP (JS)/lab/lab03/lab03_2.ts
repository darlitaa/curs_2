interface IReport {
    title: string;
    content: string;
    generate(): string | object; 
}

abstract class _Report implements IReport {
    constructor(public title: string, public content: string) {}

    abstract generate(): string | object; 
}

class HTMLReport extends _Report {
    generate(): string {
        return `<h1>${this.title}</h1><p>${this.content}</p>`;
    }
}

class JSONReport extends _Report {
    generate(): object {
        return {
            title: this.title,
            content: this.content,
        };
    }
}


const report1 = new HTMLReport("Отчёт 1", "Содержание отчёта");
console.log(report1.generate());

const report2 = new JSONReport("Отчёт 2", "Содержание отчёта");
console.log(report2.generate());
