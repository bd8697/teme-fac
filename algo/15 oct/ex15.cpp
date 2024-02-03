#include <iostream>
using namespace std;

int main()
{   int n;
     float a,b,c;
   int x[50];
   cin>>n;
   for(int i=0;i<n;i++)
    cin>>x[i];

   for(int i=0;i<n-3;i++)
   {    a=x[i];
        b=x[i+1];
        c=x[i+2];
       if(a<b && b<c)
        cout<<a<<' '<<b<<' '<<c<<' ';


   }
}
