#include <iostream>
using namespace std;

void summax(int a[100][100],int m,int n)
{
    int s[100][100];
    s[m-1][n-1]=a[m-1][n-1];
    for(int j=n-2;j>=0;j--)
        s[m-1][j]=a[m-1][j]+s[m-1][j+1];
    for(int i=m-2;i>=0;i--)
        s[i][n-1]=a[i][n-1]+s[i+1][n-1];
    for(int i=m-2;i>=0;i--)
        for(int j=n-2;j>=0;j--)
            {
                //s[i][j]=a[i][j]+max(3,10);
                s[i][j]=a[i][j]+max(s[i+1][j],s[i][j+1]);
            }
            cout<<"Suma max:"<<s[0][0]<<endl;
            cout<<"Ex:"<<a[0][0]<<'+';
            int i=0;int j=0;
            while(i<n-1 && j<m-1)
            {   if(a[i+1][j]>=a[i][j+1])
                    i++;
                else
                    j++;
                cout<<a[i][j]<<'+';}
                cout<<a[m-1][n-1];

}

int main()
{ int n,m,a[100][100];
    cin>>m;
    cin>>n;
    for(int i=0;i<m;i++)
        for(int j=0;j<n;j++)
            cin>>a[i][j];
 summax(a,m,n);

    return 0;
}
