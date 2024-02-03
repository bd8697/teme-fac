#include <iostream>
#include <string>
#include <vector>

int main() {
	std::vector<std::string> Vec;
	std::string word;
	std::string auxWord;
	std::cout << "Introdu cuvant: \n";
	std::cin >> word;
	for (int i = 0; i < word.length()-1; i++) {
		auxWord += word[i];
		Vec.push_back(auxWord);
		std::cout << auxWord << "\n";
	}
	return 0;
};