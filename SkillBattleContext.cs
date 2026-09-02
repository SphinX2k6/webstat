using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200312A RID: 12586
[NullableContext(1)]
[Nullable(0)]
public class SkillBattleContext : ISkillBattleContext
{
	// Token: 0x1700235F RID: 9055
	// (get) Token: 0x0601A10B RID: 106763 RVA: 0x007A3F1E File Offset: 0x007A211E
	// (set) Token: 0x0601A10C RID: 106764 RVA: 0x007A3F26 File Offset: 0x007A2126
	public int VisionId { get; set; }

	// Token: 0x17002360 RID: 9056
	// (get) Token: 0x0601A10D RID: 106765 RVA: 0x007A3F2F File Offset: 0x007A212F
	// (set) Token: 0x0601A10E RID: 106766 RVA: 0x007A3F37 File Offset: 0x007A2137
	public List<string> BattleFlags { get; set; } = new List<string>();
}
