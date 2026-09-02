using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000F29 RID: 3881
[NullableContext(2)]
public interface IFinalBattleCombatInfo
{
	// Token: 0x17000703 RID: 1795
	// (get) Token: 0x060060AF RID: 24751
	// (set) Token: 0x060060B0 RID: 24752
	EFinalBattleEntityType EntityType { get; set; }

	// Token: 0x17000704 RID: 1796
	// (get) Token: 0x060060B1 RID: 24753
	// (set) Token: 0x060060B2 RID: 24754
	int Uid { get; set; }

	// Token: 0x17000705 RID: 1797
	// (get) Token: 0x060060B3 RID: 24755
	// (set) Token: 0x060060B4 RID: 24756
	int OwnerId { get; set; }

	// Token: 0x17000706 RID: 1798
	// (get) Token: 0x060060B5 RID: 24757
	// (set) Token: 0x060060B6 RID: 24758
	int TemplateId { get; set; }

	// Token: 0x17000707 RID: 1799
	// (get) Token: 0x060060B7 RID: 24759
	// (set) Token: 0x060060B8 RID: 24760
	int CombatId { get; set; }

	// Token: 0x17000708 RID: 1800
	// (get) Token: 0x060060B9 RID: 24761
	// (set) Token: 0x060060BA RID: 24762
	int SubTypeId { get; set; }

	// Token: 0x17000709 RID: 1801
	// (get) Token: 0x060060BB RID: 24763
	// (set) Token: 0x060060BC RID: 24764
	string PrefabPath { get; set; }

	// Token: 0x1700070A RID: 1802
	// (get) Token: 0x060060BD RID: 24765
	// (set) Token: 0x060060BE RID: 24766
	string AssetPath { get; set; }

	// Token: 0x1700070B RID: 1803
	// (get) Token: 0x060060BF RID: 24767
	// (set) Token: 0x060060C0 RID: 24768
	int PropertyId { get; set; }

	// Token: 0x1700070C RID: 1804
	// (get) Token: 0x060060C1 RID: 24769
	// (set) Token: 0x060060C2 RID: 24770
	int? SplineId { get; set; }

	// Token: 0x1700070D RID: 1805
	// (get) Token: 0x060060C3 RID: 24771
	// (set) Token: 0x060060C4 RID: 24772
	Dictionary<int, int> BuffIdLayers { get; set; }

	// Token: 0x1700070E RID: 1806
	// (get) Token: 0x060060C5 RID: 24773
	// (set) Token: 0x060060C6 RID: 24774
	Dictionary<int, int> AttributeMap { get; set; }

	// Token: 0x1700070F RID: 1807
	// (get) Token: 0x060060C7 RID: 24775
	// (set) Token: 0x060060C8 RID: 24776
	[Nullable(1)]
	Vector Position { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000710 RID: 1808
	// (get) Token: 0x060060C9 RID: 24777
	// (set) Token: 0x060060CA RID: 24778
	[Nullable(1)]
	Rotator Rotation { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x060060CB RID: 24779
	[NullableContext(1)]
	void Update(IFinalBattleCombatInfo other);

	// Token: 0x060060CC RID: 24780
	bool IsValid();

	// Token: 0x060060CD RID: 24781
	void Reset();

	// Token: 0x060060CE RID: 24782
	void Release();

	// Token: 0x060060CF RID: 24783
	[NullableContext(1)]
	IFinalBattleCombatInfo Clone();
}
