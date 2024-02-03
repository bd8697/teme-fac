#include <iostream>

using namespace std;

int main()
{int a[50],n,s=0,nr=0;
float ma;
cin>>n;
for(int i=0;i<n;i++)
  {cin>>a[i];
  nr++;
  s=s+a[i];}
  ma=s/nr;
 cout<<ma;

  return 0;}

