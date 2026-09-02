using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200154F RID: 5455
[NullableContext(2)]
[Nullable(0)]
public class ActivityRegressSignPanel : UiPanelBase
{
	// Token: 0x06009917 RID: 39191 RVA: 0x00281838 File Offset: 0x0027FA38
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
	}

	// Token: 0x06009918 RID: 39192 RVA: 0x00281900 File Offset: 0x0027FB00
	protected override UniTask OnBeforeStartAsync()
	{
		ActivityRegressSignPanel.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityRegressSignPanel.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06009919 RID: 39193 RVA: 0x00281944 File Offset: 0x0027FB44
	protected override void OnBeforeShow()
	{
		this.SequencePlayer.PlaySequence("Start", false, null);
	}

	// Token: 0x0600991A RID: 39194 RVA: 0x0028196C File Offset: 0x0027FB6C
	protected override UniTask OnBeforeHideAsync()
	{
		ActivityRegressSignPanel.<OnBeforeHideAsync>d__8 <OnBeforeHideAsync>d__;
		<OnBeforeHideAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeHideAsync>d__.<>4__this = this;
		<OnBeforeHideAsync>d__.<>1__state = -1;
		<OnBeforeHideAsync>d__.<>t__builder.Start<ActivityRegressSignPanel.<OnBeforeHideAsync>d__8>(ref <OnBeforeHideAsync>d__);
		return <OnBeforeHideAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600991B RID: 39195 RVA: 0x002819AF File Offset: 0x0027FBAF
	protected override void OnAfterHide()
	{
		this.ClearTimer();
	}

	// Token: 0x0600991C RID: 39196 RVA: 0x002819B7 File Offset: 0x0027FBB7
	protected override void OnBeforeDestroy()
	{
		this.ClearTimer();
		ModelBase<ActivityRegressModel>.Instance.ClearSignRewardConfig();
	}

	// Token: 0x0600991D RID: 39197 RVA: 0x002819C9 File Offset: 0x0027FBC9
	public void RefreshView()
	{
		ModelBase<ActivityRegressModel>.Instance.SetupSignRewardConfig();
		this.RefreshTitle();
		this.RefreshSignInItems();
	}

	// Token: 0x0600991E RID: 39198 RVA: 0x002819E4 File Offset: 0x0027FBE4
	private void RefreshTitle()
	{
		this.TitleComponent.SetTitleByTextId("RecallActivity_Sign_Title", Array.Empty<string>());
		ActivityRegressData activityData = ModelBase<ActivityRegressModel>.Instance.ActivityData;
		ValueTuple<bool, string, long> timeVisibleAndRemainTime = ModelBase<ActivityModel>.Instance.GetTimeVisibleAndRemainTime(activityData, null);
		bool item = timeVisibleAndRemainTime.Item1;
		string item2 = timeVisibleAndRemainTime.Item2;
		this.TitleComponent.SetTimeTextVisible(item);
		this.TitleComponent.SetTogActPlayTypeVisible(false);
		if (item)
		{
			this.TitleComponent.SetTimeTextByText(item2);
		}
	}

	// Token: 0x0600991F RID: 39199 RVA: 0x00281A54 File Offset: 0x0027FC54
	private void RefreshSignInItems()
	{
		for (int i = 0; i < this.SignInRewardItems.Count; i++)
		{
			this.SignInRewardItems[i].RefreshByData(i);
		}
	}

	// Token: 0x06009920 RID: 39200 RVA: 0x00281A89 File Offset: 0x0027FC89
	private void OnTimerRefresh(float gap)
	{
		this.RefreshTitle();
	}

	// Token: 0x06009921 RID: 39201 RVA: 0x00281A91 File Offset: 0x0027FC91
	private void ClearTimer()
	{
		if (TimerSystem.Instance.Has(this.RefreshTimerHandle))
		{
			TimerSystem.Instance.Remove(this.RefreshTimerHandle);
			this.RefreshTimerHandle = null;
		}
	}

	// Token: 0x06009922 RID: 39202 RVA: 0x00281AC0 File Offset: 0x0027FCC0
	private void OnRewardItemClick(int index)
	{
		int signRewardEntityId = ModelBase<ActivityRegressModel>.Instance.ActivityData.GetSignRewardEntityId(index + 1);
		ControllerBase<ActivityRegressController>.Instance.RequestClaimSignReward(signRewardEntityId);
	}

	// Token: 0x040046C2 RID: 18114
	private ActivityTitleTypeA TitleComponent;

	// Token: 0x040046C3 RID: 18115
	[Nullable(1)]
	private readonly List<ActivityRegressSignInRewardItem> SignInRewardItems = new List<ActivityRegressSignInRewardItem>();

	// Token: 0x040046C4 RID: 18116
	private TimerHandle RefreshTimerHandle;

	// Token: 0x040046C5 RID: 18117
	private UiSequencePlayer SequencePlayer;

	// Token: 0x0200790F RID: 30991
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x040299A2 RID: 170402
		public const int ComActivityTitle = 0;

		// Token: 0x040299A3 RID: 170403
		public const int SignInItem1 = 1;

		// Token: 0x040299A4 RID: 170404
		public const int SignInItem2 = 2;

		// Token: 0x040299A5 RID: 170405
		public const int SignInItem3 = 3;

		// Token: 0x040299A6 RID: 170406
		public const int SignInItem4 = 4;

		// Token: 0x040299A7 RID: 170407
		public const int SignInItem5 = 5;

		// Token: 0x040299A8 RID: 170408
		public const int SignInItem6 = 6;

		// Token: 0x040299A9 RID: 170409
		public const int SignInItem7 = 7;
	}
}
