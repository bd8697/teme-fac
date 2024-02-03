#include <stdio.h>
#include <malloc.h>
#include<conio.h>

int main()
{
	int m, n, **a, i,j,ok,x;
	scanf_s("%d", &n);
	scanf_s("%d", &m);
	a = (int**)malloc(n*sizeof(int *));
	for (i = 0; i<n; i++)

		a[i] = (int*)malloc(m*sizeof(int));
		for ( i = 0; i<n; i++)
			for (j = 0; j<m; j++)
				scanf_s("%d", &a[i][j]);
		for ( i = 0; i<n; i++)
			{   ok=1;
			    for ( j = 0; j<m-1; j++)

                    if(a[i][j]>=a[i][j+1])
                    {   ok=0;
                        break;}
                    if(ok==1)
                            {
                                for(x=i;x<n-1;x++)
                                for(j=0;j<m;j++)
                                  a[x][j]=a[x+1][j];
                                    n--;i--;
                                    a = (int **)realloc(a, n*sizeof(int *));}
                }

                for ( j = 0; j<m; j++)
			{   ok=1;
			    for ( i = 0; i<n-1; i++)

                    if(a[i][j]>=a[i+1][j])
                    {   ok=0;
                        break;}
                    if(ok==1)
                            {
                                for(x=j;x<m-1;x++)
                                for(i=0;i<n;i++)
                                  a[i][x]=a[i][x+1];
                                    m--;j--;
                                   a[i] = (int*)realloc(a[i],m*sizeof(int));}
                }

        for ( i = 0; i<n; i++)
            {
                printf("\n");

			for (j = 0; j<m; j++)
                printf("%d ",a[i][j]);}

                return 0;}

