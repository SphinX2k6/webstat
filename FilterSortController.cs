using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using FilterDefine;

// Token: 0x020018D7 RID: 6359
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class FilterSortController : UiControllerBase<FilterSortController>
{
	// Token: 0x0600B6DA RID: 46810 RVA: 0x00309E14 File Offset: 0x00308014
	public void OpenFilterView(FilterViewData viewData)
	{
		FilterResultData filterResultData = ModelBase<FilterModel>.Instance.GetFilterResultData(viewData.UniqueId);
		Filter? filterConfig = ConfigBase<FilterConfig>.Instance.GetFilterConfig(filterResultData.ConfigId);
		if (filterConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.FilterSortView;
			ELogAuthor author = ELogAuthor.CB;
			string message = "找不到筛选配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId:", filterResultData.ConfigId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (filterConfig.Value.DataType == 2 || filterConfig.Value.DataType == 4)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionFilterView, viewData, null);
			return;
		}
		if (filterConfig.Value.DataType == 22 || filterConfig.Value.DataType == 21 || filterConfig.Value.DataType == 23)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballFilterView, viewData, null);
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FilterView, viewData, null);
	}

	// Token: 0x0600B6DB RID: 46811 RVA: 0x00309F13 File Offset: 0x00308113
	public void OpenPhantomFilterView(PhantomFilterViewData<IPhantomFilterData> viewData)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.PhantomFilterPopupView, viewData, null);
	}

	// Token: 0x0600B6DC RID: 46812 RVA: 0x00309F26 File Offset: 0x00308126
	public void OpenSortView(SortViewData viewData)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.SortView, viewData, null);
	}
}
