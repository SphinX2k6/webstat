using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Sequence.Seq_BP.BPGobletLiquid;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B2E RID: 6958
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class DrinksController : UiControllerBase<DrinksController>
{
	// Token: 0x0600C8AE RID: 51374 RVA: 0x00352D32 File Offset: 0x00350F32
	public void OpenMainView(EDrinksGameplayOpenWay openWay)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DrinksSelectRoleView, openWay, null);
	}

	// Token: 0x0600C8AF RID: 51375 RVA: 0x00352D4C File Offset: 0x00350F4C
	public UniTask<bool> SelectRoleAndPlaySeq(int roleId, EDrinksGameplayOpenWay openWay, int? requireId = null)
	{
		DrinksController.<SelectRoleAndPlaySeq>d__1 <SelectRoleAndPlaySeq>d__;
		<SelectRoleAndPlaySeq>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<SelectRoleAndPlaySeq>d__.<>4__this = this;
		<SelectRoleAndPlaySeq>d__.roleId = roleId;
		<SelectRoleAndPlaySeq>d__.openWay = openWay;
		<SelectRoleAndPlaySeq>d__.requireId = requireId;
		<SelectRoleAndPlaySeq>d__.<>1__state = -1;
		<SelectRoleAndPlaySeq>d__.<>t__builder.Start<DrinksController.<SelectRoleAndPlaySeq>d__1>(ref <SelectRoleAndPlaySeq>d__);
		return <SelectRoleAndPlaySeq>d__.<>t__builder.Task;
	}

	// Token: 0x0600C8B0 RID: 51376 RVA: 0x00352DA7 File Offset: 0x00350FA7
	public void OpenPlayView()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.DrinksGameplayView, null, null);
	}

	// Token: 0x0600C8B1 RID: 51377 RVA: 0x00352DBC File Offset: 0x00350FBC
	public UniTask<bool> RequestMixDrinkSettle()
	{
		DrinksController.<RequestMixDrinkSettle>d__3 <RequestMixDrinkSettle>d__;
		<RequestMixDrinkSettle>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestMixDrinkSettle>d__.<>4__this = this;
		<RequestMixDrinkSettle>d__.<>1__state = -1;
		<RequestMixDrinkSettle>d__.<>t__builder.Start<DrinksController.<RequestMixDrinkSettle>d__3>(ref <RequestMixDrinkSettle>d__);
		return <RequestMixDrinkSettle>d__.<>t__builder.Task;
	}

	// Token: 0x0600C8B2 RID: 51378 RVA: 0x00352E00 File Offset: 0x00351000
	public UniTask<bool> RequestMixDrinkRoleInvite(int roleId)
	{
		DrinksController.<RequestMixDrinkRoleInvite>d__4 <RequestMixDrinkRoleInvite>d__;
		<RequestMixDrinkRoleInvite>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestMixDrinkRoleInvite>d__.<>4__this = this;
		<RequestMixDrinkRoleInvite>d__.roleId = roleId;
		<RequestMixDrinkRoleInvite>d__.<>1__state = -1;
		<RequestMixDrinkRoleInvite>d__.<>t__builder.Start<DrinksController.<RequestMixDrinkRoleInvite>d__4>(ref <RequestMixDrinkRoleInvite>d__);
		return <RequestMixDrinkRoleInvite>d__.<>t__builder.Task;
	}

	// Token: 0x0600C8B3 RID: 51379 RVA: 0x00352E4C File Offset: 0x0035104C
	public UniTask<bool> RequestMixDrinkRoleReward(int configId, int roleId)
	{
		DrinksController.<RequestMixDrinkRoleReward>d__5 <RequestMixDrinkRoleReward>d__;
		<RequestMixDrinkRoleReward>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RequestMixDrinkRoleReward>d__.configId = configId;
		<RequestMixDrinkRoleReward>d__.roleId = roleId;
		<RequestMixDrinkRoleReward>d__.<>1__state = -1;
		<RequestMixDrinkRoleReward>d__.<>t__builder.Start<DrinksController.<RequestMixDrinkRoleReward>d__5>(ref <RequestMixDrinkRoleReward>d__);
		return <RequestMixDrinkRoleReward>d__.<>t__builder.Task;
	}

	// Token: 0x0600C8B4 RID: 51380 RVA: 0x00352E98 File Offset: 0x00351098
	public UniTask GmTestScoreCheck()
	{
		DrinksController.<GmTestScoreCheck>d__6 <GmTestScoreCheck>d__;
		<GmTestScoreCheck>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<GmTestScoreCheck>d__.<>4__this = this;
		<GmTestScoreCheck>d__.<>1__state = -1;
		<GmTestScoreCheck>d__.<>t__builder.Start<DrinksController.<GmTestScoreCheck>d__6>(ref <GmTestScoreCheck>d__);
		return <GmTestScoreCheck>d__.<>t__builder.Task;
	}

	// Token: 0x0600C8B5 RID: 51381 RVA: 0x00352EDC File Offset: 0x003510DC
	public void GmTestCupActor(int id)
	{
		BP_Prop_GobletLiquid_C bp_Prop_GobletLiquid_C = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("Cups").Value, ECollectActorType.Default) as BP_Prop_GobletLiquid_C;
		if (bp_Prop_GobletLiquid_C == null)
		{
			return;
		}
		ModelBase<DrinksModel>.Instance.GetSceneController().UpdateWaterById(bp_Prop_GobletLiquid_C, id, Array.Empty<int>(), 1207, false, true);
	}

	// Token: 0x0600C8B6 RID: 51382 RVA: 0x00352F28 File Offset: 0x00351128
	public void ReportDrinksGameplayInvite()
	{
		DrinksGameplayInviteLogEvent drinksGameplayInviteLogEvent = new DrinksGameplayInviteLogEvent();
		DrinksModel instance = ModelBase<DrinksModel>.Instance;
		SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
		int roleId = instance.GetRoleId();
		drinksGameplayInviteLogEvent.i_activity_id = activityData.Id;
		drinksGameplayInviteLogEvent.i_role_id = roleId;
		drinksGameplayInviteLogEvent.i_inst_id = (int)instance.GameplayOpenWay;
		if (instance.GameplayIsMainQuest)
		{
			drinksGameplayInviteLogEvent.i_first_pass = 0;
		}
		else
		{
			Dictionary<int, IDrinksMixRoleInfo> drinksProgressMap = activityData.GetDrinksProgressMap();
			if (!drinksProgressMap.ContainsKey(roleId))
			{
				drinksGameplayInviteLogEvent.i_first_pass = 1;
				instance.GameplayFirstInvite = true;
			}
			else
			{
				IDrinksMixRoleInfo drinksMixRoleInfo;
				drinksProgressMap.TryGetValue(roleId, out drinksMixRoleInfo);
				drinksGameplayInviteLogEvent.i_first_pass = (drinksMixRoleInfo.FirstPass ? 3 : 2);
				instance.GameplayFirstInvite = false;
			}
		}
		drinksGameplayInviteLogEvent.s_trace_id = instance.GameplayStamp.ToString();
		ControllerBase<LogReportController>.Instance.LogReport(drinksGameplayInviteLogEvent);
	}

	// Token: 0x0600C8B7 RID: 51383 RVA: 0x00352FE8 File Offset: 0x003511E8
	public void ReportDrinksGameplayResult()
	{
		DrinksGameplayResultLogEvent drinksGameplayResultLogEvent = new DrinksGameplayResultLogEvent();
		DrinksModel instance = ModelBase<DrinksModel>.Instance;
		SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
		int roleId = instance.GetRoleId();
		DrinksResultInfo currentPlayData = instance.GetCurrentPlayData();
		drinksGameplayResultLogEvent.i_activity_id = activityData.Id;
		drinksGameplayResultLogEvent.i_role_id = roleId;
		drinksGameplayResultLogEvent.i_inst_id = (int)instance.GameplayOpenWay;
		Dictionary<int, IDrinksMixRoleInfo> drinksProgressMap = activityData.GetDrinksProgressMap();
		ValueTuple<int, List<IDrinksRequireInfo>> roleState = instance.GetRoleState();
		int item = roleState.Item1;
		List<IDrinksRequireInfo> item2 = roleState.Item2;
		int likenessMax = instance.GetLikenessMax();
		if (instance.GameplayIsMainQuest)
		{
			drinksGameplayResultLogEvent.i_first_pass = 0;
		}
		else if (instance.GameplayFirstInvite)
		{
			drinksGameplayResultLogEvent.i_first_pass = 1;
		}
		else
		{
			IDrinksMixRoleInfo drinksMixRoleInfo;
			drinksProgressMap.TryGetValue(roleId, out drinksMixRoleInfo);
			drinksGameplayResultLogEvent.i_first_pass = (drinksMixRoleInfo.FirstPass ? 3 : 2);
		}
		if (item <= 0)
		{
			drinksGameplayResultLogEvent.i_result = 1;
		}
		else
		{
			drinksGameplayResultLogEvent.i_result = ((item >= likenessMax) ? 3 : 2);
		}
		DrinksDrinkBase? drinkBase = ConfigBase<DrinksConfig>.Instance.GetDrinkBase(currentPlayData.DrinkBase[0]);
		drinksGameplayResultLogEvent.i_first_tab = drinkBase.Value.DrinkId;
		drinksGameplayResultLogEvent.i_first_count = drinkBase.Value.QTENum;
		DrinksDrinkBase? drinkBase2 = ConfigBase<DrinksConfig>.Instance.GetDrinkBase(currentPlayData.DrinkBase[1]);
		drinksGameplayResultLogEvent.i_second_tab = drinkBase2.Value.DrinkId;
		drinksGameplayResultLogEvent.i_second_count = drinkBase2.Value.QTENum;
		drinksGameplayResultLogEvent.i_third_tab = ((currentPlayData.Batching != null && currentPlayData.Batching.Count > 0) ? currentPlayData.Batching[0] : -1);
		drinksGameplayResultLogEvent.i_fourth_tab = ((currentPlayData.Batching != null && currentPlayData.Batching.Count > 1) ? currentPlayData.Batching[1] : -1);
		drinksGameplayResultLogEvent.i_fifth_tab = ((currentPlayData.Ornament == 0) ? -1 : currentPlayData.Ornament);
		drinksGameplayResultLogEvent.i_cost_time = (int)((Singleton<TimeUtil>.Instance.GetServerTimeStamp() - instance.GameplayStamp) * Singleton<TimeUtil>.Instance.Millisecond);
		drinksGameplayResultLogEvent.i_require_id = currentPlayData.RequireId;
		drinksGameplayResultLogEvent.o_score_buff = new List<int>();
		foreach (IDrinksRequireInfo drinksRequireInfo in item2)
		{
			drinksGameplayResultLogEvent.o_score_buff.Add((drinksRequireInfo.Completed > false) ? 1 : 0);
		}
		drinksGameplayResultLogEvent.s_trace_id = instance.GameplayStamp.ToString();
		ControllerBase<LogReportController>.Instance.LogReport(drinksGameplayResultLogEvent);
	}
}
