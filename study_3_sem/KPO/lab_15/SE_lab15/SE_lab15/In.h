#pragma once
#define IN_MAX_LEN_TEXT 1024*1024
#define MAX_LEN_LINE 1000
#define IN_CODE_ENDL '\n'
#define IN_CODE_TABLE {\
	        F, F, F, F, F, F, F, F, F,   F,  '|',   F,   F,   I,   F,   F, \
            F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            T,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            T,   F,   T,   F,   F,   T,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            F,   F,   F,   F,   T,   F,   F,   F,   F,   F,   F,   F,   T,   F,    F,   F, \
            F,   F,   F,   F,   F,   F,   F,   F,   I,   F,   F,   F,   F,   F,   F,   F, \
            F,   T,   F,   T,   F,   F,   F,   F,   T,   T,   F,   T,   F,   F,   T,   F, \
            F,   F,   T,   F,   T,   T,   T,   F,   F,   T,   F,   F,   F,   F,   F,   F, \
            F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
           '-',  F,   F,  F,   T,   F,   F,   F,   F,   F,   F,   T,   F,   F,   F,   F, \
            F,   F,   F,  F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            T,   F,   T,  F,   F,   F,   F,   F,   T,   F,   T,   F,   F,   T,   F,   F, \
            T,   F,   T,  T,   F,   F,   F,   T,   F,   F,   F,   F,   T,   F,   F,   T \
}

namespace In
{
	void dell_in(char* str, int index);
	struct IN
	{
		enum { T = 1024, F = 2048, I = 4096 };
		int size;
		int lines;
		int ignor;
		unsigned char* text;
		int code[256] = IN_CODE_TABLE;
	};
	IN getin(wchar_t infile[]);
};