using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002CD7 RID: 11479
[NullableContext(1)]
[Nullable(0)]
public class MultiTemplateComponent : IGridPreserver
{
	// Token: 0x06017219 RID: 94745 RVA: 0x00668F3C File Offset: 0x0066713C
	public MultiTemplateComponent(UUIItem rootItem, Dictionary<int, UUIItem> templateItems)
	{
		this.RootItem = rootItem;
		this.TemplateItems = templateItems;
		foreach (KeyValuePair<int, UUIItem> keyValuePair in templateItems)
		{
			this.PoolItems[keyValuePair.Key] = new List<UUIItem>();
			keyValuePair.Value.SetUIActive(false);
		}
		AActor owner = rootItem.GetOwner();
		if (owner != null)
		{
			this.AnimControllerComponent = (owner.GetComponentByClass(UUIInturnAnimController.StaticClass()) as UUIInturnAnimController);
		}
		this.GridsController = new InTurnGridAppearAnimation(this);
		this.GridsController.RegisterAnimController();
	}

	// Token: 0x0601721A RID: 94746 RVA: 0x00669030 File Offset: 0x00667230
	public void RefreshByData(List<IMultiTemplateGridData> dataList, bool playGridAnim = false)
	{
		if (!this.CheckDataListValid(dataList))
		{
			return;
		}
		this.RecycleAllItems();
		this.DataList = dataList.ToList<IMultiTemplateGridData>();
		this.AllocateDisplayItems();
		this.RefreshDirectly();
		if (playGridAnim && this.GridsController != null)
		{
			this.GridsController.PlayGridAnim(this.GetDisplayGridNum(), false);
		}
	}

	// Token: 0x0601721B RID: 94747 RVA: 0x00669084 File Offset: 0x00667284
	public bool AddItem(IMultiTemplateGridData data)
	{
		UUIItem uuiitem = this.AcquireItem(data);
		if (uuiitem == null)
		{
			return false;
		}
		ISyncGridProxy syncGridProxy = this.EnsureProxy(uuiitem, data);
		uuiitem.SetUIActive(true);
		int count = this.DataList.Count;
		this.DataList.Add(data);
		this.DisplayItems.Add(uuiitem);
		uuiitem.SetHierarchyIndex(count);
		syncGridProxy.GridIndex = count;
		syncGridProxy.Refresh(data.Data);
		return true;
	}

	// Token: 0x0601721C RID: 94748 RVA: 0x006690EC File Offset: 0x006672EC
	public bool RemoveLastItem()
	{
		if (this.DisplayItems.Count == 0)
		{
			Singleton<Log>.Instance.Error(ELogModule.MultiTemplateComponent, ELogAuthor.LZK, "[MultiTemplateComponent] [RemoveLastItem] Display items is empty", default(ReadOnlySpan<ValueTuple<string, object>>));
			return false;
		}
		int displayIndex = this.DisplayItems.Count - 1;
		this.RecycleItemByIndex(displayIndex);
		this.DataList.RemoveAt(this.DataList.Count - 1);
		this.DisplayItems.RemoveAt(this.DisplayItems.Count - 1);
		return true;
	}

	// Token: 0x0601721D RID: 94749 RVA: 0x00669170 File Offset: 0x00667370
	public unsafe void RefreshDirectly()
	{
		if (this.DisplayItems.Count != this.DataList.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiTemplateComponent;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "[MultiTemplateComponent] [RefreshDirectly] Display items length is not equal to data list length";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("displayItemsLength", this.DisplayItems.Count);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("dataListLength", this.DataList.Count);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		for (int i = 0; i < this.DataList.Count; i++)
		{
			IMultiTemplateGridData multiTemplateGridData = this.DataList[i];
			UUIItem uuiitem = this.DisplayItems[i];
			ISyncGridProxy syncGridProxy;
			if (!this.ProxyItems.TryGetValue(uuiitem, out syncGridProxy))
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.MultiTemplateComponent;
				ELogAuthor author2 = ELogAuthor.LZK;
				string message2 = "[MultiTemplateComponent] [RefreshDirectly] Proxy not found for display item";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("index", i);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("item", uuiitem);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
			}
			else
			{
				syncGridProxy.Refresh(multiTemplateGridData.Data);
			}
		}
	}

	// Token: 0x0601721E RID: 94750 RVA: 0x006692C0 File Offset: 0x006674C0
	private void AllocateDisplayItems()
	{
		for (int i = 0; i < this.DataList.Count; i++)
		{
			IMultiTemplateGridData data = this.DataList[i];
			UUIItem uuiitem = this.AcquireItem(data);
			if (uuiitem != null)
			{
				ISyncGridProxy syncGridProxy = this.EnsureProxy(uuiitem, data);
				uuiitem.SetUIActive(true);
				uuiitem.SetHierarchyIndex(i);
				syncGridProxy.GridIndex = i;
				this.DisplayItems.Add(uuiitem);
			}
		}
	}

