// ConsoleApplication22.cpp : Defines the entry point for the console application.
//

#define _CRT_SECURE_NO_WARNINGS
#include "stdafx.h"
#include <stdio.h>

int main()
{
	int n,x;

	scanf("%d", &x);
	scanf("%d", &n);

	x=x>>n;

	printf("%d", x);
	return 0;
}
/*for(i=0;i<n;i++)
	x=x/2; */
  
