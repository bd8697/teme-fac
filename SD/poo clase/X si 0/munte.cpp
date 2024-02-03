#include <iostream>
#include "munte.h"
#include <agorithm>
#include <string.h>
using namespace std;
munte::munte(void){

}

munte munte::sortare(int k){
    int aux;
    char auxc[10];
	for(int i=0;i<9;i++)
       for(int j=i;j<10;j++)
         if(p.v[k].h[j]>p.v[k].h[i])
       {
           aux=p.v[k].h[i];
           p.v[k].h[i]=p.v[k].h[j];
           p.v[k].h[j]=aux;
           strcpy(auxc,p.v[k].numevarf[i]);
           strcpy(p.v[k].numevarf[i],p.v[k].numevarf[j]);
           strcpy(p.v[k].numevarf[j],auxc);
       }
       return p;
}

bool munte::unic()
{
    for(int i=0;i<9;i++)
       for(int j=i;j<10;j++)
        if(strcmp(p.v[i].numevarf,p.v[j].numevarf)==0)
            return 0;
    return 1;
}

istream & operator>>(istream &f, munte & p){
	f >> p.nume;
	for(int i=0;i<10;i++)
        f>>p.v[i].numevarf>>p.v[i].h;
	return f;
}

ostream & operator<<(ostream &f, munte & p){
	for(int i=0;i<10;i++)
        f<<p.v[i].numevarf<<endl;
	return f;
}

