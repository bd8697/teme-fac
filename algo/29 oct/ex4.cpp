#include <iostream>

using namespace std;

int main()
{int n,a[50][50],s=0;
cin>>n;
for(int i=0;i<n;i++)
    for(int j=0;j<n;j++)
        cin>>a[i][j];
    for(int i=0;i<n;i++)
    if(a[i][i]>0)
        s=s+a[i][i];
    cout<<s;
 return 0;}

