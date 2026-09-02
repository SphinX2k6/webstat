using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002617 RID: 9751
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteCompassRotateItem : CommonQteItemBase<CommonQteDragContext>
{
	// Token: 0x06013252 RID: 78418 RVA: 0x0054FE40 File Offset: 0x0054E040
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIDraggableComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem))
		};
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUIItem)));
		}
	}

	// Token: 0x06013253 RID: 78419 RVA: 0x0054FEC8 File Offset: 0x0054E0C8
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteCompassRotateItem.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteCompassRotateItem.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013254 RID: 78420 RVA: 0x0054FF0C File Offset: 0x0054E10C
	private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			this.GamepadOffset.Reset();
			this.HasInputLookup = false;
			this.HasInputTurn = false;
		}
		else
		{
			this.RelativeAngle = 90;
			this.StartAngle = 0;
			this.DragOffset = 0;
		}
		this.SetIsDragging(false);
	}

	// Token: 0x06013255 RID: 78421 RVA: 0x0054FF6C File Offset: 0x0054E16C
	protected override void OnStart()
	{
		base.OnStart();
		base.SetUiActive(false);
		UUIItem item = base.GetItem(0);
		this.LevelSequencePlayer = new LevelSequencePlayer(item);
		base.SetAttachRootItem(item);
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		UUIDraggableComponent draggable = base.GetDraggable(1);
		draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDragCallBack));
		draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
		draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndDragCallBack));
		draggable.OnPointerDownCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDownCallBack));
		draggable.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUpCallBack));
		this.Pointer = base.GetItem(2);
		this.PointerRotator.Pitch = 0f;
		this.PointerRotator.Roll = 0f;
		this.PointerRotator.Yaw = 0f;
		this.CurrentAngle = 90;
		this.AnchorLocation = new FVector?(base.GetItem(2).GetUIWorldPosition());
	}

	// Token: 0x06013256 RID: 78422 RVA: 0x00550093 File Offset: 0x0054E293
	[NullableContext(1)]
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteDragContext;
	}

	// Token: 0x06013257 RID: 78423 RVA: 0x0055009E File Offset: 0x0054E29E
	[NullableContext(1)]
	protected override void OnRefreshActionUi(string action)
	{
		InputMultiKeyItem keyItem = this.KeyItem;
		if (keyItem != null)
		{
			keyItem.RefreshByActionOrAxis(new InputActionOrAxisKeyItem
			{
				ActionOrAxisName = action
			}, false);
		}
		InputMultiKeyItem keyItem2 = this.KeyItem;
		if (keyItem2 == null)
		{
			return;
		}
		keyItem2.Show(null);
	}

	// Token: 0x06013258 RID: 78424 RVA: 0x005500D0 File Offset: 0x0054E2D0
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		SCommonQte_Drag scommonQte_Drag = uiConfig as SCommonQte_Drag;
		if (scommonQte_Drag != null)
		{
			this.RotateSpeed = scommonQte_Drag.CompassSpeed / 1000f;
		}
	}

	// Token: 0x06013259 RID: 78425 RVA: 0x00550104 File Offset: 0x0054E304
	[NullableContext(1)]
	private void OnSequenceEndEvent(string sequenceName)
	{
		if (sequenceName == "Start")
		{
			if (this.IsQteEnd)
			{
				return;
			}
			this.IsQteStart = true;
			this.IsQteInteractive = true;
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlayLevelSequenceByName("Loop", false, null, false);
			}
			if (!this.IsMobile)
			{
				InputMultiKeyItem keyItem = this.KeyItem;
				if (keyItem == null)
				{
					return;
				}
				keyItem.Show(null);
				return;
			}
		}
		else if (sequenceName == "Close")
		{
			base.Destroy(null);
		}
	}

	// Token: 0x0601325A RID: 78426 RVA: 0x00550184 File Offset: 0x0054E384
	protected override void OnPlayQteStart()
	{
		base.SetUiActive(true);
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}
		if (this.IsQteInteractive && !this.IsMobile)
		{
			InputMultiKeyItem keyItem = this.KeyItem;
			if (keyItem == null)
			{
				return;
			}
			keyItem.Show(null);
		}
	}

	// Token: 0x0601325B RID: 78427 RVA: 0x005501DC File Offset: 0x0054E3DC
	protected override void RefreshUiOffset()
	{
		if (this.CommonQteContext != null)
		{
			SCommonQte_Drag scommonQte_Drag = this.CommonQteContext.GetUiConfig() as SCommonQte_Drag;
			if (scommonQte_Drag != null)
			{
				SCommonQteButton uiconfig = scommonQte_Drag.UIConfig;
				this.RootItem.SetAnchorAlign(uiconfig.AnchorHAlign, uiconfig.AnchorVAlign);
				this.RootItem.SetAnchorOffset(uiconfig.AnchorOffset);
				if (this.IsAttaching)
				{
					this.Reattach(this.CommonQteContext);
				}
			}
		}
	}

	// Token: 0x0601325C RID: 78428 RVA: 0x0055024E File Offset: 0x0054E44E
	protected override bool IsUseBaseAction()
	{
		return false;
	}

	// Token: 0x0601325D RID: 78429 RVA: 0x00550254 File Offset: 0x0054E454
	protected override void OnBindAction()
	{
		ControllerBase<InputDistributeController>.Instance.BindAxisIgnoreLimit("UiScroll2", new TInputHandle<float>(this.OnInputTurn));
		ControllerBase<InputDistributeController>.Instance.BindAxisIgnoreLimit("UiScroll1", new TInputHandle<float>(this.OnInputLookup));
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
	}

	// Token: 0x0601325E RID: 78430 RVA: 0x005502B4 File Offset: 0x0054E4B4
	protected override void OnUnbindAction()
	{
		ControllerBase<InputDistributeController>.Instance.UnBindAxisIgnoreLimit("UiScroll2", new TInputHandle<float>(this.OnInputTurn));
		ControllerBase<InputDistributeController>.Instance.UnBindAxisIgnoreLimit("UiScroll1", new TInputHandle<float>(this.OnInputLookup));
		Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
	}

	// Token: 0x0601325F RID: 78431 RVA: 0x00550314 File Offset: 0x0054E514
	protected override void OnHandleQteEnd()
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName("Close", false, null, false);
	}

	// Token: 0x06013260 RID: 78432 RVA: 0x00550354 File Offset: 0x0054E554
	[NullableContext(1)]
	private void OnInputTurn(string name, float value, InputIdentification inputIdentification)
	{
		if (!base.IsValidInput() || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.GamepadOffset.X = (double)value;
		this.HasInputTurn = (value != 0f);
		this.SetIsDragging(this.HasInputTurn || this.HasInputLookup);
	}

	// Token: 0x06013261 RID: 78433 RVA: 0x005503AC File Offset: 0x0054E5AC
	[NullableContext(1)]
	private void OnInputLookup(string name, float value, InputIdentification inputIdentification)
	{
		if (!base.IsValidInput() || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.GamepadOffset.Y = (double)(-(double)value);
		this.HasInputLookup = (value != 0f);
		this.SetIsDragging(this.HasInputTurn || this.HasInputLookup);
	}

	// Token: 0x06013262 RID: 78434 RVA: 0x00550404 File Offset: 0x0054E604
	private void OnPointerDownCallBack(ULGUIPointerEventData eventData)
	{
		this.RelativeAngle = this.CacheAngle;
	}

	// Token: 0x06013263 RID: 78435 RVA: 0x00550412 File Offset: 0x0054E612
	private void OnPointerUpCallBack(ULGUIPointerEventData eventData)
	{
		this.RelativeAngle = 90;
	}

	// Token: 0x06013264 RID: 78436 RVA: 0x00550424 File Offset: 0x0054E624
	private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction || eventData == null)
		{
			return;
		}
		this.SetIsDragging(true);
		FVector pointerPosition = eventData.pointerPosition;
		Vector2D vector2D = Vector2D.Create();
		Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiCenterPosition(pointerPosition, vector2D);
		this.StartAngle = Rotator.ClampAxis((float)(Math.Atan2(vector2D.Y - (double)this.AnchorLocation.Value.Y, vector2D.X - (double)this.AnchorLocation.Value.X) * 57.295780181884766));
	}

	// Token: 0x06013265 RID: 78437 RVA: 0x005504B8 File Offset: 0x0054E6B8
	private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction || !this.IsDragging || eventData == null)
		{
			return;
		}
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
		{
			this.SetIsDragging(false);
			this.DragOffset = 0;
			this.StartAngle = 0;
			return;
		}
		FVector pointerPosition = eventData.pointerPosition;
		Vector2D vector2D = Vector2D.Create();
		Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiCenterPosition(pointerPosition, vector2D);
		float num = Rotator.ClampAxis((float)(Math.Atan2(vector2D.Y - (double)this.AnchorLocation.Value.Y, vector2D.X - (double)this.AnchorLocation.Value.X) * 57.295780181884766));
		this.DragOffset = num - this.StartAngle;
	}

	// Token: 0x06013266 RID: 78438 RVA: 0x00550586 File Offset: 0x0054E786
	private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction)
		{
			return;
		}
		this.SetIsDragging(false);
		this.DragOffset = 0;
		this.StartAngle = 0;
		this.RelativeAngle = 90;
	}

	// Token: 0x06013267 RID: 78439 RVA: 0x005505C5 File Offset: 0x0054E7C5
	private void SetIsDragging(bool isDragging)
	{
		if (isDragging == this.IsDragging)
		{
			return;
		}
		this.IsDragging = isDragging;
		if (isDragging)
		{
			CommonQteDragContext commonQteContext = this.CommonQteContext;
			if (commonQteContext == null)
			{
				return;
			}
			commonQteContext.Response();
			return;
		}
		else
		{
			CommonQteDragContext commonQteContext2 = this.CommonQteContext;
			if (commonQteContext2 == null)
			{
				return;
			}
			commonQteContext2.ResponseEnd();
			return;
		}
	}

	// Token: 0x06013268 RID: 78440 RVA: 0x005505FC File Offset: 0x0054E7FC
	protected override void OnTickQteItem(float delta)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			if (Singleton<MathUtils>.Instance.IsNearlyZero(this.GamepadOffset.Size(), null))
			{
				this.CurrentAngle = this.RelativeAngle;
			}
			else
			{
				this.CurrentAngle = Math.Atan2(this.GamepadOffset.Y, this.GamepadOffset.X) * 57.295780181884766;
			}
		}
		else
		{
			this.CurrentAngle = this.RelativeAngle + this.DragOffset;
		}
		this.CurrentAngle = Singleton<MathUtils>.Instance.ClampAngle((double)this.CurrentAngle, 0.0, 90.0);
		this.CacheAngle = Singleton<MathUtils>.Instance.InterpConstantTo(this.CacheAngle, this.CurrentAngle, delta, this.RotateSpeed);
		this.CommonQteContext.SetDraggingInfo(0f, (90 - this.CacheAngle) * 0.017453292f);
		this.PointerRotator.Yaw = this.CacheAngle;
		this.Pointer.SetUIRelativeRotation(this.PointerRotator);
	}

	// Token: 0x04009569 RID: 38249
	private InputMultiKeyItem KeyItem;

	// Token: 0x0400956A RID: 38250
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400956B RID: 38251
	private bool HasInputTurn;

	// Token: 0x0400956C RID: 38252
	private bool HasInputLookup;

	// Token: 0x0400956D RID: 38253
	private bool IsDragging;

	// Token: 0x0400956E RID: 38254
	private UUIItem Pointer;

	// Token: 0x0400956F RID: 38255
	private FRotator PointerRotator = new FRotator();

	// Token: 0x04009570 RID: 38256
	private FVector? AnchorLocation;

	// Token: 0x04009571 RID: 38257
	private Number StartAngle = 0;

	// Token: 0x04009572 RID: 38258
	private Number DragOffset = 0;

	// Token: 0x04009573 RID: 38259
	private Number CurrentAngle = 0;

	// Token: 0x04009574 RID: 38260
	private Number CacheAngle = 90;

	// Token: 0x04009575 RID: 38261
	[Nullable(1)]
	private readonly Vector2D GamepadOffset = Vector2D.Create();

	// Token: 0x04009576 RID: 38262
	private Number RotateSpeed = 0;

	// Token: 0x04009577 RID: 38263
	private Number RelativeAngle = 90;

	// Token: 0x020089AD RID: 35245
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E72F RID: 190255
		Prefab,
		// Token: 0x0402E730 RID: 190256
		Drag,
		// Token: 0x0402E731 RID: 190257
		Pointer,
		// Token: 0x0402E732 RID: 190258
		HotKey
	}
}
