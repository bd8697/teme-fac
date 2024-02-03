#include <iostream>
using namespace std;

int pivot(int a[],int s,int d)
{ int i=s;int j=d; int sens=1;int aux;
while(i<j)
{
    if(a[i]>a[j])
    {aux=a[i];
    a[i]=a[j];
    a[j]=aux;
    if(sens==1)
        sens=0;
    else
        sens=1;}
    if(sens==1)
        j--;
    else
        i++;}
    return j;

    }

    void quicksort(int a[],int s,int d)
    {int p;
        if(s<d)
        {
            p=pivot(a,s,d);
            quicksort(a,s,p-1);
            quicksort(a,p+1,d);
        }
    }



int main()
{int n,a[50];
cin>>n;
for(int i=0;i<n;i++)
    cin>>a[i];
quicksort(a,0,n-1);
for(int i=0;i<n;i++)
    cout<<a[i]<<' ';
    return 0;
}
