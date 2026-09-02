using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005251 RID: 21073
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleEnvironmentInfo : IRogueBattleEnvironmentInfo
	{
		// Token: 0x17008CDE RID: 36062
		// (get) Token: 0x06035F2C RID: 220972 RVA: 0x00D92176 File Offset: 0x00D90376
		// (set) Token: 0x06035F2D RID: 220973 RVA: 0x00D9217E File Offset: 0x00D9037E
		public string Icon { get; set; } = string.Empty;

		// Token: 0x17008CDF RID: 36063
		// (get) Token: 0x06035F2E RID: 220974 RVA: 0x00D92187 File Offset: 0x00D90387
		// (set) Token: 0x06035F2F RID: 220975 RVA: 0x00D9218F File Offset: 0x00D9038F
		public string TextId { get; set; } = string.Empty;

		// Token: 0x17008CE0 RID: 36064
		// (get) Token: 0x06035F30 RID: 220976 RVA: 0x00D92198 File Offset: 0x00D90398
		// (set) Token: 0x06035F31 RID: 220977 RVA: 0x00D921A0 File Offset: 0x00D903A0
		public List<string> Param { get; set; } = new List<string>();
	}
}
