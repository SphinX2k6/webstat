using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x02002809 RID: 10249
public class RoleDevPhantomDungeonData : RoleDevPhantomVisionSuitItemData
{
	// Token: 0x060143A6 RID: 82854 RVA: 0x005A2190 File Offset: 0x005A0390
	public void InitByDungeon(int dungeonId)
	{
		if (dungeonId <= 0)
		{
			return;
		}
		SilentAreaDetectionRecord silentAreaDetectData = ModelBase<AdventureGuideModel>.Instance.GetSilentAreaDetectData(dungeonId);
		if (silentAreaDetectData == null || silentAreaDetectData.IsLock)
		{
			return;
		}
		SilentAreaDetection conf = silentAreaDetectData.Conf;
		List<IDropRewardItemData> dungeonDropRewards = this.GetDungeonDropRewards(conf);
		string buttonName = "RoleProject_Button03";
		base.InitByBaseData(dungeonId, EVisionSuitItemType.Dungeon, conf.Name ?? "", 0, buttonName, conf.BigIcon);
		base.SetRewardDataList(dungeonDropRewards);
		base.SetDungeonId(dungeonId);
	}

	// Token: 0x060143A7 RID: 82855 RVA: 0x005A2200 File Offset: 0x005A0400
	[NullableContext(1)]
	protected List<IDropRewardItemData> GetDungeonDropRewards(SilentAreaDetection conf)
	{
		List<IDropRewardItemData> list = new List<IDropRewardItemData>();
		if (conf.ShowRewardMap().Count > 0)
		{
			Dictionary<int, int> dictionary;
			if (conf.Secondary == 63 || conf.Secondary == 64)
			{
				dictionary = ConfigBase<AdventureGuideConfig>.Instance.GetNightMareShowReward(conf.ShowRewardMapCalabash());
			}
			else
			{
				dictionary = ConfigBase<AdventureGuideConfig>.Instance.GetShowReward(conf.ShowRewardMap(), null);
			}
			if (dictionary != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in dictionary)
				{
					list.Add(new DropRewardItemData
					{
						Type = ERoleDevItemType.Reward,
						ItemId = keyValuePair.Key,
						Count = keyValuePair.Value,
						HaveFinish = false
					});
				}
			}
		}
		return list;
	}
}
