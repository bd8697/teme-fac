#include <iostream>
using namespace std;
struct ccirc
{   int c[50];
    int cap=-1;
    int coada=0;
void push(int n)
{   if((cap==n-1 && coada==0) || (cap+1==coada && coada !=0))
        {
            cout<<"Coada plina";
            return;
        }
    if(cap==n-1)
        cap=-1;
    cap++;
    cin>>c[cap];
    //cout<<cap;
}

void pop()
{
    if(coada>cap && c[coada]==0)
    {
        cout<<"Coada goala";
        return;
    }
    coada++;
   // cout<<coada;
}

void afis(int n)
{   if(coada==cap+1)
    {
        cout<<c[coada]<<' ';
        coada++;
    }
    while(coada!=cap+1)
             {cout<<c[coada]<<' ';
                if(coada==n-1 && cap!=n-1)
                coada=0;
                else
                coada++;
                }}

};



int main()
{
   ccirc coadacirculara;int n;
    cin>>n;
     coadacirculara.push(n);
     coadacirculara.push(n);
     coadacirculara.push(n);
      coadacirculara.pop();
      coadacirculara.push(n);
      coadacirculara.pop();
      coadacirculara.push(n);


//    cout<<coadacirculara.cap<<' ';
//    cout<<coadacirculara.coada<<' ';
    coadacirculara.afis(n);


return 0;}
