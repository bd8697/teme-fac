#include <stdio.h>
#include <malloc.h>
#include<conio.h>
int cifre(int n)
{ int nr=0;
    while(n>0)
        {n=n/10;
        nr++;}
    return nr;
}
int main()
{
	int m, n, **a, i,j,x,nr;
	scanf_s("%d", &n);
	scanf_s("%d", &m);
	a = (int**)malloc(n*sizeof(int *));
	for (i = 0; i<n; i++)

		a[i] = (int*)malloc(m*sizeof(int));
		for ( i = 0; i<n; i++)
			for (j = 0; j<m; j++)
				scanf_s("%d", &a[i][j]);
		for ( j = 0; j<m; j++)
			{   nr=cifre(a[0][j]);
                m=m+nr;
                a[i] = (int*)malloc(m*sizeof(int));
                for( x=m-1;x>j+nr;x--)
                  for(i=0;i<n;i++)
                    a[i][x]=a[i][x-nr];
                 for(x=j+1;x<=j+nr;x++)
                    for(i=0;i<n;i++)
                        a[i][x]=0;
                j=j+nr;
            }


        for ( i = 0; i<n; i++)
            {
                printf("\n");

			for (j = 0; j<m; j++)
                printf("%d ",a[i][j]);}

                return 0;}
