#include "Player.h"
Player::Player() {
	this->denumire[10] = NULL;
	this->simbol = 'x';
}
Player::~Player() {
}
istream &operator >> (istream &f, Player &p) {
	cout << "Numele jucatorului: ";
	f >> p.denumire;
	cout << "Alege simbolul: ";
	f >> p.simbol;
	while(p.simbol != 'x'&&p.simbol != '0') {
		cout << "Alege dintre x si 0!\n";
		cout << "Alege simbolul: ";
		f >> p.simbol;
	}
	return f;
}
unsigned Player::completeaza(char a[3][3]) {
	cout << this->denumire << " alege pozitia: ";
	int x, y;
	cin >> x >> y;
	while (x < 0 || x>2) {
		cout << "reintrodu x: ";
		cin >> x;
	}
	while (y < 0 || y>2) {
		cout << "reintrodu y: ";
		cin >> y;
	}
	while(a[x][y] == 'x' || a[x][y] == '0') {
		cout << "Pozitia e ocupata,introdu alta pozitie: ";
		cin >> x >> y;
		while (x < 0 || x>2) {
			cout << "reintrodu x: ";
			cin >> x;
		}
		while (y < 0 || y>2) {
			cout << "reintrodu y: ";
			cin >> y;
		}
	}
	a[x][y] = this->simbol;
	for (unsigned i = 0; i <= 2; i++) {
		for (unsigned j = 0; j <= 2; j++)
			cout << a[i][j] << " ";
		cout << "\n";
	}
	if ((a[x][(y + 2) % 3] == this->simbol&&a[x][(y + 1) % 3] == this->simbol) || (a[(x + 2) % 3][y] == this->simbol&&a[(x + 1) % 3][y] == this->simbol)) {
		cout << this->denumire << " a castigat!\n";
		return 0;
	}
	else if(a[0][0] == this->simbol&&a[1][1] == this->simbol&&a[2][2]==this->simbol){
		cout << this->denumire << " a castigat!\n";
		return 0;
	}
	else if(a[2][0] == this->simbol&&a[1][1] == this->simbol&&a[0][2] == this->simbol) {
		cout << this->denumire << " a castigat!\n";
		return 0;
	}
	return 1;
}