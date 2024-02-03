import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.DocumentBuilder;
import org.w3c.dom.Document;
import org.w3c.dom.NodeList;
import org.w3c.dom.Node;
import org.w3c.dom.Element;
import java.io.File;
import java.util.ArrayList;

public class ReadXMLFile
{
    public static void read(Graf graf)
    {  // myNode x = new myNode(1,2,3);
        try
        {
            File file = new File("D:\\Work\\Anu II\\ALG GRAF\\Tema 7 - Dijkstra\\map2.xml");
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            DocumentBuilder db = dbf.newDocumentBuilder();
            Document doc = db.parse(file);
            doc.getDocumentElement().normalize();
            System.out.println("Root element: " + doc.getDocumentElement().getNodeName());
            NodeList nodeList = doc.getElementsByTagName("node");
            NodeList arcList = doc.getElementsByTagName("arc");
            int nodesLength = nodeList.getLength();
            int arcsLength = arcList.getLength();
            System.out.println(nodesLength);
            System.out.println(Integer.MAX_VALUE - 5);
            int itr;
            graf.setLatMax(0);
            graf.setLongMax(0);
            graf.setLongMin(Integer.MAX_VALUE - 5);
            graf.setLatMin(Integer.MAX_VALUE - 5);
            for (itr = 0; itr < nodesLength; itr++)
            {
                Node node = nodeList.item(itr);
                System.out.println("\nNode Name :" + node.getNodeName());
                if (node.getNodeType() == Node.ELEMENT_NODE)
                {
                    Element eElement = (Element) node;
                    myNode auxNode= new myNode(Integer.parseInt(eElement.getAttributes().getNamedItem("longitude").getNodeValue()),Integer.parseInt(eElement.getAttributes().getNamedItem("latitude").getNodeValue()),Integer.parseInt(eElement.getAttributes().getNamedItem("id").getNodeValue()));
                    if (auxNode.getCoordX() > graf.getLongMax()) {
                        graf.setLongMax(auxNode.getCoordX());
                     //   longMax = auxNode.getCoordX();
                }
                    if (auxNode.getCoordY() > graf.getLatMax()) {
                       graf.setLatMax(auxNode.getCoordY());
                      //  latMax = auxNode.getCoordY();
                    }
                    if (auxNode.getCoordX() < graf.getLongMin()) {
                        graf.setLongMin(auxNode.getCoordX());
                       // longMin = auxNode.getCoordX();
                    }
                    if (auxNode.getCoordY() < graf.getLatMin()) {
                       graf.setLatMin(auxNode.getCoordY());
                      //  latMin = auxNode.getCoordY();
                    }
                        graf.listaNoduri.add(auxNode);
                   // System.out.println(graf.listaNoduri.get(graf.listaNoduri.size()-1).getNumber());
                 //   graf.MatriceAdiacenta.get(graf.MatriceAdiacenta.size()-1).add(Integer.parseInt(eElement.getAttributes().getNamedItem("id").getNodeValue()));
                  //  System.out.println("Node latitude: "+ eElement.getAttributes().getNamedItem("latitude").getNodeValue());
                  //  System.out.println("Node longitude: "+ eElement.getAttributes().getNamedItem("longitude").getNodeValue());
                }
            }
            System.out.println(itr);
            System.out.println(arcsLength);
            for (itr = 0; itr < arcsLength; itr++)
            {
                Node arc = arcList.item(itr);
                System.out.println(arc);
                System.out.println("\nArc Name :" + arc.getNodeName());
                if (arc.getNodeType() == Node.ELEMENT_NODE)
                {
                    Element eElement = (Element) arc;
                    myArc auxArc= new myArc(Integer.parseInt(eElement.getAttributes().getNamedItem("from").getNodeValue()),Integer.parseInt(eElement.getAttributes().getNamedItem("to").getNodeValue()),Integer.parseInt(eElement.getAttributes().getNamedItem("length").getNodeValue()));
                    graf.listaArce.add(auxArc);
                    //System.out.println(graf.listaArce.get(graf.listaArce.size()-1).getIdNod1());
                    //   graf.MatriceAdiacenta.get(graf.MatriceAdiacenta.size()-1).add(Integer.parseInt(eElement.getAttributes().getNamedItem("id").getNodeValue()));
                    //  System.out.println("Node latitude: "+ eElement.getAttributes().getNamedItem("latitude").getNodeValue());
                    //  System.out.println("Node longitude: "+ eElement.getAttributes().getNamedItem("longitude").getNodeValue());
                }
            }
            System.out.println(arcsLength);
            System.out.println(graf.listaArce.size());
            System.out.println("done reading");
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}