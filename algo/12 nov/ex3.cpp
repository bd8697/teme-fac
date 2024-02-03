#include <iostream>
using namespace std;

void push(int v[],int n,int prim,int &ultim,int x)
{
    if(ultim==n-1)
       { ultim=prim-1;
         ultim++;
         v[ultim]=x;
       }
    else
        {ultim++;
        v[ultim]=x;}
}
void pop(int v[],int n,int &prim,int ultim)
{
        if(ultim<prim)
            cout<<"Coada vida";
        else
            prim++;
}

int main()
{int v[50],n,prim=0,ultim=-1,x;
cin>>n;
for(int i=0;i<=n+n/2;i++)
{
    cin>>x;
    push(v,n,prim,ultim,x);}

    pop(v,n,prim,ultim);
    pop(v,n,prim,ultim);

    for(int i=prim;i<n;i++)
        cout<<v[i]<<' ';
    return 0;

}

