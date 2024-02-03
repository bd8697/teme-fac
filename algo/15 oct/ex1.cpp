#include <iostream>
using namespace std;
int main()
{
    int n;
    int a[50];
    cin>>n;
    for(int i=0;i<n;i++)
        cin>>a[i];
    for(int i=0;i<n;i++)
        if(a[i]%2==0)
          cout<<i+1<<' ';
}
