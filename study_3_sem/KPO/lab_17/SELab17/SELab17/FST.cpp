#include "stdafx.h"

namespace FST
{

	// Конструктор класса RELATION, инициализирующий символ и номер следующего состояния.
	RELATION::RELATION(char c, short ns)
	{
		symbol = c; // Установка символа для перехода.
		nnode = ns; // Установка номера следующего узла.
	}

	// Конструктор по умолчанию для класса NODE.
	NODE::NODE()
	{
		n_relation = NULL; // Инициализация количества отношений нулем.
		RELATION* relations = NULL; // Инициализация указателя на массив отношений.
	};

	// Конструктор класса NODE, принимающий количество отношений и сам объект RELATION.
	NODE::NODE(short n, RELATION rel, ...)
	{
		n_relation = n; // Установка количества отношений.
		RELATION* p = &rel; // Указатель на переданный объект RELATION.
		relations = new RELATION[n]; // Выделение памяти для массива отношений.

		// Копирование переданных отношений в массив отношений.
		for (short i = 0; i < n; i++) relations[i] = p[i];
	};

	// Конструктор класса FST, инициализирующий конечный автомат.
	FST::FST(const char* s, short ns, NODE n, ...)
	{
		position = -1; // Инициализация позиции в строке.
		string = s; // Сохранение строки для обработки.
		nstates = ns; // Установка количества состояний.
		nodes = new NODE[ns]; // Выделение памяти для массива узлов.

		NODE* p = &n; // Указатель на переданный узел.
		// Копирование переданного узла в массив узлов.
		for (int k = 0; k < ns; k++) nodes[k] = p[k];

		// Инициализация массива текущих состояний.
		rstates = new short[nstates];
		memset(rstates, 0Xff, sizeof(short) * nstates); // Инициализация значениями -1 (0xFF).
		rstates[0] = 0; // Установка начального состояния.
	}

	// Функция step выполняет один шаг в автомате, проверяя возможные переходы.
	bool step(FST& fst, short*& rstates) {
		bool rc = false; // Флаг, указывающий, был ли выполнен переход.
		std::swap(rstates, fst.rstates); // Обмен текущих состояний с состояниями автомата.

		// Проход по всем состояниям автомата.
		for (short i = 0; i < fst.nstates; i++)
		{
			// Проверка, соответствует ли текущее состояние текущей позиции.
			if (rstates[i] == fst.position)
				for (short j = 0; j < fst.nodes[i].n_relation; j++)
					// Проверка, соответствует ли символ переходу.
					if (fst.nodes[i].relations[j].symbol == fst.string[fst.position]) {
						fst.rstates[fst.nodes[i].relations[j].nnode] = fst.position + 1; // Установка нового состояния.
						rc = true; // Установка флага перехода.
					};
		};
		return rc; // Возврат результата выполнения перехода.
	};

	// Функция execute выполняет обработку строки конечным автоматом.
	bool execute(FST& fst)
	{
		short* rstates = new short[fst.nstates]; // Выделение памяти для текущих состояний.
		memset(rstates, 0xff, sizeof(short) * fst.nstates); // Инициализация значениями -1.
		short lstring = strlen(fst.string); // Длина обрабатываемой строки.
		bool rc = true; // Флаг, указывающий на успешное выполнение.

		// Проход по всем символам строки.
		for (short i = 0; i < lstring && rc; i++)
		{
			fst.position++; // Увеличение текущей позиции.
			rc = step(fst, rstates); // Выполнение одного шага.
		};
		delete[] rstates; // Освобождение памяти.

		// Возврат результата: успешно ли автомат достиг конечного состояния.
		return (rc ? (fst.rstates[fst.nstates - 1] == lstring) : rc);
	};
}