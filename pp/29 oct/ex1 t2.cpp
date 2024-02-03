// ConsoleApplication19.cpp : Defines the entry point for the console application.
//

#define _CRT_SECURE_NO_WARNINGS
#include "stdafx.h"

#include<stdio.h>
int main()
{int NrCurent;
double Cordx1,Cordy1,Raza1,Cordx2,Cordy2,Raza2,Cordx3,Cordy3,Raza3,Cordx4,Cordy4,Raza4;
scanf("%lf %lf %lf", &Cordx1, &Cordy1, &Raza1);
scanf("%lf %lf %lf", &Cordx2, &Cordy2, &Raza2);
scanf("%lf %lf %lf", &Cordx3, &Cordy3, &Raza3);
scanf("%lf %lf %lf", &Cordx4, &Cordy4, &Raza4);
printf("--------------------------------------------------- \n");
printf("| NrCurent |    Cordx   |    Cordy   |     Raza   | \n" );
printf("--------------------------------------------------- \n");

printf("|    1.    |  %lf  |  %lf  |  %lf  | \n", Cordx1, Cordy1, Raza1);

printf("|    2.    |  %lf  |  %lf  |  %lf  | \n", Cordx2, Cordy2, Raza2);

printf("|    3.    |  %lf  |  %lf  |  %lf  | \n", Cordx3, Cordy3, Raza3);

printf("|    4.    |  %lf  |  %lf  |  %lf  | \n", Cordx4, Cordy4, Raza4);
printf("---------------------------------------------------");
return 0;
}