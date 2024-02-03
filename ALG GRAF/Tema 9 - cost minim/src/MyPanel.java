import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionAdapter;
import java.io.FileNotFoundException;
import javax.swing.BorderFactory;
import javax.swing.JPanel;

public class MyPanel extends JPanel {
    Graf graf = new Graf();
    Point pointStart = null;
    Point pointEnd = null;
    boolean isDragging = false;
    public MyPanel() throws FileNotFoundException {
        graf.readMatriceAdiacenta();
        graf.createGraphfromMatrix();
        graf.FFE(0,5);
     //   System.out.println(graf.PBF(0,5));

     //   graf.createListaAdiacenta();
     //   graf.createGraphfromList();
      //  graf.generareAPM();
        // borderul panel-ului
        setBorder(BorderFactory.createLineBorder(Color.black));
        addMouseListener(new MouseAdapter() {
            //evenimentul care se produce la apasarea mousse-ului
            public void mousePressed(MouseEvent e) {
                pointStart = e.getPoint();
            }

            //evenimentul care se produce la eliberarea mousse-ului
            public void mouseReleased(MouseEvent e) {
                if (!isDragging) {
                    if(graf.addNode(e.getX(), e.getY()) == true) {
                        repaint();
                    };
                }
                else {
                    //tofix
                    boolean inNode = false;
                    for(int i =0;i<graf.getListaNoduri().size();i++) {
                        if(e.getX()>graf.getListaNoduri().get(i).getCoordX() && e.getX()<graf.getListaNoduri().get(i).getCoordX() + graf.getNode_diam()
                                && e.getY()>graf.getListaNoduri().get(i).getCoordY() && e.getY()<graf.getListaNoduri().get(i).getCoordY()+ graf.getNode_diam()) {
                            inNode = true;
                        }
                    }
                    if(inNode==true) {
                        Arc arc = new Arc(pointStart.x, pointStart.y, pointEnd.x, pointEnd.y);
                        graf.getListaArce().add(arc);
                    }
                }
                pointStart = null;
                isDragging = false;
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
        g.drawString("This is my Graph!", 10, 20);
        //deseneaza arcele existente in lista
		/*for(int i=0;i<listaArce.size();i++)
		{
			listaArce.elementAt(i).drawArc(g);
		}*/
        for (Arc a : graf.getListaArce())
        {
            a.drawArc(g);
        }
        //deseneaza arcul curent; cel care e in curs de desenare
        if (pointStart != null)
        {
            g.setColor(Color.RED);
            g.drawLine(pointStart.x, pointStart.y, pointEnd.x, pointEnd.y);
        }
        //deseneaza lista de noduri
        for(int i=0; i<graf.getListaNoduri().size(); i++)
        {
            graf.getListaNoduri().elementAt(i).drawNode(g, graf.getNode_diam());
        }
		/*for (Node nod : listaNoduri)
		{
			nod.drawNode(g, node_diam, node_Diam);
		}*/
    }
}