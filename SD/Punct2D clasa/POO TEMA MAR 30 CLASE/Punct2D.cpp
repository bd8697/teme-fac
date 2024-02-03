#include <iostream>
#include <math.h>
#include "Punct2D.h"
using namespace std;
Punct2D::Punct2D(void){

}
Punct2D Punct2D::operator+(Punct2D p){
	Punct2D rez;
	rez.coordx = coordx + p.coordx;
	rez.coordy = coordy + p.coordy;
	return rez;
}
Punct2D Punct2D::operator=(Punct2D p){
	coordx = p.coordx;
	coordy = p.coordy;
	return (*this);
}
bool Punct2D::operator==(Punct2D p){
	if ((coordx == p.coordx) && (coordy == p.coordy))
		return true;
	return false;
}
bool Punct2D::operator<(Punct2D p){
	if (coordx<p.coordx){
		return true;
	}
	return false;
}
int Punct2D::cadran(){
	if ((coordx > 0) && (coordy > 0))
		return 1;
	if ((coordx < 0) && (coordy > 0))
		return 2;
	if ((coordx < 0) && (coordy < 0))
		return 3;
	if ((coordx > 0) && (coordy < 0))
		return 4;
	return 0;
}
double Punct2D::distanta(Punct2D p){
	return sqrt((coordx - p.coordx)*(coordx - p.coordx) + (coordy - p.coordy)*(coordy - p.coordy));
}
istream & operator>>(istream &f, Punct2D & p){
	f >> p.coordx >> p.coordy;
	return f;
}
ostream & operator<<(ostream &f, Punct2D & p){
	f << '(' << p.coordx << ',' << p.coordy << ')';
	return f;
}

