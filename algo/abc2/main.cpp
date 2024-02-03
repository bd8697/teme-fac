
#include <iostream>
using namespace std;

struct arbore{

 struct nod{
	int inf;
	nod *st,*dr,*par;
};
nod *rad=NULL;
nod *ns=new nod;
void Adauga(nod* &r,int info,nod* aux)
{
	if(!r)
	{
		r=new nod;
		r->inf=info;
		r->st=r->dr=NULL;
		r->par=aux;
	}
	else
		if(info<r->inf)
            Adauga(r->st,info,r);
		else if(info>r->inf)
            Adauga(r->dr,info,r);
        else cout<<"Informatie duplicat";
}
void Creare()
{
	int info,n;
	cout<<"numar de noduri: ";
	cin>>n;
	for(int i=0;i<n;i++)
	{
		cout<<"informatia nodului "<<i<<':';
		cin>>info;
		Adauga(rad,info,rad);
	}
}

nod* Determina_minim(nod *p)
{
	while(p->st) { p=p->st; }
	return p;
}

nod* Determina_maxim(nod *p)
{
	while(p->dr) { p=p->dr; }
	return p;
}

nod* succesor(nod *p)
{ if(p->dr==NULL)
	{if(p->par!=NULL)
        return p->par;
	else cout<<"Nodul nu are succesor";}
    else
	{p=Determina_minim(p->dr);
	 return p;}
}

nod* predecesor(nod *p)
{ if(p->st==NULL)
	 cout<<"Nodul nu are predecesor";
    else
	{p=Determina_maxim(p->st);
	 return p;}
}


nod* Cauta(nod *p,int x) // returneaza nodul care va fi sters, stocat in ns
{
	if(!p) {cout<<"Nu s-a gasit elem"<<endl; return 0;}
	else if(p->inf<x) {  p=p->dr; return Cauta(p,x); }
	else if(p->inf>x) {  p=p->st; return Cauta(p,x); }
	else {
            cout<<"S-a gasit elem cu val "<<p->inf<< endl;
            return p;}
}
void Sterge()
{   nod* ns;int x;
    cout<<"Sa se stearga elem cu val:";
    cin>>x;
    ns=Cauta(rad,x);

	if(ns==0)
        cout<<"Informatia "<<ns->inf<<" NU exista in nici un nod al arborelui"<<endl;
	else
		if(ns->dr==ns->st)  //in cazul in care nodul cu inf x e frunza
		{
			if(ns->inf<ns->par->inf) ns->par->st=0;
		     else ns->par->dr=0;
		     delete ns; //elibereaza zona de memorie ocupata de elem sters
		}
		else
			if(ns->dr==0 && ns->st)  //in cazul in care nodul cu inf x are descendent stang
			{
				if(ns->par->inf<ns->inf) ns->par->dr=ns->st;
				else ns->par->st=ns->st;
				delete ns;
			}
			else
				if(ns->st==0 && ns->dr)  //nodul are descendent drept(simetric fata de else precedent)
				{
					if(ns->par->inf>ns->inf) ns->par->st=ns->dr;
					else ns->par->dr=ns->dr;
					delete ns;
				}
				else   //nodul are ambii descendenti
				{	nod* aux;
					aux=predecesor(ns);
					cout<<aux->inf<<endl;
					ns->inf=aux->inf;
					if(aux->st)
                        aux->st->par=aux->par;
                    if(aux->par->inf<aux->inf)
                        aux->par->dr=aux->st;
                    else
                        aux->par->st=aux->st;
					delete aux;
				}
}

void SRD(nod *r)
{
	if(r)
	{
		SRD(r->st);
		cout<<r->inf<<' ';
		SRD(r->dr);
	}
}

};
int main()
{
	arbore ABC;
	int x;
	ABC.Creare();  //se creaza nod-ul initial
  cout<<"Introdu val care se va adauga:";
	cin>>x;
    ABC.Adauga(ABC.rad,x,ABC.rad);
    cout<<"Introdu val nodului cautat:";
	cin>>x;
    ABC.ns=ABC.Cauta(ABC.rad,x);
    ABC.Sterge();
    ABC.SRD(ABC.rad);
}
