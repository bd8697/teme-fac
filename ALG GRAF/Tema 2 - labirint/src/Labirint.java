import java.awt.*;
import java.io.File;
import java.io.FileNotFoundException;
import java.net.SocketTimeoutException;
import java.util.ArrayList;
import java.util.Scanner;

public class Labirint {
    public ArrayList<ArrayList<Integer>> Matrice = new ArrayList<ArrayList<Integer>>();
    public int[][] Solutie;


    void readMatrice() throws FileNotFoundException {
        Scanner input = new Scanner(new File("./Matrice.txt"));
        while(input.hasNextLine())
        {
            Scanner colReader = new Scanner(input.nextLine());
            ArrayList col = new ArrayList();
            while(colReader.hasNextInt())
            {
                col.add(colReader.nextInt());
            }
            Matrice.add(col);
        }
        Solutie(Matrice);
        System.out.println();
    }


    public void printLabirint (ArrayList<ArrayList<Integer>> mat, Graphics g) { //black = zid, grey = drum, red = Solutie
        for (int i = 0; i < mat.size(); i++) {
            for (int j = 0; j < mat.get(i).size(); j++) {
                if (Matrice.get(i).get(j) == 1) {
                    g.setColor(Color.GRAY);
                } else {
                    g.setColor(Color.BLACK);
                }
                if(mat.get(i).get(j) == 1) {
                    g.setColor(Color.RED);
                }
                g.fillRect(100+10*i,100+10*j,10*i,10*j);
            }
        }
    }

    private void Solutie(ArrayList<ArrayList<Integer>> mat) {
        Solutie = new int[mat.size()][mat.size()];
        for (int i = 0; i <mat.size(); i++) {
            for (int j = 0; j < mat.get(i).size(); j++) {
                Solutie[i][j] = mat.get(i).get(j);
              //  System.out.print(" " + Solutie[i][j] + " ");
            }
            System.out.println();
        }
    }
    
    private boolean miscarePermisa(ArrayList<ArrayList<Integer>> mat, int x, int y) {
        return (mat.get(x).get(y) == 1);
    }

    private boolean parcurgereLabirint(ArrayList<ArrayList<Integer>> mat, int x, int y, ArrayList<ArrayList<Integer>> solutie, int horizontal, int veritcal) {
        if (x == mat.size() || y == mat.size() || x == -1 || y == -1) { // daca am iesit din labirint
           // solutie.get(x).set(y,1);
            return true;
        }

        if (miscarePermisa(mat, x, y)) {
            solutie.get(x).set(y,1);

            if (parcurgereLabirint(mat, x + horizontal, y, solutie, horizontal, veritcal)) // cautam soultie deplasandu-ne in functie de horizontal
                return true;

            if (parcurgereLabirint(mat, x, y + veritcal, solutie, horizontal, veritcal)) // cautam soultie deplasandu-ne in functie de vertical
                return true;

            solutie.get(x).set(y,0); // daca nu gasim solutie, stergem drumul marcat ca solutie partiala
            return false;
        }
        return false;
    }

    void iesire(ArrayList<ArrayList<Integer>> mat, int horizontal, int vertical, int x, int y) {
        ArrayList<ArrayList<Integer>> solutie= new ArrayList<ArrayList<Integer>>(); // initiem matricea solutie
        for(int i=0; i<Matrice.size(); i++) {
            solutie.add(new ArrayList<Integer>());
        }

        for (int i = 0; i <Matrice.size(); i++) {
            for (int j = 0; j < Matrice.size(); j++) {
                solutie.get(i).add(j,0);
            }
        }

        if (!parcurgereLabirint(mat, y, x, solutie, vertical, horizontal)) { //x si y; horizontal si vertical sunt inversate
            System.out.print("Nu exista solutie.");
            for(int i =0;i<Solutie.length;i++) {
                for(int j=0;j<Solutie[i].length;j++) {
                    Solutie[i][j] = 0;
                }
            }
        } else {Solutie(solutie);
        }
    }
}