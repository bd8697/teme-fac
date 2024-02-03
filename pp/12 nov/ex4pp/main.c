#include <stdio.h>

void variables(int a,int b,int c)
{  int auxb=b,auxc=c;
    int *p;
    p=&b;
    *p=a;
    p=&c;
    *p=auxb;
    p=&a;
    *p=auxc;
printf("%d %d %d \n",a,b,c);
}

int main()
{ int a,b,c;
    scanf("%d",&a);
    scanf("%d",&b);
    scanf("%d",&c);
variables(a,b,c);
printf("%d %d %d",a,b,c);

    return 0;
}
