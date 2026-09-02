using System;
using System.Runtime.CompilerServices;

// Token: 0x02002540 RID: 9536
[NullableContext(2)]
public interface IVisionRecommendViewOpenParam
{
	// Token: 0x17001777 RID: 6007
	// (get) Token: 0x060128E4 RID: 76004
	// (set) Token: 0x060128E5 RID: 76005
	int RoleId { get; set; }

	// Token: 0x17001778 RID: 6008
	// (get) Token: 0x060128E6 RID: 76006
	// (set) Token: 0x060128E7 RID: 76007
	bool IsFromRoleDev { get; set; }

	// Token: 0x17001779 RID: 6009
	// (get) Token: 0x060128E8 RID: 76008
	// (set) Token: 0x060128E9 RID: 76009
	Action<int, int, int?> SuccessCallBack { get; set; }

	// Token: 0x1700177A RID: 6010
	// (get) Token: 0x060128EA RID: 76010
	// (set) Token: 0x060128EB RID: 76011
	Func<int, int> GetSelectedPlanIdCallBack { get; set; }

	// Token: 0x1700177B RID: 6011
	// (get) Token: 0x060128EC RID: 76012
	// (set) Token: 0x060128ED RID: 76013
	Func<int, int> GetSelectedFirstVisionMonsterIdCallBack { get; set; }
}
