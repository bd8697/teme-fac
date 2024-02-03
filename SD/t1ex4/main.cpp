#include <iostream>
using namespace std;


struct lista
{
    struct elem
{
    int val;
    elem *next, *prev;
};
    elem *cap=NULL;
    elem *coada=NULL;
    elem *S=new elem;

void creare()
{
    int n,x;
    cout<<"Introdu nr elem lista"<<endl;
    cin>>n;
    for(int i=0;i<n;i++)
    {   cout<<"Introdu elem"<<endl;
        cin>>x;
        elem *e=new elem;
     e->val=x;
     e->prev=coada;
     e->next=NULL;
     if(coada!=NULL)
        coada->next=e;
     else
        cap=e;
     coada=e;
    }
    coada->next=S;
    S->prev=coada;
    cap->prev=S;
    S->next=cap;
}



void afis()
 {  cout<<cap->val<<' ';
     while(cap->next!=S)
        {   cap=cap->next;
            cout<<cap->val<<' ';}


 }

 void insertlainceput(int val)
 {
     elem *e=new elem;
     e->val=val;
     e->prev=S;
     e->next=cap;
     if(cap!=NULL)
        cap->prev=e;
     else
        coada=e;
     cap=e;
     S->next=cap;
 }

 void insertlasfarsit(int val)
 {
      elem *e=new elem;
     e->val=val;
     e->prev=coada;
     e->next=S;
     if(coada!=NULL)
        coada->next=e;
     else
        cap=e;
     coada=e;
     S->prev=coada;
 }


 /*void insertlasfarsit(elem *&cap,int val)
 {
      elem *e=new elem;
     e->val=val;
     e->prev=NULL;
     e->next=NULL;
     if(cap==NULL)
        cap=e;
     else
     {
         elem *nod=cap;
         while(nod->next !=NULL)
            nod=nod->next;
         nod->next=e;
         e->prev=nod;
     }
 }*/


 void sterge(int v)
 {
     elem *nod=cap;
    if(cap->val==v)
        {cap->next->prev=S;
         S->next=cap->next;
         cap=cap->next;
         return;}
    if(coada->val==v)
    {
        coada->prev->next=S;
        S->prev=coada->prev;
        coada=coada->prev;
        return;}
     while(nod->val!=v)
        nod=nod->next;
     nod->prev->next=nod->next;
     nod->next->prev=nod->prev;

 }
};

 int main()
 { int v;
    lista l;
     l.creare();
     l.insertlainceput(2);
     l.insertlainceput(7);
     l.insertlainceput(4);
     l.insertlasfarsit(6);
     l.insertlainceput(5);
     l.insertlasfarsit(9);
     cout<<"Sterge elem cu val:"<<endl;
     cin>>v;
     l.sterge(v);//elimina din lista elementul cu val. v
     l.afis();

     return 0;
 }

