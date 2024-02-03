#include <iostream>
using namespace std;

void subsircom(int a[],int b[],int n,int m)
{
    int l[100][100],ec=0;
    for(int i=0; i<=n; i++)
        l[i][0]=0;
    for(int j=0; j<=m; j++)
        l[0][j]=0;
    for(int i=1; i<=n; i++)
        for(int j=1; j<=m; j++)
        {
            if(a[i]==b[j])
                l[i][j]=1+l[i-1][j-1];
            else
                l[i][j]=max(l[i-1][j],l[i][j-1]);
        }
    cout<<"Subsir max are lungimea:"<<l[n][m]<<' '<<endl;


    for(int i=0; i<=n; i++)
    {
        cout<<endl;
        for(int j=0; j<=m; j++)
            cout<<l[i][j]<<' ';  // nu se cere
    }
    cout<<endl<<"Elem subsirului maximal sunt:"<<' ';
    for(int i=1; i<=n; i++)
        for(int j=1; j<=m; j++)
            if(l[i][j]>ec)
            {
                cout<<a[i]<<' ';
                ec++;
            }


}

int main()
{
    int a[100],b[100],n,m;
    cin>>n;
    cin>>m;
    for(int i=1; i<=n; i++)
        cin>>a[i];
    for(int i=1; i<=m; i++)
        cin>>b[i];
    subsircom(a,b,n,m);


    return 0;
}
