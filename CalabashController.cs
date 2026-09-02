using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x020017CE RID: 6094
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class CalabashController : UiControllerBase<CalabashController>
{
	// Token: 0x0600ACF9 RID: 44281 RVA: 0x002E2204 File Offset: 0x002E0404
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.ActiveBattleView, this.OnShowUnlockItemView);
		Singleton<EventSystem>.Instance.Add(EEventName.OnVisionRefineSubNeedAck, new Action(this.OnVisionRefineSubNeedAck));
	}

	// Token: 0x0600ACFA RID: 44282 RVA: 0x002E2238 File Offset: 0x002E0438
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.ActiveBattleView, this.OnShowUnlockItemView);
		Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionRefineSubNeedAck, new Action(this.OnVisionRefineSubNeedAck));
	}

	// Token: 0x0600ACFB RID: 44283 RVA: 0x002E226C File Offset: 0x002E046C
	public void OpenCalabashUpgradeSuccessView(ICalabashUpgradeSuccessViedData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CalabashUpgradeSuccessView, data, null);
	}

	// Token: 0x0600ACFC RID: 44284 RVA: 0x002E2280 File Offset: 0x002E0480
	private void OnVisionRefineSubNeedAck()
	{
		CalabashController.<>c__DisplayClass4_0 CS$<>8__locals1 = new CalabashController.<>c__DisplayClass4_0();
		Dictionary<int, PhantomBattleData> phantomBattleDataMap = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleDataMap();
		if (phantomBattleDataMap == null)
		{
			return;
		}
		CS$<>8__locals1.uid = null;
		List<Aki.Protocol.PhantomPropInfo> list = null;
		List<int> list2 = null;
		foreach (KeyValuePair<int, PhantomBattleData> keyValuePair in phantomBattleDataMap)
		{
			List<Aki.Protocol.PhantomPropInfo> unAckSubProp = keyValuePair.Value.GetUnAckSubProp();
			if (unAckSubProp.Count > 0)
			{
				CS$<>8__locals1.uid = new int?(keyValuePair.Key);
				list = unAckSubProp;
				list2 = keyValuePair.Value.GetLockSubPropIndices();
				break;
			}
		}
		if (CS$<>8__locals1.uid == null || list == null || list2 == null)
		{
			return;
		}
		VisionRefineBatchResultViewData visionRefineBatchResultViewData = new VisionRefineBatchResultViewData();
		HashSet<int> lockSet = new HashSet<int>(list2);
		visionRefineBatchResultViewData.LeftAttrList = this.BuildRefineSubVerticalLeftDataByUid(CS$<>8__locals1.uid, lockSet, null);
		visionRefineBatchResultViewData.RightAttrList = this.BuildRefineSubVerticalRightDataByUid(CS$<>8__locals1.uid, list, lockSet, null);
		visionRefineBatchResultViewData.OnClickCancel = delegate()
		{
			CalabashController.<>c__DisplayClass4_0.<<OnVisionRefineSubNeedAck>b__0>d <<OnVisionRefineSubNeedAck>b__0>d;
			<<OnVisionRefineSubNeedAck>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnVisionRefineSubNeedAck>b__0>d.<>4__this = CS$<>8__locals1;
			<<OnVisionRefineSubNeedAck>b__0>d.<>1__state = -1;
			<<OnVisionRefineSubNeedAck>b__0>d.<>t__builder.Start<CalabashController.<>c__DisplayClass4_0.<<OnVisionRefineSubNeedAck>b__0>d>(ref <<OnVisionRefineSubNeedAck>b__0>d);
			return <<OnVisionRefineSubNeedAck>b__0>d.<>t__builder.Task;
		};
		visionRefineBatchResultViewData.OnClickConfirm = delegate()
		{
			CalabashController.<>c__DisplayClass4_0.<<OnVisionRefineSubNeedAck>b__1>d <<OnVisionRefineSubNeedAck>b__1>d;
			<<OnVisionRefineSubNeedAck>b__1>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnVisionRefineSubNeedAck>b__1>d.<>4__this = CS$<>8__locals1;
			<<OnVisionRefineSubNeedAck>b__1>d.<>1__state = -1;
			<<OnVisionRefineSubNeedAck>b__1>d.<>t__builder.Start<CalabashController.<>c__DisplayClass4_0.<<OnVisionRefineSubNeedAck>b__1>d>(ref <<OnVisionRefineSubNeedAck>b__1>d);
			return <<OnVisionRefineSubNeedAck>b__1>d.<>t__builder.Task;
		};
		visionRefineBatchResultViewData.UniqueId = CS$<>8__locals1.uid;
		visionRefineBatchResultViewData.ConfirmTipTextId = "Text_UnconfirmedResultTips_Text";
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionRefineSubResultView, visionRefineBatchResultViewData, null);
	}

	// Token: 0x0600ACFD RID: 44285 RVA: 0x002E23CC File Offset: 0x002E05CC
	public VisionRefineAttributeItemData[] BuildRefineSubVerticalLeftDataByUid(int? uid, HashSet<int> lockSet, [Nullable(new byte[]
	{
		2,
		1
	})] List<AttrRecommendInfo> recommendList)
	{
		List<VisionRefineAttributeItemData> list = new List<VisionRefineAttributeItemData>();
		for (int i = 0; i < 5; i++)
		{
			VisionRefineAttributeItemData visionRefineAttributeItemData = new VisionRefineAttributeItemData();
			if (uid != null)
			{
				PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uid.Value);
				List<VisionSubPropData> list2 = (phantomDataBase != null) ? phantomDataBase.GetEquipmentViewPreviewData() : null;
				if (list2 != null && list2.Count > i)
				{
					visionRefineAttributeItemData.NameTextId = list2[i].GetSubPropName();
					visionRefineAttributeItemData.NumberText = list2[i].GetAttributeValueString();
					visionRefineAttributeItemData.IsChosen = lockSet.Contains(i);
					visionRefineAttributeItemData.CanInteractive = false;
					int phantomPropId = list2[i].PhantomSubProp.PhantomPropId;
					PhantomSubProperty subConfig = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(phantomPropId);
					visionRefineAttributeItemData.IsRecommend = (recommendList != null && recommendList.Exists((AttrRecommendInfo value) => value.GetAttrId() == subConfig.PropId && value.GetAddType() == subConfig.AddType));
				}
				else
				{
					visionRefineAttributeItemData.NameTextId = "Text_VisionRefineSubAttriLocked_Text";
					visionRefineAttributeItemData.CanInteractive = false;
				}
			}
			else
			{
				visionRefineAttributeItemData.NameTextId = "ErrorCode_200347_Text";
				visionRefineAttributeItemData.CanInteractive = false;
			}
			list.Add(visionRefineAttributeItemData);
		}
		return list.ToArray();
	}

	// Token: 0x0600ACFE RID: 44286 RVA: 0x002E24EC File Offset: 0x002E06EC
	public VisionRefineAttributeItemData[] BuildRefineSubVerticalRightDataByUid(int? uid, List<Aki.Protocol.PhantomPropInfo> unAckInfo, HashSet<int> lockSet, [Nullable(new byte[]
	{
		2,
		1
	})] List<AttrRecommendInfo> recommendList)
	{
		List<VisionRefineAttributeItemData> list = new List<VisionRefineAttributeItemData>();
		for (int i = 0; i < 5; i++)
		{
			VisionRefineAttributeItemData visionRefineAttributeItemData = new VisionRefineAttributeItemData();
			if (uid != null)
			{
				PhantomDataBase phantomDataBase = ModelBase<PhantomBattleModel>.Instance.GetPhantomDataBase(uid.Value);
				bool flag = lockSet.Contains(i);
				List<VisionSubPropData> list2 = (phantomDataBase != null) ? phantomDataBase.GetEquipmentViewPreviewData() : null;
				if (list2 != null && list2.Count > i && unAckInfo.Count > i)
				{
					VisionSubPropData visionSubPropData = list2[i];
					int phantomPropId = unAckInfo[i].PhantomPropId;
					PhantomSubProperty subConfig = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSubPropertyById(phantomPropId);
					visionRefineAttributeItemData.NameTextId = visionSubPropData.GetSubPropNameByPropId(phantomPropId);
					visionRefineAttributeItemData.NumberText = visionSubPropData.GetAttributeValueStringByPropId(phantomPropId, unAckInfo[i].Value);
					visionRefineAttributeItemData.ForceCheckboxActive = new bool?(false);
					visionRefineAttributeItemData.HasNewIcon = new bool?(!flag);
					visionRefineAttributeItemData.IsChosen = flag;
					visionRefineAttributeItemData.CanInteractive = false;
					visionRefineAttributeItemData.IsRecommend = (recommendList != null && recommendList.Exists((AttrRecommendInfo value) => value.GetAttrId() == subConfig.PropId && value.GetAddType() == subConfig.AddType));
				}
				else
				{
					visionRefineAttributeItemData.NameTextId = "Text_VisionRefineSubAttriLocked_Text";
					visionRefineAttributeItemData.CanInteractive = false;
				}
			}
			else
			{
				visionRefineAttributeItemData.NameTextId = "ErrorCode_200347_Text";
				visionRefineAttributeItemData.CanInteractive = false;
			}
			list.Add(visionRefineAttributeItemData);
		}
		return list.ToArray();
	}

	// Token: 0x0600ACFF RID: 44287 RVA: 0x002E2648 File Offset: 0x002E0848
	private void DoShowUnlockItemView()
	{
		if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.CalabashUnlockItemView) && Singleton<UiManager>.Instance.IsViewShow(EUiViewName.BattleView) && !ModelBase<SundryModel>.Instance.IsBlockTips)
		{
			List<VisionUnlockQualityData> calabashUnlockTipsList = ModelBase<CalabashModel>.Instance.CalabashUnlockTipsList;
			object param = null;
			if (calabashUnlockTipsList.Count > 0)
			{
				param = calabashUnlockTipsList[0];
				calabashUnlockTipsList.RemoveAt(0);
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CalabashUnlockItemView, param, null);
		}
	}

	// Token: 0x0600AD00 RID: 44288 RVA: 0x002E26BC File Offset: 0x002E08BC
	protected override void OnRegisterNetEvent()
	{
		Net instance = Singleton<Net>.Instance;
		ENotifyMessageId id = ENotifyMessageId.CalabashMsgNotify;
		Action<CalabashMsgNotify, Net.CallbackStatus> callback;
		if ((callback = CalabashController.<>O.<0>__CalabashMsgNotify) == null)
		{
			callback = (CalabashController.<>O.<0>__CalabashMsgNotify = new Action<CalabashMsgNotify, Net.CallbackStatus>(CalabashController.CalabashMsgNotify));
		}
		instance.Register<CalabashMsgNotify>(id, callback);
		Net instance2 = Singleton<Net>.Instance;
		ENotifyMessageId id2 = ENotifyMessageId.CalabashExpAddNotify;
		Action<CalabashExpAddNotify, Net.CallbackStatus> callback2;
		if ((callback2 = CalabashController.<>O.<1>__CalabashExpAddNotify) == null)
		{
			callback2 = (CalabashController.<>O.<1>__CalabashExpAddNotify = new Action<CalabashExpAddNotify, Net.CallbackStatus>(CalabashController.CalabashExpAddNotify));
		}
		instance2.Register<CalabashExpAddNotify>(id2, callback2);
		Net instance3 = Singleton<Net>.Instance;
		ENotifyMessageId id3 = ENotifyMessageId.CalabashDevelopRewardUnlockNotify;
		Action<CalabashDevelopRewardUnlockNotify, Net.CallbackStatus> callback3;
		if ((callback3 = CalabashController.<>O.<2>__CalabashDevelopRewardUnlockNotify) == null)
		{
			callback3 = (CalabashController.<>O.<2>__CalabashDevelopRewardUnlockNotify = new Action<CalabashDevelopRewardUnlockNotify, Net.CallbackStatus>(CalabashController.CalabashDevelopRewardUnlockNotify));
		}
		instance3.Register<CalabashDevelopRewardUnlockNotify>(id3, callback3);
		Net instance4 = Singleton<Net>.Instance;
		ENotifyMessageId id4 = ENotifyMessageId.CalabashLevelsRewardNotify;
		Action<CalabashLevelsRewardNotify, Net.CallbackStatus> callback4;
		if ((callback4 = CalabashController.<>O.<3>__CalabashLevelsRewardNotify) == null)
		{
			callback4 = (CalabashController.<>O.<3>__CalabashLevelsRewardNotify = new Action<CalabashLevelsRewardNotify, Net.CallbackStatus>(CalabashController.CalabashLevelsRewardNotify));
		}
		instance4.Register<CalabashLevelsRewardNotify>(id4, callback4);
		Net instance5 = Singleton<Net>.Instance;
		ENotifyMessageId id5 = ENotifyMessageId.PhantomDirectRefiningWeeklyResetNotify;
		Action<PhantomDirectRefiningWeeklyResetNotify, Net.CallbackStatus> callback5;
		if ((callback5 = CalabashController.<>O.<4>__PhantomDirectRefiningWeeklyResetNotify) == null)
		{
			callback5 = (CalabashController.<>O.<4>__PhantomDirectRefiningWeeklyResetNotify = new Action<PhantomDirectRefiningWeeklyResetNotify, Net.CallbackStatus>(CalabashController.PhantomDirectRefiningWeeklyResetNotify));
		}
		instance5.Register<PhantomDirectRefiningWeeklyResetNotify>(id5, callback5);
	}

	// Token: 0x0600AD01 RID: 44289 RVA: 0x002E27A0 File Offset: 0x002E09A0
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CalabashMsgNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CalabashExpAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CalabashDevelopRewardUnlockNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CalabashLevelsRewardNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.PhantomDirectRefiningWeeklyResetNotify);
	}

	// Token: 0x0600AD02 RID: 44290 RVA: 0x002E2800 File Offset: 0x002E0A00
	private static void CalabashMsgNotify(CalabashMsgNotify response, [Nullable(2)] Net.CallbackStatus _)
	{
		Singleton<Log>.Instance.Info(ELogModule.Calabash, ELogAuthor.XXJ, "服务端推送吸收器信息", default(ReadOnlySpan<ValueTuple<string, object>>));
		if (ModelBase<CalabashModel>.Instance.CalabashInstance != null)
		{
			int currentExp = ModelBase<CalabashModel>.Instance.GetCurrentExp();
			if (ModelBase<CalabashModel>.Instance.GetCalabashLevel() != response.CalabashMsg.Level)
			{
				CalabashUpgradeSuccessViedData data = new CalabashUpgradeSuccessViedData
				{
					AddExp = false,
					PreLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel(),
					PreExp = currentExp,
					CurLevel = response.CalabashMsg.Level,
					CurExp = currentExp
				};
				ControllerBase<CalabashController>.Instance.OpenCalabashUpgradeSuccessView(data);
			}
		}
		ModelBase<CalabashModel>.Instance.SetCalabashInstanceBaseInfo(response.CalabashMsg);
		ModelBase<CalabashModel>.Instance.SetCalabashInstanceConfigInfo(response.CalabashCfg);
		ModelBase<CalabashModel>.Instance.UpdateCalabashDevelopRewardData();
	}

	// Token: 0x0600AD03 RID: 44291 RVA: 0x002E28CC File Offset: 0x002E0ACC
	private static void CalabashExpAddNotify(CalabashExpAddNotify response, [Nullable(2)] Net.CallbackStatus _)
	{
		Singleton<Log>.Instance.Info(ELogModule.Calabash, ELogAuthor.XXJ, "服务端推送吸收器经验变化信息", default(ReadOnlySpan<ValueTuple<string, object>>));
		int curLevel = response.CurLevel;
		int curExp = response.CurExp;
		int currentExp = ModelBase<CalabashModel>.Instance.GetCurrentExp();
		int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
		CalabashUpgradeSuccessViedData data = new CalabashUpgradeSuccessViedData
		{
			AddExp = true,
			PreLevel = calabashLevel,
			PreExp = currentExp,
			CurLevel = curLevel,
			CurExp = curExp
		};
		ModelBase<CalabashModel>.Instance.SetCurrentExp(curExp);
		ModelBase<CalabashModel>.Instance.SetCalabashLevel(curLevel);
		ModelBase<CalabashModel>.Instance.SetCalabashInstanceConfigInfo(response.CalabashCfg);
		ModelBase<CalabashModel>.Instance.UpdateCalabashDevelopRewardData();
		ControllerBase<CalabashController>.Instance.OpenCalabashUpgradeSuccessView(data);
		if (calabashLevel < curLevel)
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.RedDotRefreshCalabash);
		}
	}

	// Token: 0x0600AD04 RID: 44292 RVA: 0x002E2998 File Offset: 0x002E0B98
	private static void CalabashDevelopRewardUnlockNotify(CalabashDevelopRewardUnlockNotify response, [Nullable(2)] Net.CallbackStatus _)
	{
		Singleton<Log>.Instance.Info(ELogModule.Calabash, ELogAuthor.XXJ, "服务端更新的葫芦经验图谱信息", default(ReadOnlySpan<ValueTuple<string, object>>));
		ModelBase<CalabashModel>.Instance.SetUnlockCalabashDevelopReward(response.UnlockedDevelopReward);
		ModelBase<CalabashModel>.Instance.UpdateCalabashDevelopRewardData();
	}

	// Token: 0x0600AD05 RID: 44293 RVA: 0x002E29E0 File Offset: 0x002E0BE0
	private static void CalabashLevelsRewardNotify(CalabashLevelsRewardNotify response, [Nullable(2)] Net.CallbackStatus _)
	{
		Singleton<Log>.Instance.Info(ELogModule.Calabash, ELogAuthor.XXJ, "服务端更新的葫芦已获得奖励等级列表数据", default(ReadOnlySpan<ValueTuple<string, object>>));
		ModelBase<CalabashModel>.Instance.SetCalabashLevelsReward(response.RewardedLevels.ToList<int>());
	}

	// Token: 0x0600AD06 RID: 44294 RVA: 0x002E2A24 File Offset: 0x002E0C24
	public static void PhantomDirectRefiningWeeklyResetNotify(PhantomDirectRefiningWeeklyResetNotify response, [Nullable(2)] Net.CallbackStatus _)
	{
		Singleton<Log>.Instance.Info(ELogModule.Calabash, ELogAuthor.LJQ, "服务端更新定向融合次数", default(ReadOnlySpan<ValueTuple<string, object>>));
		ModelBase<CalabashModel>.Instance.DirectionalFusionTime = response.DirectRefineWeekTimes;
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.CalabashRootView) && (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.CalabashRootView) as CalabashRootView).GetIsVisionRecoveryTabViewOpen())
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PhantomDirectRefiningWeeklyConfirm);
			confirmBoxDataNew.FunctionMap.Add(1, delegate
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.PhantomDirectRefiningWeeklyReset);
			});
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}

	// Token: 0x0600AD07 RID: 44295 RVA: 0x002E2AD0 File Offset: 0x002E0CD0
	public void RequestMultiCalabashLevelReward(int[] levels)
	{
		Singleton<Log>.Instance.Info(ELogModule.Calabash, ELogAuthor.XXJ, "请求领取幻象等级奖励", default(ReadOnlySpan<ValueTuple<string, object>>));
		MulCalabashLevelRewardRequest mulCalabashLevelRewardRequest = MulCalabashLevelRewardRequest.Create();
		mulCalabashLevelRewardRequest.Level.AddRange(levels);
		Singleton<Net>.Instance.Call<MulCalabashLevelRewardResponse>(ERequestMessageId.MulCalabashLevelRewardRequest, mulCalabashLevelRewardRequest, delegate(MulCalabashLevelRewardResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19560, null, true, true);
			}
		}, 0);
	}

	// Token: 0x0600AD08 RID: 44296 RVA: 0x002E2B40 File Offset: 0x002E0D40
	public void RequestPhantomRefiningRequest(ISelectedData[] dataList)
	{
		List<int> list = new List<int>();
		foreach (ISelectedData selectedData in dataList)
		{
			list.Add(selectedData.IncId);
		}
		PhantomRefiningRequest phantomRefiningRequest = PhantomRefiningRequest.Create();
		phantomRefiningRequest.IncrIdList.AddRange(list);
		Singleton<Net>.Instance.Call<PhantomRefiningResponse>(ERequestMessageId.PhantomRefiningRequest, phantomRefiningRequest, delegate(PhantomRefiningResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15082, null, true, true);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<OneOf<PhantomBatchDirectRefiningResponse, PhantomRefiningResponse>>(EEventName.OnVisionRecoveryResult, new OneOf<PhantomBatchDirectRefiningResponse, PhantomRefiningResponse>(response));
		}, 0);
	}

	// Token: 0x0600AD09 RID: 44297 RVA: 0x002E2BB8 File Offset: 0x002E0DB8
	public void PhantomBatchDirectRefiningRequest(ISelectedData[] dataList)
	{
		List<int> list = new List<int>();
		foreach (ISelectedData selectedData in dataList)
		{
			list.Add(selectedData.IncId);
		}
		PhantomBatchDirectRefiningRequest phantomBatchDirectRefiningRequest = Aki.Protocol.PhantomBatchDirectRefiningRequest.Create();
		phantomBatchDirectRefiningRequest.IncrIdList.AddRange(list);
		phantomBatchDirectRefiningRequest.TargetFetterGroupId = ModelBase<CalabashModel>.Instance.DirectionalFusionTargetFetterGroup;
		Singleton<Net>.Instance.Call<PhantomBatchDirectRefiningResponse>(ERequestMessageId.PhantomBatchDirectRefiningRequest, phantomBatchDirectRefiningRequest, delegate(PhantomBatchDirectRefiningResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17669, null, true, true);
				return;
			}
			ModelBase<CalabashModel>.Instance.DirectionalFusionTime = response.DirectRefineWeekTimes;
			Singleton<EventSystem>.Instance.Emit<OneOf<PhantomBatchDirectRefiningResponse, PhantomBatchRefiningResponse>>(EEventName.OnVisionRecoveryBatchResult, new OneOf<PhantomBatchDirectRefiningResponse, PhantomBatchRefiningResponse>(response));
		}, 0);
	}

	// Token: 0x0600AD0A RID: 44298 RVA: 0x002E2C40 File Offset: 0x002E0E40
	public void RequestBatchRefiningRequest(ISelectedData[] dataList)
	{
		List<int> list = new List<int>();
		foreach (ISelectedData selectedData in dataList)
		{
			list.Add(selectedData.IncId);
		}
		PhantomBatchRefiningRequest phantomBatchRefiningRequest = PhantomBatchRefiningRequest.Create();
		phantomBatchRefiningRequest.IncrIdList.AddRange(list);
		Singleton<Net>.Instance.Call<PhantomBatchRefiningResponse>(ERequestMessageId.PhantomBatchRefiningRequest, phantomBatchRefiningRequest, delegate(PhantomBatchRefiningResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23668, null, true, true);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<OneOf<PhantomBatchDirectRefiningResponse, PhantomBatchRefiningResponse>>(EEventName.OnVisionRecoveryBatchResult, new OneOf<PhantomBatchDirectRefiningResponse, PhantomBatchRefiningResponse>(response));
		}, 0);
	}

	// Token: 0x0600AD0B RID: 44299 RVA: 0x002E2CB8 File Offset: 0x002E0EB8
	public void JumpToCalabashCollectTabView(int monsterId)
	{
		CalabashCollectViewData param = new CalabashCollectViewData
		{
			MonsterId = monsterId
		};
		ControllerBase<CalabashController>.Instance.JumpToCalabashRootView(EUiTabViewName.CalabashCollectTabView, param);
	}

	// Token: 0x0600AD0C RID: 44300 RVA: 0x002E2CE4 File Offset: 0x002E0EE4
	public void JumpToCalabashCollectTabViewOnlyShow(int monsterId, bool onlyShow)
	{
		CalabashCollectViewData param = new CalabashCollectViewData
		{
			MonsterId = monsterId,
			OnlyShow = new bool?(onlyShow)
		};
		ControllerBase<CalabashController>.Instance.JumpToCalabashRootView(EUiTabViewName.CalabashCollectTabView, param);
	}

	// Token: 0x0600AD0D RID: 44301 RVA: 0x002E2D1C File Offset: 0x002E0F1C
	[NullableContext(2)]
	public void JumpToCalabashRootView(EUiTabViewName tabViewName, object param = null)
	{
		EFunctionType functionId = EFunctionType.Calabash;
		if (tabViewName == EUiTabViewName.VisionRecoveryTabView)
		{
			functionId = EFunctionType.VisionRecovery;
		}
		else if (tabViewName == EUiTabViewName.VisionRefineTabView)
		{
			functionId = EFunctionType.VisionRefine;
		}
		if (!ModelBase<FunctionModel>.Instance.IsOpen((int)functionId))
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_UnlockNotice_Text", Array.Empty<object>());
			return;
		}
		CalabashRootViewData param2 = new CalabashRootViewData
		{
			TabViewName = tabViewName,
			Param = param
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CalabashRootView, param2, null);
	}

	// Token: 0x0600AD0E RID: 44302 RVA: 0x002E2DA0 File Offset: 0x002E0FA0
	public unsafe void RequestPhantomPolishRequest(int incId, int propItemId)
	{
		PhantomPolishRequest phantomPolishRequest = PhantomPolishRequest.Create();
		phantomPolishRequest.IncrId = incId;
		phantomPolishRequest.PhantomMainPropItemId = propItemId;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Calabash;
		ELogAuthor author = ELogAuthor.WDX;
		string message = "RequestPhantomPolishRequest";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", incId);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("propItemId", propItemId);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		Singleton<Net>.Instance.Call<PhantomPolishResponse>(ERequestMessageId.PhantomPolishRequest, phantomPolishRequest, delegate(PhantomPolishResponse response, [Nullable(2)] Net.CallbackStatus _)
		{
			if (response == null || response.UpdateInfo == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 22869, null, true, true);
				return;
			}
			ModelBase<InventoryModel>.Instance.UpdatePhantomItemData(response.UpdateInfo);
			ModelBase<PhantomBattleModel>.Instance.UpdatePhantomBattleData(response.UpdateInfo);
			Singleton<EventSystem>.Instance.Emit<PhantomPolishResponse>(EEventName.OnVisionRefineResult, response);
		}, 0);
	}

	// Token: 0x0600AD0F RID: 44303 RVA: 0x002E2E54 File Offset: 0x002E1054
	public UniTask RequestPhantomBatchPolishRequest(int[] incIds, int propItemId)
	{
		CalabashController.<RequestPhantomBatchPolishRequest>d__23 <RequestPhantomBatchPolishRequest>d__;
		<RequestPhantomBatchPolishRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestPhantomBatchPolishRequest>d__.incIds = incIds;
		<RequestPhantomBatchPolishRequest>d__.propItemId = propItemId;
		<RequestPhantomBatchPolishRequest>d__.<>1__state = -1;
		<RequestPhantomBatchPolishRequest>d__.<>t__builder.Start<CalabashController.<RequestPhantomBatchPolishRequest>d__23>(ref <RequestPhantomBatchPolishRequest>d__);
		return <RequestPhantomBatchPolishRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600AD10 RID: 44304 RVA: 0x002E2EA0 File Offset: 0x002E10A0
	public UniTask RequestPhantomVicePolishRequest(int incId, int[] propLockIndexList)
	{
		CalabashController.<RequestPhantomVicePolishRequest>d__24 <RequestPhantomVicePolishRequest>d__;
		<RequestPhantomVicePolishRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestPhantomVicePolishRequest>d__.incId = incId;
		<RequestPhantomVicePolishRequest>d__.propLockIndexList = propLockIndexList;
		<RequestPhantomVicePolishRequest>d__.<>1__state = -1;
		<RequestPhantomVicePolishRequest>d__.<>t__builder.Start<CalabashController.<RequestPhantomVicePolishRequest>d__24>(ref <RequestPhantomVicePolishRequest>d__);
		return <RequestPhantomVicePolishRequest>d__.<>t__builder.Task;
	}

	// Token: 0x0600AD11 RID: 44305 RVA: 0x002E2EEC File Offset: 0x002E10EC
	public UniTask RequestPhantomVicePolishAckRequest(int incId, bool ack)
	{
		CalabashController.<RequestPhantomVicePolishAckRequest>d__25 <RequestPhantomVicePolishAckRequest>d__;
		<RequestPhantomVicePolishAckRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RequestPhantomVicePolishAckRequest>d__.incId = incId;
		<RequestPhantomVicePolishAckRequest>d__.ack = ack;
		<RequestPhantomVicePolishAckRequest>d__.<>1__state = -1;
		<RequestPhantomVicePolishAckRequest>d__.<>t__builder.Start<CalabashController.<RequestPhantomVicePolishAckRequest>d__25>(ref <RequestPhantomVicePolishAckRequest>d__);
		return <RequestPhantomVicePolishAckRequest>d__.<>t__builder.Task;
	}

	// Token: 0x040051E0 RID: 20960
	private readonly Action OnShowUnlockItemView = delegate()
	{
		if (ModelBase<CalabashModel>.Instance.CalabashUnlockTipsList.Count == 0)
		{
			return;
		}
		ControllerBase<CalabashController>.Instance.DoShowUnlockItemView();
	};

	// Token: 0x02007B5C RID: 31580
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402A2BF RID: 172735
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<CalabashMsgNotify, Net.CallbackStatus> <0>__CalabashMsgNotify;

		// Token: 0x0402A2C0 RID: 172736
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<CalabashExpAddNotify, Net.CallbackStatus> <1>__CalabashExpAddNotify;

		// Token: 0x0402A2C1 RID: 172737
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<CalabashDevelopRewardUnlockNotify, Net.CallbackStatus> <2>__CalabashDevelopRewardUnlockNotify;

		// Token: 0x0402A2C2 RID: 172738
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<CalabashLevelsRewardNotify, Net.CallbackStatus> <3>__CalabashLevelsRewardNotify;

		// Token: 0x0402A2C3 RID: 172739
		[Nullable(new byte[]
		{
			0,
			1,
			2
		})]
		public static Action<PhantomDirectRefiningWeeklyResetNotify, Net.CallbackStatus> <4>__PhantomDirectRefiningWeeklyResetNotify;
	}
}
