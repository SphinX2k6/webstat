using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x02001315 RID: 4885
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityDoubleRewardController : ActivityControllerBase<ActivityDoubleRewardController>
{
	// Token: 0x060084EE RID: 34030 RVA: 0x002307D5 File Offset: 0x0022E9D5
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x060084EF RID: 34031 RVA: 0x002307D8 File Offset: 0x0022E9D8
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060084F0 RID: 34032 RVA: 0x002307DA File Offset: 0x0022E9DA
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return ((ActivityDoubleRewardData)data).Prefab;
	}

	// Token: 0x060084F1 RID: 34033 RVA: 0x002307E7 File Offset: 0x0022E9E7
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewDoubleReward();
	}

	// Token: 0x060084F2 RID: 34034 RVA: 0x002307EE File Offset: 0x0022E9EE
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.UniversalActivityIdSet.Add(data.Id);
		return new ActivityDoubleRewardData();
	}

	// Token: 0x060084F3 RID: 34035 RVA: 0x00230807 File Offset: 0x0022EA07
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x060084F4 RID: 34036 RVA: 0x0023080A File Offset: 0x0022EA0A
	protected override bool OnClear()
	{
		this.UniversalActivityIdSet.Clear();
		return true;
	}

	// Token: 0x060084F5 RID: 34037 RVA: 0x00230818 File Offset: 0x0022EA18
	public bool IsAnyActivityHasLeftUpCount()
	{
		foreach (ActivityBaseData activityBaseData in ModelBase<ActivityModel>.Instance.GetActivitiesByType(7))
		{
			if (activityBaseData.CheckIfInShowTime() && (activityBaseData as ActivityDoubleRewardData).LeftUpCount > 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060084F6 RID: 34038 RVA: 0x00230888 File Offset: 0x0022EA88
	public ActivityDoubleRewardData GetAdventureUpActivity(EDungeonType type)
	{
		foreach (int id in this.UniversalActivityIdSet)
		{
			ActivityDoubleRewardData activityDoubleRewardData = ModelBase<ActivityModel>.Instance.GetActivityById(id) as ActivityDoubleRewardData;
			if (activityDoubleRewardData != null && activityDoubleRewardData.CheckIfInOpenTime() && activityDoubleRewardData != null && activityDoubleRewardData.AdventureGuideUpList.Contains(type))
			{
				return activityDoubleRewardData;
			}
		}
		return null;
	}

	// Token: 0x060084F7 RID: 34039 RVA: 0x00230908 File Offset: 0x0022EB08
	[return: Nullable(2)]
	public ActivityDoubleRewardData GetDungeonUpActivity(IList<int> customTypes, bool isInstance = true)
	{
		foreach (int id in this.UniversalActivityIdSet)
		{
			ActivityDoubleRewardData activityDoubleRewardData = ModelBase<ActivityModel>.Instance.GetActivityById(id) as ActivityDoubleRewardData;
			if (activityDoubleRewardData != null && activityDoubleRewardData.CheckIfInOpenTime() && activityDoubleRewardData.GetDungeonUpList(isInstance).ToList<int>().Any(new Func<int, bool>(customTypes.Contains)))
			{
				return activityDoubleRewardData;
			}
		}
		return null;
	}

	// Token: 0x060084F8 RID: 34040 RVA: 0x00230998 File Offset: 0x0022EB98
	public string GetDungeonUpActivityFullTip(List<int> customTypes, bool isInstance = true)
	{
		ActivityDoubleRewardData dungeonUpActivity = this.GetDungeonUpActivity(customTypes, isInstance);
		if (dungeonUpActivity == null)
		{
			return null;
		}
		return dungeonUpActivity.GetFullTip();
	}

	// Token: 0x060084F9 RID: 34041 RVA: 0x002309AD File Offset: 0x0022EBAD
	public bool HasAnyDoubleRewardActivityShowing()
	{
		return ModelBase<ActivityModel>.Instance.GetIsActivityShowingByType(7);
	}

	// Token: 0x04003F08 RID: 16136
	private readonly HashSet<int> UniversalActivityIdSet = new HashSet<int>();
}
