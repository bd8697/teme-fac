#include <iostream>
using namespace std;

void push(int v[],int &vf,int x,int n)
{
    if(vf==n)
        cout<<"Stiva plina";
    else
        {vf=vf+1;
        v[vf]=x;}
}
void pop(int v[],int &vf)
{
    if(vf==0)
        cout<<"stiva vida";
    else
        vf=vf-1;
}
int top(int v[],int vf)
{
    return v[vf];
}

int main()
{int v[50],w[50],vf=-1,n,x,vf2=-1; //n dimensiune stiva, vf poz ult. elem.
cin>>n;
for(int i=0;i<n;i++)     //face stiva
{   cin>>x;
    push(v,vf,x,n);
}
for(int i=1;i<=vf;i++)    //simuleaza pop pe coada(w va reprezenta coada)
    push(w,vf2,v[i],n);

cin>>x;
push(w,vf2,x,n);          // simuleaza push pe coada(w va reprezenta coada)

for(int i=0;i<=vf2;i++)
    cout<<w[i]<<' ';

return 0;
}




