using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing.Components.TearItem;
using CSharpScript.Game.Module.UiNavigation;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing
{
	// Token: 0x02006567 RID: 25959
	[NullableContext(2)]
	[Nullable(0)]
	public class ActivityPrizeDrawingTearView : UiTickViewBase
	{
		// Token: 0x17009EA0 RID: 40608
		// (get) Token: 0x06040DA6 RID: 265638 RVA: 0x010A1E20 File Offset: 0x010A0020
		[Nullable(1)]
		private ActivityPrizeDrawingData ActivityData
		{
			[NullableContext(1)]
			get
			{
				return ControllerBase<ActivityPrizeDrawingController>.Instance.ActivityData;
			}
		}

		// Token: 0x06040DA7 RID: 265639 RVA: 0x010A1E2C File Offset: 0x010A002C
		public bool GetGamepadCanPress()
		{
			return this.GamepadCanPress;
		}

		// Token: 0x06040DA8 RID: 265640 RVA: 0x010A1E34 File Offset: 0x010A0034
		public void SetGamepadCanPress(bool value)
		{
			this.GamepadCanPress = value;
			Singleton<UiNavigationViewManager>.Instance.RefreshCurrentHotKey();
		}

		// Token: 0x06040DA9 RID: 265641 RVA: 0x010A1E47 File Offset: 0x010A0047
		[NullableContext(1)]
		public ActivityPrizeDrawingTearView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040DAA RID: 265642 RVA: 0x010A1E50 File Offset: 0x010A0050
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBack));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickSkip));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040DAB RID: 265643 RVA: 0x010A2024 File Offset: 0x010A0224
		protected override UniTask OnBeforeStartAsync()
		{
			ActivityPrizeDrawingTearView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ActivityPrizeDrawingTearView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040DAC RID: 265644 RVA: 0x010A2068 File Offset: 0x010A0268
		protected override void OnStart()
		{
			this.ContentItem = base.GetItem(4);
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(3);
			if (scrollViewWithScrollbar != null)
			{
				scrollViewWithScrollbar.OnPointerBeginDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnStartDragging));
			}
			if (scrollViewWithScrollbar != null)
			{
				scrollViewWithScrollbar.OnPointerEndDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnStopDragging));
			}
			ActivityButtonItem functionButton = this.FunctionButton;
			if (functionButton != null)
			{
				functionButton.SetFunction(new Action(this.OnClickFunctionButton));
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetRootItem());
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
			this.OnInputControllerChanged(Singleton<Info>.Instance.InputControllerType, Singleton<Info>.Instance.InputControllerType);
			this.FirstGacha();
		}

		// Token: 0x06040DAD RID: 265645 RVA: 0x010A2128 File Offset: 0x010A0328
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			if (this.EndDelayTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.EndDelayTimerHandle))
			{
				TimerSystem.GameplayTimeInstance.Remove(this.EndDelayTimerHandle);
			}
		}

		// Token: 0x06040DAE RID: 265646 RVA: 0x010A2166 File Offset: 0x010A0366
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnOpenAnimationEvent));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChanged));
		}

		// Token: 0x06040DAF RID: 265647 RVA: 0x010A21A0 File Offset: 0x010A03A0
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<string>(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnOpenAnimationEvent));
			Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChanged));
		}

		// Token: 0x06040DB0 RID: 265648 RVA: 0x010A21DC File Offset: 0x010A03DC
		private void OnInputControllerChanged(EInputControllerType oldController, EInputControllerType newController)
		{
			this.IsGamepad = Singleton<Info>.Instance.IsInGamepad();
			if (!this.IsGamepad)
			{
				if (this.State == ActivityPrizeDrawingTearView.EState.Ready)
				{
					UUIItem item = base.GetItem(6);
					if (item == null)
					{
						return;
					}
					item.SetUIActive(true);
				}
				return;
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(false);
		}

		// Token: 0x06040DB1 RID: 265649 RVA: 0x010A222E File Offset: 0x010A042E
		public void OnGamepadPress()
		{
			this.IsGamepadHolding = true;
			this.OnStartDragging(null);
		}

		// Token: 0x06040DB2 RID: 265650 RVA: 0x010A223F File Offset: 0x010A043F
		public void OnGamepadRelease()
		{
			this.IsGamepadHolding = false;
			this.OnStopDragging(null);
		}

		// Token: 0x06040DB3 RID: 265651 RVA: 0x010A2250 File Offset: 0x010A0450
		public void OnGamepadHold(float percent)
		{
			float num = (percent >= 1f) ? 1f : Singleton<MathUtils>.Instance.Lerp(this.CachedProgress, percent, 0.2f);
			this.CachedProgress = num;
			float offsetX = Singleton<MathUtils>.Instance.Lerp(0f, -100f, num);
			this.RotationTick(offsetX, 0f);
			PrizeDrawingTearCoverItem fadeInTearItem = this.FadeInTearItem;
			if (fadeInTearItem == null)
			{
				return;
			}
			fadeInTearItem.OnTick(num);
		}

		// Token: 0x06040DB4 RID: 265652 RVA: 0x010A22C0 File Offset: 0x010A04C0
		protected override void OnTick(float delta)
		{
			if (this.IsGamepadHolding)
			{
				return;
			}
			this.CachedProgress = Singleton<MathUtils>.Instance.Lerp(this.CachedProgress, 0f, 0.2f);
			float anchorOffsetX = this.ContentItem.GetAnchorOffsetX();
			float anchorOffsetY = this.ContentItem.GetAnchorOffsetY();
			this.RotationTick(anchorOffsetX, anchorOffsetY);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (((levelSequencePlayer != null) ? levelSequencePlayer.GetCurrentSequence() : null) != null)
			{
				return;
			}
			float val = Singleton<MathUtils>.Instance.Clamp(-anchorOffsetX / 110f, 0f, 1f);
			PrizeDrawingTearCoverItem fadeInTearItem = this.FadeInTearItem;
			if (fadeInTearItem == null)
			{
				return;
			}
			fadeInTearItem.OnTick(Math.Max(val, this.CachedProgress));
		}

		// Token: 0x06040DB5 RID: 265653 RVA: 0x010A2368 File Offset: 0x010A0568
		private void RotationTick(float offsetX, float offsetY)
		{
			FRotator relativeRotation = this.ContentItem.RelativeRotation;
			float currentValue = 0f;
			float currentValue2 = 0f;
			if (this.IsDragging)
			{
				currentValue2 = -offsetY / 10f;
				currentValue = offsetX / 10f;
			}
			float to = Singleton<MathUtils>.Instance.Clamp(currentValue, -20f, 20f);
			float to2 = Singleton<MathUtils>.Instance.Clamp(currentValue2, -20f, 20f);
			relativeRotation.Roll = Singleton<MathUtils>.Instance.Lerp(relativeRotation.Roll, to2, 0.4f);
			relativeRotation.Pitch = Singleton<MathUtils>.Instance.Lerp(relativeRotation.Pitch, to, 0.4f);
			this.ContentItem.SetUIRelativeRotation(relativeRotation);
		}

		// Token: 0x06040DB6 RID: 265654 RVA: 0x010A241F File Offset: 0x010A061F
		private void FirstGacha()
		{
			this.BeforeGachaRequest();
			this.RefreshTearItemAsync().ContinueWith(new Action(this.AfterGachaRequest));
		}

		// Token: 0x06040DB7 RID: 265655 RVA: 0x010A2440 File Offset: 0x010A0640
		private UniTask GachaRequest()
		{
			ActivityPrizeDrawingTearView.<GachaRequest>d__33 <GachaRequest>d__;
			<GachaRequest>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<GachaRequest>d__.<>4__this = this;
			<GachaRequest>d__.<>1__state = -1;
			<GachaRequest>d__.<>t__builder.Start<ActivityPrizeDrawingTearView.<GachaRequest>d__33>(ref <GachaRequest>d__);
			return <GachaRequest>d__.<>t__builder.Task;
		}

		// Token: 0x06040DB8 RID: 265656 RVA: 0x010A2483 File Offset: 0x010A0683
		private void BeforeGachaRequest()
		{
			this.RefreshByState(ActivityPrizeDrawingTearView.EState.Ready, false);
		}

		// Token: 0x06040DB9 RID: 265657 RVA: 0x010A248D File Offset: 0x010A068D
		private void AfterGachaRequest()
		{
			this.SetGamepadCanPress(true);
			this.RefreshButtonText();
			UUIItem item = base.GetItem(9);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
		}

		// Token: 0x06040DBA RID: 265658 RVA: 0x010A24B0 File Offset: 0x010A06B0
		private UniTask RefreshTearItemAsync()
		{
			ActivityPrizeDrawingTearView.<RefreshTearItemAsync>d__36 <RefreshTearItemAsync>d__;
			<RefreshTearItemAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTearItemAsync>d__.<>4__this = this;
			<RefreshTearItemAsync>d__.<>1__state = -1;
			<RefreshTearItemAsync>d__.<>t__builder.Start<ActivityPrizeDrawingTearView.<RefreshTearItemAsync>d__36>(ref <RefreshTearItemAsync>d__);
			return <RefreshTearItemAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06040DBB RID: 265659 RVA: 0x010A24F3 File Offset: 0x010A06F3
		private void OnClickFunctionButton()
		{
			PrizeDrawingTearCoverItem fadeInTearItem = this.FadeInTearItem;
			if (fadeInTearItem != null && fadeInTearItem.IsUnOpened())
			{
				return;
			}
			if (this.ActivityData.IsAllFinished() || !this.ActivityData.HaveEnoughCoinToRoll())
			{
				base.CloseMe(null);
				return;
			}
			this.GachaRequest();
		}

		// Token: 0x06040DBC RID: 265660 RVA: 0x010A2533 File Offset: 0x010A0733
		private void OnClickBack()
		{
			base.CloseMe(null);
		}

		// Token: 0x06040DBD RID: 265661 RVA: 0x010A253C File Offset: 0x010A073C
		private void OnClickSkip()
		{
			PrizeDrawingTearCoverItem fadeInTearItem = this.FadeInTearItem;
			if (fadeInTearItem == null || !fadeInTearItem.IsUnOpened())
			{
				return;
			}
			this.FadeInTearItem.SetTearShadowActive(false);
			this.SetGamepadCanPress(false);
			string animName = TearType2AnimName.GetAnimName(this.LastTearType);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlaySequencePurely(animName, true, false, null, null, false);
		}

		// Token: 0x06040DBE RID: 265662 RVA: 0x010A259E File Offset: 0x010A079E
		[NullableContext(1)]
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "SkipA" || sequenceName == "SkipB" || sequenceName == "SkipC")
			{
				PrizeDrawingTearCoverItem fadeInTearItem = this.FadeInTearItem;
				if (fadeInTearItem == null)
				{
					return;
				}
				fadeInTearItem.Open(false);
			}
		}

		// Token: 0x06040DBF RID: 265663 RVA: 0x010A25D8 File Offset: 0x010A07D8
		[NullableContext(1)]
		private void OnOpenAnimationEvent(string param)
		{
			if (param == "Reveal")
			{
				PrizeDrawingTearCoverItem fadeInTearItem = this.FadeInTearItem;
				if (fadeInTearItem == null)
				{
					return;
				}
				fadeInTearItem.PlayRevelAnimation();
			}
		}

		// Token: 0x06040DC0 RID: 265664 RVA: 0x010A25F7 File Offset: 0x010A07F7
		private bool OnStartDragging(ULGUIPointerEventData data)
		{
			this.IsDragging = true;
			PrizeDrawingTearCoverItem fadeInTearItem = this.FadeInTearItem;
			if (fadeInTearItem != null && fadeInTearItem.IsUnOpened())
			{
				this.RefreshByState(ActivityPrizeDrawingTearView.EState.InProgress, true);
				PrizeDrawingTearCoverItem fadeInTearItem2 = this.FadeInTearItem;
				if (fadeInTearItem2 != null)
				{
					fadeInTearItem2.OnStartDragging();
				}
			}
			return true;
		}

		// Token: 0x06040DC1 RID: 265665 RVA: 0x010A262E File Offset: 0x010A082E
		private bool OnStopDragging(ULGUIPointerEventData data)
		{
			this.IsDragging = false;
			PrizeDrawingTearCoverItem fadeInTearItem = this.FadeInTearItem;
			if (fadeInTearItem != null && fadeInTearItem.IsUnOpened())
			{
				this.RefreshByState(ActivityPrizeDrawingTearView.EState.Ready, true);
				PrizeDrawingTearCoverItem fadeInTearItem2 = this.FadeInTearItem;
				if (fadeInTearItem2 != null)
				{
					fadeInTearItem2.OnStopDragging();
				}
			}
			return true;
		}

		// Token: 0x06040DC2 RID: 265666 RVA: 0x010A2668 File Offset: 0x010A0868
		private void OnTearOpened()
		{
			this.SetGamepadCanPress(false);
			if (this.GetFxLevel() != EFxLevel.None)
			{
				UUIItem item = base.GetItem(9);
				if (item != null)
				{
					item.SetUIActive(true);
				}
				this.SetUiActiveNew(this.FadeInTearItem.GetFxControl(), false, true, new float?(0.5f));
				this.SetUiActiveNew(this.FadeInTearItem.GetFxControlMinor(), false, true, new float?(0.5f));
				if (this.EndDelayTimerHandle != null && TimerSystem.GameplayTimeInstance.Has(this.EndDelayTimerHandle))
				{
					TimerSystem.GameplayTimeInstance.Remove(this.EndDelayTimerHandle);
				}
				this.EndDelayTimerHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
				{
					this.AfterEndAnimationDelay();
				}, 500f, null, null, true, 1f);
				return;
			}
			this.AfterEndAnimationDelay();
		}

		// Token: 0x06040DC3 RID: 265667 RVA: 0x010A2730 File Offset: 0x010A0930
		private void RefreshButtonText()
		{
			if (this.ActivityData.IsAllFinished())
			{
				ActivityButtonItem functionButton = this.FunctionButton;
				if (functionButton == null)
				{
					return;
				}
				functionButton.SetShowText("PrefabTextItem_1120255634_Text");
				return;
			}
			else if (!this.ActivityData.HaveEnoughCoinToRoll())
			{
				ActivityButtonItem functionButton2 = this.FunctionButton;
				if (functionButton2 == null)
				{
					return;
				}
				functionButton2.SetShowText("Ichiban_Kuji_confirm");
				return;
			}
			else
			{
				ActivityButtonItem functionButton3 = this.FunctionButton;
				if (functionButton3 == null)
				{
					return;
				}
				functionButton3.SetShowText("Ichiban_Kuji_TearAgain");
				return;
			}
		}

		// Token: 0x06040DC4 RID: 265668 RVA: 0x010A2798 File Offset: 0x010A0998
		private void AfterEndAnimationDelay()
		{
			this.EndDelayTimerHandle = null;
			PrizeDrawingTearCoverItem fadeInTearItem = this.FadeInTearItem;
			PrizeDrawingTearItemBase tearItem = (fadeInTearItem != null) ? fadeInTearItem.GetTearItem() : null;
			PrizeDrawingTearCoverItemBase fadeOutTearItem = this.FadeOutTearItem;
			if (fadeOutTearItem != null)
			{
				fadeOutTearItem.AttachTearItemToContent(tearItem);
			}
			PrizeDrawingTearCoverItem fadeInTearItem2 = this.FadeInTearItem;
			if (fadeInTearItem2 != null)
			{
				fadeInTearItem2.SetUiActive(false);
			}
			PrizeDrawingTearCoverItemBase fadeOutTearItem2 = this.FadeOutTearItem;
			if (fadeOutTearItem2 != null)
			{
				fadeOutTearItem2.SetUiActive(true);
			}
			this.RefreshByState(ActivityPrizeDrawingTearView.EState.End, true);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("Next", false, false, null, null, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.StopCurrentSequence(false, false);
		}

		// Token: 0x06040DC5 RID: 265669 RVA: 0x010A2834 File Offset: 0x010A0A34
		private void RefreshByState(ActivityPrizeDrawingTearView.EState state, bool controlAlpha = true)
		{
			this.State = state;
			this.SetUiActiveNew(base.GetItem(6), state == ActivityPrizeDrawingTearView.EState.Ready && !this.IsGamepad, controlAlpha, null);
			this.SetUiActiveNew(base.GetButton(1).RootUIComp.Get(), state == ActivityPrizeDrawingTearView.EState.Ready, controlAlpha, null);
			this.SetUiActiveNew(base.GetButton(0).RootUIComp.Get(), state == ActivityPrizeDrawingTearView.EState.End, controlAlpha, null);
			this.SetUiActiveNew(this.FunctionButton.GetRootItem(), state == ActivityPrizeDrawingTearView.EState.End, controlAlpha, null);
			this.SetUiActiveNew(base.GetItem(5), state != ActivityPrizeDrawingTearView.EState.InProgress, controlAlpha, null);
		}

		// Token: 0x06040DC6 RID: 265670 RVA: 0x010A28FC File Offset: 0x010A0AFC
		[NullableContext(1)]
		private void SetUiActiveNew(UUIItem uiItem, bool active, bool controlAlpha, float? overrideDuration = null)
		{
			if (controlAlpha)
			{
				float endValue = active ? 1f : 0f;
				bool flag = !uiItem.IsUIActiveInHierarchy() && active;
				if (flag)
				{
					uiItem.SetUIActive(true);
				}
				uiItem.PlayUIItemAlphaTween(flag ? 0f : uiItem.GetAlpha(), endValue, overrideDuration.GetValueOrDefault(0.2f));
			}
			else
			{
				uiItem.SetUIActive(active);
				uiItem.SetAlpha(active ? 1f : 0f);
			}
			uiItem.SetRaycastTarget(active);
		}

		// Token: 0x06040DC7 RID: 265671 RVA: 0x010A297C File Offset: 0x010A0B7C
		private EFxLevel GetFxLevel()
		{
			EFxLevel result;
			switch (this.LastTearType)
			{
			case ETearType.Single:
				result = EFxLevel.None;
				break;
			case ETearType.SingleMultiple:
				result = EFxLevel.Minor;
				break;
			case ETearType.Double:
				result = EFxLevel.Minor;
				break;
			case ETearType.Super:
				result = EFxLevel.Super;
				break;
			default:
				result = EFxLevel.None;
				break;
			}
			return result;
		}

		// Token: 0x0402463B RID: 149051
		private bool IsDragging;

		// Token: 0x0402463C RID: 149052
		private ETearType LastTearType;

		// Token: 0x0402463D RID: 149053
		private float CachedProgress;

		// Token: 0x0402463E RID: 149054
		private TimerHandle EndDelayTimerHandle;

		// Token: 0x0402463F RID: 149055
		private ActivityButtonItem FunctionButton;

		// Token: 0x04024640 RID: 149056
		private UUIItem ContentItem;

		// Token: 0x04024641 RID: 149057
		private PrizeDrawingTearCoverItemBase FadeOutTearItem;

		// Token: 0x04024642 RID: 149058
		private PrizeDrawingTearCoverItem FadeInTearItem;

		// Token: 0x04024643 RID: 149059
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04024644 RID: 149060
		private ActivityPrizeDrawingTearView.EState State;

		// Token: 0x04024645 RID: 149061
		private bool IsGamepad;

		// Token: 0x04024646 RID: 149062
		private bool GamepadCanPress;

		// Token: 0x04024647 RID: 149063
		private bool IsGamepadHolding;

		// Token: 0x0200C54C RID: 50508
		[NullableContext(0)]
		private enum EComp
		{
			// Token: 0x0403CB74 RID: 248692
			BtnBack,
			// Token: 0x0403CB75 RID: 248693
			BtnSkip,
			// Token: 0x0403CB76 RID: 248694
			BtnAgain,
			// Token: 0x0403CB77 RID: 248695
			ScrollTear,
			// Token: 0x0403CB78 RID: 248696
			TearRoot,
			// Token: 0x0403CB79 RID: 248697
			PnlCoin,
			// Token: 0x0403CB7A RID: 248698
			ActionTips,
			// Token: 0x0403CB7B RID: 248699
			FadeInItem,
			// Token: 0x0403CB7C RID: 248700
			FadeOutItem,
			// Token: 0x0403CB7D RID: 248701
			NiagaraStand
		}

		// Token: 0x0200C54D RID: 50509
		[NullableContext(0)]
		private enum EState
		{
			// Token: 0x0403CB7F RID: 248703
			Ready,
			// Token: 0x0403CB80 RID: 248704
			InProgress,
			// Token: 0x0403CB81 RID: 248705
			End
		}
	}
}
