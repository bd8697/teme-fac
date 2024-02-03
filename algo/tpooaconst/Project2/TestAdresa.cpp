#include "AdreseIp.h"
int main() {
	int n;
	cin >> n;
	AdresaIp *v = new AdresaIp[n];
	int tipA = 0, tipBroadcast = 0;
	for (int i = 0; i < n; i++) {
		cin >> v[i];
		tipA = tipA + v[i].VerificareTipA();
		tipBroadcast = tipBroadcast + v[i].VerificareBroadcast();
	}
	cout << "Numarul de adrese ip de tip A este " << tipA << "\n";
	cout << "Numarul de adrese ip de tip Broadcast este " << tipBroadcast << "\n";
	system("pause");
	return 0;
}