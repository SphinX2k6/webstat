using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Gameplay.RollBlock;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.RollBlock.View
{
	// Token: 0x02006B22 RID: 27426
	[NullableContext(2)]
	[Nullable(0)]
	public class RollBlockView : UiViewBase
	{
		// Token: 0x06043C45 RID: 277573 RVA: 0x01180710 File Offset: 0x0117E910
		[NullableContext(1)]
		public RollBlockView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043C46 RID: 277574 RVA: 0x0118071C File Offset: 0x0117E91C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIButtonComponent));
			this.ComponentRegisterInfos = list;
			num2 = 5;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnSwitchButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnResetButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnBackButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(12, new Action(this.OnTipButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(16, new Action(this.OnHelpButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06043C47 RID: 277575 RVA: 0x01180A48 File Offset: 0x0117EC48
		protected void AddEventListener()
		{
			if (this.IsAddedEventListener)
			{
				return;
			}
			this.IsAddedEventListener = true;
			this.AddInputEvent();
			this.BindButtonEvent();
			Singleton<EventSystem>.Instance.Add(EEventName.ShowRollBlockTips, new Action(this.ShowRollBlockTips));
			if (!Singleton<EventSystem>.Instance.Has(EEventName.OnRollBlockReseting, new Action<ERollBlockResetPhase>(this.OnRollBlockReseting)))
			{
				Singleton<EventSystem>.Instance.Add(EEventName.OnRollBlockReseting, new Action<ERollBlockResetPhase>(this.OnRollBlockReseting));
			}
		}

		// Token: 0x06043C48 RID: 277576 RVA: 0x01180AC8 File Offset: 0x0117ECC8
		protected void RemoveEventListener(bool removeByReset = false)
		{
			this.IsAddedEventListener = false;
			this.RemoveInputEvent();
			this.RemoveButtonEvent();
			if (Singleton<EventSystem>.Instance.Has(EEventName.ShowRollBlockTips, new Action(this.ShowRollBlockTips)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.ShowRollBlockTips, new Action(this.ShowRollBlockTips));
			}
			if (!removeByReset)
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnRollBlockReseting, new Action<ERollBlockResetPhase>(this.OnRollBlockReseting));
			}
		}

		// Token: 0x06043C49 RID: 277577 RVA: 0x01180B40 File Offset: 0x0117ED40
		protected override void OnRemoveEventListener()
		{
			this.RemoveEventListener(false);
		}

		// Token: 0x06043C4A RID: 277578 RVA: 0x01180B4C File Offset: 0x0117ED4C
		private void AddInputEvent()
		{
			ControllerBase<InputDistributeController>.Instance.BindAxis("NavigationTopDown", new TInputHandle<float>(this.OnAxis));
			ControllerBase<InputDistributeController>.Instance.BindAxis("NavigationLeftRight", new TInputHandle<float>(this.OnAxis));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI方向上", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI方向下", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI方向左", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI方向右", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
		}

		// Token: 0x06043C4B RID: 277579 RVA: 0x01180BFC File Offset: 0x0117EDFC
		private void RemoveInputEvent()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("NavigationTopDown", new TInputHandle<float>(this.OnAxis));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("NavigationLeftRight", new TInputHandle<float>(this.OnAxis));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI方向上", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI方向下", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI方向左", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI方向右", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInput));
		}

		// Token: 0x06043C4C RID: 277580 RVA: 0x01180CAC File Offset: 0x0117EEAC
		private void BindButtonEvent()
		{
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				button.OnPointDownCallBack.Bind(delegate()
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向左移动", InputDistributeDefine.EActionType.Press);
				});
			}
			UUIButtonComponent button2 = base.GetButton(1);
			if (button2 != null)
			{
				button2.OnPointUpCallBack.Bind(delegate()
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向左移动", InputDistributeDefine.EActionType.Release);
				});
			}
			UUIButtonComponent button3 = base.GetButton(2);
			if (button3 != null)
			{
				button3.OnPointDownCallBack.Bind(delegate()
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向右移动", InputDistributeDefine.EActionType.Press);
				});
			}
			UUIButtonComponent button4 = base.GetButton(2);
			if (button4 != null)
			{
				button4.OnPointUpCallBack.Bind(delegate()
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向右移动", InputDistributeDefine.EActionType.Release);
				});
			}
			UUIButtonComponent button5 = base.GetButton(3);
			if (button5 != null)
			{
				button5.OnPointDownCallBack.Bind(delegate()
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向前移动", InputDistributeDefine.EActionType.Press);
				});
			}
			UUIButtonComponent button6 = base.GetButton(3);
			if (button6 != null)
			{
				button6.OnPointUpCallBack.Bind(delegate()
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向前移动", InputDistributeDefine.EActionType.Release);
				});
			}
			UUIButtonComponent button7 = base.GetButton(4);
			if (button7 != null)
			{
				button7.OnPointDownCallBack.Bind(delegate()
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向后移动", InputDistributeDefine.EActionType.Press);
				});
			}
			UUIButtonComponent button8 = base.GetButton(4);
			if (button8 == null)
			{
				return;
			}
			button8.OnPointUpCallBack.Bind(delegate()
			{
				ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向后移动", InputDistributeDefine.EActionType.Release);
			});
		}

		// Token: 0x06043C4D RID: 277581 RVA: 0x01180E68 File Offset: 0x0117F068
		private void RemoveButtonEvent()
		{
			UUIButtonComponent button = base.GetButton(1);
			if (button != null)
			{
				button.OnPointDownCallBack.Unbind();
			}
			UUIButtonComponent button2 = base.GetButton(1);
			if (button2 != null)
			{
				button2.OnPointUpCallBack.Unbind();
			}
			UUIButtonComponent button3 = base.GetButton(2);
			if (button3 != null)
			{
				button3.OnPointDownCallBack.Unbind();
			}
			UUIButtonComponent button4 = base.GetButton(2);
			if (button4 != null)
			{
				button4.OnPointUpCallBack.Unbind();
			}
			UUIButtonComponent button5 = base.GetButton(3);
			if (button5 != null)
			{
				button5.OnPointDownCallBack.Unbind();
			}
			UUIButtonComponent button6 = base.GetButton(3);
			if (button6 != null)
			{
				button6.OnPointUpCallBack.Unbind();
			}
			UUIButtonComponent button7 = base.GetButton(4);
			if (button7 != null)
			{
				button7.OnPointDownCallBack.Unbind();
			}
			UUIButtonComponent button8 = base.GetButton(4);
			if (button8 == null)
			{
				return;
			}
			button8.OnPointUpCallBack.Unbind();
		}

		// Token: 0x06043C4E RID: 277582 RVA: 0x01180F2C File Offset: 0x0117F12C
		private bool CanInput()
		{
			EUiViewName[] array = ModelBase<InputDistributeModel>.Instance.GetNotAllowFightInputViewNameSet().ToArray<EUiViewName>();
			return array.Length != 0 && !(array[array.Length - 1] != this.ViewInfo.Name);
		}

		// Token: 0x06043C4F RID: 277583 RVA: 0x01180F70 File Offset: 0x0117F170
		[NullableContext(1)]
		private void OnAxis(string axisName, float value, InputIdentification inputIdentification)
		{
			if (!this.CanInput())
			{
				return;
			}
			if (axisName == "NavigationTopDown" && Math.Abs(this.ForwardInputValue - value) > 1E-08f)
			{
				if (value > 0.5f && this.ForwardInputValue <= 0.5f)
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向后移动", InputDistributeDefine.EActionType.Release);
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向前移动", InputDistributeDefine.EActionType.Press);
				}
				else if (value < -0.5f && this.ForwardInputValue >= -0.5f)
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向前移动", InputDistributeDefine.EActionType.Release);
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向后移动", InputDistributeDefine.EActionType.Press);
				}
				else if (value > -0.5f && value < 0.5f)
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput((this.ForwardInputValue > 0f) ? "向前移动" : "向后移动", InputDistributeDefine.EActionType.Release);
				}
				this.ForwardInputValue = value;
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RollBlock;
				ELogAuthor author = ELogAuthor.CH;
				string message = "[input] ForwardInputValue";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Value", this.ForwardInputValue);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (axisName == "NavigationLeftRight" && Math.Abs(this.RightInputValue - value) > 1E-08f)
			{
				if (value > 0.5f && this.RightInputValue <= 0.5f)
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向左移动", InputDistributeDefine.EActionType.Release);
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向右移动", InputDistributeDefine.EActionType.Press);
				}
				else if (value < -0.5f && this.RightInputValue >= -0.5f)
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向右移动", InputDistributeDefine.EActionType.Release);
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向左移动", InputDistributeDefine.EActionType.Press);
				}
				else if (value > -0.5f && value < 0.5f)
				{
					ControllerBase<RollBlockController>.Instance.OnClickMoveInput((this.RightInputValue > 0f) ? "向右移动" : "向左移动", InputDistributeDefine.EActionType.Release);
				}
				this.RightInputValue = value;
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RollBlock;
				ELogAuthor author2 = ELogAuthor.CH;
				string message2 = "[input] RightInputValue";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Value", this.RightInputValue);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			}
		}

		// Token: 0x06043C50 RID: 277584 RVA: 0x01181190 File Offset: 0x0117F390
		[NullableContext(1)]
		private unsafe void OnInput(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (!this.CanInput() && actionType == InputDistributeDefine.EActionType.Press)
			{
				return;
			}
			if (actionName == "UI方向上")
			{
				ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向前移动", actionType);
			}
			else if (actionName == "UI方向下")
			{
				ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向后移动", actionType);
			}
			else if (actionName == "UI方向左")
			{
				ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向左移动", actionType);
			}
			else if (actionName == "UI方向右")
			{
				ControllerBase<RollBlockController>.Instance.OnClickMoveInput("向右移动", actionType);
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RollBlock;
			ELogAuthor author = ELogAuthor.CH;
			string message = "[input] OnInput";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActionName", actionName);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ActionType", actionType.ToString());
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x06043C51 RID: 277585 RVA: 0x01181288 File Offset: 0x0117F488
		private void ShowRollBlockTips()
		{
			UUIItem pnlTips = this.PnlTips;
			if (pnlTips != null && pnlTips.bIsUIActive)
			{
				return;
			}
			UUIItem pnlTips2 = this.PnlTips;
			if (pnlTips2 != null)
			{
				pnlTips2.SetUIActive(true);
			}
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer == null)
			{
				return;
			}
			sequencePlayer.PlayLevelSequenceByName("TipsIn", false, null, false);
		}

		// Token: 0x06043C52 RID: 277586 RVA: 0x011812DC File Offset: 0x0117F4DC
		private void OnRollBlockReseting(ERollBlockResetPhase resetPhase)
		{
			switch (resetPhase)
			{
			case ERollBlockResetPhase.Start:
				this.RemoveEventListener(true);
				return;
			case ERollBlockResetPhase.Failure:
				this.AddEventListener();
				return;
			case ERollBlockResetPhase.Succeed:
			{
				UUIItem pnlAll = this.PnlAll;
				if (pnlAll != null)
				{
					pnlAll.SetUIActive(false);
				}
				Singleton<EventSystem>.Instance.Once(EEventName.RollBlockAllCompleted, new Action(this.OnRollBlockAllCompleted));
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x06043C53 RID: 277587 RVA: 0x0118133C File Offset: 0x0117F53C
		protected override void OnBeforeShow()
		{
			this.PnlAll = base.GetItem(13);
			UUIItem pnlAll = this.PnlAll;
			if (pnlAll != null)
			{
				pnlAll.SetUIActive(false);
			}
			this.PnlTips = base.GetItem(8);
			UUIItem pnlTips = this.PnlTips;
			if (pnlTips != null)
			{
				pnlTips.SetUIActive(false);
			}
			UUIButtonComponent button = base.GetButton(6);
			object obj;
			if (button == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = button.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(UUIItem.StaticClass()) : null);
			}
			this.BtnReset = (obj as UUIItem);
			BP_RollBlockGameplaySetting_C gameplaySetting = ControllerBase<RollBlockController>.Instance.GameplaySetting;
			int currentDifficulty = ControllerBase<RollBlockController>.Instance.GetCurrentDifficulty();
			int totalDifficulty = ControllerBase<RollBlockController>.Instance.GetTotalDifficulty();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(14), gameplaySetting.RollBlockMainTipKey, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), gameplaySetting.RollBlockSecondTipKey, new <>z__ReadOnlyArray<object>(new object[]
			{
				currentDifficulty,
				totalDifficulty
			}));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), gameplaySetting.RollBlockPhantomTipKey, Array.Empty<object>());
			EPlayerGender playerGender = ModelBase<PlayerInfoModel>.Instance.GetPlayerGender();
			if (playerGender == EPlayerGender.None)
			{
				return;
			}
			UiResource? uiResource;
			string text = (ConfigUiResourceById.GetConfig((playerGender == EPlayerGender.Male) ? "SP_CubeMoveTipIconM" : "SP_CubeMoveTipIconF", true) != null) ? uiResource.GetValueOrDefault().Path : null;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(text, delegate([Nullable(2)] ULGUISpriteData_BaseObject sprite, string _)
			{
				if (sprite == null || !sprite.IsValid())
				{
					return;
				}
				UUISprite sprite2 = base.GetSprite(10);
				if (sprite2 == null)
				{
					return;
				}
				sprite2.SetSprite(sprite, true);
			}, 100, "js_undefined");
			this.SequencePlayer = new LevelSequencePlayer(this.RootItem);
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
			}
			Singleton<EventSystem>.Instance.Once(EEventName.RollBlockAllCompleted, new Action(this.OnRollBlockAllCompleted));
		}

		// Token: 0x06043C54 RID: 277588 RVA: 0x01181507 File Offset: 0x0117F707
		protected override void OnBeforeDestroy()
		{
			if (this.ResetButtonCDTimerHandle != null)
			{
				TimerSystem.FlowTimeInstance.Remove(this.ResetButtonCDTimerHandle);
			}
			this.ResetButtonCDTimerHandle = null;
		}

		// Token: 0x06043C55 RID: 277589 RVA: 0x01181529 File Offset: 0x0117F729
		[NullableContext(1)]
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start01")
			{
				this.AddEventListener();
			}
		}

		// Token: 0x06043C56 RID: 277590 RVA: 0x01181540 File Offset: 0x0117F740
		private void OnRollBlockAllCompleted()
		{
			UUIButtonComponent button = base.GetButton(5);
			object obj;
			if (button == null)
			{
				obj = null;
			}
			else
			{
				AActor owner = button.GetOwner();
				obj = ((owner != null) ? owner.GetComponentByClass(UUIItem.StaticClass()) : null);
			}
			(obj as UUIItem).SetUIActive(ControllerBase<RollBlockController>.Instance.GetIsMultiBlock());
			UUIItem pnlAll = this.PnlAll;
			if (pnlAll != null)
			{
				pnlAll.SetUIActive(true);
			}
			LevelSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.PlayLevelSequenceByName("Start01", false, null, false);
			}
			ControllerBase<RollBlockController>.Instance.NotifyServerShowAllBlock();
			UUIItem btnReset = this.BtnReset;
			if (btnReset != null)
			{
				btnReset.SetUIActive(false);
			}
			if (this.ResetButtonCDTimerHandle != null)
			{
				TimerSystem.FlowTimeInstance.Remove(this.ResetButtonCDTimerHandle);
			}
			this.ResetButtonCDTimerHandle = TimerSystem.FlowTimeInstance.Delay(delegate(float _)
			{
				this.ResetButtonCDTimerHandle = null;
				UUIItem btnReset2 = this.BtnReset;
				if (btnReset2 == null)
				{
					return;
				}
				btnReset2.SetUIActive(true);
			}, 4000f, null, null, true, 1f);
		}

		// Token: 0x06043C57 RID: 277591 RVA: 0x0118161B File Offset: 0x0117F81B
		private void OnSwitchButtonClick()
		{
			ControllerBase<RollBlockController>.Instance.OnClickSwitch();
		}

		// Token: 0x06043C58 RID: 277592 RVA: 0x01181627 File Offset: 0x0117F827
		private void OnResetButtonClick()
		{
			ControllerBase<RollBlockController>.Instance.OnClickReset(false, false);
		}

		// Token: 0x06043C59 RID: 277593 RVA: 0x01181635 File Offset: 0x0117F835
		private void OnBackButtonClick()
		{
			ControllerBase<RollBlockController>.Instance.OnClickEsc();
		}

		// Token: 0x06043C5A RID: 277594 RVA: 0x01181641 File Offset: 0x0117F841
		private void OnTipButtonClick()
		{
			ControllerBase<RollBlockController>.Instance.OnClickTip();
		}

		// Token: 0x06043C5B RID: 277595 RVA: 0x0118164D File Offset: 0x0117F84D
		private void OnHelpButtonClick()
		{
			ControllerBase<TutorialController>.Instance.OpenExclusiveTutorial(EExclusiveTutorialType.RollBlock);
		}

		// Token: 0x04025E69 RID: 155241
		private float ForwardInputValue;

		// Token: 0x04025E6A RID: 155242
		private float RightInputValue;

		// Token: 0x04025E6B RID: 155243
		private LevelSequencePlayer SequencePlayer;

		// Token: 0x04025E6C RID: 155244
		private UUIItem PnlAll;

		// Token: 0x04025E6D RID: 155245
		private UUIItem PnlTips;

		// Token: 0x04025E6E RID: 155246
		private UUIItem BtnReset;

		// Token: 0x04025E6F RID: 155247
		private bool IsAddedEventListener;

		// Token: 0x04025E70 RID: 155248
		private TimerHandle ResetButtonCDTimerHandle;
	}
}
