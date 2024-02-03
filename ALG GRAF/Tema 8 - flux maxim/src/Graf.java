import java.io.File;
import java.io.FileNotFoundException;
import java.util.*;

public class Graf {
    private int nodeNr;
    private int node_diam;
    private Vector<Node> listaNoduri;
    private Vector<Arc> listaArce;
    ArrayList<ArrayList<Integer>> listaAdiacenta = new ArrayList<ArrayList<Integer>>();
    ArrayList<ArrayList<Integer>> MatriceAdiacenta = new ArrayList<ArrayList<Integer>>();
    ArrayList<Integer> DMF = new ArrayList<>();

    public Graf() {
        node_diam = 30;
        nodeNr = 0;
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

  // graful e stocat in matrice de adiacenta, valaorea arcului (i,j) reprezentand capacitatea.

    void FluxMaxim (int sursa, int destinatie) {
        ArrayList<Integer> DMF = new ArrayList<>(0);
        ArrayList<ArrayList<Integer>> f = new ArrayList<ArrayList<Integer>>(0); // aici stocam flux maxim
        ArrayList<ArrayList<Integer>> r = new ArrayList<ArrayList<Integer>>(0);
        int fluxMin = Integer.MAX_VALUE;
        for (int i = 0; i < MatriceAdiacenta.size(); i++) { // initial flux = capacitate (??)
            f.add( new ArrayList<Integer>(0));
            r.add( new ArrayList<Integer>(0));
            for (int j = 0; j < MatriceAdiacenta.get(i).size(); j++) {
                f.get(i).add(MatriceAdiacenta.get(i).get(j));
                r.get(i).add(MatriceAdiacenta.get(i).get(j));
            }
        }
     /*   for (int i = 0; i < MatriceAdiacenta.size(); i++) {
            r.add( new ArrayList<Integer>(0));
            for (int j = 0; j < MatriceAdiacenta.get(i).size(); j++) {
                r.get(i).add(0);
            }
        } */

      /*  for (int i = 0; i < MatriceAdiacenta.size(); i++) {
            for (int j = 0; j < MatriceAdiacenta.get(i).size(); j++) {
                r.get(i).set(j, MatriceAdiacenta.get(i).get(j) - f.get(j).get(i) + f.get(i).get(j));
            }
        } */

        // r(x,y) = c(x,y) - f(y,x) + f(x,y) || f(x,y) = max( 0, c(x,y) - r(x,y))
        System.out.println(r);
        DMF = (ArrayList<Integer>) PBF(sursa, destinatie, r).clone();
        while(DMF.get(DMF.size() - 1) == destinatie && DMF.get(0) == sursa) {
            for (int i = 0; i < DMF.size() - 1; i++) { // calculare fluxMin
                fluxMin = Math.min(fluxMin, r.get(DMF.get(i)).get(DMF.get(i + 1)));
            }

            for (int i = 0; i < DMF.size() - 1; i++) {  // marire flux
                r.get(DMF.get(i)).set(DMF.get(i + 1), r.get(DMF.get(i)).get(DMF.get(i + 1)) - fluxMin);
                r.get(DMF.get(i + 1)).set(DMF.get(i), r.get(DMF.get(i + 1)).get(DMF.get(i)) + fluxMin);
            }
            System.out.println("Capacitate reziudala: " + r);
            DMF = (ArrayList<Integer>) PBF(sursa, destinatie, r).clone();
        }

            int c_r;
            for (int i = 0; i < f.size(); i++) {  // actualizare fluxuri pe arce
                for (int j = 0; j <f.get(i).size(); j++) {
                    if (f.get(i).get(j) != 0) {
                        c_r = MatriceAdiacenta.get(i).get(j) - r.get(i).get(j);
                        if (c_r >= 0) {
                            f.get(i).set(j, c_r);
                            f.get(j).set(i, 0);
                        } else {
                            f.get(j).set(i, -c_r);
                            f.get(i).set(j, 0);
                        }
                    }
                }

            }
        System.out.println("Matrice fluxuri maxime: " + f);
    }

    int DescompunereFlux( ArrayList<ArrayList<Integer>> flux, int indexStart, int indexEnd) {
        int k = 0;
        int i = 0;
        int r;
        ArrayList<Integer> D = new ArrayList<>(0);
        ArrayList<Integer> F = new ArrayList<>(0);
        ArrayList<Integer> v = new ArrayList<>(0);
        for (int t = 0; t < flux.size(); t++) {
            v.add(0);
        }
        for (int l = 0; l < flux.size(); l++)
            for (int j = 0; j < flux.get(i).size(); j++) {
                F.add(flux.get(i).get(j));
            }
        while (F.get(k) > 0) {
            D.add(indexStart); // cum selectam nodul sursa?
            i = 0;
            while (i != indexEnd) {
                for (i = 0; i < flux.size(); i++) {
                    if (flux.get(i).get(i + 1) > 0) {
                        i++;
                        if (!Arrays.asList(D).contains(i)) {
                            D.add(i);
                        } else {
                            return -1;
                        }
                    }
                }
            }
            if (i == indexEnd) {
                r = Math.min(v.get(0), -v.get(i));
                v.set(0, v.get(0) - r);
                v.set(i, v.get(i) + r);
            }
            k++;
        }
        return 1;
    }

    ArrayList<Integer> PBF (int sursa, int destinatie, ArrayList<ArrayList<Integer>> r) {
        ArrayList<Integer> U = new ArrayList<> (0);
        Queue<Integer> V = new LinkedList<>();
        ArrayList<Integer> W = new ArrayList<> (0);
        ArrayList<Integer> p = new ArrayList<> (0);
        ArrayList<Integer> l = new ArrayList<> (0);
        int x = 0;
        for(int i = 0 ; i < listaNoduri.size(); i++) {
            if(listaNoduri.get(i).getNumber() != sursa) {
                U.add(listaNoduri.get(i).getNumber());
            }
            p.add(-1);
            l.add(0);
        }
        V.add(sursa);
        l.set(sursa, -1);
        for(int y = 0; y < U.size(); y++) {
            l.set(U.get(y), Integer.MAX_VALUE);
        }
        while (V.size() > 0) {
            x = (int) V.remove();

            for( int y = 0 ; y < MatriceAdiacenta.get(x).size(); y++) {
                if(MatriceAdiacenta.get(x).get(y) != 0) {
                    for(int z = 0 ; z < U.size(); z++) {
                        if(y == U.get(z) && r.get(x).get(y) > 0) {
                            U.remove(Integer.valueOf(y));
                            V.add(y);
                            p.set(y,x);
                            l.set(y, l.get(x) + 1);
                        }
                    }
                  // V.remove(x);
                }
            }
            W.add(x);
        }
     //   System.out.println(V);
        return Drum(sursa, destinatie, p);
    }

    ArrayList<Integer> Drum (int sursa, int destinatie, ArrayList<Integer> p) {
        int y = destinatie;
        int x;
        ArrayList<Integer> D = new ArrayList<>(0);
        D.add(destinatie);
        while(p.get(y) != -1) {
            x = p.get(y);
            D.add(x);
            y =x;
        }
        Collections.reverse(D);
        System.out.println(D);
        return D;
    }

}

// E  ok pentru primele 2 drumuri, dar dupa ia un drum de lungime 4 (de 2 ori...)...