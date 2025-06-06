#pragma once

#define ID_MAXSIZE		5					// ������������ ���������� �������� � �������������� 
#define TI_MAXSIZE		4096				// ������������ ���������� ����� � ������� ���������������
#define TI_INT_DEFAULT  0x00000000			// �������� �� ��������� ��� ���� integer
#define TI_STR_DEFAULT  0x00				// �������� �� ��������� ��� ���� string
#define TI_NULLIDX		0xffffffff			// ��� �������� ������� ���������������
#define TI_STR_MAXSIZE  255					// ������������ ����� ������

#define PARM_ID 
#define PARM_ID L".id.txt"

namespace IT								// ������� ��������������� 
{
	enum IDDATATYPE { DEF = 0, INT = 1, STR = 2 };				// ���� ������ ���������������: integer, string
	enum IDTYPE { D = 0, V = 1, F = 2, P = 3, L = 4 };			// ���� ���������������: ����������, �������, ��������, �������

	struct Entry							// ������ ������� ���������������
	{
		char parrent_function[ID_MAXSIZE + 5];			// ������������� ������������ �������
		int firstApi;									// ������ ������ ������ � ������� ������
		char id[ID_MAXSIZE + 5];						// ������������� (������������� ��������� �� ID_MAXSIZE)
		IDDATATYPE iddatatype;							// ��� ������
		IDTYPE idtype;									// ��� ��������������
		union
		{
			int vint;									// �������� integer
			char operation = '\0';
			struct
			{
				unsigned char len;						// ���������� �������� � string
				char str[TI_STR_MAXSIZE];				// ������� string
			} vstr;						// �������� string
		} value;						// �������� ��������������
		int parmQuantity;

		Entry();
		Entry(const char* parrentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first);
		Entry(const char* parrentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, int it);
		Entry(const char* parrentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, char* str);
		Entry(const char* parrentFunc, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, const char* str);
		Entry(char* parrentFunc, char* id, IDDATATYPE iddatatype, IDTYPE idtype);
	};

	struct IdTable							// ��������� ������� ���������������
	{
		int noname_lexema_count;				// ������� �������������������� ������
		int maxsize;							// ������� ������� ��������������� < TI_MAXSIZE
		int size;								// ������� ������ ������� ��������������� < maxsize
		Entry* table;							// ������ ����� ������� ���������������
		Entry GetEntry(							// �������� ������ ������� ���������������
			int n									// ����� ���������� ������
		);
		int IsId(								// �������: ����� ������ (���� ����), TI_NULLIDX(���� ���)
			const char id[ID_MAXSIZE]				// �������������
		);
		int IsId(const char id[ID_MAXSIZE], const char parrent_function[ID_MAXSIZE + 5]);

		void Add(								// �������� ������ � ������� ��������������� 
			Entry entry								// ������ ������� ��������������
		);
		void PrintIdTable(const wchar_t* in);	// ����� ������� ���������������

		IdTable();
		char* GetLexemaName();
	};


	void Delete(IdTable& idtable);			// ������� ������� ������ (���������� ������)
};