using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using Google.Protobuf.Collections;
using UnrealEngine;

// Token: 0x02002C16 RID: 11286
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class TrapDefenseController : UiControllerBase<TrapDefenseController>
{
	// Token: 0x060168E8 RID: 92392 RVA: 0x00642C30 File Offset: 0x00640E30
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<TrapDefenseSystemInfoNotify>(ENotifyMessageId.TrapDefenseSystemInfoNotify, new Action<TrapDefenseSystemInfoNotify, Net.CallbackStatus>(this.OnTrapDefenseSystemInfoNotify));
		Singleton<Net>.Instance.Register<TrapDefenseSyncGainingGroupsNotify>(ENotifyMessageId.TrapDefenseSyncGainingGroupsNotify, delegate(TrapDefenseSyncGainingGroupsNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ProtoBdBuffAllUpdateNotify(response);
		});
		Singleton<Net>.Instance.Register<TrapDefenseRewardGainingGroupsNotify>(ENotifyMessageId.TrapDefenseRewardGainingGroupsNotify, delegate(TrapDefenseRewardGainingGroupsNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ProtoBdBuffSelectUpdateNotify(response);
		});
		Singleton<Net>.Instance.Register<TrapDefenseGainingGroupUpdateNotify>(ENotifyMessageId.TrapDefenseGainingGroupUpdateNotify, delegate(TrapDefenseGainingGroupUpdateNotify response, [Nullable(2)] Net.CallbackStatus _)
		{
			TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.ProtoBdBuffGetUpdateNotify(response);
		});
		Singleton<Net>.Instance.Register<TrapDefenseMonsterConsecutiveKillsNotify>(ENotifyMessageId.TrapDefenseMonsterConsecutiveKillsNotify, new Action<TrapDefenseMonsterConsecutiveKillsNotify, Net.CallbackStatus>(this.OnMonsterConsecutiveKillsNotify));
		Singleton<Net>.Instance.Register<TrapDefenseSpawnMonsterWaveEndNotify>(ENotifyMessageId.TrapDefenseSpawnMonsterWaveEndNotify, new Action<TrapDefenseSpawnMonsterWaveEndNotify, Net.CallbackStatus>(this.OnSpawnMonsterWaveEndNotify));
		Singleton<Net>.Instance.Register<TrapDefenseDevelopInfoUpdateNotify>(ENotifyMessageId.TrapDefenseDevelopInfoUpdateNotify, new Action<TrapDefenseDevelopInfoUpdateNotify, Net.CallbackStatus>(this.OnTrapDefenseDevelopInfoUpdateNotify));
		Singleton<Net>.Instance.Register<TrapDefenseChallengeResultNotify>(ENotifyMessageId.TrapDefenseChallengeResultNotify, new Action<TrapDefenseChallengeResultNotify, Net.CallbackStatus>(this.OnTrapDefenseChallengeResultNotify));
		Singleton<Net>.Instance.Register<TrapDefenseItemUpdateNotify>(ENotifyMessageId.TrapDefenseItemUpdateNotify, new Action<TrapDefenseItemUpdateNotify, Net.CallbackStatus>(this.OnTrapDefenseItemUpdateNotify));
		Singleton<Net>.Instance.Register<TrapDefenseSystemInfoUpdateNotify>(ENotifyMessageId.TrapDefenseSystemInfoUpdateNotify, new Action<TrapDefenseSystemInfoUpdateNotify, Net.CallbackStatus>(this.OnTrapDefenseSystemInfoUpdateNotify));
	}

	// Token: 0x060168E9 RID: 92393 RVA: 0x00642D8E File Offset: 0x00640F8E
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.TrapDefenseBuildingDevelopMainView, new Func<EUiViewName, object, bool>(this.CanOpenDevelopView), "TrapDefenseController.CanOpenDevelopView");
	}

	// Token: 0x060168EA RID: 92394 RVA: 0x00642DB0 File Offset: 0x00640FB0
	protected override void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.TrapDefenseBuildingDevelopMainView, new Func<EUiViewName, object, bool>(this.CanOpenDevelopView));
	}

	// Token: 0x060168EB RID: 92395 RVA: 0x00642DD0 File Offset: 0x00640FD0
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseSystemInfoNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseSyncGainingGroupsNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseRewardGainingGroupsNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseMonsterConsecutiveKillsNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseSpawnMonsterWaveEndNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseDevelopInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseChallengeResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseItemUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.TrapDefenseSystemInfoUpdateNotify);
	}

	// Token: 0x060168EC RID: 92396 RVA: 0x00642E6D File Offset: 0x0064106D
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
		Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseInventoryDataUpdate, new Action(this.OnTrapDefenseInventoryDataUpdate));
	}

	// Token: 0x060168ED RID: 92397 RVA: 0x00642EA7 File Offset: 0x006410A7
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnInstanceChange, new Action<int, int>(this.OnInstanceChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseInventoryDataUpdate, new Action(this.OnTrapDefenseInventoryDataUpdate));
	}

	// Token: 0x060168EE RID: 92398 RVA: 0x00642EE4 File Offset: 0x006410E4
	public void RequestTrapDefenseUseItem(int itemId)
	{
		TrapDefenseUseItemRequest trapDefenseUseItemRequest = TrapDefenseUseItemRequest.Create();
		trapDefenseUseItemRequest.ItemConfigId = itemId;
		Singleton<Net>.Instance.Call<TrapDefenseUseItemResponse>(ERequestMessageId.TrapDefenseUseItemRequest, trapDefenseUseItemRequest, delegate(TrapDefenseUseItemResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.TrapDefenseItemNotEnough)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefenseEvent;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "塔防尝试使用道具不足";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ItemId", itemId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29696, null, true, true);
				return;
			}
			TrapDefenseModel instance2 = ModelBase<TrapDefenseModel>.Instance;
			TrapDefenseBattleItemData trapDefenseBattleItemData = (instance2 != null) ? instance2.BattleInventoryData.GetItemData(itemId) : null;
			if (trapDefenseBattleItemData != null && trapDefenseBattleItemData.IsUseSkill)
			{
				TowerDefensePlayerController.PlayerDoSkill(trapDefenseBattleItemData.SkillIndex);
				TrapDefenseModel instance3 = ModelBase<TrapDefenseModel>.Instance;
				if (instance3 == null)
				{
					return;
				}
				instance3.BattleData.RefreshExploreSkillData();
			}
		}, 0);
	}

	// Token: 0x060168EF RID: 92399 RVA: 0x00642F2D File Offset: 0x0064112D
	[NullableContext(1)]
	private void OnTrapDefenseItemUpdateNotify(TrapDefenseItemUpdateNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		if (instance == null)
		{
			return;
		}
		instance.BattleInventoryData.UpdateItemData(data.ItemDatas);
	}

	// Token: 0x060168F0 RID: 92400 RVA: 0x00642F49 File Offset: 0x00641149
	[NullableContext(2)]
	private bool CanOpenDevelopView(EUiViewName viewName, object param)
	{
		return !((ITrapDefenseDevelopOpenParam)param).IsInDungeon || ModelBase<TrapDefenseModel>.Instance.BattleData.IsCanBuildMachine;
	}

	// Token: 0x060168F1 RID: 92401 RVA: 0x00642F6C File Offset: 0x0064116C
	[NullableContext(2)]
	public void OpenOrganDevelop(bool isInDungeon, UiViewBase parentView, int index = 0, TrapDefenseLevelData levelData = null)
	{
		TrapDefenseDevelopOpenParam param = new TrapDefenseDevelopOpenParam
		{
			IsInDungeon = isInDungeon,
			SelectedIndex = index,
			LevelData = levelData
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseBuildingDevelopMainView, param, delegate(bool success, int viewId)
		{
			if (success && parentView != null)
			{
				parentView.AddChildViewById(viewId);
			}
		});
	}

	// Token: 0x060168F2 RID: 92402 RVA: 0x00642FBE File Offset: 0x006411BE
	[NullableContext(1)]
	private void OnTrapDefenseDevelopInfoUpdateNotify(TrapDefenseDevelopInfoUpdateNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.UpdateDevelopInfo(data);
	}

	// Token: 0x060168F3 RID: 92403 RVA: 0x00642FD0 File Offset: 0x006411D0
	[NullableContext(1)]
	public void OpenDefenseChallengeResultView(TrapDefenseChallengeResultNotify data, bool needShowViewAnim)
	{
		TrapDefenseResultViewInfo param = new TrapDefenseResultViewInfo
		{
			Notify = data,
			NeedShowViewAnim = needShowViewAnim
		};
		Singleton<AudioSystem>.Instance.ExecuteAction("play_2_6_tower_defence_music_ingame", EAudioActionType.Stop, null);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseResultView, param, null);
	}

	// Token: 0x060168F4 RID: 92404 RVA: 0x0064301B File Offset: 0x0064121B
	[NullableContext(1)]
	private void OnTrapDefenseChallengeResultNotify(TrapDefenseChallengeResultNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		if (!this.IsActivityInited)
		{
			this.ResultNotifyCache = data;
			return;
		}
		this.OpenDefenseChallengeResultView(data, false);
	}

	// Token: 0x060168F5 RID: 92405 RVA: 0x00643038 File Offset: 0x00641238
	public void RequestTrapDefenseDevelopReset()
	{
		TrapDefenseDevelopResetRequest trapDefenseDevelopResetRequest = TrapDefenseDevelopResetRequest.Create();
		trapDefenseDevelopResetRequest.ActivityId = ModelBase<TrapDefenseModel>.Instance.GetActivityId();
		Singleton<Net>.Instance.Call<TrapDefenseDevelopResetResponse>(ERequestMessageId.TrapDefenseDevelopResetRequest, trapDefenseDevelopResetRequest, delegate(TrapDefenseDevelopResetResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29832, null, true, true);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TrapDefense_Building_Reset_Text", Array.Empty<object>());
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.ResetAllOrgan();
			Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseOnDevelopResetAll);
		}, 0);
	}

	// Token: 0x060168F6 RID: 92406 RVA: 0x0064308C File Offset: 0x0064128C
	public void RequestTrapDefenseDevelopLevelUp(int id)
	{
		ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(id);
		ITrapDefenseMachineIdInfo info = new ITrapDefenseMachineIdInfo
		{
			MachineType = trapDefenseMachineIdInfo.MachineType,
			DataType = trapDefenseMachineIdInfo.DataType,
			Level = trapDefenseMachineIdInfo.Level + 1,
			Branch = trapDefenseMachineIdInfo.Branch
		};
		int newId = ModelBase<TrapDefenseModel>.Instance.ComposeMachineId(info);
		if (trapDefenseMachineIdInfo.MachineType == ETrapDefenseMachineType.Auxiliary)
		{
			this.RequestTrapDefenseAuxiliaryLevelUp(trapDefenseMachineIdInfo.DataType, newId);
			return;
		}
		this.RequestTrapDefenseBuildingLevelUp(trapDefenseMachineIdInfo.DataType, newId);
	}

	// Token: 0x060168F7 RID: 92407 RVA: 0x00643110 File Offset: 0x00641310
	private void RequestTrapDefenseBuildingLevelUp(int typeId, int newId)
	{
		TrapDefenseBuildingLevelUpRequest trapDefenseBuildingLevelUpRequest = TrapDefenseBuildingLevelUpRequest.Create();
		trapDefenseBuildingLevelUpRequest.Id = typeId;
		Singleton<Net>.Instance.Call<TrapDefenseBuildingLevelUpResponse>(ERequestMessageId.TrapDefenseBuildingLevelUpRequest, trapDefenseBuildingLevelUpRequest, delegate(TrapDefenseBuildingLevelUpResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 26108, null, true, true);
				return;
			}
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.OnItemUpdate(newId);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TowerDefense_Building_LevelUp", Array.Empty<object>());
		}, 0);
	}

	// Token: 0x060168F8 RID: 92408 RVA: 0x00643154 File Offset: 0x00641354
	private void RequestTrapDefenseAuxiliaryLevelUp(int typeId, int newId)
	{
		TrapDefenseAuxiliaryLevelUpRequest trapDefenseAuxiliaryLevelUpRequest = TrapDefenseAuxiliaryLevelUpRequest.Create();
		trapDefenseAuxiliaryLevelUpRequest.Id = typeId;
		Singleton<Net>.Instance.Call<TrapDefenseAuxiliaryLevelUpResponse>(ERequestMessageId.TrapDefenseAuxiliaryLevelUpRequest, trapDefenseAuxiliaryLevelUpRequest, delegate(TrapDefenseAuxiliaryLevelUpResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19850, null, true, true);
				return;
			}
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.OnItemUpdate(newId);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TowerDefense_Building_LevelUp", Array.Empty<object>());
		}, 0);
	}

	// Token: 0x060168F9 RID: 92409 RVA: 0x00643198 File Offset: 0x00641398
	public void RequestTrapDefenseDevelopResetOne(int id)
	{
		ITrapDefenseMachineIdInfo trapDefenseMachineIdInfo = ModelBase<TrapDefenseModel>.Instance.DecomposeMachineId(id);
		ITrapDefenseMachineIdInfo info = new ITrapDefenseMachineIdInfo
		{
			MachineType = trapDefenseMachineIdInfo.MachineType,
			DataType = trapDefenseMachineIdInfo.DataType,
			Level = 1,
			Branch = 0
		};
		int newId = ModelBase<TrapDefenseModel>.Instance.ComposeMachineId(info);
		if (trapDefenseMachineIdInfo.MachineType == ETrapDefenseMachineType.Auxiliary)
		{
			this.RequestTrapDefenseAuxiliaryReset(trapDefenseMachineIdInfo.DataType, newId);
			return;
		}
		this.RequestTrapDefenseBuildingReset(trapDefenseMachineIdInfo.DataType, newId);
	}

	// Token: 0x060168FA RID: 92410 RVA: 0x00643210 File Offset: 0x00641410
	private void RequestTrapDefenseBuildingReset(int typeId, int newId)
	{
		TrapDefenseBuildingResetRequest trapDefenseBuildingResetRequest = TrapDefenseBuildingResetRequest.Create();
		trapDefenseBuildingResetRequest.Id = typeId;
		Singleton<Net>.Instance.Call<TrapDefenseBuildingResetResponse>(ERequestMessageId.TrapDefenseBuildingResetRequest, trapDefenseBuildingResetRequest, delegate(TrapDefenseBuildingResetResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23324, null, true, true);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TrapDefense_Building_Reset_Text", Array.Empty<object>());
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.OnItemUpdate(newId);
		}, 0);
	}

	// Token: 0x060168FB RID: 92411 RVA: 0x00643254 File Offset: 0x00641454
	private void RequestTrapDefenseAuxiliaryReset(int typeId, int newId)
	{
		TrapDefenseAuxiliaryResetRequest trapDefenseAuxiliaryResetRequest = TrapDefenseAuxiliaryResetRequest.Create();
		trapDefenseAuxiliaryResetRequest.Id = typeId;
		Singleton<Net>.Instance.Call<TrapDefenseAuxiliaryResetResponse>(ERequestMessageId.TrapDefenseAuxiliaryResetRequest, trapDefenseAuxiliaryResetRequest, delegate(TrapDefenseAuxiliaryResetResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19164, null, true, true);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("TrapDefense_Building_Reset_Text", Array.Empty<object>());
			ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.OnItemUpdate(newId);
		}, 0);
	}

	// Token: 0x060168FC RID: 92412 RVA: 0x00643298 File Offset: 0x00641498
	public UniTask<bool> RequestTrapDefenseDevelopBranch(int id)
	{
		TrapDefenseController.<RequestTrapDefenseDevelopBranch>d__22 <RequestTrapDefenseDevelopBranch>d__;
		<RequestTrapDefenseDevelopBranch>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestTrapDefenseDevelopBranch>d__.<>4__this = this;
		<RequestTrapDefenseDevelopBranch>d__.id = id;
		<RequestTrapDefenseDevelopBranch>d__.<>1__state = -1;
		<RequestTrapDefenseDevelopBranch>d__.<>t__builder.Start<TrapDefenseController.<RequestTrapDefenseDevelopBranch>d__22>(ref <RequestTrapDefenseDevelopBranch>d__);
		return <RequestTrapDefenseDevelopBranch>d__.<>t__builder.Task;
	}

	// Token: 0x060168FD RID: 92413 RVA: 0x006432E4 File Offset: 0x006414E4
	private UniTask<bool> RequestTrapDefenseBuildingBranch(int typeId, int branch, int newId)
	{
		TrapDefenseController.<RequestTrapDefenseBuildingBranch>d__23 <RequestTrapDefenseBuildingBranch>d__;
		<RequestTrapDefenseBuildingBranch>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestTrapDefenseBuildingBranch>d__.typeId = typeId;
		<RequestTrapDefenseBuildingBranch>d__.branch = branch;
		<RequestTrapDefenseBuildingBranch>d__.newId = newId;
		<RequestTrapDefenseBuildingBranch>d__.<>1__state = -1;
		<RequestTrapDefenseBuildingBranch>d__.<>t__builder.Start<TrapDefenseController.<RequestTrapDefenseBuildingBranch>d__23>(ref <RequestTrapDefenseBuildingBranch>d__);
		return <RequestTrapDefenseBuildingBranch>d__.<>t__builder.Task;
	}

	// Token: 0x060168FE RID: 92414 RVA: 0x00643338 File Offset: 0x00641538
	private UniTask<bool> RequestTrapDefenseAuxiliaryBranch(int typeId, int branch, int newId)
	{
		TrapDefenseController.<RequestTrapDefenseAuxiliaryBranch>d__24 <RequestTrapDefenseAuxiliaryBranch>d__;
		<RequestTrapDefenseAuxiliaryBranch>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestTrapDefenseAuxiliaryBranch>d__.typeId = typeId;
		<RequestTrapDefenseAuxiliaryBranch>d__.branch = branch;
		<RequestTrapDefenseAuxiliaryBranch>d__.newId = newId;
		<RequestTrapDefenseAuxiliaryBranch>d__.<>1__state = -1;
		<RequestTrapDefenseAuxiliaryBranch>d__.<>t__builder.Start<TrapDefenseController.<RequestTrapDefenseAuxiliaryBranch>d__24>(ref <RequestTrapDefenseAuxiliaryBranch>d__);
		return <RequestTrapDefenseAuxiliaryBranch>d__.<>t__builder.Task;
	}

	// Token: 0x060168FF RID: 92415 RVA: 0x0064338C File Offset: 0x0064158C
	[NullableContext(1)]
	private void OnMonsterConsecutiveKillsNotify(TrapDefenseMonsterConsecutiveKillsNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.TowerDefenseBattle;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "怪物连击通知";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("连击数", data.ConsecutiveKillCount);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		ModelBase<TrapDefenseModel>.Instance.BattleData.SetComboNum(data.ConsecutiveKillCount);
	}

	// Token: 0x06016900 RID: 92416 RVA: 0x006433E4 File Offset: 0x006415E4
	[NullableContext(1)]
	private void OnSpawnMonsterWaveEndNotify(TrapDefenseSpawnMonsterWaveEndNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.TowerDefenseBattle;
		ELogAuthor author = ELogAuthor.XXJ;
		string message = "怪物波次结束通知";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("倒计时", data.CountdownSecond);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		this.StartRoundTips((float)data.CountdownSecond);
	}

	// Token: 0x06016901 RID: 92417 RVA: 0x00643433 File Offset: 0x00641633
	public void OpenPauseView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefensePauseView, null, null);
	}

	// Token: 0x06016902 RID: 92418 RVA: 0x00643448 File Offset: 0x00641648
	[NullableContext(2)]
	public void OpenTrapDefenseShopOpenTips(Action callback = null)
	{
		TrapDefenseShopTipsData param = new TrapDefenseShopTipsData
		{
			Callback = callback
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseEventShopOpenTips, param, null);
	}

	// Token: 0x06016903 RID: 92419 RVA: 0x00643474 File Offset: 0x00641674
	public UniTask<bool> OpenTrapDefenseTerrainChangeTips([Nullable(2)] Action callback = null)
	{
		TrapDefenseController.<OpenTrapDefenseTerrainChangeTips>d__29 <OpenTrapDefenseTerrainChangeTips>d__;
		<OpenTrapDefenseTerrainChangeTips>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenTrapDefenseTerrainChangeTips>d__.callback = callback;
		<OpenTrapDefenseTerrainChangeTips>d__.<>1__state = -1;
		<OpenTrapDefenseTerrainChangeTips>d__.<>t__builder.Start<TrapDefenseController.<OpenTrapDefenseTerrainChangeTips>d__29>(ref <OpenTrapDefenseTerrainChangeTips>d__);
		return <OpenTrapDefenseTerrainChangeTips>d__.<>t__builder.Task;
	}

	// Token: 0x06016904 RID: 92420 RVA: 0x006434B8 File Offset: 0x006416B8
	public UniTask<bool> OpenTrapDefenseBossComingTips([Nullable(2)] Action callback = null)
	{
		TrapDefenseController.<OpenTrapDefenseBossComingTips>d__30 <OpenTrapDefenseBossComingTips>d__;
		<OpenTrapDefenseBossComingTips>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<OpenTrapDefenseBossComingTips>d__.callback = callback;
		<OpenTrapDefenseBossComingTips>d__.<>1__state = -1;
		<OpenTrapDefenseBossComingTips>d__.<>t__builder.Start<TrapDefenseController.<OpenTrapDefenseBossComingTips>d__30>(ref <OpenTrapDefenseBossComingTips>d__);
		return <OpenTrapDefenseBossComingTips>d__.<>t__builder.Task;
	}

	// Token: 0x06016905 RID: 92421 RVA: 0x006434FC File Offset: 0x006416FC
	[NullableContext(2)]
	public void OpenTrapDefenseRoundTips(int round, Action callback = null)
	{
		TrapDefenseRoundTipsData param = new TrapDefenseRoundTipsData
		{
			Round = round,
			Callback = callback
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseRoundTips, param, null);
	}

	// Token: 0x06016906 RID: 92422 RVA: 0x00643530 File Offset: 0x00641730
	[NullableContext(2)]
	public void OpenTrapDefenseCountDownTips(float countDownTime, Action callback = null)
	{
		TrapDefenseCountDownTipsData param = new TrapDefenseCountDownTipsData
		{
			CountDownTime = countDownTime,
			Callback = callback
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseCountDownTips, param, null);
	}

	// Token: 0x06016907 RID: 92423 RVA: 0x00643564 File Offset: 0x00641764
	private UniTask StartChallengeCountDown(float countDownTime)
	{
		TrapDefenseController.<StartChallengeCountDown>d__33 <StartChallengeCountDown>d__;
		<StartChallengeCountDown>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartChallengeCountDown>d__.<>4__this = this;
		<StartChallengeCountDown>d__.countDownTime = countDownTime;
		<StartChallengeCountDown>d__.<>1__state = -1;
		<StartChallengeCountDown>d__.<>t__builder.Start<TrapDefenseController.<StartChallengeCountDown>d__33>(ref <StartChallengeCountDown>d__);
		return <StartChallengeCountDown>d__.<>t__builder.Task;
	}

	// Token: 0x06016908 RID: 92424 RVA: 0x006435B0 File Offset: 0x006417B0
	private UniTask StartChallengeBatchTips()
	{
		TrapDefenseController.<StartChallengeBatchTips>d__34 <StartChallengeBatchTips>d__;
		<StartChallengeBatchTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartChallengeBatchTips>d__.<>4__this = this;
		<StartChallengeBatchTips>d__.<>1__state = -1;
		<StartChallengeBatchTips>d__.<>t__builder.Start<TrapDefenseController.<StartChallengeBatchTips>d__34>(ref <StartChallengeBatchTips>d__);
		return <StartChallengeBatchTips>d__.<>t__builder.Task;
	}

	// Token: 0x06016909 RID: 92425 RVA: 0x006435F4 File Offset: 0x006417F4
	private UniTask StartRoundTips(float countDownTime)
	{
		TrapDefenseController.<StartRoundTips>d__35 <StartRoundTips>d__;
		<StartRoundTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartRoundTips>d__.<>4__this = this;
		<StartRoundTips>d__.countDownTime = countDownTime;
		<StartRoundTips>d__.<>1__state = -1;
		<StartRoundTips>d__.<>t__builder.Start<TrapDefenseController.<StartRoundTips>d__35>(ref <StartRoundTips>d__);
		return <StartRoundTips>d__.<>t__builder.Task;
	}

	// Token: 0x0601690A RID: 92426 RVA: 0x00643640 File Offset: 0x00641840
	public UniTask StartChallengeRoundTips()
	{
		TrapDefenseController.<StartChallengeRoundTips>d__36 <StartChallengeRoundTips>d__;
		<StartChallengeRoundTips>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartChallengeRoundTips>d__.<>4__this = this;
		<StartChallengeRoundTips>d__.<>1__state = -1;
		<StartChallengeRoundTips>d__.<>t__builder.Start<TrapDefenseController.<StartChallengeRoundTips>d__36>(ref <StartChallengeRoundTips>d__);
		return <StartChallengeRoundTips>d__.<>t__builder.Task;
	}

	// Token: 0x0601690B RID: 92427 RVA: 0x00643684 File Offset: 0x00641884
	public void RefreshTrapDefenseMainView()
	{
		UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CommonGameMainView);
		if (viewByName != null)
		{
			TrapDefenseMainViewProxy trapDefenseMainViewProxy = viewByName.OpenParam as TrapDefenseMainViewProxy;
			if (trapDefenseMainViewProxy == null)
			{
				return;
			}
			trapDefenseMainViewProxy.RefreshSelectPanel();
		}
	}

	// Token: 0x0601690C RID: 92428 RVA: 0x006436BC File Offset: 0x006418BC
	[NullableContext(1)]
	private void OnTrapDefenseSystemInfoNotify(TrapDefenseSystemInfoNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		if (instance != null)
		{
			instance.BattleData.SetBehaviorTreeVar(data.VariableKeyNames.ToDictionary<string, string>());
		}
		TrapDefenseModel instance2 = ModelBase<TrapDefenseModel>.Instance;
		if (instance2 != null)
		{
			TrapDefenseBattleData battleData = instance2.BattleData;
			TrapDefenseTechParam techParams = data.TechParams;
			battleData.SetTechParamMapVar((techParams != null) ? techParams.Params.ToDictionary<int, int>() : null);
		}
		TrapDefenseModel instance3 = ModelBase<TrapDefenseModel>.Instance;
		if (instance3 != null)
		{
			instance3.ViewModelBuildingDevelop.InitInBattle(data);
		}
		TrapDefenseModel instance4 = ModelBase<TrapDefenseModel>.Instance;
		if (instance4 != null)
		{
			instance4.BattleInventoryData.UpdateItemData(data.ItemDatas);
		}
		if (data.ChangedMiniMap != 0)
		{
			this.ChangeMap(data.ChangedMiniMap);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.TrapDefenseOnSystemInfoNotify);
	}

	// Token: 0x0601690D RID: 92429 RVA: 0x0064376C File Offset: 0x0064196C
	public UniTask<bool> RequestBdBuffSelect(int id)
	{
		TrapDefenseController.<RequestBdBuffSelect>d__39 <RequestBdBuffSelect>d__;
		<RequestBdBuffSelect>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestBdBuffSelect>d__.id = id;
		<RequestBdBuffSelect>d__.<>1__state = -1;
		<RequestBdBuffSelect>d__.<>t__builder.Start<TrapDefenseController.<RequestBdBuffSelect>d__39>(ref <RequestBdBuffSelect>d__);
		return <RequestBdBuffSelect>d__.<>t__builder.Task;
	}

	// Token: 0x0601690E RID: 92430 RVA: 0x006437B0 File Offset: 0x006419B0
	public UniTask<bool> RequestBdBuffRefresh()
	{
		TrapDefenseController.<RequestBdBuffRefresh>d__40 <RequestBdBuffRefresh>d__;
		<RequestBdBuffRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestBdBuffRefresh>d__.<>1__state = -1;
		<RequestBdBuffRefresh>d__.<>t__builder.Start<TrapDefenseController.<RequestBdBuffRefresh>d__40>(ref <RequestBdBuffRefresh>d__);
		return <RequestBdBuffRefresh>d__.<>t__builder.Task;
	}

	// Token: 0x0601690F RID: 92431 RVA: 0x006437EC File Offset: 0x006419EC
	public UniTask<bool> RequestChallenge([Nullable(1)] TrapDefenseLevelData data, bool fromSaveStar = false)
	{
		TrapDefenseController.<RequestChallenge>d__41 <RequestChallenge>d__;
		<RequestChallenge>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestChallenge>d__.data = data;
		<RequestChallenge>d__.fromSaveStar = fromSaveStar;
		<RequestChallenge>d__.<>1__state = -1;
		<RequestChallenge>d__.<>t__builder.Start<TrapDefenseController.<RequestChallenge>d__41>(ref <RequestChallenge>d__);
		return <RequestChallenge>d__.<>t__builder.Task;
	}

	// Token: 0x06016910 RID: 92432 RVA: 0x00643838 File Offset: 0x00641A38
	public UniTask<bool> RequestTrapDefenseChallengeQuit(bool needSettle)
	{
		TrapDefenseController.<RequestTrapDefenseChallengeQuit>d__42 <RequestTrapDefenseChallengeQuit>d__;
		<RequestTrapDefenseChallengeQuit>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestTrapDefenseChallengeQuit>d__.needSettle = needSettle;
		<RequestTrapDefenseChallengeQuit>d__.<>1__state = -1;
		<RequestTrapDefenseChallengeQuit>d__.<>t__builder.Start<TrapDefenseController.<RequestTrapDefenseChallengeQuit>d__42>(ref <RequestTrapDefenseChallengeQuit>d__);
		return <RequestTrapDefenseChallengeQuit>d__.<>t__builder.Task;
	}

	// Token: 0x06016911 RID: 92433 RVA: 0x0064387C File Offset: 0x00641A7C
	public UniTask<bool> RequestTrapDefenseSlotUpdate([Nullable(1)] List<TrapDefenseSlot> slotList)
	{
		TrapDefenseController.<RequestTrapDefenseSlotUpdate>d__43 <RequestTrapDefenseSlotUpdate>d__;
		<RequestTrapDefenseSlotUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestTrapDefenseSlotUpdate>d__.slotList = slotList;
		<RequestTrapDefenseSlotUpdate>d__.<>1__state = -1;
		<RequestTrapDefenseSlotUpdate>d__.<>t__builder.Start<TrapDefenseController.<RequestTrapDefenseSlotUpdate>d__43>(ref <RequestTrapDefenseSlotUpdate>d__);
		return <RequestTrapDefenseSlotUpdate>d__.<>t__builder.Task;
	}

	// Token: 0x06016912 RID: 92434 RVA: 0x006438C0 File Offset: 0x00641AC0
	public UniTask<int> RequestTrapDefenseCurChallengeInfo()
	{
		TrapDefenseController.<RequestTrapDefenseCurChallengeInfo>d__44 <RequestTrapDefenseCurChallengeInfo>d__;
		<RequestTrapDefenseCurChallengeInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder<int>.Create();
		<RequestTrapDefenseCurChallengeInfo>d__.<>1__state = -1;
		<RequestTrapDefenseCurChallengeInfo>d__.<>t__builder.Start<TrapDefenseController.<RequestTrapDefenseCurChallengeInfo>d__44>(ref <RequestTrapDefenseCurChallengeInfo>d__);
		return <RequestTrapDefenseCurChallengeInfo>d__.<>t__builder.Task;
	}

	// Token: 0x06016913 RID: 92435 RVA: 0x006438FC File Offset: 0x00641AFC
	[NullableContext(1)]
	private void OnTrapDefenseSystemInfoUpdateNotify(TrapDefenseSystemInfoUpdateNotify data, [Nullable(2)] Net.CallbackStatus status)
	{
		RepeatedField<TrapDefenseSlot> slots = data.Slots;
		ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.UploadSlotChangeByNotify(new List<TrapDefenseSlot>(slots));
	}

	// Token: 0x06016914 RID: 92436 RVA: 0x00643928 File Offset: 0x00641B28
	public UniTask<bool> RequestTrapDefenseRewardClaim([Nullable(1)] IReadOnlyList<int> ids)
	{
		TrapDefenseController.<RequestTrapDefenseRewardClaim>d__46 <RequestTrapDefenseRewardClaim>d__;
		<RequestTrapDefenseRewardClaim>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestTrapDefenseRewardClaim>d__.ids = ids;
		<RequestTrapDefenseRewardClaim>d__.<>1__state = -1;
		<RequestTrapDefenseRewardClaim>d__.<>t__builder.Start<TrapDefenseController.<RequestTrapDefenseRewardClaim>d__46>(ref <RequestTrapDefenseRewardClaim>d__);
		return <RequestTrapDefenseRewardClaim>d__.<>t__builder.Task;
	}

	// Token: 0x06016915 RID: 92437 RVA: 0x0064396C File Offset: 0x00641B6C
	public UniTask<bool> RequestTrapDefenseSpecialRewardClaim(int id)
	{
		TrapDefenseController.<RequestTrapDefenseSpecialRewardClaim>d__47 <RequestTrapDefenseSpecialRewardClaim>d__;
		<RequestTrapDefenseSpecialRewardClaim>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestTrapDefenseSpecialRewardClaim>d__.id = id;
		<RequestTrapDefenseSpecialRewardClaim>d__.<>1__state = -1;
		<RequestTrapDefenseSpecialRewardClaim>d__.<>t__builder.Start<TrapDefenseController.<RequestTrapDefenseSpecialRewardClaim>d__47>(ref <RequestTrapDefenseSpecialRewardClaim>d__);
		return <RequestTrapDefenseSpecialRewardClaim>d__.<>t__builder.Task;
	}

	// Token: 0x06016916 RID: 92438 RVA: 0x006439B0 File Offset: 0x00641BB0
	public UniTask<bool> RequestTrapDefenseTechUnlock(int id)
	{
		TrapDefenseController.<RequestTrapDefenseTechUnlock>d__48 <RequestTrapDefenseTechUnlock>d__;
		<RequestTrapDefenseTechUnlock>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestTrapDefenseTechUnlock>d__.id = id;
		<RequestTrapDefenseTechUnlock>d__.<>1__state = -1;
		<RequestTrapDefenseTechUnlock>d__.<>t__builder.Start<TrapDefenseController.<RequestTrapDefenseTechUnlock>d__48>(ref <RequestTrapDefenseTechUnlock>d__);
		return <RequestTrapDefenseTechUnlock>d__.<>t__builder.Task;
	}

	// Token: 0x06016917 RID: 92439 RVA: 0x006439F4 File Offset: 0x00641BF4
	public UniTask<bool> RequestTrapDefenseShopRefresh()
	{
		TrapDefenseController.<RequestTrapDefenseShopRefresh>d__49 <RequestTrapDefenseShopRefresh>d__;
		<RequestTrapDefenseShopRefresh>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestTrapDefenseShopRefresh>d__.<>1__state = -1;
		<RequestTrapDefenseShopRefresh>d__.<>t__builder.Start<TrapDefenseController.<RequestTrapDefenseShopRefresh>d__49>(ref <RequestTrapDefenseShopRefresh>d__);
		return <RequestTrapDefenseShopRefresh>d__.<>t__builder.Task;
	}

	// Token: 0x06016918 RID: 92440 RVA: 0x00643A30 File Offset: 0x00641C30
	public UniTask<bool> RequestTrapDefenseShopPurchase(int id, ETrapDefenseShopGoodsType type, int count = 1)
	{
		TrapDefenseController.<RequestTrapDefenseShopPurchase>d__50 <RequestTrapDefenseShopPurchase>d__;
		<RequestTrapDefenseShopPurchase>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestTrapDefenseShopPurchase>d__.id = id;
		<RequestTrapDefenseShopPurchase>d__.type = type;
		<RequestTrapDefenseShopPurchase>d__.count = count;
		<RequestTrapDefenseShopPurchase>d__.<>1__state = -1;
		<RequestTrapDefenseShopPurchase>d__.<>t__builder.Start<TrapDefenseController.<RequestTrapDefenseShopPurchase>d__50>(ref <RequestTrapDefenseShopPurchase>d__);
		return <RequestTrapDefenseShopPurchase>d__.<>t__builder.Task;
	}

	// Token: 0x06016919 RID: 92441 RVA: 0x00643A84 File Offset: 0x00641C84
	public void UpdateEnemyPositions()
	{
		FKSC_MiniMapContext[] entityPositions = ControllerBase<KuroSimpleCombatController>.Instance.GetEntityPositions();
		if (entityPositions == null)
		{
			return;
		}
		ModelBase<TrapDefenseModel>.Instance.MapData.UpdateEnemyPositions(new List<FKSC_MiniMapContext>(entityPositions));
	}

	// Token: 0x0601691A RID: 92442 RVA: 0x00643AB5 File Offset: 0x00641CB5
	public void ChangeMap(int mapId)
	{
		ModelBase<TrapDefenseModel>.Instance.MapData.ChangeMap(mapId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.TrapDefenseMapChanged, mapId);
	}

	// Token: 0x0601691B RID: 92443 RVA: 0x00643AD8 File Offset: 0x00641CD8
	private void OnInstanceChange(int lastInstanceId, int newInstanceId)
	{
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(newInstanceId);
		if (config != null && config.Value.InstSubType == 37)
		{
			ControllerBase<SkillButtonUiController>.Instance.AddEventInterface(ModelBase<TrapDefenseModel>.Instance.BattleData);
			return;
		}
		ControllerBase<SkillButtonUiController>.Instance.RemoveEventInterface(ModelBase<TrapDefenseModel>.Instance.BattleData);
	}

	// Token: 0x0601691C RID: 92444 RVA: 0x00643B36 File Offset: 0x00641D36
	private void OnTrapDefenseInventoryDataUpdate()
	{
		ModelBase<TrapDefenseModel>.Instance.BattleData.RefreshExploreSkillData();
	}

	// Token: 0x0400AE52 RID: 44626
	[Nullable(2)]
	public TrapDefenseChallengeResultNotify ResultNotifyCache;

	// Token: 0x0400AE53 RID: 44627
	public bool IsActivityInited;
}
