#include <stdio.h>
#include <stdlib.h>

int rastoarna(int x)
{ int aux=0;
    while(x>0)
    {   if(x%10%2!=0)
        aux=aux*10+x%10;
        x=x/10;
    }
    return aux;
}


int main()
{
	int *a, n, i,j,aux;
	scanf_s("%d", &n);

	a = (int *)malloc(n*sizeof(int*));

	for (i = 0; i<n; i++)
		scanf_s("%d", &a[i]);
    for(i=0;i<n;i++)
    {aux=rastoarna(a[i]);
     if(aux==rastoarna(aux))
     {
         for(j=i;j<n-1;j++)
            a[j]=a[j+1];
            n--;i--;
            a=(int *)realloc(a,n*sizeof(int*));

     }

     }



	for (i = 0; i<n; i++)
		printf(" %d", a[i]);

	free(a);

}
