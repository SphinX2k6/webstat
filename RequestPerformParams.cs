using System;
using System.Runtime.CompilerServices;

// Token: 0x02003055 RID: 12373
[NullableContext(1)]
[Nullable(0)]
public class RequestPerformParams : IRequestPerformParams
{
	// Token: 0x1700223B RID: 8763
	// (get) Token: 0x0601963B RID: 103995 RVA: 0x007531E1 File Offset: 0x007513E1
	// (set) Token: 0x0601963C RID: 103996 RVA: 0x007531E9 File Offset: 0x007513E9
	public int Signal { get; set; }

	// Token: 0x1700223C RID: 8764
	// (get) Token: 0x0601963D RID: 103997 RVA: 0x007531F2 File Offset: 0x007513F2
	// (set) Token: 0x0601963E RID: 103998 RVA: 0x007531FA File Offset: 0x007513FA
	public Entity Source { get; set; }
}
