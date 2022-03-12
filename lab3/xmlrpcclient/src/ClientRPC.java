import org.apache.xmlrpc.XmlRpcClient;

import java.util.Vector;

public class ClientRPC {
    public static void main(String[] args) {
        try{
            XmlRpcClient srv = new XmlRpcClient("http://127.0.0.1:4000");
            Vector<Integer> params = new Vector<>();
            params.addElement(13);
            params.addElement(21);
            Object result = srv.execute("MojSerwer.echo", params);
            int wynik = (Integer) result;
            System.out.println("Wynik odporwiedzi serwera: " + wynik);
        }
        catch (Exception exception){
            System.err.println("Klient XML-RPC: " + exception);
        }
    }
}
