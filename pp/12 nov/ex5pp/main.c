#include <stdio.h>


int main()
{ int nota;
printf("Introduceti nota(de la 0 la 100) \n");
scanf("%d",&nota);
if (nota==100)
    printf("Bravo, ai luat 100 de puncte!");
else if(nota>=90 && nota<=100)
    printf("Ai luat nota A!");
else if(nota<90 && nota>=80)
    printf("Ai luat nota B!");
else if(nota<80 && nota>=70)
    printf("Ai luat nota C!");
else if(nota<70 && nota>=60)
    printf("Ai luat nota D!");
else if(nota<60)
    printf("Ai luat nota F!");
else
    printf("100 de puncte e maxim!");

    return 0;
}
