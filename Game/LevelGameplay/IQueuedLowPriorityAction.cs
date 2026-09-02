using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A41 RID: 27201
	[NullableContext(1)]
	public interface IQueuedLowPriorityAction
	{
		// Token: 0x1700A247 RID: 41543
		// (get) Token: 0x060434E5 RID: 275685
		int FrameEnqueued { get; }

		// Token: 0x1700A248 RID: 41544
		// (get) Token: 0x060434E6 RID: 275686
		Action Action { get; }
	}
}
