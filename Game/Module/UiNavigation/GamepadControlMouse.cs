using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C87 RID: 19591
	[NullableContext(1)]
	[Nullable(0)]
	public class GamepadControlMouse
	{
		// Token: 0x1700879B RID: 34715
		// (get) Token: 0x06033107 RID: 209159 RVA: 0x00CC9C04 File Offset: 0x00CC7E04
		private Vector2D TempVector2D
		{
			get
			{
				if (this.InternalTempVector2D == null)
				{
					FVector pointerPosition = this.EventData.pointerPosition;
					this.InternalTempVector2D = new Vector2D((double)pointerPosition.X, (double)pointerPosition.Y);
				}
				return this.InternalTempVector2D;
			}
		}

		// Token: 0x1700879C RID: 34716
		// (get) Token: 0x06033108 RID: 209160 RVA: 0x00CC9C44 File Offset: 0x00CC7E44
		private bool IsGamepadMoving
		{
			get
			{
				return this.GamepadMoveForwardValue != 0f || this.GamepadMoveRightValue != 0f;
			}
		}

		// Token: 0x06033109 RID: 209161 RVA: 0x00CC9C68 File Offset: 0x00CC7E68
		public GamepadControlMouse(UUIItem gamepadItem, UiNavigationViewHandle viewHandle)
		{
			this.GamepadItem = gamepadItem;
			this.GamepadItem.SetAlpha(Singleton<Info>.Instance.IsInGamepad() > false);
			this.SequencePlayer = new LevelSequencePlayer(gamepadItem);
			this.ViewHandle = viewHandle;
			this.EventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
			this.Canvas = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
			this.CanvasScaleFactor = this.Canvas.Canvas.GetCanvasScale();
			this.HalfWidth = Singleton<UiLayer>.Instance.UiRootItem.GetWidth() / 2f;
			this.HalfHeight = Singleton<UiLayer>.Instance.UiRootItem.GetHeight() / 2f;
			FIntPoint viewportSize = Singleton<UiLayer>.Instance.UiRootItem.GetRenderCanvas().GetViewportSize();
			this.ViewPortWidth = (float)viewportSize.X;
			this.ViewPortHeight = (float)viewportSize.Y;
			this.Delegate = global::DelegateUtils.ToManualReleaseDelegate<FLTweenVector2SetterDynamic>(new Action<FVector2D>(this.OnTweenUpdate));
		}

		// Token: 0x0603310A RID: 209162 RVA: 0x00CC9D94 File Offset: 0x00CC7F94
		private Vector2D GetTempVectorInLgui()
		{
			if (this.Canvas == null)
			{
				return this.TempVector2D;
			}
			FVector2D fvector2D = this.ConvertViewportToLguiCanvas(this.TempVector2D.X, this.TempVector2D.Y);
			return new Vector2D((double)(fvector2D.X - this.HalfWidth), (double)(fvector2D.Y - this.HalfHeight));
		}

		// Token: 0x0603310B RID: 209163 RVA: 0x00CC9DF0 File Offset: 0x00CC7FF0
		private FVector2D ConvertViewportToLguiCanvas(double viewportX, double viewportY)
		{
			FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
			float num = (viewportSize.X > this.ViewPortWidth) ? ((viewportSize.X - this.ViewPortWidth) / 2f) : 0f;
			float num2 = (viewportSize.Y > this.ViewPortHeight) ? ((viewportSize.Y - this.ViewPortHeight) / 2f) : 0f;
			ULGUICanvasScaler canvas = this.Canvas;
			FVector2D fvector2D = new FVector2D((float)(viewportX - (double)num), (float)(viewportY - (double)num2));
			return canvas.ConvertPositionFromViewportToLGUICanvas(fvector2D);
		}

		// Token: 0x0603310C RID: 209164 RVA: 0x00CC9E78 File Offset: 0x00CC8078
		private void SetGamepadOffset()
		{
			Vector2D tempVectorInLgui = this.GetTempVectorInLgui();
			double num = 0.0;
			double num2 = 0.0;
			if (tempVectorInLgui.X > (double)this.HalfWidth)
			{
				num = tempVectorInLgui.X - (double)this.HalfWidth;
				tempVectorInLgui.X = (double)this.HalfWidth;
				this.TempVector2D.X = Singleton<MathUtils>.Instance.Clamp(this.TempVector2D.X - (double)this.GamepadMoveRightValue, 0.0, (double)this.ViewPortWidth);
			}
			else if (tempVectorInLgui.X < (double)(-(double)this.HalfWidth))
			{
				num = tempVectorInLgui.X + (double)this.HalfWidth;
				tempVectorInLgui.X = (double)(-(double)this.HalfWidth);
				this.TempVector2D.X = Singleton<MathUtils>.Instance.Clamp(this.TempVector2D.X - (double)this.GamepadMoveRightValue, 0.0, (double)this.ViewPortWidth);
			}
			if (tempVectorInLgui.Y > (double)this.HalfHeight)
			{
				num2 = tempVectorInLgui.Y - (double)this.HalfHeight;
				tempVectorInLgui.Y = (double)this.HalfHeight;
				this.TempVector2D.Y = Singleton<MathUtils>.Instance.Clamp(this.TempVector2D.Y + (double)this.GamepadMoveForwardValue, 0.0, (double)this.ViewPortHeight);
			}
			else if (tempVectorInLgui.Y < (double)(-(double)this.HalfHeight))
			{
				num2 = tempVectorInLgui.Y + (double)this.HalfHeight;
				tempVectorInLgui.Y = (double)(-(double)this.HalfHeight);
				this.TempVector2D.Y = Singleton<MathUtils>.Instance.Clamp(this.TempVector2D.Y + (double)this.GamepadMoveForwardValue, 0.0, (double)this.ViewPortHeight);
			}
			this.GamepadItem.SetAnchorOffset(tempVectorInLgui.ToUeVector2D(false));
			TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
			if (lguiEventSystemActor != null)
			{
				lguiEventSystemActor.OverrideMousePosition(this.TempVector2D.ToUeVector2D(false));
			}
			if (num != 0.0 || num2 != 0.0)
			{
				Singleton<EventSystem>.Instance.Emit<double, double>(EEventName.GamepadMoveOverScreen, num, num2);
			}
		}

		// Token: 0x0603310D RID: 209165 RVA: 0x00CCA094 File Offset: 0x00CC8294
		private void InitMousePosition()
		{
			FVector2D positionInViewPort = this.GamepadItem.GetPositionInViewPort(true);
			this.EventData.pointerPosition = new FVector(positionInViewPort.X, positionInViewPort.Y, 0f);
		}

		// Token: 0x0603310E RID: 209166 RVA: 0x00CCA0D0 File Offset: 0x00CC82D0
		private void CalculateGamepadMoveDistance(float deltaTime)
		{
			if (!this.IsGamepadMoving)
			{
				return;
			}
			float num = (float)Singleton<TimeUtil>.Instance.InverseMillisecond / deltaTime;
			float num2 = 60f / num;
			this.GamepadMoveForwardValue *= num2;
			this.GamepadMoveRightValue *= num2;
			if (this.EventData != null)
			{
				FVector pointerPosition = this.EventData.pointerPosition;
				pointerPosition.Y -= this.GamepadMoveForwardValue;
				pointerPosition.X += this.GamepadMoveRightValue;
				this.TempVector2D.Set((double)pointerPosition.X, (double)pointerPosition.Y);
				return;
			}
			this.TempVector2D.Set((double)this.GamepadMoveRightValue, (double)(-(double)this.GamepadMoveForwardValue));
		}

		// Token: 0x0603310F RID: 209167 RVA: 0x00CCA182 File Offset: 0x00CC8382
		private void UpdateMousePosition()
		{
			if (!this.IsGamepadMoving)
			{
				return;
			}
			this.KillPosTweener();
			this.IsStopMoved = false;
			this.SetGamepadOffset();
			TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
			if (lguiEventSystemActor == null)
			{
				return;
			}
			lguiEventSystemActor.SwitchToNavigationInputType();
		}

		// Token: 0x06033110 RID: 209168 RVA: 0x00CCA1B4 File Offset: 0x00CC83B4
		private void UpdateMousePositionByEventData()
		{
			if (this.EventData != null)
			{
				this.TempVector2D.Set((double)this.EventData.pointerPosition.X, (double)this.EventData.pointerPosition.Y);
			}
			this.KillPosTweener();
			this.SetGamepadOffset();
			TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
			if (lguiEventSystemActor == null)
			{
				return;
			}
			lguiEventSystemActor.SwitchToNavigationInputType();
		}

		// Token: 0x06033111 RID: 209169 RVA: 0x00CCA218 File Offset: 0x00CC8418
		private void CalculateHitListener()
		{
			UUIItem nowHitComponent = Singleton<LguiEventSystemManager>.Instance.GetNowHitComponent();
			TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener = null;
			if (nowHitComponent != null)
			{
				AActor owner = nowHitComponent.GetOwner();
				TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener2 = ((owner != null) ? owner.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null) as TsUiNavigationBehaviorListener;
				if (tsUiNavigationBehaviorListener2 != null)
				{
					tsUiNavigationBehaviorListener = tsUiNavigationBehaviorListener2;
				}
			}
			if (this.HitListener != tsUiNavigationBehaviorListener)
			{
				this.ViewHandle.MarkRefreshHotKeyDirty();
			}
			this.HitListener = tsUiNavigationBehaviorListener;
		}

		// Token: 0x06033112 RID: 209170 RVA: 0x00CCA277 File Offset: 0x00CC8477
		private void KillPosTweener()
		{
			if (this.PosTweener != null)
			{
				this.PosTweener.Kill(false);
				this.PosTweener = null;
			}
		}

		// Token: 0x06033113 RID: 209171 RVA: 0x00CCA294 File Offset: 0x00CC8494
		private void OnTweenUpdate(FVector2D targetPos)
		{
			this.TempTweenPosition.Set((double)targetPos.X, (double)targetPos.Y);
			this.TempVector2D.Set(this.TempTweenPosition.X, this.TempTweenPosition.Y);
			this.SetGamepadOffset();
		}

		// Token: 0x06033114 RID: 209172 RVA: 0x00CCA2E4 File Offset: 0x00CC84E4
		private bool IsInListenerAdsorbedDistance(Vector2D tempVector2D, TsUiNavigationBehaviorListener listener)
		{
			UUIItem uuiitem = listener.RootUIComp.Get();
			bool bIsScaledByDPI = true;
			FVector2D adsorbedPivot = listener.AdsorbedPivot;
			FVector2D positionInViewportWithPivot = uuiitem.GetPositionInViewportWithPivot(bIsScaledByDPI, adsorbedPivot);
			FVector2D fvector2D = this.ConvertViewportToLguiCanvas((double)positionInViewportWithPivot.X, (double)positionInViewportWithPivot.Y);
			this.TempListenerPosition.Set((double)positionInViewportWithPivot.X, (double)positionInViewportWithPivot.Y);
			Vector2D vector2D = new Vector2D((double)fvector2D.X, (double)fvector2D.Y);
			return Math.Abs(vector2D.X - tempVector2D.X) <= (double)listener.AdsorbedDistance && Math.Abs(vector2D.Y - tempVector2D.Y) <= (double)listener.AdsorbedDistance && Vector2D.Distance(vector2D, tempVector2D) <= (double)listener.AdsorbedDistance;
		}

		// Token: 0x06033115 RID: 209173 RVA: 0x00CCA3A0 File Offset: 0x00CC85A0
		[NullableContext(2)]
		private TsUiNavigationBehaviorListener GetFirstCanAdsorbedListener(FVector2D temp)
		{
			Vector2D tempVector2D = new Vector2D((double)temp.X, (double)temp.Y);
			foreach (TsUiNavigationPanelConfig tsUiNavigationPanelConfig in this.ViewHandle.GetPanelConfigMap().Values)
			{
				foreach (TsUiNavigationBehaviorListener tsUiNavigationBehaviorListener in tsUiNavigationPanelConfig.GetPanelHandle().GetListenerSet())
				{
					if (tsUiNavigationBehaviorListener.OpenAdsorbed && tsUiNavigationBehaviorListener.IsCanFocus() && tsUiNavigationBehaviorListener.IsInLoopScrollDisplayByGridActor() && tsUiNavigationBehaviorListener.IsInDynScrollDisplay() && this.IsInListenerAdsorbedDistance(tempVector2D, tsUiNavigationBehaviorListener))
					{
						return tsUiNavigationBehaviorListener;
					}
				}
			}
			return null;
		}

		// Token: 0x06033116 RID: 209174 RVA: 0x00CCA47C File Offset: 0x00CC867C
		[NullableContext(2)]
		private bool IsHitListenerUseDrag(TsUiNavigationBehaviorListener listener)
		{
			if (listener == null || !listener.IsUseDrag)
			{
				return false;
			}
			using (Dictionary<int, TsUiNavigationPanelConfig>.ValueCollection.Enumerator enumerator = this.ViewHandle.GetPanelConfigMap().Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.GetPanelHandle().GetListenerSet().Contains(listener))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06033117 RID: 209175 RVA: 0x00CCA4F8 File Offset: 0x00CC86F8
		private void CalculateAroundListener()
		{
			if (this.IsGamepadMoving)
			{
				return;
			}
			if (this.IsStopMoved)
			{
				return;
			}
			this.IsStopMoved = true;
			FVector2D temp = this.ConvertViewportToLguiCanvas(this.TempVector2D.X, this.TempVector2D.Y);
			TsUiNavigationBehaviorListener firstCanAdsorbedListener = this.GetFirstCanAdsorbedListener(temp);
			if (firstCanAdsorbedListener != this.AdsorbedListener)
			{
				this.AdsorbedListener = firstCanAdsorbedListener;
				this.ViewHandle.MarkRefreshHotKeyDirty();
			}
			if (this.AdsorbedListener == null)
			{
				return;
			}
			this.KillPosTweener();
			this.PosTweener = ULTweenBPLibrary.Vector2To(GlobalData.World, this.Delegate, this.TempVector2D.ToUeVector2D(false), this.TempListenerPosition.ToUeVector2D(false), 0.3f, 0f, LTweenEase.OutCubic);
		}

		// Token: 0x06033118 RID: 209176 RVA: 0x00CCA5A8 File Offset: 0x00CC87A8
		private unsafe void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			bool flag = Singleton<Info>.Instance.IsInGamepad();
			TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
			if (lguiEventSystemActor != null)
			{
				lguiEventSystemActor.SetIsOverrideMousePosition(flag);
			}
			this.GamepadItem.SetAlpha(flag > false);
			this.UpdateMousePositionByEventData();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "UiNavigation:GamepadControlMouse 输入类型方式变化";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("是否开启", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前操作类型", Singleton<Info>.Instance.InputControllerType);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06033119 RID: 209177 RVA: 0x00CCA655 File Offset: 0x00CC8855
		public void MoveForwardByGamepad(float value)
		{
			this.GamepadMoveForwardValue = value * 20f * this.CanvasScaleFactor;
		}

		// Token: 0x0603311A RID: 209178 RVA: 0x00CCA66B File Offset: 0x00CC886B
		public void MoveRightByGamepad(float value)
		{
			this.GamepadMoveRightValue = value * 20f * this.CanvasScaleFactor;
		}

		// Token: 0x0603311B RID: 209179 RVA: 0x00CCA684 File Offset: 0x00CC8884
		public void TriggerByGamepad(bool isPress)
		{
			if (isPress)
			{
				this.SequencePlayer.StopSequenceByKey("Release", false, false);
				this.SequencePlayer.PlaySequencePurely("Press", false, false, null, null, false);
				return;
			}
			this.SequencePlayer.StopSequenceByKey("Press", false, false);
			this.SequencePlayer.PlaySequencePurely("Release", false, false, null, null, false);
		}

		// Token: 0x0603311C RID: 209180 RVA: 0x00CCA6F4 File Offset: 0x00CC88F4
		public unsafe void CanOverridePosition(bool value)
		{
			bool flag = value && Singleton<Info>.Instance.IsInGamepad();
			TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
			if (lguiEventSystemActor != null)
			{
				lguiEventSystemActor.SetIsOverrideMousePosition(flag);
			}
			this.GamepadItem.SetAlpha(flag > false);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiNavigation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "UiNavigation:GamepadControlMouse 手柄控制鼠标功能";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("是否开启", flag);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("当前操作类型", Singleton<Info>.Instance.InputControllerType);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (this.IsAddEvent == value)
			{
				return;
			}
			this.IsAddEvent = value;
			if (value)
			{
				this.InitMousePosition();
				Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
				return;
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
		}

		// Token: 0x0603311D RID: 209181 RVA: 0x00CCA7F4 File Offset: 0x00CC89F4
		public void UpdateMousePositionByItem(UUIItem uiItem)
		{
			bool bIsScaledByDPI = true;
			FVector2D fvector2D = new FVector2D(0.5f, 0.5f);
			FVector2D positionInViewportWithPivot = uiItem.GetPositionInViewportWithPivot(bIsScaledByDPI, fvector2D);
			this.TempVector2D.Set((double)positionInViewportWithPivot.X, (double)positionInViewportWithPivot.Y);
			this.KillPosTweener();
			this.SetGamepadOffset();
			TsLguiEventSystemActor lguiEventSystemActor = Singleton<LguiEventSystemManager>.Instance.LguiEventSystemActor;
			if (lguiEventSystemActor == null)
			{
				return;
			}
			lguiEventSystemActor.SwitchToNavigationInputType();
		}

		// Token: 0x0603311E RID: 209182 RVA: 0x00CCA854 File Offset: 0x00CC8A54
		public void UpdateMousePositionForGuide(UUIItem uiItem)
		{
			AActor owner = uiItem.GetOwner();
			this.GuideUiListener = (((owner != null) ? owner.GetComponentByClass(TsUiNavigationBehaviorListener.StaticClass()) : null) as TsUiNavigationBehaviorListener);
			this.UpdateMousePositionByItem(uiItem);
			this.ViewHandle.MarkRefreshHotKeyDirty();
		}

		// Token: 0x0603311F RID: 209183 RVA: 0x00CCA88F File Offset: 0x00CC8A8F
		public void ResetNavigationFocusForGuide()
		{
			this.GuideUiListener = null;
		}

		// Token: 0x06033120 RID: 209184 RVA: 0x00CCA898 File Offset: 0x00CC8A98
		public bool IsNearlyListenerUseDrag()
		{
			return !this.LockUseDrag && this.IsHitListenerUseDrag(this.HitListener);
		}

		// Token: 0x06033121 RID: 209185 RVA: 0x00CCA8B5 File Offset: 0x00CC8AB5
		public void SetLockUseDragState(bool value)
		{
			this.LockUseDrag = value;
		}

		// Token: 0x06033122 RID: 209186 RVA: 0x00CCA8BE File Offset: 0x00CC8ABE
		[NullableContext(2)]
		public TsUiNavigationBehaviorListener GetHitComponentListener()
		{
			return this.HitListener;
		}

		// Token: 0x06033123 RID: 209187 RVA: 0x00CCA8C6 File Offset: 0x00CC8AC6
		[NullableContext(2)]
		public TsUiNavigationBehaviorListener GetGuideUiListener()
		{
			return this.GuideUiListener;
		}

		// Token: 0x06033124 RID: 209188 RVA: 0x00CCA8CE File Offset: 0x00CC8ACE
		[NullableContext(2)]
		public TsUiNavigationBehaviorListener GetAdsorbedListener()
		{
			return this.AdsorbedListener;
		}

		// Token: 0x06033125 RID: 209189 RVA: 0x00CCA8D6 File Offset: 0x00CC8AD6
		public void NotifyNavigationMousePositionDragState(bool state)
		{
			if (this.IsDragging != state)
			{
				this.ViewHandle.MarkRefreshHotKeyDirty();
			}
			this.IsDragging = state;
		}

		// Token: 0x06033126 RID: 209190 RVA: 0x00CCA8F3 File Offset: 0x00CC8AF3
		public bool IsNavigationMousePositionDragging()
		{
			return this.IsDragging;
		}

		// Token: 0x06033127 RID: 209191 RVA: 0x00CCA8FB File Offset: 0x00CC8AFB
		public Vector2D GetMouseViewportPosition()
		{
			this.ViewportPosition.FromUeVector2D(this.GamepadItem.GetPositionInViewPort(true));
			return this.ViewportPosition;
		}

		// Token: 0x06033128 RID: 209192 RVA: 0x00CCA91F File Offset: 0x00CC8B1F
		public void Clear()
		{
			this.CanOverridePosition(false);
			this.KillPosTweener();
			this.SequencePlayer.Clear();
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<FVector2D>(this.OnTweenUpdate));
		}

		// Token: 0x06033129 RID: 209193 RVA: 0x00CCA94A File Offset: 0x00CC8B4A
		public void Tick(float deltaTime)
		{
			if (!Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			if (UiNavigationGlobalData.IsBlockNavigation)
			{
				return;
			}
			this.CalculateGamepadMoveDistance(deltaTime);
			this.UpdateMousePosition();
			this.CalculateAroundListener();
			this.CalculateHitListener();
		}

		// Token: 0x0401DB10 RID: 121616
		private const int MOVE_SPEED_INTERVAL = 20;

		// Token: 0x0401DB11 RID: 121617
		private const float TWEEN_TIME = 0.3f;

		// Token: 0x0401DB12 RID: 121618
		private const int BASE_FPS = 60;

		// Token: 0x0401DB13 RID: 121619
		[Nullable(2)]
		private Vector2D InternalTempVector2D;

		// Token: 0x0401DB14 RID: 121620
		[Nullable(2)]
		private readonly ULGUIPointerEventData EventData;

		// Token: 0x0401DB15 RID: 121621
		[Nullable(2)]
		private readonly ULGUICanvasScaler Canvas;

		// Token: 0x0401DB16 RID: 121622
		[Nullable(2)]
		private readonly UUIItem GamepadItem;

		// Token: 0x0401DB17 RID: 121623
		private readonly float HalfWidth;

		// Token: 0x0401DB18 RID: 121624
		private readonly float HalfHeight;

		// Token: 0x0401DB19 RID: 121625
		private readonly float ViewPortWidth;

		// Token: 0x0401DB1A RID: 121626
		private readonly float ViewPortHeight;

		// Token: 0x0401DB1B RID: 121627
		private float GamepadMoveForwardValue;

		// Token: 0x0401DB1C RID: 121628
		private float GamepadMoveRightValue;

		// Token: 0x0401DB1D RID: 121629
		private bool IsStopMoved;

		// Token: 0x0401DB1E RID: 121630
		private bool IsAddEvent;

		// Token: 0x0401DB1F RID: 121631
		private readonly UiNavigationViewHandle ViewHandle;

		// Token: 0x0401DB20 RID: 121632
		private readonly LevelSequencePlayer SequencePlayer;

		// Token: 0x0401DB21 RID: 121633
		private readonly float CanvasScaleFactor = 1f;

		// Token: 0x0401DB22 RID: 121634
		[Nullable(2)]
		protected TsUiNavigationBehaviorListener AdsorbedListener;

		// Token: 0x0401DB23 RID: 121635
		[Nullable(2)]
		protected TsUiNavigationBehaviorListener HitListener;

		// Token: 0x0401DB24 RID: 121636
		[Nullable(2)]
		protected TsUiNavigationBehaviorListener GuideUiListener;

		// Token: 0x0401DB25 RID: 121637
		protected bool IsDragging;

		// Token: 0x0401DB26 RID: 121638
		protected Vector2D ViewportPosition = new Vector2D();

		// Token: 0x0401DB27 RID: 121639
		protected bool LockUseDrag;

		// Token: 0x0401DB28 RID: 121640
		private readonly Vector2D TempListenerPosition = new Vector2D();

		// Token: 0x0401DB29 RID: 121641
		[Nullable(2)]
		private ULTweener PosTweener;

		// Token: 0x0401DB2A RID: 121642
		private readonly FLTweenVector2SetterDynamic Delegate;

		// Token: 0x0401DB2B RID: 121643
		private readonly Vector2D TempTweenPosition = new Vector2D();
	}
}
