import org.apache.xmlrpc.WebServer;

import java.util.ArrayList;
import java.util.Vector;
import java.lang.reflect.Method;

public class Main {
    //kom
    public Vector<Integer> asyncPrimes(int floor, int celling){
        int count = 0;
        int lastPrime = -1;
        celling+=1;
        ArrayList<Boolean> l = new ArrayList<>();
        for(int i=0;i<celling;i++)
        {
            l.add(true);
        }
        l.set(0,false);
        l.set(1,false);
        for(int i=2;i<celling;i++)
        {
            if (l.get(i))
            {
                if(i>=floor && i<=celling)
                {
                    count+=1;
                    lastPrime=i;
                }
                for(int j=i*2;j<celling;j=j+i)
                {
                    l.set(j,false);
                }
            }

        }


        Vector<Integer> anwser = new Vector<>();
        anwser.add(count);
        anwser.add(lastPrime);

        return anwser;
    }

    public Double distance(double lat1, double lon1, double lat2, double lon2){
        final double R = 6371d; // radious of earth
        double latDistanceRads = (lat2 - lat1) * Math.PI / 180;
        double lonDistanceRads = (lon2 - lon1) * Math.PI / 180;
        double a = Math.sin(latDistanceRads / 2) * Math.sin(latDistanceRads / 2) +
                Math.cos(lat1 * Math.PI / 180) * Math.cos(lat2 * Math.PI / 180) *
                        Math.sin(lonDistanceRads / 2) * Math.sin(lonDistanceRads / 2);
        double c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));

        return R * c;
    }

    public String generateMessage(int number, String text){
        return text + number;
    }
    
    public String show(){
//        Vector<String> v = new Vector<>();
//        v.addElement("Nazwa metody: asyncPrimes, parametry: (int floor, int celling), opis: zwraca ilość liczb pierwszych w podanym przedziale [min, max] oraz największą liczbę pierwszą mniejszą lub równą max");
//        v.addElement("Nazwa metody: distance, parametry (double lat1, double lon1, double lat2, double lon2), opis: zwraca odległość między dwoma punktami na powierzchni Ziemi");
//        v.addElement("Nazwa metody generateMessage, parametry (int number, String text), opis: zwraca połączone parametry");
        return "Nazwa metody: asyncPrimes, parametry: (int floor, int celling), opis: zwraca ilosc liczb pierwszych w podanym przedziale [min, max] oraz najwieksza liczbe pierwsza mniejsza lub rowna max\n" +
                "Nazwa metody: distance, parametry (double lat1, double lon1, double lat2, double lon2), opis: zwraca odleglosc miedzy dwoma punktami na powierzchni Ziemi\n"+
                "Nazwa metody: generateMessage, parametry (int number, String text), opis: zwraca polaczone parametry";
        //return "Nazwa metody: distance, parametry (double lat1, double lon1, double lat2, double lon2), opis: zwraca odległość między dwoma punktami na powierzchni Ziemi";
    }


    public static void main(String[] args) {
        try{
            System.err.println("Startuje serwer XML-RPC...");
            int port = 4000;
            WebServer server = new WebServer(port);
            server.addHandler("MojSerwer", new Main());
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
