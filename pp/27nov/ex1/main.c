#include <stdio.h>
#include <malloc.h>
#include<conio.h>

int rastoarna(int n)
{ int b=0;
while(n>0)
{
    b=b*10+n%10;
    n=n/10;

}

    return b;
}


int main()
{
	int *a,n,i,j,aux,aux2;
	scanf_s("%d", &n);

	a = (int *)malloc(n*sizeof(int*));

	for (i = 0; i<n; i++)
		scanf_s("%d", &a[i]);

	for (i = 0; i<n; i++)
	{    aux2=a[i];
	    aux=rastoarna(a[i]);
	    while(aux>0)
         { n++;
			a = (int *)realloc(a, n*sizeof(int));

            for (j = n - 2; j >= i + 1; j--)
				a[j + 1] = a[j];
			a[i + 1] = aux%10;
			aux=aux/10;
			i++;
         }
        while(aux2%10==0)
        {
           n++;
			a = (int *)realloc(a, n*sizeof(int));
            for (j = n - 2; j >= i + 1; j--)
				a[j + 1] = a[j];
            a[i + 1] = 0;
			aux2=aux2/10;
			i++;
        }
	}


	for (i = 0; i<n; i++)
		printf("%d ", a[i]);

	free(a);
	return 0;
}
