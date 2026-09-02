using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.WuwaGo.Controller;
using CSharpScript.Game.Module.WuwaGo.Model;
using CSharpScript.Game.Module.WuwaGo.Model.Role;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.View
{
	// Token: 0x02004AC1 RID: 19137
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoView : UiTickViewBase
	{
		// Token: 0x06031E39 RID: 204345 RVA: 0x00C7BDFE File Offset: 0x00C79FFE
		public WuWaGoView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06031E3A RID: 204346 RVA: 0x00C7BE3C File Offset: 0x00C7A03C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnPlayTipsButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(10, new Action(this.OnRollbackButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnInteractionButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(15, new Action(this.OnSkipCinematicButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06031E3B RID: 204347 RVA: 0x00C7C124 File Offset: 0x00C7A324
		protected override UniTask OnBeforeStartAsync()
		{
			WuWaGoView.<OnBeforeStartAsync>d__27 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<WuWaGoView.<OnBeforeStartAsync>d__27>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031E3C RID: 204348 RVA: 0x00C7C167 File Offset: 0x00C7A367
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnWuWaGoUserRequestRollbackToSavePoint, new Action(this.OnUserRequestRollbackToSavePoint));
			base.OnBeforeDestroy();
		}

		// Token: 0x06031E3D RID: 204349 RVA: 0x00C7C18C File Offset: 0x00C7A38C
		private UniTask InitCaptionItem()
		{
			WuWaGoView.<InitCaptionItem>d__29 <InitCaptionItem>d__;
			<InitCaptionItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaptionItem>d__.<>4__this = this;
			<InitCaptionItem>d__.<>1__state = -1;
			<InitCaptionItem>d__.<>t__builder.Start<WuWaGoView.<InitCaptionItem>d__29>(ref <InitCaptionItem>d__);
			return <InitCaptionItem>d__.<>t__builder.Task;
		}

		// Token: 0x06031E3E RID: 204350 RVA: 0x00C7C1CF File Offset: 0x00C7A3CF
		protected override void OnAfterShow()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.AddBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason.SurvivorsRogue);
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.Custom, EBattleUiChild.InteractionHint, false, true, 1);
			Singleton<EventSystem>.Instance.Emit(EEventName.ActiveBattleView);
		}

		// Token: 0x06031E3F RID: 204351 RVA: 0x00C7C207 File Offset: 0x00C7A407
		protected override void OnAfterHide()
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveBattleUiCommonChildVisibleReason(EBattleUiCommonChildVisibleReason.SurvivorsRogue);
			ModelBase<BattleUiModel>.Instance.ChildViewData.SetChildVisible(EBattleUiVisibleReason.Custom, EBattleUiChild.InteractionHint, true, true, 1);
		}

		// Token: 0x06031E40 RID: 204352 RVA: 0x00C7C230 File Offset: 0x00C7A430
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnWuWaGoInteractionAvailable, new Action<bool>(this.OnInteractionAvailableChanged));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnWuWaGoPlayTipAvailable, new Action<bool>(this.OnPlayTipAvailableChanged));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnWuWaGoMainControlInputAcceptingChanged, new Action<bool>(this.OnMainControlInputAcceptingChanged));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnWuWaGoProgressUpdate, new Action<int, int>(this.OnProgressUpdate));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnWuWaGoRollbackAvailable, new Action<bool>(this.OnRollbackAvailableChanged));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnWuWaGoCinematicPlayingChanged, new Action<bool>(this.OnCinematicPlayingChanged));
			Singleton<EventSystem>.Instance.Add<bool, string>(EEventName.OnWuWaGoDamageBatchStateChanged, new Action<bool, string>(this.OnDamageBatchStateChanged));
			this.RefreshInputBinding();
			this.RefreshRollbackButton();
			this.RefreshCaptionButtons();
		}

		// Token: 0x06031E41 RID: 204353 RVA: 0x00C7C330 File Offset: 0x00C7A530
		protected override void OnRemoveEventListener()
		{
			this.UnbindAllInput();
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnWuWaGoInteractionAvailable, new Action<bool>(this.OnInteractionAvailableChanged));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnWuWaGoPlayTipAvailable, new Action<bool>(this.OnPlayTipAvailableChanged));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnWuWaGoMainControlInputAcceptingChanged, new Action<bool>(this.OnMainControlInputAcceptingChanged));
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnWuWaGoProgressUpdate, new Action<int, int>(this.OnProgressUpdate));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnWuWaGoRollbackAvailable, new Action<bool>(this.OnRollbackAvailableChanged));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnWuWaGoCinematicPlayingChanged, new Action<bool>(this.OnCinematicPlayingChanged));
			Singleton<EventSystem>.Instance.Remove<bool, string>(EEventName.OnWuWaGoDamageBatchStateChanged, new Action<bool, string>(this.OnDamageBatchStateChanged));
		}

		// Token: 0x06031E42 RID: 204354 RVA: 0x00C7C423 File Offset: 0x00C7A623
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.RefreshInputBinding();
		}

		// Token: 0x06031E43 RID: 204355 RVA: 0x00C7C42C File Offset: 0x00C7A62C
		private void OnInteractionAvailableChanged(bool available)
		{
			this.SetInteractionButtonActive(available);
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlaySequence(available ? "Icon_In_1" : "Icon_Out_1", true, null);
		}

		// Token: 0x06031E44 RID: 204356 RVA: 0x00C7C46C File Offset: 0x00C7A66C
		private void SetInteractionButtonActive(bool visible)
		{
			UUIButtonComponent button = base.GetButton(12);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(visible);
		}

		// Token: 0x06031E45 RID: 204357 RVA: 0x00C7C49E File Offset: 0x00C7A69E
		private void OnPlayTipAvailableChanged(bool available)
		{
			this.PlayTipAvailable = available;
			this.RefreshPlayTipButton();
			this.RefreshDialogueBubblePanel();
		}

		// Token: 0x06031E46 RID: 204358 RVA: 0x00C7C4B3 File Offset: 0x00C7A6B3
		private void RefreshPlayTipButton()
		{
			UUIButtonComponent button = base.GetButton(6);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(this.PlayTipAvailable && ControllerBase<WuWaGoController>.Instance.CanUsePlayTip());
		}

		// Token: 0x06031E47 RID: 204359 RVA: 0x00C7C4DB File Offset: 0x00C7A6DB
		private void OnMainControlInputAcceptingChanged(bool accepting)
		{
			this.RefreshPlayTipButton();
		}

		// Token: 0x06031E48 RID: 204360 RVA: 0x00C7C4E3 File Offset: 0x00C7A6E3
		private void OnRollbackAvailableChanged(bool available)
		{
			this.RollbackAvailable = available;
			this.RefreshRollbackButton();
		}

		// Token: 0x06031E49 RID: 204361 RVA: 0x00C7C4F2 File Offset: 0x00C7A6F2
		private void RefreshRollbackButton()
		{
			UUIButtonComponent button = base.GetButton(10);
			if (button == null)
			{
				return;
			}
			button.SetSelfInteractive(!this.CinematicPlaying && !this.IsDamageBatchActive() && this.RollbackAvailable);
		}

		// Token: 0x06031E4A RID: 204362 RVA: 0x00C7C51F File Offset: 0x00C7A71F
		private void OnCinematicPlayingChanged(bool playing)
		{
			this.CinematicPlaying = playing;
			this.RefreshPlayTipButton();
			this.RefreshRollbackButton();
			this.RefreshSkipCinematicButton();
			this.RefreshCaptionButtons();
			this.RefreshDialogueBubblePanel();
		}

		// Token: 0x06031E4B RID: 204363 RVA: 0x00C7C546 File Offset: 0x00C7A746
		private void OnDamageBatchStateChanged(bool isActive, string reason)
		{
			this.RefreshRollbackButton();
			this.RefreshCaptionButtons();
			this.RefreshPlayTipButton();
		}

		// Token: 0x06031E4C RID: 204364 RVA: 0x00C7C55A File Offset: 0x00C7A75A
		private bool IsDamageBatchActive()
		{
			return ControllerBase<WuWaGoController>.Instance.IsDamageBatchActive();
		}

		// Token: 0x06031E4D RID: 204365 RVA: 0x00C7C566 File Offset: 0x00C7A766
		private void RefreshCaptionButtons()
		{
			CaptionItem captionItem = this.CaptionItem;
			if (captionItem != null)
			{
				captionItem.SetCloseButtonInteractive(!this.CinematicPlaying && !this.IsDamageBatchActive());
			}
			CaptionItem captionItem2 = this.CaptionItem;
			if (captionItem2 == null)
			{
				return;
			}
			captionItem2.SetRightTopButtonsVisible(!this.CinematicPlaying);
		}

		// Token: 0x06031E4E RID: 204366 RVA: 0x00C7C5A8 File Offset: 0x00C7A7A8
		private void RefreshSkipCinematicButton()
		{
			UUIButtonComponent button = base.GetButton(15);
			if (button == null)
			{
				return;
			}
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(this.CinematicPlaying);
		}

		// Token: 0x06031E4F RID: 204367 RVA: 0x00C7C5DF File Offset: 0x00C7A7DF
		private void OnSkipCinematicButtonClick()
		{
			ControllerBase<WuWaGoController>.Instance.RequestInterruptPlayTipCinematic();
		}

		// Token: 0x06031E50 RID: 204368 RVA: 0x00C7C5EC File Offset: 0x00C7A7EC
		private void RefreshInitialProgress()
		{
			int progressTotalGridCount = ModelBase<WuWaGoModel>.Instance.GameData.ProgressTotalGridCount;
			this.OnProgressUpdate(0, progressTotalGridCount);
		}

		// Token: 0x06031E51 RID: 204369 RVA: 0x00C7C611 File Offset: 0x00C7A811
		private void OnProgressUpdate(int reached, int total)
		{
			this.RefreshProgressView(reached, total);
		}

		// Token: 0x06031E52 RID: 204370 RVA: 0x00C7C61C File Offset: 0x00C7A81C
		private UniTask RefreshProgressView(int reached, int total)
		{
			WuWaGoView.<RefreshProgressView>d__50 <RefreshProgressView>d__;
			<RefreshProgressView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshProgressView>d__.<>4__this = this;
			<RefreshProgressView>d__.reached = reached;
			<RefreshProgressView>d__.total = total;
			<RefreshProgressView>d__.<>1__state = -1;
			<RefreshProgressView>d__.<>t__builder.Start<WuWaGoView.<RefreshProgressView>d__50>(ref <RefreshProgressView>d__);
			return <RefreshProgressView>d__.<>t__builder.Task;
		}

		// Token: 0x06031E53 RID: 204371 RVA: 0x00C7C670 File Offset: 0x00C7A870
		private UniTask EnsureProgressItems(int total)
		{
			WuWaGoView.<EnsureProgressItems>d__51 <EnsureProgressItems>d__;
			<EnsureProgressItems>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<EnsureProgressItems>d__.<>4__this = this;
			<EnsureProgressItems>d__.total = total;
			<EnsureProgressItems>d__.<>1__state = -1;
			<EnsureProgressItems>d__.<>t__builder.Start<WuWaGoView.<EnsureProgressItems>d__51>(ref <EnsureProgressItems>d__);
			return <EnsureProgressItems>d__.<>t__builder.Task;
		}

		// Token: 0x06031E54 RID: 204372 RVA: 0x00C7C6BC File Offset: 0x00C7A8BC
		private void RefreshInputBinding()
		{
			WuWaGoView.EBoundInputMode eboundInputMode = WuWaGoView.EBoundInputMode.None;
			if (Singleton<Info>.Instance.IsInTouch())
			{
				eboundInputMode = WuWaGoView.EBoundInputMode.Touch;
			}
			else if (Singleton<Info>.Instance.IsInGamepad())
			{
				eboundInputMode = WuWaGoView.EBoundInputMode.Gamepad;
			}
			else if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				eboundInputMode = WuWaGoView.EBoundInputMode.MouseKeyboard;
			}
			if (eboundInputMode == this.CurrentInputMode)
			{
				return;
			}
			this.UnbindAllInput();
			this.CurrentInputMode = eboundInputMode;
			switch (eboundInputMode)
			{
			case WuWaGoView.EBoundInputMode.MouseKeyboard:
				this.BindMouseInput();
				return;
			case WuWaGoView.EBoundInputMode.Touch:
				this.BindTouchInput();
				return;
			case WuWaGoView.EBoundInputMode.Gamepad:
				this.BindGamepadInput();
				return;
			default:
				return;
			}
		}

		// Token: 0x06031E55 RID: 204373 RVA: 0x00C7C73C File Offset: 0x00C7A93C
		private void UnbindAllInput()
		{
			switch (this.CurrentInputMode)
			{
			case WuWaGoView.EBoundInputMode.MouseKeyboard:
				this.UnbindMouseInput();
				break;
			case WuWaGoView.EBoundInputMode.Touch:
				this.UnbindTouchInput();
				break;
			case WuWaGoView.EBoundInputMode.Gamepad:
				this.UnbindGamepadInput();
				break;
			}
			this.CurrentInputMode = WuWaGoView.EBoundInputMode.None;
			this.TouchTrackingId = null;
			this.HasMouseDown = false;
			this.HasLastPreview = false;
			this.LastPreviewX = 0.0;
			this.LastPreviewY = 0.0;
		}

		// Token: 0x06031E56 RID: 204374 RVA: 0x00C7C7BB File Offset: 0x00C7A9BB
		private void BindMouseInput()
		{
			ControllerBase<InputDistributeController>.Instance.BindAction("UI左键点击", new TInputHandle<InputDistributeDefine.EActionType>(this.OnMouseClick));
		}

		// Token: 0x06031E57 RID: 204375 RVA: 0x00C7C7D8 File Offset: 0x00C7A9D8
		private void UnbindMouseInput()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI左键点击", new TInputHandle<InputDistributeDefine.EActionType>(this.OnMouseClick));
		}

		// Token: 0x06031E58 RID: 204376 RVA: 0x00C7C7F5 File Offset: 0x00C7A9F5
		private void BindTouchInput()
		{
			ControllerBase<InputDistributeController>.Instance.BindTouches(new int[1], new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x06031E59 RID: 204377 RVA: 0x00C7C813 File Offset: 0x00C7AA13
		private void UnbindTouchInput()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindTouches(new <>z__ReadOnlySingleElementList<int>(0), new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x06031E5A RID: 204378 RVA: 0x00C7C831 File Offset: 0x00C7AA31
		private void BindGamepadInput()
		{
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveForward", new TInputHandle<float>(this.OnGamepadAxis));
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveRight", new TInputHandle<float>(this.OnGamepadAxis));
		}

		// Token: 0x06031E5B RID: 204379 RVA: 0x00C7C86C File Offset: 0x00C7AA6C
		private void UnbindGamepadInput()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveForward", new TInputHandle<float>(this.OnGamepadAxis));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveRight", new TInputHandle<float>(this.OnGamepadAxis));
			this.GamepadAxisForward = 0.0;
			this.GamepadAxisRight = 0.0;
			this.GamepadDirectionLatched = false;
		}

		// Token: 0x06031E5C RID: 204380 RVA: 0x00C7C8D4 File Offset: 0x00C7AAD4
		protected override void OnTick(float delta)
		{
			if (this.CurrentInputMode != WuWaGoView.EBoundInputMode.MouseKeyboard)
			{
				return;
			}
			WuWaGoMainControlRole mainControlRole = ModelBase<WuWaGoModel>.Instance.GameData.MainControlRole;
			if (mainControlRole == null || !mainControlRole.IsAcceptingInput)
			{
				return;
			}
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return;
			}
			Vector2D cursorPosition = characterController.GetCursorPosition();
			if (cursorPosition == null)
			{
				return;
			}
			if (this.HasLastPreview && Math.Abs(cursorPosition.X - this.LastPreviewX) + Math.Abs(cursorPosition.Y - this.LastPreviewY) < (double)this.HoverMinPixel)
			{
				return;
			}
			this.HasLastPreview = true;
			this.LastPreviewX = cursorPosition.X;
			this.LastPreviewY = cursorPosition.Y;
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnWuWaGoUserPreviewScreen, (int)cursorPosition.X, (int)cursorPosition.Y);
		}

		// Token: 0x06031E5D RID: 204381 RVA: 0x00C7C998 File Offset: 0x00C7AB98
		private void OnMouseClick(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification ii)
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return;
			}
			Vector2D cursorPosition = characterController.GetCursorPosition();
			if (cursorPosition == null)
			{
				return;
			}
			if (actionType == InputDistributeDefine.EActionType.Press)
			{
				this.HasMouseDown = true;
				this.MouseDownPosition.Set(cursorPosition.X, cursorPosition.Y);
				return;
			}
			if (!this.HasMouseDown)
			{
				return;
			}
			this.HasMouseDown = false;
			this.HandleMouseRelease(cursorPosition);
		}

		// Token: 0x06031E5E RID: 204382 RVA: 0x00C7C9F4 File Offset: 0x00C7ABF4
		private void HandleMouseRelease(Vector2D endPosition)
		{
			double num = endPosition.X - this.MouseDownPosition.X;
			double num2 = endPosition.Y - this.MouseDownPosition.Y;
			if (Math.Sqrt(num * num + num2 * num2) >= (double)this.SwipeMinPixelDistance)
			{
				Singleton<EventSystem>.Instance.Emit<double, double>(EEventName.OnWuWaGoUserPickDirection, num, num2);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnWuWaGoUserPickScreen, (int)endPosition.X, (int)endPosition.Y);
		}

		// Token: 0x06031E5F RID: 204383 RVA: 0x00C7CA70 File Offset: 0x00C7AC70
		private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification ii)
		{
			switch (touchData.TouchType)
			{
			case InputDistributeDefine.ETouchType.TouchBegin:
				this.TouchTrackingId = new int?(touchData.TouchId);
				this.TouchStartPosition.Set(touchData.TouchPosition.X, touchData.TouchPosition.Y, 0.0);
				return;
			case InputDistributeDefine.ETouchType.TouchEnd:
			{
				int? touchTrackingId = this.TouchTrackingId;
				int touchId = touchData.TouchId;
				if (!(touchTrackingId.GetValueOrDefault() == touchId & touchTrackingId != null))
				{
					return;
				}
				this.HandleTouchEnd(touchData.TouchPosition);
				this.TouchTrackingId = null;
				break;
			}
			case InputDistributeDefine.ETouchType.TouchMove:
				break;
			default:
				return;
			}
		}

		// Token: 0x06031E60 RID: 204384 RVA: 0x00C7CB10 File Offset: 0x00C7AD10
		private void HandleTouchEnd(Vector endPosition)
		{
			double num = endPosition.X - this.TouchStartPosition.X;
			double num2 = endPosition.Y - this.TouchStartPosition.Y;
			if (Math.Sqrt(num * num + num2 * num2) >= (double)this.SwipeMinPixelDistance)
			{
				Singleton<EventSystem>.Instance.Emit<double, double>(EEventName.OnWuWaGoUserPickDirection, num, num2);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.OnWuWaGoUserPickScreen, (int)endPosition.X, (int)endPosition.Y);
		}

		// Token: 0x06031E61 RID: 204385 RVA: 0x00C7CB89 File Offset: 0x00C7AD89
		private void OnGamepadAxis(string axisName, float value, InputIdentification ii)
		{
			if (axisName == "UiMoveForward")
			{
				this.GamepadAxisForward = (double)value;
			}
			else
			{
				if (!(axisName == "UiMoveRight"))
				{
					return;
				}
				this.GamepadAxisRight = (double)value;
			}
			this.UpdateGamepadDirection();
		}

		// Token: 0x06031E62 RID: 204386 RVA: 0x00C7CBC0 File Offset: 0x00C7ADC0
		private void UpdateGamepadDirection()
		{
			double gamepadAxisForward = this.GamepadAxisForward;
			double gamepadAxisRight = this.GamepadAxisRight;
			double num = Math.Sqrt(gamepadAxisForward * gamepadAxisForward + gamepadAxisRight * gamepadAxisRight);
			if (this.GamepadDirectionLatched)
			{
				if (num < 0.15000000596046448)
				{
					this.GamepadDirectionLatched = false;
				}
				return;
			}
			if (num < 0.30000001192092896)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<double, double>(EEventName.OnWuWaGoUserPickDirection, gamepadAxisRight, -gamepadAxisForward);
			this.GamepadDirectionLatched = true;
		}

		// Token: 0x06031E63 RID: 204387 RVA: 0x00C7CC2B File Offset: 0x00C7AE2B
		private void OnPlayTipsButtonClick()
		{
			this.PlayTipsButtonClickImp();
		}

		// Token: 0x06031E64 RID: 204388 RVA: 0x00C7CC34 File Offset: 0x00C7AE34
		private UniTask PlayTipsButtonClickImp()
		{
			WuWaGoView.<PlayTipsButtonClickImp>d__68 <PlayTipsButtonClickImp>d__;
			<PlayTipsButtonClickImp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayTipsButtonClickImp>d__.<>4__this = this;
			<PlayTipsButtonClickImp>d__.<>1__state = -1;
			<PlayTipsButtonClickImp>d__.<>t__builder.Start<WuWaGoView.<PlayTipsButtonClickImp>d__68>(ref <PlayTipsButtonClickImp>d__);
			return <PlayTipsButtonClickImp>d__.<>t__builder.Task;
		}

		// Token: 0x06031E65 RID: 204389 RVA: 0x00C7CC77 File Offset: 0x00C7AE77
		private void OnStartSequenceEvent(string sequenceName)
		{
			UUIItem item = base.GetItem(13);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(true);
		}

		// Token: 0x06031E66 RID: 204390 RVA: 0x00C7CC8C File Offset: 0x00C7AE8C
		private void RefreshDialogueBubblePanel()
		{
			bool uiactive = this.CinematicPlaying || this.PlayTipAvailable;
			UUIItem item = base.GetItem(5);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(uiactive);
		}

		// Token: 0x06031E67 RID: 204391 RVA: 0x00C7CCC0 File Offset: 0x00C7AEC0
		private void RefreshTipsIconSprite()
		{
			UUISprite sprite = base.GetSprite(7);
			if (sprite == null)
			{
				return;
			}
			string resourceId = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? "SP_LaHaiLuoCubeMoveTipIconF" : "SP_LaHaiLuoCubeMoveTipIconM";
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
			this.SetSpriteByPath(resourcePath, sprite, false, null, null);
		}

		// Token: 0x06031E68 RID: 204392 RVA: 0x00C7CD14 File Offset: 0x00C7AF14
		private void OnRollbackButtonClick()
		{
			this.RunWithFilterMaskAsync(() => ControllerBase<WuWaGoController>.Instance.RollbackToLastStepAsync()).Forget();
		}

		// Token: 0x06031E69 RID: 204393 RVA: 0x00C7CD40 File Offset: 0x00C7AF40
		private void OnUserRequestRollbackToSavePoint()
		{
			this.RunWithFilterMaskAsync(() => ControllerBase<WuWaGoController>.Instance.RollbackToSavePointAsync()).Forget();
		}

		// Token: 0x06031E6A RID: 204394 RVA: 0x00C7CD6C File Offset: 0x00C7AF6C
		private UniTask RunWithFilterMaskAsync(Func<UniTask> action)
		{
			WuWaGoView.<RunWithFilterMaskAsync>d__74 <RunWithFilterMaskAsync>d__;
			<RunWithFilterMaskAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RunWithFilterMaskAsync>d__.<>4__this = this;
			<RunWithFilterMaskAsync>d__.action = action;
			<RunWithFilterMaskAsync>d__.<>1__state = -1;
			<RunWithFilterMaskAsync>d__.<>t__builder.Start<WuWaGoView.<RunWithFilterMaskAsync>d__74>(ref <RunWithFilterMaskAsync>d__);
			return <RunWithFilterMaskAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031E6B RID: 204395 RVA: 0x00C7CDB7 File Offset: 0x00C7AFB7
		private void OnInteractionButtonClick()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.OnWuWaGoUserUseInteraction);
		}

		// Token: 0x0401D320 RID: 119584
		[Nullable(2)]
		private CaptionItem CaptionItem;

		// Token: 0x0401D321 RID: 119585
		private readonly List<ProgressItem> ProgressItems = new List<ProgressItem>();

		// Token: 0x0401D322 RID: 119586
		private const int MaskMinDurationMs = 500;

		// Token: 0x0401D323 RID: 119587
		private const int InteractionHintCustomSubReason = 1;

		// Token: 0x0401D324 RID: 119588
		private WuWaGoView.EBoundInputMode CurrentInputMode;

		// Token: 0x0401D325 RID: 119589
		private int? TouchTrackingId;

		// Token: 0x0401D326 RID: 119590
		private readonly Vector TouchStartPosition = Vector.Create();

		// Token: 0x0401D327 RID: 119591
		private bool HasMouseDown;

		// Token: 0x0401D328 RID: 119592
		private readonly Vector2D MouseDownPosition = Vector2D.Create(0.0, 0.0);

		// Token: 0x0401D329 RID: 119593
		private bool HasLastPreview;

		// Token: 0x0401D32A RID: 119594
		private double LastPreviewX;

		// Token: 0x0401D32B RID: 119595
		private double LastPreviewY;

		// Token: 0x0401D32C RID: 119596
		private float HoverMinPixel;

		// Token: 0x0401D32D RID: 119597
		private float SwipeMinPixelDistance;

		// Token: 0x0401D32E RID: 119598
		private bool CinematicPlaying;

		// Token: 0x0401D32F RID: 119599
		private bool PlayTipAvailable;

		// Token: 0x0401D330 RID: 119600
		private bool RollbackAvailable;

		// Token: 0x0401D331 RID: 119601
		private bool IsPlayingTip;

		// Token: 0x0401D332 RID: 119602
		private const double GamepadTriggerThreshold = 0.30000001192092896;

		// Token: 0x0401D333 RID: 119603
		private const double GamepadReleaseThreshold = 0.15000000596046448;

		// Token: 0x0401D334 RID: 119604
		private double GamepadAxisForward;

		// Token: 0x0401D335 RID: 119605
		private double GamepadAxisRight;

		// Token: 0x0401D336 RID: 119606
		private bool GamepadDirectionLatched;

		// Token: 0x0200AB21 RID: 43809
		[NullableContext(0)]
		private enum EViewComponent
		{
			// Token: 0x0403540D RID: 218125
			CaptionItem,
			// Token: 0x0403540E RID: 218126
			ProgressPanelItem,
			// Token: 0x0403540F RID: 218127
			ProgressText,
			// Token: 0x04035410 RID: 218128
			ProgressHorizontalLayout,
			// Token: 0x04035411 RID: 218129
			ProgressItem,
			// Token: 0x04035412 RID: 218130
			DialogueBubblePanel,
			// Token: 0x04035413 RID: 218131
			PlayTipBtn,
			// Token: 0x04035414 RID: 218132
			TipsIconSprite,
			// Token: 0x04035415 RID: 218133
			TipText,
			// Token: 0x04035416 RID: 218134
			GameplayTipsText,
			// Token: 0x04035417 RID: 218135
			RollbackBtn,
			// Token: 0x04035418 RID: 218136
			RollbackBtnNumText,
			// Token: 0x04035419 RID: 218137
			InteractionBtn,
			// Token: 0x0403541A RID: 218138
			PanelBubble,
			// Token: 0x0403541B RID: 218139
			PanelFilter,
			// Token: 0x0403541C RID: 218140
			SkipCinematicBtn
		}

		// Token: 0x0200AB22 RID: 43810
		[NullableContext(0)]
		private enum EBoundInputMode
		{
			// Token: 0x0403541E RID: 218142
			None,
			// Token: 0x0403541F RID: 218143
			MouseKeyboard,
			// Token: 0x04035420 RID: 218144
			Touch,
			// Token: 0x04035421 RID: 218145
			Gamepad
		}
	}
}
