#pragma once
#define IN_MAX_LEN_TEXT 1024*1024 //���� ������ ��� ����
#define IN_CODE_ENDL '\n'
// ������ ����� ������
// ������� �������� ������� ����������, ������ = ��� (Windows-1251) �������
// �������� IN::F -����������� ������, IN::T - ����������� ������, IN::I - ������������(�� �������),
// ���� 0 <= �������� < 256 - �� �������� ������ ��������

namespace In
{
    struct IN  // �������� ������
    {
        enum { T = 1024, F = 2048, I = 4096 }; // T - ���������� ������, F - ������������, I - ������������
        int size;                     // ������ ��������� ����
        int lines;                    // ���������� �����
        int ignor;                    // ���������� ����������������� ��������
        unsigned char* text;          // �������� ��� (Windows - 1251)
        /* int code[256] = { F, F, F, F, F, F, F, F, F,   F,   T,   F,   F,   I,   F,   F, \
             F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
             T,   T,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
             F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
             F,   F,   F,   F,   F,   F,   F,   F,   T,   F,   F,   F,   F,   F,   F,   F, \
             F,   F,   F,   F,   F,   F,   F,   T,   I,  '!',   F,   F,   F,   F,   F,   F, \
             F,   F,   F,   F,   T,   T,   F,   F,   F,   F,   F,   F,   T,   F,   F,   T, \
             F,   F,   T,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
             \
             F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
             F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
             F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
             F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
             F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   T,   F,   F,   T, \
             F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
             F,   F,   T,   F,   F,   T,   F,   F,   T,   T,   F,   F,   F,   F,   F,   F, \
             T,   F,   T,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F }; */
        int code[256] = { F, F, F, F, F, F, F, F, F,   F,  '|',   F,   F,   I,   F,   F, \
            F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            T,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            T,   F,   T,   F,   F,   T,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \

            F,   F,   F,   F,   T,   F,   F,   F,   F,   F,   F,   F,   T,   F,    F,   F, \
            F,   F,   F,   F,   F,   F,   F,   F,   I,   F,   F,   F,   F,   F,   F,   F, \
            F,   T,   F,   T,   F,   F,   F,   F,   T,   T,   F,   T,   F,   F,   T,   F, \
            F,   F,   T,   F,   T,   T,   T,   F,   F,   T,   F,   F,   F,   F,   F,   F, \
            
            F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \

           '-',  F,   F,  F,   T,   F,   F,   F,   F,   F,   F,   T,   F,   F,   F,   F, \
            F,   F,   F,  F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F,   F, \
            T,   F,   T,  F,   F,   F,   F,   F,   T,   F,   T,   F,   F,   T,   F,   F, \
            T,   F,   T,  T,   F,   F,   F,   T,   F,   F,   F,   F,   T,   F,   F,   T }; // ������� ��������: T, F, I ����� ��������
    };
    IN getin(wchar_t infile[]);   // ������ � ��������� ������� �����
};