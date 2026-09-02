using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02000FC3 RID: 4035
[NullableContext(1)]
[Nullable(0)]
public class FormationAttributeConfig : IFormationAttributeConfig
{
	// Token: 0x17000824 RID: 2084
	// (get) Token: 0x06006776 RID: 26486 RVA: 0x001AFD40 File Offset: 0x001ADF40
	// (set) Token: 0x06006777 RID: 26487 RVA: 0x001AFD48 File Offset: 0x001ADF48
	public FormationProperty? RawConfig { get; set; }

	// Token: 0x17000825 RID: 2085
	// (get) Token: 0x06006778 RID: 26488 RVA: 0x001AFD51 File Offset: 0x001ADF51
	// (set) Token: 0x06006779 RID: 26489 RVA: 0x001AFD59 File Offset: 0x001ADF59
	public int?[] ForbidIncreaseTags { get; set; }

	// Token: 0x17000826 RID: 2086
	// (get) Token: 0x0600677A RID: 26490 RVA: 0x001AFD62 File Offset: 0x001ADF62
	// (set) Token: 0x0600677B RID: 26491 RVA: 0x001AFD6A File Offset: 0x001ADF6A
	public int?[] ForbidDecreaseTags { get; set; }
}
