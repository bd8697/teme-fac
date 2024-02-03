#include <iostream>

class carte
{
private:
	char nume[50];
	int pret;
	char autori[50];

public:
	carte(char nume, int pret, char autori);
	carte();
	~carte();

	int nrautori();

	int getpret();
	
	
	friend std::istream& operator >> (std::istream&, carte&);
	friend std::ostream& operator << (std::ostream&, carte);
};