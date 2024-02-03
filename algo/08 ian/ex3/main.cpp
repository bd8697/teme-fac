#include <iostream>
using namespace std;

void summax(int a[100][100],int n)
{
    int s[100][100];
    for(int j=n-2;j>=0;j--)
        s[n-1][j]=a[n-1][j];
    for(int j=n-2;j>=0;j--)
        for(int i=n-2;i>=0;i--)
            s[i][j]=a[i][j]+max(s[i+1][j],s[i+1][j+1]);

            cout<<"Suma max:"<<s[0][0]<<endl;
            cout<<"Ex:"<<a[0][0]<<'+';
            int x=0;
            for(int i=0;i<n-1;i++)
            {   if(a[i+1][x]<a[i+1][x+1])
                    x++;
                cout<<a[i+1][x]<<'+';
            }

}

int main()
{ int n,a[100][100],m=0;
    cin>>n;
    for(int i=0;i<n;i++)
        {m++;
        for(int j=0;j<m;j++)
            cin>>a[i][j];}

 summax(a,n);

    return 0;
}
