#include <stdio.h> //se include biblioteca stdio.h

int arr[10] = { 3,6,1,2,3,8,4,1,7,2}; //se declara variabila arr(vector) de lungime 10,primind valorile 3,6,1,2...

void bubble(int *p, int N);
int compare(int *m, int *n);

int main(void)  //fct. main
{
    int i;    //se celara variabila i(nr intreg)
    putchar('\n'); //se afiseaza un rand gol(putchar afiseaza un singur caracter)

    for (i = 0; i < 10; i++) //pentru i incepand de la 0,cat timp i<10, cu pas 1
    {
        printf("%d ", arr[i]); //se afiseaza pe ecran, pe rand, fiecare elemet al vectorului arr
    }
    bubble(arr,10); //apel catre fct. bubble,cu parametrii arr si 10(adica se sorteaza crescator vectorul arr de dimensiune 10)
    putchar('\n'); //se afiseaza un rand gol(putchar afiseaza un singur caracter)

    for (i = 0; i < 10; i++) //pentru i incepand de la 0,cat timp i<10, cu pas 1
    {
        printf("%d ", arr[i]); //se afiseaza pe ecran, pe rand, fiecare elemet al vectorului arr
    }
    return 0; //se returneaza '0'
}

void bubble(int *p, int N)  //declaratia fct. bubble cu parametrii(*p(pointer) si N(nr. intreg)). Fct. realizeaza sortarea prin metoda bulelor (compara 2 cate 2 elem si le interschimba dace e nevoie).
{
    int i, j, t; //se cedlara var. i,j,t, nr. intregi
    for (i = N-1; i >= 0; i--) //pentru i incepand de la N(parametru al fct.)-1,cat timp i>=0,cu pas -1
    {
        for (j = 1; j <= i; j++)  //pentru j incepand de la 1,cat timp j<=i,cu pas 1
        {
            if (compare(&p[j-1], &p[j]))  //apel catre fct.compare.Interschimbarea se va efectua daca fct. compare returneaza val 1(adica daca p[j-1] e mai mare decat p[j])
            {
                t = p[j-1];  //t are rol de aux, se interschimba val. var p[j] si p[j-1]
                p[j-1] = p[j];
                p[j] = t;
            }
        }
    }
}

int compare(int *m, int *n)  //declarare fct. compare cu parametrii *m(pointer) si *n(pointer)
{
    return (*m > *n); //fct. returneaza 1 daca val pointerului m e mai mare decat a lui n, si 0 in caz contrar
}
