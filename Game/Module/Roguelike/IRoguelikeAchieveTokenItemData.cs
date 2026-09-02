using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005127 RID: 20775
	[NullableContext(1)]
	public interface IRoguelikeAchieveTokenItemData
	{
		// Token: 0x17008C61 RID: 35937
		// (get) Token: 0x060357E1 RID: 219105
		// (set) Token: 0x060357E2 RID: 219106
		RogueGainEntry GainEntry { get; set; }
	}
}
