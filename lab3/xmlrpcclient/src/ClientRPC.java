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

            Vector<Integer> params3= new Vector<>();
            params3.addElement(2);
            AC cb2 = new AC();
            srv.executeAsync("MojSerwer.execAsy", params3, cb2);
            System.out.println("Wywołano zapytanie asynchroniczne - długie");

            Vector<Integer> params2 = new Vector<>();
            params2.addElement(2022);
            params2.addElement(21);
            AC cb = new AC();
            srv.executeAsync("MojSerwer.echo", params2, cb);
            System.out.println("Wywołano zapytanie asynchroniczne - krótkie");
        }
        catch (Exception exception){
            System.err.println("Klient XML-RPC: " + exception);
        }
    }
}
