package SerwerRMI;

import java.io.Serial;
import java.io.Serializable;

public class ResultType implements Serializable {
    @Serial
    private static final long serialVersionUID = 102L;
    String resultDescription;
    public double result;
}
