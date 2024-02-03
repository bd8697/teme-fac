#include <iostream>

using namespace std;

int main()
{
   int a[50],n,aux,ok=0;
   cin>>n;
   for(int i=0;i<n;i++)
    cin>>a[i];

   for(int i=0;i<n;i++)
    for(int j=i+1;j<n;j++)
     if(a[i]>a[j])
   {
       aux=a[i];
       a[i]=a[j];
       a[j]=aux;
   }
   for(int i=0;i<n;i++)
    cout<<a[i]<<' ';
    cout<<endl;




   for(int i=0;i<n;i++)
        cin>>a[i];
   while(ok==0)
   {
       ok=1;            //daca ok e 1 nu s-a schimbat nimic,daca e 0,se schimba in continuare.
       for(int i=0;i<n;i++)
         if(a[i]>a[i+1])
       {
           aux=a[i];
           a[i]=a[i+1];
           a[i+1]=aux;
           ok=0;
       }
   }
    for(int i=0;i<n;i++)
    cout<<a[i]<<' ';


   return 0;
}
