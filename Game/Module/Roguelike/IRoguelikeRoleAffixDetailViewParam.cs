using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200510E RID: 20750
	[NullableContext(1)]
	public interface IRoguelikeRoleAffixDetailViewParam
	{
		// Token: 0x17008C51 RID: 35921
		// (get) Token: 0x06035763 RID: 218979
		// (set) Token: 0x06035764 RID: 218980
		int Index { get; set; }

		// Token: 0x17008C52 RID: 35922
		// (get) Token: 0x06035765 RID: 218981
		// (set) Token: 0x06035766 RID: 218982
		List<int> AffixIds { get; set; }
	}
}
