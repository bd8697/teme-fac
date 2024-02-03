#include <iostream>
#include <math.h>
#include <algorithm>
#include "Punct2D.h"
using namespace std;
int main(){
	int n;
	cin >> n;
	Punct2D * v = new Punct2D[n];
	Punct2D a, b, c;
	cin >> a;
	cin >> b;
	cout << a << b;
	if (a == b)
		cout << "puncte egale" << endl;
	c = a + b;
	cout << c;
	cout << a.cadran() << endl;
	for (int i = 0; i < n; i++){
		cin >> v[i];
	}
	int k[4] = { 0 };
	for (int i = 0; i < n; i++){
		k[v[i].cadran()]++;
	}
	int max = k[0];
	int poz = 0;;
	for (int i = 1; i < n; i++){
		if (k[i]>max){
			max = k[i];
			poz = i;
		}
	}
	cout << "CEL MAI POPULAR CADRAN ESTE: " << poz << " " << endl;

	for (int i = 0; i < n; i++){
		cout << v[i] << endl;
	}
	cout << v[0].distanta(v[n - 1]) << endl;
}
