using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200261D RID: 9757
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteFullScreenPullItem : CommonQteItemBase<CommonQteDragContext>
{
	// Token: 0x060132C0 RID: 78528 RVA: 0x0055269C File Offset: 0x0055089C
	protected unsafe override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIDraggableComponent));
		this.ComponentRegisterInfos = list;
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
		}
	}

	// Token: 0x060132C1 RID: 78529 RVA: 0x00552734 File Offset: 0x00550934
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteFullScreenPullItem.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteFullScreenPullItem.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060132C2 RID: 78530 RVA: 0x00552778 File Offset: 0x00550978
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

	// Token: 0x060132C3 RID: 78531 RVA: 0x0055283E File Offset: 0x00550A3E
	private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			this.InputVector.Reset();
			this.HasInputLookup = false;
			this.HasInputTurn = false;
		}
		this.DerivedLength = 0f;
	}

	// Token: 0x060132C4 RID: 78532 RVA: 0x00552870 File Offset: 0x00550A70
	[NullableContext(1)]
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteDragContext;
	}

	// Token: 0x060132C5 RID: 78533 RVA: 0x0055287B File Offset: 0x00550A7B
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

	// Token: 0x060132C6 RID: 78534 RVA: 0x005528AC File Offset: 0x00550AAC
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		SCommonQte_Drag scommonQte_Drag = uiConfig as SCommonQte_Drag;
		if (scommonQte_Drag != null)
		{
			this.DragLength = scommonQte_Drag.SlideLength;
			this.DragAxis = CommonQteFullScreenPullItem.EDragAxis.Y;
			this.DragDirection = 1;
			if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.全屏下拉界面 || scommonQte_Drag.ViewType == ECommonQteViewType_Drag.穗穗下滑界面)
			{
				this.DragDirection = -1;
			}
			else if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.全屏上拉界面)
			{
				this.DragDirection = 1;
			}
			else if (scommonQte_Drag.ViewType == ECommonQteViewType_Drag.穗穗右滑界面)
			{
				this.DragAxis = CommonQteFullScreenPullItem.EDragAxis.X;
				this.DragDirection = 1;
			}
			this.LerpSpeed = scommonQte_Drag.LerpSpeed / 1000f;
			this.CheckByRealTimeInput = scommonQte_Drag.CheckByRealTimeInput;
		}
	}

	// Token: 0x060132C7 RID: 78535 RVA: 0x00552970 File Offset: 0x00550B70
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

	// Token: 0x060132C8 RID: 78536 RVA: 0x005529F0 File Offset: 0x00550BF0
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

	// Token: 0x060132C9 RID: 78537 RVA: 0x00552A48 File Offset: 0x00550C48
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

	// Token: 0x060132CA RID: 78538 RVA: 0x00552ABA File Offset: 0x00550CBA
	protected override bool IsUseBaseAction()
	{
		return false;
	}

	// Token: 0x060132CB RID: 78539 RVA: 0x00552AC0 File Offset: 0x00550CC0
	protected override void OnBindAction()
	{
		ControllerBase<InputDistributeController>.Instance.BindAxisIgnoreLimit("UiScroll2", new TInputHandle<float>(this.OnInputTurn));
		ControllerBase<InputDistributeController>.Instance.BindAxisIgnoreLimit("UiScroll1", new TInputHandle<float>(this.OnInputLookup));
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
	}

	// Token: 0x060132CC RID: 78540 RVA: 0x00552B20 File Offset: 0x00550D20
	protected override void OnUnbindAction()
	{
		ControllerBase<InputDistributeController>.Instance.UnBindAxisIgnoreLimit("UiScroll2", new TInputHandle<float>(this.OnInputTurn));
		ControllerBase<InputDistributeController>.Instance.UnBindAxisIgnoreLimit("UiScroll1", new TInputHandle<float>(this.OnInputLookup));
		Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
	}

	// Token: 0x060132CD RID: 78541 RVA: 0x00552B80 File Offset: 0x00550D80
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

	// Token: 0x060132CE RID: 78542 RVA: 0x00552BD4 File Offset: 0x00550DD4
	[NullableContext(1)]
	private void OnInputTurn(string name, float value, InputIdentification inputIdentification)
	{
		if (!base.IsValidInput() || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.InputVector.X = (double)value;
		this.HasInputTurn = (value != 0f);
		this.SetIsDragging(this.HasInputTurn || this.HasInputLookup);
	}

	// Token: 0x060132CF RID: 78543 RVA: 0x00552C2C File Offset: 0x00550E2C
	[NullableContext(1)]
	private void OnInputLookup(string name, float value, InputIdentification inputIdentification)
	{
		if (!base.IsValidInput() || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.InputVector.Y = (double)(-(double)value);
		this.HasInputLookup = (value != 0f);
		this.SetIsDragging(this.HasInputTurn || this.HasInputLookup);
	}

	// Token: 0x060132D0 RID: 78544 RVA: 0x00552C84 File Offset: 0x00550E84
	private void OnPointerDownCallBack(ULGUIPointerEventData eventData)
	{
		this.DerivedLength = this.CacheLength;
	}

	// Token: 0x060132D1 RID: 78545 RVA: 0x00552C92 File Offset: 0x00550E92
	private void OnPointerUpCallBack(ULGUIPointerEventData eventData)
	{
		this.DerivedLength = 0f;
	}

	// Token: 0x060132D2 RID: 78546 RVA: 0x00552C9F File Offset: 0x00550E9F
	private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction)
		{
			return;
		}
		this.StartDragPosition = new FVector?(eventData.GetLocalPointInPlane());
		this.SetIsDragging(true);
	}

	// Token: 0x060132D3 RID: 78547 RVA: 0x00552CCC File Offset: 0x00550ECC
	private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction)
		{
			return;
		}
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
		{
			this.StartDragPosition = null;
			return;
		}
		if (this.StartDragPosition == null)
		{
			return;
		}
		FVector localPointInPlane = eventData.GetLocalPointInPlane();
		this.InputVector.Y = (double)(localPointInPlane.Y - this.StartDragPosition.Value.Y);
		this.InputVector.X = (double)(localPointInPlane.X - this.StartDragPosition.Value.X);
	}

	// Token: 0x060132D4 RID: 78548 RVA: 0x00552D5F File Offset: 0x00550F5F
	private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction)
		{
			return;
		}
		this.DerivedLength = 0f;
		this.StartDragPosition = null;
		this.InputVector.Reset();
		this.SetIsDragging(false);
	}

	// Token: 0x060132D5 RID: 78549 RVA: 0x00552D9B File Offset: 0x00550F9B
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

	// Token: 0x060132D6 RID: 78550 RVA: 0x00552DD4 File Offset: 0x00550FD4
	protected override void OnTickQteItem(float delta)
	{
		float angle = (float)this.InputVector.HeadingAngle();
		float dragInput = this.GetDragInput();
		float num;
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			if (this.LerpSpeed < 0f)
			{
				num = dragInput * 1.43f * (float)this.DragDirection * this.DragLength;
				this.CacheLength = num;
			}
			else
			{
				float num2 = dragInput * (float)this.DragDirection;
				if ((double)num2 <= 1E-08)
				{
					this.CacheLength = Singleton<MathUtils>.Instance.InterpConstantTo(this.CacheLength, 0f, delta, this.LerpSpeed);
				}
				else
				{
					this.CacheLength = Singleton<MathUtils>.Instance.InterpConstantTo(this.CacheLength, this.DragLength, delta, this.LerpSpeed * num2);
				}
				num = this.CacheLength;
			}
		}
		else
		{
			num = dragInput * (float)this.DragDirection + this.DerivedLength;
			if (this.LerpSpeed > 0f)
			{
				this.CacheLength = Singleton<MathUtils>.Instance.InterpConstantTo(this.CacheLength, num, delta, this.LerpSpeed);
			}
			else
			{
				this.CacheLength = num;
			}
		}
		this.CacheLength = Singleton<MathUtils>.Instance.Clamp(this.CacheLength, 0f, this.DragLength);
		this.CommonQteContext.SetDraggingInfo(this.CacheLength, angle);
		if (this.CheckByRealTimeInput && this.CommonQteContext.CheckDragComplete(num, angle))
		{
			this.CommonQteContext.SetPreResult(true);
		}
	}

	// Token: 0x060132D7 RID: 78551 RVA: 0x00552F38 File Offset: 0x00551138
	private float GetDragInput()
	{
		return (float)((this.DragAxis == CommonQteFullScreenPullItem.EDragAxis.X) ? this.InputVector.X : this.InputVector.Y);
	}

	// Token: 0x0400959A RID: 38298
	private const float GAMEPAD_ENHANCE_RATE = 1.43f;

	// Token: 0x0400959B RID: 38299
	private InputMultiKeyItem KeyItem;

	// Token: 0x0400959C RID: 38300
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400959D RID: 38301
	private float DragLength;

	// Token: 0x0400959E RID: 38302
	private float CacheLength;

	// Token: 0x0400959F RID: 38303
	private float DerivedLength;

	// Token: 0x040095A0 RID: 38304
	private float LerpSpeed;

	// Token: 0x040095A1 RID: 38305
	private int DragDirection;

	// Token: 0x040095A2 RID: 38306
	private CommonQteFullScreenPullItem.EDragAxis DragAxis = CommonQteFullScreenPullItem.EDragAxis.Y;

	// Token: 0x040095A3 RID: 38307
	private FVector? StartDragPosition;

	// Token: 0x040095A4 RID: 38308
	[Nullable(1)]
	private readonly Vector InputVector = Vector.Create();

	// Token: 0x040095A5 RID: 38309
	private bool HasInputTurn;

	// Token: 0x040095A6 RID: 38310
	private bool HasInputLookup;

	// Token: 0x040095A7 RID: 38311
	private bool IsDragging;

	// Token: 0x040095A8 RID: 38312
	private bool CheckByRealTimeInput;

	// Token: 0x020089BA RID: 35258
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E76C RID: 190316
		Prefab,
		// Token: 0x0402E76D RID: 190317
		Drag,
		// Token: 0x0402E76E RID: 190318
		HotKey
	}

	// Token: 0x020089BB RID: 35259
	[NullableContext(0)]
	private enum EDragAxis
	{
		// Token: 0x0402E770 RID: 190320
		X,
		// Token: 0x0402E771 RID: 190321
		Y
	}
}
