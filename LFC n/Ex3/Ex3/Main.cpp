#include <iostream>
#include <iterator>
#include <string>

int main() {
	std::string S;
	std::string S1;
	std::string S2;
	std::string S_aux;
	std::cout << "Wirte some text.\n";
	std::getline(std::cin, S);
	int S_length = S.length();
	S_aux = S;
	std::cout << "Wirte first string.\n";
	std::getline(std::cin, S1);
	std::cout << "Wirte second string.\n";
	std::getline(std::cin, S2);
	for (int i = 0; i < S_length;i++) {
		S_aux[i] = S[S_length-1-i];
	}
	S = S_aux;
	std::cout << S_aux;

	/*int i = 0;
	while (true) {
		i = S.find(S1, i);
		// if (index == std::string::npos) break;
		S.replace(i, S2.length(), S2);
		i += S2.length();
	}*/
	return 0;
};