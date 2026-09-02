using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardDetail
{
	// Token: 0x0200557C RID: 21884
	[NullableContext(1)]
	public interface ICardDetailConditionOutData
	{
		// Token: 0x17008F8D RID: 36749
		// (get) Token: 0x06037C1B RID: 228379
		// (set) Token: 0x06037C1C RID: 228380
		int CurrentProgress { get; set; }

		// Token: 0x17008F8E RID: 36750
		// (get) Token: 0x06037C1D RID: 228381
		// (set) Token: 0x06037C1E RID: 228382
		int MaxProgress { get; set; }

		// Token: 0x17008F8F RID: 36751
		// (get) Token: 0x06037C1F RID: 228383
		// (set) Token: 0x06037C20 RID: 228384
		string Icon { get; set; }

		// Token: 0x17008F90 RID: 36752
		// (get) Token: 0x06037C21 RID: 228385
		// (set) Token: 0x06037C22 RID: 228386
		string ConditionDesc { get; set; }

		// Token: 0x17008F91 RID: 36753
		// (get) Token: 0x06037C23 RID: 228387
		// (set) Token: 0x06037C24 RID: 228388
		string Title { get; set; }

		// Token: 0x17008F92 RID: 36754
		// (get) Token: 0x06037C25 RID: 228389
		// (set) Token: 0x06037C26 RID: 228390
		bool? TitleChangeColor { get; set; }
	}
}
