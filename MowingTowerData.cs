using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;

// Token: 0x02001432 RID: 5170
[NullableContext(1)]
[Nullable(0)]
public class MowingTowerData : ActivityBaseData
{
	// Token: 0x06008FD6 RID: 36822 RVA: 0x0025C3B4 File Offset: 0x0025A5B4
	protected override void PhraseEx(ActivityData data)
	{
		this.CurrentLevelInfoMap.Clear();
		this.CurrentLevelRewardInfoMap.Clear();
		this.PhraseLevelInfo(data.MowTowerActivityInfo.MowTowerLevelInfos.ToList<MowTowerLevelsInfo>());
		this.CheckIfNewMowingTowerOpen();
		this.PhraseRewardInfo(data.MowTowerActivityInfo.MowTowerLevelInfos.ToList<MowTowerLevelsInfo>());
		this.CurrentData = data;
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshMowingTowerData);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshMowingTowerRewardRedDot, base.Id);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06008FD7 RID: 36823 RVA: 0x0025C44C File Offset: 0x0025A64C
	public void RebuildData()
	{
		if (this.CurrentData != null)
		{
			this.PhraseEx(this.CurrentData);
		}
	}

	// Token: 0x06008FD8 RID: 36824 RVA: 0x0025C464 File Offset: 0x0025A664
	public void PhraseRewardInfo(List<MowTowerLevelsInfo> levelData)
	{
		foreach (MowTowerLevelsInfo mowTowerLevelsInfo in levelData)
		{
			List<IActivityRewardData> value = this.CreateLevelReward(mowTowerLevelsInfo.LevelsId, mowTowerLevelsInfo);
			this.CurrentLevelRewardInfoMap[mowTowerLevelsInfo.LevelsId] = value;
		}
	}

	// Token: 0x06008FD9 RID: 36825 RVA: 0x0025C4CC File Offset: 0x0025A6CC
	public void PhraseLevelInfo(List<MowTowerLevelsInfo> data)
	{
		foreach (MowTowerLevelsInfo mowTowerLevelsInfo in data)
		{
			MowingTowerLevelDetailInfo mowingTowerLevelDetailInfo;
			if (!this.CurrentLevelInfoMap.TryGetValue(mowTowerLevelsInfo.LevelsId, out mowingTowerLevelDetailInfo))
			{
				mowingTowerLevelDetailInfo = new MowingTowerLevelDetailInfo();
			}
			mowingTowerLevelDetailInfo.Phrase(base.Id, mowTowerLevelsInfo);
			this.CurrentLevelInfoMap[mowTowerLevelsInfo.LevelsId] = mowingTowerLevelDetailInfo;
			List<IActivityRewardData> value = this.CreateLevelReward(mowingTowerLevelDetailInfo.GetId(), mowTowerLevelsInfo);
			this.CurrentLevelRewardInfoMap[mowingTowerLevelDetailInfo.GetId()] = value;
		}
		if (this.CurrentData != null)
		{
			this.CurrentData.MowTowerActivityInfo.MowTowerLevelInfos.Clear();
			this.CurrentData.MowTowerActivityInfo.MowTowerLevelInfos.AddRange(data);
		}
	}

	// Token: 0x06008FDA RID: 36826 RVA: 0x0025C5A0 File Offset: 0x0025A7A0
	[NullableContext(2)]
	public MowingTowerLevelDetailInfo GetMowingTowerLevelDetailInfoById(int levelsId)
	{
		foreach (KeyValuePair<int, MowingTowerLevelDetailInfo> keyValuePair in this.CurrentLevelInfoMap)
		{
			MowingTowerLevelDetailInfo value = keyValuePair.Value;
			if (value.GetId() == levelsId)
			{
				return value;
			}
		}
		return null;
	}

	// Token: 0x06008FDB RID: 36827 RVA: 0x0025C604 File Offset: 0x0025A804
	public MowingTowerLevelDetailInfo[] GetMowingTowerLevelDetailInfo()
	{
		return this.CurrentLevelInfoMap.Values.ToArray<MowingTowerLevelDetailInfo>();
	}

	// Token: 0x06008FDC RID: 36828 RVA: 0x0025C616 File Offset: 0x0025A816
	public override bool GetExDataRedPointShowState()
	{
		return base.GetPreGuideQuestFinishState() && (this.NewOpenMowingTowerState || this.GetIfCanTakeReward());
	}

	// Token: 0x06008FDD RID: 36829 RVA: 0x0025C632 File Offset: 0x0025A832
	public bool GetNewUnlockState()
	{
		return this.NeedShowNewUnlock;
	}

	// Token: 0x06008FDE RID: 36830 RVA: 0x0025C63C File Offset: 0x0025A83C
	private bool GetIfCanTakeReward()
	{
		foreach (KeyValuePair<int, List<IActivityRewardData>> keyValuePair in this.CurrentLevelRewardInfoMap)
		{
			using (List<IActivityRewardData>.Enumerator enumerator2 = keyValuePair.Value.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.RewardState == EActivityRewardState.Enable)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06008FDF RID: 36831 RVA: 0x0025C6D4 File Offset: 0x0025A8D4
	private bool GetIfCanTakeRewardByLevelId(int levelId)
	{
		List<IActivityRewardData> list;
		if (!this.CurrentLevelRewardInfoMap.TryGetValue(levelId, out list))
		{
			return false;
		}
		foreach (IActivityRewardData activityRewardData in list)
		{
			int? id = activityRewardData.Id;
			if ((id.GetValueOrDefault() == levelId & id != null) && activityRewardData.RewardState == EActivityRewardState.Enable)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06008FE0 RID: 36832 RVA: 0x0025C760 File Offset: 0x0025A960
	public void CheckIfNewMowingTowerOpen()
	{
		int activityCacheData = ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, base.Id, 0, 0);
		int currentOpenBossNum = this.GetCurrentOpenBossNum();
		this.NewOpenMowingTowerState = (currentOpenBossNum > activityCacheData);
		int activityCacheData2 = ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, base.Id, 100, 0);
		this.NeedShowNewUnlock = (currentOpenBossNum > activityCacheData2);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06008FE1 RID: 36833 RVA: 0x0025C7D4 File Offset: 0x0025A9D4
	public int GetCurrentCheckBuffIndex()
	{
		int result = 0;
		MowingTowerLevelDetailInfo[] mowingTowerLevelDetailInfo = this.GetMowingTowerLevelDetailInfo();
		int num = mowingTowerLevelDetailInfo.Length;
		for (int i = 0; i < num; i++)
		{
			if (mowingTowerLevelDetailInfo[i].GetUnLockState())
			{
				result = i;
			}
		}
		return result;
	}

	// Token: 0x06008FE2 RID: 36834 RVA: 0x0025C808 File Offset: 0x0025AA08
	private int GetCurrentOpenBossNum()
	{
		int num = 0;
		MowingTowerLevelDetailInfo[] mowingTowerLevelDetailInfo = this.GetMowingTowerLevelDetailInfo();
		for (int i = 0; i < mowingTowerLevelDetailInfo.Length; i++)
		{
			if (mowingTowerLevelDetailInfo[i].GetUnLockState())
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06008FE3 RID: 36835 RVA: 0x0025C83C File Offset: 0x0025AA3C
	public void CacheNewUnlock()
	{
		this.NeedShowNewUnlock = false;
		int currentOpenBossNum = this.GetCurrentOpenBossNum();
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, base.Id, 100, 0, currentOpenBossNum);
		this.CheckIfNewMowingTowerOpen();
	}

	// Token: 0x06008FE4 RID: 36836 RVA: 0x0025C878 File Offset: 0x0025AA78
	public void CacheCurrentOpenBossNum()
	{
		int currentOpenBossNum = this.GetCurrentOpenBossNum();
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, base.Id, 0, 0, currentOpenBossNum);
		this.CheckIfNewMowingTowerOpen();
	}

	// Token: 0x06008FE5 RID: 36837 RVA: 0x0025C8AB File Offset: 0x0025AAAB
	public bool EntranceRedDot()
	{
		return this.GetExDataRedPointShowState();
	}

	// Token: 0x06008FE6 RID: 36838 RVA: 0x0025C8B3 File Offset: 0x0025AAB3
	public bool HaveRewardCanTake()
	{
		return this.GetIfCanTakeReward();
	}

	// Token: 0x06008FE7 RID: 36839 RVA: 0x0025C8BB File Offset: 0x0025AABB
	public bool HaveLevelRewardCanTake(int levelId)
	{
		return this.GetIfCanTakeRewardByLevelId(levelId);
	}

	// Token: 0x06008FE8 RID: 36840 RVA: 0x0025C8C4 File Offset: 0x0025AAC4
	public int GetFullScore()
	{
		int num = 0;
		foreach (KeyValuePair<int, MowingTowerLevelDetailInfo> keyValuePair in this.CurrentLevelInfoMap)
		{
			MowingTowerLevelDetailInfo value = keyValuePair.Value;
			num += value.GetScore();
		}
		return num;
	}

	// Token: 0x06008FE9 RID: 36841 RVA: 0x0025C924 File Offset: 0x0025AB24
	private string GetButtonText(int state)
	{
		string result = "";
		switch (state)
		{
		case 0:
			result = "PrefabTextItem_1443074454_Text";
			break;
		case 1:
			result = "CollectActivity_state_CanRecive";
			break;
		case 2:
			result = "CollectActivity_state_recived";
			break;
		}
		return result;
	}

	// Token: 0x06008FEA RID: 36842 RVA: 0x0025C964 File Offset: 0x0025AB64
	private List<TItem> GetRewardItems(int dropId)
	{
		List<TItem> list = new List<TItem>();
		Dictionary<int, int> dropPackagePreview = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview(dropId);
		if (dropPackagePreview != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dropPackagePreview)
			{
				list.Add(new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value));
			}
		}
		return list;
	}

	// Token: 0x06008FEB RID: 36843 RVA: 0x0025C9E0 File Offset: 0x0025ABE0
	private List<IActivityRewardData> CreateLevelReward(int levelId, MowTowerLevelsInfo levelData)
	{
		List<IActivityRewardData> list = new List<IActivityRewardData>();
		int[] array = levelData.LevelRewardStatus.Keys.ToArray<int>();
		for (int i = 0; i < array.Length; i++)
		{
			int num = array[i];
			MowTowerRewardRe? config = ConfigBase<MowingTowerConfig>.Instance.GetMowingTowerRewardById(num);
			if (config != null)
			{
				MowTowerRewardStatus mowTowerRewardStatus = levelData.LevelRewardStatus[num];
				int score = config.Value.Score;
				int capturedIndex = i;
				ActivityRewardData item = new ActivityRewardData
				{
					Id = new int?(levelId),
					NameText = ConfigMultiTextLang.GetLocalTextNew(config.Value.LevelRewardDesc, null),
					NameTextArgs = new string[]
					{
						score.ToString() ?? "",
						(levelData.FirstScore + levelData.SecondScore).ToString() ?? ""
					},
					RewardState = (EActivityRewardState)mowTowerRewardStatus,
					ClickFunction = delegate
					{
						ControllerBase<MowingTowerController>.Instance.RequestGetMowingTowerLevelReward(this.Id, config.Value.Id, config.Value.MowTowerLevelsId, capturedIndex);
					},
					RewardList = this.GetRewardItems(config.Value.RewardId).ToArray(),
					RewardButtonText = ConfigMultiTextLang.GetLocalTextNew(this.GetButtonText((int)mowTowerRewardStatus), null)
				};
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06008FEC RID: 36844 RVA: 0x0025CB54 File Offset: 0x0025AD54
	public List<IActivityRewardData> GetRewardByLevelId(int? levelId = null)
	{
		List<IActivityRewardData> result;
		if (this.CurrentLevelRewardInfoMap.TryGetValue(levelId.GetValueOrDefault(), out result))
		{
			return result;
		}
		return new List<IActivityRewardData>();
	}

	// Token: 0x06008FED RID: 36845 RVA: 0x0025CB80 File Offset: 0x0025AD80
	public void SetRewardStateClaimed(int levelId, int index)
	{
		List<IActivityRewardData> list;
		if (!this.CurrentLevelRewardInfoMap.TryGetValue(levelId, out list))
		{
			return;
		}
		if (index >= list.Count)
		{
			return;
		}
		IActivityRewardData activityRewardData = list[index];
		if (activityRewardData == null)
		{
			return;
		}
		activityRewardData.RewardState = EActivityRewardState.Claimed;
	}

	// Token: 0x040042B4 RID: 17076
	private readonly Dictionary<int, List<IActivityRewardData>> CurrentLevelRewardInfoMap = new Dictionary<int, List<IActivityRewardData>>();

	// Token: 0x040042B5 RID: 17077
	private bool NewOpenMowingTowerState;

	// Token: 0x040042B6 RID: 17078
	private bool NeedShowNewUnlock;

	// Token: 0x040042B7 RID: 17079
	private readonly Dictionary<int, MowingTowerLevelDetailInfo> CurrentLevelInfoMap = new Dictionary<int, MowingTowerLevelDetailInfo>();

	// Token: 0x040042B8 RID: 17080
	[Nullable(2)]
	private ActivityData CurrentData;
}
