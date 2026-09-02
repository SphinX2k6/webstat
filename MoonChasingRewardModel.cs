using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PayShop;

// Token: 0x0200140C RID: 5132
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MoonChasingRewardModel : ModelBase<MoonChasingRewardModel>
{
	// Token: 0x06008E35 RID: 36405 RVA: 0x00255BA0 File Offset: 0x00253DA0
	private void AddDataType(RewardTargetData rewardTargetData)
	{
		Aki.Config.TrackMoonTarget rewardTargetById = ConfigBase<MoonChasingRewardConfig>.Instance.GetRewardTargetById(rewardTargetData.Id);
		List<RewardTargetData> list;
		if (!this.DataTypeMap.TryGetValue(rewardTargetById.Type, out list))
		{
			list = new List<RewardTargetData>();
			this.DataTypeMap[rewardTargetById.Type] = list;
		}
		list.Add(rewardTargetData);
	}

	// Token: 0x06008E36 RID: 36406 RVA: 0x00255BF4 File Offset: 0x00253DF4
	public void SetAllRewardTargetData(List<Aki.Protocol.TrackMoonTarget> dataList)
	{
		foreach (Aki.Protocol.TrackMoonTarget rewardTargetData in dataList)
		{
			this.SetRewardTargetData(rewardTargetData);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshRewardTargetData);
	}

	// Token: 0x06008E37 RID: 36407 RVA: 0x00255C54 File Offset: 0x00253E54
	public void SetRewardTargetData(Aki.Protocol.TrackMoonTarget data)
	{
		RewardTargetData rewardTargetData;
		if (!this.DataMap.TryGetValue(data.Id, out rewardTargetData))
		{
			rewardTargetData = new RewardTargetData(data.Id);
			this.AddDataType(rewardTargetData);
			this.ProcessTargetInfo(rewardTargetData);
			this.DataMap[data.Id] = rewardTargetData;
		}
		rewardTargetData.Current = data.Current;
		rewardTargetData.Target = data.Target;
		rewardTargetData.Status = data.Status;
	}

	// Token: 0x06008E38 RID: 36408 RVA: 0x00255CC8 File Offset: 0x00253EC8
	private void ProcessTargetInfo(RewardTargetData data)
	{
		List<TItem> rewardList = data.GetRewardList();
		int tokenItemId = ConfigBase<BusinessConfig>.Instance.GetTokenItemId();
		foreach (TItem titem in rewardList)
		{
			if (titem.ItemData.ItemId == tokenItemId)
			{
				this.TargetTotalCount += titem.Count;
			}
		}
	}

	// Token: 0x06008E39 RID: 36409 RVA: 0x00255D40 File Offset: 0x00253F40
	public void TakenRewardTargetData(int id)
	{
		RewardTargetData rewardTargetData;
		if (!this.DataMap.TryGetValue(id, out rewardTargetData))
		{
			return;
		}
		rewardTargetData.Current = rewardTargetData.Target;
		rewardTargetData.Status = TrackMoonTargetState.TrackMoonTargetTaken;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.TakenRewardTargetData, id);
	}

	// Token: 0x06008E3A RID: 36410 RVA: 0x00255D84 File Offset: 0x00253F84
	public TaskData GetTaskDataById(int id)
	{
		RewardTargetData rewardTargetData;
		if (!this.DataMap.TryGetValue(id, out rewardTargetData))
		{
			return null;
		}
		return rewardTargetData.ConvertToTaskData();
	}

	// Token: 0x06008E3B RID: 36411 RVA: 0x00255DAC File Offset: 0x00253FAC
	public List<TaskData> GetTaskDataByTabId(int tabId)
	{
		List<RewardTargetData> list;
		if (!this.DataTypeMap.TryGetValue(tabId, out list))
		{
			return new List<TaskData>();
		}
		List<TaskData> list2 = new List<TaskData>();
		foreach (RewardTargetData rewardTargetData in list)
		{
			list2.Add(rewardTargetData.ConvertToTaskData());
		}
		return list2;
	}

	// Token: 0x06008E3C RID: 36412 RVA: 0x00255E1C File Offset: 0x0025401C
	public int SortTaskData(TaskData a, TaskData b)
	{
		if (a.Status == b.Status)
		{
			return a.TaskId - b.TaskId;
		}
		return a.Status - b.Status;
	}

	// Token: 0x06008E3D RID: 36413 RVA: 0x00255E48 File Offset: 0x00254048
	public bool GetTaskDataRedDotStateByTabId(int tabId)
	{
		using (List<TaskData>.Enumerator enumerator = this.GetTaskDataByTabId(tabId).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsFinished)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06008E3E RID: 36414 RVA: 0x00255EA4 File Offset: 0x002540A4
	public bool GetAllTaskDataRedDotState(bool withSpecialReward)
	{
		foreach (TrackMoonTargetType trackMoonTargetType in this.GetRewardTargetTabList())
		{
			if (this.GetTaskDataRedDotStateByTabId(trackMoonTargetType.Id))
			{
				return true;
			}
		}
		if (withSpecialReward)
		{
			TaskData specialTaskData = this.GetSpecialTaskData();
			return specialTaskData != null && specialTaskData.IsFinished;
		}
		return false;
	}

	// Token: 0x06008E3F RID: 36415 RVA: 0x00255F1C File Offset: 0x0025411C
	public TaskData GetSpecialTaskData()
	{
		return this.GetTaskDataByTabId(5)[0];
	}

	// Token: 0x06008E40 RID: 36416 RVA: 0x00255F2C File Offset: 0x0025412C
	public List<TrackMoonTargetType> GetRewardTargetTabList()
	{
		IEnumerable<TrackMoonTargetType> allRewardTargetTypeList = ConfigBase<MoonChasingRewardConfig>.Instance.GetAllRewardTargetTypeList();
		List<TrackMoonTargetType> list = new List<TrackMoonTargetType>();
		foreach (TrackMoonTargetType item in allRewardTargetTypeList)
		{
			if (item.Id != 5)
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06008E41 RID: 36417 RVA: 0x00255F90 File Offset: 0x00254190
	public List<PayShopGoods> GetShopDataList()
	{
		return ModelBase<PayShopModel>.Instance.GetPayShopTabData(PayShopDefine.EPayShopTabType.MoonChasing, 1, true);
	}

	// Token: 0x06008E42 RID: 36418 RVA: 0x00255FA4 File Offset: 0x002541A4
	public int GetTokenItemCount()
	{
		int tokenItemId = ConfigBase<BusinessConfig>.Instance.GetTokenItemId();
		return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(tokenItemId, 0);
	}

	// Token: 0x06008E43 RID: 36419 RVA: 0x00255FC8 File Offset: 0x002541C8
	public bool GetShopRedDotState()
	{
		bool flag = true;
		foreach (PayShopGoods payShopGoods in this.GetShopDataList())
		{
			if (flag && !payShopGoods.IsSoldOut())
			{
				flag = false;
			}
			if (this.CheckShopItemCheckFlag(payShopGoods))
			{
				return true;
			}
		}
		int value = ConfigCommonParamById.GetIntConfig("MoonChasingShopTipsValue").Value;
		return value != 0 && !flag && this.GetTokenItemCount() >= value;
	}

	// Token: 0x06008E44 RID: 36420 RVA: 0x0025605C File Offset: 0x0025425C
	public bool CheckShopItemRedDotState(PayShopGoods shopData)
	{
		return !shopData.IsSoldOut() && !shopData.IsLocked() && shopData.IfCanBuy() && !ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.MoonChasingShopItemUnlock, shopData.GetGoodsId());
	}

	// Token: 0x06008E45 RID: 36421 RVA: 0x0025608D File Offset: 0x0025428D
	public bool ReadShopItemUnlockFlag(PayShopGoods shopData)
	{
		if (!this.CheckShopItemRedDotState(shopData))
		{
			return false;
		}
		ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.MoonChasingShopItemUnlock, shopData.GetGoodsId());
		this.SaveShopRedDot();
		return true;
	}

	// Token: 0x06008E46 RID: 36422 RVA: 0x002560B4 File Offset: 0x002542B4
	public void SaveShopRedDot()
	{
		ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.MoonChasingShopItemUnlock);
		Singleton<EventSystem>.Instance.Emit(EEventName.MoonChasingRefreshRewardRedDot);
	}

	// Token: 0x06008E47 RID: 36423 RVA: 0x002560D3 File Offset: 0x002542D3
	public bool CheckShopItemCheckFlag(PayShopGoods shopData)
	{
		return !shopData.IsSoldOut() && !shopData.IsLocked() && shopData.IfCanBuy() && !ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.MoonChasingShopItemChecked, shopData.GetGoodsId());
	}

	// Token: 0x06008E48 RID: 36424 RVA: 0x00256104 File Offset: 0x00254304
	public bool ReadShopItemCheckFlag(List<PayShopGoods> shopDataList)
	{
		foreach (PayShopGoods payShopGoods in shopDataList)
		{
			if (this.CheckShopItemCheckFlag(payShopGoods))
			{
				ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.MoonChasingShopItemChecked, payShopGoods.GetGoodsId());
			}
		}
		ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.MoonChasingShopItemChecked);
		Singleton<EventSystem>.Instance.Emit(EEventName.MoonChasingRefreshRewardRedDot);
		return true;
	}

	// Token: 0x0400424A RID: 16970
	private readonly Dictionary<int, List<RewardTargetData>> DataTypeMap = new Dictionary<int, List<RewardTargetData>>();

	// Token: 0x0400424B RID: 16971
	private readonly Dictionary<int, RewardTargetData> DataMap = new Dictionary<int, RewardTargetData>();

	// Token: 0x0400424C RID: 16972
	public int TargetTotalCount;

	// Token: 0x0400424D RID: 16973
	public int TargetGetCount;
}
