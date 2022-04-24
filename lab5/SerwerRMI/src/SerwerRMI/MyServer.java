package SerwerRMI;

//import MyData.MyData;

import java.net.InetAddress;
import java.net.MalformedURLException;
import java.net.UnknownHostException;
import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

class MyData {
    public static void info() throws UnknownHostException {
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy/MM/dd HH:mm:ss");
        LocalDateTime now = LocalDateTime.now();
        System.out.println(dtf.format(now));
        System.out.println("Ernest Przybył 256480");
        System.out.println(System.getProperty("user.name"));
        System.out.println(System.getProperty("os.name"));
        System.out.println(System.getProperty("java.version"));
        InetAddress IP = InetAddress.getLocalHost();
        System.out.println(IP.getHostAddress());
    }
}

public class MyServer {
    public static void main(String[] args) throws UnknownHostException, java.rmi.UnknownHostException {
//        MyData.info("Ernest Przybył 256480");
        MyData.info();

        if(args.length == 0){
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name");
            return;
        }

//        try{
//            Registry reg = LocateRegistry.createRegistry(1099);
//        }
//        catch (RemoteException e){
//            e.printStackTrace();
//        }

        if(System.getSecurityManager() == null){
            System.setSecurityManager(new SecurityManager());
        }

        try{
            CalcObjImpl implObiektu = new CalcObjImpl();
            CalcObjImpl2 implObiektu2 = new CalcObjImpl2();
            java.rmi.Naming.rebind("//localhost/calc1", implObiektu);
            java.rmi.Naming.rebind("//localhost/calc2", implObiektu2);
            System.out.println("Server is registered now");
            System.out.println("Press Ctrl+C to stop...");
        } catch (RemoteException | MalformedURLException e) {
            System.out.println("SERVER CAN'T BE REGISTERED");
            e.printStackTrace();
            return;
        }
    }
}
