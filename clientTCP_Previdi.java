import java.io.*;
import java.net.*;
import java.util.*;
public class clientTCP_Previdi{
    public static void main(String[] args) throws Exception
    {

        double rectArea, rectLength, rectWidth;
        Scanner input = new Scanner(System.in);

        System.out.println("Enter the length of a rectangle, then press enter to input the width.");
        rectLength = input.nextDouble();
        System.out.println("Enter the width of the rectangle, then press enter to get the area.");
        rectWidth = input.nextDouble();

        Socket socket = new Socket("localhost",9000);
        PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
        BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()));

        out.println(rectLength);
        out.println(rectWidth);
        rectArea = Double.valueOf(in.readLine());
        System.out.println("The area of the rectangle with the length of " + rectLength +
                " and the width of " + rectWidth + " is " + rectArea);
    }
}