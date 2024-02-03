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
{char s[30];
int v[50],w[50],vf=0,n=20,k=0;
cin.get(s,20);
for(int i=0;i<strlen(s);i++)
{ if(strchr("0123456789",s[i]))
   {
       w[k]=s[i];
       k++;
   }
   else if(s[i]=='(')
       push(v,vf,s[i],n);
    else if(s[i]==')')
      while(v[vf])

}

return 0;


}
