#include <iostream>
using namespace std;
void floydwarshall(int (&g)[50][50],int (&p)[50][50],int n)
{
    for(int i=0;i<n;i++)
        for(int j=0;j<n;j++)
            {if(i==j || g[i][j]==99)
                p[i][j]=-1;
            else p[i][j]=i;}
for(int k=0;k<n;k++)
    for(int i=0;i<n;i++)
        for(int j=0;j<n;j++)
            {
               int drumnou =g[i][k]+g[k][j];
                if(drumnou<g[i][j])
                {
                    g[i][j]=drumnou;
                    p[i][j]=p[k][j];
                }
            }

}

void drumscurtxy(int x,int y,int p[50][50],int n)
{   int a[n];
    int aux=n;aux--;
    int j=y-1;
    a[aux]=j+1;aux--;
    j=p[x][j];
    while(j!=x)
        { a[aux]=j+1;aux--;
         j=p[x][j];
        }
    a[aux]=j+1;
    for(int i=aux;i<n;i++)
        cout<<a[i]<<' ';
}

int main()
{   int x;int y;int n;int graf[50][50],vectorparinti[50][50];
    cout<<"Introdu nr. noduri:";
    cin>>n;
    cout<<"Citeste matricea de adiacenta a grafului:"; //se rezerva valoarea 99 pentru simbolizarea lipsei arcului intre doua noduri
     for(int i=0;i<n;i++)
        for(int j=0;j<n;j++)
            cin>>graf[i][j];
    cout<<"Din nodul:";
    cin>>x;
    cout<<"In nodul:";
    cin>>y;
    x--;
    floydwarshall(graf,vectorparinti,n);
    drumscurtxy(x,y,vectorparinti,n);


/*    for(int i=0;i<n;i++)     //afisare matricea graf, care acum contine lungimile celor mai scurte drumuri de la i la j
        {
            cout<<endl;
            for(int j=0;j<n;j++)
                {if(graf[i][j]==99)
                cout<<'x'<<' ';
                else
                cout<<graf[i][j]<<' ';}}
*/


/*    for(int i=0;i<n;i++)     //afisare matricea vectorparinti, care contine drumul de la x la y pentru fiecare linie i
        {
            cout<<endl;
            for(int j=0;j<n;j++)
                {if(vectorparinti[i][j]==-1)
                cout<<'x'<<' ';
                else
                cout<<vectorparinti[i][j]+1<<' ';}}
*/

return 0;}
