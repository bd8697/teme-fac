#include <iostream>

using namespace std;

int main()
{int n,a[50][50],i,j;
cin>>n;
for(int nr=1;nr<=n;nr++)
{for( i=0;i<n;i++)
        a[i][i+nr-1]=nr;
    for(i=nr-1;i<n;i++)
         a[i][i-nr+1]=nr;
}
for(i=0;i<n;i++)
{
    cout<<endl;
    for(int j=0;j<n;j++)
        cout<<a[i][j];
}
return 0;}

