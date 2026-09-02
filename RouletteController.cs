using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Functional;
using CSharpScript.Game.Module.SkillButtonUi;
using CSharpScript.Game.NewWorld.Character.Common.Component.Explore;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

// Token: 0x0200292B RID: 10539
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class RouletteController : UiControllerBase<RouletteController>
{
	// Token: 0x06014EBD RID: 85693 RVA: 0x005CA25B File Offset: 0x005C845B
	protected override bool OnInit()
	{
		Singleton<InputManager>.Instance.RegisterOpenViewFunc(EUiViewName.PhantomExploreSetView, new Action(this.OpenView));
		return true;
	}

	// Token: 0x06014EBE RID: 85694 RVA: 0x005CA27C File Offset: 0x005C847C
	private void OpenView()
	{
		ControllerBase<RouletteController>.Instance.OpenAssemblyView(ERouletteType.Explore, null, null, null);
	}

	// Token: 0x06014EBF RID: 85695 RVA: 0x005CA2B0 File Offset: 0x005C84B0
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<VisionExploreSkillNotify>(ENotifyMessageId.VisionExploreSkillNotify, delegate(VisionExploreSkillNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.Phantom, ELogAuthor.YYZ, "推送探索技能设置更新信息", default(ReadOnlySpan<ValueTuple<string, object>>));
			int exploreSkill = response.ExploreSkill;
			ModelBase<CharacterExploreModel>.Instance.SetDefaultExploreSkillId(exploreSkill);
			ModelBase<RouletteModel>.Instance.CurrentExploreSkillId = exploreSkill;
		});
		Singleton<Net>.Instance.Register<ExploreSkillRouletteUpdateNotify>(ENotifyMessageId.ExploreSkillRouletteUpdateNotify, delegate(ExploreSkillRouletteUpdateNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.Phantom, ELogAuthor.YYZ, "推送当前轮盘保存的数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<RouletteModel>.Instance.UpdateRouletteData(response.RouletteInfo.ToList<ExploreSkillRoulette>());
		});
		Singleton<Net>.Instance.Register<ExploreToolUpdateNotify>(ENotifyMessageId.ExploreToolUpdateNotify, delegate(ExploreToolUpdateNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "推送探索技能解锁";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", response.SkillId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ModelBase<RouletteModel>.Instance.UnlockExploreSkill(response.SkillId, true);
		});
		Singleton<Net>.Instance.Register<ExploreToolAllNotify>(ENotifyMessageId.ExploreToolAllNotify, delegate(ExploreToolAllNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			if (response == null)
			{
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.Phantom, ELogAuthor.YYZ, "推送所有已解锁的探索技能及当前装备的探索技能", default(ReadOnlySpan<ValueTuple<string, object>>));
			ModelBase<RouletteModel>.Instance.CreateAllUnlockExploreSkill(response.SkillList.ToList<int>());
			ModelBase<RouletteModel>.Instance.CurrentExploreSkillId = response.ExploreSkill;
			RepeatedField<int> newUnlock = response.NewUnlock;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "新解锁探索技能";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("NewUnlock", newUnlock);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			foreach (int id in newUnlock)
			{
				ModelBase<RouletteModel>.Instance.UnlockExploreSkill(id, true);
			}
		});
	}

	// Token: 0x06014EC0 RID: 85696 RVA: 0x005CA37C File Offset: 0x005C857C
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.VisionExploreSkillNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ExploreSkillRouletteUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ExploreToolUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ExploreToolAllNotify);
	}

	// Token: 0x06014EC1 RID: 85697 RVA: 0x005CA3CC File Offset: 0x005C85CC
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseExploreSkill));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnItemUse, new Action<int, int>(this.OnRefreshExploreSkillButton));
		Singleton<EventSystem>.Instance.Add<int, long, int>(EEventName.OnUseBuffItem, new Action<int, long, int>(this.OnUseBuffItem));
		Singleton<EventSystem>.Instance.Add<ERouletteExploreId, int>(EEventName.OnMapExploreToolPlaceNumUpdated, new Action<ERouletteExploreId, int>(this.OnMapExploreToolPlaceNumUpdated));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRefreshTempFishingPointNum, new Action(this.OnRefreshTempFishingPointNum));
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06014EC2 RID: 85698 RVA: 0x005CA480 File Offset: 0x005C8680
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, int, bool>(EEventName.CharUseSkill, new Action<int, int, bool>(this.OnCharUseExploreSkill));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemUse, new <>f__AnonymousDelegate9<int, int>(this.OnRefreshExploreSkillButton));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnUseBuffItem, new Action<int, long, int>(this.OnUseBuffItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnMapExploreToolPlaceNumUpdated, new Action<ERouletteExploreId, int>(this.OnMapExploreToolPlaceNumUpdated));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRefreshTempFishingPointNum, new Action(this.OnRefreshTempFishingPointNum));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06014EC3 RID: 85699 RVA: 0x005CA534 File Offset: 0x005C8734
	[NullableContext(2)]
	public unsafe void ExploreSkillSetRequest(int skillId, Action<bool> callBack = null, bool autoChange = false)
	{
		if (!ControllerBase<RouletteController>.Instance.CheckCanExploreSkillEquip(skillId))
		{
			Action<bool> callBack2 = callBack;
			if (callBack2 == null)
			{
				return;
			}
			callBack2(false);
			return;
		}
		else
		{
			RouletteListDataBase currentRouletteListData = ModelBase<RouletteModel>.Instance.GetCurrentExploreRouletteListData();
			if (!currentRouletteListData.IsExploreSkillIdAllowEquip(skillId))
			{
				Action<bool> callBack3 = callBack;
				if (callBack3 == null)
				{
					return;
				}
				callBack3(false);
				return;
			}
			else
			{
				List<int> onSettingList = ModelBase<RouletteModel>.Instance.OnSettingExploreSkillIdList;
				int? num = (onSettingList.Count > 0) ? new int?(onSettingList[onSettingList.Count - 1]) : null;
				if (num == null && ModelBase<RouletteModel>.Instance.CurrentExploreSkillId == skillId)
				{
					Action<bool> callBack4 = callBack;
					if (callBack4 == null)
					{
						return;
					}
					callBack4(false);
					return;
				}
				else
				{
					int? num2 = num;
					if (!(num2.GetValueOrDefault() == skillId & num2 != null))
					{
						ModelBase<RouletteModel>.Instance.OnSettingExploreSkillIdList.Add(skillId);
						VisionExploreSkillSetRequest visionExploreSkillSetRequest = VisionExploreSkillSetRequest.Create();
						visionExploreSkillSetRequest.SkillId = skillId;
						visionExploreSkillSetRequest.IsAutoChange = autoChange;
						visionExploreSkillSetRequest.RouletteType = RouletteDefine.rouletteTypeDefine[currentRouletteListData.RouletteType];
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Phantom;
						ELogAuthor author = ELogAuthor.YYZ;
						string message = "请求设置探索技能";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("skillId", skillId);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RouletteType", currentRouletteListData.RouletteType);
						instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
						Singleton<Net>.Instance.Call<VisionExploreSkillSetResponse>(ERequestMessageId.VisionExploreSkillSetRequest, visionExploreSkillSetRequest, delegate(VisionExploreSkillSetResponse response, Net.CallbackStatus _)
						{
							if (onSettingList.Count > 0)
							{
								onSettingList.RemoveAt(0);
							}
							if (response == null)
							{
								Action<bool> callBack6 = callBack;
								if (callBack6 == null)
								{
									return;
								}
								callBack6(false);
								return;
							}
							else
							{
								if (response.ErrCode != Aki.Protocol.ErrorCode.Success)
								{
									Action<bool> callBack7 = callBack;
									if (callBack7 != null)
									{
										callBack7(false);
									}
									ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 15328, null, true, true);
									return;
								}
								ModelBase<RouletteModel>.Instance.CurrentExploreSkillId = response.SkillId;
								currentRouletteListData.EquipExploreSkillIdServer = response.SkillId;
								Action<bool> callBack8 = callBack;
								if (callBack8 == null)
								{
									return;
								}
								callBack8(true);
								return;
							}
						}, 0);
						return;
					}
					Action<bool> callBack5 = callBack;
					if (callBack5 == null)
					{
						return;
					}
					callBack5(false);
					return;
				}
			}
		}
	}

	// Token: 0x06014EC4 RID: 85700 RVA: 0x005CA700 File Offset: 0x005C8900
	public void SaveRouletteDataRequest(IRouletteListSaveData rouletteListData, [Nullable(2)] Action<bool> callback = null)
	{
		ExploreSkillRouletteSetRequest exploreSkillRouletteSetRequest = ExploreSkillRouletteSetRequest.Create();
		ExploreSkillRoulette exploreSkillRoulette = ExploreSkillRoulette.Create();
		exploreSkillRoulette.SkillIds.AddRange(rouletteListData.RouletteIdList);
		exploreSkillRoulette.ExtraItemId = rouletteListData.ExtraItemId;
		exploreSkillRoulette.ExploreSkill = rouletteListData.EquipExploreSkillId;
		exploreSkillRouletteSetRequest.SkillRoulette = exploreSkillRoulette;
		exploreSkillRouletteSetRequest.RouletteType = RouletteDefine.rouletteTypeDefine[rouletteListData.RouletteType];
		Singleton<Net>.Instance.Call<ExploreSkillRouletteSetResponse>(ERequestMessageId.ExploreSkillRouletteSetRequest, exploreSkillRouletteSetRequest, delegate(ExploreSkillRouletteSetResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				Action<bool> callback2 = callback;
				if (callback2 == null)
				{
					return;
				}
				callback2(false);
				return;
			}
			else if (response.ErrCode == Aki.Protocol.ErrorCode.Success)
			{
				if (response.SkillRoulette != null)
				{
					ModelBase<RouletteModel>.Instance.UpdateRouletteDataByType((int)response.RouletteType, response.SkillRoulette);
				}
				Action<bool> callback3 = callback;
				if (callback3 == null)
				{
					return;
				}
				callback3(true);
				return;
			}
			else
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrCode, 26388, null, true, true);
				Action<bool> callback4 = callback;
				if (callback4 == null)
				{
					return;
				}
				callback4(false);
				return;
			}
		}, 0);
	}

	// Token: 0x06014EC5 RID: 85701 RVA: 0x005CA78C File Offset: 0x005C898C
	[NullableContext(2)]
	public void SaveExploreRouletteExtraItemId(int equipItemId, Action<bool> callback = null)
	{
		RouletteListDataBase rouletteListDataBase;
		if (!ModelBase<RouletteModel>.Instance.RouletteListDataMap.TryGetValue(ERouletteType.Explore, out rouletteListDataBase))
		{
			return;
		}
		RouletteListDataExplore rouletteListDataExplore = rouletteListDataBase as RouletteListDataExplore;
		if (rouletteListDataExplore == null)
		{
			return;
		}
		rouletteListDataExplore.GetExtraItemIdProxy().SetExtraItemId(equipItemId, callback);
	}

	// Token: 0x06014EC6 RID: 85702 RVA: 0x005CA7C6 File Offset: 0x005C89C6
	public bool TrySetExtraItemIdForReplace(int equipItemId)
	{
		RouletteListDataExplore rouletteListDataExplore = ModelBase<RouletteModel>.Instance.RouletteListDataMap[ERouletteType.Explore] as RouletteListDataExplore;
		return rouletteListDataExplore != null && rouletteListDataExplore.SetExtraItemIdReplace(equipItemId);
	}

	// Token: 0x06014EC7 RID: 85703 RVA: 0x005CA7EC File Offset: 0x005C89EC
	public void FunctionOpenRequest(int funcId)
	{
		if (funcId == 0)
		{
			return;
		}
		FuncMenuWheel? funcDataByFuncId = ModelBase<RouletteModel>.Instance.GetFuncDataByFuncId(funcId);
		if (funcDataByFuncId == null)
		{
			return;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Phantom;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "轮盘请求打开界面";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Function Id", funcDataByFuncId.Value.UnlockCondition);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		if (funcDataByFuncId.Value.UnlockCondition > 0)
		{
			ControllerBase<FunctionController>.Instance.OpenFunctionRelateView((EFunctionType)funcDataByFuncId.Value.UnlockCondition);
			return;
		}
		RouletteFunctionOpenController.OpenRelateView((ERouletteFuncId)funcDataByFuncId.Value.FuncId);
	}

	// Token: 0x06014EC8 RID: 85704 RVA: 0x005CA88D File Offset: 0x005C8A8D
	[NullableContext(2)]
	public void EquipItemSetRequest(int itemId, Action<bool> callBack = null, EExploreSkillLayer layer = EExploreSkillLayer.Roulette)
	{
		if (ModelBase<RouletteModel>.Instance.IsEquipItemSelectOn)
		{
			RouletteController.RefreshExploreSkillButton();
			return;
		}
		ModelBase<CharacterExploreModel>.Instance.SetExploreSkillId(3001, layer, "EquipItemSetRequest");
		ControllerBase<RouletteController>.Instance.ExploreSkillSetRequest(3001, callBack, false);
	}

	// Token: 0x06014EC9 RID: 85705 RVA: 0x005CA8C7 File Offset: 0x005C8AC7
	private void OnMapExploreToolPlaceNumUpdated(ERouletteExploreId phantomSkillId, int placeNum)
	{
		if (ModelBase<RouletteModel>.Instance.CurrentExploreSkillId == (int)phantomSkillId)
		{
			RouletteController.RefreshExploreSkillButton();
		}
	}

	// Token: 0x06014ECA RID: 85706 RVA: 0x005CA8DB File Offset: 0x005C8ADB
	private void OnRefreshTempFishingPointNum()
	{
		if (ModelBase<RouletteModel>.Instance.CurrentExploreSkillId == 1018)
		{
			RouletteController.RefreshExploreSkillButton();
		}
	}

	// Token: 0x06014ECB RID: 85707 RVA: 0x005CA8F4 File Offset: 0x005C8AF4
	public static void RefreshExploreSkillButton()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.OnChangeSelectedExploreId);
		Singleton<EventSystem>.Instance.Emit<ESkillButtonType>(EEventName.OnSkillButtonSkillIdRefresh, ESkillButtonType.幻象1);
		Singleton<Log>.Instance.Info(ELogModule.Phantom, ELogAuthor.YYZ, "刷新探索技能按钮表现", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x06014ECC RID: 85708 RVA: 0x005CA940 File Offset: 0x005C8B40
	private void OnCommonItemCountAnyChange(int configId, int count)
	{
		ControllerBase<RouletteController>.Instance.OnRefreshExploreSkillButton(configId, 0);
		int currentExploreSkillId = ModelBase<RouletteModel>.Instance.CurrentExploreSkillId;
		ExploreTools exploreTools;
		if (!ModelBase<RouletteModel>.Instance.UnlockExploreSkillDataMap.TryGetValue(currentExploreSkillId, out exploreTools))
		{
			return;
		}
		Dictionary<int, int> dictionary = exploreTools.Cost();
		if (dictionary != null && dictionary.Count > 0)
		{
			using (Dictionary<int, int>.KeyCollection.Enumerator enumerator = dictionary.Keys.GetEnumerator())
			{
				if (enumerator.MoveNext() && enumerator.Current == configId)
				{
					RouletteController.RefreshExploreSkillButton();
				}
			}
		}
	}

	// Token: 0x06014ECD RID: 85709 RVA: 0x005CA9D4 File Offset: 0x005C8BD4
	private void OnUseBuffItem(int configId, long l, int arg3)
	{
		this.OnRefreshExploreSkillButton(configId, 0);
	}

	// Token: 0x06014ECE RID: 85710 RVA: 0x005CA9E0 File Offset: 0x005C8BE0
	private void OnRefreshExploreSkillButton(int configId, int _ = 0)
	{
		int currentEquipItemId = ModelBase<RouletteModel>.Instance.CurrentEquipItemId;
		if (configId != currentEquipItemId)
		{
			return;
		}
		if (ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(configId, 0) == 0)
		{
			ControllerBase<RouletteController>.Instance.SaveExploreRouletteExtraItemId(0, null);
			return;
		}
		RouletteController.RefreshExploreSkillButton();
	}

	// Token: 0x06014ECF RID: 85711 RVA: 0x005CAA1D File Offset: 0x005C8C1D
	private void OnCharUseExploreSkill(int entityId, int skillId, bool isAutonomousProxy)
	{
		ControllerBase<RouletteExploreSkillController>.Instance.UseExploreSkillId(entityId, skillId);
	}

	// Token: 0x06014ED0 RID: 85712 RVA: 0x005CAA2C File Offset: 0x005C8C2C
	public void OnUseEquipItem()
	{
		int currentEquipItemId = ModelBase<RouletteModel>.Instance.CurrentEquipItemId;
		if (!ModelBase<RouletteModel>.Instance.IsEquipItemSelectOn)
		{
			return;
		}
		if (!ControllerBase<SpecialItemController>.Instance.IsSpecialItem(currentEquipItemId))
		{
			if (ConfigBase<BuffItemConfig>.Instance.IsBuffItem(currentEquipItemId))
			{
				SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
				if (getCurrentTeamItem == null)
				{
					return;
				}
				ItemUseLogic.TryUseBuffItem(currentEquipItemId, 1, true, getCurrentTeamItem.GetConfigId);
			}
			else
			{
				ControllerBase<InventoryController>.Instance.TryUseItem(currentEquipItemId, 1);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Phantom;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "请求使用普通道具";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("道具Id", currentEquipItemId);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ModelBase<RouletteModel>.Instance.SendExploreToolItemUseLogData(currentEquipItemId);
			return;
		}
		SpecialItem? config = ConfigBase<SpecialItemConfig>.Instance.GetConfig(currentEquipItemId);
		if (config == null)
		{
			return;
		}
		if (ControllerBase<GameModeController>.Instance.IsInInstance() && !config.Value.UseInstance)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CanNotUseInstance", Array.Empty<object>());
			return;
		}
		ControllerBase<InventoryController>.Instance.RequestItemUse(currentEquipItemId, 1);
		Log instance2 = Singleton<Log>.Instance;
		ELogModule module2 = ELogModule.Phantom;
		ELogAuthor author2 = ELogAuthor.YYZ;
		string message2 = "请求使用特殊道具";
		ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("道具Id", currentEquipItemId);
		instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		ModelBase<RouletteModel>.Instance.SendExploreToolItemUseLogData(currentEquipItemId);
	}

	// Token: 0x06014ED1 RID: 85713 RVA: 0x005CAB64 File Offset: 0x005C8D64
	public void OpenEmptyTips()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ExploreSkillEmptyEquipItemTips);
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			ControllerBase<RouletteController>.Instance.OpenAssemblyView(ERouletteType.Explore, new int?(7), new int?(3001), null);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06014ED2 RID: 85714 RVA: 0x005CABB4 File Offset: 0x005C8DB4
	protected override void OnAddOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.PhantomExploreView, new Func<EUiViewName, object, bool>(this.CanOpenView), "RouletteController.CanOpenView");
		Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.PhantomExploreSetView, new Func<EUiViewName, object, bool>(this.CanOpenSetView), "RouletteController.CanOpenSetView");
	}

	// Token: 0x06014ED3 RID: 85715 RVA: 0x005CAC01 File Offset: 0x005C8E01
	protected override void OnRemoveOpenViewCheckFunction()
	{
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.PhantomExploreView, new Func<EUiViewName, object, bool>(this.CanOpenView));
		Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.PhantomExploreSetView, new Func<EUiViewName, object, bool>(this.CanOpenSetView));
	}

	// Token: 0x06014ED4 RID: 85716 RVA: 0x005CAC3C File Offset: 0x005C8E3C
	private bool CanOpenView(EUiViewName viewName, object param)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || getCurrentEntity.Entity == null)
		{
			return false;
		}
		RouletteMainViewProxyBase rouletteMainViewProxyBase = param as RouletteMainViewProxyBase;
		return rouletteMainViewProxyBase != null && rouletteMainViewProxyBase.CanOpenView();
	}

	// Token: 0x06014ED5 RID: 85717 RVA: 0x005CAC74 File Offset: 0x005C8E74
	private bool CanOpenSetView(EUiViewName viewName, object param)
	{
		EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
		if (getCurrentEntity == null || getCurrentEntity.Entity == null)
		{
			return false;
		}
		RouletteAssemblyViewProxy rouletteAssemblyViewProxy = param as RouletteAssemblyViewProxy;
		return rouletteAssemblyViewProxy != null && rouletteAssemblyViewProxy.CanOpenView();
	}

	// Token: 0x06014ED6 RID: 85718 RVA: 0x005CACAA File Offset: 0x005C8EAA
	public RouletteMainViewProxyBase GetCurrentRouletteMainViewProxy()
	{
		return ModelBase<RouletteModel>.Instance.GetCurrentExploreRouletteListData().GetRouletteMainViewProxy();
	}

	// Token: 0x06014ED7 RID: 85719 RVA: 0x005CACBB File Offset: 0x005C8EBB
	public void OpenRouletteMainView(RouletteMainViewProxyBase viewProxy)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomExploreView, viewProxy, null);
	}

	// Token: 0x06014ED8 RID: 85720 RVA: 0x005CACD0 File Offset: 0x005C8ED0
	public bool OpenAssemblyView(ERouletteType type = ERouletteType.Explore, int? selectIndex = null, int? endSwitchSkillId = null, int? selectGridId = null)
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomExploreSetView))
		{
			return false;
		}
		RouletteAssemblyViewProxy rouletteAssemblyViewProxy = new RouletteAssemblyViewProxy();
		rouletteAssemblyViewProxy.OpenParam = new RouletteAssemblyOpenParam
		{
			RouletteType = new ERouletteType?(type),
			SelectGridId = selectGridId,
			SelectGridIndex = selectIndex,
			EndSwitchSkillId = new ERouletteExploreId?((ERouletteExploreId)((endSwitchSkillId == null) ? 0 : endSwitchSkillId.Value))
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomExploreSetView, rouletteAssemblyViewProxy, null);
		return false;
	}

	// Token: 0x06014ED9 RID: 85721 RVA: 0x005CAD4C File Offset: 0x005C8F4C
	public bool CheckCanExploreSkillEquip(int exploreSkillId)
	{
		ExploreTools? exploreConfigById = ConfigBase<RouletteConfig>.Instance.GetExploreConfigById(exploreSkillId);
		return exploreConfigById != null && (exploreSkillId != 3001 || ModelBase<RouletteModel>.Instance.CurrentEquipItemId != 0) && exploreConfigById.Value.CanEquip;
	}
}
