#include <iostream>
using namespace std;
struct varf{
char numevarf[10];
int h;};
class munte{
private:
	char nume[10];
	varf v[10];
public:
	munte();
	~munte();
	bool unic();
	void sortare();

	friend istream & operator>>(istream &f, munte & p);
	friend ostream & operator<<(ostream &f, munte & p);
};
