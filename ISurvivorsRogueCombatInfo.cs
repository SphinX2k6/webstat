using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000F7F RID: 3967
[NullableContext(2)]
public interface ISurvivorsRogueCombatInfo
{
	// Token: 0x170007B5 RID: 1973
	// (get) Token: 0x0600648C RID: 25740
	// (set) Token: 0x0600648D RID: 25741
	ESurvivorsRogueEntityType EntityType { get; set; }

	// Token: 0x170007B6 RID: 1974
	// (get) Token: 0x0600648E RID: 25742
	// (set) Token: 0x0600648F RID: 25743
	int Uid { get; set; }

	// Token: 0x170007B7 RID: 1975
	// (get) Token: 0x06006490 RID: 25744
	// (set) Token: 0x06006491 RID: 25745
	int OwnerId { get; set; }

	// Token: 0x170007B8 RID: 1976
	// (get) Token: 0x06006492 RID: 25746
	// (set) Token: 0x06006493 RID: 25747
	int TemplateId { get; set; }

	// Token: 0x170007B9 RID: 1977
	// (get) Token: 0x06006494 RID: 25748
	// (set) Token: 0x06006495 RID: 25749
	int CombatId { get; set; }

	// Token: 0x170007BA RID: 1978
	// (get) Token: 0x06006496 RID: 25750
	// (set) Token: 0x06006497 RID: 25751
	int SubTypeId { get; set; }

	// Token: 0x170007BB RID: 1979
	// (get) Token: 0x06006498 RID: 25752
	// (set) Token: 0x06006499 RID: 25753
	string PrefabPath { get; set; }

	// Token: 0x170007BC RID: 1980
	// (get) Token: 0x0600649A RID: 25754
	// (set) Token: 0x0600649B RID: 25755
	string AssetPath { get; set; }

	// Token: 0x170007BD RID: 1981
	// (get) Token: 0x0600649C RID: 25756
	// (set) Token: 0x0600649D RID: 25757
	int PropertyId { get; set; }

	// Token: 0x170007BE RID: 1982
	// (get) Token: 0x0600649E RID: 25758
	// (set) Token: 0x0600649F RID: 25759
	int? SplineId { get; set; }

	// Token: 0x170007BF RID: 1983
	// (get) Token: 0x060064A0 RID: 25760
	// (set) Token: 0x060064A1 RID: 25761
	Dictionary<int, int> BuffIdLayers { get; set; }

	// Token: 0x170007C0 RID: 1984
	// (get) Token: 0x060064A2 RID: 25762
	// (set) Token: 0x060064A3 RID: 25763
	Dictionary<int, int> AttributeMap { get; set; }

	// Token: 0x170007C1 RID: 1985
	// (get) Token: 0x060064A4 RID: 25764
	// (set) Token: 0x060064A5 RID: 25765
	[Nullable(1)]
	Vector Position { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170007C2 RID: 1986
	// (get) Token: 0x060064A6 RID: 25766
	// (set) Token: 0x060064A7 RID: 25767
	[Nullable(1)]
	Rotator Rotation { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x060064A8 RID: 25768
	[NullableContext(1)]
	void Update(ISurvivorsRogueCombatInfo other);

	// Token: 0x060064A9 RID: 25769
	bool IsValid();

	// Token: 0x060064AA RID: 25770
	void Reset();

	// Token: 0x060064AB RID: 25771
	void Release();

	// Token: 0x060064AC RID: 25772
	[NullableContext(1)]
	ISurvivorsRogueCombatInfo Clone();
}
