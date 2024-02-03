import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Objects;
import java.util.Random;
import java.util.Scanner;

public class Gramatica {
	
	private ArrayList<String> Vn;
	private ArrayList<String> Vt;
	private String startSymbol;
	private int nrProd;
	private Production[] productions;
	
	public Gramatica () {
		 Vn = new ArrayList<String>(0);
		 Vt = new ArrayList<String>(0);
		startSymbol = " ";
		productions = new Production[1];
		productions[0] = new Production();
	}
	 void readFromFile () throws FileNotFoundException {
		 String auxS;
		 int auxX=0;
			
		 File file = new File("./elemente.txt"); 
		    Scanner scanner = new Scanner(file);
		    Scanner ScanEachLine = new Scanner(scanner.nextLine());
		    
		    while (ScanEachLine.hasNext()) {
	            auxS = ScanEachLine.next();
	            Vn.add(auxS);
	            auxX++;
	        }
		    
		    ScanEachLine = new Scanner(scanner.nextLine());
		    auxX=0;
			   while (ScanEachLine.hasNext()) {
		            auxS = ScanEachLine.next();
		            Vt.add(auxS);
		            auxX++;
		        }
			   
			   auxS = scanner.next();
			   startSymbol=auxS;
			   
			   auxX = Integer.parseInt(scanner.next());
			   nrProd=auxX;
			//   System.out.println(nrProd);
			   
			   auxX = nrProd;
			   productions = new Production[auxX];
			   
			   while(auxX>0) {
			   auxS = scanner.next();
			   productions[nrProd-auxX]= new Production();
			   productions[nrProd-auxX].setleft(auxS);
			//   System.out.println(productions[nrProd-auxX].getleft());
		       auxS = scanner.next();
		       productions[nrProd-auxX].setright(auxS);
		     //  System.out.println(productions[nrProd-auxX].getright());
		       auxX--; 
			   }
			   scanner.close();
			   ScanEachLine.close();
	 }
	 
	 void printGramatica () {
		 System.out.print("Vn: ");
		 for(int i =0;i<Vn.size();i++) {
			 System.out.print(Vn.get(i) + " ");
		 }
		 System.out.println();
		 System.out.print("Vt: ");
		 for(int i =0;i<Vt.size();i++) {
			 System.out.print(Vt.get(i) + " ");		 
		 }
		 System.out.println();
		 System.out.print("Symbol: ");
		 System.out.print(startSymbol);	 
		 System.out.println();
		 System.out.print("No. of productions: ");
		 System.out.print(nrProd);
		 System.out.println();
		 System.out.print("Productions: ");
		 System.out.println();
		 for(int i = 0;i<nrProd;i++) {
			 System.out.print(productions[i].getleft()+ "->");
			 System.out.print(productions[i].getright());
			 System.out.println();
		 }
		 
	 }
	 
	 int verify () {
		 char ch;
		 boolean SinVn = false;
		 boolean hasUpperCase = false;
		 boolean SinLeftProd = false;
		 boolean isINVnOrVt = false;

		 for(int i = 0 ;i<Math.min(Vn.size(), Vt.size());i++) {  //rule 1	
			 for(int j = 0 ;j<Vt.size();j++) {
				 if(Vn.get(i) == Vt.get(i)) {
					 return 1;
				 }
				 }
			 }
		 for(int i = 0 ;i<Vn.size();i++) { 
		 if(Objects.equals(Vn.get(i), startSymbol)) {SinVn=true;} //rule 2
		 }
		 if(SinVn==false) {return 2;} 
		 for(int i = 0 ;i<nrProd;i++) { //rule 3
			 if(Objects.equals(productions[i].getleft(), startSymbol)) {SinLeftProd=true;} // rule 4
			 for(int j=0;j < productions[i].getleft().length();j++) { //rule 5
				 ch = productions[i].getleft().charAt(j);
				 if(Character.isUpperCase(ch)) {
					 hasUpperCase = true;
				 }
				 for(int k = 0 ;k<Vn.size();k++) {
					 if(Objects.equals(Character.toString(ch), Vn.get(k))) {
						
						 isINVnOrVt = true; 
					 }
				 }
				 for(int k = 0 ;k<Vt.size();k++) {
					 if(Objects.equals(Character.toString(ch), Vt.get(k))) {
						 isINVnOrVt = true; 
					 }
				 }
				 if(isINVnOrVt==false) {return 5;} else {isINVnOrVt=false;}
			 }
			 for(int j=0;j < productions[i].getright().length();j++) {
				 ch = productions[i].getright().charAt(j);
				 for(int k = 0 ;k<Vn.size();k++) {
					 if(Objects.equals(Character.toString(ch), Vn.get(k))) {
						 isINVnOrVt = true; 
					 }
				 }
				 for(int k = 0 ;k<Vt.size();k++) {
					 if(Objects.equals(Character.toString(ch), Vt.get(k))) {
						 isINVnOrVt = true; 
					 }
				 }
				 if(isINVnOrVt==false) {return 5;} else {isINVnOrVt=false;}
			 }
			 if(hasUpperCase == false) {return 3;} else {hasUpperCase = false;}
		 } 
		 if(SinLeftProd==false) {return 4;}
		 
		 return 0;
	 }
	 
	 void generateWord (int option) {
		 String word = startSymbol;
		 Random rand = new Random();
		 int rnd;
		 boolean atLeastOneProd = false;
		 int[] applicableProds = new int[nrProd];
		 System.out.println(word+ "=>");
		 while(true) {
			 atLeastOneProd = false;
			 for(int i = 0;i<nrProd;i++) {
				 applicableProds[i] = word.indexOf(productions[i].getleft()); //index where x occurs in y (-1 if it doesn't)
				 if(applicableProds[i] != -1) {atLeastOneProd = true;}
			 }
			 if(atLeastOneProd == false) {
				 for(int i = 0;i<word.length();i++) {
					if(Character.isUpperCase(word.charAt(i))) {System.out.println("Element " + word.charAt(i) + " is not final."); break;}
				 }
				 System.out.println(word);
				 System.out.println("All elements are final.");
				 break;
				 }
			 do {
					rnd = rand.nextInt(nrProd);
				} while(applicableProds[rnd]==-1);
			 word = word.replaceAll(productions[rnd].getleft(),productions[rnd].getright());
			 if(option == 1) {System.out.print(word + "=>");}
		 }
	 }
	 
	 /*
		 * public String getVnElem(int pos) {
		     return Vn[pos];
		 }
		public String[] getVn() {
		     return Vn;
		 }
		public String[] getVt() {
		     return Vt;
		 }
		public Production[] getproduction() {
		     return productions;
		 }
		public void newporduction(int pos) {
			productions = new Production[pos];
		 }
		 public void setVnElem(int pos, String elem) {
		     Vn[pos]=elem;
		 }
		 public String getVtElem(int pos) {
		     return Vt[pos];
		 }

		 public void setVtElem(int pos, String elem) {
		     Vt[pos]=elem;
		 }
		 
		 public String getstartSymbol() {
		     return startSymbol;
		 }

		 public void setstartSymbol(String s) {
			 startSymbol = s;
		 }

		 public Production getproductionElem(int pos) {
				return productions[pos];
			}
		 
		 public void setproduction(int pos, Production elem) {
			 productions[pos] = elem;
		 }
		 
		 public int getnrProd () {
			 return nrProd;
		 }
		 void setnrProd (int nr) {
			 nrProd = nr;
		 }
		 */
}
