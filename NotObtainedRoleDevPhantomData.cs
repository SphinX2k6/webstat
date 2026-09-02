using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002806 RID: 10246
[NullableContext(1)]
[Nullable(0)]
public class NotObtainedRoleDevPhantomData : RoleDevPhantomViewItemDataBase
{
	// Token: 0x06014399 RID: 82841 RVA: 0x005A1E54 File Offset: 0x005A0054
	protected override void InitByRoleType(int roleId)
	{
		if (base.RoleDevViewModel != null && !base.RoleDevViewModel.CheckRoleIdIsCreated(base.RoleId))
		{
			int defaultRecommendPlanId = RoleDevPhantomDataUtils.GetDefaultRecommendPlanId(base.RoleId);
			base.RoleDevViewModel.SetRoleRecommendPlanId(base.RoleId, defaultRecommendPlanId);
		}
		this.RefreshSuitDataList();
	}

	// Token: 0x0601439A RID: 82842 RVA: 0x005A1EA0 File Offset: 0x005A00A0
	protected override List<RoleDevPhantomSuitItemData> GetSuitDataList()
	{
		return this.SuitDataListInternal;
	}

	// Token: 0x0601439B RID: 82843 RVA: 0x005A1EA8 File Offset: 0x005A00A8
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

	// Token: 0x04009D6A RID: 40298
	private List<RoleDevPhantomSuitItemData> SuitDataListInternal = new List<RoleDevPhantomSuitItemData>();
}
