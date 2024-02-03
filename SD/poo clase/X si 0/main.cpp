#include <iostream>
#include "munte.h"
using namespace std;

int main(){
	int n;
	cin >> n;
	munte * v = new munte[n];
	for (int i = 0; i < n; i++)
		cin >> v[i];
	for(int i=0;i<n;i++)
        {v[i].sortare(i);
         for(int j=0;j<10;j++)
            cout<<v[i].numevarf[j]; // numevarfuri sortate
        }

    for(int i=0;i<n;i++)
    {
        if(v[i].unic()==1)
            cout<<"Lista de varfuri a muntelui "<<v[i].nume<<" e unica";
        else
            cout<<"Lista de varfuri a muntelui "<<v[i].nume<<" NU e unica";
    }

    return 0;
}


