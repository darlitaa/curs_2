#pragma once
#define ERROR_THROW(id) Error::geterror(id); // throw ERROR_THROW(id)
#define ERROR_THROW_IN(id, l, c) Error::geterrorin(id, l, c); // throw ERROR_THROW_IN
#define ERROR_ENTRY(id, m) {id, m, {-1, -1}} // элемент структуры ошибки
#define ERROR_MAXSIZE_MESSAGE 200 // максимальная длина сообщения об ошибке
#define ERROR_ENTRY_NODEF(id) ERROR_ENTRY(-id, "Недекларированная ошибка") // 1 недекларированный элемент структуры ошибки
// ERROR_ENTRY_NODEF10(id) - 10 недекларированных элементов структуры ошибки
#define ERROR_ENTRY_NODEF10(id) ERROR_ENTRY_NODEF(id+0),ERROR_ENTRY_NODEF(id+1),ERROR_ENTRY_NODEF(id+2), ERROR_ENTRY_NODEF(id+3), \
                                ERROR_ENTRY_NODEF(id+4), ERROR_ENTRY_NODEF(id+5), ERROR_ENTRY_NODEF(id+6), ERROR_ENTRY_NODEF(id+7), \
                                ERROR_ENTRY_NODEF(id+8), ERROR_ENTRY_NODEF(id+9)
// ERROR_ENTRY_NODEF100(id) - 100 недекларированных элементов структуры ошибки
#define ERROR_ENTRY_NODEF100(id) ERROR_ENTRY_NODEF(id+0),ERROR_ENTRY_NODEF(id+10),ERROR_ENTRY_NODEF(id+2), ERROR_ENTRY_NODEF(id+3), \
                                ERROR_ENTRY_NODEF(id+40), ERROR_ENTRY_NODEF(id+50), ERROR_ENTRY_NODEF(id+6), ERROR_ENTRY_NODEF(id+7), \
                                ERROR_ENTRY_NODEF(id+80), ERROR_ENTRY_NODEF(id+90)

#define ERROR_MAX_ENTRY 1000

namespace Error
{
    struct ERROR // структура для генерации throw ERROR_THROW | ERROR_THROW_IN
    {
        int id; // код ошибки
        char message[ERROR_MAXSIZE_MESSAGE]; // сообщение об ошибке
        struct IN // структура для ошибки при вводе входных данных
        {
            short line; // номер строки (0, 1, 2, ...)
            short col; // номер столбца в строке (0, 1, 2, ...)
        } inext;
    };
    ERROR geterror(int id);						// сформировать ERROR для ERROR_THROW 
    ERROR geterrorin(							// сформировать ERROR для ERROR_THROW_IN
        int id,										// код ошибки
        int line,									// номер строки
        int col										// номер колонки
    );
}