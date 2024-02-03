import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.Stack;
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


    void PDF(int v,boolean vizitat[]) {  // Parcurgere in adancime incepand de la nodul v
        vizitat[v] = true;
        System.out.print(v + " ");

       for(int i = 0;i<listaAdiacenta.get(v).size();i++)
        {
            if (!vizitat[listaAdiacenta.get(v).get(i)])
               PDF(listaAdiacenta.get(v).get(i), vizitat); // apelare recursiva pentru fiecare nod adiacent
        }
    }

    void PDF(int v, boolean[] vizitat, Stack stiva) {

        vizitat[v] = true;

        for (int i = 0; i < listaAdiacenta.get(v).size(); i++) {
            if(!vizitat[listaAdiacenta.get(v).get(i)])
                PDF(listaAdiacenta.get(v).get(i), vizitat, stiva); // apelare recursiva pentru toate nodurile adiacente
        }
            // cu cat un nod e adaugat mai devreme in stiva, cu atat apare mai tarziu in componenta conexa
        stiva.push(v);
    }

    Graf getInvers() {
        Graf grafInvers = new Graf();
        for (int i = 0; i < listaAdiacenta.size(); i++) {
            grafInvers.listaAdiacenta.add(new ArrayList<Integer>());
        }
        for (int i = 0; i < listaAdiacenta.size(); i++) {
            for (int j = 0; j < listaAdiacenta.get(i).size(); j++) {
                grafInvers.listaAdiacenta.get(listaAdiacenta.get(i).get(j)).add(i); // inverseaza toate arcele
            }
        }
        return grafInvers;
    }

    void componenteTareConexe() {
        Stack stivaComponente = new Stack();
        boolean[] vizitat = new boolean[listaAdiacenta.size()];
        for(int i = 0; i < listaAdiacenta.size(); i++) {
            vizitat[i] = false;
        }
        
        for (int i = 0; i < listaAdiacenta.size(); i++) {
            if (!vizitat[i]) {
                PDF(i, vizitat, stivaComponente);
            }
        }
        Graf grafInvers = getInvers();

        System.out.println("here");
        System.out.println(stivaComponente);
        // In punctul asta, stiva contine parcirgerea PDF a grafului, in ordine inversa (?)
        while (!stivaComponente.empty())
        {
            int varfStiva = (int)stivaComponente.pop();
        }
    }
}