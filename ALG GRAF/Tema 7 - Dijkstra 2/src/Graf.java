import javafx.util.Pair;

import java.awt.*;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.Stack;
import java.util.Vector;

public class Graf {
    private int latMax;
    private int longMax;
    private int longMin;
    private int latMin;
    private double scaleLong;
    private double scaleLat;
    private int nodeNr;
    private int node_diam;
    Vector<myNode> listaNoduri;
    Vector<myArc> listaArce;
    ArrayList<ArrayList <Pair<Integer,Integer>>> listaAdiacenta = new ArrayList<ArrayList <Pair<Integer,Integer>>>();
    ArrayList<ArrayList<Integer>> MatriceAdiacenta = new ArrayList<ArrayList<Integer>>();
    ArrayList <Integer> distante = new ArrayList<>();
    int matriceAdiac[][];

    public Graf() {
        node_diam = 30;
        nodeNr = 1;
        listaNoduri = new Vector<myNode>();
        listaArce = new Vector<myArc>();
    }

    public int getNodeNr() {
        return nodeNr;
    }

    public void setNodeNr(int nodeNr) {
        this.nodeNr = nodeNr;
    }

    public int getNode_diam() {
        return node_diam;
    }

    public void setNode_diam(int node_diam) {
        this.node_diam = node_diam;
    }

    public Vector<myNode> getListaNoduri() {
        return listaNoduri;
    }

    public void setListaNoduri(Vector<myNode> listaNoduri) {
        this.listaNoduri = listaNoduri;
    }

    public Vector<myArc> getListaArce() {
        return listaArce;
    }

    public void setListaArce(Vector<myArc> listaArce) {
        this.listaArce = listaArce;
    }

    public void setLatMax(int latMax) {
        this.latMax = latMax;
    }

    public int getLatMax() {
        return latMax;
    }

    public int getLongMax() {
        return longMax;
    }

    public int getLongMin() {
        return longMin;
    }

    public int getLatMin() {
        return latMin;
    }

    public void setLongMax(int longMax) {
        this.longMax = longMax;
    }

    public void setLongMin(int longMin) {
        this.longMin = longMin;
    }

    public void setLatMin(int latMin) {
        this.latMin = latMin;
    }

    //metoda care se apeleaza la eliberarea mouse-ului
    public boolean addNode(int x, int y) {
        boolean inNode = false;

        for(int i = 0 ; i <listaNoduri.size();i++) {
            if(x>listaNoduri.get(i).getCoordX() - node_diam && x<listaNoduri.get(i).getCoordX() +node_diam
                    && y>listaNoduri.get(i).getCoordY() - node_diam && y<listaNoduri.get(i).getCoordY()+node_diam) {
                inNode = true;
            }
        }
        if(!inNode) {
            myNode node = new myNode(x, y, nodeNr);
            listaNoduri.add(node);
            nodeNr++;
            return true;
        } else {
            return false;
        }
        }

        public void addArc(int x, int y, int len) {
            myArc arc = new myArc(x,y,len);
            listaArce.add(arc);
        }

        public void readMatriceAdiacenta() throws FileNotFoundException {
            Scanner input = new Scanner(new File("./Matrice Adiacenta.txt"));
            while(input.hasNextLine())
            {
                Scanner colReader = new Scanner(input.nextLine());
                ArrayList col = new ArrayList();
                while(colReader.hasNextInt())
                {
                    col.add(colReader.nextInt());
                }
                MatriceAdiacenta.add(col);
            }
            printMatriceAdiacenta();
        }

        public void printMatriceAdiacenta() {
            for (int i = 0; i < MatriceAdiacenta.size(); i++) {
                for (int j = 0; j < MatriceAdiacenta.size(); j++) {
                    System.out.print(MatriceAdiacenta.get(i).get(j));
                }
                System.out.println();
            }
        }

