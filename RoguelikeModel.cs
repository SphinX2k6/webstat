using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;
using CSharpScript.Game.Module.DreamLink;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Module.Roguelike;

// Token: 0x02002786 RID: 10118
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RoguelikeModel : ModelBase<RoguelikeModel>
{
	// Token: 0x06013F5D RID: 81757 RVA: 0x00590346 File Offset: 0x0058E546
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06013F5E RID: 81758 RVA: 0x00590349 File Offset: 0x0058E549
	protected override bool OnClear()
	{
		this.RoguelikeChooseDataMap.Clear();
		this.RogueInfoInternal = null;
		return true;
	}

	// Token: 0x17001970 RID: 6512
	// (get) Token: 0x06013F5F RID: 81759 RVA: 0x0059035E File Offset: 0x0058E55E
	// (set) Token: 0x06013F60 RID: 81760 RVA: 0x00590366 File Offset: 0x0058E566
	public List<int> EditFormationRoleList
	{
		get
		{
			return this.EditFormationRoleListInternal;
		}
		set
		{
			this.EditFormationRoleListInternal = value;
		}
	}

	// Token: 0x17001971 RID: 6513
	// (get) Token: 0x06013F61 RID: 81761 RVA: 0x0059036F File Offset: 0x0058E56F
	// (set) Token: 0x06013F62 RID: 81762 RVA: 0x00590377 File Offset: 0x0058E577
	public int CurIndex
	{
		get
		{
			return this.CurIndexInternal;
		}
		set
		{
			this.CurIndexInternal = value;
		}
	}

	// Token: 0x17001972 RID: 6514
	// (get) Token: 0x06013F63 RID: 81763 RVA: 0x00590380 File Offset: 0x0058E580
	// (set) Token: 0x06013F64 RID: 81764 RVA: 0x00590388 File Offset: 0x0058E588
	public CSharpScript.Game.Module.Roguelike.RogueGainEntry CurrentRogueGainEntry
	{
		get
		{
			return this.CurrentRogueGainEntryInternal;
		}
		set
		{
			this.CurrentRogueGainEntryInternal = value;
		}
	}

	// Token: 0x17001973 RID: 6515
	// (get) Token: 0x06013F65 RID: 81765 RVA: 0x00590391 File Offset: 0x0058E591
	// (set) Token: 0x06013F66 RID: 81766 RVA: 0x00590399 File Offset: 0x0058E599
	public RoguelikeInfo RogueInfo
	{
		get
		{
			return this.RogueInfoInternal;
		}
		set
		{
			this.RogueInfoInternal = value;
		}
	}

	// Token: 0x17001974 RID: 6516
	// (get) Token: 0x06013F67 RID: 81767 RVA: 0x005903A2 File Offset: 0x0058E5A2
	// (set) Token: 0x06013F68 RID: 81768 RVA: 0x005903AA File Offset: 0x0058E5AA
	public int CurRoomCount
	{
		get
		{
			return this.CurRoomCountInternal;
		}
		set
		{
			this.CurRoomCountInternal = value;
		}
	}

	// Token: 0x17001975 RID: 6517
	// (get) Token: 0x06013F69 RID: 81769 RVA: 0x005903B3 File Offset: 0x0058E5B3
	// (set) Token: 0x06013F6A RID: 81770 RVA: 0x005903BB File Offset: 0x0058E5BB
	public int TotalRoomCount
	{
		get
		{
			return this.TotalRoomCountInternal;
		}
		set
		{
			this.TotalRoomCountInternal = value;
		}
	}

	// Token: 0x17001976 RID: 6518
	// (get) Token: 0x06013F6B RID: 81771 RVA: 0x005903C4 File Offset: 0x0058E5C4
	// (set) Token: 0x06013F6C RID: 81772 RVA: 0x005903CC File Offset: 0x0058E5CC
	public RoguelikeRoomType? CurRoomType
	{
		get
		{
			return this.CurRoomTypeInternal;
		}
		set
		{
			this.CurRoomTypeInternal = value;
		}
	}

	// Token: 0x17001977 RID: 6519
	// (get) Token: 0x06013F6D RID: 81773 RVA: 0x005903D5 File Offset: 0x0058E5D5
	// (set) Token: 0x06013F6E RID: 81774 RVA: 0x005903E2 File Offset: 0x0058E5E2
	[Nullable(1)]
	public string CurRoomMusicState
	{
		[NullableContext(1)]
		get
		{
			return this.CurRoomMusicStateInternal.State;
		}
		[NullableContext(1)]
		set
		{
			this.CurRoomMusicStateInternal.State = (value ?? "none");
		}
	}

	// Token: 0x17001978 RID: 6520
	// (get) Token: 0x06013F6F RID: 81775 RVA: 0x005903F9 File Offset: 0x0058E5F9
	[Nullable(1)]
	public Dictionary<int, int> RoguelikeCurrencyDictMap
	{
		[NullableContext(1)]
		get
		{
			return this.RoguelikeCurrencyDict;
		}
	}

	// Token: 0x06013F70 RID: 81776 RVA: 0x00590404 File Offset: 0x0058E604
	public RoleDataBase GetRoguelikeRoleData(int rogueRoleId)
	{
		RogueCharacter? rogueCharacterConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueCharacterConfig(rogueRoleId);
		if (rogueCharacterConfig == null)
		{
			return null;
		}
		int roleId = rogueCharacterConfig.Value.RoleId;
		int trialRoleId = rogueCharacterConfig.Value.TrialRoleId;
		RoleInstance roleInstanceById = ModelBase<RoleModel>.Instance.GetRoleInstanceById(roleId);
		if (roleInstanceById != null)
		{
			return roleInstanceById;
		}
		if (trialRoleId == 0)
		{
			return null;
		}
		RoleRobotData roleRobotData = ModelBase<RoleModel>.Instance.GetRoleRobotData(trialRoleId);
		if (roleRobotData != null)
		{
			return roleRobotData;
		}
		return null;
	}

	// Token: 0x06013F71 RID: 81777 RVA: 0x00590475 File Offset: 0x0058E675
	public void SetRoguelikeCurrency(int id, int count)
	{
		this.RoguelikeCurrencyDict[id] = count;
	}

	// Token: 0x06013F72 RID: 81778 RVA: 0x00590484 File Offset: 0x0058E684
	public void UpdateRoguelikeCurrency(int id, int addCount)
	{
		int roguelikeCurrency = this.GetRoguelikeCurrency(id);
		this.RoguelikeCurrencyDict[id] = roguelikeCurrency + addCount;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPlayerCurrencyChange, id);
	}

	// Token: 0x06013F73 RID: 81779 RVA: 0x005904BC File Offset: 0x0058E6BC
	public int GetRoguelikeCurrency(int currencyId)
	{
		int result;
		if (!this.RoguelikeCurrencyDict.TryGetValue(currencyId, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x06013F74 RID: 81780 RVA: 0x005904DC File Offset: 0x0058E6DC
	public int GetRoguelikeInventoryCurrency(int currencyId)
	{
		if (currencyId == 80100000 && ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
		{
			return ModelBase<WeeklyRogueModel>.Instance.GetCurrency(currencyId);
		}
		int result;
		if (!this.RoguelikeCurrencyDict.TryGetValue(currencyId, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x06013F75 RID: 81781 RVA: 0x0059051C File Offset: 0x0058E71C
	public void UpdateDescModel(bool isSimple)
	{
		EDescModel descMode = isSimple ? EDescModel.SIMPLE : EDescModel.DETAIL;
		this.DescMode = descMode;
		Singleton<EventSystem>.Instance.Emit(EEventName.RoguelikeDataUpdate);
	}

	// Token: 0x06013F76 RID: 81782 RVA: 0x00590548 File Offset: 0x0058E748
	public EDescModel GetDescModel()
	{
		return this.DescMode;
	}

	// Token: 0x06013F77 RID: 81783 RVA: 0x00590550 File Offset: 0x0058E750
	public RoguelikeEntranceViewModel GetEntranceViewModel()
	{
		if (this.EntranceViewModel == null)
		{
			this.EntranceViewModel = new RoguelikeEntranceViewModel();
		}
		return this.EntranceViewModel;
	}

	// Token: 0x06013F78 RID: 81784 RVA: 0x0059056B File Offset: 0x0058E76B
	public void ClearEntranceViewModel()
	{
		this.EntranceViewModel = null;
	}

	// Token: 0x06013F79 RID: 81785 RVA: 0x00590574 File Offset: 0x0058E774
	[NullableContext(1)]
	public void SetRoguelikeChooseData(IReadOnlyList<Aki.Protocol.RoguelikeChooseData> roguelikeChooseData)
	{
		foreach (Aki.Protocol.RoguelikeChooseData roguelikeChooseData2 in roguelikeChooseData)
		{
			this.RoguelikeChooseDataMap[roguelikeChooseData2.Index] = new CSharpScript.Game.Module.Roguelike.RoguelikeChooseData(roguelikeChooseData2);
		}
	}

	// Token: 0x06013F7A RID: 81786 RVA: 0x005905CC File Offset: 0x0058E7CC
	public CSharpScript.Game.Module.Roguelike.RoguelikeChooseData GetRoguelikeChooseDataById(int bindId)
	{
		CSharpScript.Game.Module.Roguelike.RoguelikeChooseData result;
		this.RoguelikeChooseDataMap.TryGetValue(bindId, out result);
		return result;
	}

	// Token: 0x06013F7B RID: 81787 RVA: 0x005905EC File Offset: 0x0058E7EC
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1,
		1
	})]
	public ValueTuple<List<CSharpScript.Game.Module.Roguelike.ElementInfo>, Dictionary<EElementType, CSharpScript.Game.Module.Roguelike.ElementInfo>> GetSortElementInfoArrayMap(Dictionary<int, int> addElementDict = null)
	{
		int num = 9;
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (KeyValuePair<int, int> keyValuePair in this.RogueInfo.ElementDict)
		{
			int num2;
			int num3;
			keyValuePair.Deconstruct(out num2, out num3);
			int num4 = num2;
			int value = num3;
			if (num4 != num)
			{
				dictionary[num4] = value;
			}
		}
		if (addElementDict != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in addElementDict)
			{
				int num2;
				int num3;
				keyValuePair.Deconstruct(out num3, out num2);
				int num5 = num3;
				int num6 = num2;
				if (num5 != num)
				{
					int num8;
					int num7 = dictionary.TryGetValue(num5, out num8) ? num8 : 0;
					dictionary[num5] = num7 + num6;
				}
			}
		}
		List<CSharpScript.Game.Module.Roguelike.ElementInfo> list = new List<CSharpScript.Game.Module.Roguelike.ElementInfo>();
		Dictionary<EElementType, CSharpScript.Game.Module.Roguelike.ElementInfo> dictionary2 = new Dictionary<EElementType, CSharpScript.Game.Module.Roguelike.ElementInfo>();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int num2;
			int num3;
			keyValuePair.Deconstruct(out num2, out num3);
			int num9 = num2;
			int count = num3;
			CSharpScript.Game.Module.Roguelike.ElementInfo elementInfo = new CSharpScript.Game.Module.Roguelike.ElementInfo(num9, count, null);
			if (addElementDict != null)
			{
				int num10;
				elementInfo.IsPreview = ((addElementDict.TryGetValue(num9, out num10) ? num10 : 0) > 0);
			}
			list.Add(elementInfo);
			dictionary2[(EElementType)elementInfo.ElementId] = elementInfo;
		}
		list.Sort((CSharpScript.Game.Module.Roguelike.ElementInfo a, CSharpScript.Game.Module.Roguelike.ElementInfo b) => b.Count - a.Count);
		return new ValueTuple<List<CSharpScript.Game.Module.Roguelike.ElementInfo>, Dictionary<EElementType, CSharpScript.Game.Module.Roguelike.ElementInfo>>(list, dictionary2);
	}

	// Token: 0x06013F7C RID: 81788 RVA: 0x005907A4 File Offset: 0x0058E9A4
	public bool CheckInRoguelike()
	{
		DreamLinkData currentActivityData = ControllerBase<DreamLinkController>.Instance.GetCurrentActivityData();
		InstanceDungeon? instanceDungeon;
		return (currentActivityData == null || !currentActivityData.IsDreamLinkInst(ModelBase<CreatureModel>.Instance.GetInstanceId())) && ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId()) != null && instanceDungeon.GetValueOrDefault().InstSubType == 15 && ControllerBase<GameModeController>.Instance.IsInInstance();
	}

	// Token: 0x06013F7D RID: 81789 RVA: 0x00590818 File Offset: 0x0058EA18
	public bool CheckInRoguelikeOnly()
	{
		InstanceDungeon? instanceDungeon;
		return ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId()) != null && instanceDungeon.GetValueOrDefault().InstSubType == 15 && ControllerBase<GameModeController>.Instance.IsInInstance();
	}

	// Token: 0x06013F7E RID: 81790 RVA: 0x00590868 File Offset: 0x0058EA68
	public bool CheckIsGuideDungeon()
	{
		InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
		RogueParam? paramConfigBySeasonId = this.GetParamConfigBySeasonId(null);
		return paramConfigBySeasonId != null && instanceDungeon != null && paramConfigBySeasonId.Value.GuideInstArrayLength > 0 && paramConfigBySeasonId.Value.GuideInstArray().Contains(instanceDungeon.Value.Id);
	}

	// Token: 0x06013F7F RID: 81791 RVA: 0x005908DC File Offset: 0x0058EADC
	public RoguelikeTalentTreeViewModel GetTalentTreeViewModel()
	{
		if (this.TalentTreeViewModel == null)
		{
			this.TalentTreeViewModel = new RoguelikeTalentTreeViewModel();
		}
		return this.TalentTreeViewModel;
	}

	// Token: 0x06013F80 RID: 81792 RVA: 0x005908F7 File Offset: 0x0058EAF7
	public void ClearTalentTreeViewModel()
	{
		this.TalentTreeViewModel = null;
	}

	// Token: 0x17001979 RID: 6521
	// (get) Token: 0x06013F81 RID: 81793 RVA: 0x00590900 File Offset: 0x0058EB00
	[Nullable(1)]
	public Dictionary<int, int> RoguelikeSkillDataMap
	{
		[NullableContext(1)]
		get
		{
			return this.RoguelikeSkillData;
		}
	}

	// Token: 0x06013F82 RID: 81794 RVA: 0x00590908 File Offset: 0x0058EB08
	public void SetRoguelikeSkillData(int skillId, int skillLevel)
	{
		this.RoguelikeSkillData[skillId] = skillLevel;
		RoguelikeTalentTreeViewModel talentTreeViewModel = this.TalentTreeViewModel;
		if (talentTreeViewModel == null)
		{
			return;
		}
		talentTreeViewModel.RefreshLineTypeMap();
	}

	// Token: 0x06013F83 RID: 81795 RVA: 0x00590928 File Offset: 0x0058EB28
	public bool CheckHasCanUnlockSkill()
	{
		RogueParam? paramConfigBySeasonId = this.GetParamConfigBySeasonId(null);
		if (paramConfigBySeasonId == null)
		{
			return false;
		}
		int roguelikeCurrency = this.GetRoguelikeCurrency(paramConfigBySeasonId.Value.SkillPoint);
		foreach (KeyValuePair<int, int> keyValuePair in this.RoguelikeSkillDataMap)
		{
			int num;
			int num2;
			keyValuePair.Deconstruct(out num, out num2);
			int id = num;
			if (num2 == 0)
			{
				RogueTalentTree? rogueTalentTreeById = ConfigBase<RoguelikeConfig>.Instance.GetRogueTalentTreeById(id);
				if (rogueTalentTreeById.Value.ConsuleLength > 0 && rogueTalentTreeById.Value.Consule(0) <= roguelikeCurrency)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06013F84 RID: 81796 RVA: 0x005909F8 File Offset: 0x0058EBF8
	public bool CheckRoguelikeShopRedDot()
	{
		ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
		RogueSeasonData rogueSeasonData = (currentActivityData != null) ? currentActivityData.SeasonData : null;
		if (rogueSeasonData == null)
		{
			return false;
		}
		ActivityRogueData currentActivityData2 = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
		if (currentActivityData2 == null)
		{
			return false;
		}
		RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(rogueSeasonData.SeasonId);
		if (rogueSeasonConfigById == null)
		{
			return false;
		}
		if (currentActivityData2.GetRogueActivityState() != ERogueActivityState.Open)
		{
			return false;
		}
		foreach (PayShopGoods payShopGoods in this.GetPayShopFirstTabGoods(rogueSeasonConfigById.Value.ShopId))
		{
			if (!payShopGoods.IsSoldOut() && !payShopGoods.IsLocked() && payShopGoods.IfCanBuy() && !ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.RoguelikeShopItemChecked, payShopGoods.GetGoodsId()))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06013F85 RID: 81797 RVA: 0x00590AE4 File Offset: 0x0058ECE4
	public bool HasBlackFlowerExchanged(int dungeonId)
	{
		RogueParam? paramConfigBySeasonId = this.GetParamConfigBySeasonId(null);
		return paramConfigBySeasonId != null && paramConfigBySeasonId.Value.BlackFlowerInstList().Contains(dungeonId);
	}

	// Token: 0x06013F86 RID: 81798 RVA: 0x00590B24 File Offset: 0x0058ED24
	public bool HasBlackFlowerDrop()
	{
		RogueParam? paramConfigBySeasonId = this.GetParamConfigBySeasonId(null);
		return paramConfigBySeasonId != null && paramConfigBySeasonId.Value.BlackFlowerDropId != 0;
	}

	// Token: 0x06013F87 RID: 81799 RVA: 0x00590B5E File Offset: 0x0058ED5E
	public bool HasBossChallengeMode()
	{
		return this.GetBossChallengeInstId() != 0;
	}

	// Token: 0x06013F88 RID: 81800 RVA: 0x00590B6C File Offset: 0x0058ED6C
	public int GetBossChallengeInstId()
	{
		ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
		RogueSeasonData rogueSeasonData = (currentActivityData != null) ? currentActivityData.SeasonData : null;
		if (rogueSeasonData == null)
		{
			return 0;
		}
		RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(rogueSeasonData.SeasonId);
		if (rogueSeasonConfigById == null)
		{
			return 0;
		}
		return rogueSeasonConfigById.GetValueOrDefault().ChallengeInstanceId;
	}

	// Token: 0x06013F89 RID: 81801 RVA: 0x00590BC0 File Offset: 0x0058EDC0
	[NullableContext(1)]
	private List<PayShopGoods> GetPayShopFirstTabGoods(int shopId)
	{
		int payShopFirstTabId = ModelBase<PayShopModel>.Instance.GetPayShopFirstTabId((PayShopDefine.EPayShopTabType)shopId);
		return ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)shopId, payShopFirstTabId, false);
	}

	// Token: 0x06013F8A RID: 81802 RVA: 0x00590BE6 File Offset: 0x0058EDE6
	public bool GetMapNoteShowState()
	{
		return false;
	}

	// Token: 0x06013F8B RID: 81803 RVA: 0x00590BEC File Offset: 0x0058EDEC
	public void RecordRoguelikeShopRedDot()
	{
		ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
		RogueSeasonData rogueSeasonData = (currentActivityData != null) ? currentActivityData.SeasonData : null;
		if (rogueSeasonData == null)
		{
			return;
		}
		RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(rogueSeasonData.SeasonId);
		if (rogueSeasonConfigById == null)
		{
			return;
		}
		List<PayShopGoods> payShopFirstTabGoods = this.GetPayShopFirstTabGoods(rogueSeasonConfigById.Value.ShopId);
		bool flag = false;
		foreach (PayShopGoods payShopGoods in payShopFirstTabGoods)
		{
			if (!payShopGoods.IsSoldOut() && !payShopGoods.IsLocked() && payShopGoods.IfCanBuy() && !ModelBase<NewFlagModel>.Instance.HasNewFlag(ELocalStoragePlayerKey.RoguelikeShopItemChecked, payShopGoods.GetGoodsId()))
			{
				ModelBase<NewFlagModel>.Instance.AddNewFlag(ELocalStoragePlayerKey.RoguelikeShopItemChecked, payShopGoods.GetGoodsId());
				flag = true;
			}
		}
		if (flag)
		{
			ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.RoguelikeShopItemChecked);
			Singleton<EventSystem>.Instance.Emit(EEventName.RoguelikeDataUpdate);
		}
	}

	// Token: 0x06013F8C RID: 81804 RVA: 0x00590CF0 File Offset: 0x0058EEF0
	public bool GetRoguelikeAchievementRedDot()
	{
		ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
		RogueSeasonData rogueSeasonData = (currentActivityData != null) ? currentActivityData.SeasonData : null;
		if (rogueSeasonData == null)
		{
			return false;
		}
		RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(rogueSeasonData.SeasonId);
		return ModelBase<AchievementModel>.Instance.GetCategoryRedPointState(rogueSeasonConfigById.Value.Achievement);
	}

	// Token: 0x06013F8D RID: 81805 RVA: 0x00590D48 File Offset: 0x0058EF48
	public bool CheckRogueIsOpen()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.Roguelike) && ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData() != null && ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData().GetRogueActivityState() != ERogueActivityState.Close;
	}

	// Token: 0x06013F8E RID: 81806 RVA: 0x00590D80 File Offset: 0x0058EF80
	public RogueParam? GetParamConfigBySeasonId(int? seasonId = null)
	{
		if (seasonId != null && seasonId.GetValueOrDefault() != 0)
		{
			RogueSeason? rogueSeasonConfigById = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(seasonId.Value);
			return ConfigBase<RoguelikeConfig>.Instance.GetRogueParamConfig(rogueSeasonConfigById.Value.ParamId);
		}
		ActivityRogueData currentActivityData = ControllerBase<ActivityRogueController>.Instance.GetCurrentActivityData();
		RogueSeasonData rogueSeasonData = (currentActivityData != null) ? currentActivityData.SeasonData : null;
		if (rogueSeasonData != null)
		{
			RogueSeason? rogueSeasonConfigById2 = ConfigBase<RoguelikeConfig>.Instance.GetRogueSeasonConfigById(rogueSeasonData.SeasonId);
			return ConfigBase<RoguelikeConfig>.Instance.GetRogueParamConfig(rogueSeasonConfigById2.Value.ParamId);
		}
		return ConfigBase<RoguelikeConfig>.Instance.GetRogueParamConfig(1);
	}

	// Token: 0x04009B75 RID: 39797
	private RoguelikeInfo RogueInfoInternal;

	// Token: 0x04009B76 RID: 39798
	public RogueChallengeModeType? RogueModeType;

	// Token: 0x04009B77 RID: 39799
	private int CurIndexInternal;

	// Token: 0x04009B78 RID: 39800
	private CSharpScript.Game.Module.Roguelike.RogueGainEntry CurrentRogueGainEntryInternal;

	// Token: 0x04009B79 RID: 39801
	private int CurRoomCountInternal;

	// Token: 0x04009B7A RID: 39802
	private int TotalRoomCountInternal;

	// Token: 0x04009B7B RID: 39803
	private RoguelikeRoomType? CurRoomTypeInternal;

	// Token: 0x04009B7C RID: 39804
	[Nullable(1)]
	private readonly StateRef CurRoomMusicStateInternal = new StateRef("game_rogue_room_type", "none");

	// Token: 0x04009B7D RID: 39805
	private List<int> EditFormationRoleListInternal;

	// Token: 0x04009B7E RID: 39806
	[Nullable(1)]
	private readonly Dictionary<int, CSharpScript.Game.Module.Roguelike.RoguelikeChooseData> RoguelikeChooseDataMap = new Dictionary<int, CSharpScript.Game.Module.Roguelike.RoguelikeChooseData>();

	// Token: 0x04009B7F RID: 39807
	[Nullable(1)]
	private readonly Dictionary<int, int> RoguelikeSkillData = new Dictionary<int, int>();

	// Token: 0x04009B80 RID: 39808
	[Nullable(1)]
	private readonly Dictionary<int, int> RoguelikeCurrencyDict = new Dictionary<int, int>();

	// Token: 0x04009B81 RID: 39809
	public long? TempCountdown;

	// Token: 0x04009B82 RID: 39810
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<RewardItemData> ShowRewardList;

	// Token: 0x04009B83 RID: 39811
	public int? CurDungeonId;

	// Token: 0x04009B84 RID: 39812
	private EDescModel DescMode;

	// Token: 0x04009B85 RID: 39813
	[Nullable(1)]
	public List<int> SelectRoleViewShowRoleList = new List<int>();

	// Token: 0x04009B86 RID: 39814
	[Nullable(1)]
	public List<int> SelectRoleViewRecommendRoleList = new List<int>();

	// Token: 0x04009B87 RID: 39815
	public int? CurRoomId;

	// Token: 0x04009B88 RID: 39816
	public string CurRoomTypeId;

	// Token: 0x04009B89 RID: 39817
	private RoguelikeEntranceViewModel EntranceViewModel;

	// Token: 0x04009B8A RID: 39818
	private RoguelikeTalentTreeViewModel TalentTreeViewModel;
}
