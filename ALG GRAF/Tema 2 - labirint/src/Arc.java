import java.awt.Color;
import java.awt.Graphics;
import java.awt.Point;

public class Arc
{
    private Point start;
    private Point end;

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
        }
    }
}
