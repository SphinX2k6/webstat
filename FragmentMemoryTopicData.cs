using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001C83 RID: 7299
[NullableContext(1)]
[Nullable(0)]
public class FragmentMemoryTopicData
{
	// Token: 0x0600D566 RID: 54630 RVA: 0x0038E9D7 File Offset: 0x0038CBD7
	public int GetId()
	{
		return this.Id;
	}

	// Token: 0x0600D567 RID: 54631 RVA: 0x0038E9E0 File Offset: 0x0038CBE0
	public void Phrase(PhotoMemoryTopicInfo data)
	{
		this.Id = data.Id;
		this.UnlockState = data.IsUnlock;
		this.FragmentMemoryCollectDataList = new List<FragmentMemoryCollectData>();
		foreach (PhotoMemoryCollectInfo photoMemoryCollectInfo in data.CollectInfos)
		{
			FragmentMemoryCollectData fragmentMemoryCollectData = new FragmentMemoryCollectData();
			fragmentMemoryCollectData.Phrase(photoMemoryCollectInfo);
			fragmentMemoryCollectData.PhraseFromConfig(ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryCollectById(photoMemoryCollectInfo.Id).Value);
			fragmentMemoryCollectData.BindSourceTopic(this);
			this.FragmentMemoryCollectDataList.Add(fragmentMemoryCollectData);
		}
		foreach (PhotoMemoryCollect config in ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryCollectConfigListByTopicId(this.Id))
		{
			FragmentMemoryCollectData fragmentMemoryCollectData2 = null;
			foreach (FragmentMemoryCollectData fragmentMemoryCollectData3 in this.FragmentMemoryCollectDataList)
			{
				if (fragmentMemoryCollectData3.GetId() == config.Id)
				{
					fragmentMemoryCollectData2 = fragmentMemoryCollectData3;
					break;
				}
			}
			if (fragmentMemoryCollectData2 == null)
			{
				FragmentMemoryCollectData fragmentMemoryCollectData4 = new FragmentMemoryCollectData();
				fragmentMemoryCollectData4.PhraseFromConfig(config);
				fragmentMemoryCollectData4.BindSourceTopic(this);
				this.FragmentMemoryCollectDataList.Add(fragmentMemoryCollectData4);
			}
		}
		this.FragmentMemoryCollectDataList.Sort((FragmentMemoryCollectData a, FragmentMemoryCollectData b) => a.GetRank() - b.GetRank());
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.FragmentRewardTopicRedDot, this.Id);
	}

	// Token: 0x0600D568 RID: 54632 RVA: 0x0038EB90 File Offset: 0x0038CD90
	public bool GetFirstOpen()
	{
		return ModelBase<FragmentMemoryModel>.Instance.GetTopicFirstOpenRedDotState(this.Id);
	}

	// Token: 0x0600D569 RID: 54633 RVA: 0x0038EBA4 File Offset: 0x0038CDA4
	public bool GetRedDotState()
	{
		if (!this.UnlockState)
		{
			return false;
		}
		if (this.GetFirstOpen())
		{
			return true;
		}
		using (List<FragmentMemoryCollectData>.Enumerator enumerator = this.FragmentMemoryCollectDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetIfCanGetReward())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600D56A RID: 54634 RVA: 0x0038EC14 File Offset: 0x0038CE14
	public bool GetCollectRedDotState()
	{
		if (!this.UnlockState)
		{
			return false;
		}
		using (List<FragmentMemoryCollectData>.Enumerator enumerator = this.FragmentMemoryCollectDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetIfCanGetReward())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600D56B RID: 54635 RVA: 0x0038EC78 File Offset: 0x0038CE78
	public ClueEntrance GetClueEntrance()
	{
		PhotoMemoryTopic? photoMemoryTopicById = ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryTopicById(this.Id);
		return ConfigBase<FragmentMemoryConfig>.Instance.GetClueEntrance(photoMemoryTopicById.Value.ClueId).Value;
	}

	// Token: 0x0600D56C RID: 54636 RVA: 0x0038ECB8 File Offset: 0x0038CEB8
	public IReadOnlyList<ClueContent> GetClueContent()
	{
		return ConfigBase<FragmentMemoryConfig>.Instance.GetClueContent(this.GetClueEntrance().ContentGroupId);
	}

	// Token: 0x0600D56D RID: 54637 RVA: 0x0038ECDD File Offset: 0x0038CEDD
	public List<FragmentMemoryCollectData> GetCollectDataList()
	{
		return this.FragmentMemoryCollectDataList;
	}

	// Token: 0x0600D56E RID: 54638 RVA: 0x0038ECE5 File Offset: 0x0038CEE5
	public int GetMemoryCollectNum()
	{
		return this.FragmentMemoryCollectDataList.Count;
	}

	// Token: 0x0600D56F RID: 54639 RVA: 0x0038ECF4 File Offset: 0x0038CEF4
	public bool GetCollectRewardDoneState()
	{
		if (this.FragmentMemoryCollectDataList.Count == 0)
		{
			return false;
		}
		using (List<FragmentMemoryCollectData>.Enumerator enumerator = this.FragmentMemoryCollectDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.GetIfGetReward())
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0600D570 RID: 54640 RVA: 0x0038ED5C File Offset: 0x0038CF5C
	public int GetFinishCollectNum()
	{
		int num = 0;
		using (List<FragmentMemoryCollectData>.Enumerator enumerator = this.FragmentMemoryCollectDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetIfUnlock())
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0600D571 RID: 54641 RVA: 0x0038EDB8 File Offset: 0x0038CFB8
	public bool GetAllCollectState()
	{
		using (List<FragmentMemoryCollectData>.Enumerator enumerator = this.FragmentMemoryCollectDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!enumerator.Current.GetIfUnlock())
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0600D572 RID: 54642 RVA: 0x0038EE14 File Offset: 0x0038D014
	public bool GetUnlockState()
	{
		return this.UnlockState;
	}

	// Token: 0x0600D573 RID: 54643 RVA: 0x0038EE1C File Offset: 0x0038D01C
	public PhotoMemoryTopic GetConfig()
	{
		return ConfigBase<FragmentMemoryConfig>.Instance.GetPhotoMemoryTopicById(this.Id).Value;
	}

	// Token: 0x0600D574 RID: 54644 RVA: 0x0038EE44 File Offset: 0x0038D044
	public string GetConditionDesc()
	{
		return LevelGeneralCommons.GetConditionGroupHintText(this.GetConfig().ConditionGroupId) ?? "";
	}

	// Token: 0x04006548 RID: 25928
	private int Id;

	// Token: 0x04006549 RID: 25929
	private List<FragmentMemoryCollectData> FragmentMemoryCollectDataList = new List<FragmentMemoryCollectData>();

	// Token: 0x0400654A RID: 25930
	private bool UnlockState = true;
}
