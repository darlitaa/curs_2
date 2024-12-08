#include "stdafx.h"

namespace IT
{

	// Инициализация таблицы
	IdTable::IdTable()
	{
		noname_lexema_count = 0;
		maxsize = TI_MAXSIZE;
		size = 0;
		table = new Entry[TI_MAXSIZE];
	}

	// Инициализация строки (по умолчанию)
	Entry::Entry()
	{
		parrent_function[0] = '\0';
		id[0] = '\0';
		firstApi = 0;
		iddatatype = IT::IDDATATYPE::DEF;
		idtype = IT::IDTYPE::D;
		parmQuantity = 0;
	}

	// Инициализация строки (родительскую ф-цию, индентификатор, тип данных, тип индентификатора и первое вхождение)
	Entry::Entry(const char* parrent_function, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first)
	{
		int i = 0;
		if (parrent_function)
			for (i = 0; parrent_function[i] != '\0'; i++)
				this->parrent_function[i] = parrent_function[i];
		this->parrent_function[i] = '\0';
		i = 0;
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		this->firstApi = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		this->parmQuantity = 0;
	}

	// Инициализация строки (integer со своим значением)
	Entry::Entry(const char* parrent_function, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, int it)
	{
		int i = 0;
		if (parrent_function)
			for (i = 0; parrent_function[i] != '\0'; i++)
				this->parrent_function[i] = parrent_function[i];
		this->parrent_function[i] = '\0';
		i = 0;
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		this->firstApi = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		this->parmQuantity = 0;
		this->value.vint = it;
	}

	// Инициализация строки (string со своим значением)
	Entry::Entry(const char* parrent_function, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, char* ch)
	{
		int i = 0;
		if (parrent_function)
			for (i = 0; parrent_function[i] != '\0'; i++)
				this->parrent_function[i] = parrent_function[i];
		this->parrent_function[i] = '\0';
		i = 0;
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		this->firstApi = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		this->parmQuantity = 0;

		strcpy_s(this->value.vstr.str, 255, ch);
		this->value.vstr.len = strlen(ch);
	}

	// Инициализация строки (string со своим значением)
	Entry::Entry(const char* parrent_function, const char* id, IDDATATYPE iddatatype, IDTYPE idtype, int first, const char* ch)
	{
		int i = 0;
		if (parrent_function)
			for (i = 0; parrent_function[i] != '\0'; i++)
				this->parrent_function[i] = parrent_function[i];
		this->parrent_function[i] = '\0';
		i = 0;
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		this->firstApi = first;
		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		this->parmQuantity = 0;

		strcpy_s(this->value.vstr.str, 255, ch);
		this->value.vstr.len = strlen(ch);
	}

	// Инициализация строки (просто указания типа данных и типа идентификатора)
	Entry::Entry(char* parrent_function, char* id, IDDATATYPE iddatatype, IDTYPE idtype)
	{
		int i = 0;
		if (parrent_function)
			for (i = 0; parrent_function[i] != '\0'; i++)
				this->parrent_function[i] = parrent_function[i];
		this->parrent_function[i] = '\0';
		i = 0;
		if (id)
			for (i = 0; id[i] != '\0'; i++)
				this->id[i] = id[i];

		this->id[i] = '\0';
		this->iddatatype = iddatatype;
		this->idtype = idtype;
		this->parmQuantity = 0;
	}

	// Создание таблицы
	IdTable Create(int size)
	{
		IdTable id_table;
		id_table.size = size;
		id_table.maxsize = TI_MAXSIZE;
		id_table.table = new Entry[TI_MAXSIZE];
		return id_table;
	}

	// Добавление строки
	void IdTable::Add(Entry entry)
	{
		if (strlen(entry.id) > ID_MAXSIZE && entry.idtype != IDTYPE::F)
			throw ERROR_THROW(65);

		if (size >= maxsize)
			throw ERROR_THROW(66);

		if (entry.idtype != IDTYPE::F)
			entry.id[5] = '\0';

		table[size] = entry;

		switch (entry.iddatatype)
		{
		case IDDATATYPE::INT:
		{
			table[size].value.vint = TI_INT_DEFAULT;
			break;
		}
		case IDDATATYPE::STR:
		{
			table[size].value.vstr.str[0] = TI_STR_DEFAULT;
			table[size].value.vstr.len = 0;
			break;
		}
		}

		size++;
	}

	// Получить строку из табоицы по номеру
	Entry IdTable::GetEntry(int n)
	{
		if (n >= 0 && n < maxsize)
			return table[n];
	}

	// Существует ли уже идентификатор в таблице, сравнивая переданный идентификатор с теми, которые уже добавлены
	int IdTable::IsId(const char id[ID_MAXSIZE])
	{
		for (int i = 0; i < size; i++)
			if (strcmp(table[i].id, id) == 0)
				return i;

		return TI_NULLIDX;
	}

	// Существует ли уже идентификатор в таблице, сравнивая переданный идентификатор с теми, которые уже добавлены
	//Этот метод позволяет различать идентификаторы, которые могут быть одинаковыми по имени, но находятся в разных функциях, что предотвращает конфликты.
	int IdTable::IsId(const char id[ID_MAXSIZE], const char parrent_function[ID_MAXSIZE + 5])
	{
		for (int i = 0; i < size; i++)
			if ((strcmp(this->table[i].id, id) == 0) &&
				(strcmp(this->table[i].parrent_function, parrent_function) == 0))
				return i;

		return TI_NULLIDX;
	}

