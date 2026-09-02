using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using FilterDefine;
using UnrealEngine;

// Token: 0x02001909 RID: 6409
public class FilterView : UiViewBase
{
	// Token: 0x0600B80D RID: 47117 RVA: 0x0030F071 File Offset: 0x0030D271
	[NullableContext(1)]
	public FilterView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600B80E RID: 47118 RVA: 0x0030F07C File Offset: 0x0030D27C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.ResetView));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.SaveDataAndCloseView));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600B80F RID: 47119 RVA: 0x0030F168 File Offset: 0x0030D368
	private void ResetView()
	{
		foreach (FilterGroup filterGroup in this.Scroll.GetScrollItemList())
		{
			filterGroup.ResetTempFilterDataMap();
			filterGroup.RefreshGroupItem();
			filterGroup.RefreshSelectAllToggleState();
		}
	}

	// Token: 0x0600B810 RID: 47120 RVA: 0x0030F1CC File Offset: 0x0030D3CC
	private void SaveDataAndCloseView()
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		foreach (KeyValuePair<object, FilterGroup> keyValuePair in this.Scroll.GetScrollItemMap())
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

	// Token: 0x0600B811 RID: 47121 RVA: 0x0030F270 File Offset: 0x0030D470
	protected override void OnBeforeCreate()
	{
		this.ViewData = (this.OpenParam as FilterViewData);
	}

	// Token: 0x0600B812 RID: 47122 RVA: 0x0030F284 File Offset: 0x0030D484
	protected override UniTask OnCreateAsync()
	{
		FilterView.<OnCreateAsync>d__9 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<FilterView.<OnCreateAsync>d__9>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600B813 RID: 47123 RVA: 0x0030F2C7 File Offset: 0x0030D4C7
	protected override void OnStart()
	{
		this.LayoutItem.SetUIParent(base.GetScrollViewWithScrollbar(0).ContentUIItem, false);
		this.InitFilter();
	}

	// Token: 0x0600B814 RID: 47124 RVA: 0x0030F2EC File Offset: 0x0030D4EC
	[NullableContext(1)]
	private ILayoutItem<FilterGroup> InitFilterGroup(object ruleId, UUIItem uiItem, int index)
	{
		FilterGroup filterGroup = new FilterGroup(uiItem);
		filterGroup.ShowTemp((int)ruleId, this.ViewData.UniqueId);
		FilterDefine.EFilterType filterType = filterGroup.GetFilterType();
		return new LayoutItem<FilterGroup>
		{
			Key = filterType,
			Value = filterGroup
		};
	}

	// Token: 0x0600B815 RID: 47125 RVA: 0x0030F336 File Offset: 0x0030D536
	protected override void OnBeforeDestroy()
	{
		this.Scroll.ClearChildren();
	}

	// Token: 0x0600B816 RID: 47126 RVA: 0x0030F344 File Offset: 0x0030D544
	private void InitFilter()
	{
		this.Scroll = new GenericScrollView<FilterGroup>(base.GetScrollViewWithScrollbar(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<FilterGroup>(this.InitFilterGroup), this.LayoutItem);
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(this.ViewData.UniqueId);
		Filter? filterConfig = ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterResultData.ConfigId);
		this.Scroll.RefreshByData<int>(filterConfig.Value.RuleList().ToList<int>(), null);
	}

	// Token: 0x040056C1 RID: 22209
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericScrollView<FilterGroup> Scroll;

	// Token: 0x040056C2 RID: 22210
	[Nullable(2)]
	private FilterViewData ViewData;

	// Token: 0x040056C3 RID: 22211
	[Nullable(2)]
	private UUIItem LayoutItem;

	// Token: 0x02007C58 RID: 31832
	private enum ECompDefine
	{
		// Token: 0x0402A78D RID: 173965
		Scroll,
		// Token: 0x0402A78E RID: 173966
		ClearButton,
		// Token: 0x0402A78F RID: 173967
		ConfirmButton
	}
}
