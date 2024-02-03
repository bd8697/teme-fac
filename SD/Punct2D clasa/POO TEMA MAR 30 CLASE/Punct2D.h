#include <iostream>
using namespace std;
class Punct2D{
private:
	int coordx, coordy;
public:
	Punct2D();
	~Punct2D();
	Punct2D operator+(Punct2D p);
	Punct2D operator=(Punct2D p);
	bool operator==(Punct2D p);
	bool operator<(Punct2D p);
	int cadran();
	double distanta(Punct2D p);

	friend istream & operator>>(istream &f, Punct2D & p);
	friend ostream & operator<<(ostream &f, Punct2D & p);
};
