using System;

// Token: 0x02001C0B RID: 7179
[AttributeUsage(AttributeTargets.Class)]
public class FloroRanchEntityComponentAttribute : Attribute
{
	// Token: 0x17001108 RID: 4360
	// (get) Token: 0x0600D0A6 RID: 53414 RVA: 0x00376235 File Offset: 0x00374435
	// (set) Token: 0x0600D0A7 RID: 53415 RVA: 0x0037623D File Offset: 0x0037443D
	public EFloroRanchEntityComponent Type { get; private set; }

	// Token: 0x0600D0A8 RID: 53416 RVA: 0x00376246 File Offset: 0x00374446
	public FloroRanchEntityComponentAttribute(EFloroRanchEntityComponent type)
	{
		type = this.Type;
	}
}
