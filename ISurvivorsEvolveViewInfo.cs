using System;
using System.Runtime.CompilerServices;

// Token: 0x02002AE7 RID: 10983
[NullableContext(1)]
public interface ISurvivorsEvolveViewInfo
{
	// Token: 0x17001C81 RID: 7297
	// (get) Token: 0x06015F69 RID: 89961
	ESurvivorsRogueItemType SourceType { get; }

	// Token: 0x17001C82 RID: 7298
	// (get) Token: 0x06015F6A RID: 89962
	int SourceId { get; }

	// Token: 0x17001C83 RID: 7299
	// (get) Token: 0x06015F6B RID: 89963
	string TitleId { get; }

	// Token: 0x17001C84 RID: 7300
	// (get) Token: 0x06015F6C RID: 89964
	int EvolveId { get; }

	// Token: 0x17001C85 RID: 7301
	// (get) Token: 0x06015F6D RID: 89965
	ESurvivorsRogueItemType? BondType { get; }

	// Token: 0x17001C86 RID: 7302
	// (get) Token: 0x06015F6E RID: 89966
	int? BondId { get; }

	// Token: 0x17001C87 RID: 7303
	// (get) Token: 0x06015F6F RID: 89967
	bool? PlayTween { get; }

	// Token: 0x17001C88 RID: 7304
	// (get) Token: 0x06015F70 RID: 89968
	[Nullable(2)]
	int[] WeaponEvolveIds { [NullableContext(2)] get; }
}
