using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054BC RID: 21692
	[NullableContext(1)]
	[Nullable(0)]
	public class DragInteractComponent
	{
		// Token: 0x17008E8E RID: 36494
		// (get) Token: 0x060373FD RID: 226301 RVA: 0x00E03D1D File Offset: 0x00E01F1D
		public bool IsJoystickZoom
		{
			get
			{
				return this.ZoomAxis != "";
			}
		}

		// Token: 0x17008E8F RID: 36495
		// (get) Token: 0x060373FE RID: 226302 RVA: 0x00E03D2F File Offset: 0x00E01F2F
		public Vector2D MultiTouchOriginCenter
		{
			get
			{
				return this.InternalMultiTouchOriginCenter;
			}
		}

		// Token: 0x060373FF RID: 226303 RVA: 0x00E03D38 File Offset: 0x00E01F38
		public DragInteractComponent(IDragInteractParam param)
		{
			this.Draggable = param.Draggable;
			this.CallbackOnDown = param.CallbackOnDown;
			this.CallbackOnDrag = param.CallbackOnDrag;
			this.CallbackOnInertia = param.CallbackOnInertia;
			this.TouchMap = new Dictionary<int, InputDistributeDefine.ITouchData>();
			this.Draggable.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDown));
			this.Draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDrag));
			this.Draggable.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
			this.Draggable.OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnWheelAxisInput));
			this.PointerDeltaPosition = Vector2D.Create();
			this.PrevPointerDownPosition = Vector2D.Create();
		}

		// Token: 0x17008E90 RID: 36496
		// (get) Token: 0x06037400 RID: 226304 RVA: 0x00E03E22 File Offset: 0x00E02022
		public bool IsDragging
		{
			get
			{
				return this.Dragging;
			}
		}

		// Token: 0x17008E91 RID: 36497
		// (get) Token: 0x06037401 RID: 226305 RVA: 0x00E03E2C File Offset: 0x00E0202C
		private Vector2D DragSize
		{
			get
			{
				UUIDraggableComponent draggable = this.Draggable;
				double x = (double)((draggable != null) ? draggable.RootUIComp.Get().Width : 0f);
				UUIDraggableComponent draggable2 = this.Draggable;
				return Vector2D.Create(x, (double)((draggable2 != null) ? draggable2.RootUIComp.Get().Height : 0f));
			}
		}

		// Token: 0x17008E92 RID: 36498
		// (get) Token: 0x06037402 RID: 226306 RVA: 0x00E03E86 File Offset: 0x00E02086
		public bool IsJoystickMoving
		{
			get
			{
				return this.JoystickMovingRight || this.JoystickMovingForward;
			}
		}

		// Token: 0x17008E93 RID: 36499
		// (get) Token: 0x06037403 RID: 226307 RVA: 0x00E03E98 File Offset: 0x00E02098
		public bool IsJoystickFocus
		{
			get
			{
				return this.JoystickFocus;
			}
		}

		// Token: 0x06037404 RID: 226308 RVA: 0x00E03EA0 File Offset: 0x00E020A0
		public void SetJoystickFocus(bool value)
		{
			this.JoystickFocus = value;
		}

		// Token: 0x17008E94 RID: 36500
		// (get) Token: 0x06037405 RID: 226309 RVA: 0x00E03EA9 File Offset: 0x00E020A9
		// (set) Token: 0x06037406 RID: 226310 RVA: 0x00E03EB1 File Offset: 0x00E020B1
		public bool IsMultiFingerControl
		{
			get
			{
				return this.MultiFingerControl;
			}
			set
			{
				if (value != this.MultiFingerControl)
				{
					if (!value && this.TouchMap.Count > 0)
					{
						return;
					}
					this.MultiFingerControl = value;
					if (!this.MultiFingerControl)
					{
						this.LastMultiTouchEndTime = Singleton<Time>.Instance.NowSeconds;
					}
				}
			}
		}

		// Token: 0x06037407 RID: 226311 RVA: 0x00E03EED File Offset: 0x00E020ED
		public void Enable()
		{
			this.AddEventListener();
		}

		// Token: 0x06037408 RID: 226312 RVA: 0x00E03EF5 File Offset: 0x00E020F5
		public void Disable()
		{
			this.RemoveEventListener();
		}

		// Token: 0x06037409 RID: 226313 RVA: 0x00E03F00 File Offset: 0x00E02100
		private void AddEventListener()
		{
			ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
			{
				0,
				1
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerMapForward, new Action<float>(this.OnUiForwardInput));
			Singleton<EventSystem>.Instance.Add<float>(EEventName.NavigationTriggerMapRight, new Action<float>(this.OnUiRightInput));
			Singleton<EventSystem>.Instance.Add<string, float>(EEventName.NavigationTriggerMapZoom, new Action<string, float>(this.OnHandleTriggerInput));
		}

		// Token: 0x0603740A RID: 226314 RVA: 0x00E03F84 File Offset: 0x00E02184
		private void RemoveEventListener()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindTouches(new int[]
			{
				0,
				1
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerMapForward, new Action<float>(this.OnUiForwardInput));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerMapRight, new Action<float>(this.OnUiRightInput));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerMapZoom, new Action<string, float>(this.OnHandleTriggerInput));
		}

		// Token: 0x0603740B RID: 226315 RVA: 0x00E04008 File Offset: 0x00E02208
		[NullableContext(2)]
		private void OnPointerDown(ULGUIPointerEventData eventData)
		{
			this.Dragging = false;
			if (eventData == null || this.IsMultiFingerControl)
			{
				return;
			}
			Vector2D inV = this.MousePositionConvertToLgui((double)eventData.pointerPosition.X, (double)eventData.pointerPosition.Y);
			this.PrevPointerDownPosition.DeepCopy(inV);
			this.PointerDownTime = Singleton<Time>.Instance.NowSeconds;
			Action callbackOnDown = this.CallbackOnDown;
			if (callbackOnDown == null)
			{
				return;
			}
			callbackOnDown();
		}

		// Token: 0x0603740C RID: 226316 RVA: 0x00E04074 File Offset: 0x00E02274
		[NullableContext(2)]
		private void OnPointerDrag(ULGUIPointerEventData eventData)
		{
			if (eventData == null || this.IsMultiFingerControl || this.TouchMap.Count > 1)
			{
				this.Dragging = false;
				this.PointerDeltaPosition.Reset();
				return;
			}
			this.Dragging = true;
			Vector2D vector2D = this.MousePositionConvertToLgui((double)eventData.pointerPosition.X, (double)eventData.pointerPosition.Y);
			Vector2D vector2D2 = Vector2D.Create(vector2D.X, vector2D.Y).SubtractionEqual(this.PrevPointerDownPosition);
			if (vector2D2.X == 0.0 && vector2D2.Y == 0.0)
			{
				return;
			}
			this.PointerDeltaPosition.DeepCopy(vector2D2);
			this.PrevPointerDownPosition.DeepCopy(vector2D);
			Action<Vector2D> callbackOnDrag = this.CallbackOnDrag;
			if (callbackOnDrag == null)
			{
				return;
			}
			callbackOnDrag(this.PointerDeltaPosition);
		}

		// Token: 0x0603740D RID: 226317 RVA: 0x00E04144 File Offset: 0x00E02344
		[NullableContext(2)]
		private void OnPointerUp(ULGUIPointerEventData eventData)
		{
			double nowSeconds = Singleton<Time>.Instance.NowSeconds;
			if (this.IsMultiFingerControl || nowSeconds - this.LastMultiTouchEndTime < 0.5)
			{
				return;
			}
			this.Dragging = false;
			this.DragInertia();
		}

		// Token: 0x0603740E RID: 226318 RVA: 0x00E04188 File Offset: 0x00E02388
		private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification _)
		{
			InputDistributeDefine.ETouchType touchType = touchData.TouchType;
			int touchId = int.Parse(touchIdName);
			if (touchType == InputDistributeDefine.ETouchType.TouchBegin)
			{
				this.TouchTrigger(true, touchId, touchData);
				return;
			}
			if (touchType != InputDistributeDefine.ETouchType.TouchEnd)
			{
				return;
			}
			this.TouchTrigger(false, touchId, null);
		}

		// Token: 0x0603740F RID: 226319 RVA: 0x00E041BE File Offset: 0x00E023BE
		[NullableContext(2)]
		private void OnWheelAxisInput(ULGUIPointerEventData eventData)
		{
		}

		// Token: 0x06037410 RID: 226320 RVA: 0x00E041C0 File Offset: 0x00E023C0
		[NullableContext(2)]
		private void TouchTrigger(bool bTouchPress, int touchId, InputDistributeDefine.ITouchData touchData = null)
		{
			if (bTouchPress)
			{
				if (Singleton<LguiEventSystemManager>.Instance.IsPressComponentIsValid(touchId))
				{
					this.TouchMap[touchId] = touchData;
				}
			}
			else
			{
				this.TouchMap.Remove(touchId);
			}
			this.InternalMultiTouchOriginCenter.Reset();
			foreach (InputDistributeDefine.ITouchData touchData2 in this.TouchMap.Values)
			{
				Vector2D b = Vector2D.Create(touchData2.TouchPosition.X, touchData2.TouchPosition.Y);
				this.InternalMultiTouchOriginCenter.AdditionEqual(b);
			}
			if (this.TouchMap.Count > 0)
			{
				this.InternalMultiTouchOriginCenter.DivisionEqual((double)this.TouchMap.Count);
			}
		}

		// Token: 0x06037411 RID: 226321 RVA: 0x00E04298 File Offset: 0x00E02498
		private Vector2D MousePositionConvertToLgui(double x, double y)
		{
			Vector2D vector2D = Vector2D.Create(x, y);
			Vector2D vector2D2 = vector2D;
			ULGUICanvasScaler canvasScaler = Singleton<UiLayer>.Instance.UiRootItem.GetCanvasScaler();
			FVector2D fvector2D = vector2D.ToUeVector2D(false);
			vector2D2.FromUeVector2D(canvasScaler.ConvertPositionFromViewportToLGUICanvas(fvector2D));
			return vector2D;
		}

		// Token: 0x06037412 RID: 226322 RVA: 0x00E042D8 File Offset: 0x00E024D8
		private void DragInertia()
		{
			if (this.PointerDeltaPosition.X == 0.0 && this.PointerDeltaPosition.Y == 0.0)
			{
				return;
			}
			double num = Singleton<Time>.Instance.NowSeconds - this.PointerDownTime;
			double num2 = this.PointerDeltaPosition.Size();
			double num3 = 2.0 * num2 / (num * num) * num;
			if (!this.DragSize.IsNearlyZero(9.999999747378752E-05))
			{
				num3 = MathCommon.Clamp(num3, 0.0, this.DragSize.Size());
			}
			if (!this.PointerDeltaPosition.Normalize(0.0))
			{
				this.PointerDeltaPosition.Reset();
				return;
			}
			Vector2D vector2D = Vector2D.Create();
			this.PointerDeltaPosition.Multiply(num3, vector2D);
			Action<Vector2D> callbackOnInertia = this.CallbackOnInertia;
			if (callbackOnInertia != null)
			{
				callbackOnInertia(vector2D);
			}
			this.PointerDeltaPosition.Reset();
		}

		// Token: 0x06037413 RID: 226323 RVA: 0x00E043C6 File Offset: 0x00E025C6
		private void OnHandleTriggerInput(string axisName, float value)
		{
			if (value == 0f)
			{
				if (this.ZoomAxis == axisName)
				{
					this.ZoomAxis = "";
				}
				return;
			}
			this.ZoomAxis = axisName;
		}

		// Token: 0x06037414 RID: 226324 RVA: 0x00E043F1 File Offset: 0x00E025F1
		private void OnUiForwardInput(float value)
		{
			if (value == 0f)
			{
				this.JoystickMovingForward = false;
				return;
			}
			this.JoystickMovingForward = true;
			this.JoystickFocus = false;
		}

		// Token: 0x06037415 RID: 226325 RVA: 0x00E04411 File Offset: 0x00E02611
		private void OnUiRightInput(float value)
		{
			if (value == 0f)
			{
				this.JoystickMovingRight = false;
				return;
			}
			this.JoystickMovingRight = true;
			this.JoystickFocus = false;
		}

		// Token: 0x0401FC2D RID: 130093
		[Nullable(2)]
		private readonly UUIDraggableComponent Draggable;

		// Token: 0x0401FC2E RID: 130094
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly Action<Vector2D> CallbackOnDrag;

		// Token: 0x0401FC2F RID: 130095
		[Nullable(2)]
		private readonly Action CallbackOnDown;

		// Token: 0x0401FC30 RID: 130096
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private readonly Action<Vector2D> CallbackOnInertia;

		// Token: 0x0401FC31 RID: 130097
		private bool Dragging;

		// Token: 0x0401FC32 RID: 130098
		private bool MultiFingerControl;

		// Token: 0x0401FC33 RID: 130099
		private double LastMultiTouchEndTime;

		// Token: 0x0401FC34 RID: 130100
		private string ZoomAxis = "";

		// Token: 0x0401FC35 RID: 130101
		private bool JoystickMovingRight;

		// Token: 0x0401FC36 RID: 130102
		private bool JoystickMovingForward;

		// Token: 0x0401FC37 RID: 130103
		private bool JoystickFocus;

		// Token: 0x0401FC38 RID: 130104
		[Nullable(2)]
		private Vector2D PrevPointerDownPosition;

		// Token: 0x0401FC39 RID: 130105
		[Nullable(2)]
		private Vector2D PointerDeltaPosition;

		// Token: 0x0401FC3A RID: 130106
		private double PointerDownTime;

		// Token: 0x0401FC3B RID: 130107
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, InputDistributeDefine.ITouchData> TouchMap;

		// Token: 0x0401FC3C RID: 130108
		private readonly Vector2D InternalMultiTouchOriginCenter = Vector2D.Create();
	}
}