        public void createGraphfromMatrix() {
            for (int i = 0; i < MatriceAdiacenta.size(); i++) {
                addNode((int)Math.floor((Math.random() * (900-100) + 100)),(int)Math.floor((Math.random() * (900-100) + 100)));
            }
            for (int i = 0; i < MatriceAdiacenta.size(); i++) {
                for (int j = 0; j < MatriceAdiacenta.size(); j++) {
                    if(MatriceAdiacenta.get(i).get(j) != 0) {
                     /*   addArc(listaNoduri.get(i).getCoordX() + node_diam/2,listaNoduri.get(i).getCoordY()+ node_diam/2,
                                listaNoduri.get(j).getCoordX()+ node_diam/2, listaNoduri.get(j).getCoordY()+ node_diam/2);*/
                    }
                }
            }
        }

    public void createGraphfromList() {
        for (int i = 0; i < listaAdiacenta.size(); i++) {
            addNode((int)Math.floor((Math.random() * (900-100) + 100)),(int)Math.floor((Math.random() * (900-100) + 100)));
        }
        for (int i = 0; i < listaAdiacenta.size(); i++) {
            for (int j = 0; j < listaAdiacenta.get(i).size(); j++) {
                 /*   addArc(listaNoduri.get(i).getCoordX() + node_diam/2,listaNoduri.get(i).getCoordY()+ node_diam/2,
                            listaNoduri.get(listaAdiacenta.get(i).get(j)).getCoordX()+ node_diam/2, listaNoduri.get(listaAdiacenta.get(i).get(j)).getCoordY()+ node_diam/2);*/
                     // addArc(listaNoduri.get(listaAdiacenta.get(i).get(j)).getCoordX()+ node_diam/2, listaNoduri.get(listaAdiacenta.get(i).get(j)).getCoordY()+ node_diam/2,
                       //    listaNoduri.get(i).getCoordX() + node_diam/2,listaNoduri.get(i).getCoordY()+ node_diam/2); // pentru ca e graf neorientat, adaugam si perechea
                }
            }
        }

    public void createListaAdiacenta() {
        listaAdiacenta = new ArrayList<ArrayList <Pair<Integer,Integer>>>();
        for(int i=0; i<listaNoduri.size(); i++)
            listaAdiacenta.add(new ArrayList <Pair<Integer,Integer>>());

        for (int i = 0; i <listaArce.size(); i++) {
                    listaAdiacenta.get(listaArce.get(i).getIdNod1()).add(new Pair<Integer, Integer> (listaArce.get(i).getIdNod2(), listaArce.get(i).getLength()));
                }
        getLatScale();
        getLongScale();
        System.out.println("Lista adiacenta:");
       // printListaAdiacenta();
    }

    public void printListaAdiacenta(){
        for(int i=0; i<listaAdiacenta.size(); i++){
            System.out.println(i + ": " + listaAdiacenta.get(i));
        }
    }

     public void drawArcs(Graphics g) {
         g.setColor(Color.BLACK);
        for(int i = 0 ; i<listaArce.size(); i ++) {
            if(listaArce.get(i).getLength() == -1) {
                g.setColor(Color.RED);
            } else {
                g.setColor(Color.BLACK);
            }
                g.drawLine((int) ((listaNoduri.get(listaArce.get(i).getIdNod1()).getCoordX() - longMin) * scaleLong), (int) ((listaNoduri.get(listaArce.get(i).getIdNod1()).getCoordY()  - latMin)* scaleLat),
                        (int) ((listaNoduri.get(listaArce.get(i).getIdNod2()).getCoordX() - longMin)* scaleLong), (int) ((listaNoduri.get(listaArce.get(i).getIdNod2()).getCoordY() - latMin)* scaleLat));
             //   System.out.print(((listaNoduri.get(listaArce.get(i).getIdNod1()).getCoordX() - longMin) * scaleLong) + "  ");
             //   System.out.println(((listaNoduri.get(listaArce.get(i).getIdNod1()).getCoordY()  - latMin)* scaleLat));
               // drawCerc(g);
            }
        }

  /*  public void getDistances(int pozX, int pozY) {
        for(int i =0; i<listaNoduri.size();i++) {
            distante.add(0);
        }

        for(int i =0; i<distante.size();i++) {
               distante.set(i, (int)Math.sqrt(Math.pow(Math.abs(listaNoduri.get(pozX).getCoordX() - listaNoduri.get(i).getCoordX()),2) + Math.pow(Math.abs(listaNoduri.get(pozX).getCoordY() - listaNoduri.get(i).getCoordY()),2)));
                System.out.println(distante.get(i));
            }
        }*/

