#include <iostream>
#include"Deserealizer.h"
using namespace std;

void main()
{
    std::ifstream inputFile("D:\\course_2\\study(3sem)\\KPO\\lab\\asm_4\\lab4_asm\\Serealizer\\stream.bin", std::ios::binary);
    std::vector<std::pair<int, char*>> result = Deserealizator::Deserelization(inputFile);

    for (const auto& item : result)
    {
        if (item.first != NULL)
        {
            cout << "Integer value: " << item.first << std::endl;
        }
        else if (item.second != NULL)
        {
            cout << "String value: " << item.second << std::endl;
        }
    }
    inputFile.close();
}