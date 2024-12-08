#pragma once
#include "stdafx.h"

#define token_size 256

namespace LA
{
	// Тип переменной
	struct TypeOfVar
	{
		int LT_posititon = -1;								// Позиция перменной в таблице лексем (-1 - её отсутствие)
		enum { DEF = 0, INT = 1, STR = 2 } type = DEF;		// Перечисление, которое определяет тип переменной
	};

	// Анализирует идентификаторы (например, имена переменных или функций)
	bool AnalyzeIdentifier(char* token, const int strNumber, LT::LexTable& lexTable, IT::IdTable& idTable, TypeOfVar& flag_type_variable);

	// Основная функция, выполняющая лексический анализ исходного кода
	void LexicalAnalyzer(const In::IN& source, LT::LexTable& lexTable, IT::IdTable& idTable);

	//  Анализирует отдельные токены (лексемы), найденные в исходном тексте
	// true - success, false - failed
	bool AnalyzeToken(char* token, const int strNumber, LT::LexTable& lexTable, IT::IdTable& idTable);
}
