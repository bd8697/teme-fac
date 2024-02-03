#include <iostream>
using namespace std;


int valid(int x[],int a[100][100],int k)
{ if(a[x[k]][x[k-1]]==0)
    return 0;
  for(int i=1;i<k;i++)
    if(x[i]==x[k])
        return 0;
  return 1;

}



void comis(int a[100][100],int n)
{   int x[100];
    int k=1;
    for(int i=0;i<=n;i++)
        x[i]=0;
    while(k>=1)
      {
          if(k==n)
        {if(a[x[n-1]][0]==1) //daca e drum de la ultimu elem la 1
            {for(int i=0;i<=n;i++)
                cout<<x[i];
             cout<<' ';}
         k--;}
      else
      {if(x[k]<n-1)
        x[k]=x[k]+1;
        if(valid(x,a,k)==1)
            k++;
        else
        {x[k]=0;
         k--;
        }
      }//else k--; //??

}}




int main()
{ int n,a[100][100];
cin>>n;
    for(int i=0;i<n;i++)
        for(int j=0;j<n;j++)
            cin>>a[i][j];
comis(a,n);
    return 0;
}
