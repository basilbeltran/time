public class Singleton{
    private Singleton(){
        //Class initialization goes here.
    }

    public void someSingletonMethod(){
        //Some method that acts on the Singleton.
    }

    private static Singleton _instance;
    public static Singleton Instance 
    { 
        get { 
            if (_instance == null)
                _instance = new Singleton();
            return _instance; 
        }
    } 
}

