using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005168 RID: 20840
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomSelectItemContextData : IPhantomSelectItemContextData
	{
		// Token: 0x17008C81 RID: 35969
		// (get) Token: 0x06035A0C RID: 219660 RVA: 0x00D78735 File Offset: 0x00D76935
		// (set) Token: 0x06035A0D RID: 219661 RVA: 0x00D7873D File Offset: 0x00D7693D
		public RogueGainEntry RogueGainEntry { get; set; }

		// Token: 0x17008C82 RID: 35970
		// (get) Token: 0x06035A0E RID: 219662 RVA: 0x00D78746 File Offset: 0x00D76946
		// (set) Token: 0x06035A0F RID: 219663 RVA: 0x00D7874E File Offset: 0x00D7694E
		public RoguelikeInfo RoguelikeInfo { get; set; }
	}
}
