#include "Munte.h"
Munte::Munte() {
	this->denumire[20] = NULL;
	this->n = 0;
}
Munte::~Munte(){
}
istream& operator >> (istream &f, Munte &p) {
	cout << "Numele muntelui si numarul de varfuri este: ";
	f >> p.denumire >> p.n;
	p.Varfuri = new Varf [p.n];
	for (int i = 0; i < p.n; i++)
		f >> p.Varfuri[i];
	return f;
}
ostream& operator << (ostream &f, Munte p) {
	f << p.denumire << "\n";
	for (int i = 0; i < p.n; i++)
		f << p.Varfuri[i] << " ";
	f << "\n";
	return f;
}
int Munte::getn() {
	return this->n;
}
Varf* Munte::getVarfuri() {
	return this->Varfuri;
}
void Munte::sortare() {
	sort(&Varfuri[0], &Varfuri[n]);
}