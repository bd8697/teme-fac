import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.Vector;

public class Graf {
    private int nodeNr;
    private int node_diam;
    private Vector<Node> listaNoduri;
    private Vector<Arc> listaArce;
    ArrayList<ArrayList<Integer>> listaAdiacenta = new ArrayList<ArrayList<Integer>>();
    ArrayList<ArrayList<Integer>> MatriceAdiacenta = new ArrayList<ArrayList<Integer>>();

    public Graf() {
        node_diam = 30;
        nodeNr = 1;
        listaNoduri = new Vector<Node>();
        listaArce = new Vector<Arc>();
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

    public Vector<Node> getListaNoduri() {
        return listaNoduri;
    }

    public void setListaNoduri(Vector<Node> listaNoduri) {
        this.listaNoduri = listaNoduri;
    }

    public Vector<Arc> getListaArce() {
        return listaArce;
    }

    public void setListaArce(Vector<Arc> listaArce) {
        this.listaArce = listaArce;
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
            Node node = new Node(x, y, nodeNr);
            listaNoduri.add(node);
            nodeNr++;
            return true;
        } else {
            return false;
        }
        }

        public void addArc(int x1, int y1, int x2, int y2) {
            Arc arc = new Arc(x1,y1,x2,y2);
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
                        addArc(listaNoduri.get(i).getCoordX() + node_diam/2,listaNoduri.get(i).getCoordY()+ node_diam/2,
                                listaNoduri.get(j).getCoordX()+ node_diam/2, listaNoduri.get(j).getCoordY()+ node_diam/2);
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
                    addArc(listaNoduri.get(i).getCoordX() + node_diam/2,listaNoduri.get(i).getCoordY()+ node_diam/2,
                            listaNoduri.get(listaAdiacenta.get(i).get(j)).getCoordX()+ node_diam/2, listaNoduri.get(listaAdiacenta.get(i).get(j)).getCoordY()+ node_diam/2);
                     // addArc(listaNoduri.get(listaAdiacenta.get(i).get(j)).getCoordX()+ node_diam/2, listaNoduri.get(listaAdiacenta.get(i).get(j)).getCoordY()+ node_diam/2,
                       //    listaNoduri.get(i).getCoordX() + node_diam/2,listaNoduri.get(i).getCoordY()+ node_diam/2); // pentru ca e graf neorientat, adaugam si perechea
                }
            }
        }

    public void createListaAdiacenta() {

        listaAdiacenta = new ArrayList<ArrayList<Integer>>();
        for(int i=0; i<MatriceAdiacenta.size(); i++)
            listaAdiacenta.add(new ArrayList<Integer>());

        for (int i = 0; i <MatriceAdiacenta.size(); i++) {
            for (int j = 0; j < MatriceAdiacenta.size(); j++) {
                if (MatriceAdiacenta.get(i).get(j) == 1) {
                    listaAdiacenta.get(i).add(j);
                }
            }
        }

        System.out.println("Lista adiacenta:");
        printListaAdiacenta();
    }

    public void printListaAdiacenta(){
        for(int i=0; i<listaAdiacenta.size(); i++){
            System.out.println(i + ": " + listaAdiacenta.get(i));
        }
    }

    private int costMin(int cost[], boolean pozOcupata[]) { // returneaza indexul nodului cu cost minim
        double valMin = Double.POSITIVE_INFINITY;
        int iMin = -1;

        for (int i = 0; i < MatriceAdiacenta.size(); i++) {
            if (!pozOcupata[i] && cost[i] < valMin) {
                valMin = cost[i];
                iMin = i;
            }
        }
        return iMin;
    }

    void generareAPM() {
        int[] APM;
        APM = new int[MatriceAdiacenta.size()];
        int[] cost;
        cost = new int[MatriceAdiacenta.size()];
        boolean[] pozOcupata;
        pozOcupata = new boolean[MatriceAdiacenta.size()];

        for (int i = 0; i < MatriceAdiacenta.size(); i++) {
            cost[i] = (int) Double.POSITIVE_INFINITY;
            pozOcupata[i] = false;
        }

        APM[0] = -1;
        cost[0] = 0;

        for (int i= 0; i < MatriceAdiacenta.size(); i++) {
            int nodCostMin = costMin(cost, pozOcupata);
            pozOcupata[nodCostMin] = true;
            for (int j = 0; j <  MatriceAdiacenta.size(); j++) {
                if (MatriceAdiacenta.get(nodCostMin).get(j) > 0 && MatriceAdiacenta.get(nodCostMin).get(j) < cost[j] && !pozOcupata[j]) {
                    System.out.println("hi");
                    APM[j] = nodCostMin;
                    cost[j] = MatriceAdiacenta.get(nodCostMin).get(j);
                }
            }
        }
      /*  for(int i = 0;i<MatriceAdiacenta.size();i++) {
            System.out.print(APM[i] + " ");
        }*/
        afisareAPM(APM);
        }

    private void afisareAPM(int APM[]) {
        System.out.println("Arborele partial minim obtinut este format din: ");
        System.out.println("Muchia: cu Costul:");
        for (int i = 1; i < MatriceAdiacenta.size(); i++) {
            System.out.println(APM[i] + " - " + i  + "      " + MatriceAdiacenta.get(i).get(APM[i]));
        }
    }
}

