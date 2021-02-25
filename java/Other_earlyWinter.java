import java.util.Scanner;
public class earlyWinter {
	
	static int nYears;
	static int dDays;
	static int[] iDays;
	
	public static void main(String[] args) 
	{
		Scanner input = new Scanner(System.in); 		
		nYears = input.nextInt();
		dDays = input.nextInt();
		iDays = new int[nYears];
		for(int i = 0; i < nYears; i++)
			iDays[i] = input.nextInt();
		int answer = report();
		if (answer == -1) {
			System.out.println("It had never snowed this early!");
		}
		else
		System.out.println("It hadn't snowed this early in " + (answer) + " years!");	
	}
	
	public static int report() {					
			for(int i = 0; i < nYears; i++) 
			{
				if(iDays[i] <=  dDays) {				
					return i;
				}
			}
			return -1;
		}
}
