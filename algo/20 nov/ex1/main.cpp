#include<iostream>
using namespace std;

void cautare(int a[],int s,int d,int x)
{
    int mij=(s+d)/2;
    if(x==a[mij])
        cout<<"elem "<<x<<" se afla pe poz. "<<mij+1;
    else if(s<d)
        {if(x<a[mij])
            cautare(a,s,mij-1,x);
        else
            cautare(a,mij+1,d,x);}
    else
        cout<<"Nu s-a gasit "<<x;}

        int main()
        {int n,x,a[100];
	cin>>x;cin>>n;
        for(int i=0;i<n;i++)
            cin>>a[i];
        cautare(a,1,n,x);
        return 0;

        }

