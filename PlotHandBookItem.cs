using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using UnrealEngine;

// Token: 0x02001EA8 RID: 7848
[NullableContext(1)]
[Nullable(0)]
public class PlotHandBookItem : GridProxyAbstract<PlotType>
{
	// Token: 0x0600E81E RID: 59422 RVA: 0x003EC1A7 File Offset: 0x003EA3A7
	[NullableContext(2)]
	public PlotHandBookItem(UUIItem uiItem = null)
	{
		this.GeographyHandBookList = new List<PhotographHandBook>();
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		if (uiItem != null)
		{
			this.CreateThenShowByActor(uiItem.GetOwner());
		}
	}

	// Token: 0x0600E81F RID: 59423 RVA: 0x003EC1D4 File Offset: 0x003EA3D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIGridLayout))
		};
	}

	// Token: 0x0600E820 RID: 59424 RVA: 0x003EC210 File Offset: 0x003EA410
	public override void Refresh(PlotType data, bool isSelected, int gridIndex)
	{
		PlotType plotType = data;
		int id = plotType.Id;
		IReadOnlyList<PhotographHandBook> plotHandBookConfigByType = ConfigBase<HandBookConfig>.Instance.GetPlotHandBookConfigByType(id);
		this.GeographyHandBookList = ConfigCommon.ToList<PhotographHandBook>(plotHandBookConfigByType);
		base.GetText(0).ShowTextNew(plotType.TypeDescription);
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		int count = this.GeographyHandBookList.Count;
		for (int i = 0; i < count; i++)
		{
			PhotographHandBook photographHandBook = this.GeographyHandBookList[i];
			HandBookCommonItemData handBookCommonItemData = new HandBookCommonItemData();
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Quest, photographHandBook.Id);
			bool isLock = handBookInfo == null;
			bool isNew = handBookInfo != null && !handBookInfo.IsRead;
			handBookCommonItemData.Config = photographHandBook;
			handBookCommonItemData.IsLock = isLock;
			handBookCommonItemData.IsNew = isNew;
			this.HandBookCommonItemDataList.Add(handBookCommonItemData);
		}
		this.ContentGenericLayout = new GenericLayoutNew<PlotHandBookChildItem>(base.GetGridLayout(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<PlotHandBookChildItem>(this.InitChildItem), null);
		this.ContentGenericLayout.RebuildLayoutByDataNew<HandBookCommonItemData>(this.HandBookCommonItemDataList, null);
	}

	// Token: 0x0600E821 RID: 59425 RVA: 0x003EC324 File Offset: 0x003EA524
	private ILayoutItem<PlotHandBookChildItem> InitChildItem(object data, UUIItem uiItem, int index)
	{
		PlotHandBookChildItem plotHandBookChildItem = new PlotHandBookChildItem(uiItem);
		plotHandBookChildItem.Refresh((HandBookCommonItemData)data, false, index);
		return new LayoutItem<PlotHandBookChildItem>
		{
			Key = index,
			Value = plotHandBookChildItem
		};
	}

	// Token: 0x0600E822 RID: 59426 RVA: 0x003EC35E File Offset: 0x003EA55E
	public List<PlotHandBookChildItem> GetChildItemList()
	{
		if (this.ContentGenericLayout == null)
		{
			return new List<PlotHandBookChildItem>();
		}
		return this.ContentGenericLayout.GetLayoutItemList();
	}

	// Token: 0x0600E823 RID: 59427 RVA: 0x003EC379 File Offset: 0x003EA579
	protected override void OnBeforeDestroy()
	{
		this.GeographyHandBookList = new List<PhotographHandBook>();
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
	}

	// Token: 0x04006FE1 RID: 28641
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<PlotHandBookChildItem> ContentGenericLayout;

	// Token: 0x04006FE2 RID: 28642
	private List<PhotographHandBook> GeographyHandBookList;

	// Token: 0x04006FE3 RID: 28643
	private List<HandBookCommonItemData> HandBookCommonItemDataList;

	// Token: 0x020081E9 RID: 33257
	[NullableContext(0)]
	private class EGeographyHandBookItemDefine
	{
		// Token: 0x0402C138 RID: 180536
		public const int TitleText = 0;

		// Token: 0x0402C139 RID: 180537
		public const int GirdLayout = 1;
	}
}
