using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Comic
{
	// Token: 0x02005E88 RID: 24200
	[NullableContext(1)]
	public interface IComicPanelOpenParam
	{
		// Token: 0x1700996B RID: 39275
		// (get) Token: 0x0603CDB2 RID: 249266
		// (set) Token: 0x0603CDB3 RID: 249267
		int ComicConfigId { get; set; }

		// Token: 0x1700996C RID: 39276
		// (get) Token: 0x0603CDB4 RID: 249268
		// (set) Token: 0x0603CDB5 RID: 249269
		Action OnSkip { get; set; }

		// Token: 0x1700996D RID: 39277
		// (get) Token: 0x0603CDB6 RID: 249270
		// (set) Token: 0x0603CDB7 RID: 249271
		Action OnComplete { get; set; }
	}
}
