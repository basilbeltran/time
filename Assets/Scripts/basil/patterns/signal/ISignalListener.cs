using System;


	public interface ISignalListener
	{
        void OnSignal<Signal>(Signal message);
	}


