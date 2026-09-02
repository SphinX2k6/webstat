using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A42 RID: 27202
	[NullableContext(1)]
	[Nullable(0)]
	public class QueuedLowPriorityAction : IQueuedLowPriorityAction
	{
		// Token: 0x060434E7 RID: 275687 RVA: 0x0114CCC4 File Offset: 0x0114AEC4
		public QueuedLowPriorityAction(int frameEnqueued, Action action)
		{
			this.FrameEnqueued = frameEnqueued;
			this.Action = action;
		}

		// Token: 0x1700A249 RID: 41545
		// (get) Token: 0x060434E8 RID: 275688 RVA: 0x0114CCDA File Offset: 0x0114AEDA
		public int FrameEnqueued { get; }

		// Token: 0x1700A24A RID: 41546
		// (get) Token: 0x060434E9 RID: 275689 RVA: 0x0114CCE2 File Offset: 0x0114AEE2
		public Action Action { get; }
	}
}