	// Удаление таблицы
	void Delete(IdTable& idtable)
	{
		delete[] idtable.table;
		idtable.table = nullptr;
	}

	// Получить имя лексемы
	char* IdTable::GetLexemaName()
	{
		{
			char buffer[6]; // Увеличиваем размер буфера до 6 для хранения числа и завершающего нуля
			_itoa_s(noname_lexema_count, buffer, 10); // Преобразуем число в строку (10 - основание системы счисления)

			char result[8]; // Достаточно места для "l_" + 5 символов числа + завершающий ноль

			// Сначала добавляем "l_" в result, затем добавляем содержимое buffer
			strcpy_s(result, sizeof(result), "l_"); // Копируем "l_" в result
			strcat_s(result, sizeof(result), buffer); // Добавляем значение из buffer

			noname_lexema_count++; // Увеличиваем счетчик

			return _strdup(result); // Возвращаем дубликат строки (нужно освободить память позже)
		}
	}


	// Вывод таблицы
	void IdTable::PrintIdTable(const wchar_t* inFile)
	{
		ofstream idStream(inFile);

		if (!idStream.is_open())
			throw ERROR_THROW(64);


		idStream << "---------------------Таблица идентификаторов:---------------------" << endl;
		idStream << " Литералы:" << endl;
		idStream << setw(15) << "Идентификатор:" << setw(17) << "Тип данных:" << setw(15) << "Значение:" << setw(27) << "Длина строки:" << setw(20) << "Первое вхождение:" << endl;

		for (int i = 0; i < size; i++)
		{
			if (table[i].idtype == IT::IDTYPE::L)
			{
				cout.width(25);
				switch (table[i].iddatatype)
				{
				case IDDATATYPE::INT:
					idStream << "   " << this->table[i].id << "\t\t\t\t\t" << "INT " << "\t\t\t " << table[i].value.vint << "\t\t\t\t\t\t  " << "-\t\t\t\t\t" << table[i].firstApi << endl;
					break;
				case IDDATATYPE::STR:
					idStream << "   " << this->table[i].id << "\t\t\t\t\t" << "STR " << "\t    " << table[i].value.vstr.str << setw(30 - strlen(table[i].value.vstr.str)) << (int)table[i].value.vstr.len << "\t\t\t\t\t" << table[i].firstApi << endl;
					break;
				}
			}
		}

		idStream << "\n\n\n\n";
		idStream << "Функции:" << endl;
		idStream << setw(15) << "Идентификатор:" << setw(26) << "Тип данных возврата:" << setw(36) << "Количество переданных параметров:" << setw(22) << "Первое вхождение:" << endl;

		for (int i = 0; i < size; i++)
		{
			if (this->table[i].idtype == IT::IDTYPE::F)
			{
				switch (table[i].iddatatype)
				{
				case IDDATATYPE::INT:
					idStream << "   " << table[i].id << setw(28 - strlen(table[i].id)) << "INT " << "\t\t\t\t\t\t\t\t" << table[i].parmQuantity << "\t\t\t\t\t\t\t" << table[i].firstApi << endl;
					break;
				case IDDATATYPE::STR:
					idStream << "   " << table[i].id << setw(28 - strlen(table[i].id)) << "STR " << "\t\t\t\t\t\t\t\t" << table[i].parmQuantity << "\t\t\t\t\t\t\t" << table[i].firstApi << endl;
					break;
				}
			}
		}
		idStream << "\n\n\n\n";
		idStream << "Переменные:" << endl;
		idStream << setw(25) << "Имя родительского блока:" << setw(20) << "Идентификатор:" << setw(16) << "Тип данных:" << setw(24) << "Тип идентификатора:" << setw(21) << "Первое вхождение:" << endl;

		for (int i = 0; i < size; i++)
		{
			if (table[i].idtype == IT::IDTYPE::V)
			{
				switch (table[i].iddatatype)
				{
				case IDDATATYPE::INT:
					idStream << "   " << table[i].parrent_function << setw(35 - strlen(table[i].parrent_function)) << table[i].id << setw(20) << "INT " << setw(15) << "\t" << "V" << "\t\t\t\t\t\t" << table[i].firstApi << endl;
					break;
				case IDDATATYPE::STR:
					idStream << "   " << table[i].parrent_function << setw(35 - strlen(table[i].parrent_function)) << table[i].id << setw(20) << "STR " << setw(15) << "\t" << "V" << "\t\t\t\t\t\t" << table[i].firstApi << endl;
					break;
				}
			}

			if (table[i].idtype == IT::IDTYPE::P)
			{
				switch (table[i].iddatatype)
				{
				case IDDATATYPE::INT:
					idStream << "   " << table[i].parrent_function << setw(35 - strlen(table[i].parrent_function)) << table[i].id << setw(20) << "INT " << setw(15) << "\t" << "P" << "\t\t\t\t\t\t" << table[i].firstApi << endl;
					break;

				case IDDATATYPE::STR:
					idStream << "   " << table[i].parrent_function << setw(35 - strlen(table[i].parrent_function)) << table[i].id << setw(20) << "STR " << setw(15) << "\t" << "P" << "\t\t\t\t\t\t" << table[i].firstApi << endl;
					break;
				}
			}
		}

		idStream << "\n\n\n";

		idStream.close();
	}
}