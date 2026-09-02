using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020014FB RID: 5371
[NullableContext(2)]
[Nullable(0)]
public class ActivityRegress30MainView : ActivitySubViewBase
{
	// Token: 0x06009647 RID: 38471 RVA: 0x002745BC File Offset: 0x002727BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 22;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 9;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickBattlePassBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickRoleBtnBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickSignBtnBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickNewVersionBtnBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickCultivateBtnBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickStartUpBtnBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickQuestionnaireBtnBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickShopBtnBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(18, new Action(this.OnClickRewardBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009648 RID: 38472 RVA: 0x00274A20 File Offset: 0x00272C20
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegress30MainView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegress30MainView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009649 RID: 38473 RVA: 0x00274A63 File Offset: 0x00272C63
	protected override void OnTimer(float gap)
	{
		this.RefreshTitle();
	}

	// Token: 0x0600964A RID: 38474 RVA: 0x00274A6C File Offset: 0x00272C6C
	private void RefreshTitle()
	{
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		this.TitleComponent.SetTimeTextVisible(timeVisibleAndRemainTime.Item1);
		if (timeVisibleAndRemainTime.Item1)
		{
			this.TitleComponent.SetTimeTextByText(timeVisibleAndRemainTime.Item2);
		}
	}

	// Token: 0x0600964B RID: 38475 RVA: 0x00274AD4 File Offset: 0x00272CD4
	protected override void OnRefreshView()
	{
		base.OnRefreshView();
		int currentUseTrialRole = ((ActivityRegressData)this.ActivityBaseData).CurrentUseTrialRole;
		ActivityRegressRoleItem activityRegressRoleItemInternal = this.ActivityRegressRoleItemInternal;
		if (activityRegressRoleItemInternal != null)
		{
			activityRegressRoleItemInternal.RefreshItem(currentUseTrialRole);
		}
		Activity? localConfig = this.ActivityBaseData.LocalConfig;
		string descTheme = localConfig.Value.DescTheme;
		bool flag = !StringUtils.IsEmpty(descTheme);
		this.TitleComponent.SetSubTitleVisible(flag);
		if (flag)
		{
			this.TitleComponent.SetSubTitleByTextId(descTheme, Array.Empty<string>());
		}
		this.TitleComponent.SetActivityBaseData(this.ActivityBaseData);
		this.TitleComponent.SetTitleByText(this.ActivityBaseData.GetTitle());
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = this.GetTimeVisibleAndRemainTime();
		this.TitleComponent.SetTimeTextVisible(timeVisibleAndRemainTime.Item1);
		if (timeVisibleAndRemainTime.Item1)
		{
			this.TitleComponent.SetTimeTextByText(timeVisibleAndRemainTime.Item2);
		}
		IRegressLevelProgressData curLevelProgressData = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetCurLevelProgressData();
		base.GetText(10).SetText("Lv." + curLevelProgressData.Level.ToString(), true);
		base.GetText(11).SetText("/" + curLevelProgressData.MaxLevel.ToString(), true);
		SignItem signItemInternal = this.SignItemInternal;
		if (signItemInternal != null)
		{
			signItemInternal.RefreshSignItem(ModelBase<ActivityRegressModel>.Instance.Grade == ERegressGrade.Hyper, ModelBase<ActivityRegressModel>.Instance.HasSignRewardCanClaimed());
		}
		this.OnRecallActivityInfoUpdate();
	}

