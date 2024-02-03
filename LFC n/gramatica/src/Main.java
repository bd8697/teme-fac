// import java.util.Scanner;

public class Main {
	  public static void main(String[] args) throws Exception 
	  { 
		//  Scanner scan=new Scanner(System.in);
		//  System.out.println("Write the length of Vn.");
		//  int Vnl = scan.nextInt();
		//  System.out.println("Write the length of Vt.");
		//  int Vnt = scan.nextInt();
		//  scan.close();
		Gramatica G = new Gramatica();
		G.readFromFile();
		G.printGramatica();
		switch(G.verify()) {
		case 1: System.out.println("An element from Vn was also found in Vt."); break;
		 case 2: System.out.println("S is not in Vn."); break;
		case 3: System.out.println("Left member does not contain at least one non-final element."); break;
		case 4: System.out.println("There isn't any production that has only S as its left member.");break;
		case 5: System.out.println("An element not included in Vn nor in Vt was found.");break;
		case 0: System.out.println("All the rules have been respected."); break;
		}
		G.generateWord(1);
    }


}
