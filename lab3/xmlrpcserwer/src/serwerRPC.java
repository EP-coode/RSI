import org.apache.xmlrpc.WebServer;

public class serwerRPC {
    public Integer echo(int x, int y){
        return x + y;
    }

    public Integer execAsy(int a) {
        System.out.println("... met asychroniczna wywołana ...");
        try {
            Thread.sleep(1000);
        } catch (InterruptedException e) {
            e.printStackTrace();
            Thread.currentThread().interrupt();
        }
        System.out.println("... met asychroniczna zakończona ...");
        return a;
    }

    public static void main(String[] args) {
        try{
            System.err.println("Startuje serwer XML-RPC...");
            int port = 4000;
            WebServer server = new WebServer(port);
            server.addHandler("MojSerwer", new serwerRPC());
            server.start();
            System.out.println("Serwer wystartował pomślnie");
            System.out.println("Nasłuchuje na porcie: " + port);
            System.out.println("Aby zatrzymać naciśnij ctrl+c");
        }

        catch (Exception exception){
            System.err.println("Serwer XML-RPC: "+ exception);
        }
    }
}
