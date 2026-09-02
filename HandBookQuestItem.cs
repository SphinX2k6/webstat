using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001E78 RID: 7800
[NullableContext(1)]
[Nullable(0)]
public class HandBookQuestItem : GridProxyAbstract<PlotType>
{
	// Token: 0x0600E6AD RID: 59053 RVA: 0x003E468C File Offset: 0x003E288C
	public HandBookQuestItem()
	{
		this.QuestHandBookList = new List<PhotographHandBook>();
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
	}

	// Token: 0x0600E6AE RID: 59054 RVA: 0x003E46AA File Offset: 0x003E28AA
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIGridLayout))
		};
	}

	// Token: 0x0600E6AF RID: 59055 RVA: 0x003E46E3 File Offset: 0x003E28E3
	protected override void OnStart()
	{
		this.ContentGenericLayout = new GenericLayout<HandBookQuestChildItem, HandBookCommonItemData>(base.GetGridLayout(1), new Func<HandBookQuestChildItem>(this.InitChildItem), null, false, true);
	}

	// Token: 0x0600E6B0 RID: 59056 RVA: 0x003E4708 File Offset: 0x003E2908
	public override void Refresh(PlotType data, bool isSelected, int gridIndex)
	{
		PlotType plotType = data;
		int id = plotType.Id;
		List<PhotographHandBook> list = ConfigCommon.ToList<PhotographHandBook>(ConfigBase<HandBookConfig>.Instance.GetPlotHandBookConfigByType(id));
		if (list != null)
		{
			this.QuestHandBookList = list;
			this.QuestHandBookList.Sort((PhotographHandBook a, PhotographHandBook b) => a.Id - b.Id);
		}
		else
		{
			this.QuestHandBookList = new List<PhotographHandBook>();
		}
		base.GetText(0).ShowTextNew(plotType.TypeDescription);
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
		int count = this.QuestHandBookList.Count;
		for (int i = 0; i < count; i++)
		{
			PhotographHandBook photographHandBook = this.QuestHandBookList[i];
			HandBookCommonItemData handBookCommonItemData = new HandBookCommonItemData();
			HandBookEntry handBookInfo = ModelBase<HandBookModel>.Instance.GetHandBookInfo((EHandBookTabType)plotType.Type, photographHandBook.Id);
			bool flag = handBookInfo == null;
			if (!flag)
			{
				bool isNew = handBookInfo != null && !handBookInfo.IsRead;
				handBookCommonItemData.ConfigId = photographHandBook.Id;
				handBookCommonItemData.Config = photographHandBook;
				handBookCommonItemData.IsLock = flag;
				handBookCommonItemData.IsNew = isNew;
				this.HandBookCommonItemDataList.Add(handBookCommonItemData);
			}
		}
		GenericLayout<HandBookQuestChildItem, HandBookCommonItemData> contentGenericLayout = this.ContentGenericLayout;
		if (contentGenericLayout != null)
		{
			contentGenericLayout.SetActive(this.HandBookCommonItemDataList.Count > 0);
		}
		GenericLayout<HandBookQuestChildItem, HandBookCommonItemData> contentGenericLayout2 = this.ContentGenericLayout;
		if (contentGenericLayout2 == null)
		{
			return;
		}
		contentGenericLayout2.RefreshByData(this.HandBookCommonItemDataList, null, false);
	}

	// Token: 0x0600E6B1 RID: 59057 RVA: 0x003E4871 File Offset: 0x003E2A71
	private HandBookQuestChildItem InitChildItem()
	{
		return new HandBookQuestChildItem();
	}

	// Token: 0x0600E6B2 RID: 59058 RVA: 0x003E4878 File Offset: 0x003E2A78
	public List<HandBookQuestChildItem> GetChildItemList()
	{
		return this.ContentGenericLayout.GetLayoutItemList();
	}

	// Token: 0x0600E6B3 RID: 59059 RVA: 0x003E4885 File Offset: 0x003E2A85
	protected override void OnBeforeDestroy()
	{
		if (this.ContentGenericLayout != null)
		{
			this.ContentGenericLayout.ClearChildren();
			this.ContentGenericLayout = null;
		}
		this.QuestHandBookList = new List<PhotographHandBook>();
		this.HandBookCommonItemDataList = new List<HandBookCommonItemData>();
	}

	// Token: 0x04006F3F RID: 28479
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<HandBookQuestChildItem, HandBookCommonItemData> ContentGenericLayout;

	// Token: 0x04006F40 RID: 28480
	private List<PhotographHandBook> QuestHandBookList;

	// Token: 0x04006F41 RID: 28481
	private List<HandBookCommonItemData> HandBookCommonItemDataList;
}
