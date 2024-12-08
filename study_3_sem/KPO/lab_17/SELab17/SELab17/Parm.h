#pragma once
#define PARM_IN L"-in:" // ключ для файла входных данных
#define PARM_OUT L"-out:" // ключ для файла выходных данных
#define PARM_LOG L"-log:" // ключ для файла лога
#define PARM_MAX_SIZE 300 // максимальная длина строки параметра
#define PARM_OUT_DEFAULT_EXT L".out" // расширение файла выходных данных по умолчанию
#define PARM_LOG_DEFAULT_EXT L".log" // расширение файла лога по умолчанию

namespace Parm // пространство имен для входных параметров
{
    struct PARM // входные параметры
    {
        wchar_t in[PARM_MAX_SIZE]; // -in: имя файла входных данных
        wchar_t out[PARM_MAX_SIZE]; // -out: имя файла выходных данных
        wchar_t log[PARM_MAX_SIZE]; // -log: имя файла лога
    };

    PARM getparm(int argc, _TCHAR* argv[]); // собрать struct PARM из новых параметров функции main
};