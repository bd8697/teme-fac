#include <iostream>
using namespace std;

void scrie(int st[],int x)
{
for(int i=1;i<=x;i++)
cout<<st[i]<<" ";
cout<<endl;
}

int solutie(int x,int k)
{
return (x==k);
}

void bkt(int st[],int p,int k,int n)
{
for (int val=st[p-1]+1;val<=n;val++)
{
st[p]=val;
if(solutie(p,k))
scrie(st,p);
else
bkt(st,p+1,k,n);
}
}

int main()
{int st[20],n,k;
cin>>n;
cin>>k;
st[0]=0;
bkt(st,1,k,n);
return 0;
}
