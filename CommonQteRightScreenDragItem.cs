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

// Token: 0x02002621 RID: 9761
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteRightScreenDragItem : CommonQteItemBase<CommonQteDragContext>
{
	// Token: 0x06013325 RID: 78629 RVA: 0x00554838 File Offset: 0x00552A38
	protected override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIDraggableComponent))
		};
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
		}
	}

	// Token: 0x06013326 RID: 78630 RVA: 0x005548AC File Offset: 0x00552AAC
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteRightScreenDragItem.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteRightScreenDragItem.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013327 RID: 78631 RVA: 0x005548F0 File Offset: 0x00552AF0
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
	}

	// Token: 0x06013328 RID: 78632 RVA: 0x005549B6 File Offset: 0x00552BB6
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteDragContext;
	}

	// Token: 0x06013329 RID: 78633 RVA: 0x005549C1 File Offset: 0x00552BC1
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

	// Token: 0x0601332A RID: 78634 RVA: 0x005549F4 File Offset: 0x00552BF4
	[NullableContext(2)]
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		SCommonQte_Drag scommonQte_Drag = uiConfig as SCommonQte_Drag;
		if (scommonQte_Drag != null)
		{
			this.Bounds = scommonQte_Drag.DragBounds;
			this.Length = scommonQte_Drag.DragLength;
			this.LerpSpeed = scommonQte_Drag.LerpSpeed / this.Length / 1000f;
			this.CheckByRealTimeInput = scommonQte_Drag.CheckByRealTimeInput;
		}
	}

	// Token: 0x0601332B RID: 78635 RVA: 0x00554A50 File Offset: 0x00552C50
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

	// Token: 0x0601332C RID: 78636 RVA: 0x00554AD0 File Offset: 0x00552CD0
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

	// Token: 0x0601332D RID: 78637 RVA: 0x00554B28 File Offset: 0x00552D28
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

	// Token: 0x0601332E RID: 78638 RVA: 0x00554B9A File Offset: 0x00552D9A
	protected override bool IsUseBaseAction()
	{
		return false;
	}

	// Token: 0x0601332F RID: 78639 RVA: 0x00554BA0 File Offset: 0x00552DA0
	protected override void OnBindAction()
	{
		ControllerBase<InputDistributeController>.Instance.BindAxisIgnoreLimit("UiTurn", new TInputHandle<float>(this.OnInputTurn));
		ControllerBase<InputDistributeController>.Instance.BindAxisIgnoreLimit("UiLookUp", new TInputHandle<float>(this.OnInputLookup));
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
	}

	// Token: 0x06013330 RID: 78640 RVA: 0x00554C00 File Offset: 0x00552E00
	protected override void OnUnbindAction()
	{
		ControllerBase<InputDistributeController>.Instance.UnBindAxisIgnoreLimit("UiTurn", new TInputHandle<float>(this.OnInputTurn));
		ControllerBase<InputDistributeController>.Instance.UnBindAxisIgnoreLimit("UiLookUp", new TInputHandle<float>(this.OnInputLookup));
		Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
	}

	// Token: 0x06013331 RID: 78641 RVA: 0x00554C60 File Offset: 0x00552E60
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
			this.DerivedProgress = 0f;
			this.DragValid = false;
			this.CurDrag.Reset();
		}
		this.SetIsDragging(false);
	}

	// Token: 0x06013332 RID: 78642 RVA: 0x00554CB8 File Offset: 0x00552EB8
	protected override void OnHandleQteEnd()
	{
		InputMultiKeyItem keyItem = this.KeyItem;
		if (keyItem != null)
		{
			keyItem.Hide(null);
		}
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

	// Token: 0x06013333 RID: 78643 RVA: 0x00554D0C File Offset: 0x00552F0C
	private void OnInputTurn(string name, float value, InputIdentification inputIdentification)
	{
		if (!base.IsValidInput() || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.HasInputTurn = (value != 0f);
		this.GamepadOffset.X = (double)value;
		this.SetIsDragging(this.HasInputTurn || this.HasInputLookup);
	}

	// Token: 0x06013334 RID: 78644 RVA: 0x00554D64 File Offset: 0x00552F64
	private void OnInputLookup(string name, float value, InputIdentification inputIdentification)
	{
		if (!base.IsValidInput() || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.HasInputLookup = (value != 0f);
		this.GamepadOffset.Y = (double)(-(double)value);
		this.SetIsDragging(this.HasInputTurn || this.HasInputLookup);
	}

	// Token: 0x06013335 RID: 78645 RVA: 0x00554DBC File Offset: 0x00552FBC
	[NullableContext(2)]
	private void OnPointerDownCallBack(ULGUIPointerEventData eventData)
	{
		this.DerivedProgress = this.CacheProgress;
	}

	// Token: 0x06013336 RID: 78646 RVA: 0x00554DCA File Offset: 0x00552FCA
	[NullableContext(2)]
	private void OnPointerUpCallBack(ULGUIPointerEventData eventData)
	{
		this.DerivedProgress = 0f;
	}

	// Token: 0x06013337 RID: 78647 RVA: 0x00554DD8 File Offset: 0x00552FD8
	[NullableContext(2)]
	private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction || eventData == null)
		{
			return;
		}
		this.SetIsDragging(true);
		FVector pointerPosition = eventData.pointerPosition;
		Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiCenterPosition(pointerPosition, this.StartDrag);
		this.CurDrag.DeepCopy(this.StartDrag);
		this.DragValid = true;
	}

	// Token: 0x06013338 RID: 78648 RVA: 0x00554E30 File Offset: 0x00553030
	[NullableContext(2)]
	private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction || !this.IsDragging || eventData == null)
		{
			return;
		}
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
		{
			this.SetIsDragging(false);
			this.DragValid = false;
			return;
		}
		if (!this.DragValid)
		{
			return;
		}
		FVector pointerPosition = eventData.pointerPosition;
		Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiCenterPosition(pointerPosition, this.CurDrag);
	}

	// Token: 0x06013339 RID: 78649 RVA: 0x00554E98 File Offset: 0x00553098
	[NullableContext(2)]
	private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction)
		{
			return;
		}
		this.CurDrag.Reset();
		this.StartDrag.Reset();
		this.DragValid = false;
		this.CurrentProgress = 0f;
		this.SetIsDragging(false);
	}

	// Token: 0x0601333A RID: 78650 RVA: 0x00554EE5 File Offset: 0x005530E5
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

	// Token: 0x0601333B RID: 78651 RVA: 0x00554F1C File Offset: 0x0055311C
	protected override void OnTickQteItem(float delta)
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			if (Singleton<MathUtils>.Instance.IsNearlyZero(this.GamepadOffset.Size(), null))
			{
				this.CurrentProgress -= delta * this.LerpSpeed;
			}
			else
			{
				FVector2D fvector2D = new FVector2D();
				fvector2D.X = Singleton<MathUtils>.Instance.Clamp(delta * this.LerpSpeed, 0f, 1f);
				fvector2D.Y = this.MoveCurve.GetFloatValue(this.CurrentProgress + fvector2D.X);
				float num = fvector2D.Size();
				if (num == 0f)
				{
					return;
				}
				float num2 = (float)this.GamepadOffset.DotProduct(fvector2D) / num;
				this.CurrentProgress += num2 * fvector2D.X;
			}
		}
		else if (this.DragValid)
		{
			this.CurrentProgress = (float)(this.CurDrag.X - this.StartDrag.X) / this.Length + this.DerivedProgress;
			float num3 = (float)(this.CurDrag.Y - this.StartDrag.Y) / this.Length;
			if (Math.Abs(this.MoveCurve.GetFloatValue(Singleton<MathUtils>.Instance.Clamp(this.CurrentProgress, 0f, 1f)) - num3) * this.Length > this.Bounds)
			{
				this.CurDrag.Reset();
				this.StartDrag.Reset();
				this.DragValid = false;
				this.SetIsDragging(false);
			}
		}
		else
		{
			this.CurrentProgress = this.DerivedProgress;
		}
		this.CurrentProgress = Singleton<MathUtils>.Instance.Clamp(this.CurrentProgress, 0f, 1f);
		this.CacheProgress = Singleton<MathUtils>.Instance.InterpConstantTo(this.CacheProgress, this.CurrentProgress, delta, this.LerpSpeed);
		this.CommonQteContext.SetDraggingInfo(this.CacheProgress, 0f);
		if (this.CheckByRealTimeInput && this.CommonQteContext.CheckDragComplete(this.CurrentProgress, 0f))
		{
			this.CommonQteContext.SetPreResult(true);
		}
	}

	// Token: 0x040095D0 RID: 38352
	private const string CURVE_PATH = "/Game/Aki/UI/UIResources/UiFight/Curve/PlotQTE/PlotQteDragRT1.PlotQteDragRT1";

	// Token: 0x040095D1 RID: 38353
	[Nullable(2)]
	private InputMultiKeyItem KeyItem;

	// Token: 0x040095D2 RID: 38354
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040095D3 RID: 38355
	[Nullable(2)]
	private UCurveFloat MoveCurve;

	// Token: 0x040095D4 RID: 38356
	private bool HasInputTurn;

	// Token: 0x040095D5 RID: 38357
	private bool HasInputLookup;

	// Token: 0x040095D6 RID: 38358
	private bool IsDragging;

	// Token: 0x040095D7 RID: 38359
	private bool DragValid;

	// Token: 0x040095D8 RID: 38360
	private float CurrentProgress;

	// Token: 0x040095D9 RID: 38361
	private float DerivedProgress;

	// Token: 0x040095DA RID: 38362
	private float CacheProgress;

	// Token: 0x040095DB RID: 38363
	private float LerpSpeed;

	// Token: 0x040095DC RID: 38364
	private float Bounds;

	// Token: 0x040095DD RID: 38365
	private float Length;

	// Token: 0x040095DE RID: 38366
	private readonly Vector2D StartDrag = Vector2D.Create();

	// Token: 0x040095DF RID: 38367
	private readonly Vector2D CurDrag = Vector2D.Create();

	// Token: 0x040095E0 RID: 38368
	private readonly Vector2D GamepadOffset = Vector2D.Create();

	// Token: 0x040095E1 RID: 38369
	private bool CheckByRealTimeInput;

	// Token: 0x020089BF RID: 35263
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E783 RID: 190339
		Prefab,
		// Token: 0x0402E784 RID: 190340
		Drag,
		// Token: 0x0402E785 RID: 190341
		HotKey
	}
}
