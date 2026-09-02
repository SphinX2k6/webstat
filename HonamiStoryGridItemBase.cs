using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F0D RID: 7949
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryGridItemBase : UiPanelBase
{
	// Token: 0x0600ED42 RID: 60738 RVA: 0x0040AF10 File Offset: 0x00409110
	public HonamiStoryGridItemBase(bool needItem, HonamiStoryBackpackPanelBase panel = null, HonamiStoryItemDataBase itemData = null)
	{
		this.NeedItem = needItem;
		if (panel != null)
		{
			this.Panel = panel;
		}
		if (itemData != null)
		{
			this.Data = itemData;
		}
	}

	// Token: 0x17001223 RID: 4643
	// (get) Token: 0x0600ED43 RID: 60739 RVA: 0x0040AFE1 File Offset: 0x004091E1
	private bool NeedItem { get; }

	// Token: 0x0600ED44 RID: 60740 RVA: 0x0040AFEC File Offset: 0x004091EC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickedGridButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600ED45 RID: 60741 RVA: 0x0040B0B4 File Offset: 0x004092B4
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryGridItemBase.<OnBeforeStartAsync>d__38 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryGridItemBase.<OnBeforeStartAsync>d__38>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600ED46 RID: 60742 RVA: 0x0040B0F8 File Offset: 0x004092F8
	protected override void OnStart()
	{
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		float viewportScale = UWidgetLayoutLibrary.GetViewportScale(GlobalData.World);
		this.ScreenHeight = viewportSize.Y / viewportScale;
		this.DragDistanceThreshold = viewportScale * 40f;
		this.DragSpeedThreshold = (float)ConfigBase<HonamiStoryConfig>.Instance.GetDragThresholdSpeed();
		this.SpriteBg = base.GetSprite(1);
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			button.OnPointDownCallBack.Bind(new Action(this.OnBtnPointDown));
		}
		UUIButtonComponent button2 = base.GetButton(2);
		if (button2 != null)
		{
			button2.OnPointEnterCallBack.Bind(new Action(this.OnBtnPointEnter));
		}
		UUIButtonComponent button3 = base.GetButton(2);
		if (button3 == null)
		{
			return;
		}
		button3.OnPointExitCallBack.Bind(new Action(this.OnBtnPointExit));
	}

	// Token: 0x0600ED47 RID: 60743 RVA: 0x0040B1C0 File Offset: 0x004093C0
	protected override void OnBeforeDestroy()
	{
		UUIButtonComponent button = base.GetButton(2);
		if (button != null)
		{
			button.OnPointDownCallBack.Unbind();
		}
		UUIButtonComponent button2 = base.GetButton(2);
		if (button2 != null)
		{
			button2.OnPointEnterCallBack.Unbind();
		}
		UUIButtonComponent button3 = base.GetButton(2);
		if (button3 == null)
		{
			return;
		}
		button3.OnPointExitCallBack.Unbind();
	}

	// Token: 0x17001224 RID: 4644
	// (get) Token: 0x0600ED48 RID: 60744 RVA: 0x0040B211 File Offset: 0x00409411
	private HonamiStoryItemDataBase ItemData
	{
		get
		{
			return this.Data;
		}
	}

	// Token: 0x0600ED49 RID: 60745 RVA: 0x0040B219 File Offset: 0x00409419
	[NullableContext(1)]
	public HonamiStoryBackpackPanelBase GetPanel()
	{
		return this.Panel;
	}

	// Token: 0x0600ED4A RID: 60746 RVA: 0x0040B221 File Offset: 0x00409421
	public int GetEmptyPosition()
	{
		return this.EmptyPosition;
	}

	// Token: 0x0600ED4B RID: 60747 RVA: 0x0040B229 File Offset: 0x00409429
	public HonamiStoryItemGridItem GetItemGridItem()
	{
		return this.ItemGridItem;
	}

	// Token: 0x0600ED4C RID: 60748 RVA: 0x0040B231 File Offset: 0x00409431
	[NullableContext(1)]
	public void RegisterPanel(HonamiStoryBackpackPanelBase panel)
	{
		this.Panel = panel;
	}

	// Token: 0x0600ED4D RID: 60749 RVA: 0x0040B23A File Offset: 0x0040943A
	[NullableContext(1)]
	protected virtual HonamiStoryItemGridItem CreateGridItem([Nullable(2)] HonamiStoryItemDataBase data)
	{
		return new HonamiStoryItemGridItem(data);
	}

	// Token: 0x0600ED4E RID: 60750 RVA: 0x0040B244 File Offset: 0x00409444
	protected UniTask InitItemGridItem(HonamiStoryItemDataBase data, int position)
	{
		HonamiStoryGridItemBase.<InitItemGridItem>d__48 <InitItemGridItem>d__;
		<InitItemGridItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitItemGridItem>d__.<>4__this = this;
		<InitItemGridItem>d__.data = data;
		<InitItemGridItem>d__.position = position;
		<InitItemGridItem>d__.<>1__state = -1;
		<InitItemGridItem>d__.<>t__builder.Start<HonamiStoryGridItemBase.<InitItemGridItem>d__48>(ref <InitItemGridItem>d__);
		return <InitItemGridItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600ED4F RID: 60751 RVA: 0x0040B298 File Offset: 0x00409498
	protected UniTask InitSweepItem(HonamiStoryItemDataBase data)
	{
		HonamiStoryGridItemBase.<InitSweepItem>d__49 <InitSweepItem>d__;
		<InitSweepItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSweepItem>d__.<>4__this = this;
		<InitSweepItem>d__.<>1__state = -1;
		<InitSweepItem>d__.<>t__builder.Start<HonamiStoryGridItemBase.<InitSweepItem>d__49>(ref <InitSweepItem>d__);
		return <InitSweepItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600ED50 RID: 60752 RVA: 0x0040B2DC File Offset: 0x004094DC
	public virtual void Refresh(HonamiStoryItemDataBase data, int position)
	{
		this.Data = data;
		if (this.IsForDrag)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
		}
		if (data == null)
		{
			this.EmptyPosition = position;
			this.CheckOverflowEnable(position, false);
			this.SetSpriteByPath("/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity28/HonamiStory/HonamiStoryBackpack/SP_GridEmpty.SP_GridEmpty", base.GetSprite(1), false, null, null);
			HonamiStoryItemGridItem itemGridItem = this.ItemGridItem;
			if (itemGridItem != null)
			{
				itemGridItem.SetUiActive(false);
			}
			this.ClearSequence();
			return;
		}
		if (this.ItemGridItem == null)
		{
			this.InitItemGridItem(data, position).ContinueWith(delegate()
			{
				this.PlayNewlyPickedUpSweepAnimation(data);
			});
			return;
		}
		this.ItemGridItem.SetUiActive(true);
		this.ItemGridItem.Refresh(data, position != -1);
		this.CheckOverflowEnable(position, true);
		this.SetSpriteByPath(data.GetQualityConfig().Value.GridBg, base.GetSprite(1), false, null, null);
		this.PlayNewlyPickedUpSweepAnimation(data);
	}

	// Token: 0x0600ED51 RID: 60753 RVA: 0x0040B406 File Offset: 0x00409606
	public int GetIncId()
	{
		HonamiStoryItemDataBase itemData = this.ItemData;
		if (itemData == null)
		{
			return -1;
		}
		return itemData.GetIncId();
	}

	// Token: 0x0600ED52 RID: 60754 RVA: 0x0040B419 File Offset: 0x00409619
	public HonamiStoryItemDataBase GetData()
	{
		return this.Data;
	}

	// Token: 0x0600ED53 RID: 60755 RVA: 0x0040B421 File Offset: 0x00409621
	public void SetIsForDrag(bool value)
	{
		this.IsForDrag = value;
	}

	// Token: 0x0600ED54 RID: 60756 RVA: 0x0040B42C File Offset: 0x0040962C
	[NullableContext(1)]
	public UniTask PlaySequenceByName(string sequenceName)
	{
		HonamiStoryGridItemBase.<PlaySequenceByName>d__54 <PlaySequenceByName>d__;
		<PlaySequenceByName>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySequenceByName>d__.<>4__this = this;
		<PlaySequenceByName>d__.sequenceName = sequenceName;
		<PlaySequenceByName>d__.<>1__state = -1;
		<PlaySequenceByName>d__.<>t__builder.Start<HonamiStoryGridItemBase.<PlaySequenceByName>d__54>(ref <PlaySequenceByName>d__);
		return <PlaySequenceByName>d__.<>t__builder.Task;
	}

	// Token: 0x0600ED55 RID: 60757 RVA: 0x0040B477 File Offset: 0x00409677
	public void PlayPosChangeSweepAnimation()
	{
		this.PlaySequenceByName("Sweep_In");
	}

	// Token: 0x0600ED56 RID: 60758 RVA: 0x0040B485 File Offset: 0x00409685
	[NullableContext(1)]
	public void PlayNewlyPickedUpSweepAnimation(HonamiStoryItemDataBase data)
	{
		if (!data.GetNewInBackpack())
		{
			return;
		}
		this.PlaySequenceByName("Sweep_Tips");
		data.SetNewInBackpack(false);
	}

	// Token: 0x0600ED57 RID: 60759 RVA: 0x0040B4A3 File Offset: 0x004096A3
	protected void ClearSequence()
	{
		HonamiStoryItemSweepItem sweepItem = this.SweepItem;
		if (sweepItem == null)
		{
			return;
		}
		sweepItem.ClearSequence();
	}

	// Token: 0x0600ED58 RID: 60760 RVA: 0x0040B4B8 File Offset: 0x004096B8
	protected bool CheckOverflowEnable(int position, bool notEmpty)
	{
		if (this.Panel == null)
		{
			return false;
		}
		bool flag = this.Panel.GetBackpackType() == 0;
		if (position == -1 || !flag)
		{
			return false;
		}
		HonamiStoryBackpackData backpackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData(1, false);
		if (notEmpty)
		{
			UiPanelBase overflowItem = this.OverflowItem;
			if (overflowItem != null)
			{
				overflowItem.SetUiActive(false);
			}
			int heightCount = backpackData.GetHeightCount(false);
			bool flag2 = this.ItemData.GetRow() + this.ItemData.GetGridHeight() > heightCount;
			HonamiStoryItemGridItem itemGridItem = this.ItemGridItem;
			if (itemGridItem != null)
			{
				itemGridItem.SetOverFlowEnable(flag2);
			}
			return flag2;
		}
		int capacity = backpackData.GetCapacity();
		if (position < capacity)
		{
			UiPanelBase overflowItem2 = this.OverflowItem;
			if (overflowItem2 != null)
			{
				overflowItem2.SetUiActive(false);
			}
			return false;
		}
		if (this.OverflowItem != null && !this.OverflowItem.InAsyncLoading())
		{
			this.OverflowItem.SetUiActive(true);
		}
		else
		{
			this.OverflowItem = new UiPanelBase();
			this.OverflowItem.CreateThenShowByResourceIdAsync("UiItem_HonamiStoryItemTagEmptyOverflow", this.RootItem, false).ContinueWith(delegate()
			{
				if (this.ItemGridItem != null && this.ItemGridItem.IsUiActiveInHierarchy())
				{
					UiPanelBase overflowItem3 = this.OverflowItem;
					if (overflowItem3 == null)
					{
						return;
					}
					overflowItem3.SetUiActive(false);
					return;
				}
				else
				{
					int capacity2 = backpackData.GetCapacity();
					UiPanelBase overflowItem4 = this.OverflowItem;
					if (overflowItem4 == null)
					{
						return;
					}
					overflowItem4.SetUiActive(this.EmptyPosition >= capacity2);
					return;
				}
			});
		}
		return true;
	}

	// Token: 0x0600ED59 RID: 60761 RVA: 0x0040B5D5 File Offset: 0x004097D5
	private void OnClickedGridButton()
	{
		this.DoClickedGridButton();
	}

	// Token: 0x0600ED5A RID: 60762 RVA: 0x0040B5E0 File Offset: 0x004097E0
	protected virtual void OnBtnPointDown()
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		if (backpackLogicState == EHonamiStoryBackpackLogicState.TipsWithPlugins || backpackLogicState == EHonamiStoryBackpackLogicState.Tips)
		{
			ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().CloseTips();
		}
	}

	// Token: 0x0600ED5B RID: 60763 RVA: 0x0040B60F File Offset: 0x0040980F
	private void OnBtnPointEnter()
	{
		ModelBase<HonamiStoryModel>.Instance.GetInteractController().OnHoverItem(true, base.GetButton(2).RootUIComp);
	}

	// Token: 0x0600ED5C RID: 60764 RVA: 0x0040B632 File Offset: 0x00409832
	private void OnBtnPointExit()
	{
		ModelBase<HonamiStoryModel>.Instance.GetInteractController().OnUnHover();
	}

	// Token: 0x0600ED5D RID: 60765 RVA: 0x0040B644 File Offset: 0x00409844
	protected virtual void DoClickedGridButton()
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		if (backpackLogicState == EHonamiStoryBackpackLogicState.Normal)
		{
			return;
		}
		if (backpackLogicState == EHonamiStoryBackpackLogicState.TipsWithPlugins || backpackLogicState == EHonamiStoryBackpackLogicState.Tips)
		{
			ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().CloseTips();
		}
		if (backpackLogicState == EHonamiStoryBackpackLogicState.Instead)
		{
			ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
		}
	}

	// Token: 0x0600ED5E RID: 60766 RVA: 0x0040B686 File Offset: 0x00409886
	public void CancelItemToggleSelect()
	{
		HonamiStoryItemGridItem itemGridItem = this.ItemGridItem;
		if (itemGridItem == null)
		{
			return;
		}
		itemGridItem.CancelToggleSelect();
	}

	// Token: 0x0600ED5F RID: 60767 RVA: 0x0040B698 File Offset: 0x00409898
	private bool IsCanDragState(bool isBegin)
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		if (isBegin)
		{
			return this.Data != null && (backpackLogicState == EHonamiStoryBackpackLogicState.Normal || backpackLogicState == EHonamiStoryBackpackLogicState.Tips || backpackLogicState == EHonamiStoryBackpackLogicState.TipsWithPlugins);
		}
		return this.CanDrag && (backpackLogicState == EHonamiStoryBackpackLogicState.Normal || backpackLogicState == EHonamiStoryBackpackLogicState.DraggingPlugins || backpackLogicState == EHonamiStoryBackpackLogicState.Dragging);
	}

	// Token: 0x0600ED60 RID: 60768 RVA: 0x0040B6E4 File Offset: 0x004098E4
	private bool TrySellStateDragLogic(bool isBegin, ULGUIPointerEventData eventData)
	{
		if (ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState() != EHonamiStoryBackpackLogicState.Sell)
		{
			return false;
		}
		HonamiStoryInteractController interactController = ModelBase<HonamiStoryModel>.Instance.GetInteractController();
		if (!isBegin)
		{
			interactController.IsSellDragging = false;
			return true;
		}
		if (this.IsGamepadDragging)
		{
			interactController.IsSellDragging = true;
			this.ItemGridItem.DoSellLogic();
			return true;
		}
		Vector currentSellPosition = this.CurrentSellPosition;
		FVector pointerPosition = eventData.pointerPosition;
		FVectorDouble fvectorDouble = pointerPosition;
		currentSellPosition.DeepCopy(fvectorDouble);
		double angleByVector2D = Singleton<MathUtils>.Instance.GetAngleByVector2D(this.CurrentSellPosition.SubtractionEqual(this.LastSellPosition));
		if (Math.Abs(angleByVector2D) < 75.0 || Math.Abs(angleByVector2D) > 105.0)
		{
			interactController.IsSellDragging = true;
			this.ItemGridItem.DoSellLogic();
			return true;
		}
		return false;
	}

	// Token: 0x0600ED61 RID: 60769 RVA: 0x0040B7A4 File Offset: 0x004099A4
	private void CloseTipsWhenBeginDrag()
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		if (backpackLogicState != EHonamiStoryBackpackLogicState.Tips && backpackLogicState != EHonamiStoryBackpackLogicState.TipsWithPlugins)
		{
			return;
		}
		ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().CloseTips();
	}

	// Token: 0x0600ED62 RID: 60770 RVA: 0x0040B7D4 File Offset: 0x004099D4
	public void PlayMoveItemSeq()
	{
		if (!this.IsForDrag)
		{
			return;
		}
		this.ItemGridItem.PlayMoveItemSeq();
	}

	// Token: 0x0600ED63 RID: 60771 RVA: 0x0040B7EA File Offset: 0x004099EA
	private void RemovePointerDownTimer()
	{
		if (this.LastPointerTimer != null && this.LastPointerTimer.Valid())
		{
			TimerSystem.GameplayTimeInstance.Remove(this.LastPointerTimer);
		}
		this.LastPointerTimer = null;
	}

	// Token: 0x0600ED64 RID: 60772 RVA: 0x0040B819 File Offset: 0x00409A19
	public void MarkUseCancel()
	{
		this.IsUseCancel = true;
	}

	// Token: 0x0600ED65 RID: 60773 RVA: 0x0040B822 File Offset: 0x00409A22
	public bool GetIsUseCancel()
	{
		return this.IsUseCancel;
	}

	// Token: 0x0600ED66 RID: 60774 RVA: 0x0040B82A File Offset: 0x00409A2A
	public void TriggerOnEnterGridCb()
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			Action<HonamiStoryItemGridItem> onEnterGridCb = this.OnEnterGridCb;
			if (onEnterGridCb == null)
			{
				return;
			}
			onEnterGridCb(this.ItemGridItem);
		}
	}

	// Token: 0x0600ED67 RID: 60775 RVA: 0x0040B850 File Offset: 0x00409A50
	protected void InitDraggable()
	{
		UUIExtendToggle draggableComponent = this.ItemGridItem.DraggableComponent;
		draggableComponent.OnPointEnterCallBack.Bind(new Action<EToggleState>(this.OnPointerEnter));
		draggableComponent.OnPointExitCallBack.Bind(new Action<EToggleState>(this.OnPointerExit));
		draggableComponent.OnPointDownCallBack.Bind(new Action<EToggleState>(this.OnPointerDown));
		draggableComponent.OnPointCancelCallBack.Bind(new Action<EToggleState>(this.OnPointerCancel));
		draggableComponent.OnPointUpCallBack.Bind(new Action<EToggleState>(this.OnPointerUp));
		draggableComponent.OnPointerBeginDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnDragBegin));
		draggableComponent.OnPointerDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnDrag));
		draggableComponent.OnPointerEndDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnDragEnd));
	}

	// Token: 0x0600ED68 RID: 60776 RVA: 0x0040B920 File Offset: 0x00409B20
	public void OnPointerEnter(EToggleState _)
	{
		if (ModelBase<HonamiStoryModel>.Instance.GetInteractController().IsSellDragging)
		{
			this.ItemGridItem.DoSellLogic();
		}
		if (this.IsDragging || this.OnEnterGridCb == null)
		{
			return;
		}
		this.OnEnterGridCb(this.ItemGridItem);
		ModelBase<HonamiStoryModel>.Instance.GetInteractController().OnHoverItem(false, this.ItemGridItem.GetPanelForHover());
	}

	// Token: 0x0600ED69 RID: 60777 RVA: 0x0040B986 File Offset: 0x00409B86
	public void OnPointerExit(EToggleState _)
	{
		if (this.IsDragging || this.OnExitGridCb == null)
		{
			return;
		}
		this.OnExitGridCb();
		ModelBase<HonamiStoryModel>.Instance.GetInteractController().OnUnHover();
	}

	// Token: 0x0600ED6A RID: 60778 RVA: 0x0040B9B4 File Offset: 0x00409BB4
	public void OnPointerDown(EToggleState _)
	{
		Action onDownGridCb = this.OnDownGridCb;
		if (onDownGridCb != null)
		{
			onDownGridCb();
		}
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		if (backpackLogicState != EHonamiStoryBackpackLogicState.Normal)
		{
			if (backpackLogicState == EHonamiStoryBackpackLogicState.Sell)
			{
				ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
				if (pointerEventData != null)
				{
					Vector lastSellPosition = this.LastSellPosition;
					FVector pointerPosition = pointerEventData.pointerPosition;
					FVectorDouble fvectorDouble = pointerPosition;
					lastSellPosition.DeepCopy(fvectorDouble);
				}
			}
			return;
		}
		this.ItemGridItem.SetCanOpenTips(true);
		ULGUIPointerEventData pointerEventData2 = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
		if (pointerEventData2 != null)
		{
			this.MoveDistanceX = 0.0;
			this.MoveDistanceY = 0.0;
			Vector lastPosition = this.LastPosition;
			FVector pointerPosition = pointerEventData2.pointerPosition;
			FVectorDouble fvectorDouble = pointerPosition;
			lastPosition.DeepCopy(fvectorDouble);
			this.CanDrag = true;
			this.LastPointerDownTime = Singleton<Time>.Instance.Now;
			this.LastPointerTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_honamistory_backpack_drag");
			}, 500f, null, null, true, 1f);
		}
		this.IsGamepadDragging = ControllerBase<UiNavigationNewController>.Instance.IsNavigationMousePositionDragging();
		if (this.IsGamepadDragging)
		{
			HonamiStoryGamepadLogicController gamepadLogic = ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic();
			if (gamepadLogic != null)
			{
				gamepadLogic.PickUp(this);
			}
			this.RefreshBackpackLogicStateByDrag();
			this.Panel.OnDragBegin(pointerEventData2, this);
			this.Panel.OnDrag(pointerEventData2, this);
		}
	}

	// Token: 0x0600ED6B RID: 60779 RVA: 0x0040BB11 File Offset: 0x00409D11
	public void OnPointerCancel(EToggleState _)
	{
		if (this.IsStartDrag)
		{
			return;
		}
		this.OnPointerUp(EToggleState.ETT_UnChecked);
	}

	// Token: 0x0600ED6C RID: 60780 RVA: 0x0040BB24 File Offset: 0x00409D24
	public void OnPointerUp(EToggleState _)
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		this.RemovePointerDownTimer();
		this.ItemGridItem.SetCanOpenTips(backpackLogicState != EHonamiStoryBackpackLogicState.Dragging && backpackLogicState != EHonamiStoryBackpackLogicState.DraggingPlugins);
		if (this.IsGamepadDragging)
		{
			HonamiStoryGamepadLogicController gamepadLogic = ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic();
			if (gamepadLogic != null)
			{
				gamepadLogic.PutDown(this);
			}
			ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
			this.Panel.OnDragEnd(pointerEventData, this);
			this.IsGamepadDragging = false;
			ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
		}
	}

	// Token: 0x0600ED6D RID: 60781 RVA: 0x0040BBA4 File Offset: 0x00409DA4
	public bool OnDragBegin(ULGUIPointerEventData eventData)
	{
		this.IsStartDrag = true;
		if (this.TrySellStateDragLogic(true, eventData))
		{
			return false;
		}
		if (this.IsGamepadDragging)
		{
			return false;
		}
		if (!this.IsCanDragState(true))
		{
			return false;
		}
		Vector currentPosition = this.CurrentPosition;
		FVector pointerPosition = eventData.pointerPosition;
		FVectorDouble fvectorDouble = pointerPosition;
		currentPosition.DeepCopy(fvectorDouble);
		double num = Singleton<Time>.Instance.Now - this.LastPointerDownTime;
		if (num >= 500.0)
		{
			this.CloseTipsWhenBeginDrag();
			return false;
		}
		this.RemovePointerDownTimer();
		double angleByVector2D = Singleton<MathUtils>.Instance.GetAngleByVector2D(this.CurrentPosition.SubtractionEqual(this.LastPosition));
		if (Math.Abs(angleByVector2D) < 75.0 || Math.Abs(angleByVector2D) > 105.0)
		{
			this.CloseTipsWhenBeginDrag();
			return false;
		}
		Vector currentPosition2 = this.CurrentPosition;
		pointerPosition = eventData.pointerPosition;
		fvectorDouble = pointerPosition;
		currentPosition2.DeepCopy(fvectorDouble);
		double num2 = Vector.Distance(this.CurrentPosition, this.LastPosition) * 1000.0 / (double)((float)num);
		if ((double)this.ScreenHeight / num2 > (double)this.DragSpeedThreshold)
		{
			this.CloseTipsWhenBeginDrag();
			return false;
		}
		this.CanDrag = false;
		return true;
	}

	// Token: 0x0600ED6E RID: 60782 RVA: 0x0040BCC7 File Offset: 0x00409EC7
	private void RefreshBackpackLogicStateByDrag()
	{
		if (this.GetData().GetItemType() == EHonamiStoryItemType.Plugin)
		{
			ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.DraggingPlugins);
			return;
		}
		ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Dragging);
	}

	// Token: 0x0600ED6F RID: 60783 RVA: 0x0040BCF0 File Offset: 0x00409EF0
	public bool OnDrag(ULGUIPointerEventData eventData)
	{
		if (!this.IsCanDragState(false))
		{
			return true;
		}
		Vector currentPosition = this.CurrentPosition;
		FVector pointerPosition = eventData.pointerPosition;
		FVectorDouble fvectorDouble = pointerPosition;
		currentPosition.DeepCopy(fvectorDouble);
		double num = this.CurrentPosition.X - this.LastPosition.X;
		this.MoveDistanceX += num;
		double num2 = this.CurrentPosition.Y - this.LastPosition.Y;
		this.MoveDistanceY += num2;
		this.LastPosition.DeepCopy(this.CurrentPosition);
		if (!this.IsDragging && Math.Abs(this.MoveDistanceX) + Math.Abs(this.MoveDistanceY) > (double)this.DragDistanceThreshold)
		{
			if (!this.IsGamepadDragging)
			{
				this.RefreshBackpackLogicStateByDrag();
				this.Panel.OnDragBegin(eventData, this);
			}
			this.IsDragging = true;
			return false;
		}
		if (this.IsDragging)
		{
			this.Panel.OnDrag(eventData, this);
			return false;
		}
		return true;
	}

	// Token: 0x0600ED70 RID: 60784 RVA: 0x0040BDE8 File Offset: 0x00409FE8
	public bool OnDragEnd(ULGUIPointerEventData eventData)
	{
		this.TrySellStateDragLogic(false, null);
		this.IsStartDrag = false;
		if (!this.IsCanDragState(false))
		{
			return true;
		}
		this.Panel.OnDragEnd(eventData, this);
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_honamistory_backpack_equip");
		ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
		this.IsDragging = false;
		this.IsGamepadDragging = false;
		this.IsUseCancel = false;
		return false;
	}

	// Token: 0x0600ED71 RID: 60785 RVA: 0x0040BE50 File Offset: 0x0040A050
	protected void OnClickedItem()
	{
		if (this.IsDragging || this.OnClickedGridCb == null)
		{
			return;
		}
		FVector uiworldPosition = this.RootItem.GetUIWorldPosition();
		Vector2D arg = new Vector2D((double)uiworldPosition.X, (double)uiworldPosition.Z);
		Vector2D arg2 = new Vector2D((double)this.RootItem.Width, (double)this.RootItem.Height);
		this.OnClickedGridCb(this.ItemGridItem, arg, arg2);
	}

	// Token: 0x0600ED72 RID: 60786 RVA: 0x0040BEBF File Offset: 0x0040A0BF
	public UUIItem GetBtnItem()
	{
		UUIButtonComponent button = base.GetButton(2);
		if (button == null)
		{
			return null;
		}
		return button.GetRootComponent();
	}

	// Token: 0x040071F1 RID: 29169
	public Action<HonamiStoryItemGridItem> OnEnterGridCb;

	// Token: 0x040071F2 RID: 29170
	public Action OnExitGridCb;

	// Token: 0x040071F3 RID: 29171
	public Action OnDownGridCb;

	// Token: 0x040071F4 RID: 29172
	[Nullable(new byte[]
	{
		2,
		2,
		1,
		1
	})]
	public Action<HonamiStoryItemGridItem, Vector2D, Vector2D> OnClickedGridCb;

	// Token: 0x040071F5 RID: 29173
	[Nullable(1)]
	protected HonamiStoryBackpackPanelBase Panel;

	// Token: 0x040071F6 RID: 29174
	public HonamiStoryItemDataBase Data;

	// Token: 0x040071F7 RID: 29175
	private UiPanelBase OverflowItem;

	// Token: 0x040071F8 RID: 29176
	private bool CanDrag;

	// Token: 0x040071F9 RID: 29177
	private double LastPointerDownTime;

	// Token: 0x040071FA RID: 29178
	private TimerHandle LastPointerTimer;

	// Token: 0x040071FB RID: 29179
	[Nullable(1)]
	private readonly Vector LastPosition = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x040071FC RID: 29180
	[Nullable(1)]
	private readonly Vector CurrentPosition = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x040071FD RID: 29181
	[Nullable(1)]
	private readonly Vector LastSellPosition = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x040071FE RID: 29182
	[Nullable(1)]
	private readonly Vector CurrentSellPosition = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x040071FF RID: 29183
	private double MoveDistanceX;

	// Token: 0x04007200 RID: 29184
	private double MoveDistanceY;

	// Token: 0x04007201 RID: 29185
	private float DragDistanceThreshold = 40f;

	// Token: 0x04007202 RID: 29186
	private float ScreenHeight;

	// Token: 0x04007203 RID: 29187
	private bool IsStartDrag;

	// Token: 0x04007204 RID: 29188
	private bool IsDragging;

	// Token: 0x04007205 RID: 29189
	private bool IsGamepadDragging;

	// Token: 0x04007206 RID: 29190
	private bool IsUseCancel;

	// Token: 0x04007207 RID: 29191
	private bool IsForDrag;

	// Token: 0x04007208 RID: 29192
	private float DragSpeedThreshold;

	// Token: 0x04007209 RID: 29193
	private int EmptyPosition;

	// Token: 0x0400720A RID: 29194
	protected HonamiStoryItemGridItem ItemGridItem;

	// Token: 0x0400720B RID: 29195
	[Nullable(1)]
	protected UUISprite SpriteBg;

	// Token: 0x0400720C RID: 29196
	protected HonamiStoryItemSweepItem SweepItem;

	// Token: 0x0400720D RID: 29197
	private const int DRAG_MIN_ANGLE = 75;

	// Token: 0x0400720E RID: 29198
	private const int DRAG_MAX_ANGLE = 105;

	// Token: 0x0400720F RID: 29199
	private const int DARG_MOVE_DISTANCE = 40;

	// Token: 0x04007210 RID: 29200
	private const int POINTER_DOWN_DELAY = 500;

	// Token: 0x02008265 RID: 33381
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C392 RID: 181138
		Self,
		// Token: 0x0402C393 RID: 181139
		SpriteBg,
		// Token: 0x0402C394 RID: 181140
		Btn
	}
}
