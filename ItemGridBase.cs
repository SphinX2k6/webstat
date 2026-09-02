using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001961 RID: 6497
[NullableContext(1)]
[Nullable(0)]
public class ItemGridBase : UiPanelBase
{
	// Token: 0x0600BA5E RID: 47710 RVA: 0x0031A058 File Offset: 0x00318258
	[NullableContext(2)]
	public void Initialize(AActor rootActor = null)
	{
		if (rootActor != null)
		{
			base.CreateThenShowByActor(rootActor, null);
		}
	}

	// Token: 0x0600BA5F RID: 47711 RVA: 0x0031A068 File Offset: 0x00318268
	protected override void OnStartImplement()
	{
		this.TopAdditionItem = this.OnSetTopAdditionItem();
		this.BottomAdditionItem = this.OnSetBottomAdditionItem();
		this.UnderTextAdditionItem = this.OnSetUnderTextAdditionItem();
		this.LongPressButton.Initialize(this.GetItemGridExtendToggle(), new Action<bool>(this.OnLongPressActivate), new Action(this.ExtendTogglePress), new Action(this.ExtendToggleRelease), null);
		this.LongPressButton.SetTickConditionDelegate(new Func<bool>(this.CanItemLongPressClick));
		this.AddEvents();
	}

	// Token: 0x0600BA60 RID: 47712 RVA: 0x0031A0F4 File Offset: 0x003182F4
	protected override void OnBeforeDestroyImplement()
	{
		this.TopAdditionItem = null;
		this.BottomAdditionItem = null;
		this.UnderTextAdditionItem = null;
		this.UnderTextComponentList.Clear();
		this.BottomComponentList.Clear();
		this.TopComponentList.Clear();
		LongPressButtonItem longPressButton = this.LongPressButton;
		if (longPressButton != null)
		{
			longPressButton.Clear();
		}
		this.LongPressButton = null;
		this.IsAnyComponentLoading = false;
		this.UnBindOnExtendTogglePress();
		this.UnBindOnExtendToggleRelease();
		this.UnBindOnExtendToggleStateChanged();
		this.UnBindOnExtendToggleClicked();
		this.UnBindOnCanExecuteChange();
		this.UnBindLongPress();
		this.UnBindComponentEvents();
		this.ClearVisibleComponent();
		this.ClearItemGridComponents();
		this.RemoveEvents();
	}

