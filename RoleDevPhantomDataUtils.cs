using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002808 RID: 10248
[NullableContext(1)]
[Nullable(0)]
public class RoleDevPhantomDataUtils
{
	// Token: 0x060143A1 RID: 82849 RVA: 0x005A1FD4 File Offset: 0x005A01D4
	public static List<RoleDevPhantomSuitItemData> RefreshSuitDataListByRecommendInfo(int roleId, List<VisionFetterRecommendInfo> recommendInfo, int selectedRecommendPlanId)
	{
		List<RoleDevPhantomSuitItemData> list = new List<RoleDevPhantomSuitItemData>();
		if (recommendInfo == null || recommendInfo.Count == 0)
		{
			return list;
		}
		VisionFetterRecommendInfo visionFetterRecommendInfo = recommendInfo.FirstOrDefault((VisionFetterRecommendInfo recommend) => recommend.GetPlanId() == selectedRecommendPlanId);
		if (visionFetterRecommendInfo == null)
		{
			visionFetterRecommendInfo = recommendInfo.FirstOrDefault((VisionFetterRecommendInfo recommend) => recommend.GetRecommendFetterGroupId() == selectedRecommendPlanId);
		}
		if (visionFetterRecommendInfo == null)
		{
			return list;
		}
		int recommendFetterGroupId = visionFetterRecommendInfo.GetRecommendFetterGroupId();
		EFetterGroupType fetterType = visionFetterRecommendInfo.GetFetterType();
		RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
		RoleDevPhantomJumpGroup? roleDevPhantomJumpGroup = (instance != null) ? instance.GetPhantomJumpGroupConfig(recommendFetterGroupId) : null;
		if (roleDevPhantomJumpGroup == null)
		{
			return list;
		}
		RoleDevPhantomSuitItemData roleDevPhantomSuitItemData = new RoleDevPhantomSuitItemData();
		roleDevPhantomSuitItemData.Init(recommendFetterGroupId, roleId, visionFetterRecommendInfo);
		list.Add(roleDevPhantomSuitItemData);
		if (fetterType == EFetterGroupType.Special)
		{
			int specialFetterSubGroupId = visionFetterRecommendInfo.GetSpecialFetterSubGroupId();
			if (specialFetterSubGroupId > 0)
			{
				RoleDevConfig instance2 = ConfigBase<RoleDevConfig>.Instance;
				RoleDevPhantomJumpGroup? roleDevPhantomJumpGroup2 = (instance2 != null) ? instance2.GetPhantomJumpGroupConfig(specialFetterSubGroupId) : null;
				if (roleDevPhantomJumpGroup2 != null)
				{
					RoleDevPhantomSuitItemData roleDevPhantomSuitItemData2 = new RoleDevPhantomSuitItemData();
					roleDevPhantomSuitItemData2.Init(specialFetterSubGroupId, roleId, visionFetterRecommendInfo);
					list.Add(roleDevPhantomSuitItemData2);
				}
			}
		}
		return list;
	}

	// Token: 0x060143A2 RID: 82850 RVA: 0x005A20D3 File Offset: 0x005A02D3
	public static List<VisionFetterRecommendInfo> SortRecommendInfo(List<VisionFetterRecommendInfo> recommendInfo)
	{
		recommendInfo.Sort((VisionFetterRecommendInfo a, VisionFetterRecommendInfo b) => b.GetUsage() - a.GetUsage());
		return recommendInfo;
	}

	// Token: 0x060143A3 RID: 82851 RVA: 0x005A20FC File Offset: 0x005A02FC
	public static List<RoleDevPhantomSuitItemData> RefreshSuitDataListByFetterGroupId(int roleId, int fetterGroupId)
	{
		List<RoleDevPhantomSuitItemData> list = new List<RoleDevPhantomSuitItemData>();
		RoleDevConfig instance = ConfigBase<RoleDevConfig>.Instance;
		RoleDevPhantomJumpGroup? roleDevPhantomJumpGroup = (instance != null) ? instance.GetPhantomJumpGroupConfig(fetterGroupId) : null;
		if (roleDevPhantomJumpGroup == null)
		{
			return list;
		}
		RoleDevPhantomSuitItemData roleDevPhantomSuitItemData = new RoleDevPhantomSuitItemData();
		roleDevPhantomSuitItemData.Init(fetterGroupId, roleId, null);
		list.Add(roleDevPhantomSuitItemData);
		return list;
	}

	// Token: 0x060143A4 RID: 82852 RVA: 0x005A214C File Offset: 0x005A034C
	public static int GetDefaultRecommendPlanId(int roleId)
	{
		List<VisionFetterRecommendInfo> roleFetterRecommendInfo = ModelBase<VisionRecommendModel>.Instance.GetRoleFetterRecommendInfo(roleId);
		if (roleFetterRecommendInfo == null || roleFetterRecommendInfo.Count == 0)
		{
			return 0;
		}
		RoleDevPhantomDataUtils.SortRecommendInfo(roleFetterRecommendInfo);
		return roleFetterRecommendInfo[0].GetPlanId();
	}
}
