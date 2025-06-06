#include "stdafx.h"

namespace FST
{

	// ����������� ������ RELATION, ���������������� ������ � ����� ���������� ���������.
	RELATION::RELATION(char c, short ns)
	{
		symbol = c; // ��������� ������� ��� ��������.
		nnode = ns; // ��������� ������ ���������� ����.
	}

	// ����������� �� ��������� ��� ������ NODE.
	NODE::NODE()
	{
		n_relation = NULL; // ������������� ���������� ��������� �����.
		RELATION* relations = NULL; // ������������� ��������� �� ������ ���������.
	};

	// ����������� ������ NODE, ����������� ���������� ��������� � ��� ������ RELATION.
	NODE::NODE(short n, RELATION rel, ...)
	{
		n_relation = n; // ��������� ���������� ���������.
		RELATION* p = &rel; // ��������� �� ���������� ������ RELATION.
		relations = new RELATION[n]; // ��������� ������ ��� ������� ���������.

		// ����������� ���������� ��������� � ������ ���������.
		for (short i = 0; i < n; i++) relations[i] = p[i];
	};

	// ����������� ������ FST, ���������������� �������� �������.
	FST::FST(const char* s, short ns, NODE n, ...)
	{
		position = -1; // ������������� ������� � ������.
		string = s; // ���������� ������ ��� ���������.
		nstates = ns; // ��������� ���������� ���������.
		nodes = new NODE[ns]; // ��������� ������ ��� ������� �����.

		NODE* p = &n; // ��������� �� ���������� ����.
		// ����������� ����������� ���� � ������ �����.
		for (int k = 0; k < ns; k++) nodes[k] = p[k];

		// ������������� ������� ������� ���������.
		rstates = new short[nstates];
		memset(rstates, 0Xff, sizeof(short) * nstates); // ������������� ���������� -1 (0xFF).
		rstates[0] = 0; // ��������� ���������� ���������.
	}

	// ������� step ��������� ���� ��� � ��������, �������� ��������� ��������.
	bool step(FST& fst, short*& rstates) {
		bool rc = false; // ����, �����������, ��� �� �������� �������.
		std::swap(rstates, fst.rstates); // ����� ������� ��������� � ����������� ��������.

		// ������ �� ���� ���������� ��������.
		for (short i = 0; i < fst.nstates; i++)
		{
			// ��������, ������������� �� ������� ��������� ������� �������.
			if (rstates[i] == fst.position)
				for (short j = 0; j < fst.nodes[i].n_relation; j++)
					// ��������, ������������� �� ������ ��������.
					if (fst.nodes[i].relations[j].symbol == fst.string[fst.position]) {
						fst.rstates[fst.nodes[i].relations[j].nnode] = fst.position + 1; // ��������� ������ ���������.
						rc = true; // ��������� ����� ��������.
					};
		};
		return rc; // ������� ���������� ���������� ��������.
	};

	// ������� execute ��������� ��������� ������ �������� ���������.
	bool execute(FST& fst)
	{
		short* rstates = new short[fst.nstates]; // ��������� ������ ��� ������� ���������.
		memset(rstates, 0xff, sizeof(short) * fst.nstates); // ������������� ���������� -1.
		short lstring = strlen(fst.string); // ����� �������������� ������.
		bool rc = true; // ����, ����������� �� �������� ����������.

		// ������ �� ���� �������� ������.
		for (short i = 0; i < lstring && rc; i++)
		{
			fst.position++; // ���������� ������� �������.
			rc = step(fst, rstates); // ���������� ������ ����.
		};
		delete[] rstates; // ������������ ������.

		// ������� ����������: ������� �� ������� ������ ��������� ���������.
		return (rc ? (fst.rstates[fst.nstates - 1] == lstring) : rc);
	};
}