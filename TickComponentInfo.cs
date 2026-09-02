using System;
using System.Runtime.CompilerServices;

// Token: 0x0200008A RID: 138
[NullableContext(1)]
[Nullable(0)]
public class TickComponentInfo
{
	// Token: 0x0600031F RID: 799 RVA: 0x00012D42 File Offset: 0x00010F42
	public TickComponentInfo(EntityComponent component, int index, int priority)
	{
		this.Component = component;
		this.Index = index;
		this.Priority = priority;
	}

	// Token: 0x04000345 RID: 837
	public readonly EntityComponent Component;

	// Token: 0x04000346 RID: 838
	public readonly int Index;

	// Token: 0x04000347 RID: 839
	public readonly int Priority;
}
