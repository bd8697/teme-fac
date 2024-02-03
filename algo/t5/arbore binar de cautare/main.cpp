#include <iostream>
using namespace std;


 struct nod{
	int inf;
	nod *st,*dr;
};

void Adauga(nod* &r,int info)
{
	if(!r)
	{
		r=new nod;
		r->inf=info;
		r->st=r->dr=0;
	}
	else
		if(info<r->inf)
            Adauga(r->st,info);
		else if(info>r->inf)
            Adauga(r->dr,info);
        else cout<<"nformatie duplicat";
}
void Creare(nod* &r)
{
	int info,n;
	cout<<"numar de noduri: ";
	cin>>n;
	for(int i=0;i<n;i++)
	{
		cout<<"informatia nodului "<<i<<':';
		cin>>info;
		Adauga(r,info);
	}
}
void Cauta(nod *p,int x)
{
	if(!p)
		cout<<"nodul cu val "<<x<<" NU exista in arbore"<<endl;
	else
		if(x<p->inf) Cauta(p->st,x);
          else if(x>p->inf) Cauta(p->dr,x);
			else cout<<"nodul cu val "<<x<<" exista in arbore"<<endl;

}
void valminim(nod *p)
{
	while(p->st!=NULL)
        p=p->st;
    cout<<"Val min e:"<<p->inf<<endl;
}

void succesor(nod *p)
{
if(p->st==NULL)
        cout<<"nu exista succesor pe stanga"<<endl;
    else
	{cout<<"Succesorul pe stanga al nodului cu val "<<p->inf<< " este nodul cu val ";
	nod*auxst=p->st;
	cout<<auxst->inf<<endl;}
if(p->dr==NULL)
        cout<<"nu exista succesor pe dreapta"<<endl;
    else
	{cout<<"Succesorul pe dreapta al nodului cu val "<<p->inf<< " este nodul cu val ";
	nod*auxdr=p->dr;
	cout<<auxdr->inf<<endl;}
}


nod* Determina_minim(nod *p,nod *&tns)
{
	while(p->st) { tns=p; p=p->st; }
	return p;
}
nod* Cauta_sterge(nod *p,int x,nod *&tns) // returneaza nodul care va fi sters, stocat in ns
{
	if(!p) return 0;
	else if(p->inf<x) { tns=p; p=p->dr; return Cauta_sterge(p,x,tns); }
	else if(p->inf>x) { tns=p; p=p->st; return Cauta_sterge(p,x,tns); }
	     else return p;
}
void Sterge(nod* &r,int x)
{   nod *tns;
	nod *ns,*minim,*ns1;
	int aux;
	ns=Cauta_sterge(r,x,tns);
	if(!ns) cout<<"Informatia "<<x<<" NU exista in nici un nod al arborelui"<<endl;
	else
		if(ns->dr==ns->st)  //in cazul in care nodul cu inf x e frunza
		{
			if(ns->inf<tns->inf) tns->st=0;
		     else tns->dr=0;
		     delete ns; //elibereaza zona de memorie ocupata de elem sters
		}
		else
			if(ns->dr==0&&ns->st)  //in cazul in care nodul cu inf x are descendent stang
			{
				if(tns->inf<ns->inf) tns->dr=ns->st;
				else tns->st=ns->st;
				delete ns;
			}
			else
				if(ns->st==0&&ns->dr)  //nodul are descendent drept(simetric fata de else precedent)
				{
					if(tns->inf>ns->inf) tns->st=ns->dr;
					else tns->dr=ns->dr;
					delete ns;
				}
				else   //nodul are ambii descendenti
				{
					minim=Determina_minim(ns,tns); ns1=ns;
					ns->inf=minim->inf;
					if(minim->dr==minim->st)
					//nodul minim nu are descendenti
					{  tns->st=0; delete minim; }
					else   //nodul minm are fiu drept
					{  tns->st=minim->dr; delete minim; }
					while(ns1->st&&ns1->inf<ns1->st->inf)
					{
						aux=ns1->inf; ns1->inf=ns1->st->inf;
						ns1->st->inf=aux; ns1=ns1->st;
					}
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
int main()
{
	nod *rad=0; int x;
	Creare(rad);  //se creaza nod-ul initial
  cout<<"Introdu val care se va adauga:";
	cin>>x;
    Adauga(rad,x);
    cout<<"Introdu val nodului cautat:";
	cin>>x;
    Cauta(rad,x);
    valminim(rad);
    succesor(rad);
    cout<<"Introdu val nodului care se va sterge:";
	cin>>x;
   Sterge(rad,x);
    SRD(rad);
}
