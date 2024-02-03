#include <stdio.h>
#include <string.h>
#include <malloc.h>


int main()
{ int n,i,nr=0,nrpers;
  char *s;char *aux;
  printf("Introdu nr pers.:");
  scanf_s("%d",&nrpers);
  scanf_s("%d",&n);
  s=(char *)malloc((n+1)*sizeof(char));
   aux=(char *)malloc((n+1)*sizeof(char));
for(i=0;i<nrpers;i++)
    {
        printf("Introdu nume :");
        scanf_s("%s",s);
        printf("Introdu prenume :");
        scanf_s("%s",aux);
            if(strcmp(s,aux)==0)
                nr++;
    }

    printf("%d ",nr);

    return 0;
}
