using System;

namespace basil.patterns
{
	public interface ISignalListener
	{
        void OnSignal<Signal>(Signal message);
	}
}

