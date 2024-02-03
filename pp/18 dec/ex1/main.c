#include <stdio.h>
#include <string.h>
#include <malloc.h>

int main()
{ int n,i,nrv=0,nrc=0;
  char *s;
  scanf_s("%d",&n);
  s=(char *)malloc((n+1)*sizeof(char));
    scanf_s("%s",s);
  for(i=0;i<n;i++)
    {if(strchr("aeiou",s[i])!=NULL)
        nrv++;
    else if(strchr("bcdfghjklmnpqrstvwxyz",s[i])!=NULL)
        nrc++;
        }
   if(nrc>nrv)
    printf("Mai multe consoane.");
   else if(nrv>nrc)
    printf("Mai multe vocale.");
   else
    printf("Numar egal de consoane si vocale.");
printf("%d ",nrv);
printf("%d ",nrc);

    return 0;
}
