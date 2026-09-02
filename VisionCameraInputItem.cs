using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020024F1 RID: 9457
[NullableContext(1)]
[Nullable(0)]
public class VisionCameraInputItem : UiPanelBase
{
	// Token: 0x060125D5 RID: 75221 RVA: 0x0050CC9F File Offset: 0x0050AE9F
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIDraggableComponent))
		};
	}

	// Token: 0x060125D6 RID: 75222 RVA: 0x0050CCC4 File Offset: 0x0050AEC4
	protected void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<UiCameraHandleData, UiCameraHandleData, string>(EEventName.OnPlayCameraAnimationStart, new Action<UiCameraHandleData, UiCameraHandleData, string>(this.OnPlayCameraAnimationStart));
		Singleton<EventSystem>.Instance.Add<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		UUIDraggableComponent draggable = base.GetDraggable(0);
		draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDragCallBack));
		draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
		draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndDragCallBack));
		draggable.OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerScrollCallBack));
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiLookUp", new TInputHandle<float>(this.OnInputUiLookUp));
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiTurn));
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiIncrease", new TInputHandle<float>(this.OnInputUiIncrease));
		ControllerBase<InputDistributeController>.Instance.BindAxis("UiReduce", new TInputHandle<float>(this.OnInputUiReduce));
		ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
		{
			0,
			1
		}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
	}

	// Token: 0x060125D7 RID: 75223 RVA: 0x0050CDF8 File Offset: 0x0050AFF8
	protected void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayCameraAnimationStart, new Action<UiCameraHandleData, UiCameraHandleData, string>(this.OnPlayCameraAnimationStart));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
		UUIDraggableComponent draggable = base.GetDraggable(0);
		draggable.OnPointerBeginDragCallBack.Unbind();
		draggable.OnPointerDragCallBack.Unbind();
		draggable.OnPointerEndDragCallBack.Unbind();
		draggable.OnPointerScrollCallBack.Unbind();
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiLookUp", new TInputHandle<float>(this.OnInputUiLookUp));
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiTurn", new TInputHandle<float>(this.OnInputUiTurn));
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiIncrease", new TInputHandle<float>(this.OnInputUiIncrease));
		ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiReduce", new TInputHandle<float>(this.OnInputUiReduce));
		ControllerBase<InputDistributeController>.Instance.UnBindTouches(new <>z__ReadOnlyArray<int>(new int[]
		{
			0,
			1
		}), new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
	}

	// Token: 0x060125D8 RID: 75224 RVA: 0x0050CF00 File Offset: 0x0050B100
	protected override void OnStart()
	{
		this.InitCameraComponent();
	}

	// Token: 0x060125D9 RID: 75225 RVA: 0x0050CF08 File Offset: 0x0050B108
	protected override void OnBeforeShow()
	{
		this.OnActivateUiCameraAnimationHandle(null);
		this.OnAddEventListener();
	}

	// Token: 0x060125DA RID: 75226 RVA: 0x0050CF17 File Offset: 0x0050B117
	protected override void OnBeforeHide()
	{
		UiCameraControlRotationComponent uiCameraControlRotationComponent = this.UiCameraControlRotationComponent;
		if (uiCameraControlRotationComponent != null)
		{
			uiCameraControlRotationComponent.Deactivate();
		}
		this.OnRemoveEventListener();
		this.CanCameraInput = false;
	}

	// Token: 0x060125DB RID: 75227 RVA: 0x0050CF37 File Offset: 0x0050B137
	protected override void OnBeforeDestroy()
	{
		this.DestroyCameraComponent();
	}

	// Token: 0x060125DC RID: 75228 RVA: 0x0050CF3F File Offset: 0x0050B13F
	public void OnPlayCameraAnimationStart(UiCameraHandleData uiCameraHandleData, UiCameraHandleData cameraHandleData, string arg3)
	{
		this.Pause();
	}

	// Token: 0x060125DD RID: 75229 RVA: 0x0050CF47 File Offset: 0x0050B147
	public void Pause()
	{
		this.CanCameraInput = false;
		UiCameraControlRotationComponent uiCameraControlRotationComponent = this.UiCameraControlRotationComponent;
		if (uiCameraControlRotationComponent == null)
		{
			return;
		}
		uiCameraControlRotationComponent.PauseTick();
	}

	// Token: 0x060125DE RID: 75230 RVA: 0x0050CF60 File Offset: 0x0050B160
	private void InitCameraComponent()
	{
		UiCamera uiCamera = UiCameraManager.Get();
		this.UiCameraControlRotationComponent = (uiCamera.AddUiCameraComponent(typeof(UiCameraControlRotationComponent), false) as UiCameraControlRotationComponent);
		SUiRoleCameraSetting? roleCameraConfig = ConfigBase<UiRoleCameraConfig>.Instance.GetRoleCameraConfig("声骸");
		this.UiCameraControlRotationComponent.InitDataByConfig(roleCameraConfig.Value);
	}

	// Token: 0x060125DF RID: 75231 RVA: 0x0050CFB1 File Offset: 0x0050B1B1
	private void DestroyCameraComponent()
	{
		UiCameraManager.Get().DestroyUiCameraComponent(typeof(UiCameraControlRotationComponent));
		this.UiCameraControlRotationComponent = null;
	}

	// Token: 0x060125E0 RID: 75232 RVA: 0x0050CFD0 File Offset: 0x0050B1D0
	public void OnActivateUiCameraAnimationHandle(UiCameraHandleData uiCameraHandleData)
	{
		this.CanCameraInput = this.CheckCanCameraInput();
		if (this.CanCameraInput && this.UiCameraControlRotationComponent != null)
		{
			FVectorDouble sourceLocation = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("MonsterCase").Value, ECollectActorType.UI).D_K2_GetActorLocation();
			this.UiCameraControlRotationComponent.UpdateData(sourceLocation, 0f, 0f, 0f, 0f);
			this.UiCameraControlRotationComponent.Activate();
			this.UiCameraControlRotationComponent.ResumeTick();
		}
	}

	// Token: 0x060125E1 RID: 75233 RVA: 0x0050D04D File Offset: 0x0050B24D
	private bool CheckCanCameraInput()
	{
		return !Singleton<UiCameraAnimationManager>.Instance.IsPlayingAnimation();
	}

	// Token: 0x060125E2 RID: 75234 RVA: 0x0050D05C File Offset: 0x0050B25C
	[NullableContext(2)]
	private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!this.CanCameraInput)
		{
			return;
		}
		this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
	}

	// Token: 0x060125E3 RID: 75235 RVA: 0x0050D078 File Offset: 0x0050B278
	[NullableContext(2)]
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
		if (num != 0f)
		{
			this.UiCameraControlRotationComponent.AddYawInput(num);
		}
		float num2 = this.CurrentDragPosition.Value.Y - currentDragPosition.Value.Y;
		if (num2 != 0f && this.CanPitchInput)
		{
			this.UiCameraControlRotationComponent.AddPitchInput(num2);
		}
	}

	// Token: 0x060125E4 RID: 75236 RVA: 0x0050D146 File Offset: 0x0050B346
	[NullableContext(2)]
	private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!this.CanCameraInput)
		{
			return;
		}
		this.CurrentDragPosition = null;
	}

	// Token: 0x060125E5 RID: 75237 RVA: 0x0050D15D File Offset: 0x0050B35D
	private void OnInputUiLookUp(string axisName, float value, InputIdentification _)
	{
		if (value == 0f || !this.CanCameraInput || !Singleton<Info>.Instance.IsInGamepad() || !this.CanPitchInput)
		{
			return;
		}
		this.UiCameraControlRotationComponent.AddPitchInput(-value);
	}

	// Token: 0x060125E6 RID: 75238 RVA: 0x0050D191 File Offset: 0x0050B391
	private void OnInputUiTurn(string axisName, float value, InputIdentification _)
	{
		if (value == 0f || !this.CanCameraInput || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.UiCameraControlRotationComponent.AddYawInput(value);
	}

	// Token: 0x060125E7 RID: 75239 RVA: 0x0050D1BC File Offset: 0x0050B3BC
	[NullableContext(2)]
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

	// Token: 0x060125E8 RID: 75240 RVA: 0x0050D1E6 File Offset: 0x0050B3E6
	private void OnInputUiIncrease(string axisName, float value, InputIdentification _)
	{
		if (value == 0f || !this.CanCameraInput || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.UiCameraControlRotationComponent.AddZoomInput(value);
	}

	// Token: 0x060125E9 RID: 75241 RVA: 0x0050D211 File Offset: 0x0050B411
	private void OnInputUiReduce(string axisName, float value, InputIdentification _)
	{
		if (value == 0f || !this.CanCameraInput || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.UiCameraControlRotationComponent.AddZoomInput(value);
	}

	// Token: 0x060125EA RID: 75242 RVA: 0x0050D23C File Offset: 0x0050B43C
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

	// Token: 0x060125EB RID: 75243 RVA: 0x0050D258 File Offset: 0x0050B458
	private void TouchMoved()
	{
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
		{
			float fingerExpandCloseValue = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseValue(EFingerIndex.One, EFingerIndex.Two);
			this.UiCameraControlRotationComponent.AddZoomInput(-fingerExpandCloseValue);
		}
	}

	// Token: 0x04008F3C RID: 36668
	private bool CanCameraInput;

	// Token: 0x04008F3D RID: 36669
	public bool CanPitchInput;

	// Token: 0x04008F3E RID: 36670
	[Nullable(2)]
	private UiCameraControlRotationComponent UiCameraControlRotationComponent;

	// Token: 0x04008F3F RID: 36671
	private FVector? CurrentDragPosition;

	// Token: 0x02008807 RID: 34823
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DF45 RID: 188229
		DragItem
	}
}
