using System;
using System.Runtime.CompilerServices;

// Token: 0x02002541 RID: 9537
[NullableContext(2)]
[Nullable(0)]
public class VisionRecommendViewOpenParam : IVisionRecommendViewOpenParam
{
	// Token: 0x1700177C RID: 6012
	// (get) Token: 0x060128EE RID: 76014 RVA: 0x0051CD79 File Offset: 0x0051AF79
	// (set) Token: 0x060128EF RID: 76015 RVA: 0x0051CD81 File Offset: 0x0051AF81
	public int RoleId { get; set; }

	// Token: 0x1700177D RID: 6013
	// (get) Token: 0x060128F0 RID: 76016 RVA: 0x0051CD8A File Offset: 0x0051AF8A
	// (set) Token: 0x060128F1 RID: 76017 RVA: 0x0051CD92 File Offset: 0x0051AF92
	public bool IsFromRoleDev { get; set; }

	// Token: 0x1700177E RID: 6014
	// (get) Token: 0x060128F2 RID: 76018 RVA: 0x0051CD9B File Offset: 0x0051AF9B
	// (set) Token: 0x060128F3 RID: 76019 RVA: 0x0051CDA3 File Offset: 0x0051AFA3
	public Action<int, int, int?> SuccessCallBack { get; set; }

	// Token: 0x1700177F RID: 6015
	// (get) Token: 0x060128F4 RID: 76020 RVA: 0x0051CDAC File Offset: 0x0051AFAC
	// (set) Token: 0x060128F5 RID: 76021 RVA: 0x0051CDB4 File Offset: 0x0051AFB4
	public Func<int, int> GetSelectedPlanIdCallBack { get; set; }

	// Token: 0x17001780 RID: 6016
	// (get) Token: 0x060128F6 RID: 76022 RVA: 0x0051CDBD File Offset: 0x0051AFBD
	// (set) Token: 0x060128F7 RID: 76023 RVA: 0x0051CDC5 File Offset: 0x0051AFC5
	public Func<int, int> GetSelectedFirstVisionMonsterIdCallBack { get; set; }
}
