#include <stdio.h>
#include <malloc.h>
#include<conio.h>

int main()
{
	int m, n, **a, i,j,x;
	scanf_s("%d", &n);
	scanf_s("%d", &m);
	a = (int**)malloc(n*sizeof(int *));
	for (i = 0; i<n; i++)

		a[i] = (int*)malloc(m*sizeof(int));
		for ( i = 0; i<n; i++)
			for (j = 0; j<m; j++)
				scanf_s("%d", &a[i][j]);
		for ( i = 0; i<n; i++)
			{  n++;
			   a = (int **)realloc(a, n*sizeof(int *));
               for( x=n-2;x>i;x--)
                  for(j=0;j<m;j++)
                    a[x+1][j]=a[x][j];
               for(j=0;j<m;j++)
                a[i+1][j]=a[i][0];
                i++;
            }


        for ( i = 0; i<n; i++)
            {
                printf("\n");

			for (j = 0; j<m; j++)
                printf("%d ",a[i][j]);}

                return 0;}
