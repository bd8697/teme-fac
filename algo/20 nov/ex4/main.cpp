#include <iostream>
using namespace std;

int cautarecresc(int a[],int k,int ec,int eccresc,int nrc)
{if(nrc==k)
            return a[eccresc];

    if(a[eccresc]<=a[ec])
            {eccresc=ec;
              cautarecresc(a,k,ec+1,eccresc,nrc+1);}
        else
             cautarecresc(a,k,ec+1,eccresc,nrc);

}

int main()
{int n,k,a[100];
cin>>k;cin>>n;
for(int i=0;i<n;i++)
    cin>>a[i];
cout<<"Elementul de pe poz. "<<k<<" este "<<cautarecresc(a,k,1,0,1);


    return 0;
}
