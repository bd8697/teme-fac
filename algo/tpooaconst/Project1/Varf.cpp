#include "Varf.h"
istream& operator >> (istream &f, Varf &p) {
	cout << "Numele Varfului si altitudinea lui este : ";
	f >> p.denumire >> p.altitudine;
	return f;
}
ostream& operator <<(ostream &f, Varf p) {
	f << p.denumire << " " << p.altitudine << "\n";
	return f;
}
Varf::Varf() {
	this->altitudine = 0;
	this->denumire[20] = NULL;
}
Varf::~Varf() {
}
bool Varf::operator <(Varf p) {
	if (strcmp(denumire, p.denumire) < 0)
		return true;
	return false;
}
bool Varf::operator >(Varf p) {
	if (strcmp(denumire, p.denumire) > 0)
		return true;
	return false;
}
Varf Varf::operator =(Varf *p) {
	strcpy_s(this->denumire, p->denumire);
	this->altitudine = p->altitudine;
	return *(this);
}