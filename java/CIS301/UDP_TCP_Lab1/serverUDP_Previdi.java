import java.net.*;
class serverUDP_Previdi{
    public static void main(String[] args) throws Exception
    {
        String serverMessage, rectangleSides;
        InetAddress clientAddress;
        int clientPort;
        DatagramPacket sendPacket, receivePacket;
        DatagramSocket serverSocket;
        byte[] sendBuf = new byte[65535];
        byte[] recvBuf = new byte[65535];
        double rectangleArea;

        serverSocket = new DatagramSocket(9000);
        receivePacket = new DatagramPacket(recvBuf, recvBuf.length);

        while(true)
        {
            System.out.println("Server: Waiting for incoming messages...");

            serverSocket.receive(receivePacket);
            recvBuf = receivePacket.getData();
            rectangleSides = new String(recvBuf);
            clientAddress = receivePacket.getAddress();
            clientPort = receivePacket.getPort();

            System.out.println("Client(" + clientAddress + ":" + clientPort + "): rectLength: " + rectangleSides);

            String[] rect = rectangleSides.split(" ");
            rectangleArea = Double.valueOf(rect[0]) * Double.valueOf(rect[1]);

            serverMessage = "Rectangle Area: " + rectangleArea;
            sendBuf  = serverMessage.getBytes();
            sendPacket = new DatagramPacket(sendBuf, sendBuf.length, clientAddress, clientPort);

            serverSocket.send(sendPacket);
            System.out.println("Server: Response sent to Client(" + clientAddress + ":" + clientPort + ")");
            System.out.println();
        }
    }
}
