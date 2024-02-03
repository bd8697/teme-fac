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
      //  graf.createGraphfromMatrix();
        graf.createListaAdiacenta();
        graf.createGraphfromList();

        setBorder(BorderFactory.createLineBorder(Color.black));
        addMouseListener(new MouseAdapter() {
            public void mousePressed(MouseEvent e) {
                pointStart = e.getPoint();
            }

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
            public void mouseDragged(MouseEvent e) {
                pointEnd = e.getPoint();
                isDragging = true;
                repaint();
            }
        });
    }

    protected void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        g.drawString("This is my Graph!", 10, 20);
		/*for(int i=0;i<listaArce.size();i++)
		{
			listaArce.elementAt(i).drawArc(g);
		}*/
        for (Arc a : graf.getListaArce())
        {
            a.drawArc(g);
        }
        if (pointStart != null)
        {
            g.setColor(Color.RED);
            g.drawLine(pointStart.x, pointStart.y, pointEnd.x, pointEnd.y);
        }
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
