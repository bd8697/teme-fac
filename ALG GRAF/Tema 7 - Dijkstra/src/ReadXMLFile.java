import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.DocumentBuilder;
import org.w3c.dom.Document;
import org.w3c.dom.NodeList;
import org.w3c.dom.Node;
import org.w3c.dom.Element;
import java.io.File;
public class ReadXMLFile
{
    public static void main(String argv[])
    {
        try
        {
            File file = new File("D:\\Work\\Anu II\\ALG GRAF\\Tema 7 - Dijkstra\\map2.xml");
            DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
            DocumentBuilder db = dbf.newDocumentBuilder();
            Document doc = db.parse(file);
            doc.getDocumentElement().normalize();
            System.out.println("Root element: " + doc.getDocumentElement().getNodeName());
            NodeList nodeList = doc.getElementsByTagName("node");
            int nodesLength = nodeList.getLength();
            for (int itr = 0; itr < nodesLength; itr++)
            {
                Node node = nodeList.item(itr);
                System.out.println("\nNode Name :" + node.getNodeName());
                if (node.getNodeType() == Node.ELEMENT_NODE)
                {
                    Element eElement = (Element) node;
                    System.out.println("Node id: "+ eElement.getAttributes().getNamedItem("id").getNodeValue());
                    System.out.println("Node latitude: "+ eElement.getAttributes().getNamedItem("latitude").getNodeValue());
                    System.out.println("Node longitude: "+ eElement.getAttributes().getNamedItem("longitude").getNodeValue());
                }
            }
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}  