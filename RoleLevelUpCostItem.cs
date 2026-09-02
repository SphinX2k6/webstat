using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200288A RID: 10378
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RoleLevelUpCostItem : GridProxyAbstract<ISelectedData>
{
	// Token: 0x060148BC RID: 84156 RVA: 0x005B27EF File Offset: 0x005B09EF
	private int GetConfigId()
	{
		return this.ItemGridVariantSelect.GetConfigId();
	}

	// Token: 0x060148BD RID: 84157 RVA: 0x005B27FC File Offset: 0x005B09FC
	[NullableContext(1)]
	public override void Refresh(ISelectedData data, bool isSelected, int gridIndex)
	{
		this.RefreshBySelectedData(data);
	}

	// Token: 0x060148BE RID: 84158 RVA: 0x005B2805 File Offset: 0x005B0A05
	public RoleLevelUpCostItem(UUIItem uiItem = null, Action<int> onItemClickCallBack = null, Action<int> onItemReduceCallBack = null, Func<int, bool> canItemLongPress = null, Func<int, bool> canItemReduceLongPress = null, EUiViewName? belongView = null)
	{
		this.OnItemClickCallBack = onItemClickCallBack;
		this.OnItemReduceCallBack = onItemReduceCallBack;
		this.CanItemLongPress = canItemLongPress;
		this.CanItemReduceLongPress = canItemReduceLongPress;
		this.BelongView = belongView;
		if (uiItem != null)
		{
			this.CreateThenShowByActor(uiItem.GetOwner());
		}
	}

	// Token: 0x060148BF RID: 84159 RVA: 0x005B2844 File Offset: 0x005B0A44
	protected override void OnStart()
	{
		this.ItemGridVariantSelect = new ItemGridVariantSelect(this.RootItem.GetOwner(), null, this.BelongView);
		Action<bool> pointClickAction = delegate(bool _)
		{
			Action<int> onItemClickCallBack = this.OnItemClickCallBack;
			if (onItemClickCallBack == null)
			{
				return;
			}
			onItemClickCallBack(this.GetConfigId());
		};
		Func<bool> tickConditionDelegate = delegate()
		{
			Func<int, bool> canItemLongPress = this.CanItemLongPress;
			return canItemLongPress != null && canItemLongPress(this.GetConfigId());
		};
		this.ItemLongPressButton = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(this.ItemGridVariantSelect.GetClickToggle()), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), pointClickAction);
		this.ItemLongPressButton.SetTickConditionDelegate(tickConditionDelegate);
		Action<bool> pointClickAction2 = delegate(bool _)
		{
			Action<int> onItemReduceCallBack = this.OnItemReduceCallBack;
			if (onItemReduceCallBack == null)
			{
				return;
			}
			onItemReduceCallBack(this.GetConfigId());
		};
		Func<bool> tickConditionDelegate2 = delegate()
		{
			Func<int, bool> canItemReduceLongPress = this.CanItemReduceLongPress;
			return canItemReduceLongPress != null && canItemReduceLongPress(this.GetConfigId());
		};
		this.ReduceLongPressButton = new LongPressButtonItem(new OneOf<UUIButtonComponent, UUIExtendToggle>?(this.ItemGridVariantSelect.GetReduceButton()), new LongPressButtonItem.ELongPressConfigId?(LongPressButtonItem.ELongPressConfigId.LongPressOne), pointClickAction2);
		this.ReduceLongPressButton.SetTickConditionDelegate(tickConditionDelegate2);
		Action<int, ItemConfig> toggleClickEvent = delegate(int itemId, ItemConfig itemConfigId)
		{
			UUIExtendToggle clickToggle = this.ItemGridVariantSelect.GetClickToggle();
			if (clickToggle == null)
			{
				return;
			}
			clickToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		};
		this.ItemGridVariantSelect.SetToggleClickEvent(toggleClickEvent);
		this.ItemGridVariantSelect.GetAddButton().RootUIComp.Get().SetUIActive(false);
		this.ItemGridVariantSelect.RefreshItemShowState(true);
	}

	// Token: 0x060148C0 RID: 84160 RVA: 0x005B294E File Offset: 0x005B0B4E
	[NullableContext(1)]
	public void RefreshBySelectedData(ISelectedData data)
	{
		this.ItemGridVariantSelect.RefreshByItemId(data.ItemId);
		this.RefreshCountBySelectedData(data);
	}

	// Token: 0x060148C1 RID: 84161 RVA: 0x005B2968 File Offset: 0x005B0B68
	[NullableContext(1)]
	public void RefreshCountBySelectedData(ISelectedData data)
	{
		int selectedCount = data.SelectedCount;
		int count = data.Count;
		ItemGridVariantSelect itemGridVariantSelect = this.ItemGridVariantSelect;
		bool showState = true;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(selectedCount);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(count);
		itemGridVariantSelect.RefreshTextDown(showState, defaultInterpolatedStringHandler.ToStringAndClear());
		this.ItemGridVariantSelect.GetReduceButton().RootUIComp.Get().SetUIActive(selectedCount > 0);
	}

	// Token: 0x060148C2 RID: 84162 RVA: 0x005B29DC File Offset: 0x005B0BDC
	protected override void OnBeforeDestroy()
	{
		this.ItemLongPressButton.Clear();
		this.ReduceLongPressButton.Clear();
	}

	// Token: 0x060148C3 RID: 84163 RVA: 0x005B29F4 File Offset: 0x005B0BF4
	[NullableContext(1)]
	public UUIItem GetUiItemForGuide()
	{
		ItemGridVariantSelect itemGridVariantSelect = this.ItemGridVariantSelect;
		object obj;
		if (itemGridVariantSelect == null)
		{
			obj = null;
		}
		else
		{
			UUIExtendToggle clickToggle = itemGridVariantSelect.GetClickToggle();
			obj = ((clickToggle != null) ? clickToggle.GetOwner().GetComponentByClass(UUIItem.StaticClass()) : null);
		}
		return obj as UUIItem;
	}

	// Token: 0x04009EED RID: 40685
	private ItemGridVariantSelect ItemGridVariantSelect;

	// Token: 0x04009EEE RID: 40686
	private LongPressButtonItem ItemLongPressButton;

	// Token: 0x04009EEF RID: 40687
	private LongPressButtonItem ReduceLongPressButton;

	// Token: 0x04009EF0 RID: 40688
	private readonly Action<int> OnItemClickCallBack;

	// Token: 0x04009EF1 RID: 40689
	private readonly Action<int> OnItemReduceCallBack;

	// Token: 0x04009EF2 RID: 40690
	private readonly Func<int, bool> CanItemLongPress;

	// Token: 0x04009EF3 RID: 40691
	private readonly Func<int, bool> CanItemReduceLongPress;

	// Token: 0x04009EF4 RID: 40692
	public EUiViewName? BelongView;
}
