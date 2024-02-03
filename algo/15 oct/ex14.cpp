#include <iostream>
using namespace std;

int main()
{  int n;
    int a[50],b[50];
    cin>>n;
	 for(int i=0;i<n;i++)
        b[i]=0;
    for(int i=0;i<n;i++)
        cin>>a[i];
    for(int i=0;i<n;i++)
      b[a[i]]++;
      for(int i=0;i<n;i++)
        if(b[i]>1)
        cout<<"elementul"<<i<<"apare de"<<b[i]<<"ori"<<' ';
        return 0;
}
