#include <iostream>

using namespace std;

int main()
{ int a[50],b[50],c[50],n;
cin>>n;
for(int i=0;i<n;i++)
    cin>>a[i];
for(int i=0;i<n;i++)
    c[i]=a[i];
for(int i=0;i<n;i++)
    b[i]=0;
for(int i=0;i<n;i++)
    for(int j=i+1;j<n;j++)
     {if(a[i]<a[j])
      b[j]++;
     else
    b[i]++;}

    for(int i=0;i<n;i++)
        a[b[i]]=c[i];
    for(int i=0;i<n;i++)
        cout<<a[i]<<' ';


    return 0;
}
