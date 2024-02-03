#include <iostream>
#include <string.h>
#include <algorithm>
using namespace std;
class Varf {
private:
	char denumire[20];
	int altitudine;
public:
	Varf();
	~Varf();
	friend istream& operator >> (istream &f, Varf &p);
	friend 	ostream& operator <<(ostream& f, Varf p);
	Varf operator =(Varf *p);
	bool operator <(Varf p);
	bool operator >(Varf p);
};