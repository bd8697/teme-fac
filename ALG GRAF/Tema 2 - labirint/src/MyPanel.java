import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionAdapter;
import java.io.FileNotFoundException;
import java.util.Scanner;
import javax.swing.BorderFactory;
import javax.swing.JPanel;

public class MyPanel extends JPanel {

    Labirint lab = new  Labirint();
    public MyPanel() throws FileNotFoundException {
        lab.readMatrice();
        System.out.println("Introduceti coordonatele de  start (-1, -1 pentru coordonate aleatorii): ");
        Scanner s = new Scanner(System.in);
        int x = s.nextInt();
        int y = s.nextInt();
        System.out.println(x);
        System.out.println(y);
        if( x== -1 && y == -1) {
            x = (int) (Math.random() * lab.Matrice.size());
            y = (int) (Math.random() * lab.Matrice.size());
        }
        lab.iesire(lab.Matrice, -1, -1,x,y); // lab.iesire(Matrice_labirint, directie_orizontala, directie_verticala,x,y)

        setBorder(BorderFactory.createLineBorder(Color.black));
    }

    //se executa atunci cand apelam repaint()
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        g.drawString("Labirint", 10, 20);
        System.out.println(lab.Matrice.size());
        for (int i = 0; i < lab.Matrice.size(); i++) {
            System.out.println();
            for (int j = 0; j <lab.Matrice.get(i).size(); j++) {
                System.out.print(lab.Matrice.get(i).get(j));
            }
                };

        for (int i = 0; i < lab.Matrice.size(); i++) {
            for (int j = 0; j <lab.Matrice.get(i).size(); j++) {
                if (lab.Matrice.get(i).get(j) == 1) {
                    g.setColor(Color.GRAY);
                } else {
                    g.setColor(Color.BLACK);
                }
                if(lab.Solutie[i][j] == 1) {
                  g.setColor(Color.RED);
                }
                g.fillRect(100+30*j,100+30*i,30,30);
            }
        }
    }
}
