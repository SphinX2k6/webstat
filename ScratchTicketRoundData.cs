using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x020015A1 RID: 5537
[NullableContext(1)]
[Nullable(0)]
public class ScratchTicketRoundData
{
	// Token: 0x06009BCF RID: 39887 RVA: 0x0028C3F4 File Offset: 0x0028A5F4
	public void Init(ScratchCardRoundInfo roundInfo)
	{
		this.Id = roundInfo.RoundId;
		this.Config = ConfigBase<ActivityScratchTicketConfig>.Instance.GetScratchTicketRoundConfig(this.Id);
		if (this.Config == null)
		{
			return;
		}
		this.Capacity = this.Config.Value.Size * this.Config.Value.Size;
		this.UnlockTime = roundInfo.UnlockTime;
		this.InitCellDataList();
		this.InitRewardSortMap();
		this.UpdateCellDataReward(roundInfo.RewardIds.ToDictionary<int, ScratchCardRewardData>());
		this.UpdateRemainReward(roundInfo.LeftRewardItem.ToDictionary<int, int>());
	}

	// Token: 0x06009BD0 RID: 39888 RVA: 0x0028C498 File Offset: 0x0028A698
	private void InitCellDataList()
	{
		this.CellDataList.Clear();
		for (int i = 0; i < this.Capacity; i++)
		{
			ScratchTicketCellData item = new ScratchTicketCellData(i);
			this.CellDataList.Add(item);
		}
	}

	// Token: 0x06009BD1 RID: 39889 RVA: 0x0028C4D4 File Offset: 0x0028A6D4
	private void InitRewardSortMap()
	{
		this.RewardSortMap.Clear();
		for (int i = 0; i < this.Config.Value.RewardSortList().Length; i++)
		{
			int key = this.Config.Value.RewardSortList()[i];
			this.RewardSortMap[key] = i;
		}
	}

	// Token: 0x06009BD2 RID: 39890 RVA: 0x0028C530 File Offset: 0x0028A730
	public void UpdateCellDataReward(Dictionary<int, ScratchCardRewardData> rewardMap)
	{
		foreach (KeyValuePair<int, ScratchCardRewardData> keyValuePair in rewardMap)
		{
			int key = keyValuePair.Key;
			if (key >= 0 && key < this.CellDataList.Count)
			{
				this.CellDataList[key].SetRewardItem(keyValuePair.Value);
				this.RewardCount++;
			}
		}
	}

