using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200135A RID: 4954
[NullableContext(1)]
[Nullable(0)]
public class LongShanView : UiViewBase
{
	// Token: 0x060087A5 RID: 34725 RVA: 0x0023C26B File Offset: 0x0023A46B
	public LongShanView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060087A6 RID: 34726 RVA: 0x0023C274 File Offset: 0x0023A474
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnClickPre));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickNext));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060087A7 RID: 34727 RVA: 0x0023C447 File Offset: 0x0023A647
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.LongShanUpdate, new Action(this.RefreshTasks));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x060087A8 RID: 34728 RVA: 0x0023C481 File Offset: 0x0023A681
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.LongShanUpdate, new Action(this.RefreshTasks));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityClose, new Action<IReadOnlySet<int>>(this.OnActivityClose));
	}

	// Token: 0x060087A9 RID: 34729 RVA: 0x0023C4BC File Offset: 0x0023A6BC
	protected override UniTask OnBeforeStartAsync()
	{
		LongShanView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<LongShanView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060087AA RID: 34730 RVA: 0x0023C500 File Offset: 0x0023A700
	protected override void OnBeforeShow()
	{
		this.RefreshTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTimerRefresh), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		this.RefreshView(this.CurrentIndex);
		this.OnTimerRefresh(0f);
	}

	// Token: 0x060087AB RID: 34731 RVA: 0x0023C553 File Offset: 0x0023A753
	protected override void OnBeforeHide()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.RefreshTimer))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
			this.RefreshTimer = null;
		}
	}

	// Token: 0x060087AC RID: 34732 RVA: 0x0023C580 File Offset: 0x0023A780
	private void OnTimerRefresh(float _)
	{
		if (!this.ActivityBaseData.CheckIfInOpenTime())
		{
			base.CloseMe(null);
			return;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = Math.Max((double)this.ActivityBaseData.EndOpenTime - serverTime, 1.0);
		ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> timeTypeData = this.GetTimeTypeData(num);
		string item = Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(timeTypeData.Item1), new CommonDefine.ETimeType?(timeTypeData.Item2)).CountDownText ?? "";
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "ActivityRemainingTime", new <>z__ReadOnlySingleElementList<object>(item));
	}

	// Token: 0x060087AD RID: 34733 RVA: 0x0023C620 File Offset: 0x0023A820
	[NullableContext(0)]
	private ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> GetTimeTypeData(double remainTime)
	{
		if (remainTime > 86400.0)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Day, CommonDefine.ETimeType.Hour);
		}
		if (remainTime > 3600.0)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Hour, CommonDefine.ETimeType.Minute);
		}
		if (remainTime > 60.0)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Minute, CommonDefine.ETimeType.Second);
		}
		return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Second, CommonDefine.ETimeType.Second);
	}

	// Token: 0x060087AE RID: 34734 RVA: 0x0023C670 File Offset: 0x0023A870
	private LongShanTaskItem CreateTaskItem()
	{
		return new LongShanTaskItem();
	}

	// Token: 0x060087AF RID: 34735 RVA: 0x0023C677 File Offset: 0x0023A877
	private PageDot<int> InitPageDot()
	{
		return new PageDot<int>();
	}

	// Token: 0x060087B0 RID: 34736 RVA: 0x0023C680 File Offset: 0x0023A880
	public void RefreshView(int newIndex)
	{
		this.PageDotLayout.GetLayoutItemByIndex(this.CurrentIndex).UpdateShow(false);
		this.CurrentIndex = newIndex;
		this.PageDotLayout.GetLayoutItemByIndex(this.CurrentIndex).UpdateShow(true);
		int num = this.ActivityBaseData.StageIds[this.CurrentIndex];
		this.ActivityBaseData.SaveNewStageFlag(num);
		LongShanStage value = ConfigLongShanStageById.GetConfig(num, true).Value;
		base.SetTextureByPath(value.Picture, base.GetTexture(9), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), value.TitleDetail, Array.Empty<object>());
		this.RefreshTasks();
		base.GetButton(5).RootUIComp.Get().SetUIActive(this.CurrentIndex > 0);
		base.GetButton(6).RootUIComp.Get().SetUIActive(this.CurrentIndex < this.ActivityBaseData.StageIds.Length - 1);
	}

	// Token: 0x060087B1 RID: 34737 RVA: 0x0023C788 File Offset: 0x0023A988
	private int TaskSort(LongShanTaskInfo a, LongShanTaskInfo b)
	{
		if (a.IsTaken != b.IsTaken)
		{
			if (!a.IsTaken)
			{
				return -1;
			}
			return 1;
		}
		else if (a.IsFinished != b.IsFinished)
		{
			if (!a.IsFinished)
			{
				return 1;
			}
			return -1;
		}
		else
		{
			int sortId = ConfigLongShanTaskById.GetConfig(a.Id, true).Value.SortId;
			int sortId2 = ConfigLongShanTaskById.GetConfig(b.Id, true).Value.SortId;
			if (sortId != sortId2)
			{
				return sortId - sortId2;
			}
			return a.Id - b.Id;
		}
	}

	// Token: 0x060087B2 RID: 34738 RVA: 0x0023C818 File Offset: 0x0023AA18
	private void RefreshTasks()
	{
		int id = this.ActivityBaseData.StageIds[this.CurrentIndex];
		int progress = this.ActivityBaseData.GetProgress(id);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "LongShanStage_ProgressPercentage", new <>z__ReadOnlySingleElementList<object>(progress));
		List<LongShanTaskInfo> list = this.ActivityBaseData.GetStageInfoById(id).Tasks.ToList<LongShanTaskInfo>();
		list.Sort(new Comparison<LongShanTaskInfo>(this.TaskSort));
		GenericScrollViewNew<LongShanTaskItem, LongShanTaskInfo> taskScroll = this.TaskScroll;
		if (taskScroll == null)
		{
			return;
		}
		taskScroll.RefreshByData(list, null, true);
	}

	// Token: 0x060087B3 RID: 34739 RVA: 0x0023C8A2 File Offset: 0x0023AAA2
	private void OnClickPre()
	{
		this.RefreshView(this.CurrentIndex - 1);
	}

	// Token: 0x060087B4 RID: 34740 RVA: 0x0023C8B4 File Offset: 0x0023AAB4
	private void OnClickNext()
	{
		int num = this.ActivityBaseData.StageIds[this.CurrentIndex + 1];
		if (this.ActivityBaseData.GetStageInfoById(num) != null)
		{
			this.RefreshView(this.CurrentIndex + 1);
			return;
		}
		ControllerBase<ActivityLongShanController>.Instance.ShowUnlockTip(num);
	}

	// Token: 0x060087B5 RID: 34741 RVA: 0x0023C900 File Offset: 0x0023AB00
	private void OpenHelpView()
	{
		int helpId = this.ActivityBaseData.GetHelpId();
		ControllerBase<HelpController>.Instance.OpenHelpById(helpId);
	}

	// Token: 0x060087B6 RID: 34742 RVA: 0x0023C924 File Offset: 0x0023AB24
	private void CloseView()
	{
		base.CloseMe(null);
	}

	// Token: 0x060087B7 RID: 34743 RVA: 0x0023C930 File Offset: 0x0023AB30
	private void OnActivityClose(IReadOnlySet<int> closeActivities)
	{
		if (closeActivities.Contains(this.ActivityBaseData.Id))
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ActivityEnd);
			confirmBoxDataNew.FunctionMap[1] = new Action(this.<OnActivityClose>g__ConfirmCallback|25_0);
			confirmBoxDataNew.FunctionMap[0] = new Action(this.<OnActivityClose>g__ConfirmCallback|25_0);
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}
	}

	// Token: 0x060087B8 RID: 34744 RVA: 0x0023C994 File Offset: 0x0023AB94
	[CompilerGenerated]
	private void <OnActivityClose>g__ConfirmCallback|25_0()
	{
		base.CloseMe(null);
	}

	// Token: 0x04003FDE RID: 16350
	protected ActivityLongShanData ActivityBaseData;

	// Token: 0x04003FDF RID: 16351
	[Nullable(2)]
	private TimerHandle RefreshTimer;

	// Token: 0x04003FE0 RID: 16352
	private int CurrentIndex;

	// Token: 0x04003FE1 RID: 16353
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04003FE2 RID: 16354
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<PageDot<int>, int> PageDotLayout;

	// Token: 0x04003FE3 RID: 16355
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<LongShanTaskItem, LongShanTaskInfo> TaskScroll;

	// Token: 0x02007700 RID: 30464
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028FB9 RID: 167865
		public const int CaptionItem = 0;

		// Token: 0x04028FBA RID: 167866
		public const int TxtName = 1;

		// Token: 0x04028FBB RID: 167867
		public const int TxtProgress = 2;

		// Token: 0x04028FBC RID: 167868
		public const int LabelFinish = 3;

		// Token: 0x04028FBD RID: 167869
		public const int TaskParent = 4;

		// Token: 0x04028FBE RID: 167870
		public const int BtnPre = 5;

		// Token: 0x04028FBF RID: 167871
		public const int BtnNext = 6;

		// Token: 0x04028FC0 RID: 167872
		public const int PageDotLayout = 7;

		// Token: 0x04028FC1 RID: 167873
		public const int TxtTime = 8;

		// Token: 0x04028FC2 RID: 167874
		public const int TexPicture = 9;
	}
}
