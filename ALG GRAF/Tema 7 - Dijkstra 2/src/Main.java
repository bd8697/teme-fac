import javax.swing.JFrame;
import javax.swing.SwingUtilities;
import java.awt.*;
import java.io.FileNotFoundException;

public class Main
{
    private static void initUI() throws FileNotFoundException {
        JFrame f = new JFrame("Harta Luxembourg-ului");
        //sa se inchida aplicatia atunci cand inchid fereastra
        f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        //imi creez ob MyPanel
        f.add(new MyPanel());
        //setez dimensiunea ferestrei
        f.setSize(1100, 1000);

        //fac fereastra vizibila
        f.setVisible(true);
    }

    public static void main(String[] args)
    {
        //pornesc firul de executie grafic
        //fie prin implementarea interfetei Runnable, fie printr-un ob al clasei Thread
        SwingUtilities.invokeLater(new Runnable() //new Thread()
        {
            public void run()
            {
                try {
                    initUI();
                } catch (FileNotFoundException e) {
                    e.printStackTrace();
                }
            }
        });
    }
}
