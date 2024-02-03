#include <iostream>
using namespace std;

int main()
{int n,ok=1;
int v[50],a[50];
cin>>n;
for(int i=0;i<n;i++)
    cin>>v[i];
for(int i=0;i<n;i++)
    a[i]=0;
for(int i=0;i<n;i++)
    a[v[i]]++;
for(int i=0;i<n;i++)
    if(a[i]!=1)
      ok=0;
    cout<<ok;
return 0;}
