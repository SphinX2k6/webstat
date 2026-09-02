using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using UnrealEngine;

// Token: 0x02001E50 RID: 7760
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class HandBookCommonTypeItem : GridProxyAbstract<HandBookCommonItemData[]>
{
	// Token: 0x0600E5C3 RID: 58819 RVA: 0x003E1185 File Offset: 0x003DF385
	[NullableContext(2)]
	public void Initialize(UUIItem uiItem = null)
	{
		if (uiItem != null)
		{
			this.CreateThenShowByActor(uiItem.GetOwner());
		}
	}

	// Token: 0x0600E5C4 RID: 58820 RVA: 0x003E1196 File Offset: 0x003DF396
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIGridLayout))
		};
	}

	// Token: 0x0600E5C5 RID: 58821 RVA: 0x003E11D0 File Offset: 0x003DF3D0
	public void InitGridLayout()
	{
		if (this.GridLayout != null)
		{
			this.GridLayout.ClearChildren();
			this.GridLayout = null;
		}
		this.HandBookCommonItemList = new List<HandBookCommonItem>();
		this.GridLayout = new GenericLayoutNew<HandBookCommonItem>(base.GetGridLayout(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<HandBookCommonItem>(this.InitHandBookCommonItem), null);
		this.GridLayout.RebuildLayoutByDataNew<HandBookCommonItemData>(this.HandBookCommonItemDataList, null);
	}

	// Token: 0x0600E5C6 RID: 58822 RVA: 0x003E123B File Offset: 0x003DF43B
	public void InitTitle()
	{
		if (this.HandBookCommonItemDataList.Length == 0)
		{
			return;
		}
		base.GetText(0).SetText(this.HandBookCommonItemDataList[0].Title, true);
	}

	// Token: 0x0600E5C7 RID: 58823 RVA: 0x003E1264 File Offset: 0x003DF464
	private ILayoutItem<HandBookCommonItem> InitHandBookCommonItem(object handBookCommonItemData, UUIItem uiItem, int index)
	{
		HandBookCommonItem handBookCommonItem = new HandBookCommonItem();
		handBookCommonItem.Initialize(uiItem.GetOwner());
		handBookCommonItem.Refresh((HandBookCommonItemData)handBookCommonItemData, false, 0);
		handBookCommonItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnToggleClick));
		this.HandBookCommonItemList.Add(handBookCommonItem);
		return new LayoutItem<HandBookCommonItem>
		{
			Key = index,
			Value = handBookCommonItem
		};
	}

	// Token: 0x0600E5C8 RID: 58824 RVA: 0x003E12C7 File Offset: 0x003DF4C7
	[NullableContext(2)]
	public HandBookCommonItem SetToggleChecked()
	{
		if (this.HandBookCommonItemList.Count > 0)
		{
			HandBookCommonItem handBookCommonItem = this.HandBookCommonItemList[0];
			handBookCommonItem.SetSelected(true, false);
			handBookCommonItem.OnSelected(true);
			return handBookCommonItem;
		}
		return null;
	}

	// Token: 0x0600E5C9 RID: 58825 RVA: 0x003E12F4 File Offset: 0x003DF4F4
	public void ResetAllToggleState()
	{
		int count = this.HandBookCommonItemList.Count;
		for (int i = 0; i < count; i++)
		{
			this.HandBookCommonItemList[i].SetSelected(false, false);
		}
	}

	// Token: 0x0600E5CA RID: 58826 RVA: 0x003E132C File Offset: 0x003DF52C
	protected void OnToggleClick(MediumItemGridExtendCallback callbackParameter)
	{
		HandBookCommonItemData handBookCommonItemData = callbackParameter.Data as HandBookCommonItemData;
		if (this.OnToggleCallback != null)
		{
			ItemGridBase mediumItemGrid = callbackParameter.MediumItemGrid;
			this.OnToggleCallback(handBookCommonItemData, mediumItemGrid);
		}
	}

	// Token: 0x0600E5CB RID: 58827 RVA: 0x003E1361 File Offset: 0x003DF561
	public override void Refresh(HandBookCommonItemData[] dataList, bool isSelected, int gridIndex)
	{
		this.GirdIndex = gridIndex;
		this.HandBookCommonItemDataList = dataList;
		this.InitGridLayout();
		this.InitTitle();
	}

	// Token: 0x0600E5CC RID: 58828 RVA: 0x003E137D File Offset: 0x003DF57D
	public int GetGirdIndex()
	{
		return this.GirdIndex;
	}

	// Token: 0x0600E5CD RID: 58829 RVA: 0x003E1385 File Offset: 0x003DF585
	public List<HandBookCommonItem> GetHandBookCommonItemList()
	{
		return this.HandBookCommonItemList;
	}

	// Token: 0x0600E5CE RID: 58830 RVA: 0x003E138D File Offset: 0x003DF58D
	public void BindToggleCallback(THandBookToggleFunction toggleFunction)
	{
		this.OnToggleCallback = toggleFunction;
	}

	// Token: 0x0600E5CF RID: 58831 RVA: 0x003E1396 File Offset: 0x003DF596
	protected override void OnBeforeDestroy()
	{
		if (this.GridLayout != null)
		{
			this.GridLayout.ClearChildren();
			this.GridLayout = null;
		}
	}

	// Token: 0x04006EAB RID: 28331
	protected HandBookCommonItemData[] HandBookCommonItemDataList;

	// Token: 0x04006EAC RID: 28332
	protected List<HandBookCommonItem> HandBookCommonItemList;

	// Token: 0x04006EAD RID: 28333
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<HandBookCommonItem> GridLayout;

	// Token: 0x04006EAE RID: 28334
	[Nullable(2)]
	private THandBookToggleFunction OnToggleCallback;

	// Token: 0x04006EAF RID: 28335
	private int GirdIndex;
}
