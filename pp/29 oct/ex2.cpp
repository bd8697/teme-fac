// ConsoleApplication16.cpp : Defines the entry point for the console application.
//
#define _CRT_SECURE_NO_WARNINGS
#include "stdafx.h"

#include <math.h>
#include<stdio.h>

int main()
{
	double y;
	int x;

	scanf("%lf", &y);
	x=floor(y);
	if (y - x == 0)
		printf("Da");
	else
		printf("Nu");

	printf("%lf", y);

}