	// Token: 0x0600BA61 RID: 47713 RVA: 0x0031A194 File Offset: 0x00318394
	[NullableContext(2)]
	protected virtual UUIItem OnSetUnderTextAdditionItem()
	{
		Singleton<Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.WDX, "没有实现OnSetUnderTextAdditionItem", default(ReadOnlySpan<ValueTuple<string, object>>));
		return null;
	}

	// Token: 0x0600BA62 RID: 47714 RVA: 0x0031A1C0 File Offset: 0x003183C0
	[NullableContext(2)]
	protected virtual UUIItem OnSetBottomAdditionItem()
	{
		Singleton<Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.YYZ, "没有实现OnSetBottomAdditionItem", default(ReadOnlySpan<ValueTuple<string, object>>));
		return null;
	}

	// Token: 0x0600BA63 RID: 47715 RVA: 0x0031A1EC File Offset: 0x003183EC
	[NullableContext(2)]
	protected virtual UUIItem OnSetTopAdditionItem()
	{
		Singleton<Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.YYZ, "没有实现OnSetBottomAdditionItem", default(ReadOnlySpan<ValueTuple<string, object>>));
		return null;
	}

	// Token: 0x0600BA64 RID: 47716 RVA: 0x0031A218 File Offset: 0x00318418
	[NullableContext(2)]
	public virtual UUIExtendToggle GetItemGridExtendToggle()
	{
		Singleton<Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.YYZ, "没有实现GetItemGridExtendToggle", default(ReadOnlySpan<ValueTuple<string, object>>));
		return null;
	}

	// Token: 0x0600BA65 RID: 47717 RVA: 0x0031A244 File Offset: 0x00318444
	protected void AddEvents()
	{
		UUIExtendToggle itemGridExtendToggle = this.GetItemGridExtendToggle();
		if (itemGridExtendToggle == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.LRX, base.GetType().Name + "::GetItemGridExtendToggle return empty UUIExtendToggle!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		itemGridExtendToggle.OnStateChange.Add(new Action<EToggleState>(this.ExtendToggleStateChanged));
		itemGridExtendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
		itemGridExtendToggle.OnHover.Add(new Action(this.ExtendToggleHover));
		itemGridExtendToggle.OnUnHover.Add(new Action(this.ExtendToggleUnHover));
		this.OnAddEvents();
	}

	// Token: 0x0600BA66 RID: 47718 RVA: 0x0031A2EC File Offset: 0x003184EC
	protected void RemoveEvents()
	{
		UUIExtendToggle itemGridExtendToggle = this.GetItemGridExtendToggle();
		if (itemGridExtendToggle == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Inventory, ELogAuthor.LRX, base.GetType().Name + "::GetItemGridExtendToggle return empty UUIExtendToggle!", default(ReadOnlySpan<ValueTuple<string, object>>));
			return;
		}
		itemGridExtendToggle.OnStateChange.Remove(new Action<EToggleState>(this.ExtendToggleStateChanged));
		itemGridExtendToggle.CanExecuteChange.Unbind();
		itemGridExtendToggle.OnHover.Remove(new Action(this.ExtendToggleHover));
		itemGridExtendToggle.OnUnHover.Remove(new Action(this.ExtendToggleUnHover));
		this.OnRemoveEvents();
	}

	// Token: 0x0600BA67 RID: 47719 RVA: 0x0031A386 File Offset: 0x00318586
	protected virtual void UnBindComponentEvents()
	{
	}

	// Token: 0x0600BA68 RID: 47720 RVA: 0x0031A388 File Offset: 0x00318588
	protected virtual void OnAddEvents()
	{
	}

	// Token: 0x0600BA69 RID: 47721 RVA: 0x0031A38A File Offset: 0x0031858A
	protected virtual void OnRemoveEvents()
	{
	}

	// Token: 0x0600BA6A RID: 47722 RVA: 0x0031A38C File Offset: 0x0031858C
	private void ExtendTogglePress()
	{
		this.OnExtendTogglePress();
		if (this.OnExtendTogglePressCallback != null)
		{
			MediumItemGridExtendCallback obj = new MediumItemGridExtendCallback
			{
				MediumItemGrid = this,
				State = this.GetItemGridExtendToggle().GetToggleState(),
				Data = this.Data
			};
			this.OnExtendTogglePressCallback(obj);
		}
	}

	// Token: 0x0600BA6B RID: 47723 RVA: 0x0031A3DD File Offset: 0x003185DD
	protected virtual void OnExtendTogglePress()
	{
	}

	// Token: 0x0600BA6C RID: 47724 RVA: 0x0031A3E0 File Offset: 0x003185E0
	private void ExtendToggleRelease()
	{
		this.OnExtendToggleRelease();
		if (this.OnExtendToggleReleaseCallback != null)
		{
			MediumItemGridExtendCallback obj = new MediumItemGridExtendCallback
			{
				MediumItemGrid = this,
				State = this.GetItemGridExtendToggle().GetToggleState(),
				Data = this.Data
			};
			this.OnExtendToggleReleaseCallback(obj);
		}
		this.OnExtendToggleClicked();
		if (this.OnExtendToggleClickedCallback != null)
		{
			MediumItemGridExtendCallback obj2 = new MediumItemGridExtendCallback
			{
				MediumItemGrid = this,
				State = this.GetItemGridExtendToggle().GetToggleState(),
				Data = this.Data
			};
			this.OnExtendToggleClickedCallback(obj2);
		}
	}

	// Token: 0x0600BA6D RID: 47725 RVA: 0x0031A475 File Offset: 0x00318675
	protected virtual void OnExtendToggleRelease()
	{
	}

	// Token: 0x0600BA6E RID: 47726 RVA: 0x0031A477 File Offset: 0x00318677
	protected virtual void OnExtendToggleClicked()
	{
	}

	// Token: 0x0600BA6F RID: 47727 RVA: 0x0031A47C File Offset: 0x0031867C
	private void ExtendToggleStateChanged(EToggleState state)
	{
		this.OnExtendToggleStateChanged(state);
		if (this.OnExtendToggleStateChangedCallback != null)
		{
			MediumItemGridExtendCallback obj = new MediumItemGridExtendCallback
			{
				MediumItemGrid = this,
				State = state,
				Data = this.Data
			};
			this.OnExtendToggleStateChangedCallback(obj);
		}
	}

	// Token: 0x0600BA70 RID: 47728 RVA: 0x0031A4C4 File Offset: 0x003186C4
	protected virtual void OnExtendToggleStateChanged(EToggleState state)
	{
	}

	// Token: 0x0600BA71 RID: 47729 RVA: 0x0031A4C6 File Offset: 0x003186C6
	private bool CanExecuteChange()
	{
		if (this.OnCanExecuteChangeCallback != null)
		{
			return this.OnCanExecuteChangeCallback(this.Data, this.IsForceSelected, this.GetItemGridExtendToggle().GetToggleState());
		}
		return this.OnCanExecuteChange();
	}

	// Token: 0x0600BA72 RID: 47730 RVA: 0x0031A4F9 File Offset: 0x003186F9
	protected virtual bool OnCanExecuteChange()
	{
		return true;
	}

	// Token: 0x0600BA73 RID: 47731 RVA: 0x0031A4FC File Offset: 0x003186FC
	private void ExtendToggleHover()
	{
		this.IsHover = true;
	}

	// Token: 0x0600BA74 RID: 47732 RVA: 0x0031A505 File Offset: 0x00318705
	private void ExtendToggleUnHover()
	{
		this.IsHover = false;
	}

	// Token: 0x0600BA75 RID: 47733 RVA: 0x0031A510 File Offset: 0x00318710
	public virtual void SetSelected(bool bSelected, bool bForce = false)
	{
		UUIExtendToggle itemGridExtendToggle = this.GetItemGridExtendToggle();
		if (bSelected)
		{
			if (bForce)
			{
				itemGridExtendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
			}
			else
			{
				itemGridExtendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
		}
		else if (bForce)
		{
			itemGridExtendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		else
		{
			itemGridExtendToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.IsSelected = bSelected;
		this.IsForceSelected = bForce;
	}

	// Token: 0x0600BA76 RID: 47734 RVA: 0x0031A56C File Offset: 0x0031876C
	public void SetExtendToggleEnable(bool bEnable, bool bForce = false)
	{
		if (this.IsExtendToggleEnable == bEnable && !bForce)
		{
			return;
		}
		this.IsExtendToggleEnable = bEnable;
		UUIExtendToggle itemGridExtendToggle = this.GetItemGridExtendToggle();
		if (bEnable)
		{
			this.SetSelected(this.IsSelected, bForce);
			return;
		}
		itemGridExtendToggle.SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
	}

	// Token: 0x0600BA77 RID: 47735 RVA: 0x0031A5B0 File Offset: 0x003187B0
	public void BindOnExtendTogglePress(Action<MediumItemGridExtendCallback> onItemButtonPress)
	{
		this.OnExtendTogglePressCallback = onItemButtonPress;
	}

	// Token: 0x0600BA78 RID: 47736 RVA: 0x0031A5B9 File Offset: 0x003187B9
	public void UnBindOnExtendTogglePress()
	{
		this.OnExtendTogglePressCallback = null;
	}

	// Token: 0x0600BA79 RID: 47737 RVA: 0x0031A5C2 File Offset: 0x003187C2
	public void BindOnExtendToggleRelease(Action<MediumItemGridExtendCallback> onItemButtonRelease)
	{
		this.OnExtendToggleReleaseCallback = onItemButtonRelease;
	}

	// Token: 0x0600BA7A RID: 47738 RVA: 0x0031A5CB File Offset: 0x003187CB
	public void UnBindOnExtendToggleRelease()
	{
		this.OnExtendToggleReleaseCallback = null;
	}

	// Token: 0x0600BA7B RID: 47739 RVA: 0x0031A5D4 File Offset: 0x003187D4
	public void BindOnExtendToggleStateChanged(Action<MediumItemGridExtendCallback> onItemButtonClicked)
	{
		this.OnExtendToggleStateChangedCallback = onItemButtonClicked;
	}

	// Token: 0x0600BA7C RID: 47740 RVA: 0x0031A5DD File Offset: 0x003187DD
	public void UnBindOnExtendToggleStateChanged()
	{
		this.OnExtendToggleStateChangedCallback = null;
	}

	// Token: 0x0600BA7D RID: 47741 RVA: 0x0031A5E6 File Offset: 0x003187E6
	public void BindOnExtendToggleClicked(Action<MediumItemGridExtendCallback> onExtendToggleClickedCallback)
	{
		this.OnExtendToggleClickedCallback = onExtendToggleClickedCallback;
	}

	// Token: 0x0600BA7E RID: 47742 RVA: 0x0031A5EF File Offset: 0x003187EF
	public void UnBindOnExtendToggleClicked()
	{
		this.OnExtendToggleClickedCallback = null;
	}

	// Token: 0x0600BA7F RID: 47743 RVA: 0x0031A5F8 File Offset: 0x003187F8
	public void BindOnCanExecuteChange([Nullable(new byte[]
	{
		1,
		2
	})] Func<object, bool, EToggleState, bool> onCanExecuteChange)
	{
		this.OnCanExecuteChangeCallback = onCanExecuteChange;
	}

	// Token: 0x0600BA80 RID: 47744 RVA: 0x0031A601 File Offset: 0x00318801
	public void UnBindOnCanExecuteChange()
	{
		this.OnCanExecuteChangeCallback = null;
	}

	// Token: 0x0600BA81 RID: 47745 RVA: 0x0031A60A File Offset: 0x0031880A
	public void BindLongPress(LongPressButtonItem.ELongPressConfigId longPressConfigId, [Nullable(new byte[]
	{
		1,
		1,
		2
	})] Action<bool, ItemGridBase, object> callback, [Nullable(new byte[]
	{
		2,
		1,
		2
	})] Func<ItemGridBase, object, bool> canLongPressCallBack = null)
	{
		this.LongPressButton.Deactivate();
		this.LongPressButton.Activate(longPressConfigId);
		this.OnLongPressActiveCallback = callback;
		this.CanItemLongPressCallback = canLongPressCallBack;
	}

	// Token: 0x0600BA82 RID: 47746 RVA: 0x0031A631 File Offset: 0x00318831
	public void UnBindLongPress()
	{
		this.OnLongPressActiveCallback = null;
		this.CanItemLongPressCallback = null;
	}

	// Token: 0x0600BA83 RID: 47747 RVA: 0x0031A641 File Offset: 0x00318841
	protected void OnLongPressActivate(bool isShortPress)
	{
		if (this.OnLongPressActiveCallback != null)
		{
			this.OnLongPressActiveCallback(isShortPress, this, this.Data);
		}
	}

	// Token: 0x0600BA84 RID: 47748 RVA: 0x0031A65E File Offset: 0x0031885E
	protected bool CanItemLongPressClick()
	{
		return this.CanItemLongPressCallback == null || this.CanItemLongPressCallback(this, this.Data);
	}

	// Token: 0x0600BA85 RID: 47749 RVA: 0x0031A67C File Offset: 0x0031887C
	[NullableContext(2)]
	protected ItemGridComponent RefreshComponent([Nullable(1)] Type gridClass, bool? bNewIfNull, object @params = null)
	{
		ItemGridComponent itemGridComponent = this.GetItemGridComponent(gridClass);
		if (@params == null)
		{
			if (itemGridComponent != null)
			{
				itemGridComponent.SetActive(false);
			}
			if (itemGridComponent != null)
			{
				this.VisibleComponents.Remove(itemGridComponent);
			}
			return itemGridComponent;
		}
		if (itemGridComponent == null && bNewIfNull.GetValueOrDefault())
		{
			itemGridComponent = this.AddItemGridComponent(gridClass);
		}
		if (itemGridComponent != null)
		{
			itemGridComponent.Refresh(@params);
			this.AddToComponentList(itemGridComponent);
			if (!this.UseFixedAsync && !itemGridComponent.IsCreating)
			{
				this.HandleVisibleComponents(itemGridComponent);
			}
		}
		return itemGridComponent;
	}

	// Token: 0x0600BA86 RID: 47750 RVA: 0x0031A6ED File Offset: 0x003188ED
	private void HandleVisibleComponents(ItemGridComponent component)
	{
		if (component.IsShowOrShowing)
		{
			this.VisibleComponents.Add(component);
			return;
		}
		this.VisibleComponents.Remove(component);
	}

	// Token: 0x0600BA87 RID: 47751 RVA: 0x0031A712 File Offset: 0x00318912
	protected void SetComponentVisible(ItemGridComponent component, bool bVisible)
	{
		if (component == null)
		{
			return;
		}
		if (bVisible)
		{
			this.VisibleComponents.Add(component);
		}
		else
		{
			this.VisibleComponents.Remove(component);
		}
		component.SetActive(bVisible);
	}

	// Token: 0x0600BA88 RID: 47752 RVA: 0x0031A740 File Offset: 0x00318940
	private ItemGridComponent AddItemGridComponent(Type gridClass)
	{
		ItemGridComponent itemGridComponent;
		if (this.ComponentMap.TryGetValue(gridClass, out itemGridComponent))
		{
			return itemGridComponent;
		}
		itemGridComponent = (ItemGridComponent)Activator.CreateInstance(gridClass);
		switch (itemGridComponent.GetLayoutLevel())
		{
		case EItemGridComponentLayoutLevel.Top:
			itemGridComponent.Initialize(this.TopAdditionItem, this.UseFixedAsync);
			break;
		case EItemGridComponentLayoutLevel.Bottom:
			itemGridComponent.Initialize(this.BottomAdditionItem, this.UseFixedAsync);
			break;
		case EItemGridComponentLayoutLevel.UnderText:
			itemGridComponent.Initialize(this.UnderTextAdditionItem, this.UseFixedAsync);
			break;
		}
		if (this.UseFixedAsync)
		{
			itemGridComponent.OnComponentVisibleChanged = new Action<ItemGridComponent, bool>(this.OnComponentVisibleChanged);
		}
		this.ComponentMap[gridClass] = itemGridComponent;
		this.LoadingComponentSet.Add(itemGridComponent);
		this.IsAnyComponentLoading = true;
		itemGridComponent.Load().ContinueWith(new Action<ItemGridComponent>(this.OnLoadComponentCompleted)).Forget();
		return itemGridComponent;
	}

	// Token: 0x0600BA89 RID: 47753 RVA: 0x0031A818 File Offset: 0x00318A18
	private void OnComponentVisibleChanged(ItemGridComponent component, bool bVisible)
	{
		if (bVisible)
		{
			this.VisibleComponents.Add(component);
			return;
		}
		this.VisibleComponents.Remove(component);
	}

	// Token: 0x0600BA8A RID: 47754 RVA: 0x0031A838 File Offset: 0x00318A38
	[NullableContext(2)]
	private void OnLoadComponentCompleted(ItemGridComponent component)
	{
		if (!this.UseFixedAsync)
		{
			this.HandleVisibleComponents(component);
		}
		this.LoadingComponentSet.Remove(component);
		if (this.LoadingComponentSet.Count > 0)
		{
			return;
		}
		this.IsAnyComponentLoading = false;
		this.RefreshComponentVisible();
		this.RefreshComponentHierarchyIndex();
		Action allComponentLoadedCallback = this.AllComponentLoadedCallback;
		if (allComponentLoadedCallback == null)
		{
			return;
		}
		allComponentLoadedCallback();
	}

	// Token: 0x0600BA8B RID: 47755 RVA: 0x0031A894 File Offset: 0x00318A94
	protected void RefreshComponentVisible()
	{
		if (this.UseFixedAsync && this.IsAnyComponentLoading)
		{
			return;
		}
		foreach (ItemGridComponent itemGridComponent in this.ComponentMap.Values)
		{
			if (!this.VisibleComponents.Contains(itemGridComponent))
			{
				itemGridComponent.SetActive(false);
			}
		}
	}

	// Token: 0x0600BA8C RID: 47756 RVA: 0x0031A90C File Offset: 0x00318B0C
	protected void ClearVisibleComponent()
	{
		if (this.UseFixedAsync && this.IsAnyComponentLoading)
		{
			foreach (ItemGridComponent itemGridComponent in this.ComponentMap.Values)
			{
				if (itemGridComponent.InAsyncLoading())
				{
					itemGridComponent.Refresh(null);
				}
			}
		}
		this.VisibleComponents.Clear();
	}

	// Token: 0x0600BA8D RID: 47757 RVA: 0x0031A988 File Offset: 0x00318B88
	private void AddToComponentList(ItemGridComponent component)
	{
		switch (component.GetLayoutLevel())
		{
		case EItemGridComponentLayoutLevel.Top:
			this.TopComponentList.Add(component);
			return;
		case EItemGridComponentLayoutLevel.Bottom:
			this.BottomComponentList.Add(component);
			return;
		case EItemGridComponentLayoutLevel.UnderText:
			this.UnderTextComponentList.Add(component);
			return;
		default:
			return;
		}
	}

	// Token: 0x0600BA8E RID: 47758 RVA: 0x0031A9D5 File Offset: 0x00318BD5
	protected void ClearComponentList()
	{
		this.UnderTextComponentList.Clear();
		this.BottomComponentList.Clear();
		this.TopComponentList.Clear();
	}

	// Token: 0x0600BA8F RID: 47759 RVA: 0x0031A9F8 File Offset: 0x00318BF8
	protected void RefreshComponentHierarchyIndex()
	{
		if (this.IsAnyComponentLoading)
		{
			return;
		}
		for (int i = 0; i < this.TopComponentList.Count; i++)
		{
			this.TopComponentList[i].SetHierarchyIndex(i);
		}
		for (int j = 0; j < this.BottomComponentList.Count; j++)
		{
			this.BottomComponentList[j].SetHierarchyIndex(j);
		}
		for (int k = 0; k < this.UnderTextComponentList.Count; k++)
		{
			this.UnderTextComponentList[k].SetHierarchyIndex(k);
		}
	}

	// Token: 0x0600BA90 RID: 47760 RVA: 0x0031AA88 File Offset: 0x00318C88
	[return: Nullable(2)]
	protected T GetItemGridComponent<[Nullable(0)] T>(Type ctor) where T : ItemGridComponent
	{
		ItemGridComponent itemGridComponent;
		if (this.ComponentMap.TryGetValue(ctor, out itemGridComponent))
		{
			return itemGridComponent as T;
		}
		return default(T);
	}

	// Token: 0x0600BA91 RID: 47761 RVA: 0x0031AABC File Offset: 0x00318CBC
	[return: Nullable(2)]
	protected ItemGridComponent GetItemGridComponent(Type ctor)
	{
		ItemGridComponent result;
		this.ComponentMap.TryGetValue(ctor, out result);
		return result;
	}

	// Token: 0x0600BA92 RID: 47762 RVA: 0x0031AADC File Offset: 0x00318CDC
	protected void HiddenAllItemGridComponents()
	{
		foreach (ItemGridComponent itemGridComponent in this.ComponentMap.Values)
		{
			itemGridComponent.SetActive(false);
		}
	}

	// Token: 0x0600BA93 RID: 47763 RVA: 0x0031AB34 File Offset: 0x00318D34
	protected void SetItemGridComponentVisible(Type ctor, bool bVisible)
	{
		ItemGridComponent itemGridComponent;
		if (this.ComponentMap.TryGetValue(ctor, out itemGridComponent))
		{
			itemGridComponent.SetActive(bVisible);
		}
	}

	// Token: 0x0600BA94 RID: 47764 RVA: 0x0031AB58 File Offset: 0x00318D58
	protected void ClearItemGridComponents()
	{
		this.ComponentMap.Clear();
		this.LoadingComponentSet.Clear();
		this.ClearComponentList();
	}

	// Token: 0x0600BA95 RID: 47765 RVA: 0x0031AB76 File Offset: 0x00318D76
	public void SetToggleInteractive(bool state)
	{
		this.GetItemGridExtendToggle().SetSelfInteractive(state);
	}

	// Token: 0x0600BA96 RID: 47766 RVA: 0x0031AB84 File Offset: 0x00318D84
	public void SetUseFixedAsync(bool bUseFixedAsync)
	{
		this.UseFixedAsync = bUseFixedAsync;
	}

	// Token: 0x0400582D RID: 22573
	[Nullable(2)]
	protected object Data;

	// Token: 0x0400582E RID: 22574
	private readonly Dictionary<Type, ItemGridComponent> ComponentMap = new Dictionary<Type, ItemGridComponent>();

	// Token: 0x0400582F RID: 22575
	private readonly HashSet<ItemGridComponent> LoadingComponentSet = new HashSet<ItemGridComponent>();

	// Token: 0x04005830 RID: 22576
	private readonly HashSet<ItemGridComponent> VisibleComponents = new HashSet<ItemGridComponent>();

	// Token: 0x04005831 RID: 22577
	private readonly List<ItemGridComponent> UnderTextComponentList = new List<ItemGridComponent>();

	// Token: 0x04005832 RID: 22578
	private readonly List<ItemGridComponent> BottomComponentList = new List<ItemGridComponent>();

	// Token: 0x04005833 RID: 22579
	private readonly List<ItemGridComponent> TopComponentList = new List<ItemGridComponent>();

	// Token: 0x04005834 RID: 22580
	[Nullable(2)]
	private UUIItem TopAdditionItem;

	// Token: 0x04005835 RID: 22581
	[Nullable(2)]
	private UUIItem BottomAdditionItem;

	// Token: 0x04005836 RID: 22582
	[Nullable(2)]
	private UUIItem UnderTextAdditionItem;

	// Token: 0x04005837 RID: 22583
	protected LongPressButtonItem LongPressButton = new LongPressButtonItem(null, null, null);

	// Token: 0x04005838 RID: 22584
	public bool IsHover;

	// Token: 0x04005839 RID: 22585
	protected bool IsSelected;

	// Token: 0x0400583A RID: 22586
	protected bool IsForceSelected;

	// Token: 0x0400583B RID: 22587
	private bool IsExtendToggleEnable = true;

	// Token: 0x0400583C RID: 22588
	protected bool IsAnyComponentLoading;

	// Token: 0x0400583D RID: 22589
	protected bool UseFixedAsync;

	// Token: 0x0400583E RID: 22590
	[Nullable(2)]
	public Action AllComponentLoadedCallback;

	// Token: 0x0400583F RID: 22591
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<MediumItemGridExtendCallback> OnExtendToggleStateChangedCallback;

	// Token: 0x04005840 RID: 22592
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<MediumItemGridExtendCallback> OnExtendTogglePressCallback;

	// Token: 0x04005841 RID: 22593
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<MediumItemGridExtendCallback> OnExtendToggleReleaseCallback;

	// Token: 0x04005842 RID: 22594
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<MediumItemGridExtendCallback> OnExtendToggleClickedCallback;

	// Token: 0x04005843 RID: 22595
	[Nullable(2)]
	private Func<object, bool, EToggleState, bool> OnCanExecuteChangeCallback;

	// Token: 0x04005844 RID: 22596
	[Nullable(new byte[]
	{
		2,
		1,
		2
	})]
	private Action<bool, ItemGridBase, object> OnLongPressActiveCallback;

	// Token: 0x04005845 RID: 22597
	[Nullable(new byte[]
	{
		2,
		1,
		2
	})]
	private Func<ItemGridBase, object, bool> CanItemLongPressCallback;
}
