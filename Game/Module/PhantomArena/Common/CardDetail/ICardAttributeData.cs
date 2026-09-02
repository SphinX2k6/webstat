using System;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x02005574 RID: 21876
	public interface ICardAttributeData
	{
		// Token: 0x17008F7F RID: 36735
		// (get) Token: 0x06037BE2 RID: 228322
		// (set) Token: 0x06037BE3 RID: 228323
		int Cost { get; set; }

		// Token: 0x17008F80 RID: 36736
		// (get) Token: 0x06037BE4 RID: 228324
		// (set) Token: 0x06037BE5 RID: 228325
		int Attack { get; set; }

		// Token: 0x17008F81 RID: 36737
		// (get) Token: 0x06037BE6 RID: 228326
		// (set) Token: 0x06037BE7 RID: 228327
		int Life { get; set; }
	}
}
