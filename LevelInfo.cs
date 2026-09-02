using System;
using System.Runtime.CompilerServices;

// Token: 0x0200288E RID: 10382
[NullableContext(2)]
[Nullable(0)]
public class LevelInfo : ILevelInfo
{
	// Token: 0x17001AD7 RID: 6871
	// (get) Token: 0x060148D9 RID: 84185 RVA: 0x005B2BAB File Offset: 0x005B0DAB
	// (set) Token: 0x060148DA RID: 84186 RVA: 0x005B2BB3 File Offset: 0x005B0DB3
	public int PreUpgradeLv { get; set; }

	// Token: 0x17001AD8 RID: 6872
	// (get) Token: 0x060148DB RID: 84187 RVA: 0x005B2BBC File Offset: 0x005B0DBC
	// (set) Token: 0x060148DC RID: 84188 RVA: 0x005B2BC4 File Offset: 0x005B0DC4
	public int UpgradeLv { get; set; }

	// Token: 0x17001AD9 RID: 6873
	// (get) Token: 0x060148DD RID: 84189 RVA: 0x005B2BCD File Offset: 0x005B0DCD
	// (set) Token: 0x060148DE RID: 84190 RVA: 0x005B2BD5 File Offset: 0x005B0DD5
	public string FormatStringId { get; set; }

	// Token: 0x17001ADA RID: 6874
	// (get) Token: 0x060148DF RID: 84191 RVA: 0x005B2BDE File Offset: 0x005B0DDE
	// (set) Token: 0x060148E0 RID: 84192 RVA: 0x005B2BE6 File Offset: 0x005B0DE6
	public bool? IsMaxLevel { get; set; }
}
