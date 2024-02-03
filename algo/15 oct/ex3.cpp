#include <iostream>

using namespace std;

int main()
{int a[50],n,poz=0,neg=0;
cin>>n;
for(int i=0;i<n;i++)
  {cin>>a[i];
  if(a[i]<0)
    neg++;
  else if(a[i]>0)
    poz++;
  }
  cout<<poz<<' '<<neg;
  return 0;}



