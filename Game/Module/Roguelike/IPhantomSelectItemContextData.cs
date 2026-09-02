using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005167 RID: 20839
	[NullableContext(1)]
	public interface IPhantomSelectItemContextData
	{
		// Token: 0x17008C7F RID: 35967
		// (get) Token: 0x06035A08 RID: 219656
		// (set) Token: 0x06035A09 RID: 219657
		RogueGainEntry RogueGainEntry { get; set; }

		// Token: 0x17008C80 RID: 35968
		// (get) Token: 0x06035A0A RID: 219658
		// (set) Token: 0x06035A0B RID: 219659
		RoguelikeInfo RoguelikeInfo { get; set; }
	}
}
