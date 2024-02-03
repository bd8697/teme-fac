#include <iostream>
#include <string.h>
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
        vf=vf-1;
}
int top(int v[],int vf)
{
    return v[vf];
}
int main()
{char s[30];        //vf arata nr elem din stiva
int v[50],vf=0,n=20;
cin.get(s,20);
for(int i=0;i<strlen(s);i++)
{if(s[i]=='(')
       push(v,vf,s[i],n);
    else if(s[i]==')')
      pop(v,vf);
cout<<vf<<' ';
if(vf==-1)
{
    break;
}
}
if(vf==0)
    cout<<"Parantezare corecta";
else
    cout<<"Parantezare incorecta";
return 0;


}
