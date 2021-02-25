import java.io.*;
import java.net.*;
import java.util.*;
public class serverTCP_Previdi {
    public static void main(String[] args) throws Exception{

        double clientLength, clientWidth, clientArea;
        Scanner input = new Scanner(System.in);
        ServerSocket serverSocket = new ServerSocket(9000);

        System.out.println("Waiting for incoming connections");
        Socket clientSocket = serverSocket.accept();
        PrintWriter out = new PrintWriter(clientSocket.getOutputStream(), true);
        BufferedReader in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));

        clientLength= Double.valueOf(in.readLine());
        clientWidth = Double.valueOf(in.readLine());

        clientArea = clientLength * clientWidth;
        out.println(clientArea);

        clientSocket.close();
        serverSocket.close();
        input.close();
    }
}
