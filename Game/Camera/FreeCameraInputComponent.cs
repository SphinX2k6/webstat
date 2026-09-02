using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Camera
{
	// Token: 0x020070A8 RID: 28840
	[NullableContext(1)]
	[Nullable(0)]
	public class FreeCameraInputComponent : EntityComponent, IComponentDependency
	{
		// Token: 0x1700A5CA RID: 42442
		// (get) Token: 0x06045E91 RID: 286353 RVA: 0x012506E4 File Offset: 0x0124E8E4
		public static Type[] Dependencies
		{
			get
			{
				return new Type[]
				{
					typeof(FreeCameraLogicComponent)
				};
			}
		}

		// Token: 0x06045E92 RID: 286354 RVA: 0x012506F9 File Offset: 0x0124E8F9
		protected override bool OnStart()
		{
			this.LogicComponent = base.Entity.GetComponent<FreeCameraLogicComponent>();
			this.InitViewportSize();
			return this.LogicComponent != null;
		}

		// Token: 0x06045E93 RID: 286355 RVA: 0x0125071C File Offset: 0x0124E91C
		private void HandleInputDirty()
		{
			if (this.ForwardData.Distance == 0f && this.RightData.Distance == 0f && this.UpData.Distance == 0f && this.RotateLookUp == 0f && this.RotateTurn == 0f && this.DeltaFov == 0f)
			{
				this.IsInputDirty = false;
			}
		}

		// Token: 0x06045E94 RID: 286356 RVA: 0x01250790 File Offset: 0x0124E990
		private void ResetData()
		{
			this.ForwardData.Distance = 0f;
			this.RightData.Distance = 0f;
			this.UpData.Distance = 0f;
			this.RotateLookUp = 0f;
			this.RotateTurn = 0f;
			this.DeltaFov = 0f;
			this.IsInputDirty = false;
		}

		// Token: 0x06045E95 RID: 286357 RVA: 0x012507F8 File Offset: 0x0124E9F8
		protected override void OnTick(float delta)
		{
			if (!this.IsInputDirty)
			{
				return;
			}
			this.HandleInputDirty();
			FreeCameraLogicComponent logicComponent = this.LogicComponent;
			if (logicComponent != null)
			{
				logicComponent.ReceiveCameraInput(this.ForwardData, this.RightData, this.UpData, this.RotateLookUp, this.RotateTurn, this.DeltaFov, 0f, null, false);
			}
			this.ResetData();
		}

		// Token: 0x06045E96 RID: 286358 RVA: 0x01250858 File Offset: 0x0124EA58
		[NullableContext(2)]
		public void BindAxes(UUIDraggableComponent dragComponent = null)
		{
			ControllerBase<InputDistributeController>.Instance.BindAxes(new <>z__ReadOnlyArray<string>(new string[]
			{
				"Zoom",
				"UiIncrease",
				"UiReduce"
			}), new TInputHandle<float>(this.InputCameraFov));
			ControllerBase<InputDistributeController>.Instance.BindAxis("MoveForward", new TInputHandle<float>(this.InputCameraForward));
			ControllerBase<InputDistributeController>.Instance.BindAxis("MoveRight", new TInputHandle<float>(this.InputCameraRight));
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveForward", new TInputHandle<float>(this.InputCameraForward));
			ControllerBase<InputDistributeController>.Instance.BindAxis("UiMoveRight", new TInputHandle<float>(this.InputCameraRight));
			ControllerBase<InputDistributeController>.Instance.BindAxis("LookUp", new TInputHandle<float>(this.InputCameraLookUp));
			ControllerBase<InputDistributeController>.Instance.BindAxis("Turn", new TInputHandle<float>(this.InputCameraTurn));
			this.DragComponent = dragComponent;
			if (this.DragComponent != null)
			{
				this.DragComponent.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDragCallBack));
				this.DragComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
				this.DragComponent.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndDragCallBack));
				this.DragComponent.OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerScrollCallBack));
			}
			ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
			{
				0,
				1
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x06045E97 RID: 286359 RVA: 0x012509E0 File Offset: 0x0124EBE0
		public void UnBindAxes()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAxes(new <>z__ReadOnlyArray<string>(new string[]
			{
				"Zoom",
				"UiIncrease",
				"UiReduce"
			}), new TInputHandle<float>(this.InputCameraFov));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("MoveForward", new TInputHandle<float>(this.InputCameraForward));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("MoveRight", new TInputHandle<float>(this.InputCameraRight));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveForward", new TInputHandle<float>(this.InputCameraForward));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("UiMoveRight", new TInputHandle<float>(this.InputCameraRight));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("LookUp", new TInputHandle<float>(this.InputCameraLookUp));
			ControllerBase<InputDistributeController>.Instance.UnBindAxis("Turn", new TInputHandle<float>(this.InputCameraTurn));
			if (this.DragComponent != null)
			{
				this.DragComponent.OnPointerBeginDragCallBack.Unbind();
				this.DragComponent.OnPointerDragCallBack.Unbind();
				this.DragComponent.OnPointerEndDragCallBack.Unbind();
				this.DragComponent.OnPointerScrollCallBack.Unbind();
				this.DragComponent = null;
			}
			ControllerBase<InputDistributeController>.Instance.UnBindTouches(new <>z__ReadOnlyArray<int>(new int[]
			{
				0,
				1
			}), new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
		}

		// Token: 0x06045E98 RID: 286360 RVA: 0x01250B3C File Offset: 0x0124ED3C
		private void InitViewportSize()
		{
			this.ViewportSize.X = (double)Singleton<UiLayer>.Instance.UiRootItem.GetWidth();
			this.ViewportSize.Y = (double)Singleton<UiLayer>.Instance.UiRootItem.GetHeight();
		}

		// Token: 0x06045E99 RID: 286361 RVA: 0x01250B74 File Offset: 0x0124ED74
		protected void InputCameraFov(string axisName, float value, InputIdentification inputIdentification)
		{
			this.InputCameraFieldFov(value * 1f);
		}

		// Token: 0x06045E9A RID: 286362 RVA: 0x01250B83 File Offset: 0x0124ED83
		protected void InputCameraForward(string axisName, float value, InputIdentification inputIdentification)
		{
			this.InputCameraMoveForward(value * 10f);
		}

		// Token: 0x06045E9B RID: 286363 RVA: 0x01250B92 File Offset: 0x0124ED92
		protected void InputCameraRight(string axisName, float value, InputIdentification inputIdentification)
		{
			this.InputCameraMoveRight(value * 10f);
		}

		// Token: 0x06045E9C RID: 286364 RVA: 0x01250BA1 File Offset: 0x0124EDA1
		protected void InputCameraUp(string axisName, float value, InputIdentification inputIdentification)
		{
			this.InputCameraMoveUp(value * 10f);
		}

		// Token: 0x06045E9D RID: 286365 RVA: 0x01250BB0 File Offset: 0x0124EDB0
		protected void InputCameraLookUp(string axisName, float value, InputIdentification inputIdentification)
		{
			this.InputCameraRotateLookUp(-value * 3f);
		}

		// Token: 0x06045E9E RID: 286366 RVA: 0x01250BC0 File Offset: 0x0124EDC0
		protected void InputCameraTurn(string axisName, float value, InputIdentification inputIdentification)
		{
			this.InputCameraRotateTurn(value * 3f);
		}

		// Token: 0x06045E9F RID: 286367 RVA: 0x01250BCF File Offset: 0x0124EDCF
		public void InputCameraMoveForward(float value)
		{
			if (value == 0f)
			{
				return;
			}
			this.ForwardData.Distance = value;
			this.IsInputDirty = true;
		}

		// Token: 0x06045EA0 RID: 286368 RVA: 0x01250BED File Offset: 0x0124EDED
		public void InputCameraMoveRight(float value)
		{
			if (value == 0f)
			{
				return;
			}
			this.RightData.Distance = value;
			this.IsInputDirty = true;
		}

		// Token: 0x06045EA1 RID: 286369 RVA: 0x01250C0B File Offset: 0x0124EE0B
		public void InputCameraMoveUp(float value)
		{
			if (value == 0f)
			{
				return;
			}
			this.UpData.Distance = value;
			this.IsInputDirty = true;
		}

		// Token: 0x06045EA2 RID: 286370 RVA: 0x01250C29 File Offset: 0x0124EE29
		public void InputCameraRotateLookUp(float value)
		{
			if (value == 0f && this.RotateLookUp == 0f)
			{
				return;
			}
			this.RotateLookUp = value;
			this.IsInputDirty = true;
		}

		// Token: 0x06045EA3 RID: 286371 RVA: 0x01250C4F File Offset: 0x0124EE4F
		public void InputCameraRotateTurn(float value)
		{
			if (value == 0f && this.RotateTurn == 0f)
			{
				return;
			}
			this.RotateTurn = value;
			this.IsInputDirty = true;
		}

		// Token: 0x06045EA4 RID: 286372 RVA: 0x01250C75 File Offset: 0x0124EE75
		public void InputCameraFieldFov(float value)
		{
			if (value == 0f)
			{
				return;
			}
			this.DeltaFov = value;
			this.IsInputDirty = true;
		}

		// Token: 0x06045EA5 RID: 286373 RVA: 0x01250C8E File Offset: 0x0124EE8E
		public void SetIsMoveBySelf(bool isMoveBySelf)
		{
			this.ForwardData.IsMoveBySelf = isMoveBySelf;
			this.RightData.IsMoveBySelf = isMoveBySelf;
			this.UpData.IsMoveBySelf = isMoveBySelf;
		}

		// Token: 0x06045EA6 RID: 286374 RVA: 0x01250CB4 File Offset: 0x0124EEB4
		public void SetUpMoveByWorld()
		{
			this.UpData.IsMoveBySelf = false;
		}

		// Token: 0x06045EA7 RID: 286375 RVA: 0x01250CC2 File Offset: 0x0124EEC2
		public void SetForwardMoveByWorld()
		{
			this.ForwardData.IsMoveBySelf = false;
		}

		// Token: 0x06045EA8 RID: 286376 RVA: 0x01250CD0 File Offset: 0x0124EED0
		public void SetRightMoveByWorld()
		{
			this.RightData.IsMoveBySelf = false;
		}

		// Token: 0x06045EA9 RID: 286377 RVA: 0x01250CDE File Offset: 0x0124EEDE
		[NullableContext(2)]
		private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			this.PointerDownTime = Singleton<Time>.Instance.NowSeconds;
			this.CurrentDragPosition = new FVector?(eventData.GetLocalPointInPlane());
		}

		// Token: 0x06045EAA RID: 286378 RVA: 0x01250D0C File Offset: 0x0124EF0C
		[NullableContext(2)]
		private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput || Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1 || Singleton<InputSettings>.Instance.IsInputKeyDown("RightMouseButton"))
			{
				this.CurrentDragPosition = null;
				this.DragDeltaPos.Reset();
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
			this.DragDeltaPos = Vector2D.Create((double)num, (double)num2);
			if (num != 0f)
			{
				this.InputCameraMoveRight(-num);
			}
			if (num2 != 0f)
			{
				this.InputCameraMoveForward(-num2);
			}
		}

		// Token: 0x06045EAB RID: 286379 RVA: 0x01250DE4 File Offset: 0x0124EFE4
		[NullableContext(2)]
		private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			if (!this.DragDeltaPos.Normalize(0.0))
			{
				this.DragDeltaPos.Reset();
				return;
			}
			double num = Singleton<Time>.Instance.NowSeconds - this.PointerDownTime;
			float num2 = (float)Singleton<MathUtils>.Instance.Clamp(this.DragDeltaPos.X / num, -this.ViewportSize.X, this.ViewportSize.X);
			float num3 = (float)Singleton<MathUtils>.Instance.Clamp(this.DragDeltaPos.Y / num, -this.ViewportSize.Y, this.ViewportSize.Y);
			this.RightData.Distance = 2f * num2;
			this.ForwardData.Distance = 2f * num3;
			FreeCameraLogicComponent logicComponent = this.LogicComponent;
			if (logicComponent != null)
			{
				logicComponent.ReceiveCameraInput(this.ForwardData, this.RightData, this.UpData, this.RotateLookUp, this.RotateTurn, this.DeltaFov, 0.8f, CurveUtils.CreateCurve(ECurveType.Squared, new float[]
				{
					0.5f
				}), true);
			}
			this.ResetData();
			this.CurrentDragPosition = null;
		}

		// Token: 0x06045EAC RID: 286380 RVA: 0x01250F13 File Offset: 0x0124F113
		[NullableContext(2)]
		private void OnPointerScrollCallBack(ULGUIPointerEventData eventData)
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			if (eventData.scrollAxisValue != 0f)
			{
				this.InputCameraFieldFov(eventData.scrollAxisValue);
			}
		}

		// Token: 0x06045EAD RID: 286381 RVA: 0x01250F37 File Offset: 0x0124F137
		private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification inputIdentification)
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

		// Token: 0x06045EAE RID: 286382 RVA: 0x01250F54 File Offset: 0x0124F154
		private void TouchMoved()
		{
			if (!this.CanCameraInput)
			{
				return;
			}
			if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
			{
				float fingerExpandCloseValue = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseValue(EFingerIndex.One, EFingerIndex.Two);
				this.InputCameraFieldFov(fingerExpandCloseValue);
			}
		}

		// Token: 0x06045EAF RID: 286383 RVA: 0x01250F8C File Offset: 0x0124F18C
		public void ResetInputData()
		{
			this.ForwardData.Distance = 0f;
			this.RightData.Distance = 0f;
			this.UpData.Distance = 0f;
			this.RotateLookUp = 0f;
			this.RotateTurn = 0f;
			this.DeltaFov = 0f;
			this.IsInputDirty = false;
			FreeCameraLogicComponent logicComponent = this.LogicComponent;
			if (logicComponent == null)
			{
				return;
			}
			logicComponent.ResetToInit(0f, null, null);
		}

		// Token: 0x06045EB0 RID: 286384 RVA: 0x01251008 File Offset: 0x0124F208
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			FreeCameraInputComponent freeCameraInputComponent = (FreeCameraInputComponent)componentTemplate;
			if (base.CanResetComponentProperty("LogicComponent"))
			{
				if (freeCameraInputComponent.LogicComponent == null)
				{
					this.LogicComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<FreeCameraLogicComponent>(this.LogicComponent), "LogicComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("IsInputDirty"))
			{
				this.IsInputDirty = freeCameraInputComponent.IsInputDirty;
			}
			if (base.CanResetComponentProperty("ForwardData") && freeCameraInputComponent.ForwardData != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<FreeCameraLogicComponent.ICameraMoveData>(this.ForwardData), "ForwardData"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("RightData") && freeCameraInputComponent.RightData != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<FreeCameraLogicComponent.ICameraMoveData>(this.RightData), "RightData"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("UpData") && freeCameraInputComponent.UpData != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<FreeCameraLogicComponent.ICameraMoveData>(this.UpData), "UpData"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("RotateLookUp"))
			{
				this.RotateLookUp = freeCameraInputComponent.RotateLookUp;
			}
			if (base.CanResetComponentProperty("RotateTurn"))
			{
				this.RotateTurn = freeCameraInputComponent.RotateTurn;
			}
			if (base.CanResetComponentProperty("DeltaFov"))
			{
				this.DeltaFov = freeCameraInputComponent.DeltaFov;
			}
			if (base.CanResetComponentProperty("DragComponent"))
			{
				if (freeCameraInputComponent.DragComponent == null)
				{
					this.DragComponent = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<UUIDraggableComponent>(this.DragComponent), "DragComponent"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurrentDragPosition"))
			{
				this.CurrentDragPosition = freeCameraInputComponent.CurrentDragPosition;
			}
			if (base.CanResetComponentProperty("DragDeltaPos"))
			{
				if (freeCameraInputComponent.DragDeltaPos == null)
				{
					this.DragDeltaPos = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Vector2D>(this.DragDeltaPos), "DragDeltaPos"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CanCameraInput"))
			{
				this.CanCameraInput = freeCameraInputComponent.CanCameraInput;
			}
			if (base.CanResetComponentProperty("PointerDownTime"))
			{
				this.PointerDownTime = freeCameraInputComponent.PointerDownTime;
			}
			return !base.CanResetComponentProperty("ViewportSize") || freeCameraInputComponent.ViewportSize == null || base.CheckClearObject(EntityComponentSystem.ClearObject<Vector2D>(this.ViewportSize), "ViewportSize");
		}

		// Token: 0x04027266 RID: 160358
		private const int MOVE_STEP = 10;

		// Token: 0x04027267 RID: 160359
		private const int ROTATE_STEP = 3;

		// Token: 0x04027268 RID: 160360
		private const int FOV_STEP = 1;

		// Token: 0x04027269 RID: 160361
		private const float TWEEN_TIME = 2f;

		// Token: 0x0402726A RID: 160362
		private const float DRAG_TWEEN_TIME = 0.8f;

		// Token: 0x0402726B RID: 160363
		[Nullable(2)]
		private FreeCameraLogicComponent LogicComponent;

		// Token: 0x0402726C RID: 160364
		private bool IsInputDirty;

		// Token: 0x0402726D RID: 160365
		private readonly FreeCameraLogicComponent.ICameraMoveData ForwardData = new FreeCameraLogicComponent.CameraMoveDataImpl
		{
			Distance = 0f,
			IsMoveBySelf = true
		};

		// Token: 0x0402726E RID: 160366
		private readonly FreeCameraLogicComponent.ICameraMoveData RightData = new FreeCameraLogicComponent.CameraMoveDataImpl
		{
			Distance = 0f,
			IsMoveBySelf = true
		};

		// Token: 0x0402726F RID: 160367
		private readonly FreeCameraLogicComponent.ICameraMoveData UpData = new FreeCameraLogicComponent.CameraMoveDataImpl
		{
			Distance = 0f,
			IsMoveBySelf = true
		};

		// Token: 0x04027270 RID: 160368
		private float RotateLookUp;

		// Token: 0x04027271 RID: 160369
		private float RotateTurn;

		// Token: 0x04027272 RID: 160370
		private float DeltaFov;

		// Token: 0x04027273 RID: 160371
		[Nullable(2)]
		private UUIDraggableComponent DragComponent;

		// Token: 0x04027274 RID: 160372
		private FVector? CurrentDragPosition;

		// Token: 0x04027275 RID: 160373
		private Vector2D DragDeltaPos = Vector2D.Create();

		// Token: 0x04027276 RID: 160374
		public bool CanCameraInput;

		// Token: 0x04027277 RID: 160375
		private double PointerDownTime;

		// Token: 0x04027278 RID: 160376
		private readonly Vector2D ViewportSize = Vector2D.Create();
	}
}
