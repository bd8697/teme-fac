// ConsoleApplication22.cpp : Defines the entry point for the console application.
//

#define _CRT_SECURE_NO_WARNINGS
#include "stdafx.h"
#include <stdio.h>
int fact(int x)
{
	int i;
	for (i = x - 1; i > 0; i--)
		x = x * i;
	return x;
}
int main()
{
	int n;
	scanf("%d", &n);
	
	printf("%d ", fact(n));
	return 0;
}

