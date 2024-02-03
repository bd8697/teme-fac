
public class Production {
 private String left;
 private String right;
 
 public Production(String l, String r) {
	 left = l;
	 right= r;
 }
 public Production () {
	 left = " ";
	 right= " ";
 }
 
 public String getleft() {
     return left;
 }
 public String getright() {
     return right;
 }

 public void setleft(String s) {
     left = s;
 }
 public void setright(String s) {
     right = s;
 }
}
