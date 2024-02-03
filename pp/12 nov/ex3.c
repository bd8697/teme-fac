#include <stdio.h>
#include <string.h>

int main()
{  char c[10];
   char s[100];
   int nr=0;
    FILE *in;
in = fopen("fis.txt","r");
    fscanf(in,"%s",&c);
    printf("%s \n",c);
    fscanf(in,"%s",&s);
     fgets(s,100,in);
     printf("%s \n",s);

if(strstr(c, s) != NULL) {
    nr++;
}

printf("The word is \"%s\". The sentence is \"%s\". The word occurs %d times.",c,s,nr);
return 0;
}
