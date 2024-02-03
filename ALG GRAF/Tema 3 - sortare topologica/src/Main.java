import javax.swing.JFrame;
import javax.swing.SwingUtilities;
import java.io.FileNotFoundException;

public class Main
{
    private static void initUI() throws FileNotFoundException {
        JFrame f = new JFrame("Algoritmica Grafurilor");
        f.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        f.add(new MyPanel());
        f.setSize(1000, 1000);
        f.setVisible(true);
    }

    public static void main(String[] args)
    {
        SwingUtilities.invokeLater(new Runnable()
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
