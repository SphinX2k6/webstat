using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005128 RID: 20776
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeAchieveTokenItemData : IRoguelikeAchieveTokenItemData
	{
		// Token: 0x17008C62 RID: 35938
		// (get) Token: 0x060357E3 RID: 219107 RVA: 0x00D6DEDC File Offset: 0x00D6C0DC
		// (set) Token: 0x060357E4 RID: 219108 RVA: 0x00D6DEE4 File Offset: 0x00D6C0E4
		public RogueGainEntry GainEntry { get; set; }
	}
}
