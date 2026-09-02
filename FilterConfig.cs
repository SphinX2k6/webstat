using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x020018FB RID: 6395
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class FilterConfig : ConfigBase<FilterConfig>
{
	// Token: 0x0600B790 RID: 46992 RVA: 0x0030D633 File Offset: 0x0030B833
	protected override bool OnInit()
	{
		this.Phantom4cMainProperty = ConfigCommonParamById.GetIntArrayConfig("Phantom4CMainProperty");
		this.Phantom3cMainProperty = ConfigCommonParamById.GetIntArrayConfig("Phantom3CMainProperty");
		this.Phantom1cMainProperty = ConfigCommonParamById.GetIntArrayConfig("Phantom1CMainProperty");
		return true;
	}

	// Token: 0x0600B791 RID: 46993 RVA: 0x0030D666 File Offset: 0x0030B866
	public Filter? GetFilterConfig(int id)
	{
		return ConfigFilterById.GetConfig(id, true);
	}

	// Token: 0x0600B792 RID: 46994 RVA: 0x0030D66F File Offset: 0x0030B86F
	public FilterRule? GetFilterRuleConfig(int id)
	{
		return ConfigFilterRuleById.GetConfig(id, true);
	}

	// Token: 0x0600B793 RID: 46995 RVA: 0x0030D678 File Offset: 0x0030B878
	public int GetFilterId(EFilterSortGroupId groupId)
	{
		return ConfigFilterSortGroupById.GetConfig((int)groupId, true).Value.FilterId;
	}

	// Token: 0x0600B794 RID: 46996 RVA: 0x0030D69C File Offset: 0x0030B89C
	public IReadOnlyList<int> GetCostByMainMainProp(int mainPropId)
	{
		List<int> list = new List<int>();
		if (this.Phantom4cMainProperty.IndexOf(mainPropId) >= 0)
		{
			list.Add(4);
		}
		if (this.Phantom3cMainProperty.IndexOf(mainPropId) >= 0)
		{
			list.Add(3);
		}
		if (this.Phantom1cMainProperty.IndexOf(mainPropId) >= 0)
		{
			list.Add(1);
		}
		return list;
	}

	// Token: 0x0600B795 RID: 46997 RVA: 0x0030D6F2 File Offset: 0x0030B8F2
	public IReadOnlyList<int> GetMainPropIdsByCost(int cost)
	{
		switch (cost)
		{
		case 1:
			return this.Phantom1cMainProperty;
		case 3:
			return this.Phantom3cMainProperty;
		case 4:
			return this.Phantom4cMainProperty;
		}
		return Array.Empty<int>();
	}

	// Token: 0x0400568E RID: 22158
	private const int COST_4C = 4;

	// Token: 0x0400568F RID: 22159
	private const int COST_3C = 3;

	// Token: 0x04005690 RID: 22160
	private const int COST_1C = 1;

	// Token: 0x04005691 RID: 22161
	private IReadOnlyList<int> Phantom4cMainProperty;

	// Token: 0x04005692 RID: 22162
	private IReadOnlyList<int> Phantom3cMainProperty;

	// Token: 0x04005693 RID: 22163
	private IReadOnlyList<int> Phantom1cMainProperty;
}
