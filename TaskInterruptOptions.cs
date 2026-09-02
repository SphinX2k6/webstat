using System;
using System.Runtime.CompilerServices;

// Token: 0x020034D1 RID: 13521
[NullableContext(2)]
[Nullable(0)]
public class TaskInterruptOptions
{
	// Token: 0x0601C909 RID: 117001 RVA: 0x0088FD37 File Offset: 0x0088DF37
	public TaskInterruptOptions(ETaskPriority priority = ETaskPriority.Normal, bool interruptible = false, Action onInterrupt = null)
	{
		this.Priority = priority;
		this.Interruptible = interruptible;
		this.OnInterrupt = onInterrupt;
	}

	// Token: 0x0400E613 RID: 58899
	public readonly ETaskPriority Priority;

	// Token: 0x0400E614 RID: 58900
	public readonly bool Interruptible;

	// Token: 0x0400E615 RID: 58901
	public readonly Action OnInterrupt;
}
