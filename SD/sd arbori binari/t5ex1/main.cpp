#include <iostream>
using namespace std;

struct nod {
    int info;
    int vizitat=0;
    nod* st;
    nod* dr;
};


nod *creare()
{
int n;
nod *c=new nod;
cout<<"introdu cheia nodului";
cin>>n;
if(n!=0)
{
c->info=n;
c->st=creare();
c->dr=creare();
return c;
}
else return(NULL);
}

void afisare(nod* rad) //doar sa vad daca-s toate, nu se afiseaza intr-o ordine anume
{
    cout<<rad->info<<' ';
    if(rad->st!=NULL)
    afisare(rad->st);
    if(rad->dr!=NULL)
    afisare(rad->dr);
    return;
}

void RSD(nod* rad)
    {int i=0;
    nod* v[10];
    cout<<rad->info<<' ';
    v[0]=rad;
    i++;
    while(i>=0)
    {
         while(rad->st!=NULL && rad->st->info!=1)
        {
            rad=rad->st;
            cout<<rad->info<<' ';
            v[i]=rad;
            i++;}
        i--;
        while(v[i]->vizitat==1)
            i--;
            if(i<0)
                break;
            rad=v[i];
            rad->vizitat=1;
        if(rad->dr!=NULL && rad->dr->vizitat==0)
        {
          rad=rad->dr;
         cout<<rad->info<<' ';
         i++;
         v[i]=rad;
            i++;}

        }

    }


int main()
{
    nod* Romica=creare();
   // afisare(Romica);
    RSD(Romica);
    return 0;
}


/*nod* cauta( nod* nodc, int v )
{
    if( nodc == NULL )
        return NULL;
    if( nodc->info == v )
        return nodc;
    if( nodc->info > v )
        return cauta( nodc->st, v );
    else
        return cauta( nodc->dr, v );
}

void insereaza( nod* nodc, int v )
{
    if( nodc == NULL ) {
        nodc = new nod( );
        nodc->info=v;
        return;
    }else
    if( nodc->info > v )
        insereaza( nodc->st, v );
    else
        insereaza( nodc->dr, v );
}
*/
