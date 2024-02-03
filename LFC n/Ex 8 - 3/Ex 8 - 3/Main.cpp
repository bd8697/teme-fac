#include <iostream>
#include <iterator>
#include <string>
#include <vector>
#include <ctime>

int main() {
	int triesLeft = 5;
	std::vector<std::string> Vec{ "CAMIOANE", "VEVERITA", "GEM", "CUIE", "CUTIE", "CUVANT", "ANANAS" };
	std::srand(std::time(nullptr));
	std::string word = Vec[rand() % Vec.size()];
	std::vector<int> guessed;
	int toGuess = word.size();
	char letter;
	bool didGuess = false;
	for (int i = 0; i < word.size(); i++) {
		std::cout << "_ ";
		guessed.push_back(0);
	}
	std::cout << "\n";
	while (triesLeft > 0 && toGuess > 0) {
		didGuess = false;
		std::cout << "Introdu litera.\n";
		std::cin >> letter;
		for (int i = 0; i < word.size(); i++) {
			if ((word[i] == letter || toupper(word[i]) == letter || tolower(word[i]) == letter) && guessed[i]==0) {
				guessed[i] = 1;
				toGuess--;
				didGuess = true;
			}
			if (guessed[i] == 1) {
				std::cout << word[i] << " ";
			}
			else {
				std::cout << "_ ";
			}
		}
		std::cout << "\n";
		if (didGuess == false) {
			triesLeft--;
			if (triesLeft == 1) {
				std::cout << "Gresit. Inca " << triesLeft << " incercare.\n";
			}
			else if (triesLeft == 0) {
				for (int i = 0; i < word.size(); i++) { std::cout << word[i] << " "; }
			}
			else {
				std::cout << "Gresit. Inca " << triesLeft << " incercari.\n";
			}
		}
	}
	if (toGuess > 0) {
		std::cout << "\nAi pierdut. Ai ghicit doar " << (word.size() - toGuess) / (float) word.size() * 100 << "% din litere.\n";
	}
	else {
		std::cout << "Bravo smechere!\n";
	}
	return 0;
};