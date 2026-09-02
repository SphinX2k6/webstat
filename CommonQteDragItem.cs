using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Data.Qte;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200261B RID: 9755
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteDragItem : CommonQteItemBase<CommonQteDragContext>
{
	// Token: 0x0601329B RID: 78491 RVA: 0x005518A4 File Offset: 0x0054FAA4
	protected unsafe override void OnRegisterComponent()
	{
		base.OnRegisterComponent();
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIDraggableComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISliderComponent));
		this.ComponentRegisterInfos = list;
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(6, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(7, typeof(UUIItem)));
		}
	}

	// Token: 0x0601329C RID: 78492 RVA: 0x005519DC File Offset: 0x0054FBDC
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteDragItem.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteDragItem.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601329D RID: 78493 RVA: 0x00551A20 File Offset: 0x0054FC20
	protected override void OnStart()
	{
		base.OnStart();
		this.Dot = (base.GetButton(2).GetOwner().GetComponentByClass(UUIItem.StaticClass()) as UUIItem);
		this.DurationBar = base.GetSlider(5);
		UUISliderComponent durationBar = this.DurationBar;
		if (durationBar != null)
		{
			durationBar.SetValue(1f, true);
		}
		UUISliderComponent durationBar2 = this.DurationBar;
		if (durationBar2 != null)
		{
			durationBar2.SetSelfInteractive(false);
		}
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		if (Singleton<Info>.Instance.IsInTouch())
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}
		else
		{
			UUIItem item2 = base.GetItem(6);
			this.LevelSequencePlayer = new LevelSequencePlayer(item2);
			base.SetAttachRootItem(item2);
		}
		this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceEndEvent), false);
		UUIDraggableComponent draggable = base.GetDraggable(1);
		draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerBeginDragCallBack));
		draggable.OnPointerDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerDragCallBack));
		draggable.OnPointerEndDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerEndDragCallBack));
		UUIButtonComponent button = base.GetButton(2);
		button.OnPointDownCallBack.Bind(new Action(this.OnButtonDown));
		button.OnPointUpCallBack.Bind(new Action(this.OnButtonUp));
		base.SetUiActive(false);
	}

	// Token: 0x0601329E RID: 78494 RVA: 0x00551B8D File Offset: 0x0054FD8D
	[NullableContext(1)]
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteDragContext;
	}

	// Token: 0x0601329F RID: 78495 RVA: 0x00551B98 File Offset: 0x0054FD98
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

	// Token: 0x060132A0 RID: 78496 RVA: 0x00551BCC File Offset: 0x0054FDCC
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		SCommonQte_Drag scommonQte_Drag = uiConfig as SCommonQte_Drag;
		if (scommonQte_Drag != null)
		{
			this.DragLength = scommonQte_Drag.SlideLength;
			this.Direction = (float)scommonQte_Drag.Direction;
		}
		string text = (scommonQte_Drag != null) ? scommonQte_Drag.UIConfig.TextId : null;
		UUIText text2 = base.GetText(3);
		if (!string.IsNullOrEmpty(text))
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, text, Array.Empty<object>());
			if (text2 != null)
			{
				text2.SetUIActive(true);
			}
		}
		UUIItem item = base.GetItem(4);
		if (item != null)
		{
			item.SetUIActive(this.CommonQteContext != null && !this.CommonQteContext.IsPermanent);
		}
		UUIItem item2 = base.GetItem(0);
		FRotator frotator = new FRotator(0f, this.Direction + 180f, 0f);
		item2.SetUIRelativeRotation(frotator);
		this.Direction *= 0.017453292f;
	}

	// Token: 0x060132A1 RID: 78497 RVA: 0x00551CA8 File Offset: 0x0054FEA8
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

	// Token: 0x060132A2 RID: 78498 RVA: 0x00551D28 File Offset: 0x0054FF28
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

	// Token: 0x060132A3 RID: 78499 RVA: 0x00551D80 File Offset: 0x0054FF80
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

	// Token: 0x060132A4 RID: 78500 RVA: 0x00551DF2 File Offset: 0x0054FFF2
	protected override void OnQtePause()
	{
		base.OnQtePause();
		this.Input.IsValid = false;
	}

	// Token: 0x060132A5 RID: 78501 RVA: 0x00551E06 File Offset: 0x00550006
	protected override bool IsUseBaseAction()
	{
		return false;
	}

	// Token: 0x060132A6 RID: 78502 RVA: 0x00551E09 File Offset: 0x00550009
	protected override void OnBindAction()
	{
		ControllerBase<InputDistributeController>.Instance.BindAxisIgnoreLimit("UiTurn", new TInputHandle<float>(this.OnInputTurn));
		ControllerBase<InputDistributeController>.Instance.BindAxisIgnoreLimit("UiLookUp", new TInputHandle<float>(this.OnInputLookup));
	}

	// Token: 0x060132A7 RID: 78503 RVA: 0x00551E41 File Offset: 0x00550041
	protected override void OnUnbindAction()
	{
		ControllerBase<InputDistributeController>.Instance.UnBindAxisIgnoreLimit("UiTurn", new TInputHandle<float>(this.OnInputTurn));
		ControllerBase<InputDistributeController>.Instance.UnBindAxisIgnoreLimit("UiLookUp", new TInputHandle<float>(this.OnInputLookup));
	}

	// Token: 0x060132A8 RID: 78504 RVA: 0x00551E7C File Offset: 0x0055007C
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

	// Token: 0x060132A9 RID: 78505 RVA: 0x00551ED0 File Offset: 0x005500D0
	[NullableContext(1)]
	private void OnInputTurn(string name, float value, InputIdentification inputIdentification)
	{
		if (!base.IsValidInput() || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.Input.IsValid = true;
		this.Input.Vector.X = (double)(value * this.DragLength * 1.43f);
		this.HasInputTurn = (value != 0f);
		this.SetIsDragging(this.HasInputTurn || this.HasInputLookup);
	}

	// Token: 0x060132AA RID: 78506 RVA: 0x00551F48 File Offset: 0x00550148
	[NullableContext(1)]
	private void OnInputLookup(string name, float value, InputIdentification inputIdentification)
	{
		if (!base.IsValidInput() || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.Input.IsValid = true;
		this.Input.Vector.Y = (double)(-(double)value * this.DragLength * 1.43f);
		this.HasInputLookup = (value != 0f);
		this.SetIsDragging(this.HasInputTurn || this.HasInputLookup);
	}

	// Token: 0x060132AB RID: 78507 RVA: 0x00551FBF File Offset: 0x005501BF
	private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction)
		{
			return;
		}
		this.StartDragPosition = new FVector?(eventData.GetLocalPointInPlane());
		this.SetIsDragging(true);
	}

	// Token: 0x060132AC RID: 78508 RVA: 0x00551FEC File Offset: 0x005501EC
	private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction)
		{
			return;
		}
		if (Singleton<TouchFingerManager>.Instance.GetTouchFingerCount() > 1)
		{
			this.StartDragPosition = null;
			this.Input.IsValid = false;
			return;
		}
		FVector localPointInPlane = eventData.GetLocalPointInPlane();
		this.Input.Vector.Y = (double)(localPointInPlane.Y - this.StartDragPosition.Value.Y);
		this.Input.Vector.X = (double)(localPointInPlane.X - this.StartDragPosition.Value.X);
	}

	// Token: 0x060132AD RID: 78509 RVA: 0x00552088 File Offset: 0x00550288
	private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!base.IsValidInput() || !this.HasBindAction)
		{
			return;
		}
		this.StartDragPosition = null;
		this.Input.IsValid = false;
		this.Input.Vector.Reset();
		this.SetIsDragging(false);
	}

	// Token: 0x060132AE RID: 78510 RVA: 0x005520D5 File Offset: 0x005502D5
	private void OnButtonDown()
	{
		this.Input.IsValid = true;
	}

	// Token: 0x060132AF RID: 78511 RVA: 0x005520E3 File Offset: 0x005502E3
	private void OnButtonUp()
	{
		this.Input.IsValid = false;
		this.Input.Vector.Reset();
	}

	// Token: 0x060132B0 RID: 78512 RVA: 0x00552101 File Offset: 0x00550301
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

	// Token: 0x060132B1 RID: 78513 RVA: 0x00552138 File Offset: 0x00550338
	protected override void OnTickQteItem(float delta)
	{
		if (!this.CommonQteContext.IsPermanent)
		{
			UUISliderComponent durationBar = this.DurationBar;
			if (durationBar != null)
			{
				CommonQteDragContext commonQteContext = this.CommonQteContext;
				durationBar.SetValue((commonQteContext != null) ? commonQteContext.GetRemainingTimeProgress() : 1f, true);
			}
		}
		if (!this.Input.IsValid)
		{
			if (!this.HasResetDot)
			{
				this.Input.Vector.Reset();
				this.HasResetDot = true;
				this.Dot.SetAnchorOffsetX(0f);
				this.Dot.SetAnchorOffsetY(0f);
			}
			return;
		}
		this.HasResetDot = false;
		float num = (float)this.Input.Vector.Size2D();
		float angle = (float)this.Input.Vector.HeadingAngle();
		if (num < this.DragLength)
		{
			this.Dot.SetAnchorOffsetX((float)this.Input.Vector.X);
			this.Dot.SetAnchorOffsetY((float)this.Input.Vector.Y);
		}
		else
		{
			float num2 = this.DragLength / num;
			this.Dot.SetAnchorOffsetX((float)(this.Input.Vector.X * (double)num2));
			this.Dot.SetAnchorOffsetY((float)(this.Input.Vector.Y * (double)num2));
		}
		this.CommonQteContext.SetDraggingInfo(num, angle);
	}

	// Token: 0x0400958A RID: 38282
	private const float GAMEPAD_ENHANCE_RATE = 1.43f;

	// Token: 0x0400958B RID: 38283
	private UUIItem Dot;

	// Token: 0x0400958C RID: 38284
	private UUISliderComponent DurationBar;

	// Token: 0x0400958D RID: 38285
	private InputMultiKeyItem KeyItem;

	// Token: 0x0400958E RID: 38286
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x0400958F RID: 38287
	private float DragLength;

	// Token: 0x04009590 RID: 38288
	private bool HasResetDot;

	// Token: 0x04009591 RID: 38289
	private float Direction;

	// Token: 0x04009592 RID: 38290
	[Nullable(1)]
	private readonly CommonQteDragItem.InputHandle Input = new CommonQteDragItem.InputHandle();

	// Token: 0x04009593 RID: 38291
	private bool HasInputTurn;

	// Token: 0x04009594 RID: 38292
	private bool HasInputLookup;

	// Token: 0x04009595 RID: 38293
	private bool IsDragging;

	// Token: 0x04009596 RID: 38294
	private FVector? StartDragPosition;

	// Token: 0x020089B5 RID: 35253
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E755 RID: 190293
		Offset,
		// Token: 0x0402E756 RID: 190294
		Drag,
		// Token: 0x0402E757 RID: 190295
		Dot,
		// Token: 0x0402E758 RID: 190296
		Description,
		// Token: 0x0402E759 RID: 190297
		DurationPanel,
		// Token: 0x0402E75A RID: 190298
		DurationBar,
		// Token: 0x0402E75B RID: 190299
		AnimItem,
		// Token: 0x0402E75C RID: 190300
		HotKey
	}

	// Token: 0x020089B6 RID: 35254
	[NullableContext(0)]
	private class InputHandle
	{
		// Token: 0x0402E75D RID: 190301
		[Nullable(1)]
		public Vector Vector = Vector.Create();

		// Token: 0x0402E75E RID: 190302
		public bool IsValid;
	}
}
