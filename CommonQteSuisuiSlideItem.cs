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

// Token: 0x02002627 RID: 9767
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CommonQteSuisuiSlideItem : CommonQteItemBase<CommonQteDragContext>
{
	// Token: 0x0601338C RID: 78732 RVA: 0x00556F2C File Offset: 0x0055512C
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

	// Token: 0x0601338D RID: 78733 RVA: 0x00556FC4 File Offset: 0x005551C4
	protected override UniTask OnBeforeStartAsync()
	{
		CommonQteSuisuiSlideItem.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<CommonQteSuisuiSlideItem.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601338E RID: 78734 RVA: 0x00557008 File Offset: 0x00555208
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

	// Token: 0x0601338F RID: 78735 RVA: 0x005570CE File Offset: 0x005552CE
	[NullableContext(1)]
	protected override bool IsContextMatched(CommonQteContextBase context)
	{
		return context is CommonQteDragContext;
	}

	// Token: 0x06013390 RID: 78736 RVA: 0x005570D9 File Offset: 0x005552D9
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

	// Token: 0x06013391 RID: 78737 RVA: 0x0055710C File Offset: 0x0055530C
	protected override void TryApplyQteUiConfig(object uiConfig)
	{
		SCommonQte_Drag scommonQte_Drag = uiConfig as SCommonQte_Drag;
		if (scommonQte_Drag == null)
		{
			return;
		}
		this.LeftSlideLength = Math.Max(0f, scommonQte_Drag.LeftSlideLength);
		this.RightSlideLength = Math.Max(0f, scommonQte_Drag.RightSlideLength);
		this.LerpSpeed = scommonQte_Drag.LerpSpeed / 1000f;
		this.RewardSpeed = ((scommonQte_Drag.RewardSpeed > 0f) ? (scommonQte_Drag.RewardSpeed / 1000f) : this.LerpSpeed);
		this.CheckByRealTimeInput = scommonQte_Drag.CheckByRealTimeInput;
		this.BackwardWhenFail = scommonQte_Drag.BackwardWhenFail;
		this.IsBackingToCenter = false;
	}

	// Token: 0x06013392 RID: 78738 RVA: 0x005571B0 File Offset: 0x005553B0
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

	// Token: 0x06013393 RID: 78739 RVA: 0x00557230 File Offset: 0x00555430
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

	// Token: 0x06013394 RID: 78740 RVA: 0x00557288 File Offset: 0x00555488
	protected override void RefreshUiOffset()
	{
		if (this.CommonQteContext == null)
		{
			return;
		}
		SCommonQte_Drag scommonQte_Drag = this.CommonQteContext.GetUiConfig() as SCommonQte_Drag;
		if (scommonQte_Drag == null)
		{
			return;
		}
		SCommonQteButton uiconfig = scommonQte_Drag.UIConfig;
		this.RootItem.SetAnchorAlign(uiconfig.AnchorHAlign, uiconfig.AnchorVAlign);
		this.RootItem.SetAnchorOffset(uiconfig.AnchorOffset);
		if (this.IsAttaching)
		{
			this.Reattach(this.CommonQteContext);
		}
	}

	// Token: 0x06013395 RID: 78741 RVA: 0x005572FC File Offset: 0x005554FC
	protected override bool IsUseBaseAction()
	{
		return false;
	}

	// Token: 0x06013396 RID: 78742 RVA: 0x005572FF File Offset: 0x005554FF
	protected override void OnBindAction()
	{
		ControllerBase<InputDistributeController>.Instance.BindAxisIgnoreLimit("UiScroll2", new TInputHandle<float>(this.OnInputTurn));
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
	}

	// Token: 0x06013397 RID: 78743 RVA: 0x00557338 File Offset: 0x00555538
	protected override void OnUnbindAction()
	{
		ControllerBase<InputDistributeController>.Instance.UnBindAxisIgnoreLimit("UiScroll2", new TInputHandle<float>(this.OnInputTurn));
		Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
	}

	// Token: 0x06013398 RID: 78744 RVA: 0x00557374 File Offset: 0x00555574
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

	// Token: 0x06013399 RID: 78745 RVA: 0x005573C6 File Offset: 0x005555C6
	private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		if (!Singleton<Info>.Instance.IsInGamepad())
		{
			this.InputX = 0f;
			this.HasInputTurn = false;
		}
		this.DerivedOffset = 0f;
		this.SetIsDragging(false);
	}

	// Token: 0x0601339A RID: 78746 RVA: 0x005573F8 File Offset: 0x005555F8
	[NullableContext(1)]
	private void OnInputTurn(string name, float value, InputIdentification inputIdentification)
	{
		if (!this.IsValidSlideInput() || !Singleton<Info>.Instance.IsInGamepad())
		{
			return;
		}
		this.InputX = value;
		this.HasInputTurn = (value != 0f);
		this.SetIsDragging(this.HasInputTurn);
	}

	// Token: 0x0601339B RID: 78747 RVA: 0x00557433 File Offset: 0x00555633
	private void OnPointerDownCallBack(ULGUIPointerEventData eventData)
	{
		if (this.IsBackingToCenter)
		{
			return;
		}
		this.DerivedOffset = this.CacheOffset;
	}

	// Token: 0x0601339C RID: 78748 RVA: 0x0055744A File Offset: 0x0055564A
	private void OnPointerUpCallBack(ULGUIPointerEventData eventData)
	{
		if (this.IsBackingToCenter)
		{
			return;
		}
		this.DerivedOffset = 0f;
	}

	// Token: 0x0601339D RID: 78749 RVA: 0x00557460 File Offset: 0x00555660
	private void OnPointerBeginDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!this.IsValidSlideInput())
		{
			return;
		}
		this.StartDragPosition = new FVector?(eventData.GetLocalPointInPlane());
		this.SetIsDragging(true);
	}

	// Token: 0x0601339E RID: 78750 RVA: 0x00557484 File Offset: 0x00555684
	private void OnPointerDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!this.IsValidSlideInput())
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
		this.InputX = localPointInPlane.X - this.StartDragPosition.Value.X;
	}

	// Token: 0x0601339F RID: 78751 RVA: 0x005574E6 File Offset: 0x005556E6
	private void OnPointerEndDragCallBack(ULGUIPointerEventData eventData)
	{
		if (!this.IsValidSlideInput())
		{
			return;
		}
		this.DerivedOffset = 0f;
		this.StartDragPosition = null;
		this.InputX = 0f;
		this.SetIsDragging(false);
	}

	// Token: 0x060133A0 RID: 78752 RVA: 0x0055751A File Offset: 0x0055571A
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

	// Token: 0x060133A1 RID: 78753 RVA: 0x00557551 File Offset: 0x00555751
	private bool IsValidSlideInput()
	{
		return !this.IsBackingToCenter && base.IsValidInput() && this.HasBindAction;
	}

	// Token: 0x060133A2 RID: 78754 RVA: 0x0055756C File Offset: 0x0055576C
	protected override void OnTickQteItem(float delta)
	{
		if (this.IsBackingToCenter)
		{
			this.UpdateBackingToCenter(delta);
			return;
		}
		bool flag = !this.IsDragging && (double)Math.Abs(this.CacheOffset) > 1E-08;
		float num2;
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			float num = (this.InputX >= 0f) ? this.RightSlideLength : (-this.LeftSlideLength);
			if (this.LerpSpeed > 0f)
			{
				if ((double)Math.Abs(this.InputX) <= 1E-08)
				{
					this.CacheOffset = Singleton<MathUtils>.Instance.InterpConstantTo(this.CacheOffset, 0f, delta, this.LerpSpeed);
				}
				else
				{
					this.CacheOffset = Singleton<MathUtils>.Instance.InterpConstantTo(this.CacheOffset, num, delta, this.LerpSpeed * Math.Abs(this.InputX));
				}
			}
			else
			{
				this.CacheOffset = num;
			}
			num2 = this.CacheOffset;
		}
		else
		{
			num2 = this.InputX + this.DerivedOffset;
			if (this.LerpSpeed > 0f)
			{
				this.CacheOffset = Singleton<MathUtils>.Instance.InterpConstantTo(this.CacheOffset, num2, delta, this.LerpSpeed);
			}
			else
			{
				this.CacheOffset = num2;
			}
		}
		this.CacheOffset = this.ClampOffset(this.CacheOffset);
		float num3 = this.OffsetToProgress(this.CacheOffset);
		this.CommonQteContext.SetDraggingInfo(num3, 0f);
		float num4 = this.OffsetToProgress(num2);
		float length = this.CheckByRealTimeInput ? num4 : num3;
		float progress = (this.CheckByRealTimeInput && !this.BackwardWhenFail) ? num4 : num3;
		CommonQteDragContext commonQteContext = this.CommonQteContext;
		if (!commonQteContext.IsPending())
		{
			return;
		}
		if (flag && (double)Math.Abs(this.CacheOffset) <= 1E-08)
		{
			this.CacheOffset = 0f;
			commonQteContext.SetDraggingInfo(0.5f, 0f);
			commonQteContext.StopMoveAudioAndSyncProgress();
		}
		bool flag2 = commonQteContext.CheckDragComplete(length, 0f);
		if (flag2 || commonQteContext.CheckDragFail(progress))
		{
			if (!flag2)
			{
				if (this.BackwardWhenFail)
				{
					this.StartBackingToCenter();
					return;
				}
				if (this.CheckByRealTimeInput)
				{
					commonQteContext.SetPreResult(false);
				}
				commonQteContext.QteFail();
				return;
			}
			else
			{
				if (this.CheckByRealTimeInput)
				{
					commonQteContext.SetPreResult(true);
				}
				commonQteContext.CheckQteConditionAndDoSuccess();
			}
		}
	}

	// Token: 0x060133A3 RID: 78755 RVA: 0x005577B0 File Offset: 0x005559B0
	private float ClampOffset(float offset)
	{
		float min = (this.LeftSlideLength > 0f) ? (-this.LeftSlideLength) : 0f;
		float max = (this.RightSlideLength > 0f) ? this.RightSlideLength : 0f;
		return Singleton<MathUtils>.Instance.Clamp(offset, min, max);
	}

	// Token: 0x060133A4 RID: 78756 RVA: 0x00557804 File Offset: 0x00555A04
	private float OffsetToProgress(float offset)
	{
		float num = this.ClampOffset(offset);
		if (num < 0f)
		{
			if (this.LeftSlideLength <= 0f)
			{
				return 0.5f;
			}
			return Singleton<MathUtils>.Instance.Clamp(0.5f + num / (2f * this.LeftSlideLength), 0f, 0.5f);
		}
		else
		{
			if (this.RightSlideLength <= 0f)
			{
				return 0.5f;
			}
			return Singleton<MathUtils>.Instance.Clamp(0.5f + num / (2f * this.RightSlideLength), 0.5f, 1f);
		}
	}

	// Token: 0x060133A5 RID: 78757 RVA: 0x00557898 File Offset: 0x00555A98
	private float ProgressToOffset(float progress)
	{
		float num = Singleton<MathUtils>.Instance.Clamp(progress, 0f, 1f);
		if (num < 0.5f)
		{
			return (num - 0.5f) * 2f * this.LeftSlideLength;
		}
		return (num - 0.5f) * 2f * this.RightSlideLength;
	}

	// Token: 0x060133A6 RID: 78758 RVA: 0x005578EC File Offset: 0x00555AEC
	private void StartBackingToCenter()
	{
		this.IsBackingToCenter = true;
		this.InputX = 0f;
		this.HasInputTurn = false;
		this.DerivedOffset = 0f;
		this.StartDragPosition = null;
		this.SetIsDragging(false);
	}

	// Token: 0x060133A7 RID: 78759 RVA: 0x00557928 File Offset: 0x00555B28
	private void UpdateBackingToCenter(float delta)
	{
		float num = this.OffsetToProgress(this.CacheOffset);
		float num2 = (num < 0.5f) ? this.LeftSlideLength : this.RightSlideLength;
		float interpSpeed = (num2 > 0f) ? (this.RewardSpeed * 0.5f / num2) : 0f;
		float num3;
		if (this.RewardSpeed > 0f && num2 > 0f)
		{
			num3 = Singleton<MathUtils>.Instance.InterpConstantTo(num, 0.5f, delta, interpSpeed);
		}
		else
		{
			num3 = 0.5f;
		}
		this.CacheOffset = this.ProgressToOffset(num3);
		CommonQteDragContext commonQteContext = this.CommonQteContext;
		if (commonQteContext != null)
		{
			commonQteContext.SetDraggingInfo(num3, 0f);
		}
		if ((double)Math.Abs(num3 - 0.5f) <= 1E-08)
		{
			this.CacheOffset = 0f;
			this.IsBackingToCenter = false;
			CommonQteDragContext commonQteContext2 = this.CommonQteContext;
			if (commonQteContext2 != null)
			{
				commonQteContext2.SetDraggingInfo(0.5f, 0f);
			}
			CommonQteDragContext commonQteContext3 = this.CommonQteContext;
			if (commonQteContext3 == null)
			{
				return;
			}
			commonQteContext3.StopMoveAudioAndSyncProgress();
		}
	}

	// Token: 0x040095FF RID: 38399
	private const float CENTER_PROGRESS = 0.5f;

	// Token: 0x04009600 RID: 38400
	private InputMultiKeyItem KeyItem;

	// Token: 0x04009601 RID: 38401
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04009602 RID: 38402
	private float LeftSlideLength;

	// Token: 0x04009603 RID: 38403
	private float RightSlideLength;

	// Token: 0x04009604 RID: 38404
	private float LerpSpeed;

	// Token: 0x04009605 RID: 38405
	private float RewardSpeed;

	// Token: 0x04009606 RID: 38406
	private float CacheOffset;

	// Token: 0x04009607 RID: 38407
	private float DerivedOffset;

	// Token: 0x04009608 RID: 38408
	private float InputX;

	// Token: 0x04009609 RID: 38409
	private bool HasInputTurn;

	// Token: 0x0400960A RID: 38410
	private bool IsDragging;

	// Token: 0x0400960B RID: 38411
	private bool CheckByRealTimeInput;

	// Token: 0x0400960C RID: 38412
	private bool BackwardWhenFail;

	// Token: 0x0400960D RID: 38413
	private bool IsBackingToCenter;

	// Token: 0x0400960E RID: 38414
	private FVector? StartDragPosition;

	// Token: 0x020089CD RID: 35277
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0402E7D3 RID: 190419
		Perfab,
		// Token: 0x0402E7D4 RID: 190420
		Drag,
		// Token: 0x0402E7D5 RID: 190421
		HotKey
	}
}
