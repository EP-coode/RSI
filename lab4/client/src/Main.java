import org.apache.xmlrpc.XmlRpcClient;

import java.util.Locale;
import java.util.Scanner;
import java.util.Vector;

public class Main {
    public static void main(String[] args) {
        try{
            XmlRpcClient srv = new XmlRpcClient("http://localhost:4000");
            Scanner sc = new Scanner(System.in);
            sc.useLocale(Locale.US);
            while(true)
            {
                System.out.println("\n\nWybierz jedną z opcji:");
                System.out.println("1. Pokaż dostępne procedury\n2. Uruchom procedurę asyncPrimes\n3. Uruchom procedurę didstance\n4. Uruchom procedutę łączącą");
                System.out.print("Twój wybór: ");
                int choice = sc.nextInt();
                switch (choice){
                    case 1: {
                        Object result = srv.execute("MojSerwer.show",new Vector());
                        System.out.println(result.toString());
                        break;
                    }
                    case 2:
                    {
                        Vector<Integer> params = new Vector<>();
                        int a,b;
                        System.out.println("Pamiętaj, że zakres powinien być z przedziału [2,2147483647] i dolny zakres musi być mniejszy od górnego");
                        System.out.print("Podaj dolny zakres: ");
                        a = sc.nextInt();
                        System.out.print("Podaj górny zakres: ");
                        b = sc.nextInt();
                        if(a<2 || b<2 || a>=b) {
                            System.out.println("Niepoprawny zakres!");
                            break;
                        }
                        params.addElement(a);
                        params.addElement(b);
                        Object result = srv.execute("MojSerwer.asyncPrimes", params);
                        Vector v = (Vector)result;
                        System.out.println("\nWynik: \nLiczba liczb piewszych: "+v.get(0)+"\nNajwiększa liczba pierwsza z zakresu: "+v.get(1));
                        break;
                    }
                    case 3:
                    {
                        Vector<Double> params2 = new Vector<>();
                        System.out.print("Podaj wspołrzędną x pierwszego punktu: ");
                        params2.addElement(sc.nextDouble());
                        System.out.print("Podaj wspołrzędną y pierwszego punktu: ");
                        params2.addElement(sc.nextDouble());
                        System.out.print("Podaj wspołrzędną x drugiego punktu: ");
                        params2.addElement(sc.nextDouble());
                        System.out.print("Podaj wspołrzędną y drugiego punktu: ");
                        params2.addElement(sc.nextDouble());
                        Object result2 = srv.execute("MojSerwer.distance", params2);
                        System.out.println("Odległość to: "+result2.toString() + " KM");
                        break;
                    }
                    case 4:
                    {
                        Vector<Object> params3 = new Vector<>();
                        System.out.print("Podaj liczbe calkowita: ");
                        params3.addElement(sc.nextInt());
                        System.out.print("Podaj jedno słowo: ");
                        params3.addElement(sc.next());
                        AC ac = new AC();
                        System.out.println("Poczekaj, wykonuje zapytanie asynchroniczne...");
                        srv.executeAsync("MojSerwer.generateMessage", params3, ac);
                        break;
                    }
                    default:
                        System.out.println("Brak wybranej opcji!");
                }
                System.out.println("-------------------------------------------------------------------------");
            }
        }
        catch (Exception exception){
            System.err.println("Klient XML-RPC: " + exception);
        }
    }
}
