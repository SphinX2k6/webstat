using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200510F RID: 20751
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeRoleAffixDetailViewParam : IRoguelikeRoleAffixDetailViewParam
	{
		// Token: 0x17008C53 RID: 35923
		// (get) Token: 0x06035767 RID: 218983 RVA: 0x00D6B354 File Offset: 0x00D69554
		// (set) Token: 0x06035768 RID: 218984 RVA: 0x00D6B35C File Offset: 0x00D6955C
		public int Index { get; set; }

		// Token: 0x17008C54 RID: 35924
		// (get) Token: 0x06035769 RID: 218985 RVA: 0x00D6B365 File Offset: 0x00D69565
		// (set) Token: 0x0603576A RID: 218986 RVA: 0x00D6B36D File Offset: 0x00D6956D
		public List<int> AffixIds { get; set; }
	}
}
