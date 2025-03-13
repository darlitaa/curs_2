#include "stdafx.h"
#include <cmath>
#include <memory.h>
#include <algorithm>
#include <iostream>
#include <ctime>
#include <iomanip>
#include "Levenstein.h"
using namespace std;

#define N 6
#define FIRST_LEN 300
#define SECOND_LEN 200

char* Task1(int size)
{
	char* str = new char[size];

	for (int i = 0; i < size; i++) str[i] = rand() % 26 + 'a';
	return str;
}


int _tmain(int argc, _TCHAR* argv[])
{
	setlocale(LC_ALL, "rus");
	srand(time(0));

	char* s1 = Task1(FIRST_LEN);
	cout << "S1: " << endl;
	for (int i = 0; i < FIRST_LEN; i++)
	{
		if (i % 50 == 0)
		{
			cout << "\n";
		}
		cout << s1[i];
	}
	cout << endl << endl;

	srand(time(NULL) + 1);
	char* s2 = Task1(SECOND_LEN);
	cout << "S2: " << endl;
	for (int i = 0; i < SECOND_LEN; i++)
	{
		if (i % 50 == 0)
		{
			cout << "\n";
		}
		cout << s2[i];
	}
	cout << endl << endl;

	clock_t t1 = 0, t2 = 0, t3 = 0, t4 = 0;
	int lx = sizeof(s1);
	int ly = sizeof(s2);

	int s1_size[]{ FIRST_LEN / 25, FIRST_LEN / 20, FIRST_LEN / 15, FIRST_LEN / 10, FIRST_LEN / 5, FIRST_LEN / 2, FIRST_LEN };
	int s2_size[]{ SECOND_LEN / 25, SECOND_LEN / 20, SECOND_LEN / 15, SECOND_LEN / 10, SECOND_LEN / 5, SECOND_LEN / 2, SECOND_LEN };

	cout << "\n\n  ���������� ����������� ";
	cout << "\n\n  �����     ��������    ���.�������.\n";

	for (int i = 0; i < min(lx, ly); i++)
	{
		t1 = clock();
		//levenshtein_r(s1_size[i], s1, s2_size[i], s2);
		levenshtein(s1_size[i], s1, s2_size[i], s2);
		t2 = clock();

		t3 = clock();
		//levenshtein(s1_size[i], s1, s2_size[i], s2);
		levenshtein_r(s1_size[i], s1, s2_size[i], s2);
		t4 = clock();
		cout << right << setw(2) << s1_size[i] << "/" << setw(2) << s2_size[i]
			<< "        " << left << setw(10) << (t2 - t1)
			<< "   " << setw(10) << (t4 - t3) << endl;
	}

	system("pause");
	return 0;
}