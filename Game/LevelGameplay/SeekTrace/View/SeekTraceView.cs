using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.LineCross;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.SeekTrace.View
{
	// Token: 0x02006B14 RID: 27412
	[NullableContext(2)]
	[Nullable(0)]
	public class SeekTraceView : UiTickViewBase
	{
		// Token: 0x06043BBF RID: 277439 RVA: 0x0117A497 File Offset: 0x01178697
		[NullableContext(1)]
		public SeekTraceView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043BC0 RID: 277440 RVA: 0x0117A4A0 File Offset: 0x011786A0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(4, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(3, new Action(this.OnResetClick))
			};
		}

		// Token: 0x06043BC1 RID: 277441 RVA: 0x0117A54C File Offset: 0x0117874C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnCloseRewardView, new Action(this.OnCloseRewardView));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Add(EEventName.SeekTraceMoveActionInput, new Action<ESeekTraceMoveDirection, bool>(this.MoveActionInput));
			Singleton<EventSystem>.Instance.Add<ESeekTraceMoveDirection, float>(EEventName.SeekTraceMoveAxisInput, new Action<ESeekTraceMoveDirection, float>(this.MoveAxisInput));
			Singleton<EventSystem>.Instance.Add(EEventName.SeekTraceSelectItemInput, new Action(this.SelectItemInput));
			Singleton<EventSystem>.Instance.Add(EEventName.SeekTraceResetItemInput, new Action(this.ResetItemInput));
		}

		// Token: 0x06043BC2 RID: 277442 RVA: 0x0117A604 File Offset: 0x01178804
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseRewardView, new Action(this.OnCloseRewardView));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.SeekTraceMoveActionInput, new Action<ESeekTraceMoveDirection, bool>(this.MoveActionInput));
			Singleton<EventSystem>.Instance.Remove(EEventName.SeekTraceMoveAxisInput, new Action<ESeekTraceMoveDirection, float>(this.MoveAxisInput));
			Singleton<EventSystem>.Instance.Remove(EEventName.SeekTraceSelectItemInput, new Action(this.SelectItemInput));
			Singleton<EventSystem>.Instance.Remove(EEventName.SeekTraceResetItemInput, new Action(this.ResetItemInput));
		}

		// Token: 0x06043BC3 RID: 277443 RVA: 0x0117A6B9 File Offset: 0x011788B9
		private void OnCloseRewardView()
		{
			if (this.WaitRewardViewClose)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x06043BC4 RID: 277444 RVA: 0x0117A6CA File Offset: 0x011788CA
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			SeekTraceContentPanel contentPanel = this.ContentPanel;
			if (contentPanel == null)
			{
				return;
			}
			contentPanel.OnInputControllerChange();
		}

		// Token: 0x06043BC5 RID: 277445 RVA: 0x0117A6DC File Offset: 0x011788DC
		protected override UniTask OnBeforeStartAsync()
		{
			SeekTraceView.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<SeekTraceView.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06043BC6 RID: 277446 RVA: 0x0117A720 File Offset: 0x01178920
		protected override void OnStart()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			this.SequencePlayer.BindOnEndSequenceEvent(new Action<string>(this.OnSequenceEnd));
			this.RefreshStepText();
			this.JoystickInput = new SeekTraceJoystickInput();
			SeekTraceJoystickInput joystickInput = this.JoystickInput;
			if (joystickInput == null)
			{
				return;
			}
			joystickInput.RegisterMovePress(new Action<ESeekTraceMoveDirection>(this.OnMovePress));
		}

		// Token: 0x06043BC7 RID: 277447 RVA: 0x0117A782 File Offset: 0x01178982
		protected override void OnBeforeDestroy()
		{
			UiSequencePlayer sequencePlayer = this.SequencePlayer;
			if (sequencePlayer != null)
			{
				sequencePlayer.Clear();
			}
			this.SequencePlayer = null;
			this.ResetCurve = null;
			ModelBase<LineCrossModel>.Instance.CurrentChallengeFinishState = false;
		}

		// Token: 0x06043BC8 RID: 277448 RVA: 0x0117A7B0 File Offset: 0x011789B0
		[NullableContext(1)]
		private void OnSequenceEnd(string sequenceName)
		{
			if (sequenceName == "Reset")
			{
				SeekTraceContentPanel contentPanel = this.ContentPanel;
				if (contentPanel != null)
				{
					contentPanel.SetInteractEnable(true);
				}
				this.IsReseting = false;
				return;
			}
			if (sequenceName == "Success")
			{
				if (!ModelBase<SeekTraceModel>.Instance.RemainUiAfterCompletion || ModelBase<LineCrossModel>.Instance.CurrentChallengeFinishState)
				{
					base.CloseMe(null);
				}
				else if (ModelBase<SeekTraceModel>.Instance.RemainUiAfterCompletion && !ModelBase<LineCrossModel>.Instance.CurrentChallengeFinishState)
				{
					this.WaitRewardViewClose = true;
				}
				if (ModelBase<LineCrossModel>.Instance.CurrentChallengeFinishState)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("LineCross_Challenge_Pass", Array.Empty<object>());
				}
				int currentInteractEntityId = ModelBase<SeekTraceModel>.Instance.CurrentInteractEntityId;
				Entity entity = Singleton<EntitySystem>.Instance.Get(currentInteractEntityId);
				if (entity == null || !entity.Active)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Gameplay_Locked", Array.Empty<object>());
				}
				SeekTraceController.FinishSeekTrace();
			}
		}

		// Token: 0x06043BC9 RID: 277449 RVA: 0x0117A88F File Offset: 0x01178A8F
		protected override void OnTick(float delta)
		{
			SeekTraceJoystickInput joystickInput = this.JoystickInput;
			if (joystickInput != null)
			{
				joystickInput.Tick((double)delta);
			}
			SeekTraceContentPanel contentPanel = this.ContentPanel;
			if (contentPanel == null)
			{
				return;
			}
			contentPanel.UpdateKeyBoardSelectFrame();
		}

		// Token: 0x06043BCA RID: 277450 RVA: 0x0117A8B4 File Offset: 0x01178AB4
		private void OnResetClick()
		{
			if (!ModelBase<SeekTraceModel>.Instance.IsGameFinish)
			{
				this.ResetSeekTrace("CrossLine_Reset_Tips");
			}
		}

		// Token: 0x06043BCB RID: 277451 RVA: 0x0117A8D0 File Offset: 0x01178AD0
		private void OnCloseClick()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.SeekTraceExit);
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				base.CloseMe(null);
				SeekTraceController.FinishSeekTrace();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06043BCC RID: 277452 RVA: 0x0117A90C File Offset: 0x01178B0C
		private void OnSelectedItem()
		{
			base.GetItem(0).SetUIActive(false);
			base.GetButton(3).RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06043BCD RID: 277453 RVA: 0x0117A940 File Offset: 0x01178B40
		private void OnPlacedItem()
		{
			base.GetItem(0).SetUIActive(true);
			base.GetButton(3).RootUIComp.Get().SetUIActive(true);
			SeekTraceModel instance = ModelBase<SeekTraceModel>.Instance;
			this.RefreshStepText();
			if (!instance.IsGameFinish)
			{
				return;
			}
			if (!instance.GameFinishResult)
			{
				this.ResetSeekTrace("CrossLine_Fail_Tips");
				return;
			}
			this.SequencePlayer.PlaySequencePurely("Success", false, false);
			this.ContentPanel.OnSeekTraceSucceed();
		}

		// Token: 0x06043BCE RID: 277454 RVA: 0x0117A9BC File Offset: 0x01178BBC
		[NullableContext(1)]
		private void ResetSeekTrace(string tipsId)
		{
			if (this.IsReseting)
			{
				return;
			}
			this.IsReseting = true;
			int lastStep = ModelBase<SeekTraceModel>.Instance.StepLimit;
			SeekTraceController.ResetSeekTrace(delegate
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId(tipsId, Array.Empty<object>());
				this.SequencePlayer.PlaySequencePurely("Reset", false, false);
				SeekTraceContentPanel contentPanel = this.ContentPanel;
				if (contentPanel != null)
				{
					contentPanel.SetInteractEnable(false);
				}
				SeekTraceContentPanel contentPanel2 = this.ContentPanel;
				if (contentPanel2 != null)
				{
					contentPanel2.ResetView();
				}
				int stepLimit = ModelBase<SeekTraceModel>.Instance.StepLimit;
				this.Tweener = ULTweenBPLibrary.IntTo(GlobalData.World, global::DelegateUtils.ToManualReleaseDelegate<FLTweenIntSetterDynamic>(new Action<int>(this.PlayRefreshStepText)), lastStep, stepLimit, 1f, 0f, LTweenEase.OutCubic);
				if (this.Tweener != null)
				{
					if (this.ResetCurve != null)
					{
						this.Tweener.SetEase(LTweenEase.CurveFloat);
						this.Tweener.SetCurveFloat(this.ResetCurve);
					}
					this.Tweener.OnCompleteCallBack.Bind(new Action(this.PlayRefreshStepTextComplete));
				}
			});
		}

		// Token: 0x06043BCF RID: 277455 RVA: 0x0117AA0E File Offset: 0x01178C0E
		private void PlayRefreshStepText(int value)
		{
			base.GetText(2).SetText(value.ToString(), true);
		}

		// Token: 0x06043BD0 RID: 277456 RVA: 0x0117AA24 File Offset: 0x01178C24
		private void PlayRefreshStepTextComplete()
		{
			if (this.Tweener != null)
			{
				this.Tweener.Kill(false);
				this.Tweener.OnCompleteCallBack.Unbind();
				this.Tweener = null;
			}
			global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.PlayRefreshStepText));
		}

		// Token: 0x06043BD1 RID: 277457 RVA: 0x0117AA62 File Offset: 0x01178C62
		private void RefreshStepText()
		{
			base.GetText(2).SetText(ModelBase<SeekTraceModel>.Instance.StepLimit.ToString(), true);
		}

		// Token: 0x06043BD2 RID: 277458 RVA: 0x0117AA80 File Offset: 0x01178C80
		private void MoveAxisInput(ESeekTraceMoveDirection direction, float value)
		{
			SeekTraceJoystickInput joystickInput = this.JoystickInput;
			if (joystickInput == null)
			{
				return;
			}
			joystickInput.MoveAxisInput(direction, (double)value);
		}

		// Token: 0x06043BD3 RID: 277459 RVA: 0x0117AA95 File Offset: 0x01178C95
		private void MoveActionInput(ESeekTraceMoveDirection direction, bool isPress)
		{
			SeekTraceJoystickInput joystickInput = this.JoystickInput;
			if (joystickInput == null)
			{
				return;
			}
			joystickInput.MoveActionInput(direction, isPress);
		}

		// Token: 0x06043BD4 RID: 277460 RVA: 0x0117AAA9 File Offset: 0x01178CA9
		private void SelectItemInput()
		{
			SeekTraceContentPanel contentPanel = this.ContentPanel;
			if (contentPanel == null)
			{
				return;
			}
			contentPanel.GamePadSelectItem();
		}

		// Token: 0x06043BD5 RID: 277461 RVA: 0x0117AABB File Offset: 0x01178CBB
		private void ResetItemInput()
		{
			SeekTraceContentPanel contentPanel = this.ContentPanel;
			if (contentPanel == null)
			{
				return;
			}
			contentPanel.GamePadResetItem();
		}

		// Token: 0x06043BD6 RID: 277462 RVA: 0x0117AAD0 File Offset: 0x01178CD0
		private void OnMovePress(ESeekTraceMoveDirection direction)
		{
			int offsetX = 0;
			int offsetY = 0;
			switch (direction)
			{
			case ESeekTraceMoveDirection.Up:
				offsetY = -1;
				break;
			case ESeekTraceMoveDirection.Down:
				offsetY = 1;
				break;
			case ESeekTraceMoveDirection.Left:
				offsetX = -1;
				break;
			case ESeekTraceMoveDirection.Right:
				offsetX = 1;
				break;
			}
			SeekTraceContentPanel contentPanel = this.ContentPanel;
			if (contentPanel == null)
			{
				return;
			}
			contentPanel.GamePadMovePosition(offsetX, offsetY);
		}

		// Token: 0x04025DEB RID: 155115
		private PopupCaptionItem CaptionItem;

		// Token: 0x04025DEC RID: 155116
		private SeekTraceContentPanel ContentPanel;

		// Token: 0x04025DED RID: 155117
		private SeekTraceClawItem ClawItem;

		// Token: 0x04025DEE RID: 155118
		private bool IsReseting;

		// Token: 0x04025DEF RID: 155119
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04025DF0 RID: 155120
		private ULTweener Tweener;

		// Token: 0x04025DF1 RID: 155121
		private UCurveFloat ResetCurve;

		// Token: 0x04025DF2 RID: 155122
		private SeekTraceJoystickInput JoystickInput;

		// Token: 0x04025DF3 RID: 155123
		private bool WaitRewardViewClose;
	}
}
