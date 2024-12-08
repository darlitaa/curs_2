#pragma once
#include "In.h"
#include "Parm.h"
#include "Error.h"

namespace Out
{
    struct OUT // структура
    {
        wchar_t outfile[PARM_MAX_SIZE]; // имя файла
        std::ofstream* stream;    // выводимый поток
    };

    static const OUT INITLOG{ L"", NULL };
    OUT getout(wchar_t outfile[]);
    void WriteOut(In::IN in, wchar_t out[]);
    void WriteError(OUT out, Error::ERROR error);
    void Close(OUT out);
};