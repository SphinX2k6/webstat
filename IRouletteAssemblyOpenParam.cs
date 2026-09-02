using System;

// Token: 0x02002915 RID: 10517
public interface IRouletteAssemblyOpenParam
{
	// Token: 0x17001B5B RID: 7003
	// (get) Token: 0x06014DDC RID: 85468
	// (set) Token: 0x06014DDD RID: 85469
	ERouletteType? RouletteType { get; set; }

	// Token: 0x17001B5C RID: 7004
	// (get) Token: 0x06014DDE RID: 85470
	// (set) Token: 0x06014DDF RID: 85471
	int? SelectGridId { get; set; }

	// Token: 0x17001B5D RID: 7005
	// (get) Token: 0x06014DE0 RID: 85472
	// (set) Token: 0x06014DE1 RID: 85473
	int? SelectGridIndex { get; set; }

	// Token: 0x17001B5E RID: 7006
	// (get) Token: 0x06014DE2 RID: 85474
	// (set) Token: 0x06014DE3 RID: 85475
	ERouletteExploreId? EndSwitchSkillId { get; set; }
}
