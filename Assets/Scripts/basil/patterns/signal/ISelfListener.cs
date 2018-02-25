using System;

namespace basil.patterns
{
	public interface ISelfListener
	{
        void OnThought<Signal>(Signal message);
	}
}

