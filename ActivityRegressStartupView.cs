using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001550 RID: 5456
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressStartupView : UiViewBase
{
	// Token: 0x06009924 RID: 39204 RVA: 0x00281AFE File Offset: 0x0027FCFE
	public ActivityRegressStartupView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06009925 RID: 39205 RVA: 0x00281B08 File Offset: 0x0027FD08
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnContinueBtnClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009926 RID: 39206 RVA: 0x00281BF0 File Offset: 0x0027FDF0
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RecallActivityInfoUpdate, new Action(this.RefreshReward));
	}

	// Token: 0x06009927 RID: 39207 RVA: 0x00281C0E File Offset: 0x0027FE0E
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RecallActivityInfoUpdate, new Action(this.RefreshReward));
	}

	// Token: 0x06009928 RID: 39208 RVA: 0x00281C2C File Offset: 0x0027FE2C
	protected override void OnStart()
	{
		this.FormActityView = (this.OpenParam as bool?).GetValueOrDefault();
		this.StateMachine = new RegressTransitionStateMachine();
		this.RewardLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(0), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, true);
		ERegressGrade grade = ModelBase<ActivityRegressModel>.Instance.Grade;
		this.RewardLayout.RefreshByData(this.GetRewardList(grade), delegate
		{
			foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.RewardLayout.GetLayoutItemList())
			{
				commonItemSmallItemGrid.SetReceivedVisible(ModelBase<ActivityRegressModel>.Instance.DisposableReward);
			}
		}, false);
		base.GetItem(2).SetUIActive(grade == ERegressGrade.Normal);
		base.GetItem(3).SetUIActive(grade == ERegressGrade.Hyper);
	}

	// Token: 0x06009929 RID: 39209 RVA: 0x00281CCD File Offset: 0x0027FECD
	protected override void OnBeforeShow()
	{
		ModelBase<ActivityRegressModel>.Instance.AlreadyStartView = true;
		ModelBase<ActivityRegressModel>.Instance.RecordActivityRecallSplashFirstShow();
		ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.Recall);
		this.StateMachine.Start();
	}

	// Token: 0x0600992A RID: 39210 RVA: 0x00281CFA File Offset: 0x0027FEFA
	protected override void OnBeforeDestroy()
	{
		this.StateMachine.ShutDown();
	}

	// Token: 0x0600992B RID: 39211 RVA: 0x00281D07 File Offset: 0x0027FF07
	private CommonItemSmallItemGrid InitGridItem()
	{
		CommonItemSmallItemGrid commonItemSmallItemGrid = new CommonItemSmallItemGrid();
		commonItemSmallItemGrid.ShowReceivedCallBack = ((TItem _) => ModelBase<ActivityRegressModel>.Instance.DisposableReward);
		return commonItemSmallItemGrid;
	}

	// Token: 0x0600992C RID: 39212 RVA: 0x00281D34 File Offset: 0x0027FF34
	public List<TItem> GetRewardList(ERegressGrade grade)
	{
		RegressDisposableReward? regressDisposableReward = ConfigBase<ActivityRegressConfig>.Instance.GetRegressDisposableReward(ModelBase<ActivityRegressModel>.Instance.ActivityId);
		if (regressDisposableReward == null)
		{
			return new List<TItem>();
		}
		int id = (grade == ERegressGrade.Hyper) ? regressDisposableReward.Value.HighDropId : regressDisposableReward.Value.DropId;
		return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(id);
	}

	// Token: 0x0600992D RID: 39213 RVA: 0x00281D98 File Offset: 0x0027FF98
	public void GotoActivityViewAndCloseSelf()
	{
		ModelBase<ActivityRegressModel>.Instance.SetFirstShowChecked();
		base.CloseMe(null);
		int activityId = ModelBase<ActivityRegressModel>.Instance.ActivityId;
		if (activityId != 0 && !this.FormActityView)
		{
			ControllerBase<ActivityController>.Instance.OpenActivityById(activityId, EActivityViewOpenType.Other, null, delegate(bool _)
			{
			});
		}
	}

	// Token: 0x0600992E RID: 39214 RVA: 0x00281DFC File Offset: 0x0027FFFC
	private void RefreshReward()
	{
		foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.RewardLayout.GetLayoutItemList())
		{
			commonItemSmallItemGrid.SetReceivedVisible(ModelBase<ActivityRegressModel>.Instance.DisposableReward);
		}
	}

	// Token: 0x0600992F RID: 39215 RVA: 0x00281E5C File Offset: 0x0028005C
	private void OnContinueBtnClick()
	{
		this.StateMachine.PlayNextState();
	}

	// Token: 0x040046C6 RID: 18118
	private bool FormActityView;

	// Token: 0x040046C7 RID: 18119
	[Nullable(2)]
	private RegressTransitionStateMachine StateMachine;

	// Token: 0x040046C8 RID: 18120
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x02007912 RID: 30994
	[NullableContext(0)]
	private static class EComponents
	{
		// Token: 0x040299B3 RID: 170419
		public const int PnlHor = 0;

		// Token: 0x040299B4 RID: 170420
		public const int BtnContinue = 1;

		// Token: 0x040299B5 RID: 170421
		public const int NormalCoreCtrl = 2;

		// Token: 0x040299B6 RID: 170422
		public const int HyperCoreCtrl = 3;
	}
}
