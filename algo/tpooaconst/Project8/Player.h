#include <iostream>
using namespace std;
class Player {
private:
	char simbol,denumire[10];
public:
	Player();
	~Player();
	friend istream& operator >> (istream &f, Player &p);
	unsigned completeaza(char a[3][3]);
};
