import org.apache.xmlrpc.AsyncCallback;

import java.net.URL;

public class AC implements AsyncCallback {
    @Override
    public void handleResult(Object o, URL url, String s) {
        System.out.println("AC.handleResult -> [url: " + url.toString() + ", metoda: " + s + ", rezultat: " + o.toString() +"]");
    }

    @Override
    public void handleError(Exception e, URL url, String s) {
        System.out.println("AC.handleResult -> [url: " + url.toString() + ", metoda: " + s + ", wyjatek: " + e.toString() +"]");
    }
}
