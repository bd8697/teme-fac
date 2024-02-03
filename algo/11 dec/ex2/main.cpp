#include <iostream>
using namespace std;

struct spectacol
{float start;
 float stop;
};

void sortare(spectacol v[],int n)
{ float aux;
    for(int i=0;i<n-1;i++)
        for(int j=i+1;j<n;j++)
            if(v[i].stop>v[j].stop)
            {
                aux=v[i].stop;
                v[i].stop=v[j].stop;
                v[j].stop=aux;
                aux=v[i].start;
                v[i].start=v[j].start;
                v[j].start=aux;
            }
}

void Spec(spectacol v[],int n)
{
    int nr=1;
    int k=0;
    cout<<"Se planifica spectacolul care incepe la ora "<<v[k].start<<" si se termina la ora "<<v[k].stop<<endl;
    for(int i=1;i<n;i++)
        if(v[i].start>=v[k].stop)
            {
                k=i;
                cout<<"Se planifica spectacolul care incepe la ora "<<v[k].start<<" si se termina la ora "<<v[k].stop<<endl;
                nr++;
            }
            cout<<"Deci s-au programat "<<nr<<" spectacole.";
}
int main()
{ int n;
spectacol a[50];
cin>>n;
for(int i=0;i<n;i++)
{
    cin>>a[i].start;cin>>a[i].stop;
}
sortare(a,n);
Spec(a,n);

    return 0;
}
