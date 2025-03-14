#pragma once
#include <fstream>
#include "In.h"
#include "Parm.h"
#include "Error.h"
using namespace std;

namespace Out
{
	struct OUT
	{
		wchar_t outfile[PARM_MAX_SIZE];
		ofstream* stream;
	};

	static const OUT INITOUT{ L"", NULL };
	OUT getout(wchar_t logfile[]);
	void WriteOut(OUT out, In::IN in);
	void WriteError(OUT out, Error::ERROR error);
	void Close(OUT out);
};