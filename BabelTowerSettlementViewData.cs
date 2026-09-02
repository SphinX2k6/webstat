using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011F9 RID: 4601
[NullableContext(2)]
[Nullable(0)]
public class BabelTowerSettlementViewData : IBabelTowerSettlementViewData
{
	// Token: 0x17000A86 RID: 2694
	// (get) Token: 0x060079E9 RID: 31209 RVA: 0x001FD02A File Offset: 0x001FB22A
	// (set) Token: 0x060079EA RID: 31210 RVA: 0x001FD032 File Offset: 0x001FB232
	public int LevelId { get; set; }

	// Token: 0x17000A87 RID: 2695
	// (get) Token: 0x060079EB RID: 31211 RVA: 0x001FD03B File Offset: 0x001FB23B
	// (set) Token: 0x060079EC RID: 31212 RVA: 0x001FD043 File Offset: 0x001FB243
	public int StarNum { get; set; }

	// Token: 0x17000A88 RID: 2696
	// (get) Token: 0x060079ED RID: 31213 RVA: 0x001FD04C File Offset: 0x001FB24C
	// (set) Token: 0x060079EE RID: 31214 RVA: 0x001FD054 File Offset: 0x001FB254
	public int PassTime { get; set; }

	// Token: 0x17000A89 RID: 2697
	// (get) Token: 0x060079EF RID: 31215 RVA: 0x001FD05D File Offset: 0x001FB25D
	// (set) Token: 0x060079F0 RID: 31216 RVA: 0x001FD065 File Offset: 0x001FB265
	public long PassDate { get; set; }

	// Token: 0x17000A8A RID: 2698
	// (get) Token: 0x060079F1 RID: 31217 RVA: 0x001FD06E File Offset: 0x001FB26E
	// (set) Token: 0x060079F2 RID: 31218 RVA: 0x001FD076 File Offset: 0x001FB276
	[Nullable(1)]
	public List<int> TeamRoleIdList { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000A8B RID: 2699
	// (get) Token: 0x060079F3 RID: 31219 RVA: 0x001FD07F File Offset: 0x001FB27F
	// (set) Token: 0x060079F4 RID: 31220 RVA: 0x001FD087 File Offset: 0x001FB287
	public List<int> BuffIdList { get; set; }

	// Token: 0x17000A8C RID: 2700
	// (get) Token: 0x060079F5 RID: 31221 RVA: 0x001FD090 File Offset: 0x001FB290
	// (set) Token: 0x060079F6 RID: 31222 RVA: 0x001FD098 File Offset: 0x001FB298
	public List<int> DeTermIdList { get; set; }

	// Token: 0x17000A8D RID: 2701
	// (get) Token: 0x060079F7 RID: 31223 RVA: 0x001FD0A1 File Offset: 0x001FB2A1
	// (set) Token: 0x060079F8 RID: 31224 RVA: 0x001FD0A9 File Offset: 0x001FB2A9
	public int OldLevelRank { get; set; }

	// Token: 0x17000A8E RID: 2702
	// (get) Token: 0x060079F9 RID: 31225 RVA: 0x001FD0B2 File Offset: 0x001FB2B2
	// (set) Token: 0x060079FA RID: 31226 RVA: 0x001FD0BA File Offset: 0x001FB2BA
	public int NewLevelRank { get; set; }

	// Token: 0x17000A8F RID: 2703
	// (get) Token: 0x060079FB RID: 31227 RVA: 0x001FD0C3 File Offset: 0x001FB2C3
	// (set) Token: 0x060079FC RID: 31228 RVA: 0x001FD0CB File Offset: 0x001FB2CB
	public int OldTotalRank { get; set; }

	// Token: 0x17000A90 RID: 2704
	// (get) Token: 0x060079FD RID: 31229 RVA: 0x001FD0D4 File Offset: 0x001FB2D4
	// (set) Token: 0x060079FE RID: 31230 RVA: 0x001FD0DC File Offset: 0x001FB2DC
	public int NewTotalRank { get; set; }
}
