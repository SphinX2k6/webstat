using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200253A RID: 9530
[NullableContext(2)]
[Nullable(0)]
public class VisionNewRecommendProxy
{
	// Token: 0x060128AD RID: 75949 RVA: 0x0051BE01 File Offset: 0x0051A001
	public VisionFetterRecommendInfo GetCurrentSelectRecommendInfo()
	{
		return this.CurrentSelectFetterRecommendInfo;
	}

	// Token: 0x060128AE RID: 75950 RVA: 0x0051BE09 File Offset: 0x0051A009
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<VisionFetterRecommendInfo> GetSystemRecommendInfoList()
	{
		return ModelBase<VisionRecommendModel>.Instance.GetRoleSystemFetterRecommendList(this.CurrentSelectRoleId);
	}

	// Token: 0x060128AF RID: 75951 RVA: 0x0051BE1B File Offset: 0x0051A01B
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<VisionFetterRecommendInfo> GetUsageRecommendInfoList()
	{
		return ModelBase<VisionRecommendModel>.Instance.GetRoleUsageFetterRecommendList(this.CurrentSelectRoleId);
	}

	// Token: 0x04009079 RID: 36985
	public bool IsFromRoleDev;

	// Token: 0x0400907A RID: 36986
	public int CurrentSelectRoleId;

	// Token: 0x0400907B RID: 36987
	public VisionFetterRecommendInfo CurrentSelectFetterRecommendInfo;

	// Token: 0x0400907C RID: 36988
	public bool IsSimpleMode = true;

	// Token: 0x0400907D RID: 36989
	public int CurrentSelectFirstVisionMonsterId;

	// Token: 0x0400907E RID: 36990
	public Func<int, int> GetSelectedPlanIdCallBack;

	// Token: 0x0400907F RID: 36991
	public Func<int, int> GetSelectedFirstVisionMonsterIdCallBack;

	// Token: 0x04009080 RID: 36992
	public Action<Action> RefreshSelectedRecommendDetail;

	// Token: 0x04009081 RID: 36993
	public bool IsFromRoleDevFirstSelect;

	// Token: 0x04009082 RID: 36994
	public UiBehaviorLevelSequence MainViewSequence;
}
