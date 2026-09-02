using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FilterDefine;

// Token: 0x020018E4 RID: 6372
[NullableContext(1)]
[Nullable(0)]
public abstract class CommonFilter
{
	// Token: 0x0600B726 RID: 46886 RVA: 0x0030BFDE File Offset: 0x0030A1DE
	public CommonFilter()
	{
		this.FilterMap = new Dictionary<FilterDefine.EFilterType, TFilterConfig>();
	}

	// Token: 0x0600B727 RID: 46887 RVA: 0x0030BFF1 File Offset: 0x0030A1F1
	public void InitFilterMap()
	{
		if (this.IsInit)
		{
			return;
		}
		this.IsInit = true;
		this.OnInitFilterMap();
	}

	// Token: 0x0600B728 RID: 46888 RVA: 0x0030C00C File Offset: 0x0030A20C
	[NullableContext(2)]
	public TFilterConfig GetFilterFunction(FilterDefine.EFilterType filterType)
	{
		TFilterConfig result;
		if (this.FilterMap.TryGetValue(filterType, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600B729 RID: 46889
	protected abstract void OnInitFilterMap();

	// Token: 0x0600B72A RID: 46890 RVA: 0x0030C02C File Offset: 0x0030A22C
	public virtual TDefaultFilter[] DefaultFilterList()
	{
		return Array.Empty<TDefaultFilter>();
	}

	// Token: 0x0400568A RID: 22154
	protected Dictionary<FilterDefine.EFilterType, TFilterConfig> FilterMap;

	// Token: 0x0400568B RID: 22155
	private bool IsInit;
}
