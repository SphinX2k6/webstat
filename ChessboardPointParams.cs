using System;
using System.Runtime.CompilerServices;

// Token: 0x02001289 RID: 4745
[NullableContext(1)]
[Nullable(0)]
public class ChessboardPointParams : IChessboardPointParams
{
	// Token: 0x17000ABD RID: 2749
	// (get) Token: 0x06007F0E RID: 32526 RVA: 0x0021A01E File Offset: 0x0021821E
	// (set) Token: 0x06007F0F RID: 32527 RVA: 0x0021A026 File Offset: 0x00218226
	public int Id { get; set; }

	// Token: 0x17000ABE RID: 2750
	// (get) Token: 0x06007F10 RID: 32528 RVA: 0x0021A02F File Offset: 0x0021822F
	// (set) Token: 0x06007F11 RID: 32529 RVA: 0x0021A037 File Offset: 0x00218237
	public Vector Location { get; set; }

	// Token: 0x17000ABF RID: 2751
	// (get) Token: 0x06007F12 RID: 32530 RVA: 0x0021A040 File Offset: 0x00218240
	// (set) Token: 0x06007F13 RID: 32531 RVA: 0x0021A048 File Offset: 0x00218248
	public Rotator Rotation { get; set; }

	// Token: 0x17000AC0 RID: 2752
	// (get) Token: 0x06007F14 RID: 32532 RVA: 0x0021A051 File Offset: 0x00218251
	// (set) Token: 0x06007F15 RID: 32533 RVA: 0x0021A059 File Offset: 0x00218259
	[Nullable(2)]
	public Rotator BackwardRotation { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000AC1 RID: 2753
	// (get) Token: 0x06007F16 RID: 32534 RVA: 0x0021A062 File Offset: 0x00218262
	// (set) Token: 0x06007F17 RID: 32535 RVA: 0x0021A06A File Offset: 0x0021826A
	public int SortIndex { get; set; }
}
