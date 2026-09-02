using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002E72 RID: 11890
[NullableContext(1)]
[Nullable(0)]
public class AddBuffParam
{
	// Token: 0x170020E8 RID: 8424
	// (get) Token: 0x06018718 RID: 100120 RVA: 0x006DA1B3 File Offset: 0x006D83B3
	// (set) Token: 0x06018719 RID: 100121 RVA: 0x006DA1BB File Offset: 0x006D83BB
	public long InstigatorId { get; set; }

	// Token: 0x170020E9 RID: 8425
	// (get) Token: 0x0601871A RID: 100122 RVA: 0x006DA1C4 File Offset: 0x006D83C4
	// (set) Token: 0x0601871B RID: 100123 RVA: 0x006DA1CC File Offset: 0x006D83CC
	public int? Level { get; set; }

	// Token: 0x170020EA RID: 8426
	// (get) Token: 0x0601871C RID: 100124 RVA: 0x006DA1D5 File Offset: 0x006D83D5
	// (set) Token: 0x0601871D RID: 100125 RVA: 0x006DA1DD File Offset: 0x006D83DD
	public int? OuterStackCount { get; set; }

	// Token: 0x170020EB RID: 8427
	// (get) Token: 0x0601871E RID: 100126 RVA: 0x006DA1E6 File Offset: 0x006D83E6
	// (set) Token: 0x0601871F RID: 100127 RVA: 0x006DA1EE File Offset: 0x006D83EE
	public ApplyGEType? ApplyType { get; set; }

	// Token: 0x170020EC RID: 8428
	// (get) Token: 0x06018720 RID: 100128 RVA: 0x006DA1F7 File Offset: 0x006D83F7
	// (set) Token: 0x06018721 RID: 100129 RVA: 0x006DA1FF File Offset: 0x006D83FF
	public long? PreMessageId { get; set; }

	// Token: 0x170020ED RID: 8429
	// (get) Token: 0x06018722 RID: 100130 RVA: 0x006DA208 File Offset: 0x006D8408
	// (set) Token: 0x06018723 RID: 100131 RVA: 0x006DA210 File Offset: 0x006D8410
	public long? MessageId { get; set; }

	// Token: 0x170020EE RID: 8430
	// (get) Token: 0x06018724 RID: 100132 RVA: 0x006DA219 File Offset: 0x006D8419
	// (set) Token: 0x06018725 RID: 100133 RVA: 0x006DA221 File Offset: 0x006D8421
	public float? Duration { get; set; }

	// Token: 0x170020EF RID: 8431
	// (get) Token: 0x06018726 RID: 100134 RVA: 0x006DA22A File Offset: 0x006D842A
	// (set) Token: 0x06018727 RID: 100135 RVA: 0x006DA232 File Offset: 0x006D8432
	public int? ServerId { get; set; }

	// Token: 0x170020F0 RID: 8432
	// (get) Token: 0x06018728 RID: 100136 RVA: 0x006DA23B File Offset: 0x006D843B
	// (set) Token: 0x06018729 RID: 100137 RVA: 0x006DA243 File Offset: 0x006D8443
	public bool? IsIterable { get; set; }

	// Token: 0x170020F1 RID: 8433
	// (get) Token: 0x0601872A RID: 100138 RVA: 0x006DA24C File Offset: 0x006D844C
	// (set) Token: 0x0601872B RID: 100139 RVA: 0x006DA254 File Offset: 0x006D8454
	public bool? IsServerOrder { get; set; }

	// Token: 0x170020F2 RID: 8434
	// (get) Token: 0x0601872C RID: 100140 RVA: 0x006DA25D File Offset: 0x006D845D
	// (set) Token: 0x0601872D RID: 100141 RVA: 0x006DA265 File Offset: 0x006D8465
	public string Reason { get; set; } = string.Empty;

	// Token: 0x170020F3 RID: 8435
	// (get) Token: 0x0601872E RID: 100142 RVA: 0x006DA26E File Offset: 0x006D846E
	// (set) Token: 0x0601872F RID: 100143 RVA: 0x006DA276 File Offset: 0x006D8476
	public long? BulletMessageId { get; set; }

	// Token: 0x170020F4 RID: 8436
	// (get) Token: 0x06018730 RID: 100144 RVA: 0x006DA27F File Offset: 0x006D847F
	// (set) Token: 0x06018731 RID: 100145 RVA: 0x006DA287 File Offset: 0x006D8487
	public bool? BornBuff { get; set; }

	// Token: 0x170020F5 RID: 8437
	// (get) Token: 0x06018732 RID: 100146 RVA: 0x006DA290 File Offset: 0x006D8490
	// (set) Token: 0x06018733 RID: 100147 RVA: 0x006DA298 File Offset: 0x006D8498
	public float? RemainDuration { get; set; }

	// Token: 0x170020F6 RID: 8438
	// (get) Token: 0x06018734 RID: 100148 RVA: 0x006DA2A1 File Offset: 0x006D84A1
	// (set) Token: 0x06018735 RID: 100149 RVA: 0x006DA2A9 File Offset: 0x006D84A9
	public bool? IsActive { get; set; }
}
