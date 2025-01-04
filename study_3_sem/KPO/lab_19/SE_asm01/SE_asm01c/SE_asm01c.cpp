#include <iostream>
#pragma comment(lib, "..\\Debug\\SE_asm01a.lib")
using namespace std;

extern "C" 
{
    int __stdcall getmin(int*, int);
    int __stdcall getmax(int*, int);
}

int main()
{
    int intArray[10] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    int min = getmin(intArray, sizeof(intArray) / sizeof(int));
    int max = getmax(intArray, sizeof(intArray) / sizeof(int));

    cout << "getmin + getmax = " << min + max << endl;
}

