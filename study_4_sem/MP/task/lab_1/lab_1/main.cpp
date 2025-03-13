#include "stdafx.h"
#include "Auxil.h"                            // ��������������� ������� 
#include <iostream>
#include <ctime>
#include <locale>

#define  CYCLE  1000000 // ���������� ������ 

int Fib(int i)
{
	if (i < 1)
		return 0;
	if (i == 1)
		return 1;
	return Fib(i - 1) + Fib(i - 2);
}

int _tmain()
{

	double  av1 = 0, av2 = 0;
	clock_t  t1 = 0, t2 = 0;

	setlocale(LC_ALL, "rus");

	auxil::start();                          // ����� ��������� 
	t1 = clock();                            // �������� ������� 
	for (int i = 0; i < CYCLE; i++)
	{
		av1 += (double)auxil::iget(-100, 100); // ����� ��������� ����� 
		av2 += auxil::dget(-100, 100);         // ����� ��������� ����� 
	}
	t2 = clock();                            // �������� ������� 


	std::cout << std::endl << "���������� ������:         " << CYCLE;
	std::cout << std::endl << "������� �������� (int):    " << av1 / CYCLE;
	std::cout << std::endl << "������� �������� (double): " << av2 / CYCLE;
	std::cout << std::endl << "����������������� (�.�):   " << (t2 - t1);
	std::cout << std::endl << "                  (���):   " << ((double)(t2 - t1)) / ((double)CLOCKS_PER_SEC);
	std::cout << std::endl;

	for (int n = 25; n < 43; n++)
	{
		t1 = clock();
		int num = Fib(n);
		t2 = clock();
		std::cout << std::endl << n << "-� ����� ��������� " << (t2 - t1) << " �.�.";
	}
	std::cout << std::endl;
	system("pause");

	return 0;
}