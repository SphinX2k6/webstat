using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using FilterDefine;
using UnrealEngine;

// Token: 0x0200191A RID: 6426
public class PinballFilterView : UiViewBase
{
	// Token: 0x0600B8C9 RID: 47305 RVA: 0x00312234 File Offset: 0x00310434
	[NullableContext(1)]
	public PinballFilterView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B8CA RID: 47306 RVA: 0x00312240 File Offset: 0x00310440
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ResetView));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.SaveDataAndCloseView));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B8CB RID: 47307 RVA: 0x0031236C File Offset: 0x0031056C
	private void ResetView()
	{
		foreach (PinballFilterGroup pinballFilterGroup in this.Scroll.GetScrollItemList())
		{
			pinballFilterGroup.ResetTempFilterDataMap();
			pinballFilterGroup.RefreshGroupItem();
		}
	}

	// Token: 0x0600B8CC RID: 47308 RVA: 0x003123C8 File Offset: 0x003105C8
	private void SaveDataAndCloseView()
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		foreach (KeyValuePair<object, PinballFilterGroup> keyValuePair in this.Scroll.GetScrollItemMap())
		{
			Dictionary<int, string> tempFilterDataMap = keyValuePair.Value.GetTempFilterDataMap();
			filterResultData.SetSelectRuleData((FilterDefine.EFilterType)keyValuePair.Key, tempFilterDataMap);
		}
		Action confirmFunction = this.ViewData.ConfirmFunction;
		if (confirmFunction != null)
		{
			confirmFunction();
		}
		base.CloseMe(null);
	}

	// Token: 0x0600B8CD RID: 47309 RVA: 0x0031246C File Offset: 0x0031066C
	protected override void OnBeforeCreate()
	{
		this.ViewData = (this.OpenParam as FilterViewData);
	}

	// Token: 0x0600B8CE RID: 47310 RVA: 0x0031247F File Offset: 0x0031067F
	protected override void OnStart()
	{
		this.InitFilter();
	}

	// Token: 0x0600B8CF RID: 47311 RVA: 0x00312488 File Offset: 0x00310688
	[NullableContext(1)]
	private ILayoutItem<PinballFilterGroup> InitFilterGroup(object ruleId, UUIItem uiItem, int index)
	{
		PinballFilterGroup pinballFilterGroup = new PinballFilterGroup(uiItem);
		pinballFilterGroup.ShowTemp((int)ruleId, this.ViewData.UniqueId);
		FilterDefine.EFilterType filterType = pinballFilterGroup.GetFilterType();
		return new LayoutItem<PinballFilterGroup>
		{
			Key = filterType,
			Value = pinballFilterGroup
		};
	}

	// Token: 0x0600B8D0 RID: 47312 RVA: 0x003124D2 File Offset: 0x003106D2
	protected override void OnBeforeDestroy()
	{
		this.Scroll.ClearChildren();
	}

	// Token: 0x0600B8D1 RID: 47313 RVA: 0x003124E0 File Offset: 0x003106E0
	private void InitFilter()
	{
		this.Scroll = new GenericScrollView<PinballFilterGroup>(base.GetScrollViewWithScrollbar(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<PinballFilterGroup>(this.InitFilterGroup), base.GetItem(3));
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		Filter? filterConfig = ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterResultData.ConfigId);
		this.Scroll.RefreshByData<int>(filterConfig.Value.RuleList().ToList<int>(), null);
	}

	// Token: 0x040056F8 RID: 22264
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollView<PinballFilterGroup> Scroll;

	// Token: 0x040056F9 RID: 22265
	[Nullable(2)]
	private FilterViewData ViewData;

	// Token: 0x02007C6D RID: 31853
	private enum EComponent
	{
		// Token: 0x0402A7EE RID: 174062
		ClearButton,
		// Token: 0x0402A7EF RID: 174063
		ConfirmButton,
		// Token: 0x0402A7F0 RID: 174064
		Scroll,
		// Token: 0x0402A7F1 RID: 174065
		ScrollItem,
		// Token: 0x0402A7F2 RID: 174066
		Title
	}
}
