#include <iostream>

using namespace std;

int main()
{int n,a[50][50],nr=0,ok=1;
cin>>n;
for(int i=0;i<n;i++)
    for(int j=0;j<n;j++)
        cin>>a[i][j];
    for(int j=0;j<n;j++)
    {
    for(int i=0;i<n;i++)
        if(a[i][j]<=0)
        ok=0;
        if(ok==1)
    nr++;
    ok=1;}
    cout<<nr;
 return 0;}

