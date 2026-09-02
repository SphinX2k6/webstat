using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B2A RID: 19242
	[NullableContext(1)]
	public interface IMapNoteParams
	{
		// Token: 0x170085F6 RID: 34294
		// (get) Token: 0x06032374 RID: 205684
		// (set) Token: 0x06032375 RID: 205685
		EMapNoteId MapNoteId { get; set; }

		// Token: 0x170085F7 RID: 34295
		// (get) Token: 0x06032376 RID: 205686
		// (set) Token: 0x06032377 RID: 205687
		Action<int> ClickCallBack { get; set; }

		// Token: 0x170085F8 RID: 34296
		// (get) Token: 0x06032378 RID: 205688
		// (set) Token: 0x06032379 RID: 205689
		MapNote MapNoteConfig { get; set; }

		// Token: 0x170085F9 RID: 34297
		// (get) Token: 0x0603237A RID: 205690
		// (set) Token: 0x0603237B RID: 205691
		int? MapMarkId { get; set; }

		// Token: 0x170085FA RID: 34298
		// (get) Token: 0x0603237C RID: 205692
		// (set) Token: 0x0603237D RID: 205693
		[Nullable(2)]
		string CustomDesc { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
