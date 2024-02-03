#include "Varf.h"
class Munte {
private:
	char denumire[20];
	int n;
	Varf *Varfuri;
public:
	Munte();
	~Munte();
	int getn();
	Varf* getVarfuri();
	void sortare();
	friend istream& operator >> (istream &f, Munte &p);
	friend 	ostream& operator <<(ostream& f, Munte p);
};
