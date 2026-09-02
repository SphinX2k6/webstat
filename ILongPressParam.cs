using System;

// Token: 0x020024DA RID: 9434
public interface ILongPressParam
{
	// Token: 0x1700174F RID: 5967
	// (get) Token: 0x060124F4 RID: 74996
	// (set) Token: 0x060124F5 RID: 74997
	float BeforeLongPressThreshold { get; set; }

	// Token: 0x17001750 RID: 5968
	// (get) Token: 0x060124F6 RID: 74998
	// (set) Token: 0x060124F7 RID: 74999
	float LongPressThreshold { get; set; }

	// Token: 0x17001751 RID: 5969
	// (get) Token: 0x060124F8 RID: 75000
	// (set) Token: 0x060124F9 RID: 75001
	float InvalidMoveDistance { get; set; }

	// Token: 0x17001752 RID: 5970
	// (get) Token: 0x060124FA RID: 75002
	// (set) Token: 0x060124FB RID: 75003
	float OffsetX { get; set; }

	// Token: 0x17001753 RID: 5971
	// (get) Token: 0x060124FC RID: 75004
	// (set) Token: 0x060124FD RID: 75005
	float OffsetY { get; set; }
}
