using System;


	public interface ITimeListener
	{
  
        
        
        void OnMinute<TimeFly>(TimeFly message);


        void OnSecond<TimeFly>(TimeFly message);

    
        void OnHour<TimeFly>(TimeFly message);
    
	}


