using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EE8 RID: 24296
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingLevelDescInfo : IBossPilingLevelDescInfo
	{
		// Token: 0x17009A11 RID: 39441
		// (get) Token: 0x0603D0CD RID: 250061 RVA: 0x00F8117F File Offset: 0x00F7F37F
		// (set) Token: 0x0603D0CE RID: 250062 RVA: 0x00F81187 File Offset: 0x00F7F387
		public bool IsFirstLevel { get; set; }

		// Token: 0x17009A12 RID: 39442
		// (get) Token: 0x0603D0CF RID: 250063 RVA: 0x00F81190 File Offset: 0x00F7F390
		// (set) Token: 0x0603D0D0 RID: 250064 RVA: 0x00F81198 File Offset: 0x00F7F398
		public int LevelId { get; set; }

		// Token: 0x17009A13 RID: 39443
		// (get) Token: 0x0603D0D1 RID: 250065 RVA: 0x00F811A1 File Offset: 0x00F7F3A1
		// (set) Token: 0x0603D0D2 RID: 250066 RVA: 0x00F811A9 File Offset: 0x00F7F3A9
		public string LevelMechanism { get; set; }

		// Token: 0x17009A14 RID: 39444
		// (get) Token: 0x0603D0D3 RID: 250067 RVA: 0x00F811B2 File Offset: 0x00F7F3B2
		// (set) Token: 0x0603D0D4 RID: 250068 RVA: 0x00F811BA File Offset: 0x00F7F3BA
		public string MonsterDesc { get; set; }

		// Token: 0x17009A15 RID: 39445
		// (get) Token: 0x0603D0D5 RID: 250069 RVA: 0x00F811C3 File Offset: 0x00F7F3C3
		// (set) Token: 0x0603D0D6 RID: 250070 RVA: 0x00F811CB File Offset: 0x00F7F3CB
		public string LevelDesc { get; set; }
	}
}
