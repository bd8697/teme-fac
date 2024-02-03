#include <iostream>
#include "carte.h"
using namespace std;

carte* citire()
{
	int n;
	cin >> n;
	carte *C = new carte[n];

	for (int i = 0; i < n; i++)
		cin >> C[i];

	return C;
}

void afisare(carte *C, int n)
{
	for (int i = 0; i < n; i++)
		cout << C[i] << "\n";
}

void cmmautori(carte *C, int n)
{
	int max = -1;

	for (int i = 0; i < n; i++)
		if (C[i].nrautori() > max)
		{
			max = C[i].nrautori();
		}
	for (int i = 0; i < n; i++)
		if(C[i].nrautori()==max)
			afisare(C, n);

}

void pretmin(carte *C, int n)
{
	int nr;
	cout << "NR cerut de autori:";
	cin >> nr;
	int min = C[0].getpret();

	for (int i = 0; i < n; i++)
		if(C[i].nrautori()==nr)
		if (C[i].getpret() < min)
		{
			min = C[i].getpret();
		}
	cout << "Pretul minim:" << min;

}

void main()
{
	carte *C = citire();
	cmmautori(C, sizeof(C));
	pretmin(C, sizeof(C));

}