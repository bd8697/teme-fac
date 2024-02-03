#include <iostream>
#include "IP.h"
using namespace std;

int tipA(IP* v[]){
   int nr=0;
    for(int i=0;i<n;i++)
        if(clasa(v[i])==1)
            nr++;
    return nr;
}

IP* citire(){
    int n;
	cin >> n;
	IP * v = new IP[n];
	for (int i = 0; i < n; i++){
		cin >> v[i];
	}
	return v;
}


int main(){
   
   IP *v=citire();
	
   cout<<tipA(v)<<" adrese de tip A";
return 0;}
