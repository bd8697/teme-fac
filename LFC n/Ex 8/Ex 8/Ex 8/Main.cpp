#include <iostream>
#include <iterator>
#include <string>
#include <vector>

int main() {
	std::vector<std::string> Vec{ "camioane", "veverita", "gem", "cuie", "cutie", "cuvant", "a" };
	int rando = rand() % Vec.size();
	for (int i = 0; i < Vec[rando].size(); i++) {
		std::cout << "_ ";
	}


/*  td::string S;
	std::string S1;
	std::string S2;
	std::string S_aux;
	std::cout << "Wirte some text.\n";
	std::getline(std::cin, S);
	int S_length = S.length();
	S_aux = S;
	std::cout << "Wirte the first string.\n";
	std::getline(std::cin, S1);
	std::cout << "Wirte the second string.\n";
	std::getline(std::cin, S2);
	for (int i = 0; i < S_length; i++) {
		S_aux[i] = S[S_length - 1 - i];
	}
	S = S_aux;
	std::cout << S << "\n";

	int i = 0;
	while (true) {
		i = S.find(S1, i);
		if (i == std::string::npos) break; // the returned value if S.find can't find S1 in S
		S.replace(i, S1.length(), S2);
		i += S2.length();
	}
	std::cout << S; */
	return 0;
};