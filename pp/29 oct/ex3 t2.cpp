// ConsoleApplication22.cpp : Defines the entry point for the console application.
//

#define _CRT_SECURE_NO_WARNINGS
#include "stdafx.h"
#include <stdio.h>

int main()
{
	int n,i=0,d,j=2,ok;
	scanf("%d", &n);
	while (i < n)
	{
		ok = 1;
		if (j % 2 == 0 && j != 2 || j < 2)
			ok = 0;
		
			for (d = 3; d*d<= j; d = d + 2)
				if (j%d == 0)
					ok = 0;
			if (ok == 1)
			{
			printf("%d ", j);
			i++;
		}j++;
	}



	return 0;
}

