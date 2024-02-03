#include <iostream>

using namespace std;

int main()
{int n,a[50][50],b[50][50],x[100],y[100],prod=0,nr=0;
cin>>n;
for(int i=0;i<n;i++)
    for(int j=0;j<n;j++)
    cin>>a[i][j];
for(int i=0;i<n;i++)
    for(int j=0;j<n;j++)
    cin>>b[i][j];
for(int i=0;i<n;i++)
 for(int j=0;j<=i;j++)
{   y[nr]=b[i][j];
    x[nr]=a[i][j];
nr++;}

for(int i=0;i<=n*2+1;i++)
for(int j=0;j<=n*2+1;j++)
prod=prod+x[i]*y[j];
cout<<prod;
 return 0;}


