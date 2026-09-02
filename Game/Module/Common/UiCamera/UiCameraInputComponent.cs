using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.UiCamera
{
	// Token: 0x02005E4B RID: 24139
	[NullableContext(1)]
	[Nullable(0)]
	public class UiCameraInputComponent
	{
		// Token: 0x0603CBCA RID: 248778 RVA: 0x00F6C5E0 File Offset: 0x00F6A7E0
		public void InitData(IUiCameraInputComponentData data)
		{
			if (this.ComponentState == EComponentState.None || this.ComponentState == EComponentState.End)
			{
				this.ComponentState = EComponentState.InitData;
				this.Data = data;
				this.OnInitData();
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiCommon;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "[UiCameraInputComponent] InitData调用异常";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentState", this.ComponentState);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603CBCB RID: 248779 RVA: 0x00F6C644 File Offset: 0x00F6A844
		public void UpdateData(IUiCameraInputComponentData data)
		{
			if (this.ComponentState == EComponentState.Start || this.ComponentState == EComponentState.DeActivated)
			{
				this.Data = data;
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiCommon;
			ELogAuthor author = ELogAuthor.WDX;
			string message = "[UiCameraInputComponent] UpdateData调用异常";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentState", this.ComponentState);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603CBCC RID: 248780 RVA: 0x00F6C69C File Offset: 0x00F6A89C
		public void Start()
		{
			if (this.ComponentState == EComponentState.InitData || this.ComponentState == EComponentState.End)
			{
				this.ComponentState = EComponentState.Start;
				this.OnStart();
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiCommon;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "[UiCameraInputComponent] Start调用异常";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentState", this.ComponentState);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603CBCD RID: 248781 RVA: 0x00F6C6FC File Offset: 0x00F6A8FC
		public void Activate()
		{
			if (this.ComponentState != EComponentState.Start && this.ComponentState != EComponentState.DeActivated)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCommon;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "[UiCameraInputComponent] Activate调用异常";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentState", this.ComponentState);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (Singleton<UiCameraAnimationManager>.Instance.IsPlayingAnimation())
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCommon, ELogAuthor.LZK, "[UiCameraInputComponent] 在相机动画期间不应该激活相机输入组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.ComponentState = EComponentState.Activated;
			this.OnActivate();
		}

		// Token: 0x0603CBCE RID: 248782 RVA: 0x00F6C784 File Offset: 0x00F6A984
		public void DeActivate()
		{
			if (this.ComponentState == EComponentState.Activated)
			{
				this.ComponentState = EComponentState.DeActivated;
				this.OnDeActivate();
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiCommon;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "[UiCameraInputComponent] DeActivate调用异常";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentState", this.ComponentState);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603CBCF RID: 248783 RVA: 0x00F6C7DC File Offset: 0x00F6A9DC
		public void End()
		{
			if (this.ComponentState == EComponentState.Activated)
			{
				this.DeActivate();
			}
			if (this.ComponentState == EComponentState.Start || this.ComponentState == EComponentState.DeActivated)
			{
				this.ComponentState = EComponentState.End;
				this.OnEnd();
				return;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.UiCommon;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "[UiCameraInputComponent] End调用异常";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentState", this.ComponentState);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0603CBD0 RID: 248784 RVA: 0x00F6C84C File Offset: 0x00F6AA4C
		protected void OnInitData()
		{
			UiCamera uiCamera = UiCameraManager.Get();
			this.UiCameraControlRotationComponent = (uiCamera.AddUiCameraComponent(typeof(UiCameraControlRotationComponent), false) as UiCameraControlRotationComponent);
		}

		// Token: 0x0603CBD1 RID: 248785 RVA: 0x00F6C87B File Offset: 0x00F6AA7B
		protected void OnStart()
		{
			this.AddCameraEventListener();
		}

		// Token: 0x0603CBD2 RID: 248786 RVA: 0x00F6C883 File Offset: 0x00F6AA83
		protected void AddCameraEventListener()
		{
			Singleton<EventSystem>.Instance.Add<UiCameraHandleData, UiCameraHandleData, string>(EEventName.OnPlayCameraAnimationStart, new Action<UiCameraHandleData, UiCameraHandleData, string>(this.OnPlayCameraAnimationStart));
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		}

		// Token: 0x0603CBD3 RID: 248787 RVA: 0x00F6C8BD File Offset: 0x00F6AABD
		protected void OnActivate()
		{
			this.ActiveCameraControlRotationComponent();
			UiCameraControlRotationComponent uiCameraControlRotationComponent = this.UiCameraControlRotationComponent;
			if (uiCameraControlRotationComponent != null)
			{
				uiCameraControlRotationComponent.Activate();
			}
			this.AddInputEventListener();
		}

		// Token: 0x0603CBD4 RID: 248788 RVA: 0x00F6C8DC File Offset: 0x00F6AADC
		protected void AddInputEventListener()
		{
			UUIDraggableComponent dragComponent = this.Data.DragComponent;
			dragComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDragCallBack));
			dragComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
			dragComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndDragCallBack));
			dragComponent.OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerScrollCallBack));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerRoleLookUp, new Action<float>(this.OnInputUiLookUp));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerRoleTurn, new Action<float>(this.OnInputUiTurn));
			Singleton<EventSystem>.Instance.Add<string, float>(EEventName.NavigationTriggerRoleZoom, new Action<string, float>(this.OnInputUiZoom));
			Singleton<EventSystem>.Instance.Add(EEventName.NavigationTriggerRoleReset, new Action(this.OnRightStickPress));
			ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
			{
				0,
				1
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x0603CBD5 RID: 248789 RVA: 0x00F6C9DF File Offset: 0x00F6ABDF
		protected void OnDeActivate()
		{
			UiCameraControlRotationComponent uiCameraControlRotationComponent = this.UiCameraControlRotationComponent;
			if (uiCameraControlRotationComponent != null)
			{
				uiCameraControlRotationComponent.Deactivate();
			}
			this.CurrentDragPosition = null;
			this.RemoveInputEventListener();
		}

		// Token: 0x0603CBD6 RID: 248790 RVA: 0x00F6CA04 File Offset: 0x00F6AC04
		protected void RemoveInputEventListener()
		{
			UUIDraggableComponent dragComponent = this.Data.DragComponent;
			dragComponent.OnPointerBeginDragCallBack.Unbind();
			dragComponent.OnPointerDragCallBack.Unbind();
			dragComponent.OnPointerEndDragCallBack.Unbind();
			dragComponent.OnPointerScrollCallBack.Unbind();
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleLookUp, new Action<float>(this.OnInputUiLookUp));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleTurn, new Action<float>(this.OnInputUiTurn));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleZoom, new Action<string, float>(this.OnInputUiZoom));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerRoleReset, new Action(this.OnRightStickPress));
			ControllerBase<InputDistributeController>.Instance.UnBindTouches(new int[]
			{
				0,
				1
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x0603CBD7 RID: 248791 RVA: 0x00F6CAD7 File Offset: 0x00F6ACD7
		protected void RemoveCameraEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayCameraAnimationStart, new Action<UiCameraHandleData, UiCameraHandleData, string>(this.OnPlayCameraAnimationStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		}

		// Token: 0x0603CBD8 RID: 248792 RVA: 0x00F6CB11 File Offset: 0x00F6AD11
		protected void OnEnd()
		{
			this.RemoveCameraEventListener();
		}

		// Token: 0x0603CBD9 RID: 248793 RVA: 0x00F6CB19 File Offset: 0x00F6AD19
		public EComponentState GetComponentState()
		{
			return this.ComponentState;
		}

		// Token: 0x0603CBDA RID: 248794 RVA: 0x00F6CB21 File Offset: 0x00F6AD21
		public bool TryActivate()
		{
			if (Singleton<UiCameraAnimationManager>.Instance.IsPlayingAnimation())
			{
				return false;
			}
			this.Activate();
			return true;
		}

		// Token: 0x0603CBDB RID: 248795 RVA: 0x00F6CB38 File Offset: 0x00F6AD38
		public bool TryDeActivate()
		{
			if (this.ComponentState != EComponentState.Activated)
			{
				return false;
			}
			this.DeActivate();
			return true;
		}

		// Token: 0x0603CBDC RID: 248796 RVA: 0x00F6CB4C File Offset: 0x00F6AD4C
		public void ActiveCameraControlRotationComponent()
		{
			this.UiCameraControlRotationComponent.InitDataByConfig(this.Data.CameraSettingConfig);
			this.UiCameraControlRotationComponent.SetNeedFloorReflection(true);
			SUiRoleCameraOffsetSetting? cameraOffsetConfig = this.Data.CameraOffsetConfig;
			FVector sourceLocation;
			if (cameraOffsetConfig != null)
			{
				UiCameraControlRotationComponent uiCameraControlRotationComponent = this.UiCameraControlRotationComponent;
				sourceLocation = this.Data.SourceLocation;
				uiCameraControlRotationComponent.UpdateData(sourceLocation, cameraOffsetConfig.Value.镜头浮动最大高度, cameraOffsetConfig.Value.镜头浮动最低高度, cameraOffsetConfig.Value.镜头浮动最长臂长, cameraOffsetConfig.Value.镜头浮动最短臂长);
				return;
			}
			UiCameraControlRotationComponent uiCameraControlRotationComponent2 = this.UiCameraControlRotationComponent;
			sourceLocation = this.Data.SourceLocation;
			uiCameraControlRotationComponent2.UpdateData(sourceLocation, 0f, 0f, 0f, 0f);
		}

		// Token: 0x0603CBDD RID: 248797 RVA: 0x00F6CC11 File Offset: 0x00F6AE11
		private void OnPlayCameraAnimationStart(UiCameraHandleData uiCameraHandleData, UiCameraHandleData cameraHandleData, string arg3)
		{
			this.TryDeActivate();
		}

		// Token: 0x0603CBDE RID: 248798 RVA: 0x00F6CC1A File Offset: 0x00F6AE1A
		private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
		{
			if (!handleData.GetUiCameraAnimationConfig().bTargetActorAsCenter)
			{
				return;
			}
			if (this.ComponentState == EComponentState.Activated)
			{
				this.DeActivate();
				this.Activate();
				return;
			}
			this.Activate();
		}

		// Token: 0x0603CBDF RID: 248799 RVA: 0x00F6CC46 File Offset: 0x00F6AE46
		private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
		}

		// Token: 0x0603CBE0 RID: 248800 RVA: 0x00F6CC64 File Offset: 0x00F6AE64
		private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput || Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1 || Singleton<InputSettings>.Instance.IsInputKeyDown("RightMouseButton"))
			{
				this.CurrentDragPosition = null;
				return;
			}
			FVector? currentDragPosition = this.CurrentDragPosition;
			this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
			if (currentDragPosition == null)
			{
				return;
			}
			float num = this.CurrentDragPosition.Value.X - currentDragPosition.Value.X;
			float num2 = this.CurrentDragPosition.Value.Y - currentDragPosition.Value.Y;
			if (num != 0f)
			{
				this.UiCameraControlRotationComponent.AddYawInput(num);
			}
			if (num2 != 0f)
			{
				this.UiCameraControlRotationComponent.AddPitchInput(num2);
			}
		}

		// Token: 0x0603CBE1 RID: 248801 RVA: 0x00F6CD2A File Offset: 0x00F6AF2A
		private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			this.CurrentDragPosition = null;
		}

		// Token: 0x0603CBE2 RID: 248802 RVA: 0x00F6CD41 File Offset: 0x00F6AF41
		private void OnPointerScrollCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			if (eventData.scrollAxisValue != 0f)
			{
				this.UiCameraControlRotationComponent.AddZoomInput(-eventData.scrollAxisValue);
			}
		}

		// Token: 0x0603CBE3 RID: 248803 RVA: 0x00F6CD6B File Offset: 0x00F6AF6B
		private void OnInputUiLookUp(float value)
		{
			if (!this.CanCameraInput || value == 0f || !Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.UiCameraControlRotationComponent.AddPitchInput(-value);
		}

		// Token: 0x0603CBE4 RID: 248804 RVA: 0x00F6CD97 File Offset: 0x00F6AF97
		private void OnInputUiTurn(float value)
		{
			if (!this.CanCameraInput || value == 0f || !Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.UiCameraControlRotationComponent.AddYawInput(value);
		}

		// Token: 0x0603CBE5 RID: 248805 RVA: 0x00F6CDC2 File Offset: 0x00F6AFC2
		private void OnInputUiZoom(string axisName, float value)
		{
			if (!this.CanCameraInput || value == 0f || !Singleton<Info>.Instance.IsInGamepad())
			{
				return;
			}
			this.UiCameraControlRotationComponent.AddZoomInput(value);
		}

		// Token: 0x0603CBE6 RID: 248806 RVA: 0x00F6CDF0 File Offset: 0x00F6AFF0
		private void OnRightStickPress()
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			UiCameraHandleData lastHandleData = Singleton<UiCameraAnimationManager>.Instance.GetLastHandleData();
			if (lastHandleData != null)
			{
				Singleton<UiCameraAnimationManager>.Instance.PushCameraHandleByHandleName(lastHandleData.HandleName, true, true, "1001", false, null, null);
			}
		}

		// Token: 0x0603CBE7 RID: 248807 RVA: 0x00F6CE37 File Offset: 0x00F6B037
		private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification _)
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			if (touchData.TouchType == InputDistributeDefine.ETouchType.TouchMove)
			{
				this.TouchMoved();
			}
		}

		// Token: 0x0603CBE8 RID: 248808 RVA: 0x00F6CE54 File Offset: 0x00F6B054
		private void TouchMoved()
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
			{
				float fingerExpandCloseValue = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseValue(EFingerIndex.One, EFingerIndex.Two);
				this.UiCameraControlRotationComponent.AddZoomInput(-fingerExpandCloseValue);
			}
		}

		// Token: 0x0402219C RID: 139676
		private IUiCameraInputComponentData Data;

		// Token: 0x0402219D RID: 139677
		private UiCameraControlRotationComponent UiCameraControlRotationComponent;

		// Token: 0x0402219E RID: 139678
		private FVector? CurrentDragPosition;

		// Token: 0x0402219F RID: 139679
		private EComponentState ComponentState;

		// Token: 0x040221A0 RID: 139680
		public bool CanCameraInput = true;
	}
}
