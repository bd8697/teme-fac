#include <stdio.h> // se inlcude libraria stdio.h
#include <string.h> // se include biblioteca string.h

#define MAX_BUF 256 // stabileste lungimea maxima a sirului de caractere buf

char arr2[5][20] = {  "Mickey Mouse",

                      "Donald Duck",

                      "Minnie Mouse",

                      "Goofy",

                      "Ted Jensen" }; // se declara vectorul de char-uri de dimesiune 5, fiecare element avand dimensiunea maxima de 20 de caractere

void bubble(void *p, int width, int N);
int compare(void *m, void *n);

int main(void) //fct. principala
{
    int i;  // se declara varianbila i(nr. natural)
    putchar('\n'); // se afiseaza pe ecran un rand gol

    for (i = 0; i < 5; i++) // pentru i incepand de la 0,cat timp i<5,cu pas 1
    {
        printf("%s\n", arr2[i]); // se afiseaza pe ecran fiecare element al vectorului arr2,cu un rand gol dupa fiecare element
    }
    bubble(arr2, 20, 5); // se apeleaza fct. bubble
    putchar('\n\n');  // se afiseaza pe ecran un singur rand gol
    for (i = 0; i < 5; i++) //pentru i,incepand de la 0 ,cat timp i<5,cu pas 1
    {
        printf("%s\n", arr2[i]); // se afiseaza pe ecran fiecare element al vectorului arr2,cu un rand gol dupa fiecare element
    }
    return 0; // se returneaza '0'
}

void bubble(void *p, int width, int N) // se declara functia bubble, cu parametrii *p,width si N
{
    int i, j, k; //se declara variabilele i, j si k(nr. nat.)
    unsigned char buf[MAX_BUF]; //se declara sirul de caractere buf de lungime maxima MAX_BUF(admite si caractere engative ?)
    unsigned char *bp = p; // se declara poiinterul bp(poz. sau neg.) care primeste valoarea var. p

    for (i = N-1; i >= 0; i--) // pentru i, incepand de la N-1, cat timp i >= 0,cu pas -1
    {
        for (j = 1; j <= i; j++) // pentru j, incepand de la 1,cat timp j<=i cu pas 1
        {
          k = compare((void *)(bp + width*(j-1)), (void *)(bp + j*width)); // var. k primeste valoarea returnata de fct. compare, unde parametrii sunt, pe rand, elemente consecutive ale pointerului.Este encesara utilizarea variabilei width, deoarece lucram cu vectori de siruri de caractere, nu doar vectori de nr.
          if (k > 0) // daca k>0(adica elementul curent e mai mare in Codul ASCII decat succesorul lui)
            {
             memcpy(buf, bp + width*(j-1), width); // se realizeaza interschimbarea elementului curent cu succesorul lui, daca este cazul. buf are rol de aux
             memcpy(bp + width*(j-1), bp + j*width , width);
             memcpy(bp + j*width, buf, width);
            }
        }
    }
}

int compare(void *m, void *n) // declararea fct. compare, cu 2 pointeri ca parametrii
{
    char *m1 = m; // declararea pointerului m1, care primeste valoarea var. catre care arata pointerul m
    char *n1 = n; // declararea pointerului n1, care primeste valoarea var. catre care arata pointerul n
    return (strcmp(m1,n1)); // fct. returneaza o val.<0 daca m1 are val. mai mica decat n1 in codul ASCII, 0 daca m1 si n1 sunt egale, si o val >0 in caz contrar
}
