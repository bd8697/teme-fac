import java.awt.*;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.*;

public class Graf {
    private int nodeNr;
    private int node_diam;
    private Vector<Node> listaNoduri;
    private ArrayList<Integer> indexNodSort;
    private Vector<Arc> listaArce;
    ArrayList<ArrayList<Integer>> listaAdiacenta = new ArrayList<ArrayList<Integer>>();
    ArrayList<ArrayList<Integer>> MatriceAdiacenta = new ArrayList<ArrayList<Integer>>();

    public Graf() {
        node_diam = 30;
        nodeNr = 1;
        listaNoduri = new Vector<Node>();
        listaArce = new Vector<Arc>();
        indexNodSort = new ArrayList<>(0);
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
        if(inNode == false) {
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
                    if(MatriceAdiacenta.get(i).get(j) == 1) {
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

    public void sortareTopologica() {
        Stack stivaSortare = new Stack();
        boolean[] vizitat = new boolean[listaAdiacenta.size()];

        for (int i = 0; i < listaAdiacenta.size(); i++)
             vizitat[i] = false; // marcam toate nodurile ca fiind enevizitate

        for (int i = 0; i < listaAdiacenta.size(); i++) {
            if (!vizitat[i]) {
                nodVizitat(i, vizitat, stivaSortare);  // pentru fiecare nod in parte
            }
        }

        int count = 0;
        int varfStiva = 0;
        while (!stivaSortare.empty()) {
            varfStiva = (int) stivaSortare.pop();
            System.out.print(varfStiva + " ");
            listaNoduri.get(varfStiva).setIndexSort(count);
            count++;
                }

            }

    private void nodVizitat(int v, boolean[] vizitat, Stack stiva) {
        vizitat[v] = true;
        for(int j = 0; j<listaAdiacenta.get(v).size();j++) {
            if (!vizitat[listaAdiacenta.get(v).get(j)]) {
                nodVizitat(listaAdiacenta.get(v).get(j), vizitat, stiva);
            }
        }
        stiva.push(v); // adaugam nodul curent la stiva
        // cu cat un element e adaugat in stiva mai devreme, cu atat mai tarziu apare in soratarea topologica
    }
}
