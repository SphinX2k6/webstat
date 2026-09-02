using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using FilterDefine;

// Token: 0x020018ED RID: 6381
[NullableContext(1)]
[Nullable(0)]
public class MonsterHandBookFilter : CommonFilter
{
	// Token: 0x0600B751 RID: 46929 RVA: 0x0030C838 File Offset: 0x0030AA38
	private object GetMonsterDetectConfig(object data, Dictionary<int, string> currentSelectMap)
	{
		int id = (int)data;
		HandBookConfig instance = ConfigBase<HandBookConfig>.Instance;
		MonsterHandBook? monsterHandBook = (instance != null) ? instance.GetMonsterHandBookConfigById(id) : null;
		return (monsterHandBook != null) ? monsterHandBook.GetValueOrDefault().Type : 0;
	}

	// Token: 0x0600B752 RID: 46930 RVA: 0x0030C888 File Offset: 0x0030AA88
	private object GetMonsterTypeConfig(object data, Dictionary<int, string> currentSelectMap)
	{
		int id = (int)data;
		HandBookConfig instance = ConfigBase<HandBookConfig>.Instance;
		MonsterHandBook? monsterHandBook = (instance != null) ? instance.GetMonsterHandBookConfigById(id) : null;
		return (monsterHandBook != null) ? monsterHandBook.GetValueOrDefault().Classification : 0;
	}

	// Token: 0x0600B753 RID: 46931 RVA: 0x0030C8D7 File Offset: 0x0030AAD7
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.MonsterDetect, new TFilterConfig(this.GetMonsterDetectConfig));
		this.FilterMap.Add(FilterDefine.EFilterType.MonsterType, new TFilterConfig(this.GetMonsterTypeConfig));
	}
}
