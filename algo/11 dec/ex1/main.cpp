#include <iostream>
using namespace std;

struct produs
{ int beneficiu;
  int greutate;
  float ef;
  int numar;};

  void sortare(produs o[],int n)
  {   float aux;
      for(int i=0;i<n;i++)
      o[i].ef=(float)o[i].beneficiu/(float)o[i].greutate;
      for(int i=0;i<n-1;i++)
        for(int j=i+1;j<n;j++)
        {
            if(o[i].ef<o[j].ef)
            {
                aux=o[i].ef;
                o[i].ef=o[j].ef;
                o[j].ef=aux;
                aux=o[i].beneficiu;
                o[i].beneficiu=o[j].beneficiu;
                o[j].beneficiu=aux;
                aux=o[i].greutate;
                o[i].greutate=o[j].greutate;
                o[j].greutate=aux;
                aux=o[i].numar;
                o[i].numar=o[j].numar;
                o[j].numar=aux;
            }
        }
  }

  void rucsac (int gmax, produs o[],int n)
  { int gr=gmax;float fr;
  //int castig=0;
    int i=0;
    while(i<n && gr>0)
    {
        if(o[i].greutate<=gr)
        {cout<<"obiectul nr. "<<o[i].numar<<'('<<o[i].greutate<<" si "<<o[i].beneficiu<<") , ";
         gr=gr-o[i].greutate;
       //  castig=castig+o[i].beneficiu;
         i++;}
         else
         {
             fr=(float)gr/(float)o[i].greutate;
             cout<<fr<<"din"<<"obiectul nr. "<<o[i].numar<<'('<<fr*o[i].greutate<<" si "<<fr*o[i].beneficiu<<") , ";
             gr=0;
        //     castig=castig+fr*o[i].beneficiu;
         }
    }

  }




int main()
{ produs a[50];
  int n,gmax;
  cin>>n;cin>>gmax;
  for(int i=0;i<n;i++)
  {cin>>a[i].beneficiu;cin>>a[i].greutate;}
  for(int i=0;i<n;i++)
    a[i].numar=i+1;
    sortare(a,n);
    rucsac(gmax,a,n);

    return 0;
}
