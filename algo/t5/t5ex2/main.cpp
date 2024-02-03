#include <iostream>
using namespace std;

struct nod {
    int info;
    nod* st;
    nod* dr;
};


void afisare(nod* rad) //doar sa vad daca-s toate, nu se afiseaza intr-o ordine anume
{
    cout<<rad->info<<' ';
    if(rad->st!=NULL)
    afisare(rad->st);
    if(rad->dr!=NULL)
    afisare(rad->dr);
    return;
}

void creare(int a[],int b[],int n ,nod* rad)
{
    int poz[50];int ok=0;
    for(int i=0;i<n;i++)
        for(int j=0;j<n;j++)
            if(a[i]==b[j])
                {poz[i]=j;
                break;}
    nod* c=new nod;nod* aux=new nod;
    c->info=a[0];
    for(int i=1;i<n;i++)
        {
            nod* nou=new nod;
            nou->info=a[i];
             if(poz[i]>poz[0] && ok==0)
                {aux=rad;
                aux->dr=nou;
                c=nou;
                ok=1;}
            else
            if(poz[i]<poz[i-1])
            {
                c->st=nou;
                aux=c;
                c=nou;
            }
           else
           {
               if(poz[i-1]>poz[i-2])
               {
                c->dr=nou;
                aux=c;
                c=nou;
               }
               else
               {
                   aux->dr=nou;
                   c=nou;
               }
           }

}

afisare(rad);
}


int main()
{   int rsd[50];
    int srd[50];
    int n;cin>>n;
    for(int i=0;i<n;i++)
        cin>>rsd[i];
    for(int i=0;i<n;i++)
        cin>>srd[i];
    nod* Romica=new nod;
creare(rsd,srd,n,Romica);


    return 0;
}


