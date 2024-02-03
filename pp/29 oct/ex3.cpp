// ConsoleApplication13.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include<stdio.h>

int main()
{int n;
int nr = 0;
char p;

scanf("%d", &n);

for (int i = 0; i < n; i++)
{
	scanf("%c", &p);
	if (p == 'c')
		nr++;
}
printf("%d", nr);
    return 0;
}

