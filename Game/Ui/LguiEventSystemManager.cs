using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A31 RID: 18993
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LguiEventSystemManager : Singleton<LguiEventSystemManager>
	{
		// Token: 0x17008475 RID: 33909
		// (get) Token: 0x06031A1F RID: 203295 RVA: 0x00C5DAF1 File Offset: 0x00C5BCF1
		public ULGUIEventSystem LguiEventSystem
		{
			get
			{
				TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
				if (lguiEventSystemActorInternal == null)
				{
					return null;
				}
				return lguiEventSystemActorInternal.EventSystem;
			}
		}

		// Token: 0x06031A20 RID: 203296 RVA: 0x00C5DB04 File Offset: 0x00C5BD04
		public UniTask Initialize()
		{
			LguiEventSystemManager.<Initialize>d__4 <Initialize>d__;
			<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<LguiEventSystemManager.<Initialize>d__4>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x06031A21 RID: 203297 RVA: 0x00C5DB47 File Offset: 0x00C5BD47
		public void Clear()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.DestroyLguiEventSystemActor);
			TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
			if (lguiEventSystemActorInternal == null)
			{
				return;
			}
			lguiEventSystemActorInternal.ResetLguiEventSystemActor();
		}

		// Token: 0x06031A22 RID: 203298 RVA: 0x00C5DB6C File Offset: 0x00C5BD6C
		[NullableContext(1)]
		public void ClickedMouse(string actionName, InputDistributeDefine.EActionType actionType)
		{
			TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
			if (lguiEventSystemActorInternal == null || !lguiEventSystemActorInternal.IsValid())
			{
				return;
			}
			bool triggerPress = actionType == InputDistributeDefine.EActionType.Press;
			if (actionName == "UI左键点击")
			{
				lguiEventSystemActorInternal.InputTrigger(triggerPress, EMouseButtonType.Left);
				return;
			}
			if (!(actionName == "UI右键点击"))
			{
				return;
			}
			lguiEventSystemActorInternal.InputTrigger(triggerPress, EMouseButtonType.Right);
		}

		// Token: 0x06031A23 RID: 203299 RVA: 0x00C5DBC0 File Offset: 0x00C5BDC0
		[NullableContext(1)]
		public void InputNavigation(string actionName, InputDistributeDefine.EActionType actionType)
		{
			TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
			if (lguiEventSystemActorInternal == null || !lguiEventSystemActorInternal.IsValid())
			{
				return;
			}
			bool pressOrRelease = actionType == InputDistributeDefine.EActionType.Press;
			if (actionName == "UI方向上")
			{
				lguiEventSystemActorInternal.InputNavigation(ELGUINavigationDirection.Up, pressOrRelease, false);
				return;
			}
			if (actionName == "UI方向下")
			{
				lguiEventSystemActorInternal.InputNavigation(ELGUINavigationDirection.Down, pressOrRelease, false);
				return;
			}
			if (actionName == "UI方向左")
			{
				lguiEventSystemActorInternal.InputNavigation(ELGUINavigationDirection.Left, pressOrRelease, false);
				return;
			}
			if (!(actionName == "UI方向右"))
			{
				return;
			}
			lguiEventSystemActorInternal.InputNavigation(ELGUINavigationDirection.Right, pressOrRelease, false);
		}

		// Token: 0x06031A24 RID: 203300 RVA: 0x00C5DC41 File Offset: 0x00C5BE41
		public void RefreshCurrentInputModule()
		{
			TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
			if (lguiEventSystemActorInternal == null)
			{
				return;
			}
			lguiEventSystemActorInternal.RefreshCurrentInputModule();
		}

		// Token: 0x06031A25 RID: 203301 RVA: 0x00C5DC53 File Offset: 0x00C5BE53
		[NullableContext(1)]
		public void InputWheelAxis(string axisName, float value)
		{
			TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
			if (lguiEventSystemActorInternal == null)
			{
				return;
			}
			lguiEventSystemActorInternal.InputScroll(value);
		}

		// Token: 0x06031A26 RID: 203302 RVA: 0x00C5DC66 File Offset: 0x00C5BE66
		public void InputWheelAxisByGamepad(float value)
		{
			TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
			if (lguiEventSystemActorInternal == null)
			{
				return;
			}
			lguiEventSystemActorInternal.InputScrollByGamepad(value);
		}

		// Token: 0x06031A27 RID: 203303 RVA: 0x00C5DC79 File Offset: 0x00C5BE79
		public void InputTouchTrigger(bool bTouchPress, int touchId, FVector touchPosition)
		{
			TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
			if (lguiEventSystemActorInternal == null)
			{
				return;
			}
			lguiEventSystemActorInternal.InputTouchTrigger(bTouchPress, touchId, touchPosition);
		}

		// Token: 0x06031A28 RID: 203304 RVA: 0x00C5DC8E File Offset: 0x00C5BE8E
		public void InputLguiTouchMove(int touchId, FVector touchPosition)
		{
			TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
			if (lguiEventSystemActorInternal == null)
			{
				return;
			}
			lguiEventSystemActorInternal.InputTouchMove(touchId, touchPosition);
		}

		// Token: 0x06031A29 RID: 203305 RVA: 0x00C5DCA2 File Offset: 0x00C5BEA2
		public void SetEventDataPrevPosition(float x, float y)
		{
			TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
			if (lguiEventSystemActorInternal == null)
			{
				return;
			}
			lguiEventSystemActorInternal.SetPrevMousePosition(x, y);
		}

		// Token: 0x17008476 RID: 33910
		// (get) Token: 0x06031A2A RID: 203306 RVA: 0x00C5DCB6 File Offset: 0x00C5BEB6
		public TsLguiEventSystemActor LguiEventSystemActor
		{
			get
			{
				return this.LguiEventSystemActorInternal;
			}
		}

		// Token: 0x06031A2B RID: 203307 RVA: 0x00C5DCBE File Offset: 0x00C5BEBE
		public UUIItem GetNowHitComponent()
		{
			TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
			if (lguiEventSystemActorInternal == null)
			{
				return null;
			}
			return lguiEventSystemActorInternal.GetNowHitComponent();
		}

		// Token: 0x06031A2C RID: 203308 RVA: 0x00C5DCD4 File Offset: 0x00C5BED4
		public string GetNowHitComponentName()
		{
			UUIItem nowHitComponent = this.GetNowHitComponent();
			if (nowHitComponent == null)
			{
				return null;
			}
			return nowHitComponent.GetDisplayName();
		}

		// Token: 0x06031A2D RID: 203309 RVA: 0x00C5DCF3 File Offset: 0x00C5BEF3
		public ULGUIPointerEventData GetPointerEventData(int pointerId, bool createIfNotExist = false)
		{
			TsLguiEventSystemActor lguiEventSystemActorInternal = this.LguiEventSystemActorInternal;
			if (lguiEventSystemActorInternal == null)
			{
				return null;
			}
			return lguiEventSystemActorInternal.GetPointerEventData((float)pointerId, createIfNotExist);
		}

		// Token: 0x06031A2E RID: 203310 RVA: 0x00C5DD0C File Offset: 0x00C5BF0C
		public FVector? GetPointerEventDataPosition(int pointerId)
		{
			ULGUIPointerEventData pointerEventData = this.GetPointerEventData(pointerId, false);
			if (pointerEventData == null)
			{
				return null;
			}
			return new FVector?(pointerEventData.pointerPosition);
		}

		// Token: 0x06031A2F RID: 203311 RVA: 0x00C5DD3C File Offset: 0x00C5BF3C
		public bool IsPressComponentIsValid(int pointerId)
		{
			ULGUIPointerEventData pointerEventData = this.GetPointerEventData(pointerId, false);
			return pointerEventData != null && pointerEventData.enterComponent != null && pointerEventData.pressComponent != null;
		}

		// Token: 0x06031A30 RID: 203312 RVA: 0x00C5DD6C File Offset: 0x00C5BF6C
		public bool IsNowTriggerPressed(int pointerId)
		{
			ULGUIPointerEventData pointerEventData = this.GetPointerEventData(pointerId, false);
			return pointerEventData != null && pointerEventData.nowIsTriggerPressed;
		}

		// Token: 0x0401CE3B RID: 118331
		private TsLguiEventSystemActor LguiEventSystemActorInternal;

		// Token: 0x0401CE3C RID: 118332
		private bool IsInitializing;
	}
}
