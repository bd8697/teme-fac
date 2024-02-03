#include <iostream>
using namespace std;

void subsir(int v[],int n)
{
    int l[n],sol[n],poz;
    l[n-1]=1;
    sol[n-1]=n-1;
    for(int i=n-2;i>=0;i--)
    {
        l[i]=0;sol[i]=i;
        for(int j=i+1;j<=n-1;j++)
            if(v[j]>v[i] && l[j]>l[i])
                {
                 l[i]=l[j];
                 sol[i]=j;}
             l[i]=l[i]+1;
    }
    poz=0;
    for(int i=1;i<n;i++)
        if(l[i]>l[poz])
            poz=i; // poz e poz unde incepe c m lung sir
        cout<<"Lungime max:"<<l[poz]<<' '; // lpoz e lungimea c m lung sir
        cout<<"Elem subvect:"<<' ';
        while(sol[poz]!=poz)
        {
            cout<<v[poz]<<' ';
            poz=sol[poz];}
        cout<<v[poz]; // de testat pt 5 9 1 4 1 5 9 9
    }


int main()
{int v[100],n;
cin>>n;
for(int i=0;i<n;i++)
    cin>>v[i];
 subsir(v,n);
    return 0;
}
