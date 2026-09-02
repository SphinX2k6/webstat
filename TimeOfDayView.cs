using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.UiCameraAnimation.Struct;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiCameraAnimation;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BBB RID: 11195
[NullableContext(1)]
[Nullable(0)]
public class TimeOfDayView : UiTickViewBase
{
	// Token: 0x060164D3 RID: 91347 RVA: 0x0062CF1C File Offset: 0x0062B11C
	public TimeOfDayView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060164D4 RID: 91348 RVA: 0x0062CF98 File Offset: 0x0062B198
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(16, typeof(UUITexture)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIText)),
			new ValueTuple<int, Type>(22, typeof(UUIInteractionGroup)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnConfirm)),
			new ValueTuple<int, Delegate>(15, new Action(this.OnClickBtnClose))
		};
	}

	// Token: 0x060164D5 RID: 91349 RVA: 0x0062D23C File Offset: 0x0062B43C
	protected override void OnStart()
	{
		this.DayStateUiItemMap[ETodDayState.One] = new TimeOfDayView.UiItemSwitcher(base.GetItem(6), base.GetItem(7));
		this.DayStateUiItemMap[ETodDayState.Two] = new TimeOfDayView.UiItemSwitcher(base.GetItem(8), base.GetItem(9));
		this.DayStateUiItemMap[ETodDayState.Three] = new TimeOfDayView.UiItemSwitcher(base.GetItem(10), base.GetItem(11));
		this.DayStateUiItemMap[ETodDayState.Four] = new TimeOfDayView.UiItemSwitcher(base.GetItem(12), base.GetItem(13));
		FVector2D uiitemPositionInViewPort = ULGUIBPLibrary.GetUIItemPositionInViewPort(GlobalData.World, base.GetItem(17), false);
		this.DragCenterPoint = global::Vector.Create((double)uiitemPositionInViewPort.X, (double)uiitemPositionInViewPort.Y, 0.0);
		this.TimeAdjustingClock = new TimeOfDayView.TodTimeAdjustingClock();
		this.TimeAdjustingAnimation = new TodTimeAdjustingAnimation(ConfigBase<TimeOfDayConfig>.Instance.GetMaxV(), ConfigBase<TimeOfDayConfig>.Instance.GetA(), new Action<double>(this.OnAnimation), new Action(this.OnAnimationFinished));
		this.ResetView();
		this.UpdateTime();
	}

	// Token: 0x060164D6 RID: 91350 RVA: 0x0062D34E File Offset: 0x0062B54E
	protected override void OnBeforeDestroy()
	{
		this.TimeAdjustingClock.Reset();
		this.TimeAdjustingAnimation.Stop();
		this.ClearStartAnimationTimer();
	}

	// Token: 0x060164D7 RID: 91351 RVA: 0x0062D36C File Offset: 0x0062B56C
	protected override void OnTick(float deltaTime)
	{
		TodTimeAdjustingAnimation timeAdjustingAnimation = this.TimeAdjustingAnimation;
		if (timeAdjustingAnimation == null)
		{
			return;
		}
		timeAdjustingAnimation.Tick((double)deltaTime);
	}

	// Token: 0x060164D8 RID: 91352 RVA: 0x0062D380 File Offset: 0x0062B580
	protected override void OnAddEventListener()
	{
		UUIDraggableComponent draggable = base.GetDraggable(14);
		draggable.OnPointerBeginDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
		{
			this.OnClockPointerPressed(eventData);
		});
		draggable.OnPointerDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
		{
			this.OnClockPointerDragCallBack(eventData);
		});
		draggable.OnPointerEndDragCallBack.Bind(delegate(ULGUIPointerEventData eventData)
		{
			this.OnClockPointerReleaseCallBack(eventData);
		});
		draggable.OnUIDimensionsChangedCallBack.Bind(new Action<bool, bool>(this.OnUiDimensionsChangedCallBack));
		Singleton<EventSystem>.Instance.Add(EEventName.TodTimeChange, new Action(this.UpdateTime));
	}

	// Token: 0x060164D9 RID: 91353 RVA: 0x0062D40C File Offset: 0x0062B60C
	protected override void OnRemoveEventListener()
	{
		UUIDraggableComponent draggable = base.GetDraggable(14);
		draggable.OnPointerBeginDragCallBack.Unbind();
		draggable.OnPointerDragCallBack.Unbind();
		draggable.OnPointerEndDragCallBack.Unbind();
		draggable.OnUIDimensionsChangedCallBack.Unbind();
		Singleton<EventSystem>.Instance.Remove(EEventName.TodTimeChange, new Action(this.UpdateTime));
	}

	// Token: 0x060164DA RID: 91354 RVA: 0x0062D468 File Offset: 0x0062B668
	private void ClearStartAnimationTimer()
	{
		if (TimerSystem.GameplayTimeInstance.Has(this.StartAnimationTimerId))
		{
			TimerSystem.GameplayTimeInstance.Remove(this.StartAnimationTimerId);
		}
		this.StartAnimationTimerId = null;
	}

	// Token: 0x060164DB RID: 91355 RVA: 0x0062D494 File Offset: 0x0062B694
	private void ResetView()
	{
		base.GetTexture(2).SetFillAmount(0f);
		base.GetTexture(3).SetFillAmount(0f);
		base.GetItem(18).SetUIActive(true);
		base.GetItem(19).SetUIActive(true);
		base.GetItem(23).SetUIActive(true);
		base.GetItem(24).SetUIActive(true);
		this.SetBtnConfirmState(false);
		base.GetText(5).ShowTextNew(this.TimeAdjustingClock.DayTextId);
	}

	// Token: 0x060164DC RID: 91356 RVA: 0x0062D51C File Offset: 0x0062B71C
	private void UpdateTime()
	{
		if (this.TimeAdjustingClock.IsAdjusting)
		{
			return;
		}
		string hourMinuteString = ModelBase<TimeOfDayModel>.Instance.GameTime.HourMinuteString;
		base.GetText(0).SetText(hourMinuteString, true);
		base.GetText(4).SetText(hourMinuteString, true);
		ETodDayState dayState = ModelBase<TimeOfDayModel>.Instance.GameTime.DayState;
		foreach (KeyValuePair<ETodDayState, TimeOfDayView.UiItemSwitcher> keyValuePair in this.DayStateUiItemMap)
		{
			keyValuePair.Value.SwitchTo(keyValuePair.Key == dayState);
		}
		this.DragPointerRotator.Yaw = (float)this.GetPointerAngle(ModelBase<TimeOfDayModel>.Instance.GameTime.Second);
		UUIItem texture = base.GetTexture(16);
		FRotator frotator = this.DragPointerRotator.ToUeRotator();
		texture.SetUIRelativeRotation(frotator);
		UUIItem item = base.GetItem(17);
		frotator = this.DragPointerRotator.ToUeRotator();
		item.SetUIRelativeRotation(frotator);
		UUIItem item2 = base.GetItem(25);
		frotator = this.DragPointerRotator.ToUeRotator();
		item2.SetUIRelativeRotation(frotator);
		UUIItem item3 = base.GetItem(18);
		frotator = this.TextureRotator.ToUeRotator();
		item3.SetUIRelativeRotation(frotator);
		UUIItem item4 = base.GetItem(19);
		frotator = this.TextureRotator.ToUeRotator();
		item4.SetUIRelativeRotation(frotator);
	}

	// Token: 0x060164DD RID: 91357 RVA: 0x0062D678 File Offset: 0x0062B878
	private void OnClockPointerPressed(ULGUIPointerEventData eventData)
	{
		if (this.TimeAdjustingClock.IsAdjusting)
		{
			return;
		}
		this.TimeAdjustingClock.Start();
		global::Vector firstDragPoint = this.FirstDragPoint;
		FVector pointerPosition = eventData.pointerPosition;
		FVectorDouble fvectorDouble = pointerPosition;
		firstDragPoint.DeepCopy(fvectorDouble);
		global::Vector lastDragPoint = this.LastDragPoint;
		pointerPosition = eventData.pointerPosition;
		fvectorDouble = pointerPosition;
		lastDragPoint.DeepCopy(fvectorDouble);
		this.TextureRotator.Yaw = (float)this.GetPointerAngle(this.TimeAdjustingClock.StartSecond);
		UUIItem item = base.GetItem(19);
		FRotator frotator = this.TextureRotator.ToUeRotator();
		item.SetUIRelativeRotation(frotator);
		UUIItem item2 = base.GetItem(18);
		frotator = this.TextureRotator.ToUeRotator();
		item2.SetUIRelativeRotation(frotator);
		base.GetTexture(2).SetFillDirectionFlip(false);
		base.GetTexture(3).SetFillDirectionFlip(false);
	}

	// Token: 0x060164DE RID: 91358 RVA: 0x0062D744 File Offset: 0x0062B944
	private void OnClockPointerDragCallBack(ULGUIPointerEventData eventData)
	{
		if (this.LastDragPoint.IsZero() || this.FirstDragPoint.IsZero())
		{
			global::Vector lastDragPoint = this.LastDragPoint;
			FVector pointerPosition = eventData.pointerPosition;
			FVectorDouble fvectorDouble = pointerPosition;
			lastDragPoint.DeepCopy(fvectorDouble);
			global::Vector firstDragPoint = this.FirstDragPoint;
			pointerPosition = eventData.pointerPosition;
			fvectorDouble = pointerPosition;
			firstDragPoint.DeepCopy(fvectorDouble);
			return;
		}
		global::Vector vector = global::Vector.Create(eventData.pointerPosition);
		bool isClockwise = this.JudgePointsClockwise(this.LastDragPoint, vector);
		double pointsAngle = this.GetPointsAngle(this.LastDragPoint, vector);
		double secondByAngle = this.GetSecondByAngle(pointsAngle);
		ValueTuple<bool, double> valueTuple = this.TimeAdjustingClock.AdjustToSecond(secondByAngle, isClockwise);
		if (!valueTuple.Item1)
		{
			if (valueTuple.Item2 != 0.0)
			{
				this.TimeAdjustingClock.AdjustToSecond(valueTuple.Item2, isClockwise);
				this.LastDragPoint.DeepCopy(this.FirstDragPoint);
			}
		}
		else
		{
			this.LastDragPoint.DeepCopy(vector);
		}
		this.RefreshAdjustingView();
	}

	// Token: 0x060164DF RID: 91359 RVA: 0x0062D840 File Offset: 0x0062BA40
	private void OnClockPointerReleaseCallBack(ULGUIPointerEventData eventData)
	{
		this.LastDragPoint.DeepCopy(global::Vector.ZeroVectorProxy);
		this.FirstDragPoint.DeepCopy(global::Vector.ZeroVectorProxy);
	}

	// Token: 0x060164E0 RID: 91360 RVA: 0x0062D864 File Offset: 0x0062BA64
	private void OnUiDimensionsChangedCallBack(bool positionChanged, bool sizeChanged)
	{
		if (!sizeChanged)
		{
			return;
		}
		this.FirstDragPoint.DeepCopy(global::Vector.ZeroVectorProxy);
		this.LastDragPoint.DeepCopy(global::Vector.ZeroVectorProxy);
		FVector2D uiitemPositionInViewPort = ULGUIBPLibrary.GetUIItemPositionInViewPort(GlobalData.World, base.GetItem(17), false);
		this.DragCenterPoint = global::Vector.Create((double)uiitemPositionInViewPort.X, (double)uiitemPositionInViewPort.Y, 0.0);
	}

	// Token: 0x060164E1 RID: 91361 RVA: 0x0062D8CC File Offset: 0x0062BACC
	private void OnClickBtnConfirm()
	{
		ControllerBase<TimeOfDayController>.Instance.AdjustTime(this.TimeAdjustingClock.ToSecond, SceneDateUpdateReason.PlayerOperate, 0U, true);
		ControllerBase<TimeOfDayController>.Instance.PauseTime();
		Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(true, "");
		Singleton<Log>.Instance.Info(ELogModule.Test, ELogAuthor.YZY, "OnClickBtnConfirm:" + ModelBase<CameraModel>.Instance.MainModel.CurrentCameraActor.GetName(), default(ReadOnlySpan<ValueTuple<string, object>>));
		int? intConfig = ConfigCommonParamById.GetIntConfig("TimeCameraSettingName");
		int? intConfig2 = ConfigCommonParamById.GetIntConfig("TimeCameraBlendDataName");
		this.CameraHandleData = Singleton<UiCameraAnimationManager>.Instance.PlayCameraAnimationFromCurrent(intConfig.ToString(), intConfig2.ToString());
		SUiCameraAnimationSettings uiCameraAnimationConfig = ConfigBase<UiCameraAnimationConfig>.Instance.GetUiCameraAnimationConfig(intConfig.ToString());
		this.ClearStartAnimationTimer();
		this.StartAnimationTimerId = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.OnAnimationBegin();
			this.TimeAdjustingAnimation.Play(this.TimeAdjustingClock.StartSecond, this.TimeAdjustingClock.ToSecond);
		}, 1000f * uiCameraAnimationConfig.BlendInTime, null, null, true, 1f);
	}

	// Token: 0x060164E2 RID: 91362 RVA: 0x0062D9CE File Offset: 0x0062BBCE
	private void OnClickBtnClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x060164E3 RID: 91363 RVA: 0x0062D9D8 File Offset: 0x0062BBD8
	private void OnAnimationBegin()
	{
		this.TextureRotator.Yaw = (float)this.GetPointerAngle(this.TimeAdjustingClock.ToSecond);
		base.GetTexture(2).SetFillDirectionFlip(true);
		base.GetTexture(3).SetFillDirectionFlip(true);
		UUIItem item = base.GetItem(18);
		FRotator frotator = this.TextureRotator.ToUeRotator();
		item.SetUIRelativeRotation(frotator);
		UUIItem item2 = base.GetItem(19);
		frotator = this.TextureRotator.ToUeRotator();
		item2.SetUIRelativeRotation(frotator);
		base.GetItem(23).SetUIActive(false);
		base.GetItem(24).SetUIActive(false);
	}

	// Token: 0x060164E4 RID: 91364 RVA: 0x0062DA70 File Offset: 0x0062BC70
	private void OnAnimation(double second)
	{
		this.TimeAdjustingClock.AdjustStartSecond(second);
		double startSecondOneDay = this.TimeAdjustingClock.StartSecondOneDay;
		if (this.TimeAdjustingClock.IsAdjustingMoreThanOneDay)
		{
			base.GetTexture(2).SetFillAmount(1f);
			double num = this.TimeAdjustingClock.IsAdjustingToMaxLimit ? 1.0 : this.TimeAdjustingClock.DeltaDayOneDay;
			base.GetTexture(3).SetFillAmount((float)num);
		}
		else
		{
			base.GetTexture(2).SetFillAmount((float)this.TimeAdjustingClock.DeltaDayOneDay);
			base.GetTexture(3).SetFillAmount(0f);
		}
		ETodDayState etodDayState = TodDayTime.ConvertToDayState(startSecondOneDay);
		foreach (KeyValuePair<ETodDayState, TimeOfDayView.UiItemSwitcher> keyValuePair in this.DayStateUiItemMap)
		{
			keyValuePair.Value.SwitchTo(keyValuePair.Key == etodDayState);
		}
		this.DragPointerRotator.Yaw = (float)this.GetPointerAngle(startSecondOneDay);
		UUIItem texture = base.GetTexture(16);
		FRotator frotator = this.DragPointerRotator.ToUeRotator();
		texture.SetUIRelativeRotation(frotator);
		base.GetText(0).SetText(TodDayTime.ConvertToHourMinuteString(startSecondOneDay), true);
		ControllerBase<TimeOfDayController>.Instance.SyncGlobalGameTime(TodDayTime.ConvertToOneDaySecond(second), false);
	}

	// Token: 0x060164E5 RID: 91365 RVA: 0x0062DBC0 File Offset: 0x0062BDC0
	private void OnAnimationFinished()
	{
		Singleton<UiLayer>.Instance.SetShowNormalMaskLayer(false, "");
		int? intConfig = ConfigCommonParamById.GetIntConfig("TimeCameraBlendDataName");
		Singleton<UiCameraAnimationManager>.Instance.PlayCameraAnimationFromCurrent(this.CameraHandleData.GetHandleName(), intConfig.ToString());
		ControllerBase<TimeOfDayController>.Instance.ResumeTimeScale(true);
		this.TimeAdjustingClock.Reset();
		this.ResetView();
	}

	// Token: 0x060164E6 RID: 91366 RVA: 0x0062DC28 File Offset: 0x0062BE28
	private void RefreshAdjustingView()
	{
		if (this.TimeAdjustingClock.IsAdjustingMoreThanOneDay)
		{
			base.GetTexture(2).SetFillAmount(1f);
			double num = this.TimeAdjustingClock.IsAdjustingToMaxLimit ? 1.0 : this.TimeAdjustingClock.DeltaDayOneDay;
			base.GetTexture(3).SetFillAmount((float)num);
		}
		else
		{
			base.GetTexture(2).SetFillAmount((float)this.TimeAdjustingClock.DeltaDayOneDay);
			base.GetTexture(3).SetFillAmount(0f);
		}
		base.GetText(5).ShowTextNew(this.TimeAdjustingClock.DayTextId);
		this.SetBtnConfirmState(this.TimeAdjustingClock.IsAdjustingMoreThanMinLimit);
		this.DragPointerRotator.Yaw = (float)this.GetPointerAngle(this.TimeAdjustingClock.ToSecondOneDay);
		UUIItem item = base.GetItem(17);
		FRotator frotator = this.DragPointerRotator.ToUeRotator();
		item.SetUIRelativeRotation(frotator);
		UUIItem item2 = base.GetItem(25);
		frotator = this.DragPointerRotator.ToUeRotator();
		item2.SetUIRelativeRotation(frotator);
		base.GetText(4).SetText(TodDayTime.ConvertToHourMinuteString(this.TimeAdjustingClock.ToSecondOneDay), true);
	}

	// Token: 0x060164E7 RID: 91367 RVA: 0x0062DD48 File Offset: 0x0062BF48
	private void SetBtnConfirmState(bool state)
	{
		base.GetInteractionGroup(22).SetInteractable(state);
		string id = state ? "TimeOfDayConfirmTextOn" : "TimeOfDayConfirmTextOff";
		base.GetText(21).ShowTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById(id));
	}

	// Token: 0x060164E8 RID: 91368 RVA: 0x0062DD8B File Offset: 0x0062BF8B
	private double GetPointerAngle(double second)
	{
		return -(TodDayTime.ConvertToOneDaySecond(second) / 86400.0) * 360.0;
	}

	// Token: 0x060164E9 RID: 91369 RVA: 0x0062DDA8 File Offset: 0x0062BFA8
	private double GetSecondByAngle(double angle)
	{
		return angle / 360.0 * 86400.0;
	}

	// Token: 0x060164EA RID: 91370 RVA: 0x0062DDC0 File Offset: 0x0062BFC0
	private double GetPointsAngle(global::Vector point1, global::Vector point2)
	{
		point1.Subtraction(this.DragCenterPoint, this.TempVector1);
		point2.Subtraction(this.DragCenterPoint, this.TempVector2);
		double num = Math.Acos(this.TempVector1.CosineAngle2D(this.TempVector2, 9.999999747378752E-05)) * 57.295780181884766;
		if (point1.X < 0.0)
		{
			num = 360.0 - num;
		}
		return num;
	}

	// Token: 0x060164EB RID: 91371 RVA: 0x0062DE3C File Offset: 0x0062C03C
	private bool JudgePointsClockwise(global::Vector from, global::Vector to)
	{
		from.Subtraction(this.DragCenterPoint, this.TempVector1);
		to.Subtraction(this.DragCenterPoint, this.TempVector2);
		global::Vector.CrossProduct(this.TempVector1, this.TempVector2, this.TempCrossProduct);
		return this.TempCrossProduct.Z > 0.0;
	}

	// Token: 0x0400ACA0 RID: 44192
	private readonly global::Vector FirstDragPoint = global::Vector.Create();

	// Token: 0x0400ACA1 RID: 44193
	private readonly global::Vector LastDragPoint = global::Vector.Create();

	// Token: 0x0400ACA2 RID: 44194
	private readonly global::Vector TempVector1 = global::Vector.Create();

	// Token: 0x0400ACA3 RID: 44195
	private readonly global::Vector TempVector2 = global::Vector.Create();

	// Token: 0x0400ACA4 RID: 44196
	private readonly global::Vector TempCrossProduct = global::Vector.Create();

	// Token: 0x0400ACA5 RID: 44197
	private readonly global::Rotator DragPointerRotator = global::Rotator.Create();

	// Token: 0x0400ACA6 RID: 44198
	private readonly global::Rotator TextureRotator = global::Rotator.Create(0f, 0f, 180f);

	// Token: 0x0400ACA7 RID: 44199
	private readonly Dictionary<ETodDayState, TimeOfDayView.UiItemSwitcher> DayStateUiItemMap = new Dictionary<ETodDayState, TimeOfDayView.UiItemSwitcher>();

	// Token: 0x0400ACA8 RID: 44200
	[Nullable(2)]
	private global::Vector DragCenterPoint;

	// Token: 0x0400ACA9 RID: 44201
	[Nullable(2)]
	private TimeOfDayView.TodTimeAdjustingClock TimeAdjustingClock;

	// Token: 0x0400ACAA RID: 44202
	[Nullable(2)]
	private TodTimeAdjustingAnimation TimeAdjustingAnimation;

	// Token: 0x0400ACAB RID: 44203
	[Nullable(2)]
	private TimerHandle StartAnimationTimerId;

	// Token: 0x0400ACAC RID: 44204
	[Nullable(2)]
	private UiCameraHandleData CameraHandleData;

	// Token: 0x02008EB2 RID: 36530
	[NullableContext(0)]
	private class EChildCom
	{
		// Token: 0x0402FF32 RID: 196402
		public const int TextTime = 0;

		// Token: 0x0402FF33 RID: 196403
		public const int BtnConfirm = 1;

		// Token: 0x0402FF34 RID: 196404
		public const int TextureClockOuter = 2;

		// Token: 0x0402FF35 RID: 196405
		public const int TextureClockInner = 3;

		// Token: 0x0402FF36 RID: 196406
		public const int TextTimeAdjust = 4;

		// Token: 0x0402FF37 RID: 196407
		public const int TextTomorrow = 5;

		// Token: 0x0402FF38 RID: 196408
		public const int PanelMorning1 = 6;

		// Token: 0x0402FF39 RID: 196409
		public const int PanelMorning2 = 7;

		// Token: 0x0402FF3A RID: 196410
		public const int PanelSunset1 = 8;

		// Token: 0x0402FF3B RID: 196411
		public const int PanelSunset2 = 9;

		// Token: 0x0402FF3C RID: 196412
		public const int PanelNight1 = 10;

		// Token: 0x0402FF3D RID: 196413
		public const int PanelNight2 = 11;

		// Token: 0x0402FF3E RID: 196414
		public const int PanelSunrise1 = 12;

		// Token: 0x0402FF3F RID: 196415
		public const int PanelSunrise2 = 13;

		// Token: 0x0402FF40 RID: 196416
		public const int DraggableClock = 14;

		// Token: 0x0402FF41 RID: 196417
		public const int BtnBack = 15;

		// Token: 0x0402FF42 RID: 196418
		public const int TexturePointerShort = 16;

		// Token: 0x0402FF43 RID: 196419
		public const int PanelPointerLong = 17;

		// Token: 0x0402FF44 RID: 196420
		public const int PanelClockOuter = 18;

		// Token: 0x0402FF45 RID: 196421
		public const int PanelClockInner = 19;

		// Token: 0x0402FF46 RID: 196422
		public const int PanelTimeAdjust = 20;

		// Token: 0x0402FF47 RID: 196423
		public const int TextConfirm = 21;

		// Token: 0x0402FF48 RID: 196424
		public const int InteractionConfirm = 22;

		// Token: 0x0402FF49 RID: 196425
		public const int PanelBtnBack = 23;

		// Token: 0x0402FF4A RID: 196426
		public const int PanelBtnConfirm = 24;

		// Token: 0x0402FF4B RID: 196427
		public const int PanelBtnPointerLong = 25;
	}

	// Token: 0x02008EB3 RID: 36531
	[Nullable(0)]
	private class UiItemSwitcher
	{
		// Token: 0x06049BDA RID: 302042 RVA: 0x013FA003 File Offset: 0x013F8203
		public UiItemSwitcher(UUIItem uiItemOff, UUIItem uiItemOn)
		{
			this.UiItemOn = uiItemOn;
			this.UiItemOff = uiItemOff;
		}

		// Token: 0x06049BDB RID: 302043 RVA: 0x013FA019 File Offset: 0x013F8219
		public void SwitchTo(bool state)
		{
			this.UiItemOn.SetUIActive(state);
			this.UiItemOff.SetUIActive(!state);
		}

		// Token: 0x0402FF4C RID: 196428
		private readonly UUIItem UiItemOn;

		// Token: 0x0402FF4D RID: 196429
		private readonly UUIItem UiItemOff;
	}

	// Token: 0x02008EB4 RID: 36532
	[NullableContext(0)]
	private class TodTimeAdjustingClock
	{
		// Token: 0x1700A863 RID: 43107
		// (get) Token: 0x06049BDC RID: 302044 RVA: 0x013FA036 File Offset: 0x013F8236
		public double DeltaSecond
		{
			get
			{
				return this.ToSecond - this.StartSecond;
			}
		}

		// Token: 0x1700A864 RID: 43108
		// (get) Token: 0x06049BDD RID: 302045 RVA: 0x013FA045 File Offset: 0x013F8245
		public double DeltaMinute
		{
			get
			{
				return Math.Floor(this.ToSecond / 60.0) - Math.Floor(this.StartSecond / 60.0);
			}
		}

		// Token: 0x1700A865 RID: 43109
		// (get) Token: 0x06049BDE RID: 302046 RVA: 0x013FA072 File Offset: 0x013F8272
		public double DeltaSecondOneDay
		{
			get
			{
				return TodDayTime.ConvertToOneDaySecond(this.DeltaSecond);
			}
		}

		// Token: 0x1700A866 RID: 43110
		// (get) Token: 0x06049BDF RID: 302047 RVA: 0x013FA07F File Offset: 0x013F827F
		public double DeltaDayOneDay
		{
			get
			{
				return TodDayTime.ConvertToDay(this.DeltaSecondOneDay);
			}
		}

		// Token: 0x1700A867 RID: 43111
		// (get) Token: 0x06049BE0 RID: 302048 RVA: 0x013FA08C File Offset: 0x013F828C
		public double ToSecondOneDay
		{
			get
			{
				return TodDayTime.ConvertToOneDaySecond(this.ToSecond);
			}
		}

		// Token: 0x1700A868 RID: 43112
		// (get) Token: 0x06049BE1 RID: 302049 RVA: 0x013FA099 File Offset: 0x013F8299
		public double StartSecondOneDay
		{
			get
			{
				return TodDayTime.ConvertToOneDaySecond(this.StartSecond);
			}
		}

		// Token: 0x1700A869 RID: 43113
		// (get) Token: 0x06049BE2 RID: 302050 RVA: 0x013FA0A6 File Offset: 0x013F82A6
		public bool IsAdjusting
		{
			get
			{
				return this.StartSecond >= 0.0;
			}
		}

		// Token: 0x1700A86A RID: 43114
		// (get) Token: 0x06049BE3 RID: 302051 RVA: 0x013FA0BC File Offset: 0x013F82BC
		public bool IsTomorrow
		{
			get
			{
				return this.ToSecond >= 86400.0;
			}
		}

		// Token: 0x1700A86B RID: 43115
		// (get) Token: 0x06049BE4 RID: 302052 RVA: 0x013FA0D4 File Offset: 0x013F82D4
		[Nullable(1)]
		public string DayTextId
		{
			[NullableContext(1)]
			get
			{
				int num = (int)Math.Floor(this.ToSecond / 86400.0);
				if (num == 1)
				{
					return ConfigBase<TextConfig>.Instance.GetTextContentIdById("TimeOfDayTomorrow");
				}
				if (num == 2)
				{
					return ConfigBase<TextConfig>.Instance.GetTextContentIdById("TimeOfDayPlusTwoDay");
				}
				return ConfigBase<TextConfig>.Instance.GetTextContentIdById("TimeOfDayToday");
			}
		}

		// Token: 0x1700A86C RID: 43116
		// (get) Token: 0x06049BE5 RID: 302053 RVA: 0x013FA12F File Offset: 0x013F832F
		public bool IsAdjustingMoreThanOneDay
		{
			get
			{
				return this.DeltaSecond >= 86400.0;
			}
		}

		// Token: 0x1700A86D RID: 43117
		// (get) Token: 0x06049BE6 RID: 302054 RVA: 0x013FA145 File Offset: 0x013F8345
		public bool IsAdjustingMoreThanMinLimit
		{
			get
			{
				return this.DeltaMinute >= 30.0;
			}
		}

		// Token: 0x1700A86E RID: 43118
		// (get) Token: 0x06049BE7 RID: 302055 RVA: 0x013FA15B File Offset: 0x013F835B
		public bool IsAdjustingToMaxLimit
		{
			get
			{
				return this.DeltaSecond >= 172800.0;
			}
		}

		// Token: 0x06049BE8 RID: 302056 RVA: 0x013FA171 File Offset: 0x013F8371
		public void Start()
		{
			this.StartSecond = ModelBase<TimeOfDayModel>.Instance.GameTime.Second;
			this.ToSecond = this.StartSecond;
		}

		// Token: 0x06049BE9 RID: 302057 RVA: 0x013FA194 File Offset: 0x013F8394
		public void Reset()
		{
			this.StartSecond = -1.0;
			this.ToSecond = -1.0;
		}

		// Token: 0x06049BEA RID: 302058 RVA: 0x013FA1B4 File Offset: 0x013F83B4
		public ValueTuple<bool, double> AdjustToSecond(double addSecond, bool isClockwise)
		{
			if (addSecond == 0.0 || double.IsNaN(addSecond))
			{
				return new ValueTuple<bool, double>(false, 0.0);
			}
			if (!this.IsAdjusting)
			{
				return new ValueTuple<bool, double>(false, 0.0);
			}
			double num;
			if (isClockwise)
			{
				num = this.ToSecond + addSecond;
				if (num > this.StartSecond + 172800.0)
				{
					return new ValueTuple<bool, double>(false, this.StartSecond + 172800.0 - this.ToSecond);
				}
			}
			else
			{
				num = this.ToSecond - addSecond;
				if (num < this.StartSecond)
				{
					return new ValueTuple<bool, double>(false, this.ToSecond - this.StartSecond);
				}
			}
			this.ToSecond = num;
			return new ValueTuple<bool, double>(true, 0.0);
		}

		// Token: 0x06049BEB RID: 302059 RVA: 0x013FA280 File Offset: 0x013F8480
		public void AdjustStartSecond(double second)
		{
			if (second == 0.0 || double.IsNaN(second))
			{
				return;
			}
			if (!this.IsAdjusting)
			{
				return;
			}
			this.StartSecond = second;
			if (this.StartSecond > this.ToSecond)
			{
				this.StartSecond = this.ToSecond;
			}
		}

		// Token: 0x06049BEC RID: 302060 RVA: 0x013FA2CC File Offset: 0x013F84CC
		public unsafe void DebugPrint()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TimeOfDay;
			ELogAuthor author = ELogAuthor.TL;
			string message = "TodTimeAdjustingClock";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("this.StartSecond", this.StartSecond);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("this.ToSecond", this.ToSecond);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0402FF4E RID: 196430
		public double StartSecond = -1.0;

		// Token: 0x0402FF4F RID: 196431
		public double ToSecond = -1.0;
	}
}
