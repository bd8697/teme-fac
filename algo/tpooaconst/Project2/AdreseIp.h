#include <iostream>
#include <string.h>
using namespace std;
class AdresaIp {
private:
	char adresa[15];
public:
	AdresaIp();
	~AdresaIp();
	friend istream& operator >> (istream &f, AdresaIp &p);
	unsigned VerificareTipA();
	unsigned VerificareBroadcast();
};
