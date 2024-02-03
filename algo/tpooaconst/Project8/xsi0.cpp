#include "Player.h"
int main() {
	Player a, b;
	cin >> a >> b;
	char c[3][3];
	for (unsigned i = 0; i <= 2; i++)
		for (unsigned j = 0; j <= 2; j++)
			c[i][j] = '_';
	for (unsigned i = 0; i <= 2; i++) {
		for (unsigned j = 0; j <= 2; j++)
			cout << c[i][j] << " ";
		cout << "\n";
	}
	unsigned k = 0;
	while (a.completeaza(c)) {
		k++;
		if (k == 9) {
			cout << "egalitate!\n";
			break;
		}
		if (b.completeaza(c) == 0) {
			break;
		}
		k++;
	}
	system("pause");
	return 0;
}