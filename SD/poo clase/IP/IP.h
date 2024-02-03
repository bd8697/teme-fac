#include <iostream>
using namespace std;
class IP{
private:
	char adresa[16];
public:
	IP();
	~IP();
	int clasa();
	friend istream & operator>>(istream &f, IP & p);
	friend ostream & operator<<(ostream &f, IP & p);
};
