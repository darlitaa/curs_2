#include "GRB.h"
#include "GRBrules.h"
#include "string.h"

namespace GRB
{
	// Конструктор класса Chain
	Rule::Chain::Chain(short psize, GRBALPHABET s, ...)
	{
		// Создаем массив нетерминалов размером psize
		this->nt = new GRBALPHABET[this->size = psize];

		// Приводим указатель на входной параметр к типу int*
		int* ptr = (int*)&s;
		// Копируем элементы из переданного аргумента в массив nt
		for (int i = 0; i < psize; i++)
			this->nt[i] = (short)ptr[i];
	}

	// Конструктор класса Rule
	Rule::Rule(GRBALPHABET pnn, int iderroe, short psize, Chain c, ...)
	{
		// Инициализируем поля класса
		this->nn = pnn;              // Нетерминал
		this->iderror = iderroe;    // Идентификатор ошибки
		this->chains = new Chain[this->size = psize]; // Создаем массив цепочек

		// Указываем на переданную цепочку
		Chain* ptr = &c;
		// Копируем цепочки в массив
		for (int i = 0; i < psize; i++)
			this->chains[i] = ptr[i];
	}

	// Конструктор класса Greibach
	Greibach::Greibach(GRBALPHABET pstartN, GRBALPHABET pstbottomT, short psize, Rule r, ...)
	{
		// Инициализируем поля класса
		this->startN = pstartN;           // Начальный нетерминал
		this->stbottomT = pstbottomT;     // Терминал на дне стека
		this->rules = new Rule[this->size = psize]; // Создаем массив правил

		// Указываем на переданное правило
		Rule* ptr = &r;
		// Копируем правила в массив
		for (int i = 0; i < psize; i++)
			rules[i] = ptr[i];
	}



	// Метод для получения правила по нетерминалу
	short Greibach::getRule(GRBALPHABET pnn, Rule& prule)
	{
		short rc = -1, k = 0; // Инициализация переменных
		// Поиск правила по нетерминалу
		while (k < this->size && rules[k].nn != pnn)
			k++;
		// Если найдено, возвращаем индекс и правило
		if (k < this->size)
			prule = rules[rc = k];
		return rc; // Возвращаем индекс найденного правила или -1
	}

	// Метод для получения правила по индексу
	Rule Greibach::getRule(short n)
	{
		Rule rc; // Создаем временное правило
		// Если индекс в пределах размера, возвращаем правило
		if (n < this->size)
			rc = rules[n];
		return rc; // Возвращаем правило
	}

	// Метод для получения строкового представления правила
	char* Rule::getCRule(char* b, short nchain)
	{
		char buf[200]; // Временный буфер для цепочки
		b[0] = Chain::alphabet_to_char(this->nn); // Заполняем буфер нетерминалом
		b[1] = '-';
		b[2] = '>';
		b[3] = 0x00; // Завершаем строку

		// Получаем строковое представление цепочки
		this->chains[nchain].getCChain(buf);
		// Конкатенируем строку с правилом
		strcat_s(b, sizeof(buf) + 5, buf);

		return b; // Возвращаем буфер с представлением правила
	}

	// Метод для получения следующей цепочки по входному символу
	short Rule::getNextChain(GRBALPHABET t, Rule::Chain& pchain, short j)
	{
		short rc = -1; // Инициализация переменной

		// Поиск цепочки по входному символу
		while (j < this->size && this->chains[j].nt[0] != t)
			j++;

		// Если найдено, возвращаем индекс и цепочку
		rc = (j < this->size ? j : -1);
		if (rc >= 0)
			pchain = chains[rc];
		return rc; // Возвращаем индекс или -1
	}

	// Метод для получения строкового представления цепочки
	char* Rule::Chain::getCChain(char* b)
	{
		// Заполняем буфер символами цепочки
		for (int i = 0; i < this->size; i++)
			b[i] = Chain::alphabet_to_char(this->nt[i]);
		b[this->size] = 0; // Завершаем строку
		return b; // Возвращаем буфер
	}

	// Глобальная функция для получения экземпляра грамматики Грейбаха
	Greibach getGreibach()
	{
		return greibach; // Возвращаем экземпляр грамматики
	}
}