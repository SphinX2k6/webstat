using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002807 RID: 10247
[NullableContext(1)]
[Nullable(0)]
public class ObtainedRoleDevPhantomData : RoleDevPhantomViewItemDataBase
{
	// Token: 0x0601439D RID: 82845 RVA: 0x005A1F14 File Offset: 0x005A0114
	protected override void InitByRoleType(int roleId)
	{
		if (base.RoleDevViewModel != null && !base.RoleDevViewModel.CheckRoleIdIsCreated(base.RoleId))
		{
			int defaultRecommendPlanId = RoleDevPhantomDataUtils.GetDefaultRecommendPlanId(base.RoleId);
			base.RoleDevViewModel.SetRoleRecommendPlanId(base.RoleId, defaultRecommendPlanId);
		}
		this.RefreshSuitDataList();
	}

	// Token: 0x0601439E RID: 82846 RVA: 0x005A1F60 File Offset: 0x005A0160
	protected override List<RoleDevPhantomSuitItemData> GetSuitDataList()
	{
		return this.SuitDataListInternal;
	}

	// Token: 0x0601439F RID: 82847 RVA: 0x005A1F68 File Offset: 0x005A0168
	public override void RefreshSuitDataList()
	{
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(base.RoleId);
		if (roleFetterRecommendInfo == null)
		{
			return;
		}
		if (base.RoleDevViewModel != null)
		{
			RoleDevPhantomDataUtils.SortRecommendInfo(roleFetterRecommendInfo);
			int roleRecommendPlanId = base.RoleDevViewModel.GetRoleRecommendPlanId(base.RoleId);
			this.SuitDataListInternal = RoleDevPhantomDataUtils.RefreshSuitDataListByRecommendInfo(base.RoleId, roleFetterRecommendInfo, roleRecommendPlanId);
		}
	}

	// Token: 0x04009D6B RID: 40299
	private List<RoleDevPhantomSuitItemData> SuitDataListInternal = new List<RoleDevPhantomSuitItemData>();
}
