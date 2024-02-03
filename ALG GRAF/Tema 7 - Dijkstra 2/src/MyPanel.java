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
    Graf graf = new Graf();
    ReadXMLFile file = new ReadXMLFile();
    Point pointStart = null;
    Point pointEnd = null;
    boolean isDragging = false;
    public MyPanel() throws FileNotFoundException {
      //  graf.readMatriceAdiacenta();
       // graf.createGraphfromMatrix();
     //   graf.createListaAdiacenta();
     //   graf.createGraphfromList();
       // graf.generareAPM();
        System.out.println("Din ce nod plecam?");
        Scanner S=new Scanner(System.in);
        int x=S.nextInt();
        System.out.println("In ce nod ajungem?");
        int y=S.nextInt();
       file.read(graf);
       graf.getDistances();
       graf.createListaAdiacenta();
       graf.dijkstra(x, y); //112 , 606 && 13 , 13000 && 37 , 39636 && 10 , 33489 && 25000 , 40582
        System.out.println( (double)(graf.getLatMax() - graf.getLatMin()) /(double)(graf.getLongMax() - graf.getLongMin()));

       graf.getDistances();
       // graf.dijkstra(graf.MatriceAdiacenta);
        // borderul panel-ului
        setBorder(BorderFactory.createLineBorder(Color.black));
        addMouseListener(new MouseAdapter() {
            //evenimentul care se produce la apasarea mousse-ului
            public void mousePressed(MouseEvent e) {
                pointStart = e.getPoint();
            }

            //evenimentul care se produce la eliberarea mousse-ului
            public void mouseReleased(MouseEvent e) {
            }
        });

        addMouseMotionListener(new MouseMotionAdapter() {
            //evenimentul care se produce la drag&drop pe mousse
            public void mouseDragged(MouseEvent e) {
                pointEnd = e.getPoint();
                isDragging = true;
                repaint();
            }
        });
    }

    //se executa atunci cand apelam repaint()
    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);//apelez metoda paintComponent din clasa de baza
        g.drawString("This is Luxembourg!", 10, 20);
        setBackground(Color.orange);
        //deseneaza arcele existente in lista
		/*for(int i=0;i<listaArce.size();i++)
		{
			listaArce.elementAt(i).drawArc(g);
		}*/
      /*  for (myArc a : graf.getListaArce())
        {
            a.drawArc(g);
        }*/
       graf.drawArcs(g);
        //deseneaza arcul curent; cel care e in curs de desenare
     /*   if (pointStart != null)
        {
            g.setColor(Color.RED);
            g.drawLine(pointStart.x, pointStart.y, pointEnd.x, pointEnd.y);
        }*/
        //deseneaza lista de noduri
       /* for(int i=0; i<graf.getListaNoduri().size(); i++)
        {
            graf.getListaNoduri().elementAt(i).drawNode(g, graf.getNode_diam());
        } */
		/*for (Node nod : listaNoduri)
		{
			nod.drawNode(g, node_diam, node_Diam);
		}*/
    }
}
