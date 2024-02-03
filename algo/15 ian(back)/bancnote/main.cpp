#include <iostream>
using namespace std;

int suma(int a[],int st[],int k,int S)
{
    int i,x=0;

    for(i=1; i<=k; i++)
        x=x+st[i]*a[i];

    return x;

}

void backtrack(int a[],int st[],int b[],int k,int S,int n)
{
    int ok;
    for(int i=0; i<=S/a[k]; i++)
    {
        st[k]=i;

        if(suma(a,st,k,S)==S)
        {
            ok=1;

            for(int j=1; j<=k; j++)
                if(b[j]<st[j])
                {
                    ok=0;
                    break;
                }
            if(ok==1)
            {
                cout<<endl;
                for(int j=1; j<=k; j++)
                {
                    cout<<st[j]<<" * "<<a[j]<<"  "<<endl;
                }
            }
        }
        else

            if(suma(a,st,k,S)<S && k<n)
                backtrack(a,st,b,k+1,S,n);

    }
}


int main()
{
    int a[100],b[100],n,S,st[100];
    cout<<"n=";
    cin>>n;
    cout<<"S=";
    cin>>S;

    for(int i=1; i<=n; i++)
    {
        cin>>a[i];
        cin>>b[i];
    }

    backtrack(a,st,b,1,S,n);
    return 0;
}
