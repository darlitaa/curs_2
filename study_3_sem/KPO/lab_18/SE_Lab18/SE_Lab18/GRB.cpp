#include "GRB.h"
#include "GRBrules.h"
#include "string.h"

namespace GRB
{
	// ����������� ������ Chain
	Rule::Chain::Chain(short psize, GRBALPHABET s, ...)
	{
		// ������� ������ ������������ �������� psize
		this->nt = new GRBALPHABET[this->size = psize];

		// �������� ��������� �� ������� �������� � ���� int*
		int* ptr = (int*)&s;
		// �������� �������� �� ����������� ��������� � ������ nt
		for (int i = 0; i < psize; i++)
			this->nt[i] = (short)ptr[i];
	}

	// ����������� ������ Rule
	Rule::Rule(GRBALPHABET pnn, int iderroe, short psize, Chain c, ...)
	{
		// �������������� ���� ������
		this->nn = pnn;              // ����������
		this->iderror = iderroe;    // ������������� ������
		this->chains = new Chain[this->size = psize]; // ������� ������ �������

		// ��������� �� ���������� �������
		Chain* ptr = &c;
		// �������� ������� � ������
		for (int i = 0; i < psize; i++)
			this->chains[i] = ptr[i];
	}

	// ����������� ������ Greibach
	Greibach::Greibach(GRBALPHABET pstartN, GRBALPHABET pstbottomT, short psize, Rule r, ...)
	{
		// �������������� ���� ������
		this->startN = pstartN;           // ��������� ����������
		this->stbottomT = pstbottomT;     // �������� �� ��� �����
		this->rules = new Rule[this->size = psize]; // ������� ������ ������

		// ��������� �� ���������� �������
		Rule* ptr = &r;
		// �������� ������� � ������
		for (int i = 0; i < psize; i++)
			rules[i] = ptr[i];
	}



	// ����� ��� ��������� ������� �� �����������
	short Greibach::getRule(GRBALPHABET pnn, Rule& prule)
	{
		short rc = -1, k = 0; // ������������� ����������
		// ����� ������� �� �����������
		while (k < this->size && rules[k].nn != pnn)
			k++;
		// ���� �������, ���������� ������ � �������
		if (k < this->size)
			prule = rules[rc = k];
		return rc; // ���������� ������ ���������� ������� ��� -1
	}

	// ����� ��� ��������� ������� �� �������
	Rule Greibach::getRule(short n)
	{
		Rule rc; // ������� ��������� �������
		// ���� ������ � �������� �������, ���������� �������
		if (n < this->size)
			rc = rules[n];
		return rc; // ���������� �������
	}

	// ����� ��� ��������� ���������� ������������� �������
	char* Rule::getCRule(char* b, short nchain)
	{
		char buf[200]; // ��������� ����� ��� �������
		b[0] = Chain::alphabet_to_char(this->nn); // ��������� ����� ������������
		b[1] = '-';
		b[2] = '>';
		b[3] = 0x00; // ��������� ������

		// �������� ��������� ������������� �������
		this->chains[nchain].getCChain(buf);
		// ������������� ������ � ��������
		strcat_s(b, sizeof(buf) + 5, buf);

		return b; // ���������� ����� � �������������� �������
	}

	// ����� ��� ��������� ��������� ������� �� �������� �������
	short Rule::getNextChain(GRBALPHABET t, Rule::Chain& pchain, short j)
	{
		short rc = -1; // ������������� ����������

		// ����� ������� �� �������� �������
		while (j < this->size && this->chains[j].nt[0] != t)
			j++;

		// ���� �������, ���������� ������ � �������
		rc = (j < this->size ? j : -1);
		if (rc >= 0)
			pchain = chains[rc];
		return rc; // ���������� ������ ��� -1
	}

	// ����� ��� ��������� ���������� ������������� �������
	char* Rule::Chain::getCChain(char* b)
	{
		// ��������� ����� ��������� �������
		for (int i = 0; i < this->size; i++)
			b[i] = Chain::alphabet_to_char(this->nt[i]);
		b[this->size] = 0; // ��������� ������
		return b; // ���������� �����
	}

	// ���������� ������� ��� ��������� ���������� ���������� ��������
	Greibach getGreibach()
	{
		return greibach; // ���������� ��������� ����������
	}
}