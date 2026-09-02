using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020024B1 RID: 9393
[NullableContext(1)]
public interface IPhantomInteractGridData
{
	// Token: 0x170016F7 RID: 5879
	// (get) Token: 0x060123A0 RID: 74656
	int MonsterId { get; }

	// Token: 0x170016F8 RID: 5880
	// (get) Token: 0x060123A1 RID: 74657
	int MonsterInfoId { get; }

	// Token: 0x170016F9 RID: 5881
	// (get) Token: 0x060123A2 RID: 74658
	List<int> SkinIds { get; }

	// Token: 0x170016FA RID: 5882
	// (get) Token: 0x060123A3 RID: 74659
	int EquippedSkin { get; }

	// Token: 0x170016FB RID: 5883
	// (get) Token: 0x060123A4 RID: 74660
	bool IsSpecial { get; }

	// Token: 0x170016FC RID: 5884
	// (get) Token: 0x060123A5 RID: 74661
	bool HasSkin { get; }

	// Token: 0x170016FD RID: 5885
	// (get) Token: 0x060123A6 RID: 74662
	int Cost { get; }

	// Token: 0x170016FE RID: 5886
	// (get) Token: 0x060123A7 RID: 74663
	List<int> InteractAreaList { get; }

	// Token: 0x170016FF RID: 5887
	// (get) Token: 0x060123A8 RID: 74664
	bool IsUnlocked { get; }

	// Token: 0x17001700 RID: 5888
	// (get) Token: 0x060123A9 RID: 74665
	[Nullable(2)]
	string Name { [NullableContext(2)] get; }

	// Token: 0x17001701 RID: 5889
	// (get) Token: 0x060123AA RID: 74666
	int InSlotIndex { get; }

	// Token: 0x17001702 RID: 5890
	// (get) Token: 0x060123AB RID: 74667
	[Nullable(2)]
	string IconPath { [NullableContext(2)] get; }

	// Token: 0x17001703 RID: 5891
	// (get) Token: 0x060123AC RID: 74668
	int GetWayConfigId { get; }

	// Token: 0x17001704 RID: 5892
	// (get) Token: 0x060123AD RID: 74669
	int SortId { get; }
}