    public void getDistances() {
  /*      matriceAdiac = new int[42313][42313];
        System.out.println(listaNoduri.size());
        for(int i =0; i<42313;i++) {
            for (int j = 0; j < 42313; j++) {
                MatriceAdiacenta.get(i).add(0);
            }
        }*/

       /* for(int i =0; i<listaNoduri.size();i++) {
            for(int j = i; j<listaNoduri.size();j++) {
                MatriceAdiacenta.get(i).set(j, (int)Math.sqrt(Math.pow(Math.abs(listaNoduri.get(i).getCoordX() - listaNoduri.get(j).getCoordX()),2) + Math.pow(Math.abs(listaNoduri.get(i).getCoordY() - listaNoduri.get(j).getCoordY()),2)));
                System.out.println(MatriceAdiacenta.get(i).get(j));
                System.out.println(i);
            }
        }*/
    }

    int minDist(int d[], ArrayList<Integer> W)
    {
        int distMin = Integer.MAX_VALUE, nodMin = -1;

        for (int i = 0; i < W.size(); i++) {
        //    if(d[W.get(i)]<500)
         //   System.out.println(d[W.get(i)]);
            if (d[W.get(i)] <= distMin) {
                distMin = d[W.get(i)];
                nodMin = W.get(i);
            }

        }
        return nodMin;
    }

    private void getLongScale() {
        scaleLong = (double)1000 / (longMax - longMin);
    }

    private void getLatScale() {
        scaleLat = (double)930 / (latMax - latMin);
    }

    void printDrum(int start, int dest, int d[], int p[]) // replace stack with array ( heap space)
    {
        int i = dest;
        int count = 0;

        do {
            count++;
            for(int k = 0; k < listaArce.size(); k++) {
                if(listaArce.get(k).getIdNod1() == p[i] && listaArce.get(k).getIdNod2() == i)
                listaArce.get(k).setLength(-1); // daca e drum dupa dijkstra, distanta deviene -1
            }
           // pInvers.push(i);
            i = p[i];
            System.out.println(p[i]);
        } while(i != start);
    }

    void dijkstra(int start, int destinatie) {
        ArrayList<Integer> W = new ArrayList<>(listaNoduri.size());
        for (int i = 0; i < listaNoduri.size(); i++) {
            W.add(i);
        }
        int d[] = new int[listaNoduri.size()];

        int p[] = new int[listaNoduri.size()];

        for (int i = 0; i < listaNoduri.size(); i++) {
            d[i] = 9999999;
            p[i] = 0;
        }

        d[start] = 0;
        p[start] = 0;
        int x = 0;
        while (W.size() > 0) {
            x = minDist(d, W);
            W.remove(Integer.valueOf(x));

          /* for (int i = 0; i < W.size(); i++) {
               if (listaAdiacenta.get(x).get(i).getValue() != 0 && d[x] + listaAdiacenta.get(x).get(i).getValue() < d[i] && d[x] != Integer.MAX_VALUE) {// need last one?
                   d[i] = d[x] + listaAdiacenta.get(x).get(i).getValue();
                   p[i] = x;
               }
           }*/
            for (int i = 0; i < W.size(); i++) {
                for (int j = 0; j < listaAdiacenta.get(x).size(); j++) {
                    //    System.out.print(listaAdiacenta.get(x).get(j) + "     ");
                    //   System.out.println(i);
                    if (listaAdiacenta.get(x).get(j).getKey() == i && d[x] + listaAdiacenta.get(x).get(j).getValue() < d[i]) {
                        d[i] = d[x] + listaAdiacenta.get(x).get(j).getValue();
                        p[i] = x;
                        //  System.out.println(d[i]);
                    }
                }
            }
        }
        System.out.println("outdijkstra");

        for (int i = 0; i < d.length; i++) {
            System.out.println("Distanta de la " +i+ "  ->   " + " e " +d[i]);
        }
        if( p[destinatie] == 0 ) {
            System.out.println("Nu exista drum intre sursa si destiantie.");
        }
        else {
            printDrum(start, destinatie, d, p);
        }
    }
}

