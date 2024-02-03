import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;

public class Arc
{
    private Point start;
    private Point end;
    private int length;

    public Point getStart () {
        return start;
    }
    public Arc(int x1, int y1, int x2, int y2)
    {   this.start = new Point();
        this.end = new Point();
        this.start.x = x1;
        this.start.y = y1;
        this.end.x = x2;
        this.end.y = y2;
    }

    public void drawArc(Graphics g)
    {
        if (start != null)
        {
            g.setColor(Color.BLACK);
            g.drawLine(start.x, start.y, end.x, end.y);
            drawCerc(g);
        }
    }

    public void drawCerc(Graphics g) {
        g.setColor(Color.BLACK);
        g.fillOval((int) (end.x + Math.signum(start.x - end.x) * Math.abs(start.x - end.x) * 1/3) -5, (int) (end.y + Math.signum(start.y - end.y) * Math.abs(start.y - end.y) * 1/3) - 5, 10, 10);
    }

    private void calcLength() {
        length = (int) Math.sqrt((Math.pow(2,Math.abs(start.x +end.x)) + Math.pow(2,Math.abs(start.y + end.y))));
    }
}