	// Token: 0x06009BD3 RID: 39891 RVA: 0x0028C5B8 File Offset: 0x0028A7B8
	public void UpdateRemainReward(Dictionary<int, int> rewardList)
	{
		this.RemainRewardList.Clear();
		foreach (KeyValuePair<int, int> keyValuePair in rewardList)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value);
			this.RemainRewardList.Add(item);
		}
		this.RemainRewardList.Sort(delegate(TItem a, TItem b)
		{
			int num2;
			int num = this.RewardSortMap.TryGetValue(a.ItemData.ItemId, out num2) ? num2 : int.MaxValue;
			int num4;
			int num3 = this.RewardSortMap.TryGetValue(b.ItemData.ItemId, out num4) ? num4 : int.MaxValue;
			return num - num3;
		});
	}

	// Token: 0x06009BD4 RID: 39892 RVA: 0x0028C650 File Offset: 0x0028A850
	public void UpdateRoundState(EScratchTicketRoundState preState)
	{
		if (Singleton<TimeUtil>.Instance.GetServerTimeStamp() <= (double)this.UnlockTime || preState != EScratchTicketRoundState.Finish)
		{
			this.RoundState = EScratchTicketRoundState.Lock;
			return;
		}
		if (this.RewardCount >= this.Config.Value.Size * this.Config.Value.Size)
		{
			this.RoundState = EScratchTicketRoundState.Finish;
			return;
		}
		this.RoundState = EScratchTicketRoundState.InProgress;
	}

	// Token: 0x06009BD5 RID: 39893 RVA: 0x0028C6BA File Offset: 0x0028A8BA
	public long GetUnlockTime()
	{
		return this.UnlockTime;
	}

	// Token: 0x06009BD6 RID: 39894 RVA: 0x0028C6C4 File Offset: 0x0028A8C4
	public EScratchTicketRoundState GetPreRoundState()
	{
		ScratchTicketRoundData scratchRoundData = ModelBase<ActivityScratchTicketModel>.Instance.GetScratchRoundData(this.Config.Value.PreRoundId);
		if (scratchRoundData == null)
		{
			return EScratchTicketRoundState.Finish;
		}
		return scratchRoundData.GetRoundState();
	}

	// Token: 0x06009BD7 RID: 39895 RVA: 0x0028C6FA File Offset: 0x0028A8FA
	public EScratchTicketRoundState GetRoundState()
	{
		return this.RoundState;
	}

	// Token: 0x06009BD8 RID: 39896 RVA: 0x0028C702 File Offset: 0x0028A902
	public List<ScratchTicketCellData> GetCellDataList()
	{
		return this.CellDataList;
	}

	// Token: 0x06009BD9 RID: 39897 RVA: 0x0028C70A File Offset: 0x0028A90A
	public List<TItem> GetRemainRewardList()
	{
		return this.RemainRewardList;
	}

	// Token: 0x06009BDA RID: 39898 RVA: 0x0028C714 File Offset: 0x0028A914
	public List<RewardItemData> GetRewardDataList(Dictionary<int, int> itemMap)
	{
		List<RewardItemData> list = new List<RewardItemData>();
		foreach (KeyValuePair<int, int> keyValuePair in itemMap)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			RewardItemData item = new RewardItemData(key, value, null, EDropItemType.Normal);
			list.Add(item);
		}
		list.Sort(delegate(RewardItemData a, RewardItemData b)
		{
			int num2;
			int num = this.RewardSortMap.TryGetValue(a.ConfigId, out num2) ? num2 : int.MaxValue;
			int num4;
			int num3 = this.RewardSortMap.TryGetValue(b.ConfigId, out num4) ? num4 : int.MaxValue;
			return num - num3;
		});
		return list;
	}

	// Token: 0x06009BDB RID: 39899 RVA: 0x0028C7A0 File Offset: 0x0028A9A0
	public List<ScratchTicketRoundResult> GetRewardResultList(int index, EScratchTicketRewardType rewardType)
	{
		if (!this.CheckIndexValid(index, true))
		{
			return new List<ScratchTicketRoundResult>();
		}
		switch (rewardType)
		{
		case EScratchTicketRewardType.Center:
			return this.GetRewardCenterResult(index, 700f, "HamsterA");
		case EScratchTicketRewardType.Cross:
			return this.GetRewardCrossResult(index);
		case EScratchTicketRewardType.Column:
			return this.GetRewardColumnResult(index);
		case EScratchTicketRewardType.Row:
			return this.GetRewardRowResult(index);
		case EScratchTicketRewardType.NineGridCell:
			return this.GetRewardNineGridCellResult(index);
		case EScratchTicketRewardType.ColumnAndRow:
			return this.GetRewardRowAndColumnResult(index);
		case EScratchTicketRewardType.AllGrid:
			return this.GetRemainingRewardResult(index);
		default:
			return new List<ScratchTicketRoundResult>();
		}
	}

	// Token: 0x06009BDC RID: 39900 RVA: 0x0028C828 File Offset: 0x0028AA28
	private List<ScratchTicketRoundResult> GetRewardCenterResult(int index, float delayInterval, string sequenceName)
	{
		List<ScratchTicketRoundResult> list = new List<ScratchTicketRoundResult>();
		if (!this.CheckIndexValid(index, true))
		{
			return list;
		}
		ScratchTicketRewardResult rewardResultData = this.GetRewardResultData(index, EScratchDirectionType.Center, true);
		ScratchTicketRoundResult roundResultData = this.GetRoundResultData(new List<ScratchTicketRewardResult>
		{
			rewardResultData
		}, delayInterval, sequenceName);
		list.Add(roundResultData);
		return list;
	}

	// Token: 0x06009BDD RID: 39901 RVA: 0x0028C870 File Offset: 0x0028AA70
	private List<ScratchTicketRoundResult> GetRewardCrossResult(int index)
	{
		List<ScratchTicketRoundResult> rewardCenterResult = this.GetRewardCenterResult(index, 700f, "HamsterB");
		this.PushRewardCrossRoundResult(rewardCenterResult, index, false);
		this.PushSequenceRoundResult(rewardCenterResult, 250, "InnerGlow");
		this.PushRewardCrossRoundResult(rewardCenterResult, index, true);
		return rewardCenterResult;
	}

	// Token: 0x06009BDE RID: 39902 RVA: 0x0028C8B4 File Offset: 0x0028AAB4
	private void PushRewardCrossRoundResult(List<ScratchTicketRoundResult> result, int index, bool checkLock)
	{
		List<ScratchTicketRewardResult> list = new List<ScratchTicketRewardResult>();
		this.PushRewardResult(list, index, EScratchDirectionType.Left, checkLock);
		this.PushRewardResult(list, index, EScratchDirectionType.Right, checkLock);
		this.PushRewardResult(list, index, EScratchDirectionType.Top, checkLock);
		this.PushRewardResult(list, index, EScratchDirectionType.Bottom, checkLock);
		if (list.Count <= 0)
		{
			return;
		}
		int delayInterval = this.GetDelayInterval(false, !checkLock);
		ScratchTicketRoundResult roundResultData = this.GetRoundResultData(list, delayInterval);
		result.Add(roundResultData);
	}

	// Token: 0x06009BDF RID: 39903 RVA: 0x0028C918 File Offset: 0x0028AB18
	private List<ScratchTicketRoundResult> GetRewardNineGridCellResult(int index)
	{
		List<ScratchTicketRoundResult> rewardCenterResult = this.GetRewardCenterResult(index, 700f, "HamsterB");
		this.PushRewardNineGridCellRoundResult(rewardCenterResult, index, false);
		this.PushSequenceRoundResult(rewardCenterResult, 250, "InnerGlow");
		this.PushRewardNineGridCellRoundResult(rewardCenterResult, index, true);
		return rewardCenterResult;
	}

	// Token: 0x06009BE0 RID: 39904 RVA: 0x0028C95C File Offset: 0x0028AB5C
	private void PushRewardNineGridCellRoundResult(List<ScratchTicketRoundResult> result, int index, bool checkLock)
	{
		List<ScratchTicketRewardResult> list = new List<ScratchTicketRewardResult>();
		this.PushRewardResult(list, index, EScratchDirectionType.Left, checkLock);
		this.PushRewardResult(list, index, EScratchDirectionType.Right, checkLock);
		this.PushRewardResult(list, index, EScratchDirectionType.Top, checkLock);
		this.PushRewardResult(list, index, EScratchDirectionType.Bottom, checkLock);
		this.PushRewardResult(list, index, EScratchDirectionType.LeftTop, checkLock);
		this.PushRewardResult(list, index, EScratchDirectionType.LeftBottom, checkLock);
		this.PushRewardResult(list, index, EScratchDirectionType.RightTop, checkLock);
		this.PushRewardResult(list, index, EScratchDirectionType.RightBottom, checkLock);
		if (list.Count <= 0)
		{
			return;
		}
		int delayInterval = this.GetDelayInterval(false, !checkLock);
		ScratchTicketRoundResult roundResultData = this.GetRoundResultData(list, delayInterval);
		result.Add(roundResultData);
	}

	// Token: 0x06009BE1 RID: 39905 RVA: 0x0028C9E8 File Offset: 0x0028ABE8
	private List<ScratchTicketRoundResult> GetRewardRowResult(int index)
	{
		List<ScratchTicketRoundResult> rewardCenterResult = this.GetRewardCenterResult(index, 700f, "HamsterB");
		this.PushRewardRowRoundResult(rewardCenterResult, index, false);
		this.PushSequenceRoundResult(rewardCenterResult, 250, "InnerGlow");
		this.PushRewardRowRoundResult(rewardCenterResult, index, true);
		return rewardCenterResult;
	}

	// Token: 0x06009BE2 RID: 39906 RVA: 0x0028CA2C File Offset: 0x0028AC2C
	private void PushRewardRowRoundResult(List<ScratchTicketRoundResult> result, int index, bool checkLock)
	{
		List<ScratchTicketRewardResult> list = new List<ScratchTicketRewardResult>();
		this.PushDirectionFirstReward(list, index, EScratchDirectionType.Left, checkLock);
		this.PushDirectionFirstReward(list, index, EScratchDirectionType.Right, checkLock);
		this.PushRewardResultAlongDirection(result, list, checkLock);
	}

	// Token: 0x06009BE3 RID: 39907 RVA: 0x0028CA5C File Offset: 0x0028AC5C
	private List<ScratchTicketRoundResult> GetRewardColumnResult(int index)
	{
		List<ScratchTicketRoundResult> rewardCenterResult = this.GetRewardCenterResult(index, 700f, "HamsterB");
		this.PushRewardColumnRoundResult(rewardCenterResult, index, false);
		this.PushSequenceRoundResult(rewardCenterResult, 250, "InnerGlow");
		this.PushRewardColumnRoundResult(rewardCenterResult, index, true);
		return rewardCenterResult;
	}

	// Token: 0x06009BE4 RID: 39908 RVA: 0x0028CAA0 File Offset: 0x0028ACA0
	private void PushRewardColumnRoundResult(List<ScratchTicketRoundResult> result, int index, bool checkLock)
	{
		List<ScratchTicketRewardResult> list = new List<ScratchTicketRewardResult>();
		this.PushDirectionFirstReward(list, index, EScratchDirectionType.Top, checkLock);
		this.PushDirectionFirstReward(list, index, EScratchDirectionType.Bottom, checkLock);
		this.PushRewardResultAlongDirection(result, list, checkLock);
	}

	// Token: 0x06009BE5 RID: 39909 RVA: 0x0028CAD0 File Offset: 0x0028ACD0
	private List<ScratchTicketRoundResult> GetRewardRowAndColumnResult(int index)
	{
		List<ScratchTicketRoundResult> rewardCenterResult = this.GetRewardCenterResult(index, 700f, "HamsterB");
		this.PushRewardRowAndColumnRoundResult(rewardCenterResult, index, false);
		this.PushSequenceRoundResult(rewardCenterResult, 250, "InnerGlow");
		this.PushRewardRowAndColumnRoundResult(rewardCenterResult, index, true);
		return rewardCenterResult;
	}

	// Token: 0x06009BE6 RID: 39910 RVA: 0x0028CB14 File Offset: 0x0028AD14
	private void PushRewardRowAndColumnRoundResult(List<ScratchTicketRoundResult> result, int index, bool checkLock)
	{
		List<ScratchTicketRewardResult> list = new List<ScratchTicketRewardResult>();
		this.PushDirectionFirstReward(list, index, EScratchDirectionType.Top, checkLock);
		this.PushDirectionFirstReward(list, index, EScratchDirectionType.Bottom, checkLock);
		this.PushDirectionFirstReward(list, index, EScratchDirectionType.Left, checkLock);
		this.PushDirectionFirstReward(list, index, EScratchDirectionType.Right, checkLock);
		this.PushRewardResultAlongDirection(result, list, checkLock);
	}

	// Token: 0x06009BE7 RID: 39911 RVA: 0x0028CB58 File Offset: 0x0028AD58
	private List<ScratchTicketRoundResult> GetRemainingRewardResult(int index)
	{
		List<ScratchTicketRoundResult> rewardCenterResult = this.GetRewardCenterResult(index, 1000f, "HamsterC");
		this.PushRewardRemainingRoundResult(rewardCenterResult, false);
		this.PushSequenceRoundResult(rewardCenterResult, 250, "InnerGlow");
		this.PushRewardRemainingRoundResult(rewardCenterResult, true);
		return rewardCenterResult;
	}

	// Token: 0x06009BE8 RID: 39912 RVA: 0x0028CB9C File Offset: 0x0028AD9C
	private void PushRewardRemainingRoundResult(List<ScratchTicketRoundResult> result, bool checkLock)
	{
		List<ScratchTicketRewardResult> list = new List<ScratchTicketRewardResult>();
		foreach (ScratchTicketCellData scratchTicketCellData in this.GetCellDataList())
		{
			if (!checkLock || scratchTicketCellData.IsLock())
			{
				ScratchTicketRewardResult rewardResultData = this.GetRewardResultData(scratchTicketCellData.Index, EScratchDirectionType.Center, true);
				list.Add(rewardResultData);
			}
		}
		if (list.Count > 0)
		{
			int delayInterval = this.GetDelayInterval(false, !checkLock);
			ScratchTicketRoundResult roundResultData = this.GetRoundResultData(list, delayInterval);
			result.Add(roundResultData);
		}
	}

	// Token: 0x06009BE9 RID: 39913 RVA: 0x0028CC38 File Offset: 0x0028AE38
	private void PushRewardResultAlongDirection(List<ScratchTicketRoundResult> result, List<ScratchTicketRewardResult> rewardResultList, bool checkLock)
	{
		List<ScratchTicketRewardResult> list = new List<ScratchTicketRewardResult>(rewardResultList);
		int delayInterval = this.GetDelayInterval(false, !checkLock);
		while (list.Count > 0)
		{
			ScratchTicketRoundResult roundResultData = this.GetRoundResultData(list, delayInterval);
			result.Add(roundResultData);
			List<ScratchTicketRewardResult> list2 = new List<ScratchTicketRewardResult>();
			foreach (ScratchTicketRewardResult scratchTicketRewardResult in list)
			{
				this.PushDirectionFirstReward(list2, scratchTicketRewardResult.Index, scratchTicketRewardResult.DirectionType, checkLock);
			}
			list = list2;
		}
	}

	// Token: 0x06009BEA RID: 39914 RVA: 0x0028CCD0 File Offset: 0x0028AED0
	private void PushDirectionFirstReward(List<ScratchTicketRewardResult> roundResult, int index, EScratchDirectionType direction, bool checkLock)
	{
		int num = index;
		for (;;)
		{
			num = this.GetCellDataIndexByDirection(num, direction);
			ScratchTicketCellData cellDataByIndex = this.GetCellDataByIndex(num);
			if (cellDataByIndex != null && (!checkLock || cellDataByIndex.IsLock()))
			{
				break;
			}
			if (num < 0)
			{
				return;
			}
		}
		ScratchTicketRewardResult rewardResultData = this.GetRewardResultData(num, direction, checkLock);
		roundResult.Add(rewardResultData);
	}

	// Token: 0x06009BEB RID: 39915 RVA: 0x0028CD18 File Offset: 0x0028AF18
	private void PushRewardResult(List<ScratchTicketRewardResult> roundResult, int index, EScratchDirectionType direction, bool checkLock)
	{
		int cellDataIndexByDirection = this.GetCellDataIndexByDirection(index, direction);
		ScratchTicketCellData cellDataByIndex = this.GetCellDataByIndex(cellDataIndexByDirection);
		if (cellDataByIndex == null)
		{
			return;
		}
		if (checkLock && !cellDataByIndex.IsLock())
		{
			return;
		}
		ScratchTicketRewardResult rewardResultData = this.GetRewardResultData(cellDataIndexByDirection, direction, checkLock);
		roundResult.Add(rewardResultData);
	}

	// Token: 0x06009BEC RID: 39916 RVA: 0x0028CD5C File Offset: 0x0028AF5C
	private void PushSequenceRoundResult(List<ScratchTicketRoundResult> result, int delayInterval, string sequenceName)
	{
		ScratchTicketRoundResult roundResultData = this.GetRoundResultData(new List<ScratchTicketRewardResult>(), (float)delayInterval, sequenceName);
		result.Add(roundResultData);
	}

	// Token: 0x06009BED RID: 39917 RVA: 0x0028CD80 File Offset: 0x0028AF80
	public List<ScratchTicketRoundResult> GetDiagonalResultList()
	{
		if (this.DiagonalResultList != null)
		{
			return this.DiagonalResultList;
		}
		this.DiagonalResultList = new List<ScratchTicketRoundResult>();
		int size = this.Config.Value.Size;
		for (int i = 0; i < size * 2; i++)
		{
			this.PushDiagonalRoundResult(this.DiagonalResultList, i);
		}
		return this.DiagonalResultList;
	}

	// Token: 0x06009BEE RID: 39918 RVA: 0x0028CDDC File Offset: 0x0028AFDC
	private void PushDiagonalRoundResult(List<ScratchTicketRoundResult> result, int roundIndex)
	{
		List<ScratchTicketRewardResult> list = new List<ScratchTicketRewardResult>();
		for (int i = 0; i <= roundIndex; i++)
		{
			int column = roundIndex - i;
			int cellDataIndex = this.GetCellDataIndex(i, column);
			if (cellDataIndex >= 0)
			{
				ScratchTicketRewardResult item = new ScratchTicketRewardResult
				{
					Index = cellDataIndex,
					DirectionType = EScratchDirectionType.Center,
					SequenceType = ECellSequenceType.Reveal
				};
				list.Add(item);
			}
		}
		ScratchTicketRoundResult roundResultData = this.GetRoundResultData(list, 30);
		result.Add(roundResultData);
	}

	// Token: 0x06009BEF RID: 39919 RVA: 0x0028CE44 File Offset: 0x0028B044
	private bool CheckIndexValid(int index, bool needLog = true)
	{
		return index >= 0 && index < this.Capacity;
	}

	// Token: 0x06009BF0 RID: 39920 RVA: 0x0028CE55 File Offset: 0x0028B055
	private ScratchTicketRoundResult GetRoundResultData(List<ScratchTicketRewardResult> rewardList, int delayInterval)
	{
		return this.GetRoundResultData(rewardList, (float)delayInterval, "Empty");
	}

	// Token: 0x06009BF1 RID: 39921 RVA: 0x0028CE65 File Offset: 0x0028B065
	private ScratchTicketRoundResult GetRoundResultData(List<ScratchTicketRewardResult> rewardList, float delayInterval, string sequenceName)
	{
		return new ScratchTicketRoundResult
		{
			RewardList = rewardList,
			DelayInterval = delayInterval,
			SequenceName = sequenceName
		};
	}

	// Token: 0x06009BF2 RID: 39922 RVA: 0x0028CE84 File Offset: 0x0028B084
	private ScratchTicketRewardResult GetRewardResultData(int index, EScratchDirectionType directionType, bool checkLock)
	{
		ECellSequenceType sequenceType = ECellSequenceType.Warning;
		if (checkLock)
		{
			ActivityScratchTicketDefine.DirectionToSequenceMap.TryGetValue(directionType, out sequenceType);
		}
		return new ScratchTicketRewardResult
		{
			Index = index,
			DirectionType = directionType,
			SequenceType = sequenceType
		};
	}

	// Token: 0x06009BF3 RID: 39923 RVA: 0x0028CEBE File Offset: 0x0028B0BE
	private int GetDelayInterval(bool isFirst, bool isWaring)
	{
		if (isFirst)
		{
			return 700;
		}
		if (isWaring)
		{
			return 50;
		}
		return 100;
	}

	// Token: 0x06009BF4 RID: 39924 RVA: 0x0028CED1 File Offset: 0x0028B0D1
	public ScratchTicketCellData GetCellDataByIndex(int index)
	{
		if (!this.CheckIndexValid(index, true))
		{
			return null;
		}
		return this.CellDataList[index];
	}

	// Token: 0x06009BF5 RID: 39925 RVA: 0x0028CEEC File Offset: 0x0028B0EC
	private int GetCellDataIndex(int row, int column)
	{
		int size = this.Config.Value.Size;
		if (column < 0 || column >= size || row < 0 || row >= size)
		{
			return -1;
		}
		return row * size + column;
	}

	// Token: 0x06009BF6 RID: 39926 RVA: 0x0028CF24 File Offset: 0x0028B124
	private int GetCellDataIndexByDirection(int index, EScratchDirectionType directionType)
	{
		int size = this.Config.Value.Size;
		int num = index % size;
		int num2 = index / size;
		switch (directionType)
		{
		case EScratchDirectionType.Left:
			num--;
			break;
		case EScratchDirectionType.Right:
			num++;
			break;
		case EScratchDirectionType.Top:
			num2--;
			break;
		case EScratchDirectionType.Bottom:
			num2++;
			break;
		case EScratchDirectionType.LeftTop:
			num2--;
			num--;
			break;
		case EScratchDirectionType.LeftBottom:
			num2++;
			num--;
			break;
		case EScratchDirectionType.RightTop:
			num2--;
			num++;
			break;
		case EScratchDirectionType.RightBottom:
			num2++;
			num++;
			break;
		}
		return this.GetCellDataIndex(num2, num);
	}

	// Token: 0x040047C3 RID: 18371
	public int Id;

	// Token: 0x040047C4 RID: 18372
	private long UnlockTime;

	// Token: 0x040047C5 RID: 18373
	public ScratchCardRoundRe? Config;

	// Token: 0x040047C6 RID: 18374
	private List<ScratchTicketCellData> CellDataList = new List<ScratchTicketCellData>();

	// Token: 0x040047C7 RID: 18375
	private int RewardCount;

	// Token: 0x040047C8 RID: 18376
	private List<TItem> RemainRewardList = new List<TItem>();

	// Token: 0x040047C9 RID: 18377
	private EScratchTicketRoundState RoundState;

	// Token: 0x040047CA RID: 18378
	private readonly Dictionary<int, int> RewardSortMap = new Dictionary<int, int>();

	// Token: 0x040047CB RID: 18379
	private int Capacity;

	// Token: 0x040047CC RID: 18380
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ScratchTicketRoundResult> DiagonalResultList;
}
