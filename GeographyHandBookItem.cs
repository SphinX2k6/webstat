using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using UnrealEngine;

// Token: 0x02001E45 RID: 7749
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GeographyHandBookItem : GridProxyAbstract<IGeographyHandBookItemData>
{
	// Token: 0x0600E563 RID: 58723 RVA: 0x003DF700 File Offset: 0x003DD900
	public GeographyHandBookItem()
	{
		this.GeographyHandBookList = new List<GeographyHandBook>();
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		this.GeographyHandBookChildItemList = new List<GeographyHandBookChildItem>();
	}

	// Token: 0x0600E564 RID: 58724 RVA: 0x003DF729 File Offset: 0x003DD929
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIGridLayout))
		};
	}

	// Token: 0x0600E565 RID: 58725 RVA: 0x003DF762 File Offset: 0x003DD962
	protected override void OnStart()
	{
		this.ContentGenericLayout = new GenericLayoutNew<GeographyHandBookChildItem>(base.GetGridLayout(1), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<GeographyHandBookChildItem>(this.InitChildItem), null);
	}

	// Token: 0x0600E566 RID: 58726 RVA: 0x003DF784 File Offset: 0x003DD984
	public override void Refresh(IGeographyHandBookItemData data, bool isSelected, int gridIndex)
	{
		this.GeographyHandBookList = data.HandBookList;
		this.GeographyHandBookList.Sort((GeographyHandBook a, GeographyHandBook b) => a.Id - b.Id);
		base.GetText(0).ShowTextNew(data.Type.TypeDescription);
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		int count = this.GeographyHandBookList.Count;
		for (int i = 0; i < count; i++)
		{
			GeographyHandBook geographyHandBook = this.GeographyHandBookList[i];
			HandBookCommonItemData handBookCommonItemData = new HandBookCommonItemData();
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo(EHandBookTabType.Geography, geographyHandBook.Id);
			bool isLock = handBookInfo == null;
			bool isNew = handBookInfo != null && !handBookInfo.IsRead;
			handBookCommonItemData.Config = geographyHandBook;
			handBookCommonItemData.IsLock = isLock;
			handBookCommonItemData.IsNew = isNew;
			this.HandBookCommonItemDataList.Add(handBookCommonItemData);
		}
		this.GeographyHandBookChildItemList = new List<GeographyHandBookChildItem>();
		this.ContentGenericLayout.RebuildLayoutByDataNew<HandBookCommonItemData>(this.HandBookCommonItemDataList, null);
	}

	// Token: 0x0600E567 RID: 58727 RVA: 0x003DF898 File Offset: 0x003DDA98
	private ILayoutItem<GeographyHandBookChildItem> InitChildItem(object data, UUIItem uiItem, int index)
	{
		GeographyHandBookChildItem geographyHandBookChildItem = new GeographyHandBookChildItem(uiItem);
		geographyHandBookChildItem.Refresh((HandBookCommonItemData)data, false, index);
		this.GeographyHandBookChildItemList.Add(geographyHandBookChildItem);
		return new LayoutItem<GeographyHandBookChildItem>
		{
			Key = index,
			Value = geographyHandBookChildItem
		};
	}

	// Token: 0x0600E568 RID: 58728 RVA: 0x003DF8DE File Offset: 0x003DDADE
	public List<GeographyHandBookChildItem> GetChildItemList()
	{
		return this.GeographyHandBookChildItemList;
	}

	// Token: 0x0600E569 RID: 58729 RVA: 0x003DF8E6 File Offset: 0x003DDAE6
	protected override void OnBeforeDestroy()
	{
		if (this.ContentGenericLayout != null)
		{
			this.ContentGenericLayout.ClearChildren();
			this.ContentGenericLayout = null;
		}
		this.GeographyHandBookList = new List<GeographyHandBook>();
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		this.GeographyHandBookChildItemList = new List<GeographyHandBookChildItem>();
	}

	// Token: 0x04006E65 RID: 28261
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<GeographyHandBookChildItem> ContentGenericLayout;

	// Token: 0x04006E66 RID: 28262
	private List<GeographyHandBook> GeographyHandBookList;

	// Token: 0x04006E67 RID: 28263
	private List<HandBookCommonItemData> HandBookCommonItemDataList;

	// Token: 0x04006E68 RID: 28264
	private List<GeographyHandBookChildItem> GeographyHandBookChildItemList;
}
