using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005576 RID: 21878
	[NullableContext(1)]
	public interface ICardDescriptionData
	{
		// Token: 0x17008F85 RID: 36741
		// (get) Token: 0x06037BEF RID: 228335
		// (set) Token: 0x06037BF0 RID: 228336
		string Description { get; set; }

		// Token: 0x17008F86 RID: 36742
		// (get) Token: 0x06037BF1 RID: 228337
		// (set) Token: 0x06037BF2 RID: 228338
		List<string> DescriptionParams { get; set; }
	}
}
