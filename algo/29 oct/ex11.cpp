#include <iostream>

using namespace std;

int main()
{
   int n,a[50][50],s=0;
   cin>>n;
   for(int i=0;i<n;i++)
    for(int j=0;j<n;j++)
   cin>>a[i][j];
   if(n%2==0)
   {
       for(int i=0;i<n/2;i++)
        for(int j=0;j<n/2;j++)
          s=s+a[i][j];
       cout<<s<<' ';
        s=0;
       for(int i=0;i<n/2;i++)
        for(int j=n/2;j<n;j++)
          s=s+a[i][j];
       cout<<s<<' ';
        s=0;
       for(int i=n/2;i<n;i++)
        for(int j=0;j<n/2;j++)
          s=s+a[i][j];
       cout<<s<<' ';
        s=0;
       for(int i=n/2;i<n;i++)
        for(int j=n/2;j<n;j++)
          s=s+a[i][j];
       cout<<s<<' ';
        s=0;
   }
   else
   {
       for(int i=0;i<n/2;i++)
        for(int j=0;j<n/2;j++)
          s=s+a[i][j];
       cout<<s<<' ';
        s=0;
       for(int i=0;i<n/2;i++)
        for(int j=n/2+1;j<n;j++)
          s=s+a[i][j];
       cout<<s<<' ';
        s=0;
       for(int i=n/2+1;i<n;i++)
        for(int j=0;j<n/2;j++)
          s=s+a[i][j];
       cout<<s<<' ';
        s=0;
       for(int i=n/2+1;i<n;i++)
        for(int j=n/2+1;j<n;j++)
          s=s+a[i][j];
       cout<<s<<' ';
        s=0;
   }

}
