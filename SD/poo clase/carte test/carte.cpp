#include "carte.h"
#include <iostream>
#include<string.h>
using namespace std;

carte::carte(char* n, int p, char* a)
{
	strcpy(nume, n);
	pret = p;
	strcpy(autori, a);

	
}

carte::~carte() {}

int carte::getpret()
{
	return pret;
}

int carte::nrautori()
{
	char *p;
	int nr = 0;
	p = strtok(autori, ";");
	while (p != NULL)
	{
		nr++;
		p = strtok(NULL, ";");
	}
	return nr;
}




istream& operator >> (istream& f, carte& C)
{
	f >> C.nume >> C.pret >> C.autori;
	return f;
}

ostream& operator << (ostream& f, carte C)
{
	f << "(" << C.nume << ", " << C.pret<<","<<C.autori;
	
	return f;
}