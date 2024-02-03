// ConsoleApplication14.cpp : Defines the entry point for the console application.
//
#define _CRT_SECURE_NO_WARNINGS
#include "stdafx.h"
#include<stdio.h>

int main()
{
	int n;
	float sc=0,nc=0;
	
	float media;
	scanf("%f", &n);
	while (n != 0)
	{
		sc = sc + n % 10;
		n = n / 10;
		nc++;
	} media = sc / nc;
	printf("%1.4f", media);
	return 0;
}

