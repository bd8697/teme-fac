

#include <iostream>
using namespace std;

int mat(int a,int b,int c,int d,int n)
{
    if(n==0)
        return a;

        if(n%2==0)
            mat(a*a+b*c,a*b+b*d,c*a+d*c,c*b+d*d,n/2);
        else
            mat(a*a+b*c+a*b+b*d,a*a+b*c,c*a+d*c+c*b+d*d,c*a+d*c,n/2); //pt 6 ar trebui sa faca intai else, si dupa if,pt 5 ar trbui sa faca intai if si dupa else



    }




int main()
{int n;
cin>>n;
cout<<mat(1,1,1,0,n);
return 0;

}
