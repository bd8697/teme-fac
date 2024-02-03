#include <iostream>
using namespace std;


typedef struct nod{
	int inf;
	nod *st,*dr;
}ABC;
ABC *tns;
void Adauga(ABC* &r,int info)
{
	if(!r)  //arborele este vid, creez radacina
	{
		r=new ABC; r->inf=info; r->st=r->dr=0;
	}
	else
		if(info<r->inf)
            Adauga(r->st,info);
		else if(info>r->inf)
                Adauga(r->dr,info);
			else cout<<"nformatie duplicat";
}
void Creare(ABC* &r)
{
	int info,n;
	cout<<"numar de noduri: "; cin>>n;
	for(int i=0;i<n;i++)
	{
		cout<<"informatia nodului "<<i<<':'; cin>>info;
		Adauga(r,info);
	}
}
void Cauta(ABC *p,int x)
{
	if(!p)
		cout<<"nodul cu val "<<x<<" NU exista in arbore"<<endl;
	else
		if(x<p->inf) Cauta(p->st,x);
		else if(x>p->inf) Cauta(p->dr,x);
			else cout<<"nodul cu val "<<x<<" exista in arbore"<<endl;

}
void minim(ABC *p)
{
	while(p->st!=NULL)
        p=p->st;
    cout<<"Val min e:"<<p->inf<<endl;
}

void succesor(ABC *p)
{
if(p->st==NULL)
        cout<<"nu exista succesor pe stanga"<<endl;
    else
	{cout<<"Succesorul pe stanga al nodului cu val "<<p->inf<< " este nodul cu val ";
	ABC*auxst=p->st;
	cout<<auxst->inf<<endl;}
if(p->dr==NULL)
        cout<<"nu exista succesor pe dreapta"<<endl;
    else
	{cout<<"Succesorul pe dreapta al nodului cu val "<<p->inf<< " este nodul cu val ";
	ABC*auxdr=p->dr;
	cout<<auxdr->inf<<endl;}
}


ABC* Determina_minim(ABC *p)
{
	while(p->st) { tns=p; p=p->st; }
	return p;
}
ABC* Cauta_sterge(ABC *p,int x)
{
	if(!p) return 0;
	else if(p->inf<x) { tns=p; p=p->dr; return Cauta_sterge(p,x); }
	else if(p->inf>x) { tns=p; p=p->st; return Cauta_sterge(p,x); }
	     else return p;
}
void Sterge(ABC* &r,int x)
{
	ABC *ns,*minim,*ns1; int aux;
	ns=Cauta_sterge(r,x);
	if(!ns) cout<<"\ninformatia “<<x<<” exista in arbore\n";
	else
		if(ns->dr==ns->st)  //nodul ce trebuie sters nu are descendenti
		{
			if(ns->inf<tns->inf) tns->st=0;
		     else tns->dr=0;
		     delete ns;
		}
		else
			if(ns->dr==0&&ns->st)  //nodul are fiu stang
			{
				if(tns->inf<ns->inf) tns->dr=ns->st;
				else tns->st=ns->st;
				delete ns;
			}
			else
				if(ns->st==0&&ns->dr)  //nodul are fiu drept
				{
					if(tns->inf>ns->inf) tns->st=ns->dr;
					else tns->dr=ns->dr;
					delete ns;
				}
				else   //nodul ce trebuie sters are ambii fii
				{
					minim=Determina_minim(ns); ns1=ns;
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
void SRD(ABC *r)
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
	ABC *rad=0; int x;
	Creare(rad);  //se creaza ABC-ul initial
  cout<<"Introdu val care se va adauga:";
	cin>>x;
    Adauga(rad,x);
    cout<<"Introdu val nodului cautat:";
	cin>>x;
    Cauta(rad,x);
    minim(rad);
    succesor(rad->st);
    cout<<"Introdu val nodului care se va sterge:";
	cin>>x;
 //   Sterge(rad,x);
    SRD(rad);
}
