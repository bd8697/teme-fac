#include <iostream>
using namespace std;

void sortmat(int a[50][50],int n)
{
    int aux;
    for(int i=0;i<n-1;i++)
        for(int j=i+1;j<n;j++)
            if(a[i][0]>a[j][0])

                    for(int x=0;x<=a[j][0];x++)
                    {
                        aux=a[i][x];
                        a[i][x]=a[j][x];
                        a[j][x]=aux;}
 for(int i=0;i<n;i++)
        {
            cout<<endl;
        for(int j=0;j<=a[i][0];j++)
            cout<<a[i][j];}

}

void interclasare(int a[50][50],int n)
{   int w[300],v[300];
    int lungimev=0;
    for(int i=0;i<a[0][0];i++)
    {v[i]=a[0][i+1];
    lungimev++;}
    int lungimew=0,i=0,j=1,c=1;
    while(c<n)  // c e nr liniei
    {
        while(i<lungimev && j<=a[c][0])
        {
           if(v[i]<a[c][j])
            {
            w[lungimew]=v[i];
            lungimew++;
            i++;}
            else
            {
            w[lungimew]=a[c][j];
            lungimew++;
            j++;}
            }
        if(i<lungimev)
        while(i<lungimev)
            {
             w[lungimew]=v[i];
             lungimew++;
             i++;}
        if(j<=a[c][0])
            while(j<=a[c][0])
            {
             w[lungimew]=a[c][j];
             lungimew++;
             j++;}
        i=0;
        j=1;
        c++;
        lungimev=0;
        for(int i=0;i<lungimew;i++)
         {v[i]=w[i];
         lungimev++;}
        if(c<n)
        lungimew=0;
    }
    for(int i=0;i<lungimew;i++)
        cout<<w[i];
}







int main()
{ int n,a[50][50],l;
cin>>n;
for(int i=0;i<n;i++)
{    cin>>l;
    a[i][0]=l;
    for(int j=1;j<=l;j++)
        cin>>a[i][j];
}
   sortmat(a,n);
   cout<<endl;
   interclasare(a,n);
    return 0;
}
