#include <iostream>
using namespace std;

void sortcresc(int a[],int n)
{ int aux;
    for(int i=0;i<n-1;i++)
        for(int j=i+1;j<n;j++)
            if(a[i]<a[j])
                {
                    aux=a[i];
                    a[i]=a[j];
                    a[j]=aux;
                }

}

void suma(int a[],int n,int s)
{ int i=0,nr=0;
    while(s>0)
        {while(s-a[i]>=0)
            {s=s-a[i];
            nr++;}
         if(nr>0)
         cout<<nr<<" bancnote de val. "<<a[i]<<", ";
        nr=0;
        i++;
        }

}

int main()
{int n,s;
int a[50];
cin>>s;
cin>>n;
for(int i=0;i<n;i++)
    cin>>a[i];
cout<<"Suma e alcatuita din: ";
sortcresc(a,n);
suma(a,n,s);

    return 0;
}
