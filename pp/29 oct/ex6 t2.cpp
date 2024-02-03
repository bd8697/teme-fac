// ConsoleApplication22.cpp : Defines the entry point for the console application.
//

#define _CRT_SECURE_NO_WARNINGS
#include "stdafx.h"
#include <stdio.h>

int main()
{
	int x, i , y,aux ;
	scanf("%d", &x);

		for (i = 7; i > 0; i--)
		{
			y = 1;
			aux = i;
			while (aux > 0)
			{
				y = y * 2;
				aux--;
			}

			if (x >= y)
			{
				x = x - y;
				printf("1 ");
			}
			else
				printf("0 ");
		}
	if(x==1)
		
		printf("1 ");

	else
		printf("0 ");


	return 0;
}

