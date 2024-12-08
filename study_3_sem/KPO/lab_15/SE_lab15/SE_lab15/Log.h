#pragma once

#include "In.h"
#include "Parm.h"
#include "Error.h"
using namespace std;
namespace Log // Пространство с идентификатором
{
    struct LOG // Логгер
    {
        wchar_t logfile[PARM_MAX_SIZE]; // Имя файла логгера
        ofstream* stream; // Выходной поток логгера
    };

    static const LOG INITLOG{ L"", NULL }; // Константа для инициализации LOG
    LOG getlog(wchar_t logfile[]); // Создать экземпляр LOG
    void WriteLine(LOG log, char* c, ...); // Вывести в лог строку
    void WriteLine(LOG log, wchar_t* w, ...); // Вывести в лог строку
    void WriteLog(LOG log); // Вывести в лог сообщение
    void WriteParm(LOG log, Parm::PARM parm); // Вывести в лог информацию о входных параметрах
    void WriteIn(LOG log, In::IN in); // Вывести в лог информацию о входном потоке
    void WriteError(LOG log, Error::ERROR error); // Вывести в лог информацию об ошибке
    void Close(LOG log);
};