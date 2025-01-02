#include<iostream>
#include<fstream>
#include "Serealizer.h"
using namespace std;

void main()
{
	char textString[128];
	cin.getline(textString, 128);
	int intValue;
	cin >> intValue;

	ofstream file;
	file.open("D:\\course_2\\study(3sem)\\KPO\\lab\\asm_4\\lab4_asm\\Serealizer\\stream.bin", std::ios::binary);
	Serealizer::Serialize(intValue, file);
	Serealizer::Serialize(textString, file);
	file.close();
}