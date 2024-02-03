#include <iostream>
using namespace std;



struct lista
{

struct elem
{
    int val;
    elem *next;
    };
elem *cap=NULL;
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
     e->next=NULL;
     if(cap==NULL)
     cap=e;
     else
     {
        elem *nod=cap;
        while(nod->next!=NULL)
            nod=nod->next;
         nod->next=e;
     }
    }
}


void afis()
 {
     while(cap!=NULL)
        {   cout<<cap->val<<' ';
            cap=cap->next;}
 }


void inversare()
{
    elem *cap2=cap->next;
    elem *cap3=cap2->next;
    cap->next=NULL;
    while(cap3!=NULL)
    {
        cap2->next=cap;
        cap=cap2;
        cap2=cap3;
        cap3=cap3->next;

    }
    cap2->next=cap;
 cap=cap2;

}
};
 int main()
 {   lista l;
     l.creare();
     l.inversare();
     //cap o sa devina coada dupa inversare
     l.afis();

     return 0;
 }

