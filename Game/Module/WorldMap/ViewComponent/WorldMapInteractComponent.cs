using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.View.BaseMap;
using CSharpScript.Game.Ui;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B4A RID: 19274
	[NullableContext(2)]
	[Nullable(0)]
	public class WorldMapInteractComponent : MapComponent
	{
		// Token: 0x0603252C RID: 206124 RVA: 0x00C97441 File Offset: 0x00C95641
		public WorldMapInteractComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x17008658 RID: 34392
		// (get) Token: 0x0603252D RID: 206125 RVA: 0x00C97460 File Offset: 0x00C95660
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.WorldMapInteract;
			}
		}

		// Token: 0x17008659 RID: 34393
		// (get) Token: 0x0603252E RID: 206126 RVA: 0x00C97463 File Offset: 0x00C95663
		public bool IsJoystickMoving
		{
			get
			{
				return this.JoystickMovingRight || this.JoystickMovingForward;
			}
		}

		// Token: 0x1700865A RID: 34394
		// (get) Token: 0x0603252F RID: 206127 RVA: 0x00C97475 File Offset: 0x00C95675
		public bool IsJoystickFocus
		{
			get
			{
				return this.JoystickFocus;
			}
		}

		// Token: 0x1700865B RID: 34395
		// (get) Token: 0x06032530 RID: 206128 RVA: 0x00C9747D File Offset: 0x00C9567D
		[Nullable(1)]
		public Vector2D MultiTouchOriginCenter
		{
			[NullableContext(1)]
			get
			{
				return this.InternalMultiTouchOriginCenter;
			}
		}

		// Token: 0x1700865C RID: 34396
		// (get) Token: 0x06032531 RID: 206129 RVA: 0x00C97485 File Offset: 0x00C95685
		public bool IsDragging
		{
			get
			{
				return this.Dragging;
			}
		}

		// Token: 0x1700865D RID: 34397
		// (get) Token: 0x06032532 RID: 206130 RVA: 0x00C9748D File Offset: 0x00C9568D
		// (set) Token: 0x06032533 RID: 206131 RVA: 0x00C97498 File Offset: 0x00C95698
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
					if (!value)
					{
						Dictionary<int, InputDistributeDefine.ITouchData> touchMap = this.TouchMap;
						if (touchMap != null && touchMap.Count > 0)
						{
							return;
						}
					}
					this.MultiFingerControl = value;
					if (!this.MultiFingerControl)
					{
						this.LastMultiTouchEndTime = Singleton<Time>.Instance.NowSeconds;
					}
				}
			}
		}

		// Token: 0x1700865E RID: 34398
		// (get) Token: 0x06032534 RID: 206132 RVA: 0x00C974E8 File Offset: 0x00C956E8
		public bool IsJoystickZoom
		{
			get
			{
				return !string.IsNullOrEmpty(this.ZoomAxis);
			}
		}

		// Token: 0x1700865F RID: 34399
		// (get) Token: 0x06032535 RID: 206133 RVA: 0x00C974F8 File Offset: 0x00C956F8
		private WorldMapUiEntity WorldMapUiComponent
		{
			get
			{
				WorldMapUiEntity worldMapUiEntity = base.Parent.AsT3 as WorldMapUiEntity;
				if (worldMapUiEntity == null)
				{
					base.LogError(ELogAuthor.LRX, "[地图系统]->二级界面组件没有附加到容器下！", default(ReadOnlySpan<ValueTuple<string, object>>));
					return null;
				}
				return worldMapUiEntity;
			}
		}

		// Token: 0x17008660 RID: 34400
		// (get) Token: 0x06032536 RID: 206134 RVA: 0x00C97535 File Offset: 0x00C95735
		private UKuroWorldMapUIParams UiParams
		{
			get
			{
				WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
				if (worldMapUiComponent == null)
				{
					return null;
				}
				return worldMapUiComponent.UiParams;
			}
		}

		// Token: 0x17008661 RID: 34401
		// (get) Token: 0x06032537 RID: 206135 RVA: 0x00C97548 File Offset: 0x00C95748
		private FVector2D ViewportSize
		{
			get
			{
				return this.WorldMapUiComponent.ViewPortSize;
			}
		}

		// Token: 0x06032538 RID: 206136 RVA: 0x00C97558 File Offset: 0x00C95758
		protected override void OnAdd()
		{
			WorldMapUiEntity worldMapUiComponent = this.WorldMapUiComponent;
			BaseMap baseMap = (worldMapUiComponent != null) ? worldMapUiComponent.Map : null;
			object obj;
			if (baseMap == null)
			{
				obj = null;
			}
			else
			{
				AActor rootActor = baseMap.GetRootActor();
				obj = ((rootActor != null) ? rootActor.GetComponentByClass(UUIDraggableComponent.StaticClass()) : null);
			}
			UUIDraggableComponent uuidraggableComponent = obj as UUIDraggableComponent;
			if (uuidraggableComponent == null)
			{
				return;
			}
			this.TouchMap = new Dictionary<int, InputDistributeDefine.ITouchData>();
			this.PrevPointerDownPosition = Vector2D.Create();
			this.PointerDeltaPosition = Vector2D.Create();
			uuidraggableComponent.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDown));
			uuidraggableComponent.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDrag));
			uuidraggableComponent.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
			uuidraggableComponent.OnPointerScrollCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnWheelAxisInput));
		}

		// Token: 0x06032539 RID: 206137 RVA: 0x00C97620 File Offset: 0x00C95820
		protected override void OnEnable()
		{
			this.AddEventListener();
		}

		// Token: 0x0603253A RID: 206138 RVA: 0x00C97628 File Offset: 0x00C95828
		protected override void OnDisable()
		{
			this.RemoveEventListener();
		}

		// Token: 0x0603253B RID: 206139 RVA: 0x00C97630 File Offset: 0x00C95830
		protected override void OnRemove()
		{
			this.PrevPointerDownPosition = null;
			this.PointerDeltaPosition = null;
		}

		// Token: 0x0603253C RID: 206140 RVA: 0x00C97640 File Offset: 0x00C95840
		public void SetJoystickFocus(bool value)
		{
			this.JoystickFocus = value;
		}

		// Token: 0x0603253D RID: 206141 RVA: 0x00C9764C File Offset: 0x00C9584C
		private void AddEventListener()
		{
			ControllerBase<InputDistributeController>.Instance.BindTouches(new int[]
			{
				0,
				1
			}, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
			Singleton<EventSystem>.Instance.Add(EEventName.NavigationTriggerMapForward, new Action<float>(this.OnUiForwardInput));
			Singleton<EventSystem>.Instance.Add(EEventName.NavigationTriggerMapRight, new Action<float>(this.OnUiRightInput));
			Singleton<EventSystem>.Instance.Add(EEventName.NavigationTriggerMapZoom, new Action<string, float>(this.OnHandleTriggerInput));
		}

		// Token: 0x0603253E RID: 206142 RVA: 0x00C976D0 File Offset: 0x00C958D0
		private void RemoveEventListener()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindTouches(new <>z__ReadOnlyArray<int>(new int[]
			{
				0,
				1
			}), new TInputHandle<InputDistributeDefine.ITouchData>(this.OnTouch));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerMapForward, new Action<float>(this.OnUiForwardInput));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerMapRight, new Action<float>(this.OnUiRightInput));
			Singleton<EventSystem>.Instance.Remove(EEventName.NavigationTriggerMapZoom, new Action<string, float>(this.OnHandleTriggerInput));
		}

		// Token: 0x0603253F RID: 206143 RVA: 0x00C97758 File Offset: 0x00C95958
		public void CheckTouch()
		{
			if (this.TouchMap == null)
			{
				return;
			}
			InputDistributeDefine.ITouchData touchData;
			this.TouchMap.TryGetValue(0, out touchData);
			InputDistributeDefine.ITouchData touchData2;
			this.TouchMap.TryGetValue(1, out touchData2);
			this.IsMultiFingerControl = (touchData != null && touchData2 != null);
			if (!this.IsMultiFingerControl)
			{
				return;
			}
			ValueTuple<EFingerExpandCloseType, float> fingerExpandCloseType = Singleton<TouchFingerManager>.Instance.GetFingerExpandCloseType(EFingerIndex.One, EFingerIndex.Two);
			EFingerExpandCloseType item = fingerExpandCloseType.Item1;
			if (item == EFingerExpandCloseType.Expand)
			{
				Singleton<EventSystem>.Instance.Emit<float, EMapScaleSetType>(EEventName.WorldMapFingerExpandClose, fingerExpandCloseType.Item2, EMapScaleSetType.FingerExpandClose);
				return;
			}
			if (item != EFingerExpandCloseType.Close)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<float, EMapScaleSetType>(EEventName.WorldMapFingerExpandClose, fingerExpandCloseType.Item2, EMapScaleSetType.FingerExpandClose);
		}

		// Token: 0x06032540 RID: 206144 RVA: 0x00C977F4 File Offset: 0x00C959F4
		private void OnPointerDown(ULGUIPointerEventData eventData)
		{
			this.Dragging = false;
			if (eventData == null || this.IsMultiFingerControl || !this.CheckPointInScope(eventData.pointerPosition))
			{
				return;
			}
			Vector2D inV = this.MousePositionConverToLgui(eventData.pointerPosition.X, eventData.pointerPosition.Y);
			Vector2D prevPointerDownPosition = this.PrevPointerDownPosition;
			if (prevPointerDownPosition != null)
			{
				prevPointerDownPosition.DeepCopy(inV);
			}
			this.PointerDownTime = Singleton<Time>.Instance.NowSeconds;
			Singleton<EventSystem>.Instance.Emit(EEventName.WorldMapPointerDown);
		}

		// Token: 0x06032541 RID: 206145 RVA: 0x00C97874 File Offset: 0x00C95A74
		private void OnPointerDrag(ULGUIPointerEventData eventData)
		{
			if (eventData != null && !this.IsMultiFingerControl)
			{
				Dictionary<int, InputDistributeDefine.ITouchData> touchMap = this.TouchMap;
				if (((touchMap != null) ? touchMap.Count : 0) <= 1)
				{
					this.Dragging = true;
					Vector2D vector2D = this.MousePositionConverToLgui(eventData.pointerPosition.X, eventData.pointerPosition.Y);
					Vector2D vector2D2 = Vector2D.Create(vector2D.X, vector2D.Y);
					vector2D2.SubtractionEqual(this.PrevPointerDownPosition);
					if (vector2D2.X == 0.0 && vector2D2.Y == 0.0)
					{
						return;
					}
					this.PointerDeltaPosition.DeepCopy(vector2D2);
					this.PrevPointerDownPosition.DeepCopy(vector2D);
					Singleton<EventSystem>.Instance.Emit<Vector2D>(EEventName.WorldMapPointerDrag, this.PointerDeltaPosition);
					return;
				}
			}
			this.Dragging = false;
			Vector2D pointerDeltaPosition = this.PointerDeltaPosition;
			if (pointerDeltaPosition == null)
			{
				return;
			}
			pointerDeltaPosition.Reset();
		}

		// Token: 0x06032542 RID: 206146 RVA: 0x00C97950 File Offset: 0x00C95B50
		private void OnPointerUp(ULGUIPointerEventData eventData)
		{
			double nowSeconds = Singleton<Time>.Instance.NowSeconds;
			if (this.IsMultiFingerControl || nowSeconds - this.LastMultiTouchEndTime < 0.5)
			{
				Singleton<Log>.Instance.Info(ELogModule.Map, ELogAuthor.LYX, "正在进行双指缩放", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (!this.CheckPointInScope(eventData.pointerPosition))
			{
				this.Dragging = false;
				return;
			}
			if (this.Dragging)
			{
				this.Dragging = false;
				this.DragInertia();
				return;
			}
			Singleton<EventSystem>.Instance.Emit<ULGUIPointerEventData>(EEventName.WorldMapPointerUp, eventData);
		}

		// Token: 0x06032543 RID: 206147 RVA: 0x00C979E0 File Offset: 0x00C95BE0
		private void DragInertia()
		{
			if (this.PointerDeltaPosition == null || (this.PointerDeltaPosition.X == 0.0 && this.PointerDeltaPosition.Y == 0.0))
			{
				return;
			}
			double num = Singleton<Time>.Instance.NowSeconds - this.PointerDownTime;
			double num2 = this.PointerDeltaPosition.Size();
			double num3 = 2.0 * num2 / (num * num) * num;
			FVector2D uiViewportSize = LGuiExtension.GetUiViewportSize();
			if (!uiViewportSize.IsNearlyZero(0.0001f))
			{
				num3 = MathCommon.Clamp(num3, 0.0, (double)uiViewportSize.Size());
			}
			if (!this.PointerDeltaPosition.Normalize(0.0))
			{
				this.PointerDeltaPosition.Reset();
				return;
			}
			Vector2D vector2D = Vector2D.Create();
			this.PointerDeltaPosition.Multiply(num3, vector2D);
			Singleton<EventSystem>.Instance.Emit<Vector2D>(EEventName.WorldMapDragInertia, vector2D);
			this.PointerDeltaPosition.Reset();
		}

		// Token: 0x06032544 RID: 206148 RVA: 0x00C97AD4 File Offset: 0x00C95CD4
		[NullableContext(1)]
		private void OnTouch(string touchIdName, InputDistributeDefine.ITouchData touchData, InputIdentification identification)
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

		// Token: 0x06032545 RID: 206149 RVA: 0x00C97B0C File Offset: 0x00C95D0C
		private void TouchTrigger(bool bTouchPress, int touchId, InputDistributeDefine.ITouchData touchData = null)
		{
			if (bTouchPress)
			{
				if (Singleton<LguiEventSystemManager>.Instance.IsPressComponentIsValid(touchId) && touchData != null)
				{
					this.TouchMap[touchId] = touchData;
				}
			}
			else
			{
				this.TouchMap.Remove(touchId);
			}
			this.InternalMultiTouchOriginCenter.Reset();
			if (this.TouchMap != null)
			{
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
		}

		// Token: 0x06032546 RID: 206150 RVA: 0x00C97BF4 File Offset: 0x00C95DF4
		private void OnWheelAxisInput(ULGUIPointerEventData eventData)
		{
			Singleton<EventSystem>.Instance.Emit<float, EMapScaleSetType>(EEventName.WorldMapWheelAxisInput, eventData.scrollAxisValue * 0.05f, EMapScaleSetType.WheelInput);
		}

		// Token: 0x06032547 RID: 206151 RVA: 0x00C97C14 File Offset: 0x00C95E14
		private void OnUiForwardInput(float value)
		{
			if (value == 0f)
			{
				this.JoystickMovingForward = false;
				return;
			}
			this.JoystickMovingForward = true;
			this.JoystickFocus = false;
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.WorldMapJoystickMoveForward;
			UKuroWorldMapUIParams uiParams = this.UiParams;
			instance.Emit<float>(name, (uiParams != null) ? (-uiParams.GamePadMoveSpeed * value) : 0f);
		}

		// Token: 0x06032548 RID: 206152 RVA: 0x00C97C68 File Offset: 0x00C95E68
		private void OnUiRightInput(float value)
		{
			if (value == 0f)
			{
				this.JoystickMovingRight = false;
				return;
			}
			this.JoystickMovingRight = true;
			this.JoystickFocus = false;
			EventSystem instance = Singleton<EventSystem>.Instance;
			EEventName name = EEventName.WorldMapJoystickMoveRight;
			UKuroWorldMapUIParams uiParams = this.UiParams;
			instance.Emit<float>(name, (uiParams != null) ? (-uiParams.GamePadMoveSpeed * value) : 0f);
		}

		// Token: 0x06032549 RID: 206153 RVA: 0x00C97CBC File Offset: 0x00C95EBC
		[NullableContext(1)]
		private void OnHandleTriggerInput(string axisName, float value)
		{
			if (value == 0f)
			{
				if (this.ZoomAxis == axisName)
				{
					this.ZoomAxis = string.Empty;
				}
				return;
			}
			this.ZoomAxis = axisName;
			Singleton<EventSystem>.Instance.Emit<float, EMapScaleSetType>(EEventName.WorldMapHandleTriggerAxisInput, 0.05f * value, EMapScaleSetType.Gamepad);
		}

		// Token: 0x0603254A RID: 206154 RVA: 0x00C97D0C File Offset: 0x00C95F0C
		private bool CheckPointInScope(FVector mousePos)
		{
			Vector2D vector2D = this.MousePositionConverToLgui(mousePos.X, mousePos.Y);
			return vector2D.X >= 0.0 && vector2D.X <= (double)this.ViewportSize.X && vector2D.Y >= 0.0 && vector2D.Y <= (double)this.ViewportSize.Y;
		}

		// Token: 0x0603254B RID: 206155 RVA: 0x00C97D7C File Offset: 0x00C95F7C
		[NullableContext(1)]
		private Vector2D MousePositionConverToLgui(float x, float y)
		{
			Vector2D vector2D = Vector2D.Create((double)x, (double)y);
			UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
			if (((uiRootItem != null) ? uiRootItem.GetCanvasScaler() : null) != null)
			{
				FVector2D fvector2D = vector2D.ToUeVector2D(false);
				FVector2D fvector2D2 = uiRootItem.GetCanvasScaler().ConvertPositionFromViewportToLGUICanvas(fvector2D);
				vector2D.FromUeVector2D(fvector2D2);
			}
			vector2D.X = MathCommon.Clamp(vector2D.X, 0.0, (double)this.ViewportSize.X);
			vector2D.Y = MathCommon.Clamp(vector2D.Y, 0.0, (double)this.ViewportSize.Y);
			return vector2D;
		}

		// Token: 0x0401D668 RID: 120424
		private const float MULTI_TOUCH_DELAY_TIME = 0.5f;

		// Token: 0x0401D669 RID: 120425
		private const float SCALE_STEP = 0.05f;

		// Token: 0x0401D66A RID: 120426
		private bool Dragging;

		// Token: 0x0401D66B RID: 120427
		private bool MultiFingerControl;

		// Token: 0x0401D66C RID: 120428
		private double LastMultiTouchEndTime;

		// Token: 0x0401D66D RID: 120429
		private bool JoystickMovingRight;

		// Token: 0x0401D66E RID: 120430
		private bool JoystickMovingForward;

		// Token: 0x0401D66F RID: 120431
		private bool JoystickFocus;

		// Token: 0x0401D670 RID: 120432
		[Nullable(1)]
		private string ZoomAxis = string.Empty;

		// Token: 0x0401D671 RID: 120433
		[Nullable(1)]
		private readonly Vector2D InternalMultiTouchOriginCenter = Vector2D.Create();

		// Token: 0x0401D672 RID: 120434
		private Vector2D PrevPointerDownPosition;

		// Token: 0x0401D673 RID: 120435
		private Vector2D PointerDeltaPosition;

		// Token: 0x0401D674 RID: 120436
		private double PointerDownTime;

		// Token: 0x0401D675 RID: 120437
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<int, InputDistributeDefine.ITouchData> TouchMap;
	}
}
