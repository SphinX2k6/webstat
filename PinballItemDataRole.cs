using System;
using System.Runtime.CompilerServices;

// Token: 0x020014DA RID: 5338
[NullableContext(2)]
[Nullable(0)]
public class PinballItemDataRole : IPinballItemDataRole
{
	// Token: 0x17000CCC RID: 3276
	// (get) Token: 0x06009548 RID: 38216 RVA: 0x00270863 File Offset: 0x0026EA63
	// (set) Token: 0x06009549 RID: 38217 RVA: 0x0027086B File Offset: 0x0026EA6B
	public EPinballItemType Type { get; set; }

	// Token: 0x17000CCD RID: 3277
	// (get) Token: 0x0600954A RID: 38218 RVA: 0x00270874 File Offset: 0x0026EA74
	// (set) Token: 0x0600954B RID: 38219 RVA: 0x0027087C File Offset: 0x0026EA7C
	public int Id { get; set; }

	// Token: 0x17000CCE RID: 3278
	// (get) Token: 0x0600954C RID: 38220 RVA: 0x00270885 File Offset: 0x0026EA85
	// (set) Token: 0x0600954D RID: 38221 RVA: 0x0027088D File Offset: 0x0026EA8D
	public bool? IsRecommend { get; set; }

	// Token: 0x17000CCF RID: 3279
	// (get) Token: 0x0600954E RID: 38222 RVA: 0x00270896 File Offset: 0x0026EA96
	// (set) Token: 0x0600954F RID: 38223 RVA: 0x0027089E File Offset: 0x0026EA9E
	public int? BdId { get; set; }

	// Token: 0x17000CD0 RID: 3280
	// (get) Token: 0x06009550 RID: 38224 RVA: 0x002708A7 File Offset: 0x0026EAA7
	// (set) Token: 0x06009551 RID: 38225 RVA: 0x002708AF File Offset: 0x0026EAAF
	public bool? IsLocked { get; set; }

	// Token: 0x17000CD1 RID: 3281
	// (get) Token: 0x06009552 RID: 38226 RVA: 0x002708B8 File Offset: 0x0026EAB8
	// (set) Token: 0x06009553 RID: 38227 RVA: 0x002708C0 File Offset: 0x0026EAC0
	public bool? IsUnavailable { get; set; }

	// Token: 0x17000CD2 RID: 3282
	// (get) Token: 0x06009554 RID: 38228 RVA: 0x002708C9 File Offset: 0x0026EAC9
	// (set) Token: 0x06009555 RID: 38229 RVA: 0x002708D1 File Offset: 0x0026EAD1
	public TableTextArgNew BottomText { get; set; }

	// Token: 0x17000CD3 RID: 3283
	// (get) Token: 0x06009556 RID: 38230 RVA: 0x002708DA File Offset: 0x0026EADA
	// (set) Token: 0x06009557 RID: 38231 RVA: 0x002708E2 File Offset: 0x0026EAE2
	public string BottomPlainText { get; set; }

	// Token: 0x17000CD4 RID: 3284
	// (get) Token: 0x06009558 RID: 38232 RVA: 0x002708EB File Offset: 0x0026EAEB
	// (set) Token: 0x06009559 RID: 38233 RVA: 0x002708F3 File Offset: 0x0026EAF3
	public int? ClassId { get; set; }
}
