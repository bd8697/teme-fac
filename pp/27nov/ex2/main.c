#include <stdio.h>
#include <malloc.h>
#include<conio.h>

int main()
{
	int m,n,**A,i,j,ok1=0,ok2=0,k,l,x,ok=0;
	scanf_s("%d", &n);
	scanf_s("%d", &m);

	A = (int**)malloc(n*sizeof(int *));
	for (i = 0; i<n; i++)
	A[i] = (int*)malloc(m*sizeof(int));
		for (int i = 0; i<n; i++)
			for (j = 0; j<m; j++)
				scanf_s("%d", &A[i][j]);
				while(ok==0)
         {ok=1;
		  for ( i = 0; i<n; i++)
                    for(k=0;k<n;k++)
                    {   if(i==k)
                        k++;
                        if(k==n)
                        break;
                        ok1=1;
                        for(l=0;l<m;l++)
                          if(A[i][l]>A[k][l])
                        {
                            ok1=0;
                            break;
                        }if(ok1==1)
                            {   ok=0;
                                for(x=i;x<n-1;x++)
                                for(j=0;j<m;j++)
                                  A[x][j]=A[x+1][j];
                                    n--;k=0;if(i==n)break;}}

        for ( j = 0; j<m; j++)
                    for(l=0;l<m;l++)
                    {   if(j==l)
                        l++;
                        if(l==m)
                        break;
                        ok2=1;
                        for(k=0;k<n;k++)
                          if(A[k][j]<A[k][l])
                        {
                            ok2=0;
                            break;
                        }if(ok2==1)
                            {   ok=0;
                                for(x=j;x<m-1;x++)
                                for(i=0;i<n;i++)
                                  A[i][x]=A[i][x+1];

                                    m--;l=0;if(j==m)break;}}


		}
        for(i=0;i<n;i++)
        { printf("\n");
            for(j=0;j<m;j++)
             printf("%d ",A[i][j]);}
return 0;

}
