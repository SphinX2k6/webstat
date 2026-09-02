using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RoleSkinTrial;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.ItemReward;
using Cysharp.Threading.Tasks;

// Token: 0x0200157A RID: 5498
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class RoleSkinTrialController : ActivityControllerBase<RoleSkinTrialController>
{
	// Token: 0x06009A55 RID: 39509 RVA: 0x00286CC7 File Offset: 0x00284EC7
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new RoleSkinTrialData();
	}

	// Token: 0x06009A56 RID: 39510 RVA: 0x00286CCE File Offset: 0x00284ECE
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new RoleSkinTrialSubView();
	}

	// Token: 0x06009A57 RID: 39511 RVA: 0x00286CD5 File Offset: 0x00284ED5
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06009A58 RID: 39512 RVA: 0x00286CD7 File Offset: 0x00284ED7
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06009A59 RID: 39513 RVA: 0x00286CDA File Offset: 0x00284EDA
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_ActivityRoleSkinOntrial";
	}

	// Token: 0x06009A5A RID: 39514 RVA: 0x00286CE1 File Offset: 0x00284EE1
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<RoleSkinTrialSettleNotify>(ENotifyMessageId.RoleSkinTrialSettleNotify, new Action<RoleSkinTrialSettleNotify, Net.CallbackStatus>(this.OnRoleSkinTrialSettleNotify));
	}

	// Token: 0x06009A5B RID: 39515 RVA: 0x00286CFF File Offset: 0x00284EFF
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RoleSkinTrialSettleNotify);
	}

	// Token: 0x06009A5C RID: 39516 RVA: 0x00286D11 File Offset: 0x00284F11
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
	}

	// Token: 0x06009A5D RID: 39517 RVA: 0x00286D2F File Offset: 0x00284F2F
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
	}

	// Token: 0x06009A5E RID: 39518 RVA: 0x00286D50 File Offset: 0x00284F50
	private void OnWorldDone()
	{
		if (!RoleSkinTrialController.SkinTrailState || ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			return;
		}
		List<ActivityBaseData> activitiesByType = ModelBase<ActivityModel>.Instance.GetActivitiesByType(35);
		RoleSkinTrialController.SkinTrailState = false;
		foreach (ActivityBaseData activityBaseData in activitiesByType)
		{
			RoleSkinTrialData roleSkinTrialData = activityBaseData as RoleSkinTrialData;
			if (roleSkinTrialData != null && roleSkinTrialData.TrialState)
			{
				roleSkinTrialData.TrialState = false;
				ControllerBase<ActivityController>.Instance.OpenActivityById(activityBaseData.Id, EActivityViewOpenType.Other, null, null);
				break;
			}
		}
	}

	// Token: 0x06009A5F RID: 39519 RVA: 0x00286DEC File Offset: 0x00284FEC
	public static bool CheckIfInRoleSkinTrialInstance()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		return config != null && config.Value.InstSubType == 26;
	}

	// Token: 0x06009A60 RID: 39520 RVA: 0x00286E30 File Offset: 0x00285030
	private void OnRoleSkinTrialSettleNotify(RoleSkinTrialSettleNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		if (notify.ErrorCode > Aki.Protocol.ErrorCode.Success)
		{
			ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(notify.ErrorCode, 25661, null, true, true);
			RewardExploreConfirmButtonData item = new RewardExploreConfirmButtonData
			{
				ButtonTextId = "ConfirmBox_250_ButtonText_0",
				DescriptionTextId = null,
				IsTimeDownCloseView = false,
				IsClickedCloseView = true,
				OnClickedCallback = new Action<int>(RoleSkinTrialController.<OnRoleSkinTrialSettleNotify>g__OnClickQuit|13_0)
			};
			ControllerBase<ItemRewardController>.Instance.OpenExploreRewardView(3023, false, null, null, null, new List<IRewardExploreConfirmButton>
			{
				item
			}, null, null, null, null, null, null, null, null, null, null, null);
			return;
		}
	}

	// Token: 0x06009A61 RID: 39521 RVA: 0x00286ED8 File Offset: 0x002850D8
	public static void RequestRoleSkinTrailInstanceReward(int activityId, int id)
	{
		TrialRoleSkinRewardRequest trialRoleSkinRewardRequest = TrialRoleSkinRewardRequest.Create();
		trialRoleSkinRewardRequest.RoleSkinTrialInfoId = id;
		Singleton<Net>.Instance.Call<TrialRoleSkinRewardResponse>(ERequestMessageId.TrialRoleSkinRewardRequest, trialRoleSkinRewardRequest, delegate(TrialRoleSkinRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 25039, null, true, true);
			}
			RoleSkinTrialData roleSkinTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as RoleSkinTrialData;
			if (roleSkinTrialData == null)
			{
				return;
			}
			roleSkinTrialData.FinishRewardById(id);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YZY;
			string message = "[角色皮肤试用活动]试用副本奖励领取成功";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}, 0);
	}

	// Token: 0x06009A62 RID: 39522 RVA: 0x00286F28 File Offset: 0x00285128
	public static void EnterRoleTrialDungeonDirectly(int instanceId, int activityId, int id)
	{
		RoleSkinTrialData roleSkinTrialData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as RoleSkinTrialData;
		if (roleSkinTrialData == null)
		{
			return;
		}
		roleSkinTrialData.TrialState = true;
		RoleSkinTrialEnterCtx roleSkinTrialEnterCtx = new RoleSkinTrialEnterCtx
		{
			ActivityId = activityId,
			RoleSkinTrialInfoId = id
		};
		RoleSkinTrialController.SkinTrailState = true;
		ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.RoleSkinTrialEnterCtx = roleSkinTrialEnterCtx;
		ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(instanceId, new List<int>(), 0, 0, null, null);
	}

	// Token: 0x06009A63 RID: 39523 RVA: 0x00286F90 File Offset: 0x00285190
	public static void RequestRoleSkinTrialUiEndPush()
	{
		RoleTrialUiEndPush message = RoleTrialUiEndPush.Create();
		Singleton<Net>.Instance.Send(EPushMessageId.RoleSkinTrialUiEndPush, message);
	}

	// Token: 0x06009A65 RID: 39525 RVA: 0x00286FBB File Offset: 0x002851BB
	[CompilerGenerated]
	internal static void <OnRoleSkinTrialSettleNotify>g__OnClickQuit|13_0(int _)
	{
		ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
	}

	// Token: 0x04004726 RID: 18214
	[StaticVariableRuleIgnore]
	private static bool SkinTrailState;

	// Token: 0x04004727 RID: 18215
	public int CurrentActivityId;
}
