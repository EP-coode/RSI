import org.apache.xmlrpc.XmlRpcClient;

import java.util.Vector;

public class Main {
    public static void main(String[] args) {
        try{
            XmlRpcClient srv = new XmlRpcClient("http://127.0.0.1:4000");

            Vector<Integer> params = new Vector<>();
            params.addElement(100000000);
            params.addElement(110000000);
            Object result = srv.execute("MojSerwer.asyncPrimes", params);

            Vector<Double> params2 = new Vector<>();
            params2.addElement(10d);
            params2.addElement(20d);
            params2.addElement(15d);
            params2.addElement(25d);
            Object result2 = srv.execute("MojSerwer.distance", params2);

            Vector<Object> params3 = new Vector<>();
            params3.addElement(24);
            params3.addElement("Ta liczba jest parzysta: ");
            Object result3 = srv.execute("MojSerwer.generateMessage", params3);


            System.out.println("Result 1: "+ result.toString() + "\nResult 2: " + result2.toString() + "\nResult 3: " + result3.toString());
        }
        catch (Exception exception){
            System.err.println("Klient XML-RPC: " + exception);
        }
    }
}
