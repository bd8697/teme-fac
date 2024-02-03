#include "Munte.h"
int main() {
	int NrMunti;
	cin >> NrMunti;
	Munte *a = new Munte[NrMunti];
	for (int i = 0; i < NrMunti; i++)
		cin >> a[i];
	for (int i = 0; i < NrMunti; i++)
		a[i].sortare;
	for (int i = 0; i < NrMunti; i++)
		cout << a[i] << "\n";
	system("pause");
	return 0;
}