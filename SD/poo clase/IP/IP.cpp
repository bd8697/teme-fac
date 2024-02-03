#include <iostream>
#include "IP.h"
#include <string.h>
using namespace std;
IP::IP(void){

}

int IP::clasa(){
    char * nr;
    nr = strtok (adresa,".");
	int tip=atoi(nr);
		if(tip<128)
            return 1;
        else if(tip<192)
            return 2;
        else if(tip<224)
            return 3;
        else if(tip<240)
            return 4;
        else if(tip<256)
            return 5;
        else
            cout<<"Adresa IP invalida";

}

istream & operator>>(istream &f, IP & p){
	f >> p.adresa;
	return f;
}
ostream & operator<<(ostream &f, IP & p){
	f <<p.adresa<<' ';
	return f;
}

