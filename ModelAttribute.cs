using System;

// Token: 0x02000BB4 RID: 2996
[AttributeUsage(AttributeTargets.Class)]
public class ModelAttribute : Attribute
{
	// Token: 0x1700009A RID: 154
	// (get) Token: 0x060030C1 RID: 12481 RVA: 0x0001AEA5 File Offset: 0x000190A5
	// (set) Token: 0x060030C2 RID: 12482 RVA: 0x0001AEAD File Offset: 0x000190AD
	public int Priority { get; private set; }

	// Token: 0x060030C3 RID: 12483 RVA: 0x0001AEB6 File Offset: 0x000190B6
	public ModelAttribute(int priority = 0)
	{
		this.Priority = priority;
	}
}
