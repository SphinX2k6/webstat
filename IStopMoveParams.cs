using System;
using System.Runtime.CompilerServices;

// Token: 0x020030F6 RID: 12534
[NullableContext(1)]
[Nullable(0)]
public class IStopMoveParams : IActionParamMap
{
	// Token: 0x17002328 RID: 9000
	// (get) Token: 0x06019EC2 RID: 106178 RVA: 0x00794638 File Offset: 0x00792838
	// (set) Token: 0x06019EC3 RID: 106179 RVA: 0x00794640 File Offset: 0x00792840
	public int SplineId { get; set; }

	// Token: 0x17002329 RID: 9001
	// (get) Token: 0x06019EC4 RID: 106180 RVA: 0x00794649 File Offset: 0x00792849
	// (set) Token: 0x06019EC5 RID: 106181 RVA: 0x00794651 File Offset: 0x00792851
	public string Context { get; set; }

	// Token: 0x1700232A RID: 9002
	// (get) Token: 0x06019EC6 RID: 106182 RVA: 0x0079465A File Offset: 0x0079285A
	// (set) Token: 0x06019EC7 RID: 106183 RVA: 0x00794662 File Offset: 0x00792862
	public EStopMoveMethod? Method { get; set; }
}
