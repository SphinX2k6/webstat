using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.HonamiStory;

// Token: 0x02001ECF RID: 7887
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryActivityData : ActivityBaseData
{
	// Token: 0x0600E919 RID: 59673 RVA: 0x003F352C File Offset: 0x003F172C
	protected override void OnInit(ActivityData data)
	{
		HonamiStoryActivityInfo honamiStoryActivityInfo = data.HonamiStoryActivityInfo;
		if (honamiStoryActivityInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.BB, "HonamiStoryActivityData初始化 无效activityInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ModelBase<HonamiStoryModel>.Instance.InitActivityInfo(base.Id, honamiStoryActivityInfo);
		this.InitHonamiStoryAreaData();
		this.InitHonamiStoryMascotData();
		this.InitHonamiStoryPermanentTaskData();
		this.InitHonamiStoryLimitTaskData();
		this.InitHonamiStoryScoreRewardData();
		this.InitItemCollectionData();
		this.InitSubQuestTaskDataList(honamiStoryActivityInfo.AreaTask.ToList<ConditionTask>());
		this.UpdateHonamiStoryAreaDataList(honamiStoryActivityInfo.HonamiStoryAreaInfos.ToList<HonamiStoryAreaInfo>());
		this.UpdateHonamiStoryMascotDataList(honamiStoryActivityInfo.HonamiStoryMascotInfos.ToList<HonamiStoryMascotInfo>());
		this.UpdatePermanentTaskDataList(honamiStoryActivityInfo.HonamiStoryResidentTask.ToList<ConditionTask>());
		this.UpdateLimitTaskDataList(honamiStoryActivityInfo.HonamiStoryLimitTask.ToList<ConditionTask>());
		this.UpdateScoreRewardDataList(honamiStoryActivityInfo.HonamiStoryScoreRewardInfos.ToList<HonamiStoryScoreRewardInfo>());
		this.UpdateItemCollectionDataList(honamiStoryActivityInfo.HonamiStoryItemCollectionInfos.ToList<HonamiStoryItemCollectionInfo>());
		this.RefreshTowerData(honamiStoryActivityInfo.HonamiStoryTopInfos.ToList<HonamiStoryTopInfo>());
		this.InitLevelSelectPanelData();
	}

	// Token: 0x0600E91A RID: 59674 RVA: 0x003F3628 File Offset: 0x003F1828
	protected override void PhraseEx(ActivityData data)
	{
		HonamiStoryActivityInfo honamiStoryActivityInfo = data.HonamiStoryActivityInfo;
		if (honamiStoryActivityInfo == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.BB, "HonamiStoryActivityDataPhrase 无效activityInfo", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		ModelBase<HonamiStoryModel>.Instance.UpdateActivityInfo(base.Id, honamiStoryActivityInfo);
		this.UpdateHonamiStoryAreaDataList(honamiStoryActivityInfo.HonamiStoryAreaInfos.ToList<HonamiStoryAreaInfo>());
		this.UpdateHonamiStoryMascotDataList(honamiStoryActivityInfo.HonamiStoryMascotInfos.ToList<HonamiStoryMascotInfo>());
		this.UpdatePermanentTaskDataList(honamiStoryActivityInfo.HonamiStoryResidentTask.ToList<ConditionTask>());
		this.UpdateLimitTaskDataList(honamiStoryActivityInfo.HonamiStoryLimitTask.ToList<ConditionTask>());
		this.UpdateScoreRewardDataList(honamiStoryActivityInfo.HonamiStoryScoreRewardInfos.ToList<HonamiStoryScoreRewardInfo>());
		this.UpdateItemCollectionDataList(honamiStoryActivityInfo.HonamiStoryItemCollectionInfos.ToList<HonamiStoryItemCollectionInfo>());
		this.UpdateSubQuestTaskDataList(honamiStoryActivityInfo.AreaTask.ToList<ConditionTask>());
		this.RefreshTowerData(honamiStoryActivityInfo.HonamiStoryTopInfos.ToList<HonamiStoryTopInfo>());
		ModelBase<HonamiStoryModel>.Instance.SetTotalRevenueInternal(honamiStoryActivityInfo.TotalRevenue);
	}

	// Token: 0x0600E91B RID: 59675 RVA: 0x003F3708 File Offset: 0x003F1908
	protected override bool GetExDataFinishShowState()
	{
		using (Dictionary<int, HonamiStoryPermanentTaskData>.ValueCollection.Enumerator enumerator = this.PermanentTaskDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status != EActivityTaskState.FinishedAndClaimed)
				{
					return false;
				}
			}
		}
		using (List<HonamiStoryMascotData>.Enumerator enumerator2 = this.MascotDataList.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				if (enumerator2.Current.State != EHonamiStoryCollectState.GotReward)
				{
					return false;
				}
			}
		}
		using (List<HonamiStoryAreaData>.Enumerator enumerator3 = this.GetHonamiStoryMascotAreaDataList().GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				if (enumerator3.Current.CollectMascotState != EHonamiStoryCollectState.GotReward)
				{
					return false;
				}
			}
		}
		using (Dictionary<int, HonamiStoryItemCollectionData>.ValueCollection.Enumerator enumerator4 = this.ItemCollectionDataMap.Values.GetEnumerator())
		{
			while (enumerator4.MoveNext())
			{
				if (enumerator4.Current.State != EHonamiStoryCollectState.GotReward)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0600E91C RID: 59676 RVA: 0x003F3848 File Offset: 0x003F1A48
	public override bool GetExDataRedPointShowState()
	{
		return this.CheckAllFunctionRedDot();
	}

	// Token: 0x0600E91D RID: 59677 RVA: 0x003F3850 File Offset: 0x003F1A50
	public bool CheckAllFunctionRedDot()
	{
		if (!base.IsUnLock())
		{
			return false;
		}
		bool flag = this.IsLimitTaskHasRedDot() || this.IsPermanentTaskHasRedDot();
		if (flag)
		{
			return flag;
		}
		FunctionModel instance = ModelBase<FunctionModel>.Instance;
		if (instance != null && instance.IsOpen(10116))
		{
			flag = (this.CanMascotCollectGetReward() || this.CanAreaCollectGetReward());
			if (flag)
			{
				return flag;
			}
		}
		FunctionModel instance2 = ModelBase<FunctionModel>.Instance;
		if (instance2 != null && instance2.IsOpen(10123))
		{
			flag = (LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.HonamiStoryWeaponUnlockSet, new HashSet<int>()).Count > 0);
			if (flag)
			{
				return flag;
			}
		}
		if (ModelBase<FunctionModel>.Instance.IsOpen(10118))
		{
			flag = this.IsItemCollectionHasRedDot();
			if (flag)
			{
				return flag;
			}
		}
		return false;
	}

	// Token: 0x0600E91E RID: 59678 RVA: 0x003F3900 File Offset: 0x003F1B00
	private void InitHonamiStoryAreaData()
	{
		foreach (HonamiStoryArea honamiStoryArea in ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryAreaConfigList(base.Id))
		{
			HonamiStoryAreaData honamiStoryAreaData = new HonamiStoryAreaData(honamiStoryArea.Id);
			this.AreaDataMap[honamiStoryArea.Id] = honamiStoryAreaData;
			this.AreaDataList.Add(honamiStoryAreaData);
		}
	}

	// Token: 0x0600E91F RID: 59679 RVA: 0x003F397C File Offset: 0x003F1B7C
	public void UpdateHonamiStoryAreaDataList(List<HonamiStoryAreaInfo> areaInfoList)
	{
		foreach (HonamiStoryAreaInfo areaInfo in areaInfoList)
		{
			this.UpdateHonamiStoryAreaData(areaInfo);
		}
	}

	// Token: 0x0600E920 RID: 59680 RVA: 0x003F39CC File Offset: 0x003F1BCC
	public void UpdateHonamiStoryAreaData(HonamiStoryAreaInfo areaInfo)
	{
		HonamiStoryAreaData honamiStoryAreaData = this.GetHonamiStoryAreaData(areaInfo.HonamiStoryAreaId);
		if (honamiStoryAreaData == null)
		{
			return;
		}
		honamiStoryAreaData.UpdateData(areaInfo);
	}

	// Token: 0x0600E921 RID: 59681 RVA: 0x003F39F4 File Offset: 0x003F1BF4
	[NullableContext(2)]
	public HonamiStoryAreaData GetHonamiStoryAreaData(int id)
	{
		HonamiStoryAreaData result;
		if (this.AreaDataMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.HonamiStory;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "HonamiStoryAreaData 无效Id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600E922 RID: 59682 RVA: 0x003F3A44 File Offset: 0x003F1C44
	public List<HonamiStoryAreaData> GetHonamiStoryAreaDataList()
	{
		if (this.AreaDataList.Count == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.HonamiStory, ELogAuthor.LRC, "HonamiStoryAreaDataList为空", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		return this.AreaDataList;
	}

	// Token: 0x0600E923 RID: 59683 RVA: 0x003F3A84 File Offset: 0x003F1C84
	public List<HonamiStoryAreaData> GetHonamiStoryMascotAreaDataList()
	{
		List<HonamiStoryAreaData> list = new List<HonamiStoryAreaData>();
		foreach (HonamiStoryAreaData honamiStoryAreaData in this.AreaDataList)
		{
			if (honamiStoryAreaData.Id != 1 && this.GetHonamiStoryMascotDataListByAreaId(honamiStoryAreaData.Id).Count != 0)
			{
				list.Add(honamiStoryAreaData);
			}
		}
		return list;
	}

	// Token: 0x0600E924 RID: 59684 RVA: 0x003F3AFC File Offset: 0x003F1CFC
	public int GetCurrentProgressAreaDataId()
	{
		List<HonamiStoryAreaData> honamiStoryAreaDataList = this.GetHonamiStoryAreaDataList();
		if (honamiStoryAreaDataList.Count <= 0)
		{
			return 1;
		}
		foreach (HonamiStoryAreaData honamiStoryAreaData in honamiStoryAreaDataList)
		{
			if (honamiStoryAreaData.GetAreaState != EHonamiStoryAreaState.Finished)
			{
				return honamiStoryAreaData.Id;
			}
		}
		return honamiStoryAreaDataList[honamiStoryAreaDataList.Count - 1].Id;
	}

	// Token: 0x0600E925 RID: 59685 RVA: 0x003F3B7C File Offset: 0x003F1D7C
	public bool IsAllAreaPass()
	{
		List<HonamiStoryAreaData> honamiStoryAreaDataList = this.GetHonamiStoryAreaDataList();
		int count = honamiStoryAreaDataList.Count;
		int num = 0;
		using (List<HonamiStoryAreaData>.Enumerator enumerator = honamiStoryAreaDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetAreaState != EHonamiStoryAreaState.Finished)
				{
					break;
				}
				num++;
			}
		}
		return count > 0 && num == count;
	}

	// Token: 0x0600E926 RID: 59686 RVA: 0x003F3BE8 File Offset: 0x003F1DE8
	public bool CanAreaCollectGetReward()
	{
		foreach (HonamiStoryAreaData honamiStoryAreaData in this.AreaDataList)
		{
			if (honamiStoryAreaData.IsAreaUnlock && honamiStoryAreaData.IsSecretFinished)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600E927 RID: 59687 RVA: 0x003F3C4C File Offset: 0x003F1E4C
	public void RefreshTowerData(List<HonamiStoryTopInfo> towerInfoList)
	{
		foreach (HonamiStoryTopInfo honamiStoryTopInfo in towerInfoList)
		{
			this.TowerDangerLv2MaxFloorMap[honamiStoryTopInfo.DangerLevel] = honamiStoryTopInfo.MaxFloor;
		}
	}

	// Token: 0x0600E928 RID: 59688 RVA: 0x003F3CAC File Offset: 0x003F1EAC
	public int GetMaxFloorByDangerLv(int lv)
	{
		int result;
		if (this.TowerDangerLv2MaxFloorMap.TryGetValue(lv, out result))
		{
			return result;
		}
		return 0;
	}

	// Token: 0x0600E929 RID: 59689 RVA: 0x003F3CCC File Offset: 0x003F1ECC
	private void InitHonamiStoryMascotData()
	{
		foreach (HonamiStoryMascot honamiStoryMascot in ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryMascotConfigList(base.Id))
		{
			HonamiStoryMascotData honamiStoryMascotData = new HonamiStoryMascotData(honamiStoryMascot.Id);
			this.MascotDataMap[honamiStoryMascot.Id] = honamiStoryMascotData;
			this.MascotDataList.Add(honamiStoryMascotData);
		}
	}

	// Token: 0x0600E92A RID: 59690 RVA: 0x003F3D48 File Offset: 0x003F1F48
	public void UpdateHonamiStoryMascotDataList(List<HonamiStoryMascotInfo> mascotInfoList)
	{
		foreach (HonamiStoryMascotInfo mascotInfo in mascotInfoList)
		{
			this.UpdateHonamiStoryMascotData(mascotInfo);
		}
	}

	// Token: 0x0600E92B RID: 59691 RVA: 0x003F3D98 File Offset: 0x003F1F98
	public void UpdateHonamiStoryMascotData(HonamiStoryMascotInfo mascotInfo)
	{
		HonamiStoryMascotData honamiStoryMascotData = this.GetHonamiStoryMascotData(mascotInfo.HonamiStoryMascotId);
		if (honamiStoryMascotData == null)
		{
			return;
		}
		honamiStoryMascotData.UpdateState((EHonamiStoryCollectState)mascotInfo.Status);
	}

	// Token: 0x0600E92C RID: 59692 RVA: 0x003F3DC4 File Offset: 0x003F1FC4
	[NullableContext(2)]
	public HonamiStoryMascotData GetHonamiStoryMascotData(int id)
	{
		HonamiStoryMascotData result;
		if (this.MascotDataMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.HonamiStory;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "HonamiStoryMascotData 无效Id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600E92D RID: 59693 RVA: 0x003F3E14 File Offset: 0x003F2014
	public List<HonamiStoryMascotData> GetHonamiStoryMascotDataListByAreaId(int areaId)
	{
		List<HonamiStoryMascotData> list = new List<HonamiStoryMascotData>();
		foreach (HonamiStoryMascotData honamiStoryMascotData in this.MascotDataList)
		{
			if (honamiStoryMascotData.AreaId == areaId)
			{
				list.Add(honamiStoryMascotData);
			}
		}
		return list;
	}

	// Token: 0x0600E92E RID: 59694 RVA: 0x003F3E78 File Offset: 0x003F2078
	public bool CanMascotCollectGetReward()
	{
		using (List<HonamiStoryMascotData>.Enumerator enumerator = this.MascotDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.State == EHonamiStoryCollectState.Finished)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600E92F RID: 59695 RVA: 0x003F3ED4 File Offset: 0x003F20D4
	public bool CheckMascotCollectFinished()
	{
		using (List<HonamiStoryMascotData>.Enumerator enumerator = this.MascotDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.State == EHonamiStoryCollectState.Unfinished)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0600E930 RID: 59696 RVA: 0x003F3F30 File Offset: 0x003F2130
	private void InitHonamiStoryPermanentTaskData()
	{
		foreach (HonamiStoryResidentTask honamiStoryResidentTask in ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryPermanentTaskConfigList(base.Id))
		{
			HonamiStoryPermanentTaskData value = new HonamiStoryPermanentTaskData(honamiStoryResidentTask.Id);
			this.PermanentTaskDataMap[honamiStoryResidentTask.Id] = value;
		}
	}

	// Token: 0x0600E931 RID: 59697 RVA: 0x003F3FA0 File Offset: 0x003F21A0
	public void UpdatePermanentTaskDataList(List<ConditionTask> taskInfoList)
	{
		foreach (ConditionTask taskInfo in taskInfoList)
		{
			this.UpdatePermanentTaskData(taskInfo);
		}
	}

	// Token: 0x0600E932 RID: 59698 RVA: 0x003F3FF0 File Offset: 0x003F21F0
	public void UpdatePermanentTaskData(ConditionTask taskInfo)
	{
		HonamiStoryPermanentTaskData permanentTaskData = this.GetPermanentTaskData(taskInfo.Id);
		if (permanentTaskData == null)
		{
			return;
		}
		permanentTaskData.UpdateData(taskInfo);
	}

	// Token: 0x0600E933 RID: 59699 RVA: 0x003F4018 File Offset: 0x003F2218
	[NullableContext(2)]
	public HonamiStoryPermanentTaskData GetPermanentTaskData(int id)
	{
		HonamiStoryPermanentTaskData result;
		if (this.PermanentTaskDataMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.HonamiStory;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "HonamiStoryPermanentTaskData 无效Id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600E934 RID: 59700 RVA: 0x003F4068 File Offset: 0x003F2268
	public List<HonamiStoryPermanentTaskData> GetPermanentTaskDataList()
	{
		List<HonamiStoryPermanentTaskData> list = new List<HonamiStoryPermanentTaskData>();
		foreach (KeyValuePair<int, HonamiStoryPermanentTaskData> keyValuePair in this.PermanentTaskDataMap)
		{
			list.Add(keyValuePair.Value);
		}
		list.Sort(delegate(HonamiStoryPermanentTaskData a, HonamiStoryPermanentTaskData b)
		{
			if (a.Status != b.Status)
			{
				return a.Status.CompareTo(b.Status);
			}
			return a.Id.CompareTo(b.Id);
		});
		return list;
	}

	// Token: 0x0600E935 RID: 59701 RVA: 0x003F40F0 File Offset: 0x003F22F0
	public List<int> GetPermanentTaskIdsByState(EActivityTaskState state)
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, HonamiStoryPermanentTaskData> keyValuePair in this.PermanentTaskDataMap)
		{
			if (keyValuePair.Value.Status == state)
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list;
	}

	// Token: 0x0600E936 RID: 59702 RVA: 0x003F4160 File Offset: 0x003F2360
	public int GetPermanentTaskTotalNum()
	{
		return this.PermanentTaskDataMap.Count;
	}

	// Token: 0x0600E937 RID: 59703 RVA: 0x003F4170 File Offset: 0x003F2370
	public bool IsPermanentTaskHasRedDot()
	{
		using (Dictionary<int, HonamiStoryPermanentTaskData>.ValueCollection.Enumerator enumerator = this.PermanentTaskDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == EActivityTaskState.FinishedAndUnclaimed)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600E938 RID: 59704 RVA: 0x003F41D0 File Offset: 0x003F23D0
	private void InitHonamiStoryLimitTaskData()
	{
		foreach (HonamiStoryLimitTask honamiStoryLimitTask in ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryLimitTaskConfigList(base.Id))
		{
			HonamiStoryLimitTaskData value = new HonamiStoryLimitTaskData(honamiStoryLimitTask.Id);
			this.LimitTaskDataMap[honamiStoryLimitTask.Id] = value;
		}
	}

	// Token: 0x0600E939 RID: 59705 RVA: 0x003F4240 File Offset: 0x003F2440
	public void UpdateLimitTaskDataList(List<ConditionTask> limitTaskInfoList)
	{
		foreach (ConditionTask limitTaskInfo in limitTaskInfoList)
		{
			this.UpdateLimitTaskData(limitTaskInfo);
		}
	}

	// Token: 0x0600E93A RID: 59706 RVA: 0x003F4290 File Offset: 0x003F2490
	public void UpdateLimitTaskData(ConditionTask limitTaskInfo)
	{
		HonamiStoryLimitTaskData limitTaskData = this.GetLimitTaskData(limitTaskInfo.Id);
		if (limitTaskData == null)
		{
			return;
		}
		limitTaskData.UpdateData(limitTaskInfo);
	}

	// Token: 0x0600E93B RID: 59707 RVA: 0x003F42B8 File Offset: 0x003F24B8
	[NullableContext(2)]
	public HonamiStoryLimitTaskData GetLimitTaskData(int id)
	{
		HonamiStoryLimitTaskData result;
		if (this.LimitTaskDataMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.HonamiStory;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "HonamiStoryLimitTaskData 无效Id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600E93C RID: 59708 RVA: 0x003F4308 File Offset: 0x003F2508
	public List<HonamiStoryLimitTaskData> GetLimitTaskDataList()
	{
		List<HonamiStoryLimitTaskData> list = new List<HonamiStoryLimitTaskData>();
		foreach (KeyValuePair<int, HonamiStoryLimitTaskData> keyValuePair in this.LimitTaskDataMap)
		{
			list.Add(keyValuePair.Value);
		}
		list.Sort(delegate(HonamiStoryLimitTaskData a, HonamiStoryLimitTaskData b)
		{
			if (a.Status != b.Status)
			{
				return a.Status.CompareTo(b.Status);
			}
			return a.Id.CompareTo(b.Id);
		});
		return list;
	}

	// Token: 0x0600E93D RID: 59709 RVA: 0x003F4390 File Offset: 0x003F2590
	public List<int> GetFinishedLimitTaskIds()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, HonamiStoryLimitTaskData> keyValuePair in this.LimitTaskDataMap)
		{
			if (keyValuePair.Value.Status == EActivityTaskState.FinishedAndUnclaimed)
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list;
	}

	// Token: 0x0600E93E RID: 59710 RVA: 0x003F4400 File Offset: 0x003F2600
	public bool IsLimitTaskHasRedDot()
	{
		using (Dictionary<int, HonamiStoryLimitTaskData>.ValueCollection.Enumerator enumerator = this.LimitTaskDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == EActivityTaskState.FinishedAndUnclaimed)
				{
					return true;
				}
			}
		}
		using (Dictionary<int, HonamiStoryScoreRewardData>.ValueCollection.Enumerator enumerator2 = this.ScoreRewardDataMap.Values.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				if (enumerator2.Current.State == EHonamiStoryCollectState.Finished)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600E93F RID: 59711 RVA: 0x003F44AC File Offset: 0x003F26AC
	private void InitHonamiStoryScoreRewardData()
	{
		foreach (HonamiStoryScoreReward honamiStoryScoreReward in ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryScoreRewardConfigList(base.Id))
		{
			HonamiStoryScoreRewardData value = new HonamiStoryScoreRewardData(honamiStoryScoreReward.Id);
			this.ScoreRewardDataMap[honamiStoryScoreReward.Id] = value;
		}
	}

	// Token: 0x0600E940 RID: 59712 RVA: 0x003F451C File Offset: 0x003F271C
	public void UpdateScoreRewardDataList(List<HonamiStoryScoreRewardInfo> infoList)
	{
		foreach (HonamiStoryScoreRewardInfo info in infoList)
		{
			this.UpdateScoreRewardData(info);
		}
	}

	// Token: 0x0600E941 RID: 59713 RVA: 0x003F456C File Offset: 0x003F276C
	public void UpdateScoreRewardData(HonamiStoryScoreRewardInfo info)
	{
		HonamiStoryScoreRewardData honamiStoryScoreRewardData;
		if (this.ScoreRewardDataMap.TryGetValue(info.ScoreRewardId, out honamiStoryScoreRewardData))
		{
			honamiStoryScoreRewardData.UpdateState((EHonamiStoryCollectState)info.Status);
		}
	}

	// Token: 0x0600E942 RID: 59714 RVA: 0x003F459C File Offset: 0x003F279C
	[NullableContext(2)]
	public HonamiStoryScoreRewardData GetScoreRewardData(int scoreRewardId)
	{
		HonamiStoryScoreRewardData result;
		if (this.ScoreRewardDataMap.TryGetValue(scoreRewardId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600E943 RID: 59715 RVA: 0x003F45BC File Offset: 0x003F27BC
	public List<HonamiStoryScoreRewardData> GetScoreRewardDataList()
	{
		List<HonamiStoryScoreRewardData> list = new List<HonamiStoryScoreRewardData>();
		foreach (KeyValuePair<int, HonamiStoryScoreRewardData> keyValuePair in this.ScoreRewardDataMap)
		{
			list.Add(keyValuePair.Value);
		}
		return list;
	}

	// Token: 0x0600E944 RID: 59716 RVA: 0x003F461C File Offset: 0x003F281C
	public List<int> GetFinishedScoreRewardIds()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, HonamiStoryScoreRewardData> keyValuePair in this.ScoreRewardDataMap)
		{
			if (keyValuePair.Value.State == EHonamiStoryCollectState.Finished)
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list;
	}

	// Token: 0x0600E945 RID: 59717 RVA: 0x003F468C File Offset: 0x003F288C
	public int GetCurrentScore()
	{
		return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.Config.Value.ScoreItemId, 0);
	}

	// Token: 0x0600E946 RID: 59718 RVA: 0x003F46BC File Offset: 0x003F28BC
	public int GetMaxScore()
	{
		int num = 0;
		foreach (HonamiStoryScoreReward honamiStoryScoreReward in ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryScoreRewardConfigList(base.Id))
		{
			if (num < honamiStoryScoreReward.Score)
			{
				num = honamiStoryScoreReward.Score;
			}
		}
		return num;
	}

	// Token: 0x0600E947 RID: 59719 RVA: 0x003F4724 File Offset: 0x003F2924
	public void InitSubQuestTaskDataList(IReadOnlyList<ConditionTask> subQuestInfoList)
	{
		this.SubQuestDataMap.Clear();
		this.SubTaskDataList.Clear();
		foreach (ConditionTask conditionTask in subQuestInfoList)
		{
			HonamiStorySubQuestData honamiStorySubQuestData = new HonamiStorySubQuestData(conditionTask.Id);
			this.SubQuestDataMap[conditionTask.Id] = honamiStorySubQuestData;
			this.SubTaskDataList.Add(honamiStorySubQuestData);
			honamiStorySubQuestData.UpdateData(conditionTask);
		}
	}

	// Token: 0x0600E948 RID: 59720 RVA: 0x003F47AC File Offset: 0x003F29AC
	public void UpdateSubQuestTaskDataList(List<ConditionTask> subQuestInfoList)
	{
		foreach (ConditionTask subQuestInfo in subQuestInfoList)
		{
			this.UpdateSubQuestTaskData(subQuestInfo);
		}
	}

	// Token: 0x0600E949 RID: 59721 RVA: 0x003F47FC File Offset: 0x003F29FC
	public void UpdateSubQuestTaskData(ConditionTask subQuestInfo)
	{
		HonamiStorySubQuestData subQuestTaskData = this.GetSubQuestTaskData(subQuestInfo.Id);
		if (subQuestTaskData == null)
		{
			return;
		}
		subQuestTaskData.UpdateData(subQuestInfo);
	}

	// Token: 0x0600E94A RID: 59722 RVA: 0x003F4824 File Offset: 0x003F2A24
	[NullableContext(2)]
	public HonamiStorySubQuestData GetSubQuestTaskData(int id)
	{
		HonamiStorySubQuestData result;
		if (this.SubQuestDataMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.HonamiStory;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "HonamiStoryAreaTaskData 无效Id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600E94B RID: 59723 RVA: 0x003F4873 File Offset: 0x003F2A73
	public List<HonamiStorySubQuestData> GetSubQuestTaskDataList()
	{
		return this.SubTaskDataList;
	}

	// Token: 0x0600E94C RID: 59724 RVA: 0x003F487C File Offset: 0x003F2A7C
	private void InitItemCollectionData()
	{
		foreach (HonamiStoryItemCollection config in ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryItemCollectionConfigList(base.Id))
		{
			HonamiStoryItemCollectionData value = new HonamiStoryItemCollectionData(config);
			this.ItemCollectionDataMap[config.ItemId] = value;
		}
	}

	// Token: 0x0600E94D RID: 59725 RVA: 0x003F48E8 File Offset: 0x003F2AE8
	public void UpdateItemCollectionDataList(List<HonamiStoryItemCollectionInfo> itemCollectionInfoList)
	{
		foreach (HonamiStoryItemCollectionInfo honamiStoryItemCollectionInfo in itemCollectionInfoList)
		{
			HonamiStoryItemCollectionData itemCollectionData = this.GetItemCollectionData(honamiStoryItemCollectionInfo.HonamiStoryItemId);
			if (itemCollectionData != null)
			{
				itemCollectionData.UpdateData(honamiStoryItemCollectionInfo);
			}
		}
	}

	// Token: 0x0600E94E RID: 59726 RVA: 0x003F4948 File Offset: 0x003F2B48
	[NullableContext(2)]
	public HonamiStoryItemCollectionData GetItemCollectionData(int id)
	{
		HonamiStoryItemCollectionData result;
		if (this.ItemCollectionDataMap.TryGetValue(id, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.HonamiStory;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "HonamiStoryItemCollectionData 无效Id";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x0600E94F RID: 59727 RVA: 0x003F4998 File Offset: 0x003F2B98
	public List<HonamiStoryItemCollectionData> GetItemCollectionDataList()
	{
		List<HonamiStoryItemCollectionData> list = new List<HonamiStoryItemCollectionData>();
		foreach (KeyValuePair<int, HonamiStoryItemCollectionData> keyValuePair in this.ItemCollectionDataMap)
		{
			list.Add(keyValuePair.Value);
		}
		return list;
	}

	// Token: 0x0600E950 RID: 59728 RVA: 0x003F49F8 File Offset: 0x003F2BF8
	public bool IsItemCollectionHasRedDot()
	{
		using (Dictionary<int, HonamiStoryItemCollectionData>.ValueCollection.Enumerator enumerator = this.ItemCollectionDataMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.State == EHonamiStoryCollectState.Finished)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600E951 RID: 59729 RVA: 0x003F4A58 File Offset: 0x003F2C58
	private void InitLevelSelectPanelData()
	{
		HonamiStoryActivity? config = this.Config;
		this.CurHonamiLv = ((config != null) ? config.GetValueOrDefault().OriAreaDangerLevel : 0);
		config = this.Config;
		this.CurTowerLv = ((config != null) ? config.GetValueOrDefault().OriTopTowerDangerLevel : 0);
	}

	// Token: 0x0600E952 RID: 59730 RVA: 0x003F4AB8 File Offset: 0x003F2CB8
	public bool IsLevelSelectHasViewRedDot()
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10121))
		{
			int currentProgressAreaDataId = this.GetCurrentProgressAreaDataId();
			int count = this.GetHonamiStoryAreaDataList().Count;
			HonamiStoryAreaData honamiStoryAreaData = this.GetHonamiStoryAreaData(currentProgressAreaDataId);
			return currentProgressAreaDataId <= count && honamiStoryAreaData != null && honamiStoryAreaData.IsAreaCanEnter;
		}
		return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.HonamiStorySelectLvTowerUnLockTogRedDot, false);
	}

	// Token: 0x170011D9 RID: 4569
	// (get) Token: 0x0600E953 RID: 59731 RVA: 0x003F4B0F File Offset: 0x003F2D0F
	private HonamiStoryActivity? Config
	{
		get
		{
			return ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryActivityConfig(base.Id);
		}
	}

	// Token: 0x170011DA RID: 4570
	// (get) Token: 0x0600E954 RID: 59732 RVA: 0x003F4B24 File Offset: 0x003F2D24
	public int HelpId
	{
		get
		{
			return this.Config.Value.HelpId;
		}
	}

	// Token: 0x170011DB RID: 4571
	// (get) Token: 0x0600E955 RID: 59733 RVA: 0x003F4B48 File Offset: 0x003F2D48
	public int MarkId
	{
		get
		{
			return this.Config.Value.MarkId;
		}
	}

	// Token: 0x170011DC RID: 4572
	// (get) Token: 0x0600E956 RID: 59734 RVA: 0x003F4B6C File Offset: 0x003F2D6C
	public int ShopId
	{
		get
		{
			return this.Config.Value.ShopId;
		}
	}

	// Token: 0x170011DD RID: 4573
	// (get) Token: 0x0600E957 RID: 59735 RVA: 0x003F4B90 File Offset: 0x003F2D90
	public int GetActHelpId
	{
		get
		{
			return this.Config.Value.HelpId;
		}
	}

	// Token: 0x170011DE RID: 4574
	// (get) Token: 0x0600E958 RID: 59736 RVA: 0x003F4BB4 File Offset: 0x003F2DB4
	public int ActivityQuestId
	{
		get
		{
			return this.Config.Value.MainQuestId;
		}
	}

	// Token: 0x170011DF RID: 4575
	// (get) Token: 0x0600E959 RID: 59737 RVA: 0x003F4BD8 File Offset: 0x003F2DD8
	public int AreaInstId
	{
		get
		{
			return this.Config.Value.AreaInstId;
		}
	}

	// Token: 0x170011E0 RID: 4576
	// (get) Token: 0x0600E95A RID: 59738 RVA: 0x003F4BFC File Offset: 0x003F2DFC
	public int OutCoinItemId
	{
		get
		{
			return this.Config.Value.OutCoinItemId;
		}
	}

	// Token: 0x170011E1 RID: 4577
	// (get) Token: 0x0600E95B RID: 59739 RVA: 0x003F4C20 File Offset: 0x003F2E20
	public string TowerName
	{
		get
		{
			return this.Config.Value.TowerName;
		}
	}

	// Token: 0x0400708D RID: 28813
	private readonly Dictionary<int, HonamiStoryAreaData> AreaDataMap = new Dictionary<int, HonamiStoryAreaData>();

	// Token: 0x0400708E RID: 28814
	private readonly List<HonamiStoryAreaData> AreaDataList = new List<HonamiStoryAreaData>();

	// Token: 0x0400708F RID: 28815
	private readonly Dictionary<int, int> TowerDangerLv2MaxFloorMap = new Dictionary<int, int>();

	// Token: 0x04007090 RID: 28816
	private readonly Dictionary<int, HonamiStoryMascotData> MascotDataMap = new Dictionary<int, HonamiStoryMascotData>();

	// Token: 0x04007091 RID: 28817
	private readonly List<HonamiStoryMascotData> MascotDataList = new List<HonamiStoryMascotData>();

	// Token: 0x04007092 RID: 28818
	private readonly Dictionary<int, HonamiStoryPermanentTaskData> PermanentTaskDataMap = new Dictionary<int, HonamiStoryPermanentTaskData>();

	// Token: 0x04007093 RID: 28819
	private readonly Dictionary<int, HonamiStoryLimitTaskData> LimitTaskDataMap = new Dictionary<int, HonamiStoryLimitTaskData>();

	// Token: 0x04007094 RID: 28820
	private readonly Dictionary<int, HonamiStoryScoreRewardData> ScoreRewardDataMap = new Dictionary<int, HonamiStoryScoreRewardData>();

	// Token: 0x04007095 RID: 28821
	private readonly Dictionary<int, HonamiStorySubQuestData> SubQuestDataMap = new Dictionary<int, HonamiStorySubQuestData>();

	// Token: 0x04007096 RID: 28822
	private readonly List<HonamiStorySubQuestData> SubTaskDataList = new List<HonamiStorySubQuestData>();

	// Token: 0x04007097 RID: 28823
	private readonly Dictionary<int, HonamiStoryItemCollectionData> ItemCollectionDataMap = new Dictionary<int, HonamiStoryItemCollectionData>();

	// Token: 0x04007098 RID: 28824
	public int CurTarget;

	// Token: 0x04007099 RID: 28825
	public int CurHonamiLv;

	// Token: 0x0400709A RID: 28826
	public int CurTowerLv;
}
