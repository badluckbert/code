import java.net.*;
import java.util.*;
public class clientUDP_Previdi{
        public static void main(String[] args) throws Exception
        {
            Scanner input = new Scanner(System.in);
            DatagramSocket clientSocket = new DatagramSocket(8000);

            System.out.println("Enter the length and width of a rectangle separated by spaces, then press enter");
            String rectangleSides = input.nextLine();

            InetAddress serverAddress = InetAddress.getByName("localhost");
            DatagramPacket sendPacket = new DatagramPacket(rectangleSides.getBytes(), rectangleSides.length(),
                    serverAddress, 9000);
            clientSocket.send(sendPacket);

            byte[] buf = new byte[65536];
            DatagramPacket receivePacket = new DatagramPacket(buf, buf.length);
            clientSocket.receive(receivePacket);
            String receiveMessage = new String(receivePacket.getData());
            System.out.print("Rectangle has an area of " + receiveMessage);

            input.close();
            clientSocket.close();
        }
}
