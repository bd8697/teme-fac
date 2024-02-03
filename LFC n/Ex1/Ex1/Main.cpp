#include <iostream>
#include <string>

int main() {
	std::cout << "Wirte some text.\n";
	std::string S;
	std::getline(std::cin, S);
	std::cout << "What character are you looking for?\n";
	char character;
	int characterOccourences = 0;
	std::cin >> character;
	// std::string S = "This is some text.";
	for (int i = 0; i < S.length(); i++) {
		if (S[i] == character) {
			characterOccourences++;
		}
	}
	std::cout << "Character " << character << " occours " << characterOccourences << " times in " << S << "\n";
	return 0;
};