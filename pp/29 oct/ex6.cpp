// ConsoleApplication15.cpp : Defines the entry point for the console application.
//

// scanf (" q%d", &x) vs scanf("q%d, &x) -A doua varianta este gresita deoarece nu se inchid ghilimelele, astfel rezultand intr-o eroare la compilare.
// scanf ("%d",&s) vs scanf ("%d",s) -A doua varianta este gresita deoarece specificatorul de format "%d", care indica faptul ca variabila ce ureaza sa fie intodusa este de tipul int,obliga folosirea simbolului "&" (operator de referinte) inaintea variabilei.
// while (scanf ("%d %d\n", &p, &q) == 2) -Lipseste virgula dintre "%d" si "%d".