// ConsoleApplication22.cpp : Defines the entry point for the console application.
//

#define _CRT_SECURE_NO_WARNINGS
#include "stdafx.h"
#include <stdio.h>

int main()
{
	int n,i;
	scanf("%d", &n);
	for (i = n - 1; i > 0; i--)
		n = n*i;
	printf("%d ", n);
	return 0;
}

