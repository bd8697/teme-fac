#include <iostream>
using namespace std;

int maxim(int a[],int s,int d)
{ if(s==d)
    return a[s];

    if(a[(s+d)/2]<=a[(s+d)/2+1])
         maxim(a,(s+d)/2+1,d);
    else
         maxim(a,s,(s+d)/2);
}



int main()
{int n,a[50];
cin>>n;
for(int i=0;i<n;i++)
    cin>>a[i];
cout<<maxim(a,0,n-1);


    return 0;
}
