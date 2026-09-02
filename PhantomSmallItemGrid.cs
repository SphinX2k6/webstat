using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A4F RID: 6735
public class PhantomSmallItemGrid : SmallItemGridBase
{
	// Token: 0x17000FCC RID: 4044
	// (get) Token: 0x0600C0A0 RID: 49312 RVA: 0x0032D59A File Offset: 0x0032B79A
	public override ESmallItemGridType Type
	{
		get
		{
			return ESmallItemGridType.Phantom;
		}
	}

	// Token: 0x04005A3A RID: 23098
	public int? MonsterId;

	// Token: 0x04005A3B RID: 23099
	public int? PhantomId;

	// Token: 0x04005A3C RID: 23100
	public bool? IsLockVisible;

	// Token: 0x04005A3D RID: 23101
	public bool? IsLockVisibleBlack;

	// Token: 0x04005A3E RID: 23102
	public bool? IsReceivableVisible;

	// Token: 0x04005A3F RID: 23103
	public bool? IsReceivedVisible;

	// Token: 0x04005A40 RID: 23104
	public bool? IsNewVisible;

	// Token: 0x04005A41 RID: 23105
	public bool? IsNotFoundVisible;

	// Token: 0x04005A42 RID: 23106
	public bool? IsSelectedFlag;

	// Token: 0x04005A43 RID: 23107
	public bool? IconHidden;

	// Token: 0x04005A44 RID: 23108
	public int? VisionRoleHeadInfo;

	// Token: 0x04005A45 RID: 23109
	public int? FetterGroupId;

	// Token: 0x04005A46 RID: 23110
	public bool? IsPhantomLock;

	// Token: 0x04005A47 RID: 23111
	public bool? IsPhantomDeprecate;

	// Token: 0x04005A48 RID: 23112
	[Nullable(2)]
	public SmallItemMultiPlayer MultiPlayer;
}
