package SerwerRMI;

import java.net.MalformedURLException;
import java.rmi.RemoteException;

public class MyServer {
    public static void main(String[] args) {
        if(args.length == 0){
            System.out.println("You have to enter RMI object address in the form: //host_address/service_name");
            return;
        }

        if(System.getSecurityManager() == null){
            System.setSecurityManager(new SecurityManager());
        }

        try{
            CalcObjImpl implObiektu = new CalcObjImpl();
            CalcObjImpl2 implObiektu2 = new CalcObjImpl2();
            java.rmi.Naming.rebind(args[0], implObiektu);
            java.rmi.Naming.rebind(args[0], implObiektu2);
            System.out.println("Server is registered now");
            System.out.println("Press Ctrl+C to stop...");
        } catch (RemoteException | MalformedURLException e) {
            System.out.println("SERVER CAN'T BE REGISTERED");
            e.printStackTrace();
            return;
        }
    }
}
