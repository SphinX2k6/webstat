using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x02005248 RID: 21064
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueBattleRoleAffixDetailOpenParam : IRogueBattleRoleAffixDetailOpenParam
	{
		// Token: 0x17008CC6 RID: 36038
		// (get) Token: 0x06035EF8 RID: 220920 RVA: 0x00D92069 File Offset: 0x00D90269
		// (set) Token: 0x06035EF9 RID: 220921 RVA: 0x00D92071 File Offset: 0x00D90271
		public int Index { get; set; }

		// Token: 0x17008CC7 RID: 36039
		// (get) Token: 0x06035EFA RID: 220922 RVA: 0x00D9207A File Offset: 0x00D9027A
		// (set) Token: 0x06035EFB RID: 220923 RVA: 0x00D92082 File Offset: 0x00D90282
		public List<int> AffixIds { get; set; } = new List<int>();

		// Token: 0x17008CC8 RID: 36040
		// (get) Token: 0x06035EFC RID: 220924 RVA: 0x00D9208B File Offset: 0x00D9028B
		// (set) Token: 0x06035EFD RID: 220925 RVA: 0x00D92093 File Offset: 0x00D90293
		public int RoleId { get; set; }
	}
}
