using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000F6C RID: 3948
[NullableContext(2)]
public interface IPotatoCombatInfo
{
	// Token: 0x17000786 RID: 1926
	// (get) Token: 0x060063B1 RID: 25521
	// (set) Token: 0x060063B2 RID: 25522
	EPotatoEntityType EntityType { get; set; }

	// Token: 0x17000787 RID: 1927
	// (get) Token: 0x060063B3 RID: 25523
	// (set) Token: 0x060063B4 RID: 25524
	int Uid { get; set; }

	// Token: 0x17000788 RID: 1928
	// (get) Token: 0x060063B5 RID: 25525
	// (set) Token: 0x060063B6 RID: 25526
	int OwnerId { get; set; }

	// Token: 0x17000789 RID: 1929
	// (get) Token: 0x060063B7 RID: 25527
	// (set) Token: 0x060063B8 RID: 25528
	int TemplateId { get; set; }

	// Token: 0x1700078A RID: 1930
	// (get) Token: 0x060063B9 RID: 25529
	// (set) Token: 0x060063BA RID: 25530
	int CombatId { get; set; }

	// Token: 0x1700078B RID: 1931
	// (get) Token: 0x060063BB RID: 25531
	// (set) Token: 0x060063BC RID: 25532
	int SubTypeId { get; set; }

	// Token: 0x1700078C RID: 1932
	// (get) Token: 0x060063BD RID: 25533
	// (set) Token: 0x060063BE RID: 25534
	string PrefabPath { get; set; }

	// Token: 0x1700078D RID: 1933
	// (get) Token: 0x060063BF RID: 25535
	// (set) Token: 0x060063C0 RID: 25536
	string AssetPath { get; set; }

	// Token: 0x1700078E RID: 1934
	// (get) Token: 0x060063C1 RID: 25537
	// (set) Token: 0x060063C2 RID: 25538
	int PropertyId { get; set; }

	// Token: 0x1700078F RID: 1935
	// (get) Token: 0x060063C3 RID: 25539
	// (set) Token: 0x060063C4 RID: 25540
	int? SplineId { get; set; }

	// Token: 0x17000790 RID: 1936
	// (get) Token: 0x060063C5 RID: 25541
	// (set) Token: 0x060063C6 RID: 25542
	Dictionary<int, int> BuffIdLayers { get; set; }

	// Token: 0x17000791 RID: 1937
	// (get) Token: 0x060063C7 RID: 25543
	// (set) Token: 0x060063C8 RID: 25544
	Dictionary<int, int> AttributeMap { get; set; }

	// Token: 0x17000792 RID: 1938
	// (get) Token: 0x060063C9 RID: 25545
	// (set) Token: 0x060063CA RID: 25546
	[Nullable(1)]
	Vector Position { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000793 RID: 1939
	// (get) Token: 0x060063CB RID: 25547
	// (set) Token: 0x060063CC RID: 25548
	[Nullable(1)]
	Rotator Rotation { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x060063CD RID: 25549
	[NullableContext(1)]
	void Update(IPotatoCombatInfo other);

	// Token: 0x060063CE RID: 25550
	bool IsValid();

	// Token: 0x060063CF RID: 25551
	void Reset();

	// Token: 0x060063D0 RID: 25552
	void Release();

	// Token: 0x060063D1 RID: 25553
	[NullableContext(1)]
	IPotatoCombatInfo Clone();
}