	// Token: 0x0601721F RID: 94751 RVA: 0x00669324 File Offset: 0x00667524
	[return: Nullable(2)]
	private UUIItem AcquireItem(IMultiTemplateGridData data)
	{
		int templateIndex = data.GetTemplateIndex();
		UUIItem uuiitem = this.PopItemFromPool(templateIndex);
		if (uuiitem != null)
		{
			return uuiitem;
		}
		UUIItem uuiitem2 = this.CreateItemByTemplateIndex(templateIndex);
		if (uuiitem2 == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiTemplateComponent;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "[MultiTemplateComponent] [AcquireItem] Failed to create item by template index";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("templateIndex", templateIndex);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return uuiitem2;
	}

	// Token: 0x06017220 RID: 94752 RVA: 0x00669384 File Offset: 0x00667584
	private ISyncGridProxy EnsureProxy(UUIItem item, IMultiTemplateGridData data)
	{
		ISyncGridProxy syncGridProxy;
		if (!this.ProxyItems.TryGetValue(item, out syncGridProxy))
		{
			syncGridProxy = data.CreateProxy();
			this.ProxyItems[item] = syncGridProxy;
			syncGridProxy.CreateByActor(item.GetOwner());
		}
		return syncGridProxy;
	}

	// Token: 0x06017221 RID: 94753 RVA: 0x006693C4 File Offset: 0x006675C4
	[NullableContext(2)]
	private UUIItem PopItemFromPool(int templateIndex)
	{
		List<UUIItem> list;
		if (!this.PoolItems.TryGetValue(templateIndex, out list))
		{
			return null;
		}
		if (list.Count == 0)
		{
			return null;
		}
		UUIItem result = list[list.Count - 1];
		list.RemoveAt(list.Count - 1);
		return result;
	}

	// Token: 0x06017222 RID: 94754 RVA: 0x0066940C File Offset: 0x0066760C
	[NullableContext(2)]
	private UUIItem CreateItemByTemplateIndex(int templateIndex)
	{
		UUIItem item;
		if (!this.TemplateItems.TryGetValue(templateIndex, out item))
		{
			return null;
		}
		return Singleton<LguiUtil>.Instance.CopyItem(item, this.RootItem);
	}

	// Token: 0x06017223 RID: 94755 RVA: 0x0066943C File Offset: 0x0066763C
	private void RecycleAllItems()
	{
		if (this.DisplayItems.Count == 0)
		{
			return;
		}
		for (int i = 0; i < this.DisplayItems.Count; i++)
		{
			this.RecycleItemByIndex(i);
		}
		this.DisplayItems.Clear();
	}

	// Token: 0x06017224 RID: 94756 RVA: 0x00669480 File Offset: 0x00667680
	private unsafe void RecycleItemByIndex(int displayIndex)
	{
		if (displayIndex < 0 || displayIndex >= this.DisplayItems.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiTemplateComponent;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "[MultiTemplateComponent] [RecycleItemByIndex] Display index out of range";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("displayIndex", displayIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("displayItemsLength", this.DisplayItems.Count);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return;
		}
		UUIItem uuiitem = this.DisplayItems[displayIndex];
		if (uuiitem == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.MultiTemplateComponent;
			ELogAuthor author2 = ELogAuthor.LZK;
			string message2 = "[MultiTemplateComponent] [RecycleItemByIndex] Item not found in display items";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("displayIndex", displayIndex);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		ISyncGridProxy syncGridProxy;
		if (!this.ProxyItems.TryGetValue(uuiitem, out syncGridProxy))
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.MultiTemplateComponent;
			ELogAuthor author3 = ELogAuthor.LZK;
			string message3 = "[MultiTemplateComponent] [RecycleItemByIndex] Proxy not found in proxy items";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("displayIndex", displayIndex);
			instance3.Error(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return;
		}
		int templateIndex = this.DataList[displayIndex].GetTemplateIndex();
		List<UUIItem> list;
		if (!this.PoolItems.TryGetValue(templateIndex, out list))
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.MultiTemplateComponent;
			ELogAuthor author4 = ELogAuthor.LZK;
			string message4 = "[MultiTemplateComponent] [RecycleItemByIndex] Template index not found in pool items";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("templateIndex", templateIndex);
			instance4.Error(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
			return;
		}
		uuiitem.SetUIActive(false);
		list.Add(uuiitem);
		syncGridProxy.Clear();
	}

	// Token: 0x06017225 RID: 94757 RVA: 0x006695F0 File Offset: 0x006677F0
	public unsafe bool CheckDataListValid(List<IMultiTemplateGridData> dataList)
	{
		for (int i = 0; i < dataList.Count; i++)
		{
			int templateIndex = dataList[i].GetTemplateIndex();
			if (!this.TemplateItems.ContainsKey(templateIndex))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MultiTemplateComponent;
				ELogAuthor author = ELogAuthor.LZK;
				string message = "[MultiTemplateComponent] [CheckDataListValid] Template index not found in template items";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("dataIndex", i);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("templateIndex", templateIndex);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
		}
		return true;
	}

	// Token: 0x06017226 RID: 94758 RVA: 0x00669692 File Offset: 0x00667892
	public List<UUIItem> GetDisplayItems()
	{
		return this.DisplayItems;
	}

	// Token: 0x06017227 RID: 94759 RVA: 0x0066969A File Offset: 0x0066789A
	[NullableContext(2)]
	public UUIItem GetItemByDisplayIndex(int displayIndex)
	{
		if (displayIndex < 0 || displayIndex >= this.DisplayItems.Count)
		{
			return null;
		}
		return this.DisplayItems[displayIndex];
	}

	// Token: 0x06017228 RID: 94760 RVA: 0x006696BC File Offset: 0x006678BC
	[NullableContext(2)]
	public ISyncGridProxy GetProxyByDisplayIndex(int displayIndex)
	{
		UUIItem uuiitem = this.DisplayItems[displayIndex];
		if (uuiitem == null)
		{
			return null;
		}
		ISyncGridProxy result;
		if (this.ProxyItems.TryGetValue(uuiitem, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06017229 RID: 94761 RVA: 0x006696F0 File Offset: 0x006678F0
	public unsafe int GetTemplateIndexByDisplayIndex(int displayIndex)
	{
		if (displayIndex < 0 || displayIndex >= this.DataList.Count)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MultiTemplateComponent;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "[MultiTemplateComponent] [GetTemplateIndexByDisplayIndex] Display index out of range";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("displayIndex", displayIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("dataListLength", this.DataList.Count);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return -1;
		}
		return this.DataList[displayIndex].GetTemplateIndex();
	}

	// Token: 0x0601722A RID: 94762 RVA: 0x0066978C File Offset: 0x0066798C
	public int GetDisplayGridNum()
	{
		return this.DisplayItems.Count;
	}

	// Token: 0x0601722B RID: 94763 RVA: 0x00669799 File Offset: 0x00667999
	public int GetPreservedGridNum()
	{
		return this.DisplayItems.Count;
	}

	// Token: 0x0601722C RID: 94764 RVA: 0x006697A6 File Offset: 0x006679A6
	public int GetDisplayGridStartIndex()
	{
		return 0;
	}

	// Token: 0x0601722D RID: 94765 RVA: 0x006697A9 File Offset: 0x006679A9
	public int GetDisplayGridEndIndex()
	{
		return this.GetDisplayGridNum() - 1;
	}

	// Token: 0x0601722E RID: 94766 RVA: 0x006697B3 File Offset: 0x006679B3
	[NullableContext(2)]
	public UUIItem GetGrid(int gridIndex)
	{
		if (gridIndex < 0 || gridIndex >= this.DisplayItems.Count)
		{
			return null;
		}
		return this.DisplayItems[gridIndex];
	}

	// Token: 0x0601722F RID: 94767 RVA: 0x006697D5 File Offset: 0x006679D5
	[NullableContext(2)]
	public UUIItem GetGridByDisplayIndex(int displayIndex)
	{
		if (displayIndex < 0 || displayIndex >= this.DisplayItems.Count)
		{
			return null;
		}
		return this.DisplayItems[displayIndex];
	}

	// Token: 0x06017230 RID: 94768 RVA: 0x006697F7 File Offset: 0x006679F7
	public float GetGridAnimationInterval()
	{
		return 0f;
	}

	// Token: 0x06017231 RID: 94769 RVA: 0x006697FE File Offset: 0x006679FE
	public float GetGridAnimationStartTime()
	{
		return 0f;
	}

	// Token: 0x06017232 RID: 94770 RVA: 0x00669805 File Offset: 0x00667A05
	public void NotifyAnimationStart()
	{
	}

	// Token: 0x06017233 RID: 94771 RVA: 0x00669807 File Offset: 0x00667A07
	public void NotifyAnimationEnd()
	{
	}

	// Token: 0x06017234 RID: 94772 RVA: 0x00669809 File Offset: 0x00667A09
	[NullableContext(2)]
	public UUIInturnAnimController GetUiAnimController()
	{
		return this.AnimControllerComponent;
	}

	// Token: 0x0400B1FC RID: 45564
	[Nullable(2)]
	private readonly UUIItem RootItem;

	// Token: 0x0400B1FD RID: 45565
	private List<IMultiTemplateGridData> DataList = new List<IMultiTemplateGridData>();

	// Token: 0x0400B1FE RID: 45566
	private readonly Dictionary<int, UUIItem> TemplateItems = new Dictionary<int, UUIItem>();

	// Token: 0x0400B1FF RID: 45567
	private readonly Dictionary<int, List<UUIItem>> PoolItems = new Dictionary<int, List<UUIItem>>();

	// Token: 0x0400B200 RID: 45568
	private readonly Dictionary<UUIItem, ISyncGridProxy> ProxyItems = new Dictionary<UUIItem, ISyncGridProxy>();

	// Token: 0x0400B201 RID: 45569
	private readonly List<UUIItem> DisplayItems = new List<UUIItem>();

	// Token: 0x0400B202 RID: 45570
	[Nullable(2)]
	private readonly GridAppearAnimationBase GridsController;

	// Token: 0x0400B203 RID: 45571
	[Nullable(2)]
	private readonly UUIInturnAnimController AnimControllerComponent;
}
