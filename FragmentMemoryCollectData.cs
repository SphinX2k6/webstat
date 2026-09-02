using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;

// Token: 0x02001C82 RID: 7298
[NullableContext(1)]
[Nullable(0)]
public class FragmentMemoryCollectData
{
	// Token: 0x0600D548 RID: 54600 RVA: 0x0038E639 File Offset: 0x0038C839
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x0600D549 RID: 54601 RVA: 0x0038E641 File Offset: 0x0038C841
	public int GetFlag()
	{
		return this.Flag;
	}

	// Token: 0x0600D54A RID: 54602 RVA: 0x0038E649 File Offset: 0x0038C849
	public bool GetIfCanGetReward()
	{
		return this.GetIfUnlock() && !this.GetIfGetReward();
	}

	// Token: 0x0600D54B RID: 54603 RVA: 0x0038E65E File Offset: 0x0038C85E
	public bool GetIfUnlock()
	{
		return (this.Flag & 1) == 1;
	}

	// Token: 0x0600D54C RID: 54604 RVA: 0x0038E66B File Offset: 0x0038C86B
	[NullableContext(2)]
	public FragmentMemoryTopicData GetTopicData()
	{
		return this.TopicData;
	}

	// Token: 0x0600D54D RID: 54605 RVA: 0x0038E673 File Offset: 0x0038C873
	public bool GetIfGetReward()
	{
		return (this.Flag >> 1 & 1) == 1;
	}

	// Token: 0x0600D54E RID: 54606 RVA: 0x0038E684 File Offset: 0x0038C884
	public int GetTraceEntityId()
	{
		return this.GetConfig().TraceEntityId;
	}

	// Token: 0x0600D54F RID: 54607 RVA: 0x0038E6A0 File Offset: 0x0038C8A0
	public int GetTraceMarkId()
	{
		return this.GetConfig().TraceMarkId;
	}

	// Token: 0x0600D550 RID: 54608 RVA: 0x0038E6BC File Offset: 0x0038C8BC
	public int GetTrackMapId()
	{
		return this.GetConfig().TrackMapId;
	}

	// Token: 0x0600D551 RID: 54609 RVA: 0x0038E6D8 File Offset: 0x0038C8D8
	public List<int> GetQuestList()
	{
		return this.GetConfig().GetQuestIdListArray().ToList<int>();
	}

	// Token: 0x0600D552 RID: 54610 RVA: 0x0038E6F8 File Offset: 0x0038C8F8
	public double GetFinishTime()
	{
		return this.FinishTime;
	}

	// Token: 0x0600D553 RID: 54611 RVA: 0x0038E700 File Offset: 0x0038C900
	public void PhraseFromConfig(PhotoMemoryCollect config)
	{
		this.Id = config.Id;
	}

	// Token: 0x0600D554 RID: 54612 RVA: 0x0038E710 File Offset: 0x0038C910
	public int GetRank()
	{
		return this.GetConfig().Rank;
	}

	// Token: 0x0600D555 RID: 54613 RVA: 0x0038E72C File Offset: 0x0038C92C
	public void Phrase(PhotoMemoryCollectInfo data)
	{
		this.Id = data.Id;
		this.Flag = data.Flag;
		this.FinishTime = (double)Singleton<MathUtils>.Instance.LongToBigInt(data.CollectTime) / 1000.0;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.FragmentRewardRedDot, this.Id);
	}

	// Token: 0x0600D556 RID: 54614 RVA: 0x0038E788 File Offset: 0x0038C988
	public string GetTimeText()
	{
		if (this.FinishTime == 0.0)
		{
			return "";
		}
		return Singleton<TimeUtil>.Instance.DateFormatString(this.FinishTime);
	}

	// Token: 0x0600D557 RID: 54615 RVA: 0x0038E7B1 File Offset: 0x0038C9B1
	public void BindSourceTopic(FragmentMemoryTopicData topicData)
	{
		this.TopicData = topicData;
	}

	// Token: 0x0600D558 RID: 54616 RVA: 0x0038E7BC File Offset: 0x0038C9BC
	public ClueEntrance GetClueEntrance()
	{
		return ConfigBase<FragmentMemoryConfig>.Instance.GetClueEntrance(this.GetClueId()).Value;
	}

	// Token: 0x0600D559 RID: 54617 RVA: 0x0038E7E4 File Offset: 0x0038C9E4
	public IReadOnlyList<ClueContent> GetClueContent()
	{
		return ConfigBase<FragmentMemoryConfig>.Instance.GetClueContent(this.GetClueEntrance().ContentGroupId);
	}

	// Token: 0x0600D55A RID: 54618 RVA: 0x0038E80C File Offset: 0x0038CA0C
	public int GetClueId()
	{
		return this.GetConfig().ClueId;
	}

	// Token: 0x0600D55B RID: 54619 RVA: 0x0038E828 File Offset: 0x0038CA28
	public PhotoMemoryCollect GetConfig()
	{
		return ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryCollectById(this.Id).Value;
	}

	// Token: 0x0600D55C RID: 54620 RVA: 0x0038E850 File Offset: 0x0038CA50
	public string GetTitle()
	{
		return this.GetConfig().Title;
	}

	// Token: 0x0600D55D RID: 54621 RVA: 0x0038E86C File Offset: 0x0038CA6C
	public string GetTipsDesc()
	{
		return this.GetConfig().TipsDesc;
	}

	// Token: 0x0600D55E RID: 54622 RVA: 0x0038E888 File Offset: 0x0038CA88
	public string GetDesc()
	{
		return this.GetConfig().Desc;
	}

	// Token: 0x0600D55F RID: 54623 RVA: 0x0038E8A4 File Offset: 0x0038CAA4
	public int GetDropId()
	{
		return this.GetConfig().DropId;
	}

	// Token: 0x0600D560 RID: 54624 RVA: 0x0038E8C0 File Offset: 0x0038CAC0
	public List<TItem> GetPreviewReward()
	{
		Dictionary<int, int> dictionary = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(this.GetDropId()).Value.DropPreview();
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value);
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0600D561 RID: 54625 RVA: 0x0038E95C File Offset: 0x0038CB5C
	public string GetThemeBg()
	{
		return this.GetBgResource();
	}

	// Token: 0x0600D562 RID: 54626 RVA: 0x0038E964 File Offset: 0x0038CB64
	public string GetBgResource()
	{
		EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
		if (playerGender == EPlayerGender.Male)
		{
			return this.GetMaleBgResource();
		}
		if (playerGender == EPlayerGender.Female)
		{
			return this.GetFemaleBgResource();
		}
		return "";
	}

	// Token: 0x0600D563 RID: 54627 RVA: 0x0038E998 File Offset: 0x0038CB98
	private string GetMaleBgResource()
	{
		return this.GetConfig().BgResourceM;
	}

	// Token: 0x0600D564 RID: 54628 RVA: 0x0038E9B4 File Offset: 0x0038CBB4
	private string GetFemaleBgResource()
	{
		return this.GetConfig().BgResourceF;
	}

	// Token: 0x04006544 RID: 25924
	private int Id;

	// Token: 0x04006545 RID: 25925
	private int Flag;

	// Token: 0x04006546 RID: 25926
	[Nullable(2)]
	private FragmentMemoryTopicData TopicData;

	// Token: 0x04006547 RID: 25927
	private double FinishTime;
}
