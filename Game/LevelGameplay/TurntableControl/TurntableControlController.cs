using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.NewWorld.SceneItem.Common.Component;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.TurntableControl
{
	// Token: 0x02006A69 RID: 27241
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class TurntableControlController : UiControllerBase<TurntableControlController>
	{
		// Token: 0x06043648 RID: 276040 RVA: 0x0115C6A4 File Offset: 0x0115A8A4
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandleFail, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandleFail));
		}

		// Token: 0x06043649 RID: 276041 RVA: 0x0115C6C2 File Offset: 0x0115A8C2
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandleFail, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandleFail));
		}

		// Token: 0x0604364A RID: 276042 RVA: 0x0115C6E0 File Offset: 0x0115A8E0
		[NullableContext(1)]
		private void OnActivateUiCameraAnimationHandleFail(UiCameraHandleData _)
		{
			Singleton<Log>.Instance.Warn(ELogModule.SceneItem, ELogAuthor.ZYL, "[TurntableControlView] 激活UI相机Seq失败，关闭UI", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.TurntableControlView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.TurntableControlView, null);
			}
		}

		// Token: 0x0604364B RID: 276043 RVA: 0x0115C72A File Offset: 0x0115A92A
		public override bool Clear()
		{
			this.RemoveControllerEntityEvents();
			return base.Clear();
		}

		// Token: 0x0604364C RID: 276044 RVA: 0x0115C738 File Offset: 0x0115A938
		private void AddControllerEntityEvents()
		{
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			if (((instance != null) ? instance.CurControllerEntity : null) == null)
			{
				return;
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget(instance.CurControllerEntity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.HandleControllerUpdateState)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(instance.CurControllerEntity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.HandleControllerUpdateState));
			}
		}

		// Token: 0x0604364D RID: 276045 RVA: 0x0115C7A0 File Offset: 0x0115A9A0
		private void RemoveControllerEntityEvents()
		{
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			if (((instance != null) ? instance.CurControllerEntity : null) == null)
			{
				return;
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget(instance.CurControllerEntity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.HandleControllerUpdateState)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(instance.CurControllerEntity, EEventName.OnSceneItemStateChange, new Action<int, bool>(this.HandleControllerUpdateState));
			}
		}

		// Token: 0x0604364E RID: 276046 RVA: 0x0115C807 File Offset: 0x0115AA07
		private void HandleControllerUpdateState(int stateId, bool isReady)
		{
			if (stateId == GameplayTagDefine.EGameplayTagId["关卡.Common.状态.完成"] && isReady)
			{
				this.HandleTurntableControlViewClose();
				Singleton<UiManager>.Instance.CloseView(EUiViewName.TurntableControlView, null);
			}
		}

		// Token: 0x0604364F RID: 276047 RVA: 0x0115C838 File Offset: 0x0115AA38
		public UniTask<bool> OpenTurntableControlView(int controllerEntityId)
		{
			TurntableControlController.<OpenTurntableControlView>d__7 <OpenTurntableControlView>d__;
			<OpenTurntableControlView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OpenTurntableControlView>d__.<>4__this = this;
			<OpenTurntableControlView>d__.controllerEntityId = controllerEntityId;
			<OpenTurntableControlView>d__.<>1__state = -1;
			<OpenTurntableControlView>d__.<>t__builder.Start<TurntableControlController.<OpenTurntableControlView>d__7>(ref <OpenTurntableControlView>d__);
			return <OpenTurntableControlView>d__.<>t__builder.Task;
		}

		// Token: 0x06043650 RID: 276048 RVA: 0x0115C884 File Offset: 0x0115AA84
		public void HandleTurntableControlViewClose()
		{
			this.RemoveControllerEntityEvents();
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			SceneItemTurntableControllerComponent curControllerEntityComp = instance.CurControllerEntityComp;
			if (curControllerEntityComp != null)
			{
				curControllerEntityComp.TriggerStopAllRingsRotate();
				curControllerEntityComp.DeselectAllRings(true);
				curControllerEntityComp.SetAllowRotate(false);
			}
			instance.ClearCurControllerEntity();
		}

		// Token: 0x06043651 RID: 276049 RVA: 0x0115C8BF File Offset: 0x0115AABF
		[NullableContext(2)]
		public Entity GetControllerEntity()
		{
			return ModelBase<TurntableControlModel>.Instance.CurControllerEntity;
		}

		// Token: 0x06043652 RID: 276050 RVA: 0x0115C8CC File Offset: 0x0115AACC
		public void StartRotateSelected()
		{
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			if (((instance != null) ? instance.CurControllerEntityComp : null) == null)
			{
				return;
			}
			instance.CurControllerEntityComp.TriggerStartSelectedRingsRotate();
		}

		// Token: 0x06043653 RID: 276051 RVA: 0x0115C8FC File Offset: 0x0115AAFC
		public void StopAllRotate()
		{
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			if (((instance != null) ? instance.CurControllerEntityComp : null) == null)
			{
				return;
			}
			if (instance.CurControllerEntityComp.GetControlType() == EControllerType.FreeAngle)
			{
				instance.CurControllerEntityComp.TriggerStopAllRingsRotate();
			}
		}

		// Token: 0x06043654 RID: 276052 RVA: 0x0115C938 File Offset: 0x0115AB38
		public bool IsAllRingsAtTarget()
		{
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			return ((instance != null) ? instance.CurControllerEntityComp : null) != null && instance.CurControllerEntityComp.IsAllRingsAtTarget();
		}

		// Token: 0x06043655 RID: 276053 RVA: 0x0115C968 File Offset: 0x0115AB68
		public bool IsBusyRotating()
		{
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			return ((instance != null) ? instance.CurControllerEntityComp : null) != null && instance.CurControllerEntityComp.IsBusyRotating();
		}

		// Token: 0x06043656 RID: 276054 RVA: 0x0115C998 File Offset: 0x0115AB98
		public void SwitchSelectedRing()
		{
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			if (((instance != null) ? instance.CurControllerEntityComp : null) == null)
			{
				return;
			}
			int? ringsNum = instance.CurControllerEntityComp.GetRingsNum();
			for (int i = 0; i < ringsNum.Value; i++)
			{
				if (instance.CurControllerEntityComp.IsRingSelectedByIndex(i))
				{
					int index = (i + 1 >= ringsNum.Value) ? 0 : (i + 1);
					this.SelectRingByIndex(index, true);
					return;
				}
			}
			this.SelectRingByIndex(0, true);
		}

		// Token: 0x06043657 RID: 276055 RVA: 0x0115CA0C File Offset: 0x0115AC0C
		public void SelectRingByIndex(int index, bool exclusive)
		{
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			if (((instance != null) ? instance.CurControllerEntityComp : null) == null)
			{
				return;
			}
			if (exclusive)
			{
				instance.CurControllerEntityComp.DeselectAllRings(false);
				instance.CurControllerEntityComp.SelectRingByIndex(index, false);
				instance.CurControllerEntityComp.UpdateAllRingsSelectedEffect();
				return;
			}
			instance.CurControllerEntityComp.SelectRingByIndex(index, true);
		}

		// Token: 0x06043658 RID: 276056 RVA: 0x0115CA64 File Offset: 0x0115AC64
		public void DeselectRingByIndex(int index)
		{
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			if (((instance != null) ? instance.CurControllerEntityComp : null) == null)
			{
				return;
			}
			instance.CurControllerEntityComp.DeselectRingByIndex(index, true);
		}

		// Token: 0x06043659 RID: 276057 RVA: 0x0115CA94 File Offset: 0x0115AC94
		public void ResetRingsAngle()
		{
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			if (((instance != null) ? instance.CurControllerEntityComp : null) == null)
			{
				return;
			}
			instance.CurControllerEntityComp.TriggerResetAllRingsToInitAngle(false);
		}

		// Token: 0x0604365A RID: 276058 RVA: 0x0115CAC4 File Offset: 0x0115ACC4
		public EControllerType? GetControlType()
		{
			TurntableControlModel instance = ModelBase<TurntableControlModel>.Instance;
			if (((instance != null) ? instance.CurControllerEntityComp : null) == null)
			{
				return null;
			}
			return new EControllerType?(instance.CurControllerEntityComp.GetControlType());
		}
	}
}
