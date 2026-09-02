using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x0200237D RID: 9085
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class BattlePassModel : ModelBase<BattlePassModel>
{
	// Token: 0x06011648 RID: 71240 RVA: 0x004CA8DB File Offset: 0x004C8ADB
	public bool GetInTimeRange()
	{
		return this.InTimeRange;
	}

	// Token: 0x06011649 RID: 71241 RVA: 0x004CA8E3 File Offset: 0x004C8AE3
	public void SetInTimeRange(bool value)
	{
		this.InTimeRange = value;
	}

	// Token: 0x0601164A RID: 71242 RVA: 0x004CA8EC File Offset: 0x004C8AEC
	public long GetDayEndTime()
	{
		return this.DayEndTime;
	}

	// Token: 0x0601164B RID: 71243 RVA: 0x004CA8F4 File Offset: 0x004C8AF4
	public long GetWeekEndTime()
	{
		return this.WeekEndTime;
	}

	// Token: 0x0601164C RID: 71244 RVA: 0x004CA8FC File Offset: 0x004C8AFC
	public int GetGiftId()
	{
		return this.GiftId;
	}

	// Token: 0x17001593 RID: 5523
	// (get) Token: 0x0601164D RID: 71245 RVA: 0x004CA904 File Offset: 0x004C8B04
	public int PrimaryItemId
	{
		get
		{
			return ConfigCommonParamById.GetIntArrayConfig("PrimaryGiftItem")[0];
		}
	}

	// Token: 0x17001594 RID: 5524
	// (get) Token: 0x0601164E RID: 71246 RVA: 0x004CA916 File Offset: 0x004C8B16
	public int AdvanceItemId
	{
		get
		{
			return ConfigCommonParamById.GetIntArrayConfig("AdvancedGiftItem")[0];
		}
	}

	// Token: 0x17001595 RID: 5525
	// (get) Token: 0x0601164F RID: 71247 RVA: 0x004CA928 File Offset: 0x004C8B28
	// (set) Token: 0x06011650 RID: 71248 RVA: 0x004CA930 File Offset: 0x004C8B30
	public bool HadEnter
	{
		get
		{
			return this.HadEnterInternal;
		}
		set
		{
			if (this.HadEnterInternal != value)
			{
				this.HadEnterInternal = value;
				Singleton<EventSystem>.Instance.Emit(EEventName.BattlePassHadEnterUpdate);
			}
		}
	}

	// Token: 0x06011651 RID: 71249 RVA: 0x004CA954 File Offset: 0x004C8B54
	public List<WeaponDataBase> GetWeaponDataList()
	{
		if (this.WeaponDataList == null)
		{
			this.WeaponDataList = new List<WeaponDataBase>();
			foreach (int trialId in ConfigCommonParamById.GetIntArrayConfig("BattlePassUnlockWeapons"))
			{
				WeaponTrialData weaponTrialData = new WeaponTrialData();
				weaponTrialData.SetTrialId(trialId, true);
				this.WeaponDataList.Add(weaponTrialData);
			}
		}
		return this.WeaponDataList;
	}

	// Token: 0x06011652 RID: 71250 RVA: 0x004CA9D4 File Offset: 0x004C8BD4
	[NullableContext(2)]
	public BattlePassRewardData GetRewardData(int level)
	{
		if (level - 1 < 0 || level - 1 >= this.RewardDataList.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Temp;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "战令奖励数据 没有这个等级的";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("level", level);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		BattlePassRewardData battlePassRewardData = this.RewardDataList[level - 1];
		if (battlePassRewardData == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Temp;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "战令奖励数据 没有这个等级的";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("level", level);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return null;
		}
		return battlePassRewardData;
	}

	// Token: 0x17001596 RID: 5526
	// (get) Token: 0x06011653 RID: 71251 RVA: 0x004CAA64 File Offset: 0x004C8C64
	// (set) Token: 0x06011654 RID: 71252 RVA: 0x004CAA94 File Offset: 0x004C8C94
	public bool PayButtonRedDotState
	{
		get
		{
			if (this.PayButtonRedDotStateInternal == null)
			{
				this.PayButtonRedDotStateInternal = new bool?(LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.BattlePassPayButton, true));
			}
			return this.PayButtonRedDotStateInternal.Value;
		}
		set
		{
			bool? payButtonRedDotStateInternal = this.PayButtonRedDotStateInternal;
			if (!(payButtonRedDotStateInternal.GetValueOrDefault() == value & payButtonRedDotStateInternal != null))
			{
				this.PayButtonRedDotStateInternal = new bool?(value);
				Singleton<EventSystem>.Instance.Emit(EEventName.BattlePassHadEnterUpdate);
				LocalStorage.SetPlayer<bool?>(ELocalStoragePlayerKey.BattlePassPayButton, this.PayButtonRedDotStateInternal);
			}
		}
	}

	// Token: 0x06011655 RID: 71253 RVA: 0x004CAAE8 File Offset: 0x004C8CE8
	public int GetMaxLevel()
	{
		return this.MaxLevel;
	}

	// Token: 0x06011656 RID: 71254 RVA: 0x004CAAF0 File Offset: 0x004C8CF0
	public bool IsLevelMax()
	{
		return this.CurrentBattlePassLevel >= this.MaxLevel;
	}

	// Token: 0x06011657 RID: 71255 RVA: 0x004CAB03 File Offset: 0x004C8D03
	public bool IsWeekMax()
	{
		return this.WeekExp >= this.MaxWeekExp;
	}

	// Token: 0x06011658 RID: 71256 RVA: 0x004CAB18 File Offset: 0x004C8D18
	public int GetNextStageLevel(int currentLevel)
	{
		if (currentLevel == 0)
		{
			return 0;
		}
		int result = 0;
		foreach (int num in this.StageLevelList)
		{
			if (num > currentLevel)
			{
				result = num;
				break;
			}
		}
		return result;
	}

	// Token: 0x06011659 RID: 71257 RVA: 0x004CAB74 File Offset: 0x004C8D74
	public void InitBattlePassConfigData()
	{
		int battlePassId = this.BattlePassId;
		this.RewardDataList.Clear();
		BattlePass? battlePassData = ConfigBase<BattlePassConfig>.Instance.GetBattlePassData(battlePassId);
		this.MaxLevel = battlePassData.Value.LevelLimit;
		foreach (BattlePassReward battlePassReward in ConfigBase<BattlePassConfig>.Instance.GetAllRewardData(battlePassData.Value.BattlePassRewardId))
		{
			if (battlePassReward.Level <= this.MaxLevel)
			{
				BattlePassRewardData battlePassRewardData = new BattlePassRewardData(new int?(battlePassReward.Level));
				foreach (KeyValuePair<int, int> keyValuePair in battlePassReward.FreeReward())
				{
					BattlePassRewardItem battlePassRewardItem = new BattlePassRewardItem(keyValuePair.Key, keyValuePair.Value, EBattlePassItemType.Locked);
					if (this.BattlePassLevel >= battlePassReward.Level)
					{
						battlePassRewardItem.ItemType = new EBattlePassItemType?(EBattlePassItemType.CanGet);
					}
					battlePassRewardData.FreeRewardItem.Add(battlePassRewardItem);
				}
				foreach (KeyValuePair<int, int> keyValuePair2 in battlePassReward.PayReward())
				{
					BattlePassRewardItem battlePassRewardItem2 = new BattlePassRewardItem(keyValuePair2.Key, keyValuePair2.Value, EBattlePassItemType.Locked);
					if (this.BattlePassLevel >= battlePassReward.Level && this.BattlePassType != BattlePassPayStatus.NoPaid)
					{
						battlePassRewardItem2.ItemType = new EBattlePassItemType?(EBattlePassItemType.CanGet);
					}
					battlePassRewardData.PayRewardItem.Add(battlePassRewardItem2);
				}
				if (battlePassReward.IsMilestone)
				{
					this.StageLevelList.Add(battlePassReward.Level);
				}
				this.RewardDataList.Add(battlePassRewardData);
			}
		}
		this.MaxWeekExp = battlePassData.Value.WeekExpLimit;
		this.MaxLevelExp = battlePassData.Value.LevelUpExp;
		this.UpdateLimitValue();
	}

	// Token: 0x0601165A RID: 71258 RVA: 0x004CADAC File Offset: 0x004C8FAC
	private void UpdateLimitValue()
	{
		this.AllExpLimitValue = this.MaxLevelExp * (this.MaxLevel - this.CurrentBattlePassLevel) - this.LevelExp;
		this.WeekExpLimitValue = this.MaxWeekExp - this.WeekExp;
	}

	// Token: 0x0601165B RID: 71259 RVA: 0x004CADE4 File Offset: 0x004C8FE4
	[NullableContext(0)]
	private ValueTuple<int, int> GetTasksExp([Nullable(1)] List<int> taskIdList)
	{
		int num = 0;
		int num2 = 0;
		foreach (int id in taskIdList)
		{
			BattlePassTaskData taskData = this.GetTaskData(id);
			num += taskData.Exp;
			num2 += ((taskData.UpdateType == EBattlePassTaskUpdateState.Always) ? 0 : taskData.Exp);
		}
		return new ValueTuple<int, int>(num, num2);
	}

	// Token: 0x0601165C RID: 71260 RVA: 0x004CAE60 File Offset: 0x004C9060
	public void TryRequestTaskList(List<int> taskIdList)
	{
		ValueTuple<int, int> tasksExp = this.GetTasksExp(taskIdList);
		int item = tasksExp.Item1;
		int item2 = tasksExp.Item2;
		int num = item - Math.Max(0, item2 - this.WeekExpLimitValue);
		if (this.IsLevelMax() || num > this.AllExpLimitValue)
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("BattlePassExpMax", Array.Empty<object>());
			ControllerBase<BattlePassController>.Instance.RequestBattlePassTaskTake(taskIdList);
			return;
		}
		if (item2 > this.WeekExpLimitValue)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(this.IsWeekMax() ? EConfirmBoxConfigId.TakeExpSureTip : EConfirmBoxConfigId.TakeExpOverSureTip);
			confirmBoxDataNew.FunctionMap.Add(2, delegate
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("BattlePassWeeklyExpMax", Array.Empty<object>());
				ControllerBase<BattlePassController>.Instance.RequestBattlePassTaskTake(taskIdList);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		ControllerBase<BattlePassController>.Instance.RequestBattlePassTaskTake(taskIdList);
	}

	// Token: 0x0601165D RID: 71261 RVA: 0x004CAF34 File Offset: 0x004C9134
	public void UpdateBattlePassRewardDataFromResponse([Nullable(new byte[]
	{
		2,
		1
	})] IList<PbBattlePassReward> responseDataList)
	{
		if (responseDataList == null || responseDataList.Count == 0)
		{
			return;
		}
		foreach (PbBattlePassReward pbBattlePassReward in responseDataList)
		{
			this.TakeReward(pbBattlePassReward.Type, pbBattlePassReward.Level, pbBattlePassReward.ItemId);
		}
	}

	// Token: 0x0601165E RID: 71262 RVA: 0x004CAF9C File Offset: 0x004C919C
	public void UpdateRewardDataWithTargetLevel(int targetLevel)
	{
		for (int i = 1; i <= targetLevel; i++)
		{
			this.SetRewardCanGet(i, false);
		}
	}

	// Token: 0x0601165F RID: 71263 RVA: 0x004CAFC0 File Offset: 0x004C91C0
	private void SetRewardCanGet(int level, bool force = false)
	{
		if (level - 1 >= 0 && level - 1 < this.RewardDataList.Count)
		{
			BattlePassRewardData battlePassRewardData = this.RewardDataList[level - 1];
			if (battlePassRewardData != null)
			{
				foreach (BattlePassRewardItem battlePassRewardItem in battlePassRewardData.FreeRewardItem)
				{
					EBattlePassItemType? itemType = battlePassRewardItem.ItemType;
					EBattlePassItemType ebattlePassItemType = EBattlePassItemType.Locked;
					if ((itemType.GetValueOrDefault() == ebattlePassItemType & itemType != null) || force)
					{
						battlePassRewardItem.ItemType = new EBattlePassItemType?(EBattlePassItemType.CanGet);
					}
				}
				if (this.PayType != BattlePassPayStatus.NoPaid)
				{
					foreach (BattlePassRewardItem battlePassRewardItem2 in battlePassRewardData.PayRewardItem)
					{
						EBattlePassItemType? itemType = battlePassRewardItem2.ItemType;
						EBattlePassItemType ebattlePassItemType = EBattlePassItemType.Locked;
						if ((itemType.GetValueOrDefault() == ebattlePassItemType & itemType != null) || force)
						{
							battlePassRewardItem2.ItemType = new EBattlePassItemType?(EBattlePassItemType.CanGet);
						}
					}
				}
			}
		}
	}

	// Token: 0x06011660 RID: 71264 RVA: 0x004CB0E0 File Offset: 0x004C92E0
	public unsafe void TakeReward(BattlePassType battlePassType, int level, int itemId)
	{
		BattlePassRewardData rewardData = this.GetRewardData(level);
		BattlePassRewardItem battlePassRewardItem;
		if (battlePassType == Aki.Protocol.BattlePassType.Free)
		{
			battlePassRewardItem = rewardData.GetFreeRewardItem(itemId);
		}
		else
		{
			battlePassRewardItem = rewardData.GetPayRewardItem(itemId);
		}
		if (battlePassRewardItem != null)
		{
			battlePassRewardItem.ItemType = new EBattlePassItemType?(EBattlePassItemType.HasGet);
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Temp;
		ELogAuthor author = ELogAuthor.WZ;
		string message = "【TakeReward】战令奖励数据 没有这个奖励的配置";
		<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("battlePassType", battlePassType);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("level", level);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("itemId from server", itemId);
		instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
	}

	// Token: 0x06011661 RID: 71265 RVA: 0x004CB195 File Offset: 0x004C9395
	public void OnResponseTakeReward(BattlePassType battlePassType, int level, int itemId, int gridIndex)
	{
		this.TakeReward(battlePassType, level, itemId);
		Singleton<EventSystem>.Instance.Emit<int?>(EEventName.GetBattlePassRewardEvent, new int?(gridIndex));
	}

	// Token: 0x17001597 RID: 5527
	// (get) Token: 0x06011662 RID: 71266 RVA: 0x004CB1B7 File Offset: 0x004C93B7
	// (set) Token: 0x06011663 RID: 71267 RVA: 0x004CB1BF File Offset: 0x004C93BF
	public int BattlePassLevel
	{
		get
		{
			return this.CurrentBattlePassLevel;
		}
		set
		{
			this.CurrentBattlePassLevel = value;
		}
	}

	// Token: 0x17001598 RID: 5528
	// (get) Token: 0x06011664 RID: 71268 RVA: 0x004CB1C8 File Offset: 0x004C93C8
	// (set) Token: 0x06011665 RID: 71269 RVA: 0x004CB1D0 File Offset: 0x004C93D0
	public int WeekExp
	{
		get
		{
			return this.CurrentWeekExp;
		}
		set
		{
			this.CurrentWeekExp = value;
		}
	}

	// Token: 0x17001599 RID: 5529
	// (get) Token: 0x06011666 RID: 71270 RVA: 0x004CB1D9 File Offset: 0x004C93D9
	// (set) Token: 0x06011667 RID: 71271 RVA: 0x004CB1E1 File Offset: 0x004C93E1
	public int LevelExp
	{
		get
		{
			return this.CurrentLevelExp;
		}
		set
		{
			this.CurrentLevelExp = value;
		}
	}

	// Token: 0x1700159A RID: 5530
	// (get) Token: 0x06011668 RID: 71272 RVA: 0x004CB1EA File Offset: 0x004C93EA
	// (set) Token: 0x06011669 RID: 71273 RVA: 0x004CB1F2 File Offset: 0x004C93F2
	public BattlePassPayStatus PayType
	{
		get
		{
			return this.BattlePassType;
		}
		set
		{
			this.BattlePassType = value;
		}
	}

	// Token: 0x0601166A RID: 71274 RVA: 0x004CB1FB File Offset: 0x004C93FB
	public long GetBattlePassStartTime()
	{
		return this.BattlePassStartTime;
	}

	// Token: 0x0601166B RID: 71275 RVA: 0x004CB203 File Offset: 0x004C9403
	public long GetBattlePassEndTime()
	{
		return this.BattlePassEndTime;
	}

	// Token: 0x0601166C RID: 71276 RVA: 0x004CB20B File Offset: 0x004C940B
	public bool InBattlePassInWarningTime()
	{
		return Singleton<TimeUtil>.Instance.GetServerTime() > (double)this.WarningTime;
	}

	// Token: 0x0601166D RID: 71277 RVA: 0x004CB220 File Offset: 0x004C9420
	private void SetBattlePassStartTime(long value)
	{
		this.BattlePassStartTime = Singleton<MathUtils>.Instance.LongToBigInt(value);
	}

	// Token: 0x0601166E RID: 71278 RVA: 0x004CB234 File Offset: 0x004C9434
	private void SetBattlePassEndTime(long value)
	{
		this.BattlePassEndTime = Singleton<MathUtils>.Instance.LongToBigInt(value);
		this.WarningTime = this.BattlePassEndTime - (long)(ConfigCommonParamById.GetIntConfig("BattlePassSettleBugTime").Value * 3600);
	}

	// Token: 0x0601166F RID: 71279 RVA: 0x004CB278 File Offset: 0x004C9478
	public void SetDayEndTime(long value)
	{
		this.DayEndTime = Singleton<MathUtils>.Instance.LongToBigInt(value);
	}

	// Token: 0x06011670 RID: 71280 RVA: 0x004CB28B File Offset: 0x004C948B
	public void SetWeekEndTime(long value)
	{
		this.WeekEndTime = Singleton<MathUtils>.Instance.LongToBigInt(value);
	}

	// Token: 0x06011671 RID: 71281 RVA: 0x004CB29E File Offset: 0x004C949E
	public int GetMaxWeekExp()
	{
		return this.MaxWeekExp;
	}

	// Token: 0x06011672 RID: 71282 RVA: 0x004CB2A6 File Offset: 0x004C94A6
	public int GetMaxLevelExp()
	{
		return this.MaxLevelExp;
	}

	// Token: 0x06011673 RID: 71283 RVA: 0x004CB2B0 File Offset: 0x004C94B0
	public string GetPassPayBtnKey()
	{
		switch (this.BattlePassType)
		{
		case BattlePassPayStatus.NoPaid:
			return "Text_BattlePassBuyButton1_Text";
		case BattlePassPayStatus.Paid:
			return "Text_BattlePassBuyButton2_Text";
		case BattlePassPayStatus.Advanced:
			return "Text_BattlePassBuyButton3_Text";
		default:
			return "";
		}
	}

	// Token: 0x06011674 RID: 71284 RVA: 0x004CB2EF File Offset: 0x004C94EF
	protected override bool OnInit()
	{
		this.GiftId = 301;
		this.RewardDataList = new List<BattlePassRewardData>();
		this.StageLevelList = new List<int>();
		this.BattlePassTaskMap = new Dictionary<int, BattlePassTaskData>();
		this.HadEnterInternal = true;
		this.BattlePassType = BattlePassPayStatus.NoPaid;
		return true;
	}

	// Token: 0x06011675 RID: 71285 RVA: 0x004CB32C File Offset: 0x004C952C
	public int GetBattlePassRemainTime()
	{
		return (int)Singleton<TimeUtil>.Instance.CalculateHourGapBetweenNow((double)this.BattlePassEndTime, true);
	}

	// Token: 0x06011676 RID: 71286 RVA: 0x004CB344 File Offset: 0x004C9544
	public double GetBattlePassRemainTimeSecond()
	{
		double num = Singleton<TimeUtil>.Instance.GetServerTimeStamp() / (double)Singleton<TimeUtil>.Instance.InverseMillisecond;
		return (double)this.BattlePassEndTime - num;
	}

	// Token: 0x06011677 RID: 71287 RVA: 0x004CB374 File Offset: 0x004C9574
	public void GetTargetLevelRewardList(int targetLevel, List<TItem> rewardList)
	{
		rewardList.Clear();
		int currentBattlePassLevel = this.CurrentBattlePassLevel;
		Dictionary<int, TItem> dictionary = new Dictionary<int, TItem>();
		for (int i = currentBattlePassLevel + 1; i <= targetLevel; i++)
		{
			BattlePassRewardData rewardData = this.GetRewardData(i);
			if (rewardData != null)
			{
				List<BattlePassRewardItem> list = new List<BattlePassRewardItem>();
				if (this.BattlePassType == BattlePassPayStatus.NoPaid)
				{
					list.AddRange(rewardData.FreeRewardItem);
				}
				else
				{
					list.AddRange(rewardData.FreeRewardItem);
					list.AddRange(rewardData.PayRewardItem);
				}
				foreach (BattlePassRewardItem battlePassRewardItem in list)
				{
					int itemId = battlePassRewardItem.Item.Value.ItemData.ItemId;
					int count = battlePassRewardItem.Item.Value.Count;
					TItem titem;
					if (dictionary.TryGetValue(itemId, out titem))
					{
						dictionary[itemId] = new TItem(titem.ItemData, titem.Count + count);
					}
					else
					{
						dictionary.Add(itemId, new TItem(new InventoryDefine.GetItemData(itemId, 0), count));
					}
				}
			}
		}
		foreach (KeyValuePair<int, TItem> keyValuePair in dictionary)
		{
			rewardList.Add(keyValuePair.Value);
		}
		rewardList.Sort(new Comparison<TItem>(BattlePassModel.<GetTargetLevelRewardList>g__compare|80_0));
	}

	// Token: 0x06011678 RID: 71288 RVA: 0x004CB4E4 File Offset: 0x004C96E4
	[NullableContext(2)]
	public BattlePassTaskData GetTaskData(int id)
	{
		BattlePassTaskData result;
		if (this.BattlePassTaskMap.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06011679 RID: 71289 RVA: 0x004CB504 File Offset: 0x004C9704
	public void GetTaskList(EBattlePassTaskUpdateState updateState, List<BattlePassTaskData> outArray)
	{
		outArray.Clear();
		foreach (KeyValuePair<int, BattlePassTaskData> keyValuePair in this.BattlePassTaskMap)
		{
			if (keyValuePair.Value.UpdateType == updateState)
			{
				outArray.Add(keyValuePair.Value);
			}
		}
		outArray.Sort(new Comparison<BattlePassTaskData>(BattlePassModel.<GetTaskList>g__compare|83_0));
	}

	// Token: 0x0601167A RID: 71290 RVA: 0x004CB584 File Offset: 0x004C9784
	public EBattlePassTaskUpdateState[] GetTaskTypeList()
	{
		EBattlePassTaskUpdateState[] array = new EBattlePassTaskUpdateState[3];
		array[0] = EBattlePassTaskUpdateState.EveryDay;
		array[1] = EBattlePassTaskUpdateState.EveryWeek;
		return array;
	}

	// Token: 0x0601167B RID: 71291 RVA: 0x004CB594 File Offset: 0x004C9794
	public int GetPrimaryBattlePassGoodsId()
	{
		return ConfigCommonParamById.GetIntConfig("PrimaryBattlePassShopId").Value;
	}

	// Token: 0x0601167C RID: 71292 RVA: 0x004CB5B4 File Offset: 0x004C97B4
	public int GetHighBattlePassGoodsId()
	{
		return ConfigCommonParamById.GetIntConfig("AdvancedWithActive").Value;
	}

	// Token: 0x0601167D RID: 71293 RVA: 0x004CB5D4 File Offset: 0x004C97D4
	public int GetSupplyBattlePassGoodsId()
	{
		return ConfigCommonParamById.GetIntConfig("AdvancedWithoutActive").Value;
	}

	// Token: 0x0601167E RID: 71294 RVA: 0x004CB5F4 File Offset: 0x004C97F4
	public List<int> GetAllFinishedTask()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, BattlePassTaskData> keyValuePair in this.BattlePassTaskMap)
		{
			if (keyValuePair.Value.TaskState == EBattlePassTaskState.WaitTakeReward)
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list;
	}

	// Token: 0x0601167F RID: 71295 RVA: 0x004CB664 File Offset: 0x004C9864
	public bool CheckHasRewardWaitTake()
	{
		if (!this.GetInTimeRange())
		{
			return false;
		}
		foreach (BattlePassRewardData battlePassRewardData in this.RewardDataList)
		{
			using (List<BattlePassRewardItem>.Enumerator enumerator2 = battlePassRewardData.FreeRewardItem.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.ItemType.GetValueOrDefault() == EBattlePassItemType.CanGet)
					{
						return true;
					}
				}
			}
			using (List<BattlePassRewardItem>.Enumerator enumerator2 = battlePassRewardData.PayRewardItem.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.ItemType.GetValueOrDefault() == EBattlePassItemType.CanGet)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06011680 RID: 71296 RVA: 0x004CB75C File Offset: 0x004C995C
	public bool CheckHasTaskWaitTake()
	{
		if (this.MaxLevel == this.BattlePassLevel)
		{
			return false;
		}
		foreach (KeyValuePair<int, BattlePassTaskData> keyValuePair in this.BattlePassTaskMap)
		{
			if (keyValuePair.Value.TaskState == EBattlePassTaskState.WaitTakeReward)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06011681 RID: 71297 RVA: 0x004CB7D0 File Offset: 0x004C99D0
	public bool CheckHasTaskWaitTakeWithType(EBattlePassTaskUpdateState type)
	{
		if (!this.GetInTimeRange())
		{
			return false;
		}
		if (this.CurrentBattlePassLevel == this.MaxLevel)
		{
			return false;
		}
		foreach (KeyValuePair<int, BattlePassTaskData> keyValuePair in this.BattlePassTaskMap)
		{
			if (type == keyValuePair.Value.UpdateType && keyValuePair.Value.TaskState == EBattlePassTaskState.WaitTakeReward)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06011682 RID: 71298 RVA: 0x004CB85C File Offset: 0x004C9A5C
	public void AddTaskDataFromProtocol(PbBattlePassTask task)
	{
		int? intConfig = ConfigCommonParamById.GetIntConfig("BattlePassExp");
		Dictionary<int, BattlePassTaskData> battlePassTaskMap = this.BattlePassTaskMap;
		BattlePassTaskData battlePassTaskData = new BattlePassTaskData();
		battlePassTaskData.TaskId = task.Id;
		BattlePassTask? battlePassTask = ConfigBase<BattlePassConfig>.Instance.GetBattlePassTask(task.Id);
		foreach (KeyValuePair<int, int> keyValuePair in battlePassTask.Value.TaskReward())
		{
			TItem item = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
			int key = keyValuePair.Key;
			int? num = intConfig;
			if (key == num.GetValueOrDefault() & num != null)
			{
				battlePassTaskData.Exp += keyValuePair.Value;
			}
			battlePassTaskData.RewardItemList.Add(item);
		}
		battlePassTaskData.CurrentProgress = task.Current;
		battlePassTaskData.TargetProgress = task.Target;
		battlePassTaskData.UpdateType = (EBattlePassTaskUpdateState)battlePassTask.Value.UpdateType;
		battlePassTaskData.SkipId = ((battlePassTask.Value.JumpId == 0) ? null : new int?(battlePassTask.Value.JumpId));
		if (!task.IsFinished)
		{
			battlePassTaskData.TaskState = EBattlePassTaskState.Running;
		}
		else if (task.IsTaken)
		{
			battlePassTaskData.TaskState = EBattlePassTaskState.FinishedAndHasTaken;
		}
		else
		{
			battlePassTaskData.TaskState = EBattlePassTaskState.WaitTakeReward;
		}
		battlePassTaskMap[task.Id] = battlePassTaskData;
	}

	// Token: 0x06011683 RID: 71299 RVA: 0x004CB9E0 File Offset: 0x004C9BE0
	public void SetDataFromBattlePassResponse(BattlePassResponse response)
	{
		PbBattlePass battlePass = response.BattlePass;
		this.InTimeRange = battlePass.InTimeRange;
		if (!this.InTimeRange)
		{
			this.PayButtonRedDotState = false;
			return;
		}
		this.HadEnter = battlePass.HadEnter;
		this.BattlePassId = battlePass.Id;
		this.PayType = battlePass.PayStatus;
		this.BattlePassLevel = battlePass.Level;
		this.LevelExp = battlePass.Exp;
		this.WeekExp = battlePass.WeeklyTotalExp;
		this.SetBattlePassEndTime(battlePass.EndTime);
		this.SetBattlePassStartTime(battlePass.BeginTime);
		this.InitBattlePassConfigData();
		this.UpdateBattlePassRewardDataFromResponse(response.BattlePass.TakenRewards ?? null);
		if (!battlePass.HadEnter && battlePass.InTimeRange)
		{
			this.PayButtonRedDotState = true;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.ReceiveBattlePassDataEvent);
	}

	// Token: 0x06011684 RID: 71300 RVA: 0x004CBAB4 File Offset: 0x004C9CB4
	public void UpdateTaskDataFromBattlePassTaskTakeResponse(int[] ids)
	{
		Dictionary<int, BattlePassTaskData> battlePassTaskMap = this.BattlePassTaskMap;
		foreach (int key in ids)
		{
			BattlePassTaskData battlePassTaskData;
			if (battlePassTaskMap.TryGetValue(key, out battlePassTaskData))
			{
				battlePassTaskData.TaskState = EBattlePassTaskState.FinishedAndHasTaken;
			}
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.UpdateBattlePassTaskEvent);
	}

	// Token: 0x06011685 RID: 71301 RVA: 0x004CBB00 File Offset: 0x004C9D00
	public void UpdateExpDataFromBattlePassExpUpdateNotify(int level, int exp, int weekExp)
	{
		this.UpdateRewardDataWithTargetLevel(level);
		bool flag = level > this.BattlePassLevel;
		if (flag)
		{
			this.IncreasedLevelToShow += level - this.BattlePassLevel;
		}
		this.BattlePassLevel = level;
		if (flag)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBattlePassLevelUpEvent);
		}
		this.LevelExp = exp;
		this.WeekExp = weekExp;
		this.UpdateLimitValue();
		Singleton<EventSystem>.Instance.Emit(EEventName.ReceiveBattlePassDataEvent);
	}

	// Token: 0x06011686 RID: 71302 RVA: 0x004CBB74 File Offset: 0x004C9D74
	public void UpdateRewardDataFromBattlePassTakeAllRewardResponse(BattlePassTakeAllRewardResponse response)
	{
		foreach (PbBattlePassReward pbBattlePassReward in response.TakenRewards)
		{
			this.TakeReward(pbBattlePassReward.Type, pbBattlePassReward.Level, pbBattlePassReward.ItemId);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.ReceiveBattlePassDataEvent);
	}

	// Token: 0x06011687 RID: 71303 RVA: 0x004CBBE4 File Offset: 0x004C9DE4
	public void UpdateRewardDataFormFreeToPay()
	{
		for (int i = 1; i <= this.CurrentBattlePassLevel; i++)
		{
			BattlePassRewardData rewardData = this.GetRewardData(i);
			if (rewardData != null)
			{
				foreach (BattlePassRewardItem battlePassRewardItem in rewardData.PayRewardItem)
				{
					battlePassRewardItem.ItemType = new EBattlePassItemType?(EBattlePassItemType.CanGet);
				}
			}
		}
	}

	// Token: 0x06011688 RID: 71304 RVA: 0x004CBC58 File Offset: 0x004C9E58
	[NullableContext(2)]
	public string GetBattlePassIconPath()
	{
		BattlePass? battlePassData = ConfigBase<BattlePassConfig>.Instance.GetBattlePassData(this.BattlePassId);
		if (battlePassData != null)
		{
			return battlePassData.Value.ExclusiveRewardPath;
		}
		return null;
	}

	// Token: 0x06011689 RID: 71305 RVA: 0x004CBC90 File Offset: 0x004C9E90
	public int GetCurrentShowLevel()
	{
		int num = 0;
		foreach (BattlePassRewardData battlePassRewardData in this.RewardDataList)
		{
			if (battlePassRewardData.IsThisType(EBattlePassItemType.CanGet))
			{
				num = battlePassRewardData.Level.Value;
				break;
			}
		}
		if (num == 0)
		{
			foreach (BattlePassRewardData battlePassRewardData2 in this.RewardDataList)
			{
				if (battlePassRewardData2.IsThisType(EBattlePassItemType.HasGet))
				{
					num = battlePassRewardData2.Level.Value;
				}
			}
		}
		if (num == 0)
		{
			num = 1;
		}
		return num;
	}

	// Token: 0x0601168A RID: 71306 RVA: 0x004CBD50 File Offset: 0x004C9F50
	public string GetHighBattlePassOriginalPrice()
	{
		int primaryBattlePassGoodsId = this.GetPrimaryBattlePassGoodsId();
		int? intConfig = ConfigCommonParamById.GetIntConfig("AdvancedWithoutActive");
		int payId = ConfigBase<PayShopConfig>.Instance.GetPayShopDirectGoods(primaryBattlePassGoodsId).PayId;
		float amount = ConfigBase<PayItemConfig>.Instance.GetPayConf(payId).Value.Amount;
		int payId2 = ConfigBase<PayShopConfig>.Instance.GetPayShopDirectGoods(intConfig.Value).PayId;
		float amount2 = ConfigBase<PayItemConfig>.Instance.GetPayConf(payId2).Value.Amount;
		StringBuilder stringBuilder = new StringBuilder();
		string payShow = ConfigBase<PayItemConfig>.Instance.GetPayShow(payId2);
		stringBuilder.Append(ConfigBase<PayItemConfig>.Instance.GetPayShowCurrency());
		stringBuilder.Append(amount + amount2);
		return payShow;
	}

	// Token: 0x0601168B RID: 71307 RVA: 0x004CBE10 File Offset: 0x004CA010
	public EConfirmBoxConfigId GetBattlePassItemConfirmId(int itemId)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(10040))
		{
			return EConfirmBoxConfigId.BattlePassLock;
		}
		if (!this.GetInTimeRange())
		{
			return EConfirmBoxConfigId.BattlePassOutTime;
		}
		if (itemId == this.PrimaryItemId)
		{
			if (ModelBase<BattlePassModel>.Instance.PayType != BattlePassPayStatus.NoPaid)
			{
				return EConfirmBoxConfigId.BattlePassPrimaryRepeat;
			}
			if (ModelBase<BattlePassModel>.Instance.InBattlePassInWarningTime())
			{
				return EConfirmBoxConfigId.BattlePassPrimaryTimeWarning;
			}
			return EConfirmBoxConfigId.BattlePassUsePrimary;
		}
		else
		{
			if (ModelBase<BattlePassModel>.Instance.PayType == BattlePassPayStatus.Advanced)
			{
				return EConfirmBoxConfigId.BattlePassAdvanceRepeat;
			}
			if (ModelBase<BattlePassModel>.Instance.PayType == BattlePassPayStatus.Paid)
			{
				return EConfirmBoxConfigId.BattlePassUseUpgrade;
			}
			if (ModelBase<BattlePassModel>.Instance.InBattlePassInWarningTime())
			{
				return EConfirmBoxConfigId.BattlePassAdvanceTimeWarning;
			}
			return EConfirmBoxConfigId.BattlePassUseAdvance;
		}
	}

	// Token: 0x1700159B RID: 5531
	// (get) Token: 0x0601168C RID: 71308 RVA: 0x004CBEB2 File Offset: 0x004CA0B2
	public int? RemindLevel
	{
		get
		{
			return this.RemindLevelInternal;
		}
	}

	// Token: 0x0601168D RID: 71309 RVA: 0x004CBEBC File Offset: 0x004CA0BC
	public void TryAssignRemindLevel(int? level = null)
	{
		if (this.PayType > BattlePassPayStatus.NoPaid)
		{
			this.RemindLevelInternal = null;
			return;
		}
		BattlePass? battlePass;
		int battlePassId = (ConfigBase<BattlePassConfig>.Instance.GetBattlePassData(this.BattlePassId) != null) ? battlePass.GetValueOrDefault().BattlePassRewardId : 0;
		if (level == null)
		{
			using (IEnumerator<BattlePassReward> enumerator = ConfigBase<BattlePassConfig>.Instance.GetAllRewardData(battlePassId).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					BattlePassReward battlePassReward = enumerator.Current;
					if (battlePassReward.IsRemind && this.GetRewardData(battlePassReward.Level).IsThisType(EBattlePassItemType.CanGet))
					{
						this.RemindLevelInternal = new int?(this.BattlePassLevel);
						return;
					}
				}
				goto IL_142;
			}
		}
		BattlePassRewardData rewardData = this.GetRewardData(level.Value);
		if (rewardData != null && rewardData.IsThisType(EBattlePassItemType.CanGet))
		{
			foreach (BattlePassReward battlePassReward2 in ConfigBase<BattlePassConfig>.Instance.GetAllRewardData(battlePassId))
			{
				int level2 = battlePassReward2.Level;
				int? num = level;
				if (level2 == num.GetValueOrDefault() & num != null)
				{
					this.RemindLevelInternal = (battlePassReward2.IsRemind ? new int?(this.BattlePassLevel) : null);
					return;
				}
			}
		}
		IL_142:
		this.RemindLevelInternal = null;
	}

	// Token: 0x0601168E RID: 71310 RVA: 0x004CC034 File Offset: 0x004CA234
	public RewardItemData[] GetExtraRewardItems()
	{
		if (this.RemindLevelInternal == null)
		{
			return new RewardItemData[0];
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		List<RewardItemData> list = new List<RewardItemData>();
		BattlePass? battlePass;
		int battlePassId = (ConfigBase<BattlePassConfig>.Instance.GetBattlePassData(this.BattlePassId) != null) ? battlePass.GetValueOrDefault().BattlePassRewardId : 0;
		foreach (BattlePassReward battlePassReward in ConfigBase<BattlePassConfig>.Instance.GetAllRewardData(battlePassId))
		{
			int level = battlePassReward.Level;
			int? remindLevelInternal = this.RemindLevelInternal;
			if (level <= remindLevelInternal.GetValueOrDefault() & remindLevelInternal != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in battlePassReward.PayReward())
				{
					int num;
					if (dictionary.TryGetValue(keyValuePair.Key, out num))
					{
						dictionary[keyValuePair.Key] = num + keyValuePair.Value;
					}
					else
					{
						dictionary.Add(keyValuePair.Key, keyValuePair.Value);
					}
				}
			}
		}
		foreach (KeyValuePair<int, int> keyValuePair2 in dictionary)
		{
			list.Add(new RewardItemData(keyValuePair2.Key, keyValuePair2.Value, null, EDropItemType.Normal));
		}
		list.Sort(delegate(RewardItemData a, RewardItemData b)
		{
			int qualityId = ConfigBase<InventoryConfig>.Instance.GetItemConfig(a.ConfigId).Value.QualityId;
			int qualityId2 = ConfigBase<InventoryConfig>.Instance.GetItemConfig(b.ConfigId).Value.QualityId;
			if (qualityId == qualityId2)
			{
				return a.Count - b.Count;
			}
			return qualityId2 - qualityId;
		});
		return list.ToArray();
	}

	// Token: 0x06011690 RID: 71312 RVA: 0x004CC20C File Offset: 0x004CA40C
	[CompilerGenerated]
	internal static int <GetTargetLevelRewardList>g__compare|80_0(TItem a, TItem b)
	{
		int qualityId = ConfigBase<InventoryConfig>.Instance.GetItemConfig(a.ItemData.ItemId).Value.QualityId;
		int qualityId2 = ConfigBase<InventoryConfig>.Instance.GetItemConfig(b.ItemData.ItemId).Value.QualityId;
		if (qualityId == qualityId2)
		{
			return a.Count - b.Count;
		}
		return qualityId2 - qualityId;
	}

	// Token: 0x06011691 RID: 71313 RVA: 0x004CC27A File Offset: 0x004CA47A
	[CompilerGenerated]
	internal static int <GetTaskList>g__compare|83_0(BattlePassTaskData a, BattlePassTaskData b)
	{
		if (a.TaskState == EBattlePassTaskState.WaitTakeReward || b.TaskState == EBattlePassTaskState.FinishedAndHasTaken)
		{
			return -1;
		}
		if (a.TaskState == EBattlePassTaskState.FinishedAndHasTaken || b.TaskState == EBattlePassTaskState.WaitTakeReward)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x04008895 RID: 34965
	private const int GIFT_ID = 301;

	// Token: 0x04008896 RID: 34966
	public bool IsRequiringViewData;

	// Token: 0x04008897 RID: 34967
	private bool InTimeRange;

	// Token: 0x04008898 RID: 34968
	public int IncreasedLevelToShow;

	// Token: 0x04008899 RID: 34969
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<WeaponDataBase> WeaponDataList;

	// Token: 0x0400889A RID: 34970
	private long WarningTime;

	// Token: 0x0400889B RID: 34971
	private bool HadEnterInternal;

	// Token: 0x0400889C RID: 34972
	private bool? PayButtonRedDotStateInternal;

	// Token: 0x0400889D RID: 34973
	private int WeekExpLimitValue;

	// Token: 0x0400889E RID: 34974
	private int AllExpLimitValue;

	// Token: 0x0400889F RID: 34975
	private int GiftId;

	// Token: 0x040088A0 RID: 34976
	private long DayEndTime;

	// Token: 0x040088A1 RID: 34977
	private long WeekEndTime;

	// Token: 0x040088A2 RID: 34978
	public List<BattlePassRewardData> RewardDataList;

	// Token: 0x040088A3 RID: 34979
	public int BattlePassId;

	// Token: 0x040088A4 RID: 34980
	private int MaxLevel;

	// Token: 0x040088A5 RID: 34981
	public List<int> StageLevelList;

	// Token: 0x040088A6 RID: 34982
	private int CurrentBattlePassLevel;

	// Token: 0x040088A7 RID: 34983
	private int CurrentWeekExp;

	// Token: 0x040088A8 RID: 34984
	private int CurrentLevelExp;

	// Token: 0x040088A9 RID: 34985
	private BattlePassPayStatus BattlePassType;

	// Token: 0x040088AA RID: 34986
	private long BattlePassStartTime;

	// Token: 0x040088AB RID: 34987
	private long BattlePassEndTime;

	// Token: 0x040088AC RID: 34988
	private int MaxWeekExp;

	// Token: 0x040088AD RID: 34989
	private int MaxLevelExp;

	// Token: 0x040088AE RID: 34990
	public Dictionary<int, BattlePassTaskData> BattlePassTaskMap;

	// Token: 0x040088AF RID: 34991
	private int? RemindLevelInternal;
}
