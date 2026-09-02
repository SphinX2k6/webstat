using System;

// Token: 0x02000BB0 RID: 2992
[AttributeUsage(AttributeTargets.Class)]
public class ControllerAttribute : Attribute
{
	// Token: 0x17000094 RID: 148
	// (get) Token: 0x06003092 RID: 12434 RVA: 0x0001AB1D File Offset: 0x00018D1D
	// (set) Token: 0x06003093 RID: 12435 RVA: 0x0001AB25 File Offset: 0x00018D25
	public int Priority { get; private set; }

	// Token: 0x06003094 RID: 12436 RVA: 0x0001AB2E File Offset: 0x00018D2E
	public ControllerAttribute(int priority = 0)
	{
		this.Priority = priority;
	}
}
