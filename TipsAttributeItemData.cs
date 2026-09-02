using System;
using System.Runtime.CompilerServices;

// Token: 0x02001984 RID: 6532
[NullableContext(1)]
[Nullable(0)]
public class TipsAttributeItemData : ITipsAttributeItemData
{
	// Token: 0x17000F45 RID: 3909
	// (get) Token: 0x0600BBCE RID: 48078 RVA: 0x0031DA75 File Offset: 0x0031BC75
	// (set) Token: 0x0600BBCF RID: 48079 RVA: 0x0031DA7D File Offset: 0x0031BC7D
	public int Id { get; set; }

	// Token: 0x17000F46 RID: 3910
	// (get) Token: 0x0600BBD0 RID: 48080 RVA: 0x0031DA86 File Offset: 0x0031BC86
	// (set) Token: 0x0600BBD1 RID: 48081 RVA: 0x0031DA8E File Offset: 0x0031BC8E
	public bool IsMainAttribute { get; set; }

	// Token: 0x17000F47 RID: 3911
	// (get) Token: 0x0600BBD2 RID: 48082 RVA: 0x0031DA97 File Offset: 0x0031BC97
	// (set) Token: 0x0600BBD3 RID: 48083 RVA: 0x0031DA9F File Offset: 0x0031BC9F
	public string Name { get; set; }

	// Token: 0x17000F48 RID: 3912
	// (get) Token: 0x0600BBD4 RID: 48084 RVA: 0x0031DAA8 File Offset: 0x0031BCA8
	// (set) Token: 0x0600BBD5 RID: 48085 RVA: 0x0031DAB0 File Offset: 0x0031BCB0
	public string IconPath { get; set; }

	// Token: 0x17000F49 RID: 3913
	// (get) Token: 0x0600BBD6 RID: 48086 RVA: 0x0031DAB9 File Offset: 0x0031BCB9
	// (set) Token: 0x0600BBD7 RID: 48087 RVA: 0x0031DAC1 File Offset: 0x0031BCC1
	public double Value { get; set; }

	// Token: 0x17000F4A RID: 3914
	// (get) Token: 0x0600BBD8 RID: 48088 RVA: 0x0031DACA File Offset: 0x0031BCCA
	// (set) Token: 0x0600BBD9 RID: 48089 RVA: 0x0031DAD2 File Offset: 0x0031BCD2
	public bool IsRatio { get; set; }
}
