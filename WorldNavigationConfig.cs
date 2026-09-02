using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A7B RID: 6779
[NullableContext(1)]
[Nullable(0)]
public class WorldNavigationConfig : IWorldNavigationConfig
{
	// Token: 0x17000FE5 RID: 4069
	// (get) Token: 0x0600C201 RID: 49665 RVA: 0x00331DBC File Offset: 0x0032FFBC
	// (set) Token: 0x0600C202 RID: 49666 RVA: 0x00331DC4 File Offset: 0x0032FFC4
	public Vector SourcePosition { get; set; }

	// Token: 0x17000FE6 RID: 4070
	// (get) Token: 0x0600C203 RID: 49667 RVA: 0x00331DCD File Offset: 0x0032FFCD
	// (set) Token: 0x0600C204 RID: 49668 RVA: 0x00331DD5 File Offset: 0x0032FFD5
	public Vector DestPosition { get; set; }

	// Token: 0x17000FE7 RID: 4071
	// (get) Token: 0x0600C205 RID: 49669 RVA: 0x00331DDE File Offset: 0x0032FFDE
	// (set) Token: 0x0600C206 RID: 49670 RVA: 0x00331DE6 File Offset: 0x0032FFE6
	public int MapId { get; set; }

	// Token: 0x17000FE8 RID: 4072
	// (get) Token: 0x0600C207 RID: 49671 RVA: 0x00331DEF File Offset: 0x0032FFEF
	// (set) Token: 0x0600C208 RID: 49672 RVA: 0x00331DF7 File Offset: 0x0032FFF7
	[Nullable(2)]
	public BaseMoveComponent MoveComponent { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000FE9 RID: 4073
	// (get) Token: 0x0600C209 RID: 49673 RVA: 0x00331E00 File Offset: 0x00330000
	// (set) Token: 0x0600C20A RID: 49674 RVA: 0x00331E08 File Offset: 0x00330008
	public int? DistanceThreshold { get; set; }

	// Token: 0x17000FEA RID: 4074
	// (get) Token: 0x0600C20B RID: 49675 RVA: 0x00331E11 File Offset: 0x00330011
	// (set) Token: 0x0600C20C RID: 49676 RVA: 0x00331E19 File Offset: 0x00330019
	public int? TryFindPathTimes { get; set; }

	// Token: 0x17000FEB RID: 4075
	// (get) Token: 0x0600C20D RID: 49677 RVA: 0x00331E22 File Offset: 0x00330022
	// (set) Token: 0x0600C20E RID: 49678 RVA: 0x00331E2A File Offset: 0x0033002A
	[Nullable(2)]
	public TWorldNavigationCallback Callback { [NullableContext(2)] get; [NullableContext(2)] set; }
}
