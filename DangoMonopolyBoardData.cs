using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x020012DB RID: 4827
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyBoardData
{
	// Token: 0x060082B5 RID: 33461 RVA: 0x00229747 File Offset: 0x00227947
	public static DangoMonopolyBoardData Create(DangoMonopolyBoard config, int index)
	{
		DangoMonopolyBoardData dangoMonopolyBoardData = new DangoMonopolyBoardData(config.BoardId, index);
		dangoMonopolyBoardData.Init(config);
		return dangoMonopolyBoardData;
	}

	// Token: 0x060082B6 RID: 33462 RVA: 0x00229760 File Offset: 0x00227960
	private DangoMonopolyBoardData(int id, int index)
	{
		this.Id = id;
		this.Index = index;
	}

	// Token: 0x060082B7 RID: 33463 RVA: 0x002297C4 File Offset: 0x002279C4
	private void Init(DangoMonopolyBoard config)
	{
		this.RewardItemId = config.ItemId;
		this.RewardItemCount = config.ItemNum;
		this.GroupId = config.BoardGroupId;
		this.FinishTitle = config.FinishTitle;
		this.FinishDesc = config.FinishDesc;
		DangoMonopolyGrid[] gridList = ConfigBase<ActivityDangoMonopolyConfig>.Instance.GetGridList(config.GridGroupId);
		for (int i = 0; i < gridList.Length; i++)
		{
			DangoMonopolyGrid config2 = gridList[i];
			DangoMonopolyGridData dangoMonopolyGridData = DangoMonopolyGridData.Create(config2, i, this);
			this.GridList.Add(dangoMonopolyGridData);
			this.GridMap.Add(config2.GridId, dangoMonopolyGridData);
		}
	}

	// Token: 0x060082B8 RID: 33464 RVA: 0x00229862 File Offset: 0x00227A62
	public void SetActivityData(ActivityDangoMonopolyData data)
	{
		this.ActivityData = data;
	}

	// Token: 0x060082B9 RID: 33465 RVA: 0x0022986B File Offset: 0x00227A6B
	public void SetRewarded(bool isRewarded)
	{
		this.IsRewarded = isRewarded;
	}

	// Token: 0x060082BA RID: 33466 RVA: 0x00229874 File Offset: 0x00227A74
	public bool IsFinish()
	{
		ActivityDangoMonopolyData activityData = this.ActivityData;
		DangoMonopolyBoardData dangoMonopolyBoardData = (activityData != null) ? activityData.CurrentBoardData : null;
		if (dangoMonopolyBoardData != null && dangoMonopolyBoardData.IsGreaterIndex(this.Index))
		{
			return true;
		}
		if (dangoMonopolyBoardData != null && dangoMonopolyBoardData.IsEqualIndex(this.Index))
		{
			DangoMonopolyGridData currentGridData = this.GetCurrentGridData();
			if (currentGridData == null || !currentGridData.IsLessIndex(this.GridList.Count - 1))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060082BB RID: 33467 RVA: 0x002298DC File Offset: 0x00227ADC
	public bool IsRunning()
	{
		ActivityDangoMonopolyData activityData = this.ActivityData;
		DangoMonopolyBoardData dangoMonopolyBoardData = (activityData != null) ? activityData.CurrentBoardData : null;
		return dangoMonopolyBoardData != null && dangoMonopolyBoardData.IsEqualIndex(this.Index);
	}

	// Token: 0x060082BC RID: 33468 RVA: 0x0022990D File Offset: 0x00227B0D
	[NullableContext(2)]
	public DangoMonopolyGridData GetCurrentGridData()
	{
		if (!this.IsRunning())
		{
			return null;
		}
		ActivityDangoMonopolyData activityData = this.ActivityData;
		if (activityData == null)
		{
			return null;
		}
		return activityData.RunningGridData;
	}

	// Token: 0x060082BD RID: 33469 RVA: 0x0022992A File Offset: 0x00227B2A
	public bool IsGreaterIndex(int index)
	{
		return this.Index > index;
	}

	// Token: 0x060082BE RID: 33470 RVA: 0x00229935 File Offset: 0x00227B35
	public bool IsEqualIndex(int index)
	{
		return this.Index == index;
	}

	// Token: 0x060082BF RID: 33471 RVA: 0x00229940 File Offset: 0x00227B40
	public bool IsLessIndex(int index)
	{
		return this.Index < index;
	}

	// Token: 0x060082C0 RID: 33472 RVA: 0x0022994B File Offset: 0x00227B4B
	public bool IsCanReceiveReward()
	{
		return !this.IsRewarded && this.IsFinish();
	}

	// Token: 0x060082C1 RID: 33473 RVA: 0x00229964 File Offset: 0x00227B64
	public List<IDangoMonopolyRoundBuffData> GetDangoBuffShowList()
	{
		List<IDangoMonopolyRoundBuffData> list = new List<IDangoMonopolyRoundBuffData>();
		int finishGridNum = this.GetFinishGridNum();
		foreach (DangoMonopolyGridData dangoMonopolyGridData in this.GridList)
		{
			DangoData dangoData = dangoMonopolyGridData.GetDangoData();
			if (dangoData != null)
			{
				int id = dangoData.Id;
				DangoMonopolyProperty? addPropertyConfig = dangoMonopolyGridData.GetAddPropertyConfig();
				DangoMonopolyRoundBuffData dangoMonopolyRoundBuffData = new DangoMonopolyRoundBuffData();
				dangoMonopolyRoundBuffData.DangoId = id;
				dangoMonopolyRoundBuffData.PropertyId = ((addPropertyConfig != null) ? addPropertyConfig.GetValueOrDefault().Id : 0);
				dangoMonopolyRoundBuffData.GridId = dangoMonopolyGridData.Id;
				dangoMonopolyRoundBuffData.IsActive = (finishGridNum >= dangoMonopolyGridData.GetPosition());
				dangoMonopolyRoundBuffData.DangoIcon = dangoData.Icon;
				dangoMonopolyRoundBuffData.DangoName = dangoData.NameKey;
				string propertyDesc;
				if ((propertyDesc = ((addPropertyConfig != null) ? addPropertyConfig.GetValueOrDefault().Desc : null)) == null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
					defaultInterpolatedStringHandler.AppendLiteral("not property, gridId: ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(dangoMonopolyGridData.Id);
					propertyDesc = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				dangoMonopolyRoundBuffData.PropertyDesc = propertyDesc;
				string propertyTitle;
				if ((propertyTitle = ((addPropertyConfig != null) ? addPropertyConfig.GetValueOrDefault().Title : null)) == null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
					defaultInterpolatedStringHandler.AppendLiteral("not property, gridId: ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(dangoMonopolyGridData.Id);
					propertyTitle = defaultInterpolatedStringHandler.ToStringAndClear();
				}
				dangoMonopolyRoundBuffData.PropertyTitle = propertyTitle;
				DangoMonopolyRoundBuffData item = dangoMonopolyRoundBuffData;
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x060082C2 RID: 33474 RVA: 0x00229B04 File Offset: 0x00227D04
	public List<RewardItemData> GetAllGridRewardItemList()
	{
		List<IDangoMonopolyItemShowData> list = new List<IDangoMonopolyItemShowData>();
		foreach (DangoMonopolyGridData dangoMonopolyGridData in this.GridList)
		{
			if (dangoMonopolyGridData.IsExistItem())
			{
				DangoMonopolyItemShowData item = new DangoMonopolyItemShowData
				{
					Id = dangoMonopolyGridData.ItemId,
					Num = dangoMonopolyGridData.ItemCount,
					IsDouble = dangoMonopolyGridData.IsActiveDouble(),
					UniqueId = 0
				};
				list.Add(item);
			}
		}
		ActivityDangoMonopolyData activityData = this.ActivityData;
		return ((activityData != null) ? activityData.GetItemShowList(list) : null) ?? new List<RewardItemData>();
	}

	// Token: 0x060082C3 RID: 33475 RVA: 0x00229BB4 File Offset: 0x00227DB4
	public int GetPosition()
	{
		return this.Index + 1;
	}

	// Token: 0x060082C4 RID: 33476 RVA: 0x00229BC0 File Offset: 0x00227DC0
	public int GetFinishGridNum()
	{
		if (this.IsFinish())
		{
			return this.GridList.Count;
		}
		DangoMonopolyGridData currentGridData = this.GetCurrentGridData();
		if (currentGridData == null)
		{
			return 0;
		}
		return currentGridData.GetPosition();
	}

	// Token: 0x060082C5 RID: 33477 RVA: 0x00229BF4 File Offset: 0x00227DF4
	public int InitStartMoveDango(int step)
	{
		if (!this.IsRunning())
		{
			return 0;
		}
		DangoMonopolyGridData currentGridData = this.GetCurrentGridData();
		if (currentGridData == null)
		{
			DangoMonopolyGridData dangoMonopolyGridData = (step < this.GridList.Count) ? this.GridList[step] : this.GridList[this.GridList.Count - 1];
			ActivityDangoMonopolyData activityData = this.ActivityData;
			if (activityData != null)
			{
				activityData.UpdateTargetGrid((dangoMonopolyGridData != null) ? dangoMonopolyGridData.Id : 0);
			}
			if (dangoMonopolyGridData == null)
			{
				return 0;
			}
			return dangoMonopolyGridData.GetPosition();
		}
		else
		{
			int index = currentGridData.Index;
			int num = Math.Min(index + step, this.GridList.Count - 1);
			int result = num - index;
			DangoMonopolyGridData dangoMonopolyGridData2 = this.GridList[num];
			ActivityDangoMonopolyData activityData2 = this.ActivityData;
			if (activityData2 == null)
			{
				return result;
			}
			activityData2.UpdateTargetGrid(dangoMonopolyGridData2.Id);
			return result;
		}
	}

	// Token: 0x060082C6 RID: 33478 RVA: 0x00229CBC File Offset: 0x00227EBC
	public bool MoveDangoOneStep()
	{
		if (!this.IsRunning())
		{
			return false;
		}
		ActivityDangoMonopolyData activityData = this.ActivityData;
		int? num;
		if (activityData == null)
		{
			num = null;
		}
		else
		{
			DangoMonopolyGridData runningGridData = activityData.RunningGridData;
			num = ((runningGridData != null) ? new int?(runningGridData.Id) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		ActivityDangoMonopolyData activityData2 = this.ActivityData;
		int? num3;
		if (activityData2 == null)
		{
			num3 = null;
		}
		else
		{
			DangoMonopolyGridData targetGridData = activityData2.TargetGridData;
			num3 = ((targetGridData != null) ? new int?(targetGridData.Id) : null);
		}
		num2 = num3;
		int valueOrDefault2 = num2.GetValueOrDefault();
		int id = Math.Min(valueOrDefault + 1, valueOrDefault2);
		ActivityDangoMonopolyData activityData3 = this.ActivityData;
		if (activityData3 != null)
		{
			activityData3.UpdateRunningGrid(id);
		}
		return true;
	}

	// Token: 0x060082C7 RID: 33479 RVA: 0x00229D68 File Offset: 0x00227F68
	public bool IsMoveToTarget()
	{
		ActivityDangoMonopolyData activityData = this.ActivityData;
		int? num;
		if (activityData == null)
		{
			num = null;
		}
		else
		{
			DangoMonopolyGridData runningGridData = activityData.RunningGridData;
			num = ((runningGridData != null) ? new int?(runningGridData.Id) : null);
		}
		int? num2 = num;
		int valueOrDefault = num2.GetValueOrDefault();
		ActivityDangoMonopolyData activityData2 = this.ActivityData;
		int? num3;
		if (activityData2 == null)
		{
			num3 = null;
		}
		else
		{
			DangoMonopolyGridData targetGridData = activityData2.TargetGridData;
			num3 = ((targetGridData != null) ? new int?(targetGridData.Id) : null);
		}
		num2 = num3;
		int valueOrDefault2 = num2.GetValueOrDefault();
		return valueOrDefault == valueOrDefault2;
	}

	// Token: 0x060082C8 RID: 33480 RVA: 0x00229DEF File Offset: 0x00227FEF
	public int GetEndGridId()
	{
		if (this.GridList.Count <= 0)
		{
			return 0;
		}
		return this.GridList[this.GridList.Count - 1].Id;
	}

	// Token: 0x060082C9 RID: 33481 RVA: 0x00229E1E File Offset: 0x0022801E
	public int GetStartGridId()
	{
		if (this.GridList.Count <= 0)
		{
			return 0;
		}
		return this.GridList[0].Id;
	}

	// Token: 0x060082CA RID: 33482 RVA: 0x00229E44 File Offset: 0x00228044
	[NullableContext(2)]
	public DangoMonopolyGridData GetFirstDoubleGrid()
	{
		foreach (DangoMonopolyGridData dangoMonopolyGridData in this.GridList)
		{
			if (dangoMonopolyGridData.PropertyIsDouble())
			{
				return dangoMonopolyGridData;
			}
		}
		return null;
	}

	// Token: 0x060082CB RID: 33483 RVA: 0x00229EA0 File Offset: 0x002280A0
	public bool IsLock()
	{
		return this.GetUnlockRemainTime() > 0.0;
	}

	// Token: 0x060082CC RID: 33484 RVA: 0x00229EB3 File Offset: 0x002280B3
	public double GetUnlockRemainTime()
	{
		if (this.UnlockTime <= 0L)
		{
			return 0.0;
		}
		return Math.Max(0.0, (double)this.UnlockTime - Singleton<TimeUtil>.Instance.GetServerTime());
	}

	// Token: 0x060082CD RID: 33485 RVA: 0x00229EE9 File Offset: 0x002280E9
	public void UpdateUnlockTime(long time)
	{
		this.UnlockTime = time;
	}

	// Token: 0x060082CE RID: 33486 RVA: 0x00229EF2 File Offset: 0x002280F2
	public void UpdateRollDiceTimes(int num)
	{
		this.RecordRollDiceTimes = num;
	}

	// Token: 0x060082CF RID: 33487 RVA: 0x00229EFB File Offset: 0x002280FB
	public void AddRollDiceTimes()
	{
		this.RecordRollDiceTimes++;
	}

	// Token: 0x060082D0 RID: 33488 RVA: 0x00229F0B File Offset: 0x0022810B
	public void UpdateRecordTriggerBuff(int id, int times)
	{
		this.RecordTriggerBuffMap[id] = times;
	}

	// Token: 0x060082D1 RID: 33489 RVA: 0x00229F1C File Offset: 0x0022811C
	public void AddRecordTriggerBuff(int id)
	{
		if (id <= 0)
		{
			return;
		}
		int num;
		if (!this.RecordTriggerBuffMap.TryGetValue(id, out num))
		{
			num = 0;
		}
		this.RecordTriggerBuffMap[id] = num + 1;
	}

	// Token: 0x060082D2 RID: 33490 RVA: 0x00229F4F File Offset: 0x0022814F
	public void ClearRecordTriggerBuff()
	{
		this.RecordTriggerBuffMap.Clear();
	}

	// Token: 0x060082D3 RID: 33491 RVA: 0x00229F5C File Offset: 0x0022815C
	public int GetRecordTriggerBuffTotalTimes()
	{
		int num = 0;
		foreach (KeyValuePair<int, int> keyValuePair in this.RecordTriggerBuffMap)
		{
			ActivityDangoMonopolyData activityData = this.ActivityData;
			if (activityData == null || !activityData.BuffIsImplicit(keyValuePair.Key))
			{
				num += keyValuePair.Value;
			}
		}
		return num;
	}

	// Token: 0x060082D4 RID: 33492 RVA: 0x00229FD4 File Offset: 0x002281D4
	public void UpdateOwnedBuffIdList(int id)
	{
		this.OwnedBuffIdList.Add(id);
	}

	// Token: 0x060082D5 RID: 33493 RVA: 0x00229FE2 File Offset: 0x002281E2
	public void ClearOwnedBuffIdList()
	{
		this.OwnedBuffIdList.Clear();
	}

	// Token: 0x060082D6 RID: 33494 RVA: 0x00229FF0 File Offset: 0x002281F0
	public List<DangoMonopolyGridData> GetGridListDango()
	{
		List<DangoMonopolyGridData> list = new List<DangoMonopolyGridData>();
		foreach (DangoMonopolyGridData dangoMonopolyGridData in this.GridList)
		{
			if (dangoMonopolyGridData.IsExistDango())
			{
				list.Add(dangoMonopolyGridData);
			}
		}
		return list;
	}

	// Token: 0x060082D7 RID: 33495 RVA: 0x0022A054 File Offset: 0x00228254
	public int GetDangoIdByBuffId(int buffId)
	{
		foreach (DangoMonopolyGridData dangoMonopolyGridData in this.GetGridListDango())
		{
			if (dangoMonopolyGridData.AddPropertyId == buffId)
			{
				return dangoMonopolyGridData.DangoId;
			}
		}
		ActivityDangoMonopolyData activityData = this.ActivityData;
		int? num;
		if (activityData == null)
		{
			num = null;
		}
		else
		{
			DangoData dango = activityData.Dango;
			num = ((dango != null) ? new int?(dango.Id) : null);
		}
		int? num2 = num;
		return num2.GetValueOrDefault();
	}

	// Token: 0x060082D8 RID: 33496 RVA: 0x0022A0F0 File Offset: 0x002282F0
	public void LogInfo()
	{
		List<DangoMonopolyGridData> gridListDango = this.GetGridListDango();
		List<int[]> list = new List<int[]>();
		foreach (DangoMonopolyGridData dangoMonopolyGridData in gridListDango)
		{
			list.Add(new int[]
			{
				dangoMonopolyGridData.Id,
				dangoMonopolyGridData.DangoId
			});
		}
		List<DangoMonopolyGridData> list2 = new List<DangoMonopolyGridData>();
		foreach (DangoMonopolyGridData dangoMonopolyGridData2 in this.GridList)
		{
			if (dangoMonopolyGridData2.GetFireBuffId() > 0)
			{
				list2.Add(dangoMonopolyGridData2);
			}
		}
		List<int[]> list3 = new List<int[]>();
		foreach (DangoMonopolyGridData dangoMonopolyGridData3 in list2)
		{
			list3.Add(new int[]
			{
				dangoMonopolyGridData3.Id,
				dangoMonopolyGridData3.GetFireBuffId()
			});
		}
	}

	// Token: 0x04003E05 RID: 15877
	public int Id;

	// Token: 0x04003E06 RID: 15878
	public int GroupId;

	// Token: 0x04003E07 RID: 15879
	public int Index;

	// Token: 0x04003E08 RID: 15880
	public bool IsRewarded;

	// Token: 0x04003E09 RID: 15881
	public int RewardItemId;

	// Token: 0x04003E0A RID: 15882
	public int RewardItemCount;

	// Token: 0x04003E0B RID: 15883
	public string FinishTitle = "";

	// Token: 0x04003E0C RID: 15884
	public string FinishDesc = "";

	// Token: 0x04003E0D RID: 15885
	public readonly List<DangoMonopolyGridData> GridList = new List<DangoMonopolyGridData>();

	// Token: 0x04003E0E RID: 15886
	public readonly Dictionary<int, DangoMonopolyGridData> GridMap = new Dictionary<int, DangoMonopolyGridData>();

	// Token: 0x04003E0F RID: 15887
	[Nullable(2)]
	public ActivityDangoMonopolyData ActivityData;

	// Token: 0x04003E10 RID: 15888
	public long UnlockTime;

	// Token: 0x04003E11 RID: 15889
	public int RecordRollDiceTimes;

	// Token: 0x04003E12 RID: 15890
	public readonly Dictionary<int, int> RecordTriggerBuffMap = new Dictionary<int, int>();

	// Token: 0x04003E13 RID: 15891
	public readonly List<int> OwnedBuffIdList = new List<int>();
}
