// ConsoleApplication22.cpp : Defines the entry point for the console application.
//

#define _CRT_SECURE_NO_WARNINGS
#include "stdafx.h"
#include <stdio.h>

int main()
{
	int n, k, i;
	scanf("%d", &n);
	scanf("%d", &k);
	for (i = n+1; i <= n + k; i++)
		printf("%d ", i);
	for (i = n-1; i >= n -k; i--)
		printf("%d ", i);
	return 0;
}

