#include <stdio.h>
#include <string.h>
#include <malloc.h>

int main()
{ int n,i,nr=0;
  char *s;
  scanf_s("%d",&n);
  s=(char *)malloc((n+1)*sizeof(char));
    scanf_s("%s",s);
  for(i=0;i<n;i++)
    if(strchr("0123456789",s[i])!=NULL)
        nr++;

    printf("%d Numere in fraza.",nr);

    return 0;
}
