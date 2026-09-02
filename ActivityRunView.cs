using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x0200158F RID: 5519
[NullableContext(1)]
[Nullable(0)]
public class ActivityRunView : UiTickViewBase
{
	// Token: 0x06009B51 RID: 39761 RVA: 0x0028AA4C File Offset: 0x00288C4C
	public ActivityRunView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06009B52 RID: 39762 RVA: 0x0028AAAC File Offset: 0x00288CAC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 18;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009B53 RID: 39763 RVA: 0x0028AD6C File Offset: 0x00288F6C
	private void InitCaptionItem()
	{
		this.CaptionItem = new PopupCaptionItem(base.GetItem(0));
		this.CaptionItem.SetCloseCallBack(new Action(this.OnClickBackBtn));
		this.CaptionItem.SetHelpCallBack(new Action(this.OnClickMoreButton));
		this.CaptionItem.SetTitle(this.CurrentActivity.GetTitle());
	}

	// Token: 0x06009B54 RID: 39764 RVA: 0x0028ADD0 File Offset: 0x00288FD0
	protected override void OnStart()
	{
		this.CurrentActivity = (this.OpenParam as ActivityRun);
		this.ActivityRunDataArray = this.CurrentActivity.GetChallengeDataArray();
		this.InitCaptionItem();
		UUIVerticalLayout verticalLayout = base.GetVerticalLayout(7);
		this.TaskScroller = new GenericLayout<ActivityRunItem, int>(verticalLayout, this.CreateTaskItem, null, false, true);
		UUILoopScrollViewComponent scrollView = base.GetItem(1).GetOwner().GetComponentByClass(UUILoopScrollViewComponent.StaticClass()) as UUILoopScrollViewComponent;
		this.ExhibitionView = new LoopScrollView<ActivityRunCycleItem, int>(scrollView, base.GetItem(2).GetOwner() as AUIBaseActor, this.CreateActivityItem, false);
		base.GetItem(2).SetUIActive(false);
		base.GetButton(11).RootUIComp.Get().SetUIActive(false);
		base.GetButton(12).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x06009B55 RID: 39765 RVA: 0x0028AEAC File Offset: 0x002890AC
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnSelectActivityRunChallengeItem, new Action(this.OnSelectActivityRunChallengeItem));
		Singleton<EventSystem>.Instance.Add<ActivityRunCycleItem>(EEventName.OnClickActivityRunChallenge, new Action<ActivityRunCycleItem>(this.OnClickActivityRunChallenge));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnGetRunActivityReward, new Action<int>(this.OnGetRunActivityReward));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06009B56 RID: 39766 RVA: 0x0028AF2C File Offset: 0x0028912C
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectActivityRunChallengeItem, new Action(this.OnSelectActivityRunChallengeItem));
		Singleton<EventSystem>.Instance.Remove<ActivityRunCycleItem>(EEventName.OnClickActivityRunChallenge, new Action<ActivityRunCycleItem>(this.OnClickActivityRunChallenge));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnGetRunActivityReward, new Action<int>(this.OnGetRunActivityReward));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x06009B57 RID: 39767 RVA: 0x0028AFAC File Offset: 0x002891AC
	private void OnActivityClose(IReadOnlySet<int> closeActivities)
	{
		if (closeActivities.Contains(this.CurrentActivity.Id))
		{
			Action value = delegate()
			{
				base.CloseMe(null);
			};
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityEnd);
			confirmBoxDataNew.FunctionMap[1] = value;
			confirmBoxDataNew.FunctionMap[0] = value;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}

	// Token: 0x06009B58 RID: 39768 RVA: 0x0028B007 File Offset: 0x00289207
	private void OnSelectActivityRunChallengeItem()
	{
		this.RefreshTaskScroller();
		this.RefreshConfirmButton();
		this.RefreshPointText();
		this.RefreshContainer();
		this.RefreshCountDownText();
		this.PlaySwitchAnimation();
	}

	// Token: 0x06009B59 RID: 39769 RVA: 0x0028B030 File Offset: 0x00289230
	private void RefreshContainer()
	{
		bool isShow = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId).GetIsShow();
		UUIItem item = base.GetItem(3);
		if (item != null)
		{
			item.SetUIActive(isShow);
		}
		base.GetItem(9).SetUIActive(!isShow);
	}

	// Token: 0x06009B5A RID: 39770 RVA: 0x0028B07C File Offset: 0x0028927C
	private void RefreshConfirmButton()
	{
		ActivityRunData activityRunData = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId);
		if (activityRunData == null)
		{
			return;
		}
		base.GetButton(6).RootUIComp.Get().SetUIActive(activityRunData.GetIsShow());
	}

	// Token: 0x06009B5B RID: 39771 RVA: 0x0028B0C4 File Offset: 0x002892C4
	private void PlaySwitchAnimation()
	{
		if (this.UiViewSequence.HasSequenceNameInPlaying("Switch"))
		{
			this.UiViewSequence.ReplaySequence("Switch");
			return;
		}
		this.UiViewSequence.PlaySequence("Switch", false, null);
	}

	// Token: 0x06009B5C RID: 39772 RVA: 0x0028B10E File Offset: 0x0028930E
	private void OnClickActivityRunChallenge(ActivityRunCycleItem item)
	{
		this.ExhibitionView.ScrollToGridIndex(item.GridIndex, true);
	}

	// Token: 0x06009B5D RID: 39773 RVA: 0x0028B122 File Offset: 0x00289322
	private void OnGetRunActivityReward(int i)
	{
		LoopScrollView<ActivityRunCycleItem, int> exhibitionView = this.ExhibitionView;
		if (exhibitionView == null)
		{
			return;
		}
		exhibitionView.RefreshAllGridProxies();
	}

	// Token: 0x06009B5E RID: 39774 RVA: 0x0028B134 File Offset: 0x00289334
	private void OnClickConfirmBtn()
	{
		if (!ModelBase<ActivityRunModel>.Instance.GetActivityRunData(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId).GetIsShow())
		{
			return;
		}
		int activityRunMarkId = ConfigBase<ActivityRunConfig>.Instance.GetActivityRunMarkId(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId);
		WorldMapViewOpenParams data = new WorldMapViewOpenParams
		{
			MarkId = new int?(activityRunMarkId),
			MarkType = EMarkType.Parkour,
			OpenFogId = new int?(0)
		};
		ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data, null);
	}

	// Token: 0x06009B5F RID: 39775 RVA: 0x0028B1A6 File Offset: 0x002893A6
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x06009B60 RID: 39776 RVA: 0x0028B1AF File Offset: 0x002893AF
	private void OnClickMoreButton()
	{
		this.OpenHelpView();
	}

	// Token: 0x06009B61 RID: 39777 RVA: 0x0028B1B8 File Offset: 0x002893B8
	protected void OpenHelpView()
	{
		int helpId = this.CurrentActivity.GetHelpId();
		ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
	}

	// Token: 0x06009B62 RID: 39778 RVA: 0x0028B1DC File Offset: 0x002893DC
	protected override void OnBeforeShow()
	{
		ControllerBase<ActivityRunController>.Instance.SelectDefaultChallengeId(this.CurrentActivity);
		this.RefreshActivityScroller();
		this.InitTimer();
	}

	// Token: 0x06009B63 RID: 39779 RVA: 0x0028B1FA File Offset: 0x002893FA
	private void InitTimer()
	{
		this.RefreshTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTimerRefresh), 1000f, 1f, null, null, true);
	}

	// Token: 0x06009B64 RID: 39780 RVA: 0x0028B228 File Offset: 0x00289428
	private void OnTimerRefresh(float deltaTime)
	{
		this.RefreshCountDownText();
		ActivityRunData activityRunData = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId);
		if (activityRunData == null)
		{
			return;
		}
		bool isShow = activityRunData.GetIsShow();
		if (isShow && this.IsLastShow != isShow)
		{
			int selectedGridIndex = this.ExhibitionView.GetSelectedGridIndex();
			this.ExhibitionView.RefreshGridProxy(selectedGridIndex);
			this.RefreshTaskScroller();
			this.RefreshPointText();
			this.RefreshConfirmButton();
			this.RefreshContainer();
		}
		this.IsLastShow = isShow;
	}

	// Token: 0x06009B65 RID: 39781 RVA: 0x0028B2A0 File Offset: 0x002894A0
	private void RefreshCountDownText()
	{
		ActivityRunData activityRunData = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId);
		if (!activityRunData.GetIsShow())
		{
			string remainTimeText = this.GetRemainTimeText(activityRunData.BeginOpenTime, "ActiveToOpenTime");
			base.GetText(10).SetText(remainTimeText, true);
		}
	}

	// Token: 0x06009B66 RID: 39782 RVA: 0x0028B2EC File Offset: 0x002894EC
	private string GetRemainTimeText(long dataTime, string timeText)
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = (double)dataTime - serverTime;
		if (num <= 10.0)
		{
			num = 10.0;
		}
		CommonDefine.ICountDown countDownData = Singleton<TimeUtil>.Instance.GetCountDownData(num, null, null);
		if (num >= 86400.0)
		{
			countDownData = Singleton<TimeUtil>.Instance.GetCountDownData(num, new CommonDefine.ETimeType?(CommonDefine.ETimeType.Day), new CommonDefine.ETimeType?(CommonDefine.ETimeType.Hour));
		}
		return ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById(timeText), null).Replace("{0}", countDownData.CountDownText);
	}

	// Token: 0x06009B67 RID: 39783 RVA: 0x0028B384 File Offset: 0x00289584
	private void RefreshActivityScroller()
	{
		int count = this.ActivityRunDataArray.Count;
		List<int> list = new List<int>();
		for (int i = 0; i < count; i++)
		{
			list.Add(this.ActivityRunDataArray[i].Id);
		}
		this.ExhibitionView.RefreshByDataAsync(list, false, false).ContinueWith(delegate()
		{
			this.ExhibitionView.SelectGridProxy(ModelBase<ActivityRunModel>.Instance.GetStartViewSelectIndex(), true);
		});
	}

	// Token: 0x06009B68 RID: 39784 RVA: 0x0028B3E8 File Offset: 0x002895E8
	private void RefreshTaskScroller()
	{
		ActivityRunData activityRunData = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId);
		if (activityRunData == null)
		{
			return;
		}
		List<int> scoreArray = activityRunData.GetScoreArray();
		this.TaskScroller.RefreshByData(scoreArray, null, false);
	}

	// Token: 0x06009B69 RID: 39785 RVA: 0x0028B424 File Offset: 0x00289624
	private void RefreshPointText()
	{
		ActivityRunData activityRunData = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(ModelBase<ActivityRunModel>.Instance.CurrentSelectChallengeId);
		if (activityRunData == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(15), "ActiveRunMaxPoint", Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(16), "ActiveRunMinTime", Array.Empty<object>());
		if (activityRunData.GetMiniTime() == 0)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("ActivityRunNoPoint"), null);
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetText(localTextNew, true);
			}
			UUIText text2 = base.GetText(5);
			if (text2 != null)
			{
				text2.SetText(localTextNew, true);
			}
		}
		else
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(15), "ActiveRunMaxPoint", Array.Empty<object>());
			UUIText text3 = base.GetText(4);
			if (text3 != null)
			{
				text3.SetText(activityRunData.GetMaxScore().ToString(), true);
			}
			string timeString = Singleton<TimeUtil>.Instance.GetTimeString((double)activityRunData.GetMiniTime());
			UUIText text4 = base.GetText(5);
			if (text4 != null)
			{
				text4.SetText(timeString.ToString(), true);
			}
		}
		base.GetText(17).ShowTextNew("ReadyToFightText");
	}

	// Token: 0x06009B6A RID: 39786 RVA: 0x0028B544 File Offset: 0x00289744
	protected override void OnBeforeDestroy()
	{
		if (this.RefreshTimer != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
			this.RefreshTimer = null;
		}
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.ActivityRun);
	}

	// Token: 0x04004779 RID: 18297
	private const int TIMERGAP = 1000;

	// Token: 0x0400477A RID: 18298
	[Nullable(2)]
	private TimerHandle RefreshTimer;

	// Token: 0x0400477B RID: 18299
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ActivityRunData> ActivityRunDataArray;

	// Token: 0x0400477C RID: 18300
	[Nullable(2)]
	private ActivityRun CurrentActivity;

	// Token: 0x0400477D RID: 18301
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<ActivityRunItem, int> TaskScroller;

	// Token: 0x0400477E RID: 18302
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private LoopScrollView<ActivityRunCycleItem, int> ExhibitionView;

	// Token: 0x0400477F RID: 18303
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04004780 RID: 18304
	private readonly Func<ActivityRunItem> CreateTaskItem = () => new ActivityRunItem();

	// Token: 0x04004781 RID: 18305
	private readonly Func<ActivityRunCycleItem> CreateActivityItem = () => new ActivityRunCycleItem();

	// Token: 0x04004782 RID: 18306
	private bool IsLastShow;

	// Token: 0x0200795A RID: 31066
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029AFF RID: 170751
		public const int CaptionItem = 0;

		// Token: 0x04029B00 RID: 170752
		public const int LeftScroller = 1;

		// Token: 0x04029B01 RID: 170753
		public const int LeftItem = 2;

		// Token: 0x04029B02 RID: 170754
		public const int PnlRight = 3;

		// Token: 0x04029B03 RID: 170755
		public const int BestPointText = 4;

		// Token: 0x04029B04 RID: 170756
		public const int BestTimeText = 5;

		// Token: 0x04029B05 RID: 170757
		public const int BtnConfirm = 6;

		// Token: 0x04029B06 RID: 170758
		public const int RightScroller = 7;

		// Token: 0x04029B07 RID: 170759
		public const int RightItem = 8;

		// Token: 0x04029B08 RID: 170760
		public const int LockContainer = 9;

		// Token: 0x04029B09 RID: 170761
		public const int LockText = 10;

		// Token: 0x04029B0A RID: 170762
		public const int BtnUp = 11;

		// Token: 0x04029B0B RID: 170763
		public const int BtnDown = 12;

		// Token: 0x04029B0C RID: 170764
		public const int UpRed = 13;

		// Token: 0x04029B0D RID: 170765
		public const int DownRed = 14;

		// Token: 0x04029B0E RID: 170766
		public const int BestPointTextTitle = 15;

		// Token: 0x04029B0F RID: 170767
		public const int BestTimeTextTitle = 16;

		// Token: 0x04029B10 RID: 170768
		public const int TxtFunc = 17;
	}
}
