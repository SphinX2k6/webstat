using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.AutoAttach;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002BC6 RID: 11206
[NullableContext(1)]
[Nullable(0)]
public class TimeOfDaySecondView : UiTickViewBase
{
	// Token: 0x06016525 RID: 91429 RVA: 0x0062EFE4 File Offset: 0x0062D1E4
	public TimeOfDaySecondView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06016526 RID: 91430 RVA: 0x0062EFF8 File Offset: 0x0062D1F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickBackBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickConfirmBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06016527 RID: 91431 RVA: 0x0062F1CC File Offset: 0x0062D3CC
	protected override UniTask OnBeforeStartAsync()
	{
		TimeOfDaySecondView.<OnBeforeStartAsync>d__10 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TimeOfDaySecondView.<OnBeforeStartAsync>d__10>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06016528 RID: 91432 RVA: 0x0062F210 File Offset: 0x0062D410
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(6);
		UUIItem item2 = base.GetItem(7);
		base.GetUiNiagara(4).SetUIActive(false);
		this.NoCircleAttachView = new NoCircleAttachView<TimeOfDaySecondItemSt, TimeOfDaySecondCircleAttachItem>(item.GetOwner() as AUIBaseActor, false);
		NoCircleAttachView<TimeOfDaySecondItemSt, TimeOfDaySecondCircleAttachItem> noCircleAttachView = this.NoCircleAttachView;
		if (noCircleAttachView != null)
		{
			noCircleAttachView.SetControllerItem(item2);
		}
		NoCircleAttachView<TimeOfDaySecondItemSt, TimeOfDaySecondCircleAttachItem> noCircleAttachView2 = this.NoCircleAttachView;
		if (noCircleAttachView2 != null)
		{
			noCircleAttachView2.SetIfNeedFakeItem(true);
		}
		this.NoCircleAttachView.CreateItems(base.GetItem(5).GetOwner() as AUIBaseActor, 0f, new Func<AActor, int, int, TimeOfDaySecondCircleAttachItem>(this.CreateNoCircleAttachItem), EAttachDirection.Horizontal);
		base.GetItem(5).SetUIActive(false);
		this.RefreshTimerText();
		this.ReloadScrollView();
		this.TimerId = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.OnTimer), (float)this.TIMEGAP, 1f, null, null, true);
	}

	// Token: 0x06016529 RID: 91433 RVA: 0x0062F2E7 File Offset: 0x0062D4E7
	private TimeOfDaySecondToggleItem CreateToggleItem()
	{
		return new TimeOfDaySecondToggleItem();
	}

	// Token: 0x0601652A RID: 91434 RVA: 0x0062F2EE File Offset: 0x0062D4EE
	private TimeOfDaySecondCircleAttachItem CreateNoCircleAttachItem(AActor actor, int index, int showNum)
	{
		return new TimeOfDaySecondCircleAttachItem(actor);
	}

	// Token: 0x0601652B RID: 91435 RVA: 0x0062F2F8 File Offset: 0x0062D4F8
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<TimeOfDaySecondCircleAttachItem>(EEventName.ClickTimeItem, new Action<TimeOfDaySecondCircleAttachItem>(this.OnClickTimeItem));
		Singleton<EventSystem>.Instance.Add<double, double, Action>(EEventName.AdjustTimeInAnim, new Action<double, double, Action>(this.OnAdjustTimeInAnim));
		Singleton<EventSystem>.Instance.Add(EEventName.OnSelectTimeItem, new Action(this.OnSelectTimeItem));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnSelectTimePreset, new Action<int>(this.OnSelectChange));
		Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0601652C RID: 91436 RVA: 0x0062F390 File Offset: 0x0062D590
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove<TimeOfDaySecondCircleAttachItem>(EEventName.ClickTimeItem, new Action<TimeOfDaySecondCircleAttachItem>(this.OnClickTimeItem));
		Singleton<EventSystem>.Instance.Remove<double, double, Action>(EEventName.AdjustTimeInAnim, new Action<double, double, Action>(this.OnAdjustTimeInAnim));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSelectTimeItem, new Action(this.OnSelectTimeItem));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnSelectTimePreset, new Action<int>(this.OnSelectChange));
		Singleton<EventSystem>.Instance.Remove<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
	}

	// Token: 0x0601652D RID: 91437 RVA: 0x0062F428 File Offset: 0x0062D628
	protected override void OnAfterShow()
	{
		if (this.OpenParam == null)
		{
			return;
		}
		ITimeOfDaySecondViewParam timeOfDaySecondViewParam = (ITimeOfDaySecondViewParam)this.OpenParam;
		this.OnAdjustTimeInAnim(ModelBase<TimeOfDayModel>.Instance.GameTime.Second, timeOfDaySecondViewParam.SetTime, null);
	}

	// Token: 0x0601652E RID: 91438 RVA: 0x0062F466 File Offset: 0x0062D666
	private void OnClickTimeItem(TimeOfDaySecondCircleAttachItem item)
	{
		if (this.NoCircleAttachView.IsVelocityMoveState())
		{
			return;
		}
		this.NoCircleAttachView.AttachToIndex(item.GetCurrentShowItemIndex(), false);
	}

	// Token: 0x0601652F RID: 91439 RVA: 0x0062F488 File Offset: 0x0062D688
	private void OnSelectTimeItem()
	{
		this.RefreshDropComponent();
	}

	// Token: 0x06016530 RID: 91440 RVA: 0x0062F490 File Offset: 0x0062D690
	private void OnCloseView(EUiViewName viewName, int viewId)
	{
		if (viewName == EUiViewName.TimeOfDayLoadingView)
		{
			ControllerBase<TimeOfDayController>.Instance.SetUiAnimFlag(false);
			UUINiagara uiNiagara = base.GetUiNiagara(4);
			if (uiNiagara != null)
			{
				uiNiagara.ActivateSystem(true);
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.DestroyAllUiCameraAnimationHandles);
			if (this.CurrentAdjustFinishCallback != null)
			{
				this.CurrentAdjustFinishCallback();
				this.CurrentAdjustFinishCallback = null;
			}
		}
	}

	// Token: 0x06016531 RID: 91441 RVA: 0x0062F4F4 File Offset: 0x0062D6F4
	private void OnSelectChange(int inSelectIndex)
	{
		if (inSelectIndex >= 0)
		{
			TimeOfDaySecondItemSt currentSelectTimeItemSt = ModelBase<TimeOfDayModel>.Instance.CurrentSelectTimeItemSt;
			if (currentSelectTimeItemSt == null || currentSelectTimeItemSt.ChangeDayIndex != inSelectIndex)
			{
				this.GenericLayout.SelectGridProxy(inSelectIndex, false);
				int num = 43200;
				for (int i = 0; i < this.CurrentShowItem.Length; i++)
				{
					TimeOfDaySecondItemSt timeOfDaySecondItemSt = this.CurrentShowItem[i];
					if (timeOfDaySecondItemSt.ChangeDayIndex == inSelectIndex && (inSelectIndex == 0 || timeOfDaySecondItemSt.SetTime == num))
					{
						ModelBase<TimeOfDayModel>.Instance.CurrentSelectTimeItemSt = timeOfDaySecondItemSt;
						break;
					}
				}
				this.NoCircleAttachView.AttachToIndex(ModelBase<TimeOfDayModel>.Instance.CurrentSelectTimeItemSt.Id, true);
				for (int j = -3; j < 3; j++)
				{
					TimeOfDaySecondCircleAttachItem itemByShowIndex = this.NoCircleAttachView.GetItemByShowIndex(j);
					if (itemByShowIndex != null)
					{
						itemByShowIndex.GetRootItem().SetHierarchyIndex(j + 3);
					}
				}
				(base.GetItem(7).GetOwner().GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController).Play("", -1, false);
				return;
			}
		}
	}

	// Token: 0x06016532 RID: 91442 RVA: 0x0062F5E8 File Offset: 0x0062D7E8
	private void RefreshDropComponent()
	{
		TimeOfDaySecondItemSt currentSelectTimeItemSt = ModelBase<TimeOfDayModel>.Instance.CurrentSelectTimeItemSt;
		this.GenericLayout.SelectGridProxy(currentSelectTimeItemSt.ChangeDayIndex, false);
	}

	// Token: 0x06016533 RID: 91443 RVA: 0x0062F614 File Offset: 0x0062D814
	private void ReloadScrollView()
	{
		this.CurrentShowItem = ModelBase<TimeOfDayModel>.Instance.GetTimeOfDayShowData();
		TimeOfDaySecondItemSt[] currentShowItem = this.CurrentShowItem;
		this.NoCircleAttachView.ReloadView(currentShowItem.Length, currentShowItem, 0);
		for (int i = -3; i < 3; i++)
		{
			TimeOfDaySecondCircleAttachItem itemByShowIndex = this.NoCircleAttachView.GetItemByShowIndex(i);
			if (itemByShowIndex != null)
			{
				itemByShowIndex.GetRootItem().SetHierarchyIndex(i + 3);
			}
		}
	}

	// Token: 0x06016534 RID: 91444 RVA: 0x0062F674 File Offset: 0x0062D874
	private void OnTimer(float deltaTime)
	{
		this.RefreshTimerText();
	}

	// Token: 0x06016535 RID: 91445 RVA: 0x0062F67C File Offset: 0x0062D87C
	protected override void OnTick(float deltaTime)
	{
		this.ShowEffectByExhibitionViewMoveState();
	}

	// Token: 0x06016536 RID: 91446 RVA: 0x0062F684 File Offset: 0x0062D884
	private void ShowEffectByExhibitionViewMoveState()
	{
		UUINiagara uiNiagara = base.GetUiNiagara(4);
		if (this.NoCircleAttachView != null)
		{
			if (!this.NoCircleAttachView.MovingState())
			{
				if (!uiNiagara.IsUIActiveSelf())
				{
					base.GetUiNiagara(4).SetUIActive(true);
					return;
				}
			}
			else if (uiNiagara.IsUIActiveSelf())
			{
				base.GetUiNiagara(4).SetUIActive(false);
				return;
			}
		}
		else if (uiNiagara.IsUIActiveSelf())
		{
			base.GetUiNiagara(4).SetUIActive(false);
		}
	}

	// Token: 0x06016537 RID: 91447 RVA: 0x0062F6F0 File Offset: 0x0062D8F0
	private void RefreshTimerText()
	{
		string hourMinuteString = ModelBase<TimeOfDayModel>.Instance.GameTime.HourMinuteString;
		base.GetText(1).SetText(hourMinuteString, true);
	}

	// Token: 0x06016538 RID: 91448 RVA: 0x0062F71C File Offset: 0x0062D91C
	protected override void OnBeforeDestroy()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.TimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerId);
		}
		if (TimerSystem.GameplayTimeInstance.Has(this.RefreshTimeHandle))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimeHandle);
		}
		TimeOfDayAnimController.CallBack = delegate()
		{
		};
		ControllerBase<TimeOfDayController>.Instance.SetUiAnimFlag(false);
		Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(false, "");
		ControllerBase<TimeOfDayController>.Instance.ResumeTimeScale(true);
		if (this.CurrentAdjustFinishCallback != null)
		{
			this.CurrentAdjustFinishCallback();
			this.CurrentAdjustFinishCallback = null;
		}
		TimeOfDaySecondCircleAttachItem.MiddleOffsetCurve = null;
		this.NoCircleAttachView.Clear();
		GenericLayout<TimeOfDaySecondToggleItem, DaySelectPreset> genericLayout = this.GenericLayout;
		if (genericLayout == null)
		{
			return;
		}
		genericLayout.ClearChildren();
	}

	// Token: 0x06016539 RID: 91449 RVA: 0x0062F7F4 File Offset: 0x0062D9F4
	private void OnClickBackBtn()
	{
		base.CloseMe(null);
	}

	// Token: 0x0601653A RID: 91450 RVA: 0x0062F7FD File Offset: 0x0062D9FD
	private void OnClickConfirmBtn()
	{
		this.OnAdjustTimeInAnim(ModelBase<TimeOfDayModel>.Instance.GameTime.Second, (double)ModelBase<TimeOfDayModel>.Instance.CurrentSelectTimeItemSt.SetTime, null);
	}

	// Token: 0x0601653B RID: 91451 RVA: 0x0062F828 File Offset: 0x0062DA28
	[NullableContext(2)]
	private void OnAdjustTimeInAnim(double startSecond, double setSecond, Action callback = null)
	{
		double setSecond2 = (setSecond - startSecond < 1800.0) ? (setSecond + 86400.0) : setSecond;
		this.CurrentAdjustFinishCallback = callback;
		uint changeDayNum = this.GetChangeDayNum();
		ControllerBase<TimeOfDayController>.Instance.SetUiAnimFlag(true);
		ControllerBase<TimeOfDayController>.Instance.AdjustTime(setSecond, SceneDateUpdateReason.PlayerOperate, changeDayNum, true);
		this.RefreshTimeHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.ReloadScrollView();
			this.RefreshTimeHandle = null;
		}, 1000f, null, null, true, 1f);
		this.PlayAnimation(startSecond, setSecond2, delegate
		{
		});
	}

	// Token: 0x0601653C RID: 91452 RVA: 0x0062F8C9 File Offset: 0x0062DAC9
	private uint GetChangeDayNum()
	{
		return (uint)ModelBase<TimeOfDayModel>.Instance.CurrentSelectTimeItemSt.ChangeDayIndex;
	}

	// Token: 0x0601653D RID: 91453 RVA: 0x0062F8DA File Offset: 0x0062DADA
	private void PlayAnimation(double startSecond, double setSecond, Action callback)
	{
		TimeOfDayAnimController.PlayTimeAnimation(startSecond, setSecond, callback);
	}

	// Token: 0x0601653E RID: 91454 RVA: 0x0062F8E4 File Offset: 0x0062DAE4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		double num = Convert.ToDouble(configParams[0]);
		if (num != 0.0)
		{
			int? num2 = null;
			int num3 = 0;
			for (;;)
			{
				int num4 = num3;
				TimeOfDaySecondItemSt[] currentShowItem = this.CurrentShowItem;
				if (num4 >= ((currentShowItem != null) ? currentShowItem.Length : 0))
				{
					goto IL_55;
				}
				if ((double)this.CurrentShowItem[num3].SetTime == num)
				{
					break;
				}
				num3++;
			}
			num2 = new int?(num3);
			IL_55:
			if (num2 != null && num2.Value >= 0)
			{
				NoCircleAttachView<TimeOfDaySecondItemSt, TimeOfDaySecondCircleAttachItem> noCircleAttachView = this.NoCircleAttachView;
				if (noCircleAttachView != null)
				{
					noCircleAttachView.AttachToIndex(num2.Value, true);
				}
				NoCircleAttachView<TimeOfDaySecondItemSt, TimeOfDaySecondCircleAttachItem> noCircleAttachView2 = this.NoCircleAttachView;
				UUIItem uuiitem;
				if (noCircleAttachView2 == null)
				{
					uuiitem = null;
				}
				else
				{
					TimeOfDaySecondCircleAttachItem itemByShowIndex = noCircleAttachView2.GetItemByShowIndex(num2.Value);
					uuiitem = ((itemByShowIndex != null) ? itemByShowIndex.GetRootItem() : null);
				}
				UUIItem uuiitem2 = uuiitem;
				if (uuiitem2 != null)
				{
					return new UUIItem[]
					{
						uuiitem2,
						uuiitem2
					};
				}
			}
		}
		return null;
	}

	// Token: 0x0400ACEB RID: 44267
	private int TIMEGAP = 1000;

	// Token: 0x0400ACEC RID: 44268
	[Nullable(2)]
	private TimerHandle TimerId;

	// Token: 0x0400ACED RID: 44269
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private NoCircleAttachView<TimeOfDaySecondItemSt, TimeOfDaySecondCircleAttachItem> NoCircleAttachView;

	// Token: 0x0400ACEE RID: 44270
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TimeOfDaySecondItemSt[] CurrentShowItem;

	// Token: 0x0400ACEF RID: 44271
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<TimeOfDaySecondToggleItem, DaySelectPreset> GenericLayout;

	// Token: 0x0400ACF0 RID: 44272
	[Nullable(2)]
	private TimerHandle RefreshTimeHandle;

	// Token: 0x0400ACF1 RID: 44273
	[Nullable(2)]
	private Action CurrentAdjustFinishCallback;

	// Token: 0x02008EB8 RID: 36536
	[NullableContext(0)]
	public enum ETimeOfDayComponent
	{
		// Token: 0x0402FF64 RID: 196452
		TimeImg,
		// Token: 0x0402FF65 RID: 196453
		CurrentTimeText,
		// Token: 0x0402FF66 RID: 196454
		BackBtn,
		// Token: 0x0402FF67 RID: 196455
		ConfirmBtn,
		// Token: 0x0402FF68 RID: 196456
		Effect,
		// Token: 0x0402FF69 RID: 196457
		ScrollerItem,
		// Token: 0x0402FF6A RID: 196458
		DragView,
		// Token: 0x0402FF6B RID: 196459
		DragViewContent,
		// Token: 0x0402FF6C RID: 196460
		HorizontalLayout,
		// Token: 0x0402FF6D RID: 196461
		ToggleItem
	}
}
