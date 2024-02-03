#include "AdreseIp.h"
AdresaIp::AdresaIp() {
	this->adresa[15] = NULL;
}
AdresaIp::~AdresaIp() {
}
istream& operator >> (istream &f, AdresaIp &p) {
	f >> p.adresa;
	return f;
}
unsigned AdresaIp::VerificareTipA() {
	char *a, sep[] = ".", *context = NULL;
	a = strtok_s(this->adresa, sep, &context);
	if (strcmp(a, "128") < 0||(strcmp(a,"0")>0&&strlen(a)<3))
		return 1;
	return 0;
}
unsigned AdresaIp::VerificareBroadcast() {
	char *a, sep[] = ".", *context = NULL;
	a = strtok_s(this->adresa, sep, &context);
	if (strcmp(a, "191") > 0 && strcmp(a, "224") < 0)
	return 1;
	return 0;
}