import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;

public class myArc {

    private int idNod1;
    private int idNod2;
    private int length;

    public int getIdNod1() {
        return idNod1;
    }

    public void setIdNod1(int idNod1) {
        this.idNod1 = idNod1;
    }

    public int getIdNod2() {
        return idNod2;
    }

    public void setIdNod2(int idNod2) {
        this.idNod2 = idNod2;
    }

    public int getLength() {
        return length;
    }

    public void setLength(int length) {
        this.length = length;
    }

    public myArc(int x, int y,int len) {
        idNod1 = x;
        idNod2 = y;
        length = len;
    }

    /*public void drawArc(Graphics g) {
        if (start != null) {
            g.setColor(Color.BLACK);
            g.drawLine(start.x, start.y, end.x, end.y);
            drawCerc(g);
        }
    }


    public void drawCerc(Graphics g) {
        g.setColor(Color.BLACK);
        g.fillOval((int) (end.x + Math.signum(start.x - end.x) * Math.abs(start.x - end.x) * 1 / 7) - 5, (int) (end.y + Math.signum(start.y - end.y) * Math.abs(start.y - end.y) * 1 / 7) - 5, 10, 10);
    }

    private void calcLength() {
        length = (int) Math.sqrt((Math.pow(2, Math.abs(start.x + end.x)) + Math.pow(2, Math.abs(start.y + end.y))));
    }*/
}