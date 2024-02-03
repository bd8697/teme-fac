#include <iostream>

using namespace std;

int main()
{int n,a[50][50],v[50],aux;
cin>>n;
for(int i=0;i<n;i++)
    {cin>>v[i];
    a[0][i]=v[i];}
for(int nr=1;nr<n;nr++)
{ aux=v[n-1];
for(int i=n-1;i>0;i--)
    v[i]=v[i-1];
    v[0]=aux;

for(int i=0;i<n;i++)
    a[nr][i]=v[i];
}


    for(int i=0;i<n;i++)
{
    cout<<endl;
    for(int j=0;j<n;j++)
        cout<<a[i][j];
} return 0;}





