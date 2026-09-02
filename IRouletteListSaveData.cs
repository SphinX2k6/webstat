using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002919 RID: 10521
[NullableContext(1)]
public interface IRouletteListSaveData
{
	// Token: 0x17001B69 RID: 7017
	// (get) Token: 0x06014DFA RID: 85498
	// (set) Token: 0x06014DFB RID: 85499
	ERouletteType RouletteType { get; set; }

	// Token: 0x17001B6A RID: 7018
	// (get) Token: 0x06014DFC RID: 85500
	// (set) Token: 0x06014DFD RID: 85501
	List<int> RouletteIdList { get; set; }

	// Token: 0x17001B6B RID: 7019
	// (get) Token: 0x06014DFE RID: 85502
	// (set) Token: 0x06014DFF RID: 85503
	int ExtraItemId { get; set; }

	// Token: 0x17001B6C RID: 7020
	// (get) Token: 0x06014E00 RID: 85504
	// (set) Token: 0x06014E01 RID: 85505
	int EquipExploreSkillId { get; set; }
}
