using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.InstanceDungeon.Define;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Personal;
using CSharpScript.Game.Module.TowerDefence;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002BC7 RID: 11207
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class TowerDefenseController : ActivityControllerBase<TowerDefenseController>
{
	// Token: 0x06016540 RID: 91456 RVA: 0x0062F9BA File Offset: 0x0062DBBA
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return ModelBase<TowerDefenseModel>.Instance.GetOrCreateParsedTowerDefenseMsg();
	}

	// Token: 0x06016541 RID: 91457 RVA: 0x0062F9C6 File Offset: 0x0062DBC6
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new TowerDefenseSubView();
	}

	// Token: 0x06016542 RID: 91458 RVA: 0x0062F9CD File Offset: 0x0062DBCD
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_LordGymMainA";
	}

	// Token: 0x06016543 RID: 91459 RVA: 0x0062F9D4 File Offset: 0x0062DBD4
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TowerDefenseLevelView);
	}

	// Token: 0x06016544 RID: 91460 RVA: 0x0062F9E8 File Offset: 0x0062DBE8
	protected override void OnOpenView(ActivityBaseData data)
	{
		if (!data.GetPreGuideQuestFinishState())
		{
			int unFinishPreGuideQuestId = data.GetUnFinishPreGuideQuestId();
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, unFinishPreGuideQuestId, null);
			return;
		}
		TowerDefenseConfig? towerDefenseConfigByActivityId = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigByActivityId(data.Id);
		if (towerDefenseConfigByActivityId.Value.EntranceId != 0)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(towerDefenseConfigByActivityId.Value.EntranceId, 0, null);
			return;
		}
		WorldMapViewOpenParams data2 = new WorldMapViewOpenParams
		{
			MarkId = new int?(ControllerBase<TowerDefenseController>.Instance.GetMarkIdByActivityId(data.Id)),
			MarkType = EMarkType.None,
			OpenFogId = new int?(0)
		};
		ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data2, null);
	}

	// Token: 0x06016545 RID: 91461 RVA: 0x0062FA9C File Offset: 0x0062DC9C
	[NullableContext(0)]
	protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
	{
		TowerDefenseController.<OnOpenSubView>d__5 <OnOpenSubView>d__;
		<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OnOpenSubView>d__.viewName = viewName;
		<OnOpenSubView>d__.<>1__state = -1;
		<OnOpenSubView>d__.<>t__builder.Start<TowerDefenseController.<OnOpenSubView>d__5>(ref <OnOpenSubView>d__);
		return <OnOpenSubView>d__.<>t__builder.Task;
	}

	// Token: 0x06016546 RID: 91462 RVA: 0x0062FAE0 File Offset: 0x0062DCE0
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshEditBattleRoleSlotData, new Action<ERefreshEditBattleRoleSlotDataReason>(this.HandleOnRefreshEditBattleRoleSlotData));
		Singleton<EventSystem>.Instance.Add(EEventName.TowerDefenseBeforeConfirmQuickRoleSelect, new Action(this.HandleBeforeConfirmQuickRoleSelect));
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.HandleOnChangeRole));
		Singleton<EventSystem>.Instance.Add(EEventName.EnterInstanceDungeon, new Action(this.HandleEnterInstanceDungeon));
		Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeon, new Action(this.HandleLeaveInstanceDungeon));
		Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceExternalConfirm, new Action(this.HandleLeaveInstanceExternalConfirm));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleScoreChanged, new Action<int, int>(this.HandleBattleScoreChanged));
		Singleton<EventSystem>.Instance.Add(EEventName.OnBeforeDestroyInstanceDungeonEntranceView, new Action(this.HandleOnBeforeDestroyInstanceDungeonEntranceView));
		Singleton<EventSystem>.Instance.Add(EEventName.TowerDefenseSelfPhantomConfirm, new Action<int>(this.HandleTowerDefenseSelfPhantomConfirm));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.HandleWorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.HandleCloseView));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSelectInstanceIdChallenge, new Action<int>(this.OnSelectInstanceIdChallenge));
	}

	// Token: 0x06016547 RID: 91463 RVA: 0x0062FC3C File Offset: 0x0062DE3C
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshEditBattleRoleSlotData, new Action<ERefreshEditBattleRoleSlotDataReason>(this.HandleOnRefreshEditBattleRoleSlotData));
		Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefenseBeforeConfirmQuickRoleSelect, new Action(this.HandleBeforeConfirmQuickRoleSelect));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.HandleOnChangeRole));
		Singleton<EventSystem>.Instance.Remove(EEventName.EnterInstanceDungeon, new Action(this.HandleEnterInstanceDungeon));
		Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeon, new Action(this.HandleLeaveInstanceDungeon));
		Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceExternalConfirm, new Action(this.HandleLeaveInstanceExternalConfirm));
		Singleton<EventSystem>.Instance.Remove(EEventName.BattleScoreChanged, new Action<int, int>(this.HandleBattleScoreChanged));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBeforeDestroyInstanceDungeonEntranceView, new Action(this.HandleOnBeforeDestroyInstanceDungeonEntranceView));
		Singleton<EventSystem>.Instance.Remove(EEventName.TowerDefenseSelfPhantomConfirm, new Action<int>(this.HandleTowerDefenseSelfPhantomConfirm));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.HandleWorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.HandleCloseView));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectInstanceIdChallenge, new Action<int>(this.OnSelectInstanceIdChallenge));
	}

	// Token: 0x06016548 RID: 91464 RVA: 0x0062FD98 File Offset: 0x0062DF98
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<TowerDefenceInfoUpdateNotify>(ENotifyMessageId.TowerDefenceInfoUpdateNotify, new Action<TowerDefenceInfoUpdateNotify, Net.CallbackStatus>(this.OnActivityInfoUpdateNotify));
		Singleton<Net>.Instance.Register<TowerDefenceInstanceInfoUpdateNotify>(ENotifyMessageId.TowerDefenceInstanceInfoUpdateNotify, new Action<TowerDefenceInstanceInfoUpdateNotify, Net.CallbackStatus>(this.OnInstanceInfoUpdateNotify));
		Singleton<Net>.Instance.Register<TowerDefencePhantomInfoUpdateNotify>(ENotifyMessageId.TowerDefencePhantomInfoUpdateNotify, new Action<TowerDefencePhantomInfoUpdateNotify, Net.CallbackStatus>(this.OnPhantomInfoUpdateNotify));
		Singleton<Net>.Instance.Register<TowerDefenceEndNotify>(ENotifyMessageId.TowerDefenceEndNotify, new Action<TowerDefenceEndNotify, Net.CallbackStatus>(this.OnTowerDefenseBattleEndNotify));
		Singleton<Net>.Instance.Register<TowerDefenceEnterInstNotify>(ENotifyMessageId.TowerDefenceEnterInstNotify, new Action<TowerDefenceEnterInstNotify, Net.CallbackStatus>(this.OnEnterInstNotify));
		Singleton<Net>.Instance.Register<TowerDefenceRoleReviveNotify>(ENotifyMessageId.TowerDefenceRoleReviveNotify, new Action<TowerDefenceRoleReviveNotify, Net.CallbackStatus>(this.OnRoleReviveNotify));
		Singleton<Net>.Instance.Register<TowerDefencePlayerReviveNotify>(ENotifyMessageId.TowerDefencePlayerReviveNotify, new Action<TowerDefencePlayerReviveNotify, Net.CallbackStatus>(this.OnPlayerReviveNotify));
	}

	// Token: 0x06016549 RID: 91465 RVA: 0x0062FE6C File Offset: 0x0062E06C
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TowerDefenceInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TowerDefenceInstanceInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TowerDefencePhantomInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TowerDefenceEndNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TowerDefenceEnterInstNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TowerDefenceRoleReviveNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TowerDefencePlayerReviveNotify);
	}

	// Token: 0x0601654A RID: 91466 RVA: 0x0062FEE9 File Offset: 0x0062E0E9
	public override bool GetActivityLevelUnlockState(int levelId)
	{
		return this.CheckIsInstanceUnlock(levelId);
	}

	// Token: 0x0601654B RID: 91467 RVA: 0x0062FEF2 File Offset: 0x0062E0F2
	public TowerDefencePhantomIconItem BuildPhantomIconItem()
	{
		return new TowerDefencePhantomIconItem();
	}

	// Token: 0x0601654C RID: 91468 RVA: 0x0062FEF9 File Offset: 0x0062E0F9
	public TowerDefensePhantomSkillItem BuildPhantomSkillItem()
	{
		return new TowerDefensePhantomSkillItem();
	}

	// Token: 0x0601654D RID: 91469 RVA: 0x0062FF00 File Offset: 0x0062E100
	public TowerDefenseInBattleInfoItem BuildPhantomSkillInBattleItem()
	{
		return new TowerDefenseInBattleInfoItem();
	}

	// Token: 0x0601654E RID: 91470 RVA: 0x0062FF08 File Offset: 0x0062E108
	public List<PhantomSmallItemGrid> BuildPhantomIconScrollData()
	{
		List<PhantomSmallItemGrid> list = new List<PhantomSmallItemGrid>();
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		List<ITowerDefensePhantomConfig> sortedPhantomConfigCache = instance.SortedPhantomConfigCache;
		InstanceDungeonEntranceModel instance2 = ModelBase<InstanceDungeonEntranceModel>.Instance;
		Dictionary<long, EMultiPlayerSlot> dictionary = null;
		if (this.CheckIsInMatch())
		{
			dictionary = new Dictionary<long, EMultiPlayerSlot>();
			foreach (PrewarFormationData prewarFormationData in ModelBase<InstanceDungeonModel>.Instance.GetPrewarFormationDataList())
			{
				dictionary[(long)prewarFormationData.GetPlayerId()] = (EMultiPlayerSlot)prewarFormationData.GetOnlineNumber();
			}
		}
		foreach (ITowerDefensePhantomConfig towerDefensePhantomConfig in sortedPhantomConfigCache)
		{
			if (instance.CheckPhantomAvailableInActivityByActivityId(towerDefensePhantomConfig.ActivityId))
			{
				Aki.Config.PhantomItem? config = ConfigPhantomItemByItemId.GetConfig(towerDefensePhantomConfig.PhantomItemId, true);
				int num = this.CheckIsInMatch() ? instance2.GetMatchingId() : instance2.SelectInstanceId;
				TowerDefenceInstance? config2 = ConfigTowerDefenceInstanceByInstanceId.GetConfig(num, true);
				if (config2 == null)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Activity;
					ELogAuthor author = ELogAuthor.WZ;
					string message = "副本ID配置错误，无法在塔防副本配置中找到，请检查联机塔防表和副本表";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("选中的副本ID", num);
					instance3.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				bool flag = config2 == null || !config2.Value.OptionalBuff().Contains(towerDefensePhantomConfig.Id);
				TowerDefensePhantomIconItemData towerDefensePhantomIconItemData = new TowerDefensePhantomIconItemData();
				towerDefensePhantomIconItemData.ConfigId = towerDefensePhantomConfig.Id;
				UiResourceConfig instance4 = ConfigBase<UiResourceConfig>.Instance;
				towerDefensePhantomIconItemData.HexColorPath = (((instance4 != null) ? instance4.GetResourcePath(towerDefensePhantomConfig.MarkResourceId) : null) ?? "");
				towerDefensePhantomIconItemData.IsLocked = flag;
				towerDefensePhantomIconItemData.IsChosen = false;
				towerDefensePhantomIconItemData.IsOccupied = instance.CheckPhantomIsOccupied(towerDefensePhantomConfig.Id);
				TowerDefensePhantomIconItemData data = towerDefensePhantomIconItemData;
				SmallItemMultiPlayer multiPlayer = null;
				if (dictionary != null)
				{
					Dictionary<EMultiPlayerSlot, bool> dictionary2 = new Dictionary<EMultiPlayerSlot, bool>();
					foreach (ITowerDefensePhantomDataOwner towerDefensePhantomDataOwner in instance.PhantomOwnerDataList)
					{
						EMultiPlayerSlot key;
						if (towerDefensePhantomDataOwner.PhantomId != 0 && towerDefensePhantomDataOwner.PhantomId == towerDefensePhantomConfig.Id && dictionary.TryGetValue(towerDefensePhantomDataOwner.PlayerId, out key))
						{
							bool flag2;
							dictionary2[key] = (towerDefensePhantomDataOwner.IsSelf || (dictionary2.TryGetValue(key, out flag2) && flag2));
						}
					}
					if (dictionary2.Count > 0)
					{
						List<SmallItemMultiPlayerSlot> list2 = new List<SmallItemMultiPlayerSlot>();
						foreach (KeyValuePair<EMultiPlayerSlot, bool> keyValuePair in dictionary2)
						{
							list2.Add(new SmallItemMultiPlayerSlot
							{
								Seat = keyValuePair.Key,
								IsSelf = keyValuePair.Value
							});
						}
						list2.Sort((SmallItemMultiPlayerSlot a, SmallItemMultiPlayerSlot b) => a.Seat - b.Seat);
						multiPlayer = new SmallItemMultiPlayer
						{
							Players = list2
						};
					}
				}
				PhantomSmallItemGrid item = new PhantomSmallItemGrid
				{
					Data = data,
					PhantomId = new int?(towerDefensePhantomConfig.PhantomItemId),
					QualityId = new int?(config.Value.QualityId),
					IsLockVisibleBlack = new bool?(flag || !instance.IsPhantomViewOpened),
					MultiPlayer = multiPlayer
				};
				list.Add(item);
			}
		}
		list.Sort(new Comparison<PhantomSmallItemGrid>(this.PhantomIconSorter));
		return list;
	}

	// Token: 0x0601654F RID: 91471 RVA: 0x006302CC File Offset: 0x0062E4CC
	public void MarkPhantomIconScrollDataChosen(List<PhantomSmallItemGrid> data, bool isFirstTime, int roleCfgId)
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
		ITowerDefensePhantomDataOwner ownerData = instance.GetOwnerData(value, roleCfgId);
		if (isFirstTime)
		{
			if (ownerData == null || ownerData.PhantomId == 0)
			{
				using (List<PhantomSmallItemGrid>.Enumerator enumerator = data.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						PhantomSmallItemGrid phantomSmallItemGrid = enumerator.Current;
						ITowerDefensePhantomIconItemData towerDefensePhantomIconItemData = phantomSmallItemGrid.Data as ITowerDefensePhantomIconItemData;
						if (!towerDefensePhantomIconItemData.IsOccupied && !towerDefensePhantomIconItemData.IsLocked)
						{
							instance.CurrentSelfPhantomIdInUiTemp = towerDefensePhantomIconItemData.ConfigId;
							break;
						}
					}
					goto IL_93;
				}
			}
			instance.CurrentSelfPhantomIdInUiTemp = ownerData.PhantomId;
		}
		IL_93:
		foreach (PhantomSmallItemGrid phantomSmallItemGrid2 in data)
		{
			ITowerDefensePhantomIconItemData towerDefensePhantomIconItemData2 = phantomSmallItemGrid2.Data as ITowerDefensePhantomIconItemData;
			towerDefensePhantomIconItemData2.IsChosen = (instance.CurrentSelfPhantomIdInUiTemp == towerDefensePhantomIconItemData2.ConfigId);
		}
	}

	// Token: 0x06016550 RID: 91472 RVA: 0x006303D4 File Offset: 0x0062E5D4
	public bool CheckSelfPhantomCancelAble(int roleCfgId)
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
		ITowerDefensePhantomDataOwner ownerData = instance.GetOwnerData(value, roleCfgId);
		return ownerData != null && ownerData.PhantomId != 0 && instance.CurrentSelfPhantomIdInUiTemp == ownerData.PhantomId;
	}

	// Token: 0x06016551 RID: 91473 RVA: 0x00630420 File Offset: 0x0062E620
	public List<ITowerDefensePhantomSkillItemData> BuildPhantomSkillLayoutData()
	{
		List<ITowerDefensePhantomSkillItemData> list = new List<ITowerDefensePhantomSkillItemData>();
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		ITowerDefensePhantomConfig towerDefensePhantomConfig = instance.PhantomConfigCache[instance.CurrentSelfPhantomIdInUiTemp];
		for (int i = 0; i < towerDefensePhantomConfig.SkillDataList.Count; i++)
		{
			ITowerDefensePhantomConfigSkillData towerDefensePhantomConfigSkillData = towerDefensePhantomConfig.SkillDataList[i];
			list.Add(new TowerDefensePhantomSkillItemData
			{
				SkillTextId = towerDefensePhantomConfigSkillData.Name,
				DescriptionTextId = towerDefensePhantomConfigSkillData.Description,
				DescriptionArgs = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescExByPhantomSkillIdAndQuality(towerDefensePhantomConfigSkillData.PhantomSkill, 5).ToList<string>(),
				Level = (i + 1).ToString()
			});
		}
		return list;
	}

	// Token: 0x06016552 RID: 91474 RVA: 0x006304C4 File Offset: 0x0062E6C4
	public ITowerDefensePhantomOtherData BuildPhantomOtherData()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		InstanceDungeonEntranceModel instance2 = ModelBase<InstanceDungeonEntranceModel>.Instance;
		ITowerDefensePhantomConfig towerDefensePhantomConfig = instance.PhantomConfigCache[instance.CurrentSelfPhantomIdInUiTemp];
		if (towerDefensePhantomConfig == null)
		{
			return null;
		}
		TowerDefenceInstance? config = ConfigTowerDefenceInstanceByInstanceId.GetConfig(this.CheckIsInMatch() ? instance2.GetMatchingId() : instance2.SelectInstanceId, true);
		return new TowerDefensePhantomOtherData
		{
			NameTextId = towerDefensePhantomConfig.PhantomNameTextId,
			TypeIconPath = towerDefensePhantomConfig.TypeIconPath,
			TypeTextId = towerDefensePhantomConfig.PhantomTypeTextId,
			IsLocked = (config == null || !config.Value.OptionalBuff().Contains(instance.CurrentSelfPhantomIdInUiTemp))
		};
	}

	// Token: 0x06016553 RID: 91475 RVA: 0x0063056C File Offset: 0x0062E76C
	public PhantomSmallItemGrid BuildPhantomIconInBattleData()
	{
		TowerDefencePhantom? config = ConfigTowerDefencePhantomById.GetConfig(ModelBase<TowerDefenseModel>.Instance.GetCurrentPhantomIdInBattle(), true);
		int? num = (config != null) ? new int?(config.GetValueOrDefault().PhantomItemId) : null;
		return new PhantomSmallItemGrid
		{
			Data = num,
			PhantomId = num
		};
	}

	// Token: 0x06016554 RID: 91476 RVA: 0x006305CC File Offset: 0x0062E7CC
	public List<ITowerDefensePhantomSkillItemInBattleData> BuildPhantomSkillInBattleLayoutData()
	{
		List<ITowerDefensePhantomSkillItemInBattleData> list = new List<ITowerDefensePhantomSkillItemInBattleData>();
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		List<ITowerDefensePhantomConfigSkillData> currentPhantomSkillCfgListInBattle = instance.GetCurrentPhantomSkillCfgListInBattle();
		int currentPhantomLevelInBattle = instance.GetCurrentPhantomLevelInBattle();
		int num = currentPhantomLevelInBattle - 1;
		bool flag = this.CheckInBossRushInstance();
		bool flag2 = currentPhantomLevelInBattle >= currentPhantomSkillCfgListInBattle.Count;
		for (int i = 0; i < currentPhantomSkillCfgListInBattle.Count; i++)
		{
			if ((flag && !flag2) || i == num)
			{
				ITowerDefensePhantomConfigSkillData towerDefensePhantomConfigSkillData = currentPhantomSkillCfgListInBattle[i];
				list.Add(new TowerDefensePhantomSkillItemInBattleData
				{
					Skill = towerDefensePhantomConfigSkillData.Name,
					Description = towerDefensePhantomConfigSkillData.Description,
					DescriptionArgs = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescExByPhantomSkillIdAndQuality(towerDefensePhantomConfigSkillData.PhantomSkill, 5).ToList<string>(),
					IsUnlock = (currentPhantomLevelInBattle > i),
					IsCurrent = (i == num)
				});
			}
		}
		return list;
	}

	// Token: 0x06016555 RID: 91477 RVA: 0x00630698 File Offset: 0x0062E898
	public int GetCurrentPhantomItemIdInBattle()
	{
		TowerDefencePhantom? config = ConfigTowerDefencePhantomById.GetConfig(ModelBase<TowerDefenseModel>.Instance.GetCurrentPhantomIdInBattle(), true);
		if (config == null)
		{
			return 0;
		}
		return config.GetValueOrDefault().PhantomItemId;
	}

	// Token: 0x06016556 RID: 91478 RVA: 0x006306D0 File Offset: 0x0062E8D0
	public string GetCurrentPhantomQualitySpritePathInBattle()
	{
		Aki.Config.PhantomItem? config = ConfigPhantomItemByItemId.GetConfig(this.GetCurrentPhantomItemIdInBattle(), true);
		InventoryDefine.EQuality key = (InventoryDefine.EQuality)((config != null) ? config.GetValueOrDefault().QualityId : 0);
		string resourceId;
		if (!TowerDefenceDefine.inBattleQualitySpriteKey.TryGetValue(key, out resourceId))
		{
			return "";
		}
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		return ((instance != null) ? instance.GetResourcePath(resourceId) : null) ?? "";
	}

	// Token: 0x06016557 RID: 91479 RVA: 0x00630738 File Offset: 0x0062E938
	[NullableContext(2)]
	public string GetNextLevelUnlockDescriptionInBattle()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		List<ITowerDefensePhantomConfigSkillData> currentPhantomSkillCfgListInBattle = instance.GetCurrentPhantomSkillCfgListInBattle();
		int currentPhantomLevelInBattle = instance.GetCurrentPhantomLevelInBattle();
		if (currentPhantomLevelInBattle < 0 || currentPhantomLevelInBattle >= currentPhantomSkillCfgListInBattle.Count)
		{
			return null;
		}
		return currentPhantomSkillCfgListInBattle[currentPhantomLevelInBattle].UnlockDescription;
	}

	// Token: 0x06016558 RID: 91480 RVA: 0x00630772 File Offset: 0x0062E972
	public string BuildCurrentPhantomNameTextIdInBattle()
	{
		return ModelBase<TowerDefenseModel>.Instance.GetCurrentPhantomNameTextId();
	}

	// Token: 0x06016559 RID: 91481 RVA: 0x0063077E File Offset: 0x0062E97E
	public IActivityRewardViewData BuildPreviewRewardData()
	{
		return ModelBase<TowerDefenseModel>.Instance.GetPreviewRewardData();
	}

	// Token: 0x0601655A RID: 91482 RVA: 0x0063078C File Offset: 0x0062E98C
	public List<TItem> BuildPhantomForInstanceDungeonEntranceData(int instanceId)
	{
		List<TItem> list = new List<TItem>();
		TowerDefenceInstance? config = ConfigTowerDefenceInstanceByInstanceId.GetConfig(instanceId, true);
		if (config == null)
		{
			return list;
		}
		int[] array = config.Value.OptionalBuff();
		for (int i = 0; i < array.Length; i++)
		{
			TowerDefencePhantom? config2 = ConfigTowerDefencePhantomById.GetConfig(array[i], true);
			if (config2 != null)
			{
				InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(config2.Value.PhantomItemId, 0);
				list.Add(new TItem(itemData, 0));
			}
		}
		return list;
	}

	// Token: 0x0601655B RID: 91483 RVA: 0x0063080C File Offset: 0x0062EA0C
	public TowerDefenseRecommendLevel BuildRecommendLevelForInstanceDungeonEntranceData(int instanceId)
	{
		InstanceDungeon? instanceDungeon;
		return new TowerDefenseRecommendLevel
		{
			TextId = "RecommendLevel",
			Level = ((ConfigInstanceDungeonById.GetConfig(instanceId, true) != null) ? instanceDungeon.GetValueOrDefault().RecommendLevel().GetValueOrDefault(1, 0) : 0)
		};
	}

	// Token: 0x0601655C RID: 91484 RVA: 0x0063085C File Offset: 0x0062EA5C
	public string BuildTotalScoreContent()
	{
		int totalScore = ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.TotalScore;
		return totalScore.ToString();
	}

	// Token: 0x0601655D RID: 91485 RVA: 0x00630880 File Offset: 0x0062EA80
	public ITowerDefenseTipsContentInBattle BuildPhantomTipsInBattleData()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		List<ITowerDefensePhantomConfigSkillData> currentPhantomSkillCfgListInBattle = instance.GetCurrentPhantomSkillCfgListInBattle();
		int currentPhantomLevelInBattle = instance.GetCurrentPhantomLevelInBattle();
		ITowerDefensePhantomConfigSkillData towerDefensePhantomConfigSkillData = currentPhantomSkillCfgListInBattle[currentPhantomLevelInBattle - 1];
		return new TowerDefenseTipsContentInBattle
		{
			TitleTextId = towerDefensePhantomConfigSkillData.Name,
			PhantomTextId = towerDefensePhantomConfigSkillData.Name,
			Level = currentPhantomLevelInBattle,
			DescTextId = towerDefensePhantomConfigSkillData.Description,
			DescArgs = instance.GetCurrentPhantomSkillDescriptionArgsInBattle()
		};
	}

	// Token: 0x0601655E RID: 91486 RVA: 0x006308E8 File Offset: 0x0062EAE8
	public string BuildTeamPhantomIconData(int playerId, int roleCfgId)
	{
		ITowerDefensePhantomDataOwner ownerData = ModelBase<TowerDefenseModel>.Instance.GetOwnerData(playerId, roleCfgId);
		if (ownerData == null)
		{
			return null;
		}
		int phantomId = ownerData.PhantomId;
		if (phantomId <= 0)
		{
			return null;
		}
		TowerDefencePhantom? config = ConfigTowerDefencePhantomById.GetConfig(phantomId, true);
		if (config == null)
		{
			return null;
		}
		Aki.Config.PhantomItem? config2 = ConfigPhantomItemByItemId.GetConfig(config.Value.PhantomItemId, true);
		if (config2 == null)
		{
			return null;
		}
		return config2.GetValueOrDefault().IconMiddle;
	}

	// Token: 0x0601655F RID: 91487 RVA: 0x0063095C File Offset: 0x0062EB5C
	private unsafe List<IRewardExploreConfirmButton> BuildRewardButtonList(int recordScore)
	{
		RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
		{
			ButtonTextId = "Text_ButtonTextExit_Text",
			DescriptionTextId = null,
			IsTimeDownCloseView = false,
			IsClickedCloseView = false,
			OnClickedCallback = new Action<int>(this.RewardViewLeftClickCallback)
		};
		RewardExploreConfirmButtonData rewardExploreConfirmButtonData = new RewardExploreConfirmButtonData();
		rewardExploreConfirmButtonData.ButtonTextId = "TowerDefence_Restart";
		rewardExploreConfirmButtonData.DescriptionTextId = "TowerDefence_GPint";
		int num = 1;
		List<object> list = new List<object>(num);
		CollectionsMarshal.SetCount<object>(list, num);
		Span<object> span = CollectionsMarshal.AsSpan<object>(list);
		int index = 0;
		*span[index] = recordScore;
		rewardExploreConfirmButtonData.DescriptionArgs = list;
		rewardExploreConfirmButtonData.IsTimeDownCloseView = false;
		rewardExploreConfirmButtonData.IsClickedCloseView = false;
		rewardExploreConfirmButtonData.OnClickedCallback = new Action<int>(this.RewardViewRightClickCallback);
		RewardExploreConfirmButtonData item2 = rewardExploreConfirmButtonData;
		return new List<IRewardExploreConfirmButton>
		{
			item,
			item2
		};
	}

	// Token: 0x06016560 RID: 91488 RVA: 0x00630A20 File Offset: 0x0062EC20
	public List<int> BuildPhantomIdListByOwnRoleCfgIdList(List<int> roleCfgIdList)
	{
		List<int> list = new List<int>();
		if (this.CheckInUiFlow())
		{
			TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
			int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
			foreach (int roleCfgId in roleCfgIdList)
			{
				ITowerDefensePhantomDataOwner ownerData = instance.GetOwnerData(value, roleCfgId);
				int item = 0;
				if (ownerData != null)
				{
					item = ownerData.PhantomId;
				}
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06016561 RID: 91489 RVA: 0x00630AB4 File Offset: 0x0062ECB4
	[NullableContext(2)]
	public unsafe string BuildInstanceCountDownTextParam(int instanceId)
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		TowerDefenceInstance? config = ConfigTowerDefenceInstanceByInstanceId.GetConfig(instanceId, true);
		if (config == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TowerDefense;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "副本ID与塔防副本表不对应";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InstanceId", instanceId);
			instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage;
		instance.PhantomMessageCache.StageMapCache.TryGetValue(config.Value.Id, out towerDefenseParsedStageMessage);
		if (towerDefenseParsedStageMessage == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.TowerDefense;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "指定塔防副本协议数据不存在";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("InstanceId", instanceId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("TowerDefenseInstanceId", config.Value.Id);
			instance3.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		double num = (double)towerDefenseParsedStageMessage.UnlockTime * Singleton<TimeUtil>.Instance.Millisecond - Singleton<TimeUtil>.Instance.GetServerTime();
		if (num <= 0.0)
		{
			return "";
		}
		double num2 = Math.Max(num, Singleton<TimeUtil>.Instance.Minute);
		CommonDefine.ETimeType value = CommonDefine.ETimeType.Minute;
		CommonDefine.ETimeType value2 = CommonDefine.ETimeType.Minute;
		if (num2 > 86400.0)
		{
			value = CommonDefine.ETimeType.Day;
			value2 = CommonDefine.ETimeType.Day;
		}
		else if (num > 3600.0)
		{
			value = CommonDefine.ETimeType.Hour;
			value2 = CommonDefine.ETimeType.Hour;
		}
		return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num2, new CommonDefine.ETimeType?(value), new CommonDefine.ETimeType?(value2)).CountDownText ?? "";
	}

	// Token: 0x06016562 RID: 91490 RVA: 0x00630C38 File Offset: 0x0062EE38
	public string BuildInstanceCountDownText(int instanceId)
	{
		string text = this.BuildInstanceCountDownTextParam(instanceId);
		if (text == null)
		{
			return null;
		}
		return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("ActivityMowing_UnlockCondition", null), new string[]
		{
			text
		});
	}

	// Token: 0x06016563 RID: 91491 RVA: 0x00630C6C File Offset: 0x0062EE6C
	private int PhantomIconSorter(PhantomSmallItemGrid a, PhantomSmallItemGrid b)
	{
		ITowerDefensePhantomIconItemData towerDefensePhantomIconItemData = a.Data as ITowerDefensePhantomIconItemData;
		ITowerDefensePhantomIconItemData towerDefensePhantomIconItemData2 = b.Data as ITowerDefensePhantomIconItemData;
		if (towerDefensePhantomIconItemData.IsLocked == towerDefensePhantomIconItemData2.IsLocked)
		{
			return towerDefensePhantomIconItemData.ConfigId - towerDefensePhantomIconItemData2.ConfigId;
		}
		if (!towerDefensePhantomIconItemData.IsLocked)
		{
			return -1;
		}
		return 1;
	}

	// Token: 0x06016564 RID: 91492 RVA: 0x00630CB8 File Offset: 0x0062EEB8
	public double GetTotalScoreProgress()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		int maxScoreRewardThreshold = instance.GetMaxScoreRewardThreshold();
		if (maxScoreRewardThreshold <= 0)
		{
			return 0.0;
		}
		double val = (double)instance.PhantomMessageCache.TotalScore / (double)maxScoreRewardThreshold;
		return Math.Min(1.0, Math.Max(0.0, val));
	}

	// Token: 0x06016565 RID: 91493 RVA: 0x00630D10 File Offset: 0x0062EF10
	private void SyncMatchingPhantomId()
	{
		if (!this.CheckInUiFlow() || !this.CheckIsInMatch())
		{
			return;
		}
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		MatchTeamInfo matchTeamInfo = ModelBase<InstanceDungeonModel>.Instance.GetMatchTeamInfo();
		if (matchTeamInfo != null)
		{
			int num = 0;
			foreach (MatchPlayerInfo matchPlayerInfo in matchTeamInfo.PlayerInfos)
			{
				int playerId = matchPlayerInfo.PlayerId;
				foreach (MatchRoleInfo matchRoleInfo in matchPlayerInfo.RoleInfo)
				{
					int roleId = matchRoleInfo.RoleId;
					int towerDefencePhantomId = matchRoleInfo.TowerDefencePhantomId;
					bool flag = this.CheckIsSelf(playerId);
					ITowerDefensePhantomDataOwner towerDefensePhantomDataOwner = instance.PhantomOwnerDataList[num++];
					towerDefensePhantomDataOwner.PlayerId = (long)playerId;
					towerDefensePhantomDataOwner.IsSelf = flag;
					towerDefensePhantomDataOwner.RoleCfgId = roleId;
					towerDefensePhantomDataOwner.RoleSkinId = matchRoleInfo.RoleSkinId;
					towerDefensePhantomDataOwner.PhantomId = towerDefencePhantomId;
					if (flag)
					{
						instance.RoleCfgId2PhantomIdMapCache[roleId] = towerDefencePhantomId;
					}
				}
			}
			for (int i = num; i < 3; i++)
			{
				instance.ResetPhantomOwnerDataByIndex(i);
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefense;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "同步匹配数据时，队伍不足3人，所以将不足的数据重置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("第几个角色是空缺", i);
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}
	}

	// Token: 0x06016566 RID: 91494 RVA: 0x00630E80 File Offset: 0x0062F080
	private void SyncEditBattleTeamModelToOwnerData()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		EditBattleTeamModel instance2 = ModelBase<EditBattleTeamModel>.Instance;
		int i = 0;
		while (i < 3)
		{
			EditBattleRoleSlotData roleSlotData = instance2.GetRoleSlotData(i + 1);
			if (roleSlotData == null)
			{
				goto IL_8F;
			}
			EditBattleRoleData getRoleData = roleSlotData.GetRoleData;
			ITowerDefensePhantomDataOwner towerDefensePhantomDataOwner = instance.PhantomOwnerDataList[i];
			if (getRoleData == null)
			{
				goto IL_8F;
			}
			towerDefensePhantomDataOwner.PlayerId = (long)getRoleData.PlayerId;
			towerDefensePhantomDataOwner.IsSelf = getRoleData.IsSelf;
			towerDefensePhantomDataOwner.RoleCfgId = getRoleData.ConfigId;
			towerDefensePhantomDataOwner.RoleSkinId = getRoleData.SkinId;
			towerDefensePhantomDataOwner.PhantomId = instance.RoleCfgId2PhantomIdMapCache.GetValueOrDefault(getRoleData.ConfigId, 0);
			IL_96:
			i++;
			continue;
			IL_8F:
			instance.ResetPhantomOwnerDataByIndex(i);
			goto IL_96;
		}
	}

	// Token: 0x06016567 RID: 91495 RVA: 0x00630F30 File Offset: 0x0062F130
	private void OpenInBattleTipImplement()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		int currentPhantomIdInBattle = instance.GetCurrentPhantomIdInBattle();
		bool valueOrDefault = instance.PhantomMessageCache.OwnPhantomInBattleNewLevelUpFlagCache.GetValueOrDefault(currentPhantomIdInBattle, false);
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TowerDefenseInBattleTips) && valueOrDefault)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerDefenseInBattleTips, null, null);
		}
	}

	// Token: 0x06016568 RID: 91496 RVA: 0x00630F84 File Offset: 0x0062F184
	[NullableContext(0)]
	public UniTask<bool> EnterTowerDefense()
	{
		TowerDefenseController.<EnterTowerDefense>d__40 <EnterTowerDefense>d__;
		<EnterTowerDefense>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<EnterTowerDefense>d__.<>1__state = -1;
		<EnterTowerDefense>d__.<>t__builder.Start<TowerDefenseController.<EnterTowerDefense>d__40>(ref <EnterTowerDefense>d__);
		return <EnterTowerDefense>d__.<>t__builder.Task;
	}

	// Token: 0x06016569 RID: 91497 RVA: 0x00630FC0 File Offset: 0x0062F1C0
	public void RequestScoreReward(IReadOnlyList<int> rewardIds)
	{
		if (rewardIds.Count == 0)
		{
			return;
		}
		TowerDefenceScoreRewardRequest towerDefenceScoreRewardRequest = TowerDefenceScoreRewardRequest.Create();
		TowerDefenseModel model = ModelBase<TowerDefenseModel>.Instance;
		foreach (int item in rewardIds)
		{
			towerDefenceScoreRewardRequest.Ids.Add(item);
		}
		Singleton<Net>.Instance.CallAsync<TowerDefenceScoreRewardResponse>(ERequestMessageId.TowerDefenceScoreRewardRequest, towerDefenceScoreRewardRequest, 0).ContinueWith(delegate(TowerDefenceScoreRewardResponse response)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				foreach (int rewardId in rewardIds)
				{
					model.PhantomMessageCache.UpdateByScoreRewardRequest(rewardId);
				}
				Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, model.GetPreviewRewardData());
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, model.PhantomMessageCache.Id);
			}
		});
	}

	// Token: 0x0601656A RID: 91498 RVA: 0x00631064 File Offset: 0x0062F264
	public void RequestInstanceReward(IReadOnlyList<int> instanceIds)
	{
		if (instanceIds.Count == 0)
		{
			return;
		}
		TowerDefenceInstanceRewardRequest towerDefenceInstanceRewardRequest = TowerDefenceInstanceRewardRequest.Create();
		TowerDefenseModel model = ModelBase<TowerDefenseModel>.Instance;
		foreach (int item in instanceIds)
		{
			towerDefenceInstanceRewardRequest.Ids.Add(item);
		}
		Singleton<Net>.Instance.CallAsync<TowerDefenceInstanceRewardResponse>(ERequestMessageId.TowerDefenceInstanceRewardRequest, towerDefenceInstanceRewardRequest, 0).ContinueWith(delegate(TowerDefenceInstanceRewardResponse response)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.Success)
			{
				foreach (int instanceId in instanceIds)
				{
					model.PhantomMessageCache.UpdateByInstanceRewardRequest(instanceId);
				}
				Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, model.GetPreviewRewardData());
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, model.PhantomMessageCache.Id);
			}
		});
	}

	// Token: 0x0601656B RID: 91499 RVA: 0x00631108 File Offset: 0x0062F308
	public UniTask RequestSelfRankData(int activityId)
	{
		TowerDefenseController.<RequestSelfRankData>d__43 <RequestSelfRankData>d__;
		<RequestSelfRankData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestSelfRankData>d__.activityId = activityId;
		<RequestSelfRankData>d__.<>1__state = -1;
		<RequestSelfRankData>d__.<>t__builder.Start<TowerDefenseController.<RequestSelfRankData>d__43>(ref <RequestSelfRankData>d__);
		return <RequestSelfRankData>d__.<>t__builder.Task;
	}

	// Token: 0x0601656C RID: 91500 RVA: 0x0063114C File Offset: 0x0062F34C
	public UniTask RequestRankList(int levelId)
	{
		TowerDefenseController.<RequestRankList>d__44 <RequestRankList>d__;
		<RequestRankList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestRankList>d__.levelId = levelId;
		<RequestRankList>d__.<>1__state = -1;
		<RequestRankList>d__.<>t__builder.Start<TowerDefenseController.<RequestRankList>d__44>(ref <RequestRankList>d__);
		return <RequestRankList>d__.<>t__builder.Task;
	}

	// Token: 0x0601656D RID: 91501 RVA: 0x00631190 File Offset: 0x0062F390
	public void RequestRankShowName(bool isShowName, Action callback = null)
	{
		TowerDefenceRankShowNameRequest towerDefenceRankShowNameRequest = TowerDefenceRankShowNameRequest.Create();
		towerDefenceRankShowNameRequest.ShowName = isShowName;
		Singleton<Net>.Instance.Call<TowerDefenceRankShowNameResponse>(ERequestMessageId.TowerDefenceRankShowNameRequest, towerDefenceRankShowNameRequest, delegate(TowerDefenceRankShowNameResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24645, null, true, true);
				return;
			}
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		}, 0);
	}

	// Token: 0x0601656E RID: 91502 RVA: 0x006311D4 File Offset: 0x0062F3D4
	private void OnActivityInfoUpdateNotify(TowerDefenceInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		if (notify.ActivityInfo == null)
		{
			return;
		}
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		instance.PhantomMessageCache.ParseTowerDefenseActivityData(notify.ActivityInfo);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, instance.PhantomMessageCache.Id);
		Singleton<EventSystem>.Instance.Emit(EEventName.TowerDefenseOnActivityInfoUpdateNotify);
	}

	// Token: 0x0601656F RID: 91503 RVA: 0x0063122C File Offset: 0x0062F42C
	private void OnInstanceInfoUpdateNotify(TowerDefenceInstanceInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.ParseTowerDefenseInstanceDataList(notify.InstanceInfos.ToList<TowerDefenceInstanceInfo>(), false);
		Singleton<EventSystem>.Instance.Emit(EEventName.TowerDefenseOnInstanceInfoUpdateNotify);
	}

	// Token: 0x06016570 RID: 91504 RVA: 0x00631259 File Offset: 0x0062F459
	private void OnPhantomInfoUpdateNotify(TowerDefencePhantomInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.ParseTowerDefenseOwnPhantomDataList(notify.Phantoms.ToList<TowerDefencePhantomInfo>());
		Singleton<EventSystem>.Instance.Emit(EEventName.TowerDefenseOnPhantomInfoUpdateNotify);
		this.OpenInBattleTipImplement();
	}

	// Token: 0x06016571 RID: 91505 RVA: 0x0063128B File Offset: 0x0062F48B
	private void OnTowerDefenseBattleEndNotify(TowerDefenceEndNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		if (ModelBase<GameModeModel>.Instance.WorldDoneAndLoadingClosed)
		{
			this.HandleEndNotifyImplement(notify);
			return;
		}
		ModelBase<TowerDefenseModel>.Instance.DelayedEndNotify = notify;
	}

	// Token: 0x06016572 RID: 91506 RVA: 0x006312AC File Offset: 0x0062F4AC
	private void OnEnterInstNotify(TowerDefenceEnterInstNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		instance.ResetPhantomOwnerDataList();
		for (int i = 0; i < notify.RoleList.Count; i++)
		{
			TowerDefenceRoleInfo towerDefenceRoleInfo = notify.RoleList[i];
			ITowerDefensePhantomDataOwner towerDefensePhantomDataOwner = instance.PhantomOwnerDataList[i];
			TowerDefencePhantomInfo phantom = towerDefenceRoleInfo.Phantom;
			int id = phantom.Id;
			towerDefensePhantomDataOwner.RoleCfgId = towerDefenceRoleInfo.RoleId;
			towerDefensePhantomDataOwner.PhantomId = id;
			instance.PhantomMessageCache.OwnPhantomInBattleDataCache[id] = phantom;
		}
		ModelBase<BattleUiModel>.Instance.RegisterTopPanelHook(new TowerDefenseTopHudHook());
	}

	// Token: 0x06016573 RID: 91507 RVA: 0x00631338 File Offset: 0x0062F538
	private void OnRoleReviveNotify(TowerDefenceRoleReviveNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		long targetTime = notify.ReviveTime;
		double serverStopTimeStamp = Singleton<TimeUtil>.Instance.GetServerStopTimeStamp();
		double total = Singleton<TimeUtil>.Instance.SetTimeSecond((double)targetTime - serverStopTimeStamp);
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(total + 0.5);
		if (!string.IsNullOrEmpty(remainTimeDataFormat.CountDownText))
		{
			if (this.CheckIsSelf(notify.PlayerId))
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TowerDefenceRoleDie", new object[]
				{
					remainTimeDataFormat.CountDownText
				});
			}
			else
			{
				ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TowerDefencePlayerDie", new object[]
				{
					remainTimeDataFormat.CountDownText
				});
			}
		}
		TowerDefenseModel model = ModelBase<TowerDefenseModel>.Instance;
		TimerHandle handle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			double serverStopTimeStamp2 = Singleton<TimeUtil>.Instance.GetServerStopTimeStamp();
			if (serverStopTimeStamp2 >= (double)targetTime)
			{
				Singleton<EventSystem>.Instance.Emit<int, int, float?, float?>(EEventName.OnRefreshFormationCooldownExternalInBattleView, notify.PlayerId, notify.RoleId, null, null);
				model.TryRemoveTimerInBattle(notify.PlayerId, new int?(notify.RoleId));
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int, int, float?, float?>(EEventName.OnRefreshFormationCooldownExternalInBattleView, notify.PlayerId, notify.RoleId, new float?((float)Singleton<TimeUtil>.Instance.SetTimeSecond((double)targetTime - serverStopTimeStamp2)), new float?((float)total));
		}, 100f, 1f, null, null, true);
		model.TryAddTimerInBattle(handle, notify.PlayerId, notify.RoleId);
	}

	// Token: 0x06016574 RID: 91508 RVA: 0x00631454 File Offset: 0x0062F654
	private void OnPlayerReviveNotify(TowerDefencePlayerReviveNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		long targetTime = Singleton<MathUtils>.Instance.LongToNumber(notify.ReviveTime);
		double serverStopTimeStamp = Singleton<TimeUtil>.Instance.GetServerStopTimeStamp();
		double total = Singleton<TimeUtil>.Instance.SetTimeSecond((double)targetTime - serverStopTimeStamp);
		CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(0.5 + Singleton<TimeUtil>.Instance.SetTimeSecond((double)targetTime - serverStopTimeStamp));
		if (this.CheckIsSelf(notify.PlayerId))
		{
			ModelBase<TowerDefenseModel>.Instance.SelfReviveTargetTimestampForUi = new long?(Singleton<MathUtils>.Instance.LongToNumber(notify.ReviveTime));
		}
		else if (!string.IsNullOrEmpty(remainTimeDataFormat.CountDownText))
		{
			OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(notify.PlayerId);
			int num = (currentTeamListById != null) ? currentTeamListById.PlayerNumber : 0;
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TowerDefencePlayerRoleDie", new object[]
			{
				num,
				remainTimeDataFormat.CountDownText
			});
		}
		TowerDefenseModel model = ModelBase<TowerDefenseModel>.Instance;
		model.TryRemoveTimerInBattle(notify.PlayerId, null);
		BattleUiFormationPanelData formationPanelData = ModelBase<BattleUiModel>.Instance.FormationPanelData;
		Dictionary<int, FormationItemData> dictionary = (formationPanelData != null) ? formationPanelData.PositionItemMap : null;
		if (dictionary != null)
		{
			using (Dictionary<int, FormationItemData>.ValueCollection.Enumerator enumerator = dictionary.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					FormationItemData itemData = enumerator.Current;
					if (itemData.PlayerId == notify.PlayerId)
					{
						TimerHandle handle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
						{
							double serverStopTimeStamp2 = Singleton<TimeUtil>.Instance.GetServerStopTimeStamp();
							if (serverStopTimeStamp2 >= (double)targetTime)
							{
								Singleton<EventSystem>.Instance.Emit<int, int, float?, float?>(EEventName.OnRefreshFormationCooldownExternalInBattleView, notify.PlayerId, 0, null, null);
								model.TryRemoveTimerInBattle(notify.PlayerId, new int?(itemData.RoleId));
								return;
							}
							Singleton<EventSystem>.Instance.Emit<int, int, float?, float?>(EEventName.OnRefreshFormationCooldownExternalInBattleView, notify.PlayerId, 0, new float?((float)Singleton<TimeUtil>.Instance.SetTimeSecond((double)targetTime - serverStopTimeStamp2)), new float?((float)total));
						}, 100f, 1f, null, null, true);
						model.TryAddTimerInBattle(handle, notify.PlayerId, itemData.RoleId);
					}
				}
			}
		}
	}

	// Token: 0x06016575 RID: 91509 RVA: 0x00631680 File Offset: 0x0062F880
	public void HandleOnClickReward()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerDefenseRewardView, ModelBase<TowerDefenseModel>.Instance.GetPreviewRewardData(), delegate(bool success, int viewId)
		{
			EUiViewName viewName = Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TowerDefenseLevelView) ? EUiViewName.TowerDefenseLevelView : EUiViewName.CommonActivityView;
			if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
			{
				UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(viewName);
				if (viewByName == null)
				{
					return;
				}
				viewByName.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x06016576 RID: 91510 RVA: 0x006316BA File Offset: 0x0062F8BA
	private void HandleBeforeConfirmQuickRoleSelect()
	{
		if (!this.CheckInUiFlow())
		{
			return;
		}
		this.SyncEditBattleTeamModelToOwnerData();
		Singleton<EventSystem>.Instance.Emit(EEventName.TowerDefensePhantomChanged);
	}

	// Token: 0x06016577 RID: 91511 RVA: 0x006316DB File Offset: 0x0062F8DB
	private void HandleOnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
	}

	// Token: 0x06016578 RID: 91512 RVA: 0x006316DD File Offset: 0x0062F8DD
	private void HandleEnterInstanceDungeon()
	{
		if (this.CheckInInstanceDungeon())
		{
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TowerDefenseShowInBattleView, true);
		}
	}

	// Token: 0x06016579 RID: 91513 RVA: 0x006316F8 File Offset: 0x0062F8F8
	private void HandleLeaveInstanceDungeon()
	{
		ModelBase<TowerDefenseModel>.Instance.ResetTimerCacheInBattle();
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.BattleView);
		if (viewByName != null)
		{
			(viewByName as BattleView).ResetFormationCooldownExternal();
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.TowerDefenseShowInBattleView, false);
	}

	// Token: 0x0601657A RID: 91514 RVA: 0x0063173E File Offset: 0x0062F93E
	private void HandleLeaveInstanceExternalConfirm()
	{
		if (!this.CheckInInstanceDungeon())
		{
			return;
		}
		ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().ContinueWith(delegate(bool task)
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExploreRewardView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, null);
			}
			TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
			instance.IsNeedShowMainView = true;
			instance.ResetAllCache();
		});
	}

	// Token: 0x0601657B RID: 91515 RVA: 0x00631778 File Offset: 0x0062F978
	private void RewardViewLeftClickCallback(int buttonIndex)
	{
		this.RequestChallengeQuit();
	}

	// Token: 0x0601657C RID: 91516 RVA: 0x00631780 File Offset: 0x0062F980
	private void RewardViewRightClickCallback(int buttonIndex)
	{
		this.HandleSettleViewRestart(buttonIndex);
	}

	// Token: 0x0601657D RID: 91517 RVA: 0x0063178C File Offset: 0x0062F98C
	public void HandleSettleViewExit()
	{
		ModelBase<TowerDefenseModel>.Instance.IsNeedShowMainView = true;
		ModelBase<InstanceDungeonModel>.Instance.LastEnterRoleList = null;
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExploreRewardView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, null);
		}
		if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.TowerDefenseSettleView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.TowerDefenseSettleView, null);
		}
		ModelBase<TowerDefenseModel>.Instance.ResetAllCache();
	}

	// Token: 0x0601657E RID: 91518 RVA: 0x006317FC File Offset: 0x0062F9FC
	public void RequestChallengeQuit()
	{
		TowerDefenceChallengeQuitRequest message = TowerDefenceChallengeQuitRequest.Create();
		Singleton<Net>.Instance.CallAsync<TowerDefenceChallengeQuitResponse>(ERequestMessageId.TowerDefenceChallengeQuitRequest, message, 0).ContinueWith(delegate(TowerDefenceChallengeQuitResponse response)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25202, null, true, true);
				return;
			}
			this.HandleSettleViewExit();
		});
	}

	// Token: 0x0601657F RID: 91519 RVA: 0x00631834 File Offset: 0x0062FA34
	public void HandleSettleViewRestart(int buttonIndex = 0)
	{
		if (ModelBase<TowerDefenseModel>.Instance.GetOrCreateParsedTowerDefenseMsg().CheckIfClose())
		{
			ControllerBase<GenericPromptController>.Instance.ShowPromptByCode("TowerDefenceActivityEnd", Array.Empty<object>());
			return;
		}
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.SettleViewButtonSuccessOnMultiCallBack(buttonIndex);
			return;
		}
		ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().ContinueWith(delegate(bool task)
		{
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ExploreRewardView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ExploreRewardView, null);
			}
		});
	}

	// Token: 0x06016580 RID: 91520 RVA: 0x006318AE File Offset: 0x0062FAAE
	private void HandleBattleScoreChanged(int scoreId, int scoreValue)
	{
		this.CheckInInstanceDungeon();
	}

	// Token: 0x06016581 RID: 91521 RVA: 0x006318B7 File Offset: 0x0062FAB7
	private void HandleOnBeforeDestroyInstanceDungeonEntranceView()
	{
		this.CheckInUiFlow();
		this.SetIsUiFlowOpen(false);
	}

	// Token: 0x06016582 RID: 91522 RVA: 0x006318C8 File Offset: 0x0062FAC8
	private void HandleOnRefreshEditBattleRoleSlotData(ERefreshEditBattleRoleSlotDataReason reason)
	{
		if (!this.CheckInUiFlow())
		{
			return;
		}
		if (this.CheckIsInMatch())
		{
			this.SyncMatchingPhantomId();
		}
		else
		{
			if (reason == ERefreshEditBattleRoleSlotDataReason.ChangeTeamOffline)
			{
				ModelBase<TowerDefenseModel>.Instance.RoleCfgId2PhantomIdMapCache.Clear();
			}
			this.SyncEditBattleTeamModelToOwnerData();
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.TowerDefensePhantomChanged);
	}

	// Token: 0x06016583 RID: 91523 RVA: 0x00631917 File Offset: 0x0062FB17
	private void HandleTowerDefenseSelfPhantomConfirm(int roleCfgId)
	{
		this.SyncSelfTowerDefensePhantomId(roleCfgId);
		this.ResetCurrentTowerDefensePhantomIdInUiTemp();
	}

	// Token: 0x06016584 RID: 91524 RVA: 0x00631928 File Offset: 0x0062FB28
	private void HandleWorldDoneAndCloseLoading()
	{
		this.TryReopenLevelViewOnWorldReturn();
		if (!this.CheckInInstanceDungeon())
		{
			return;
		}
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		if (instance.DelayedEndNotify != null)
		{
			this.HandleEndNotifyImplement(instance.DelayedEndNotify);
			instance.DelayedEndNotify = null;
		}
	}

	// Token: 0x06016585 RID: 91525 RVA: 0x00631968 File Offset: 0x0062FB68
	private void TryReopenLevelViewOnWorldReturn()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		if (!instance.IsNeedShowMainView)
		{
			return;
		}
		instance.IsNeedShowMainView = false;
		if (instance.GetOrCreateParsedTowerDefenseMsg().CheckIfClose())
		{
			return;
		}
		SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.None, ESplashScreenType.Other, delegate()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.EnterEntrance(ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceId, 0, null);
		});
		ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, false);
	}

	// Token: 0x06016586 RID: 91526 RVA: 0x006319CC File Offset: 0x0062FBCC
	private void HandleCloseView(EUiViewName viewName, int ViewId)
	{
		if (this.CheckInUiFlow() && viewName == EUiViewName.EditBattleTeamView)
		{
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TowerDefensePhantomView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.TowerDefensePhantomView, null);
			}
			ModelBase<TowerDefenseModel>.Instance.RoleCfgId2PhantomIdMapCache.Clear();
			if (!this.CheckActivityUnlockByMulti())
			{
				this.SetIsUiFlowOpen(false);
			}
		}
	}

	// Token: 0x06016587 RID: 91527 RVA: 0x00631A2D File Offset: 0x0062FC2D
	private void OnSelectInstanceIdChallenge(int instanceId)
	{
		ModelBase<TowerDefenseModel>.Instance.SetLevelHasClickByInstanceId(instanceId);
	}

	// Token: 0x06016588 RID: 91528 RVA: 0x00631A3A File Offset: 0x0062FC3A
	public void SetCurrentTowerDefensePhantomIdInUiTemp(int id)
	{
		ModelBase<TowerDefenseModel>.Instance.CurrentSelfPhantomIdInUiTemp = id;
	}

	// Token: 0x06016589 RID: 91529 RVA: 0x00631A47 File Offset: 0x0062FC47
	public void ResetCurrentTowerDefensePhantomIdInUiTemp()
	{
		ModelBase<TowerDefenseModel>.Instance.ResetCurrentPhantomIdInUiTempToFirstAvailable();
	}

	// Token: 0x0601658A RID: 91530 RVA: 0x00631A53 File Offset: 0x0062FC53
	public void ToggleInBattleView()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.BattleUiToggleTowerDefenseInfoView);
	}

	// Token: 0x0601658B RID: 91531 RVA: 0x00631A68 File Offset: 0x0062FC68
	public void ResetCurrentPhantomLevelUpFlag(int level)
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		int currentPhantomIdInBattle = instance.GetCurrentPhantomIdInBattle();
		int currentPhantomLevelInBattle = instance.GetCurrentPhantomLevelInBattle();
		instance.PhantomMessageCache.OwnPhantomInBattleNewLevelUpFlagCache[currentPhantomIdInBattle] = (currentPhantomLevelInBattle > level);
	}

	// Token: 0x0601658C RID: 91532 RVA: 0x00631A9C File Offset: 0x0062FC9C
	public void TryReopenInBattleTip()
	{
		this.OpenInBattleTipImplement();
	}

	// Token: 0x0601658D RID: 91533 RVA: 0x00631AA4 File Offset: 0x0062FCA4
	public void TryOpenPhantomViewByPlayerIdAndRoleId(int playerId, int roleId)
	{
		if (this.CheckIsSelf(playerId))
		{
			if (ModelBase<InstanceDungeonModel>.Instance.GetPrewarPlayerReadyState(playerId))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TowerDefence_PhantasmTips", Array.Empty<object>());
				return;
			}
			TowerDefensePhantomViewArgs param = new TowerDefensePhantomViewArgs
			{
				RoleCfgId = roleId
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerDefensePhantomView, param, null);
		}
	}

	// Token: 0x0601658E RID: 91534 RVA: 0x00631AFC File Offset: 0x0062FCFC
	public void SyncSelfTowerDefensePhantomId(int roleCfgId)
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
		ITowerDefensePhantomDataOwner ownerData = instance.GetOwnerData(value, roleCfgId);
		if (ownerData == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TowerDefense;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "自己选择声骸后，找不到自己的OwnerData，声骸ID不进行同步";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("roleCfgId", roleCfgId);
			instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		ownerData.PhantomId = instance.CurrentSelfPhantomIdInUiTemp;
		instance.RoleCfgId2PhantomIdMapCache[roleCfgId] = instance.CurrentSelfPhantomIdInUiTemp;
		if (this.CheckIsInMatch())
		{
			EditBattleTeamModel instance3 = ModelBase<EditBattleTeamModel>.Instance;
			ControllerBase<InstanceDungeonEntranceController>.Instance.MatchChangeRoleRequest(instance3.GetOwnRoleConfigIdList.Item1).ContinueWith(delegate(bool bSuccess)
			{
				if (bSuccess)
				{
					Singleton<EventSystem>.Instance.Emit(EEventName.TowerDefensePhantomChanged);
				}
			});
			return;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.TowerDefensePhantomChanged);
	}

	// Token: 0x0601658F RID: 91535 RVA: 0x00631BD8 File Offset: 0x0062FDD8
	private void HandleEndNotifyImplement(TowerDefenceEndNotify notify)
	{
		if (!ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			return;
		}
		if (notify.Success && ModelBase<GameModeModel>.Instance.IsMulti)
		{
			this.OpenTowerDefenseSuccessSettleView(notify);
		}
		else
		{
			this.OpenTowerDefenseSettleView(notify);
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TowerDefenseInBattleTips))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.TowerDefenseInBattleTips, null);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.TowerDefenseOnTowerDefenseBattleEndNotify);
	}

	// Token: 0x06016590 RID: 91536 RVA: 0x00631C48 File Offset: 0x0062FE48
	public unsafe void OpenTowerDefenseResultView(TowerDefenceEndNotify notify)
	{
		TowerDefenceInstance? config = ConfigTowerDefenceInstanceById.GetConfig(notify.InstId, true);
		if (config == null)
		{
			return;
		}
		bool isDifficult = config.Value.IsDifficult;
		string titleTextId = string.Empty;
		string record = string.Empty;
		int? recordRollingTo = null;
		List<IRewardExploreConfirmButton> list = this.BuildRewardButtonList(notify.MaxScore);
		if (isDifficult)
		{
			if (notify.Success)
			{
				titleTextId = "TowerDefenceWinTime";
				record = Singleton<TimeUtil>.Instance.GetTimeString((double)notify.PassTime);
			}
			else
			{
				titleTextId = "TowerDefencelose";
				record = string.Empty;
			}
			list[1].DescriptionTextId = "TowerDefenceBestTime";
			IRewardExploreConfirmButton rewardExploreConfirmButton = list[1];
			int num = 1;
			List<object> list2 = new List<object>(num);
			CollectionsMarshal.SetCount<object>(list2, num);
			Span<object> span = CollectionsMarshal.AsSpan<object>(list2);
			int index = 0;
			*span[index] = Singleton<TimeUtil>.Instance.GetTimeString((double)notify.MinPassTime);
			rewardExploreConfirmButton.DescriptionArgs = list2;
		}
		else if (notify.Success)
		{
			titleTextId = "MowingCurrentPoint";
			record = string.Empty;
			recordRollingTo = new int?(notify.Score);
		}
		else
		{
			titleTextId = "TowerDefencelose";
			record = string.Empty;
		}
		ExploreRewardViewData data = new ExploreRewardViewData
		{
			ConfigId = (notify.Success ? 3018 : 3017),
			IsSuccess = notify.Success,
			ExploreRecordInfo = new RewardExploreRecordData
			{
				TitleTextId = titleTextId,
				Record = record,
				RecordRollingTo = recordRollingTo,
				IsNewRecord = (isDifficult ? (notify.PassTime != 0 && notify.MinPassTime >= notify.PassTime) : (notify.Score >= notify.MaxScore && notify.Score != 0))
			},
			ButtonInfoList = list
		};
		ControllerBase<ItemRewardController>.Instance.OpenExploreRewardViewNew(data);
	}

	// Token: 0x06016591 RID: 91537 RVA: 0x00631DFF File Offset: 0x0062FFFF
	public void OpenTowerDefenseSettleView(TowerDefenceEndNotify notify)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TowerDefenseSettleView, notify, null);
	}

	// Token: 0x06016592 RID: 91538 RVA: 0x00631E14 File Offset: 0x00630014
	private void OpenTowerDefenseSuccessSettleView(TowerDefenceEndNotify notify)
	{
		List<ISolarSpeedRolePanelData> list = new List<ISolarSpeedRolePanelData>();
		List<int> list2 = new List<int>();
		foreach (TowerDefenceRoleScoreInfo towerDefenceRoleScoreInfo in notify.BattleInfo)
		{
			int playerId = towerDefenceRoleScoreInfo.PlayerId;
			int num = list2.IndexOf(playerId);
			int index;
			if (num != -1)
			{
				index = num;
			}
			else
			{
				index = list2.Count;
				list2.Add(playerId);
			}
			OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId);
			bool flag = currentTeamListById != null && currentTeamListById.IsSelf;
			List<ITowerDefenseRoleDescData> list3 = new List<ITowerDefenseRoleDescData>();
			foreach (TowerDefenceBattleScoreInfo towerDefenceBattleScoreInfo in towerDefenceRoleScoreInfo.ScoreList)
			{
				TowerDefenseRoleDescData item = new TowerDefenseRoleDescData
				{
					Title = towerDefenceBattleScoreInfo.Id,
					Count = towerDefenceBattleScoreInfo.Score
				};
				list3.Add(item);
			}
			TowerDefenseRolePanelData item2 = new TowerDefenseRolePanelData
			{
				Rank = 0,
				PlayerId = playerId,
				IsAddButtonAvailable = (!flag && !ModelBase<FriendModel>.Instance.IsMyFriend(playerId)),
				IsSelf = flag,
				BgPath = SolarSpeedDefine.rankBgPathMap[0],
				MedalColorHex = SolarSpeedDefine.medalColorHex[0],
				FxColorHex = SolarSpeedDefine.fxColorHex[0],
				PlayerIndexIconPath = (flag ? SolarSpeedDefine.playerIndexSelfIconMap[index] : SolarSpeedDefine.playerIndexIconMap[index]),
				NameText = (((currentTeamListById != null) ? currentTeamListById.PlayerName : null) ?? string.Empty),
				IconData = new SolarSpeedRoleIconPanelData
				{
					IconPath = ((currentTeamListById == null) ? string.Empty : ModelBase<PersonalModel>.Instance.GetPlayerHeadData(currentTeamListById.HeadId, false).GetRoleHeadIconCircle())
				},
				BestTitle = towerDefenceRoleScoreInfo.Title,
				DescDataList = list3
			};
			list.Add(item2);
		}
		SolarSpeedResultViewData solarSpeedResultViewData = new SolarSpeedResultViewData();
		solarSpeedResultViewData.TitleId = "TowerDefenceSettlement01";
		solarSpeedResultViewData.RoleDataList = list;
		solarSpeedResultViewData.PanelType = (() => new TowerDefenseRolePanel());
		solarSpeedResultViewData.ConfirmClick = delegate()
		{
			this.OpenTowerDefenseSettleView(notify);
		};
		SolarSpeedResultViewData param = solarSpeedResultViewData;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SolarSpeedResultView, param, null);
	}

	// Token: 0x06016593 RID: 91539 RVA: 0x006320BC File Offset: 0x006302BC
	public int GetLevelInBattle()
	{
		return ModelBase<TowerDefenseModel>.Instance.GetCurrentPhantomLevelInBattle();
	}

	// Token: 0x06016594 RID: 91540 RVA: 0x006320C8 File Offset: 0x006302C8
	public string GetLevelContentInBattle()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		if (instance.CheckCurrentActivityShowDifferent())
		{
			return ConfigMultiTextLang.GetLocalTextNew("TowerDefencewenhao", null) ?? string.Empty;
		}
		return instance.GetCurrentPhantomLevelInBattle().ToString();
	}

	// Token: 0x06016595 RID: 91541 RVA: 0x00632108 File Offset: 0x00630308
	[NullableContext(2)]
	public ITowerDefensePhantomExp GetExpDataInBattle()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		if (instance.CheckCurrentActivityShowDifferent())
		{
			return null;
		}
		return instance.GetCurrentPhantomExpPairInBattle();
	}

	// Token: 0x06016596 RID: 91542 RVA: 0x0063212C File Offset: 0x0063032C
	public float GetProgressInBattle()
	{
		ITowerDefensePhantomExp currentPhantomExpPairInBattle = ModelBase<TowerDefenseModel>.Instance.GetCurrentPhantomExpPairInBattle();
		if (currentPhantomExpPairInBattle.Exp == 0.0)
		{
			return 0f;
		}
		if (currentPhantomExpPairInBattle.Threshold == 0.0)
		{
			return 1f;
		}
		return (float)(currentPhantomExpPairInBattle.Exp / currentPhantomExpPairInBattle.Threshold);
	}

	// Token: 0x06016597 RID: 91543 RVA: 0x00632180 File Offset: 0x00630380
	public bool GetIsFirstOpen()
	{
		return ModelBase<TowerDefenseModel>.Instance.GetOrCreateParsedTowerDefenseMsg().GetIfFirstOpen();
	}

	// Token: 0x06016598 RID: 91544 RVA: 0x00632191 File Offset: 0x00630391
	public string GetActivitySubViewTitle()
	{
		return ModelBase<TowerDefenseModel>.Instance.GetOrCreateParsedTowerDefenseMsg().GetTitle();
	}

	// Token: 0x06016599 RID: 91545 RVA: 0x006321A2 File Offset: 0x006303A2
	public Activity GetActivityCfg()
	{
		return ModelBase<TowerDefenseModel>.Instance.GetOrCreateParsedTowerDefenseMsg().LocalConfig.Value;
	}

	// Token: 0x0601659A RID: 91546 RVA: 0x006321B8 File Offset: 0x006303B8
	public List<TItem> GetActivityPreviewReward()
	{
		return ModelBase<TowerDefenseModel>.Instance.GetOrCreateParsedTowerDefenseMsg().GetPreviewReward(null);
	}

	// Token: 0x0601659B RID: 91547 RVA: 0x006321E0 File Offset: 0x006303E0
	public EUiViewName? TryGetReviveViewName()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ExploreRewardView))
		{
			return null;
		}
		return new EUiViewName?(EUiViewName.TowerDefenceReviveView);
	}

	// Token: 0x0601659C RID: 91548 RVA: 0x00632212 File Offset: 0x00630412
	public SceneTeamItem GetCurrentSceneTeamItem()
	{
		return ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
	}

	// Token: 0x0601659D RID: 91549 RVA: 0x0063221E File Offset: 0x0063041E
	public List<SceneTeamItem> GetAllOwnSceneTeamItems()
	{
		return ModelBase<SceneTeamModel>.Instance.GetTeamItems(true);
	}

	// Token: 0x0601659E RID: 91550 RVA: 0x0063222B File Offset: 0x0063042B
	public int GetSuitableStageId()
	{
		return ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.GetSuitableStageId();
	}

	// Token: 0x0601659F RID: 91551 RVA: 0x0063223C File Offset: 0x0063043C
	public bool CheckStageUnlockById(int id)
	{
		TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(id);
		if (towerDefenseConfigById == null)
		{
			return false;
		}
		if (towerDefenseConfigById.Value.BossRush)
		{
			return this.CheckAllPrerequisiteStagesPassed();
		}
		if (!this.IsStageTimeReachedById(id))
		{
			return false;
		}
		if (towerDefenseConfigById.Value.Difficulty == 1)
		{
			return true;
		}
		int sameGroupNormalStageId = this.GetSameGroupNormalStageId(towerDefenseConfigById.Value.GroupId);
		return sameGroupNormalStageId <= 0 || this.CheckStagePassedById(sameGroupNormalStageId);
	}

	// Token: 0x060165A0 RID: 91552 RVA: 0x006322BA File Offset: 0x006304BA
	public bool IsStageTimeReachedById(int id)
	{
		return ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.IsStageUnlockedByTowerDefenseInstanceId(id);
	}

	// Token: 0x060165A1 RID: 91553 RVA: 0x006322CC File Offset: 0x006304CC
	public bool CheckStageSelectableById(int id)
	{
		TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(id);
		if (towerDefenseConfigById == null)
		{
			return false;
		}
		if (towerDefenseConfigById.Value.BossRush)
		{
			return this.CheckStageUnlockById(id);
		}
		int sameGroupNormalStageId = this.GetSameGroupNormalStageId(towerDefenseConfigById.Value.GroupId);
		if (sameGroupNormalStageId <= 0)
		{
			return this.IsStageTimeReachedById(id);
		}
		return this.IsStageTimeReachedById(sameGroupNormalStageId);
	}

	// Token: 0x060165A2 RID: 91554 RVA: 0x00632334 File Offset: 0x00630534
	public int GetSameGroupNormalStageId(int groupId)
	{
		List<ITowerDefenseParsedStageMessage> stageListCache = ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.StageListCache;
		if (stageListCache == null)
		{
			return 0;
		}
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in stageListCache)
		{
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(towerDefenseParsedStageMessage.Id);
			if (towerDefenseConfigById != null && !towerDefenseConfigById.Value.BossRush && towerDefenseConfigById.Value.GroupId == groupId && towerDefenseConfigById.Value.Difficulty == 1)
			{
				return towerDefenseParsedStageMessage.Id;
			}
		}
		return 0;
	}

	// Token: 0x060165A3 RID: 91555 RVA: 0x006323F0 File Offset: 0x006305F0
	public bool CheckAllPrerequisiteStagesPassed()
	{
		List<ITowerDefenseParsedStageMessage> stageListCache = ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.StageListCache;
		if (stageListCache == null)
		{
			return false;
		}
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in stageListCache)
		{
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(towerDefenseParsedStageMessage.Id);
			if (towerDefenseConfigById != null && !towerDefenseConfigById.Value.BossRush && towerDefenseConfigById.Value.Difficulty == 1 && !this.CheckStagePassedById(towerDefenseParsedStageMessage.Id))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060165A4 RID: 91556 RVA: 0x006324A4 File Offset: 0x006306A4
	public int GetSameGroupHardStageId(int groupId)
	{
		List<ITowerDefenseParsedStageMessage> stageListCache = ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.StageListCache;
		if (stageListCache == null)
		{
			return 0;
		}
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in stageListCache)
		{
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(towerDefenseParsedStageMessage.Id);
			if (towerDefenseConfigById != null && !towerDefenseConfigById.Value.BossRush && towerDefenseConfigById.Value.GroupId == groupId && towerDefenseConfigById.Value.Difficulty != 1)
			{
				return towerDefenseParsedStageMessage.Id;
			}
		}
		return 0;
	}

	// Token: 0x060165A5 RID: 91557 RVA: 0x00632560 File Offset: 0x00630760
	public int GetLatestUnlockedGroupId()
	{
		List<ITowerDefenseParsedStageMessage> stageListCache = ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.StageListCache;
		if (stageListCache == null)
		{
			return 0;
		}
		int result = 0;
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in stageListCache)
		{
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(towerDefenseParsedStageMessage.Id);
			if (towerDefenseConfigById != null && !towerDefenseConfigById.Value.BossRush && towerDefenseConfigById.Value.Difficulty == 1 && this.IsStageTimeReachedById(towerDefenseParsedStageMessage.Id))
			{
				result = towerDefenseConfigById.Value.GroupId;
			}
		}
		return result;
	}

	// Token: 0x060165A6 RID: 91558 RVA: 0x00632620 File Offset: 0x00630820
	public int GetLastBossRushStageId()
	{
		List<ITowerDefenseParsedStageMessage> stageListCache = ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.StageListCache;
		if (stageListCache == null)
		{
			return 0;
		}
		int result = 0;
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in stageListCache)
		{
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(towerDefenseParsedStageMessage.Id);
			if (towerDefenseConfigById != null && towerDefenseConfigById.Value.BossRush)
			{
				result = towerDefenseParsedStageMessage.Id;
			}
		}
		return result;
	}

	// Token: 0x060165A7 RID: 91559 RVA: 0x006326B4 File Offset: 0x006308B4
	public int GetDefaultSelectStageId()
	{
		List<ITowerDefenseParsedStageMessage> stageListCache = ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.StageListCache;
		if (stageListCache == null)
		{
			return 0;
		}
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in stageListCache)
		{
			TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(towerDefenseParsedStageMessage.Id);
			if (towerDefenseConfigById != null && !towerDefenseConfigById.Value.BossRush && this.CheckStageUnlockById(towerDefenseParsedStageMessage.Id) && !this.CheckStagePassedById(towerDefenseParsedStageMessage.Id))
			{
				return towerDefenseParsedStageMessage.Id;
			}
		}
		int lastBossRushStageId = this.GetLastBossRushStageId();
		if (lastBossRushStageId > 0 && this.CheckStageUnlockById(lastBossRushStageId))
		{
			return lastBossRushStageId;
		}
		int latestUnlockedGroupId = this.GetLatestUnlockedGroupId();
		if (latestUnlockedGroupId <= 0)
		{
			return 0;
		}
		int sameGroupHardStageId = this.GetSameGroupHardStageId(latestUnlockedGroupId);
		if (sameGroupHardStageId <= 0)
		{
			return this.GetSameGroupNormalStageId(latestUnlockedGroupId);
		}
		return sameGroupHardStageId;
	}

	// Token: 0x060165A8 RID: 91560 RVA: 0x006327A4 File Offset: 0x006309A4
	[NullableContext(2)]
	public ITowerDefenseLockedHint BuildStageLockedHintById(int id)
	{
		TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(id);
		if (towerDefenseConfigById == null)
		{
			return null;
		}
		if (towerDefenseConfigById.Value.BossRush)
		{
			return new TowerDefenseLockedHint
			{
				TextId = "TowerDefence_Lcok_TipsText"
			};
		}
		if (this.IsStageTimeReachedById(id))
		{
			return new TowerDefenseLockedHint
			{
				TextId = "OnlineGymnasium_LevelRst"
			};
		}
		string text = this.BuildInstanceCountDownTextParam(towerDefenseConfigById.Value.InstanceId);
		if (!string.IsNullOrEmpty(text))
		{
			return new TowerDefenseLockedHint
			{
				TextId = "ActivityMowing_UnlockCondition",
				Args = new string[]
				{
					text
				}
			};
		}
		return null;
	}

	// Token: 0x060165A9 RID: 91561 RVA: 0x00632848 File Offset: 0x00630A48
	public bool CheckStagePassedById(int id)
	{
		ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage;
		return ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.StageMapCache.TryGetValue(id, out towerDefenseParsedStageMessage) && towerDefenseParsedStageMessage.Passed;
	}

	// Token: 0x060165AA RID: 91562 RVA: 0x00632878 File Offset: 0x00630A78
	public int GetRecordByStageId(int id)
	{
		ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage;
		if (!ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.StageMapCache.TryGetValue(id, out towerDefenseParsedStageMessage))
		{
			return 0;
		}
		return towerDefenseParsedStageMessage.Record;
	}

	// Token: 0x060165AB RID: 91563 RVA: 0x006328A8 File Offset: 0x00630AA8
	public int GetRecordByInstanceId(int instanceId)
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		TowerDefenceInstance? config = ConfigTowerDefenceInstanceByInstanceId.GetConfig(instanceId, true);
		if (config == null)
		{
			return 0;
		}
		ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage;
		if (instance.PhantomMessageCache.StageMapCache.TryGetValue(config.Value.Id, out towerDefenseParsedStageMessage))
		{
			return towerDefenseParsedStageMessage.Record;
		}
		return 0;
	}

	// Token: 0x060165AC RID: 91564 RVA: 0x006328FC File Offset: 0x00630AFC
	public string GetPassTimeContentByInstanceId(int instanceId)
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		TowerDefenceInstance? config = ConfigTowerDefenceInstanceByInstanceId.GetConfig(instanceId, true);
		double second = 0.0;
		ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage;
		if (config != null && instance.PhantomMessageCache.StageMapCache.TryGetValue(config.Value.Id, out towerDefenseParsedStageMessage))
		{
			second = (towerDefenseParsedStageMessage.Passed ? towerDefenseParsedStageMessage.PassTime : 0.0);
		}
		return Singleton<TimeUtil>.Instance.GetTimeString(second);
	}

	// Token: 0x060165AD RID: 91565 RVA: 0x00632974 File Offset: 0x00630B74
	public int GetTotalScoreLimitByInstanceId(int instanceId)
	{
		TowerDefenceInstance? config = ConfigTowerDefenceInstanceByInstanceId.GetConfig(instanceId, true);
		if (config == null)
		{
			return 0;
		}
		return config.Value.UnlockScoreLimit;
	}

	// Token: 0x060165AE RID: 91566 RVA: 0x006329A4 File Offset: 0x00630BA4
	public int GetCurrentScoreLimit()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		int num = 0;
		foreach (int num2 in instance.PhantomMessageCache.StageMapCache.Keys)
		{
			TowerDefenceInstance? config = ConfigTowerDefenceInstanceById.GetConfig(num2, true);
			if (config != null && instance.PhantomMessageCache.IsStageUnlockedByTowerDefenseInstanceId(num2))
			{
				num = ((config.Value.UnlockScoreLimit > num) ? config.Value.UnlockScoreLimit : num);
			}
		}
		return num;
	}

	// Token: 0x060165AF RID: 91567 RVA: 0x00632A4C File Offset: 0x00630C4C
	public int GetMarkIdByActivityId(int activityId)
	{
		TowerDefenceMapMark? config = ConfigTowerDefenceMapMarkByActivityId.GetConfig(activityId, true);
		if (config == null)
		{
			return 0;
		}
		return config.Value.MarkId;
	}

	// Token: 0x060165B0 RID: 91568 RVA: 0x00632A7B File Offset: 0x00630C7B
	public int GetSuitableInstanceId()
	{
		return ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.GetSuitableInstanceId();
	}

	// Token: 0x060165B1 RID: 91569 RVA: 0x00632A8C File Offset: 0x00630C8C
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] GetPhantomSkillDescriptionArgsByPhantomId(int id)
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		if (!instance.CheckCurrentActivityShowDifferent())
		{
			return null;
		}
		int skillId = ConfigPhantomItemByItemId.GetConfig(instance.PhantomConfigCache[id].PhantomItemId, true).Value.SkillId;
		return ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillDescExByPhantomSkillIdAndQuality(skillId, 5);
	}

	// Token: 0x060165B2 RID: 91570 RVA: 0x00632ADD File Offset: 0x00630CDD
	public bool CheckActivityUnlockByCondition()
	{
		return ModelBase<TowerDefenseModel>.Instance.GetOrCreateParsedTowerDefenseMsg().IsUnLock();
	}

	// Token: 0x060165B3 RID: 91571 RVA: 0x00632AF0 File Offset: 0x00630CF0
	public bool CheckInInstanceDungeon()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.GetValueOrDefault().InstSubType == 21;
		}
		return false;
	}

	// Token: 0x060165B4 RID: 91572 RVA: 0x00632B40 File Offset: 0x00630D40
	public bool CheckInBossRushInstance()
	{
		TowerDefenceInstance? config = ConfigTowerDefenceInstanceByInstanceId.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId(), true);
		return config != null && config.GetValueOrDefault().BossRush;
	}

	// Token: 0x060165B5 RID: 91573 RVA: 0x00632B78 File Offset: 0x00630D78
	public bool CheckIsInstanceUnlock(int instanceId)
	{
		return ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.IsStageUnLocked(instanceId);
	}

	// Token: 0x060165B6 RID: 91574 RVA: 0x00632B8C File Offset: 0x00630D8C
	public bool CheckIsInstanceSingle()
	{
		if (ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
			InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
			return config != null && config.GetValueOrDefault().OnlineType == InstOnlineType.Single;
		}
		return false;
	}

	// Token: 0x060165B7 RID: 91575 RVA: 0x00632BDB File Offset: 0x00630DDB
	public bool CheckHasReward()
	{
		return ModelBase<TowerDefenseModel>.Instance.CheckHasReward();
	}

	// Token: 0x060165B8 RID: 91576 RVA: 0x00632BE7 File Offset: 0x00630DE7
	public bool CheckHasNewStage()
	{
		return ModelBase<TowerDefenseModel>.Instance.HasNotClickNewLevel();
	}

	// Token: 0x060165B9 RID: 91577 RVA: 0x00632BF4 File Offset: 0x00630DF4
	public bool CheckIsSelf(int playerId)
	{
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		return id.GetValueOrDefault() == playerId & id != null;
	}

	// Token: 0x060165BA RID: 91578 RVA: 0x00632C20 File Offset: 0x00630E20
	public bool CheckActivityUnlockByMulti()
	{
		if (ModelBase<GameModeModel>.Instance.IsMulti)
		{
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			int ownerId = ModelBase<OnlineModel>.Instance.OwnerId;
			return id.GetValueOrDefault() == ownerId & id != null;
		}
		return true;
	}

	// Token: 0x060165BB RID: 91579 RVA: 0x00632C69 File Offset: 0x00630E69
	public bool CheckInUiFlow()
	{
		return ModelBase<TowerDefenseModel>.Instance.IsUiFlowOpen;
	}

	// Token: 0x060165BC RID: 91580 RVA: 0x00632C75 File Offset: 0x00630E75
	public bool CheckIsSelfEntrance(int entranceId)
	{
		return TowerDefenceDefine.entranceSet.Contains(entranceId);
	}

	// Token: 0x060165BD RID: 91581 RVA: 0x00632C82 File Offset: 0x00630E82
	public bool CheckIsPhantomViewOpened()
	{
		return ModelBase<TowerDefenseModel>.Instance.IsPhantomViewOpened;
	}

	// Token: 0x060165BE RID: 91582 RVA: 0x00632C90 File Offset: 0x00630E90
	public bool CheckAllPhantomsReady()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
		foreach (ITowerDefensePhantomDataOwner towerDefensePhantomDataOwner in instance.PhantomOwnerDataList)
		{
			int? num = id;
			long? num2 = (num != null) ? new long?((long)num.GetValueOrDefault()) : null;
			long playerId = towerDefensePhantomDataOwner.PlayerId;
			if ((num2.GetValueOrDefault() == playerId & num2 != null) && towerDefensePhantomDataOwner.RoleCfgId > 0 && towerDefensePhantomDataOwner.PhantomId <= 0)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060165BF RID: 91583 RVA: 0x00632D4C File Offset: 0x00630F4C
	public bool CheckHasSurvivalPhantom()
	{
		return ModelBase<TowerDefenseModel>.Instance.CheckHasSurvivalPhantom();
	}

	// Token: 0x060165C0 RID: 91584 RVA: 0x00632D58 File Offset: 0x00630F58
	public bool CheckSelectStageIsBossRush()
	{
		InstanceDungeonEntranceModel instance = ModelBase<InstanceDungeonEntranceModel>.Instance;
		TowerDefenceInstance? towerDefenceInstance;
		return ConfigTowerDefenceInstanceByInstanceId.GetConfig(this.CheckIsInMatch() ? instance.GetMatchingId() : instance.SelectInstanceId, true) != null && towerDefenceInstance.GetValueOrDefault().BossRush;
	}

	// Token: 0x060165C1 RID: 91585 RVA: 0x00632DA2 File Offset: 0x00630FA2
	public bool CheckNeedSurvivalWarning()
	{
		return this.CheckSelectStageIsBossRush() && !this.CheckHasSurvivalPhantom();
	}

	// Token: 0x060165C2 RID: 91586 RVA: 0x00632DB8 File Offset: 0x00630FB8
	public bool CheckIsTowerEntity(ITrackData trackData)
	{
		if (!this.CheckInInstanceDungeon())
		{
			return false;
		}
		TowerDefenceInstance? config = ConfigTowerDefenceInstanceByInstanceId.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId(), true);
		if (config != null)
		{
			TTrackTarget_Int ttrackTarget_Int = trackData.TrackTarget as TTrackTarget_Int;
			return ttrackTarget_Int != null && config.Value.BaseEntityId == ttrackTarget_Int.Value;
		}
		return false;
	}

	// Token: 0x060165C3 RID: 91587 RVA: 0x00632E13 File Offset: 0x00631013
	private bool CheckIsInMatch()
	{
		return ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() > EInstanceMatchState.Default;
	}

	// Token: 0x060165C4 RID: 91588 RVA: 0x00632E24 File Offset: 0x00631024
	public bool CheckIsChallengeInstanceByInstanceId(int id)
	{
		TowerDefenceInstance? config = ConfigTowerDefenceInstanceByInstanceId.GetConfig(id, true);
		return config != null && config.Value.IsDifficult;
	}

	// Token: 0x060165C5 RID: 91589 RVA: 0x00632E54 File Offset: 0x00631054
	public bool CheckInstancePassedByInstanceId(int id)
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		TowerDefenceInstance? config = ConfigTowerDefenceInstanceByInstanceId.GetConfig(id, true);
		ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage;
		return config != null && instance.PhantomMessageCache.StageMapCache.TryGetValue(config.Value.Id, out towerDefenseParsedStageMessage) && towerDefenseParsedStageMessage.Passed;
	}

	// Token: 0x060165C6 RID: 91590 RVA: 0x00632EA5 File Offset: 0x006310A5
	public bool CheckCurrentPhantomIsOccupiedInUi()
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		return instance.CheckPhantomIsOccupied(instance.CurrentSelfPhantomIdInUiTemp);
	}

	// Token: 0x060165C7 RID: 91591 RVA: 0x00632EB7 File Offset: 0x006310B7
	public void SetIsUiFlowOpen(bool value)
	{
		TowerDefenseModel instance = ModelBase<TowerDefenseModel>.Instance;
		instance.IsUiFlowOpen = value;
		instance.IsPhantomViewOpened = false;
	}

	// Token: 0x060165C8 RID: 91592 RVA: 0x00632ECB File Offset: 0x006310CB
	public void SetPhantomViewOpened(bool value)
	{
		ModelBase<TowerDefenseModel>.Instance.IsPhantomViewOpened = value;
	}
}
