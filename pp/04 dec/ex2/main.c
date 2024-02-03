#include <stdio.h>
#include<conio.h>

int cmmdc(int a,int b)
{
    while (a != b)
    {   if (a > b)
            a = a - b;
        else
            b = b - a;
    }
   return a;
}
int cmmmc(int a,int b)
{return(a*b/cmmdc(a,b));
}




int main()
{
	int *a, n, i,aux;
	scanf_s("%d", &n);
    n=n+2;
	a = (int *)malloc(n*sizeof(int*));

	for (i = 1; i<n-1; i++)
		scanf_s("%d", &a[i]);
    a[0]=cmmdc(a[1],a[2]);
    a[n-1]=cmmmc(a[1],a[2]);
    for(i=3;i<n-1;i++)
        {
            a[0]=cmmdc(a[0],a[i]);
            a[n-1]=cmmmc(a[n-1],a[i]);
        }



	for (i = 0; i<n; i++)
		printf(" %d", a[i]);

	free(a);

}
