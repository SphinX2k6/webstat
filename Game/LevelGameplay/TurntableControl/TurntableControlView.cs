using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.TurntableControl
{
	// Token: 0x02006A6B RID: 27243
	[NullableContext(2)]
	[Nullable(0)]
	public class TurntableControlView : UiViewBase
	{
		// Token: 0x06043662 RID: 276066 RVA: 0x0115CB76 File Offset: 0x0115AD76
		[NullableContext(1)]
		public TurntableControlView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06043663 RID: 276067 RVA: 0x0115CB80 File Offset: 0x0115AD80
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(3, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnBtnResetClicked)),
				new ValueTuple<int, Delegate>(1, new Action(this.OnBtnSwitchClicked)),
				new ValueTuple<int, Delegate>(3, new Action(this.OnBtnBackClicked))
			};
			if (ControllerBase<TurntableControlController>.Instance.GetControlType().GetValueOrDefault() == Aki.TDConfigMgr.Component.EControllerType.FixedAngle)
			{
				this.BtnBindInfo.Add(new ValueTuple<int, Delegate>(2, new Action(this.OnBtnRotateClicked)));
			}
		}

		// Token: 0x06043664 RID: 276068 RVA: 0x0115CC78 File Offset: 0x0115AE78
		protected override void OnStart()
		{
			this.BtnReset = base.GetButton(0);
			this.BtnSwitch = base.GetButton(1);
			this.BtnRotate = base.GetButton(2);
			this.BtnBack = base.GetButton(3);
			Aki.TDConfigMgr.Component.EControllerType? controlType = ControllerBase<TurntableControlController>.Instance.GetControlType();
			Aki.TDConfigMgr.Component.EControllerType econtrollerType = Aki.TDConfigMgr.Component.EControllerType.FreeAngle;
			if (controlType.GetValueOrDefault() == econtrollerType & controlType != null)
			{
				this.BtnRotate.OnPointDownCallBack.Bind(new Action(this.OnBtnRotateDown));
				this.BtnRotate.OnPointUpCallBack.Bind(new Action(this.OnBtnRotateUp));
				UiComponentUtil.BindAudioEvent(this.BtnRotate);
			}
		}

		// Token: 0x06043665 RID: 276069 RVA: 0x0115CD1D File Offset: 0x0115AF1D
		protected override void OnBeforeShow()
		{
			Singleton<UiTimeDilation>.Instance.AddWaitSetTimeDilationTag("TurntableControl");
		}

		// Token: 0x06043666 RID: 276070 RVA: 0x0115CD2E File Offset: 0x0115AF2E
		protected override void OnAfterHide()
		{
			Singleton<UiTimeDilation>.Instance.DeleteWaitSetTimeDilationTag("TurntableControl");
		}

		// Token: 0x06043667 RID: 276071 RVA: 0x0115CD40 File Offset: 0x0115AF40
		protected override void OnBeforeDestroy()
		{
			ControllerBase<TurntableControlController>.Instance.HandleTurntableControlViewClose();
			if (this.BtnRotate.OnPointDownCallBack.IsBound())
			{
				this.BtnRotate.OnPointDownCallBack.Unbind();
			}
			if (this.BtnRotate.OnPointUpCallBack.IsBound())
			{
				this.BtnRotate.OnPointUpCallBack.Unbind();
			}
			UiComponentUtil.UnBindAudioEvent(this.BtnRotate);
			this.BtnReset = null;
			this.BtnSwitch = null;
			this.BtnRotate = null;
			this.BtnBack = null;
		}

		// Token: 0x06043668 RID: 276072 RVA: 0x0115CDC4 File Offset: 0x0115AFC4
		protected override void OnAfterShow()
		{
			if (ControllerBase<TurntableControlController>.Instance.IsAllRingsAtTarget())
			{
				this.BtnReset.SetSelfInteractive(false);
				this.BtnSwitch.SetSelfInteractive(false);
				this.BtnRotate.SetSelfInteractive(false);
			}
			if (!this.OpenViewSeqEventTriggered)
			{
				Singleton<Log>.Instance.Info(ELogModule.SceneItem, ELogAuthor.ZYL, "[TurntableControlView] Seq事件未触发过，初始隐藏UI", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.GetRootItem().SetUIActive(false);
			}
		}

		// Token: 0x06043669 RID: 276073 RVA: 0x0115CE34 File Offset: 0x0115B034
		protected override void OnAddEventListener()
		{
			Entity controllerEntity = ControllerBase<TurntableControlController>.Instance.GetControllerEntity();
			if (controllerEntity != null && !Singleton<EventSystem>.Instance.HasWithTarget(controllerEntity, EEventName.OnTurntableControllerBusyStateChange, new Action<bool, bool>(this.OnTurntableControllerBusyStateChange)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(controllerEntity, EEventName.OnTurntableControllerBusyStateChange, new Action<bool, bool>(this.OnTurntableControllerBusyStateChange));
			}
			Singleton<EventSystem>.Instance.Add(EEventName.OnExecuteUiCameraSequenceEvent, new Action<string>(this.OnExecuteUiCameraSequenceEvent));
		}

		// Token: 0x0604366A RID: 276074 RVA: 0x0115CEA8 File Offset: 0x0115B0A8
		protected override void OnRemoveEventListener()
		{
			Entity controllerEntity = ControllerBase<TurntableControlController>.Instance.GetControllerEntity();
			if (controllerEntity != null && Singleton<EventSystem>.Instance.HasWithTarget(controllerEntity, EEventName.OnTurntableControllerBusyStateChange, new Action<bool, bool>(this.OnTurntableControllerBusyStateChange)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(controllerEntity, EEventName.OnTurntableControllerBusyStateChange, new Action<bool, bool>(this.OnTurntableControllerBusyStateChange));
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnExecuteUiCameraSequenceEvent, new Action<string>(this.OnExecuteUiCameraSequenceEvent));
		}

		// Token: 0x0604366B RID: 276075 RVA: 0x0115CF1C File Offset: 0x0115B11C
		[NullableContext(1)]
		private void OnExecuteUiCameraSequenceEvent(string sequenceEventName)
		{
			if (sequenceEventName == "OnOpenTurntableControlViewBlackScreen")
			{
				this.OpenViewSeqEventTriggered = true;
				ControllerBase<TurntableControlController>.Instance.SelectRingByIndex(0, true);
				Singleton<Log>.Instance.Info(ELogModule.SceneItem, ELogAuthor.ZYL, "[TurntableControlView] Seq触发黑幕进入事件，显示UI", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.GetRootItem().SetUIActive(true);
			}
		}

		// Token: 0x0604366C RID: 276076 RVA: 0x0115CF74 File Offset: 0x0115B174
		private void OnTurntableControllerBusyStateChange(bool isBusyRotating, bool isBusyAnimating)
		{
			if (isBusyAnimating)
			{
				this.BtnReset.SetSelfInteractive(false);
				this.BtnSwitch.SetSelfInteractive(false);
				this.BtnRotate.SetSelfInteractive(false);
				this.BtnBack.SetSelfInteractive(false);
				return;
			}
			if (isBusyRotating)
			{
				this.BtnReset.SetSelfInteractive(false);
				this.BtnSwitch.SetSelfInteractive(true);
				if (ControllerBase<TurntableControlController>.Instance.GetControlType().GetValueOrDefault() == Aki.TDConfigMgr.Component.EControllerType.FixedAngle)
				{
					this.BtnRotate.SetSelfInteractive(false);
				}
				else
				{
					this.BtnRotate.SetSelfInteractive(true);
				}
				this.BtnBack.SetSelfInteractive(false);
				return;
			}
			this.BtnReset.SetSelfInteractive(true);
			this.BtnSwitch.SetSelfInteractive(true);
			this.BtnRotate.SetSelfInteractive(true);
			this.BtnBack.SetSelfInteractive(true);
		}

		// Token: 0x0604366D RID: 276077 RVA: 0x0115D03C File Offset: 0x0115B23C
		private void OnBtnResetClicked()
		{
			this.OnTurntableControllerBusyStateChange(false, true);
			this.OnBtnResetClickedImp();
		}

		// Token: 0x0604366E RID: 276078 RVA: 0x0115D050 File Offset: 0x0115B250
		private UniTask OnBtnResetClickedImp()
		{
			TurntableControlView.<OnBtnResetClickedImp>d__18 <OnBtnResetClickedImp>d__;
			<OnBtnResetClickedImp>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBtnResetClickedImp>d__.<>4__this = this;
			<OnBtnResetClickedImp>d__.<>1__state = -1;
			<OnBtnResetClickedImp>d__.<>t__builder.Start<TurntableControlView.<OnBtnResetClickedImp>d__18>(ref <OnBtnResetClickedImp>d__);
			return <OnBtnResetClickedImp>d__.<>t__builder.Task;
		}

		// Token: 0x0604366F RID: 276079 RVA: 0x0115D093 File Offset: 0x0115B293
		private void OnBtnSwitchClicked()
		{
			ControllerBase<TurntableControlController>.Instance.SwitchSelectedRing();
		}

		// Token: 0x06043670 RID: 276080 RVA: 0x0115D09F File Offset: 0x0115B29F
		private void OnBtnRotateClicked()
		{
			ControllerBase<TurntableControlController>.Instance.StartRotateSelected();
		}

		// Token: 0x06043671 RID: 276081 RVA: 0x0115D0AB File Offset: 0x0115B2AB
		private void OnBtnRotateDown()
		{
			ControllerBase<TurntableControlController>.Instance.StartRotateSelected();
		}

		// Token: 0x06043672 RID: 276082 RVA: 0x0115D0B7 File Offset: 0x0115B2B7
		private void OnBtnRotateUp()
		{
			ControllerBase<TurntableControlController>.Instance.StopAllRotate();
		}

		// Token: 0x06043673 RID: 276083 RVA: 0x0115D0C3 File Offset: 0x0115B2C3
		private void OnBtnBackClicked()
		{
			base.CloseMe(null);
		}

		// Token: 0x04025A09 RID: 154121
		private UUIButtonComponent BtnReset;

		// Token: 0x04025A0A RID: 154122
		private UUIButtonComponent BtnSwitch;

		// Token: 0x04025A0B RID: 154123
		private UUIButtonComponent BtnRotate;

		// Token: 0x04025A0C RID: 154124
		private UUIButtonComponent BtnBack;

		// Token: 0x04025A0D RID: 154125
		private bool OpenViewSeqEventTriggered;

		// Token: 0x0200C9C3 RID: 51651
		[NullableContext(0)]
		public enum ETurntableControlView
		{
			// Token: 0x0403E018 RID: 253976
			BtnReset,
			// Token: 0x0403E019 RID: 253977
			BtnSwitch,
			// Token: 0x0403E01A RID: 253978
			BtnRotate,
			// Token: 0x0403E01B RID: 253979
			BtnBack
		}
	}
}
