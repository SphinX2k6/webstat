using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Dango;
using CSharpScript.Game.Ui;
using Google.Protobuf.Collections;

// Token: 0x020012CF RID: 4815
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DangoAbyssActivityController : ActivityControllerBase<DangoAbyssActivityController>
{
	// Token: 0x06008152 RID: 33106 RVA: 0x0022330D File Offset: 0x0022150D
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06008153 RID: 33107 RVA: 0x0022330F File Offset: 0x0022150F
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiView_CelebrationGuideMain";
	}

	// Token: 0x06008154 RID: 33108 RVA: 0x00223316 File Offset: 0x00221516
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new DangoAbyssSubView();
	}

	// Token: 0x06008155 RID: 33109 RVA: 0x0022331D File Offset: 0x0022151D
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new DangoAbyssActivityData();
	}

	// Token: 0x06008156 RID: 33110 RVA: 0x00223324 File Offset: 0x00221524
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06008157 RID: 33111 RVA: 0x00223328 File Offset: 0x00221528
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<AbyssRoleInfoUpdateNotify>(ENotifyMessageId.AbyssRoleInfoUpdateNotify, new Action<AbyssRoleInfoUpdateNotify, Net.CallbackStatus>(this.OnRoleInfoUpdate));
		Singleton<Net>.Instance.Register<AbyssRoleAddNotify>(ENotifyMessageId.AbyssRoleAddNotify, new Action<AbyssRoleAddNotify, Net.CallbackStatus>(this.OnRoleAdd));
		Singleton<Net>.Instance.Register<AbyssPluginItemInfoUpdateNotify>(ENotifyMessageId.AbyssPluginItemInfoUpdateNotify, new Action<AbyssPluginItemInfoUpdateNotify, Net.CallbackStatus>(this.OnPluginInfoUpdate));
		Singleton<Net>.Instance.Register<AbyssPluginItemRemoveNotify>(ENotifyMessageId.AbyssPluginItemRemoveNotify, new Action<AbyssPluginItemRemoveNotify, Net.CallbackStatus>(this.OnPluginRemove));
		Singleton<Net>.Instance.Register<AbyssRewardsUpdateNotify>(ENotifyMessageId.AbyssRewardsUpdateNotify, new Action<AbyssRewardsUpdateNotify, Net.CallbackStatus>(this.OnRewardStateUpdate));
		Singleton<Net>.Instance.Register<AbyssPluginItemAddNotify>(ENotifyMessageId.AbyssPluginItemAddNotify, new Action<AbyssPluginItemAddNotify, Net.CallbackStatus>(this.OnPluginAdd));
	}

	// Token: 0x06008158 RID: 33112 RVA: 0x002233E0 File Offset: 0x002215E0
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AbyssRoleInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AbyssRoleAddNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AbyssPluginItemInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AbyssPluginItemRemoveNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AbyssRewardsUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.AbyssPluginItemAddNotify);
	}

	// Token: 0x06008159 RID: 33113 RVA: 0x00223450 File Offset: 0x00221650
	[NullableContext(2)]
	private DangoAbyssActivityData GetCurrentOpenAbyssActivityData()
	{
		foreach (KeyValuePair<int, ActivityBaseData> keyValuePair in ModelBase<ActivityModel>.Instance.GetAllActivityMap())
		{
			if (keyValuePair.Value.Type == ActivityType.Abyss)
			{
				return keyValuePair.Value as DangoAbyssActivityData;
			}
		}
		return null;
	}

	// Token: 0x0600815A RID: 33114 RVA: 0x002234C4 File Offset: 0x002216C4
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssActivityOpen, null, null);
	}

	// Token: 0x0600815B RID: 33115 RVA: 0x002234D8 File Offset: 0x002216D8
	public void OpenCurrentRoleUpView()
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		DangoRootViewData dangoRootViewData = new DangoRootViewData();
		dangoRootViewData.ActivityId = currentOpenAbyssActivityData.Id;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DangoAbyssRootView, dangoRootViewData, null);
	}

	// Token: 0x0600815C RID: 33116 RVA: 0x00223534 File Offset: 0x00221734
	private void OnRoleInfoUpdate(AbyssRoleInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		currentOpenAbyssActivityData.OnRoleInfoUpdate(notify);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAbyssRoleInfoUpdate);
	}

	// Token: 0x0600815D RID: 33117 RVA: 0x00223584 File Offset: 0x00221784
	private void OnRoleAdd(AbyssRoleAddNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		currentOpenAbyssActivityData.OnAddRoleInfo(notify);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAbyssAddRole);
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (AbyssRoleInfo abyssRoleInfo in notify.RoleList)
		{
			dictionary[abyssRoleInfo.Id] = abyssRoleInfo.Level;
		}
		ControllerBase<DangoAbyssController>.Instance.OpenGetDangoView(dictionary);
	}

	// Token: 0x0600815E RID: 33118 RVA: 0x00223634 File Offset: 0x00221834
	private void OnPluginInfoUpdate(AbyssPluginItemInfoUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		currentOpenAbyssActivityData.OnPluginInfoUpdate(notify);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAbyssPluginInfoUpdate);
	}

	// Token: 0x0600815F RID: 33119 RVA: 0x00223684 File Offset: 0x00221884
	private void OnPluginRemove(AbyssPluginItemRemoveNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		currentOpenAbyssActivityData.OnPluginRemove(notify);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAbyssPluginInfoUpdate);
	}

	// Token: 0x06008160 RID: 33120 RVA: 0x002236D4 File Offset: 0x002218D4
	private void OnPluginAdd(AbyssPluginItemAddNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		currentOpenAbyssActivityData.OnPluginAdd(notify);
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (Aki.Protocol.AbyssPluginItemInfo abyssPluginItemInfo in notify.PluginItems)
		{
			dictionary[abyssPluginItemInfo.ItemId] = abyssPluginItemInfo.Count;
		}
		ControllerBase<ItemHintController>.Instance.AddAbyssItemList(dictionary);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAbyssPluginInfoUpdate);
	}

	// Token: 0x06008161 RID: 33121 RVA: 0x00223784 File Offset: 0x00221984
	private void OnRewardStateUpdate(AbyssRewardsUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		DangoAbyssActivityData currentOpenAbyssActivityData = this.GetCurrentOpenAbyssActivityData();
		if (currentOpenAbyssActivityData == null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YZY, "当前深渊团子没有开启", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		currentOpenAbyssActivityData.OnUpdateRewardIdList(notify);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnAbyssRewardStateUpdate);
		int id = currentOpenAbyssActivityData.Id;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshAbyssRewardRedDot, id);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, id);
	}

	// Token: 0x06008162 RID: 33122 RVA: 0x002237FC File Offset: 0x002219FC
	public void RequestGetAbyssRewardList(int[] rewardIdList)
	{
		AbyssRewardRequest abyssRewardRequest = AbyssRewardRequest.Create();
		abyssRewardRequest.Ids.AddRange(rewardIdList);
		Singleton<Net>.Instance.Call<AbyssRewardResponse>(ERequestMessageId.AbyssRewardRequest, abyssRewardRequest, delegate(AbyssRewardResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 17749, null, true, true);
			}
		}, 0);
	}

	// Token: 0x06008163 RID: 33123 RVA: 0x0022384C File Offset: 0x00221A4C
	public void RequestAbyssDangoLevelUp(int dangoId, int level)
	{
		AbyssLittleRoleLevelUpRequest abyssLittleRoleLevelUpRequest = AbyssLittleRoleLevelUpRequest.Create();
		abyssLittleRoleLevelUpRequest.Id = dangoId;
		abyssLittleRoleLevelUpRequest.Level = level;
		Singleton<Net>.Instance.Call<AbyssLittleRoleLevelUpResponse>(ERequestMessageId.AbyssLittleRoleLevelUpRequest, abyssLittleRoleLevelUpRequest, delegate(AbyssLittleRoleLevelUpResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27037, null, true, true);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnAbyssDangoLevelUp, dangoId, level);
		}, 0);
	}

	// Token: 0x06008164 RID: 33124 RVA: 0x002238A8 File Offset: 0x00221AA8
	public void RequestPutPluginOnDango(int dangoId, int[] equipIds, DangoAbyssDefine.EAbyssItemTipsState state)
	{
		AbyssPluginPutRequest abyssPluginPutRequest = AbyssPluginPutRequest.Create();
		abyssPluginPutRequest.LittleRoleId = dangoId;
		abyssPluginPutRequest.EquipItems.AddRange(equipIds);
		Singleton<Net>.Instance.Call<AbyssPluginPutResponse>(ERequestMessageId.AbyssPluginPutRequest, abyssPluginPutRequest, delegate(AbyssPluginPutResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 21395, null, true, true);
				return;
			}
			this.ShowEquipTipsByState(state);
		}, 0);
	}

	// Token: 0x06008165 RID: 33125 RVA: 0x00223900 File Offset: 0x00221B00
	public void RequestPluginRecovery(List<int> incIdList)
	{
		AbyssPluginSynthesisRequest abyssPluginSynthesisRequest = AbyssPluginSynthesisRequest.Create();
		abyssPluginSynthesisRequest.PluginItemIncrId.AddRange(incIdList);
		Singleton<Net>.Instance.Call<AbyssPluginSynthesisResponse>(ERequestMessageId.AbyssPluginSynthesisRequest, abyssPluginSynthesisRequest, delegate(AbyssPluginSynthesisResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16196, null, true, true);
				return;
			}
			RepeatedField<AddCountItemInfo> outputItems = response.OutputItems;
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<AddCountItemInfo>>(EEventName.OnAbyssPluginRecovery, outputItems);
		}, 0);
	}

	// Token: 0x06008166 RID: 33126 RVA: 0x00223950 File Offset: 0x00221B50
	public AbyssChallengeData[] GetAbyssChallengeByActivityId(int activityId)
	{
		DangoAbyssActivityData dangoAbyssActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as DangoAbyssActivityData;
		if (dangoAbyssActivityData == null)
		{
			return new AbyssChallengeData[0];
		}
		return dangoAbyssActivityData.GetAbyssChallengeDataList();
	}

	// Token: 0x06008167 RID: 33127 RVA: 0x00223980 File Offset: 0x00221B80
	public AbyssChallengeData[] GetAbyssChallengeRankListByActivityId(int activityId)
	{
		DangoAbyssActivityData dangoAbyssActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as DangoAbyssActivityData;
		if (dangoAbyssActivityData == null)
		{
			return new AbyssChallengeData[0];
		}
		return dangoAbyssActivityData.GetAbyssChallengeRankList();
	}

	// Token: 0x06008168 RID: 33128 RVA: 0x002239B0 File Offset: 0x00221BB0
	public void ShowEquipTipsByState(DangoAbyssDefine.EAbyssItemTipsState state)
	{
		switch (state)
		{
		case DangoAbyssDefine.EAbyssItemTipsState.DiffDango:
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_DangoEquipSuccessSwitch_Text", Array.Empty<object>());
			return;
		case DangoAbyssDefine.EAbyssItemTipsState.TakeOff:
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_DangoEquipSuccessTakeOff_Text", Array.Empty<object>());
			return;
		case DangoAbyssDefine.EAbyssItemTipsState.Switch:
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_DangoEquipSuccessSwitch_Text", Array.Empty<object>());
			return;
		case DangoAbyssDefine.EAbyssItemTipsState.Move:
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_DangoEquipSuccessPutOn_Text", Array.Empty<object>());
			return;
		case DangoAbyssDefine.EAbyssItemTipsState.Replace:
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_DangoEquipSuccessSwitch_Text", Array.Empty<object>());
			return;
		case DangoAbyssDefine.EAbyssItemTipsState.PutOn:
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Text_DangoEquipSuccessPutOn_Text", Array.Empty<object>());
			return;
		default:
			return;
		}
	}
}
