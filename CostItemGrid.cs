using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020027AE RID: 10158
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class CostItemGrid : GridProxyAbstract<ISelectedData>
{
	// Token: 0x06014107 RID: 82183 RVA: 0x0059A010 File Offset: 0x00598210
	[NullableContext(2)]
	public CostItemGrid(UUIItem uiItem = null)
	{
		if (uiItem != null)
		{
			this.CreateThenShowByActor(uiItem.GetOwner());
		}
	}

	// Token: 0x06014108 RID: 82184 RVA: 0x0059A027 File Offset: 0x00598227
	public override void Refresh(ISelectedData data, bool isSelected, int gridIndex)
	{
		this.RefreshBySelectedData(data);
	}

	// Token: 0x06014109 RID: 82185 RVA: 0x0059A030 File Offset: 0x00598230
	protected override void OnStart()
	{
		this.ItemGridVariantSelect = new ItemGridVariantSelect(null, null, null);
		this.ItemGridVariantSelect.CreateThenShowByActor(this.RootItem.GetOwner());
		Action<int, CSharpScript.Game.Module.Inventory.ItemConfig> toggleClickEvent = delegate(int _, CSharpScript.Game.Module.Inventory.ItemConfig _)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemGridVariantSelect.GetConfigId(), true, null);
			this.ItemGridVariantSelect.GetClickToggle().SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		};
		this.ItemGridVariantSelect.SetToggleClickEvent(toggleClickEvent);
		this.ItemGridVariantSelect.GetAddButton().RootUIComp.Get().SetUIActive(false);
		this.ItemGridVariantSelect.GetReduceButton().RootUIComp.Get().SetUIActive(false);
		this.ItemGridVariantSelect.RefreshItemShowState(true);
	}

	// Token: 0x0601410A RID: 82186 RVA: 0x0059A0CA File Offset: 0x005982CA
	public void RefreshBySelectedData(ISelectedData data)
	{
		this.ItemGridVariantSelect.RefreshByItemId(data.ItemId);
		this.RefreshCountBySelectedData(data);
	}

	// Token: 0x0601410B RID: 82187 RVA: 0x0059A0E4 File Offset: 0x005982E4
	protected override void OnBeforeDestroy()
	{
		ItemGridVariantSelect itemGridVariantSelect = this.ItemGridVariantSelect;
		if (itemGridVariantSelect == null)
		{
			return;
		}
		itemGridVariantSelect.Destroy(null);
	}

	// Token: 0x0601410C RID: 82188 RVA: 0x0059A0F8 File Offset: 0x005982F8
	public void RefreshCountBySelectedData(ISelectedData data)
	{
		int selectedCount = data.SelectedCount;
		int count = data.Count;
		string text = "Text_ItemEnoughText_Text";
		if (selectedCount < count)
		{
			text = "Text_ItemNotEnoughText_Text";
		}
		this.ItemGridVariantSelect.RefreshTextDownByTextId(true, text, new object[]
		{
			selectedCount,
			count
		});
	}

	// Token: 0x04009C47 RID: 40007
	[Nullable(2)]
	private ItemGridVariantSelect ItemGridVariantSelect;
}
