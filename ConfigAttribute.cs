using System;

// Token: 0x02000BAC RID: 2988
[AttributeUsage(AttributeTargets.Class)]
public class ConfigAttribute : Attribute
{
	// Token: 0x17000092 RID: 146
	// (get) Token: 0x06003081 RID: 12417 RVA: 0x0001AA6E File Offset: 0x00018C6E
	// (set) Token: 0x06003082 RID: 12418 RVA: 0x0001AA76 File Offset: 0x00018C76
	public int Priority { get; private set; }

	// Token: 0x06003083 RID: 12419 RVA: 0x0001AA7F File Offset: 0x00018C7F
	public ConfigAttribute(int priority = 0)
	{
		this.Priority = priority;
	}
}
