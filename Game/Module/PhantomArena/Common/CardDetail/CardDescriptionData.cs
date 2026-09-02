using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005577 RID: 21879
	[NullableContext(1)]
	[Nullable(0)]
	public class CardDescriptionData : ICardDescriptionData
	{
		// Token: 0x17008F87 RID: 36743
		// (get) Token: 0x06037BF3 RID: 228339 RVA: 0x00E21D1B File Offset: 0x00E1FF1B
		// (set) Token: 0x06037BF4 RID: 228340 RVA: 0x00E21D23 File Offset: 0x00E1FF23
		public string Description { get; set; }

		// Token: 0x17008F88 RID: 36744
		// (get) Token: 0x06037BF5 RID: 228341 RVA: 0x00E21D2C File Offset: 0x00E1FF2C
		// (set) Token: 0x06037BF6 RID: 228342 RVA: 0x00E21D34 File Offset: 0x00E1FF34
		public List<string> DescriptionParams { get; set; }
	}
}