	// Token: 0x0600964C RID: 38476 RVA: 0x00274C3C File Offset: 0x00272E3C
	protected override void OnStart()
	{
		base.OnStart();
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityRegressQuestionnaire, base.GetItem(16), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityRegressShopDiscount, base.GetItem(17), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityRecallSignEntry, base.GetItem(12), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityRegressDisposableReward, base.GetItem(15), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityRegressTrialRole, base.GetItem(14), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityRegressBp, base.GetItem(13), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityRegressRewardBtn, base.GetItem(19), null, 0);
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(this.OnRecallActivityInfoUpdate));
	}

	// Token: 0x0600964D RID: 38477 RVA: 0x00274D1A File Offset: 0x00272F1A
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
	}

	// Token: 0x0600964E RID: 38478 RVA: 0x00274D2C File Offset: 0x00272F2C
	protected override void OnBeforeDestroy()
	{
		base.OnBeforeDestroy();
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityRegressQuestionnaire, base.GetItem(16), 0);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityRegressShopDiscount, base.GetItem(17), 0);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityRecallSignEntry, base.GetItem(12), 0);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityRegressDisposableReward, base.GetItem(15), 0);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityRegressTrialRole, base.GetItem(14), 0);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityRegressBp, base.GetItem(13), 0);
		ControllerBase<RedDotController>.Instance.UnBindGivenUi(ERedDotName.ActivityRegressRewardBtn, base.GetItem(19), 0);
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(this.OnRecallActivityInfoUpdate));
		if (this.RewardPopupInternal != null)
		{
			this.RewardPopupInternal = null;
		}
	}

	// Token: 0x0600964F RID: 38479 RVA: 0x00274E12 File Offset: 0x00273012
	private void OnRecallActivityInfoUpdate()
	{
		base.GetItem(21).SetUIActive(ModelBase<ActivityRegressModel>.Instance.DisposableReward);
	}

	// Token: 0x06009650 RID: 38480 RVA: 0x00274E2C File Offset: 0x0027302C
	private void OnClickBattlePassBtn()
	{
		IActivityRegressMainViewOpenData activityRegressMainViewOpenData = new IActivityRegressMainViewOpenData
		{
			SubView = EActivityMainSubViewNewType.BattlePass,
			OpenType = EActivityRegressMainViewOpenDataType.Regress
		};
		ActivityRegressHelper.ReportRecallLog1023New(EReportLogEventNewType.BattlePass);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressMainView, activityRegressMainViewOpenData, null);
	}

	// Token: 0x06009651 RID: 38481 RVA: 0x00274E70 File Offset: 0x00273070
	private void OnClickRoleBtnBtn()
	{
		ActivityRegressHelper.ReportRecallLog1023New(EReportLogEventNewType.TrialRole);
		ControllerBase<ActivityRegressController>.Instance.OpenTrialRoleView(null);
		ModelBase<ActivityRegressModel>.Instance.ActivityData.SetTrialRoleRedDotChecked(true);
	}

	// Token: 0x06009652 RID: 38482 RVA: 0x00274EA8 File Offset: 0x002730A8
	private void OnClickSignBtnBtn()
	{
		IActivityRegressMainViewOpenData activityRegressMainViewOpenData = new IActivityRegressMainViewOpenData
		{
			SubView = EActivityMainSubViewNewType.Sign,
			OpenType = EActivityRegressMainViewOpenDataType.Regress
		};
		ActivityRegressHelper.ReportRecallLog1023New(EReportLogEventNewType.Sign);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressMainView, activityRegressMainViewOpenData, null);
	}

	// Token: 0x06009653 RID: 38483 RVA: 0x00274EEB File Offset: 0x002730EB
	private void OnClickNewVersionBtnBtn()
	{
		ActivityRegressHelper.ReportRecallLog1023New(EReportLogEventNewType.NewVersion);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressNewVersionMainView, null, null);
	}

	// Token: 0x06009654 RID: 38484 RVA: 0x00274F04 File Offset: 0x00273104
	private void OnClickCultivateBtnBtn()
	{
		IActivityRegressMainViewOpenData activityRegressMainViewOpenData = new IActivityRegressMainViewOpenData
		{
			SubView = EActivityMainSubViewNewType.Adventure,
			OpenType = EActivityRegressMainViewOpenDataType.Regress
		};
		ActivityRegressHelper.ReportRecallLog1023New(EReportLogEventNewType.Adventure);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressMainView, activityRegressMainViewOpenData, null);
	}

	// Token: 0x06009655 RID: 38485 RVA: 0x00274F47 File Offset: 0x00273147
	private void OnClickStartUpBtnBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressStartupView, true, null);
	}

	// Token: 0x06009656 RID: 38486 RVA: 0x00274F5F File Offset: 0x0027315F
	private void OnClickQuestionnaireBtnBtn()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRegressQuestionnaireView, null, null);
	}

	// Token: 0x06009657 RID: 38487 RVA: 0x00274F72 File Offset: 0x00273172
	private void OnClickShopBtnBtn()
	{
		SkipTaskManager.RunByConfigId(859201, null);
		ActivityRegressHelper.ReportRegressLog1060();
		ModelBase<ActivityRegressModel>.Instance.ActivityData.SetShopRedDotChecked();
	}

	// Token: 0x06009658 RID: 38488 RVA: 0x00274F94 File Offset: 0x00273194
	private void OnClickRewardBtn()
	{
		ModelBase<ActivityRegressModel>.Instance.ActivityData.SetRegressRewardBtnReached();
		ERegressGrade grade = ModelBase<ActivityRegressModel>.Instance.Grade;
		List<ValueTuple<InventoryDefine.IGetItemData, int>> regressRewardList = this.GetRegressRewardList(grade);
		List<RegressRewardTuple> list = new List<RegressRewardTuple>();
		foreach (ValueTuple<InventoryDefine.IGetItemData, int> valueTuple in regressRewardList)
		{
			list.Add(new RegressRewardTuple
			{
				Id = valueTuple.Item1.ItemId,
				Num = valueTuple.Item2,
				Received = !ModelBase<ActivityRegressModel>.Instance.ActivityData.CheckDisposableRewardRedDot()
			});
		}
		UUIItem mountItem = base.GetButton(18).RootUIComp.Get();
		RegressRewardPopupData data = new RegressRewardPopupData
		{
			RewardLists = list.ToArray(),
			MountItem = mountItem,
			PosBias = FVector.ZeroVector
		};
		this.RewardPopupInternal.Refresh(data);
	}

	// Token: 0x06009659 RID: 38489 RVA: 0x0027509C File Offset: 0x0027329C
	[return: Nullable(new byte[]
	{
		1,
		0,
		1
	})]
	public List<ValueTuple<InventoryDefine.IGetItemData, int>> GetRegressRewardList(ERegressGrade grade)
	{
		RegressDisposableReward? regressDisposableReward = ConfigBase<ActivityRegressConfig>.Instance.GetRegressDisposableReward(ModelBase<ActivityRegressModel>.Instance.ActivityId);
		List<ValueTuple<InventoryDefine.IGetItemData, int>> list = new List<ValueTuple<InventoryDefine.IGetItemData, int>>();
		if (regressDisposableReward == null)
		{
			return list;
		}
		DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage((grade == ERegressGrade.Hyper) ? regressDisposableReward.Value.HighDropId : regressDisposableReward.Value.DropId);
		if (dropPackage == null)
		{
			return list;
		}
		foreach (DicIntInt dicIntInt in dropPackage.Value.DropPreviewIter())
		{
			list.Add(new ValueTuple<InventoryDefine.IGetItemData, int>(new InventoryDefine.GetItemData(dicIntInt.Key, 0), dicIntInt.Value));
		}
		return list;
	}

	// Token: 0x0600965A RID: 38490 RVA: 0x00275174 File Offset: 0x00273374
	protected override void OnBeforeHide()
	{
		base.OnBeforeHide();
		UUIItem item = base.GetItem(21);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		RegressRewardPopup rewardPopupInternal = this.RewardPopupInternal;
		if (rewardPopupInternal == null)
		{
			return;
		}
		rewardPopupInternal.SetActive(false);
	}

	// Token: 0x040045A8 RID: 17832
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x040045A9 RID: 17833
	private SignItem SignItemInternal;

	// Token: 0x040045AA RID: 17834
	private ActivityRegressRoleItem ActivityRegressRoleItemInternal;

	// Token: 0x040045AB RID: 17835
	private RegressRewardPopup RewardPopupInternal;

	// Token: 0x020078BE RID: 30910
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029818 RID: 170008
		public const int TitleItem = 0;

		// Token: 0x04029819 RID: 170009
		public const int BattlePassBtn = 1;

		// Token: 0x0402981A RID: 170010
		public const int SignBtn = 2;

		// Token: 0x0402981B RID: 170011
		public const int CultivateBtn = 3;

		// Token: 0x0402981C RID: 170012
		public const int NewVersionBtn = 4;

		// Token: 0x0402981D RID: 170013
		public const int RoleBtn = 5;

		// Token: 0x0402981E RID: 170014
		public const int StartUpBtn = 6;

		// Token: 0x0402981F RID: 170015
		public const int QuestionnaireBtn = 7;

		// Token: 0x04029820 RID: 170016
		public const int ShopBtn = 8;

		// Token: 0x04029821 RID: 170017
		public const int RoleItem = 9;

		// Token: 0x04029822 RID: 170018
		public const int BpLevelText = 10;

		// Token: 0x04029823 RID: 170019
		public const int BpMaxText = 11;

		// Token: 0x04029824 RID: 170020
		public const int SignRedDotItem = 12;

		// Token: 0x04029825 RID: 170021
		public const int BpRedDotItem = 13;

		// Token: 0x04029826 RID: 170022
		public const int TrialRoleRedDotItem = 14;

		// Token: 0x04029827 RID: 170023
		public const int StartViewRedDotItem = 15;

		// Token: 0x04029828 RID: 170024
		public const int QuestionBtnRedDotRedDotItem = 16;

		// Token: 0x04029829 RID: 170025
		public const int ShopRedDotItem = 17;

		// Token: 0x0402982A RID: 170026
		public const int RewardBtn = 18;

		// Token: 0x0402982B RID: 170027
		public const int RewardBtnDotItem = 19;

		// Token: 0x0402982C RID: 170028
		public const int RewardPopup = 20;

		// Token: 0x0402982D RID: 170029
		public const int RewardBtnFinished = 21;
	}
}
