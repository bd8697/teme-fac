#include <iostream>
using namespace std;
//0= drum
//1= fara drum

void afis(int x[],int n)
{
    for(int i=1; i<=n; i++) cout<<x[i]<<" ";
    cout<<'1'<<endl;
}

int sol(int a[100][100],int x[],int k,int n)
{
    if(k>1) if(a[x[k]][x[k-1]]==1) return 0;
    if(k==n) if(a[x[1]][x[n]]==1) return 0;
    return 1;
}

void backtrack(int a[100][100],int x[],int p[],int k,int n)
{
    for(int i=1; i<=n; i++)
        if(p[i]==0)
        {
            x[k]=i;
            if(x[1]==1)
            {p[i]=1;
            if(sol(a,x,k,n))
                if(k==n)
                    afis(x,n);
                else backtrack(a,x,p,k+1,n);
            p[i]=0;
        }}

}
int main()
{
    int n;
    int a[100][100];
    int x[100];
    int p[100];

    cin>>n;
    for(int i=1; i<=n; i++)
        for(int j=1; j<=n; j++)
            cin>>a[i][j];
    backtrack(a,x,p,1,n);
    return 0;
}
