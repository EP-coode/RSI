package ClientRMI;

import MyData.MyData;
import SerwerRMI.CalcObject;
import SerwerRMI.CalcObject2;
import SerwerRMI.InputType;
import SerwerRMI.ResultType;

import java.net.MalformedURLException;
import java.net.UnknownHostException;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;

public class MyClient {
    public static void main(String[] args) throws UnknownHostException, java.rmi.UnknownHostException {
        MyData.info("Ernest Przybył 256480");

        double wynik;
        ResultType result;
        InputType inObj;
        CalcObject zObject;
        CalcObject2 zObject2;

        if (args.length == 0) {
            System.out.println("You have to enter RMI object address in the form: //host_address");
            return;
        }

        String addres = args[0];

        try {
            zObject = (CalcObject) java.rmi.Naming.lookup(addres + "/calc1");
            zObject2 = (CalcObject2) java.rmi.Naming.lookup(addres + "/calc2");
        } catch (RemoteException | NotBoundException | MalformedURLException e) {
            System.out.println("Nie mozna porobrac referencji do " + addres);
            e.printStackTrace();
            return;
        }

        System.out.println("Referencja do " + addres + " jest pobrana.");

        try {
            wynik = zObject.calculate(1.1, 2.2);
            inObj = new InputType();
            inObj.x1 = 1;
            inObj.x2 = -3.14d;
            inObj.operation = "add";
            result = zObject2.calculate(inObj);

        } catch (RemoteException e) {
            System.out.println("Blad zdalnego wywolania");
            e.printStackTrace();
            return;
        }

        System.out.println("Wynik = " + result.result);
    }
}
