#include <stdio.h>
#include <malloc.h>
#include<conio.h>

int main()
{
	int m, n, **A, i, j,min,x,y;
	scanf_s("%d", &n);
	scanf_s("%d", &m);
	A = (int**)malloc(n*sizeof(int *));
	for (i = 0; i<n; i++)

		A[i] = (int*)malloc(m*sizeof(int));
		for (int i = 0; i<n; i++)
			for (j = 0; j<m; j++)
				scanf_s("%d", &A[i][j]);
            min=A[0][0];
        for (int i = 0; i<n; i++)
			for (j = 0; j<m; j++)
                if(A[i][j]<min)
                    min=A[i][j];
        for (int i = 0; i<n; i++)
			for (j = 0; j<m; j++)
                if(A[i][j]==min)
                {for(x=i;x<n-1;x++)
                    for(y=0;y<m;y++)
                        A[x][y]=A[x+1][y];
                   n--;
                 for(x=0;x<n;x++)
                    for(y=j;y<m-1;y++)
                        A[x][y]=A[x][y+1];
                   m--;
                }

		for (int i = 0; i<n; i++)
			{    printf("\n");
			    for (j = 0; j<m; j++)
				printf("%d ", A[i][j]);}
return 0;
}
