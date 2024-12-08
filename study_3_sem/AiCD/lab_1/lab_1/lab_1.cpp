#include <iostream>
using namespace std;

void tower(int N, int k, int i) {
	if (N == 1)
		cout << "переместить диск 1 с " << i << " на " << k << " стержень" << endl;
	else {
		int tmp = 6 - i - k;
		tower(N - 1, tmp, i);
		cout << "переместить диск " << N << " с " << i << " на " << k << " стержень" << endl;
		tower(N - 1, k, tmp);
	}
}

int main() {
	setlocale(LC_CTYPE, "Russian");
	int N, k;
	cout << "Введите количество дисков: ";
	cin >> N;
	cout << "Введите номер конечного стержня (2-ой или 3-ий): ";
	cin >> k; cout << endl;
	if (N < 1 || k > 3 || k < 2)
		cout << "Введены некорректные данные";
	else
		tower(N, k, 1);
}