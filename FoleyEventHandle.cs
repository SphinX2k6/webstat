using System;
using System.Runtime.CompilerServices;

// Token: 0x02000D4B RID: 3403
[NullableContext(1)]
[Nullable(0)]
internal class FoleyEventHandle
{
	// Token: 0x060047F7 RID: 18423 RVA: 0x00097523 File Offset: 0x00095723
	public FoleyEventHandle(int id, string eventName)
	{
		this.Id = id;
		this.EventName = eventName;
	}

	// Token: 0x040013F9 RID: 5113
	public int Id;

	// Token: 0x040013FA RID: 5114
	public string EventName = "";
}
