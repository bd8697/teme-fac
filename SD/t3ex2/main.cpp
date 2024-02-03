#include <iostream>
using namespace std;
int ok=0;
int drum(int a[50][50],int i,int y,int n)
{

    for(int j=0;j<n;j++)
    {
        if(i==y)
           ok=1;
        else
        if(a[i][j]==1)
        {
            return drum(a,j,y,n);
        }
    }

}

int main()
{   int n;int a[50][50];
    cout<<"cate noduri:";
    cin>>n;
    cout<<"Citeste matricea";
    for(int i=0;i<n;i++)
        for(int j=0;j<n;j++)
            cin>>a[i][j];
    int x,y;
    cout<<"Din nodul :";
    cin>>x;
    cout<<"In nodul :";
    cin>>y;
    x=x-1;
    y=y-1;
    drum(a,x,y,n);
    if(ok==1)
        cout<<"exista drum intre x si y";
    else
        cout<<"Nu exista drum intre x si y";
    return 0;
}
