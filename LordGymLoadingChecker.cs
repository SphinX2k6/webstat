using System;
using System.Collections.Generic;
using Aki.Config;
using CSharpScript.Game.Ui;

// Token: 0x020020CB RID: 8395
public class LordGymLoadingChecker : ISpecialCustomLoadingTypeChecker
{
	// Token: 0x060100A6 RID: 65702 RVA: 0x00467B1C File Offset: 0x00465D1C
	public bool CanHandle(int instanceId)
	{
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		return config != null && config.Value.InstSubType == 48;
	}

	// Token: 0x060100A7 RID: 65703 RVA: 0x00467B54 File Offset: 0x00465D54
	public EUiViewName? GetLoadingViewName(int instanceId)
	{
		IReadOnlyList<LordGymEntranceSet> configList = ConfigLordGymEntranceSetAll.GetConfigList(true);
		if (configList == null)
		{
			return null;
		}
		LordGymEntranceSet? lordGymEntranceSet = null;
		foreach (LordGymEntranceSet value in configList)
		{
			if (value.DungeonId == instanceId)
			{
				lordGymEntranceSet = new LordGymEntranceSet?(value);
				break;
			}
		}
		if (lordGymEntranceSet == null)
		{
			return null;
		}
		if (lordGymEntranceSet.Value.Id == 200104)
		{
			return new EUiViewName?(EUiViewName.LordGymThird5LoadingView);
		}
		if (lordGymEntranceSet.Value.Id != 200103 && ModelBase<LordGymModel>.Instance.LastChallengeEntryFromGuide)
		{
			return null;
		}
		return new EUiViewName?(EUiViewName.LordGymLoadingView);
	}
}
