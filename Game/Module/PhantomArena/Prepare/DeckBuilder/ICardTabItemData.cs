using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.DeckBuilder
{
	// Token: 0x020054FF RID: 21759
	[NullableContext(1)]
	public interface ICardTabItemData
	{
		// Token: 0x17008F0B RID: 36619
		// (get) Token: 0x06037779 RID: 227193
		// (set) Token: 0x0603777A RID: 227194
		ECardTabType TabType { get; set; }

		// Token: 0x17008F0C RID: 36620
		// (get) Token: 0x0603777B RID: 227195
		// (set) Token: 0x0603777C RID: 227196
		ECardElement? ElementConfigId { get; set; }

		// Token: 0x17008F0D RID: 36621
		// (get) Token: 0x0603777D RID: 227197
		// (set) Token: 0x0603777E RID: 227198
		string TabTexturePath { get; set; }

		// Token: 0x17008F0E RID: 36622
		// (get) Token: 0x0603777F RID: 227199
		// (set) Token: 0x06037780 RID: 227200
		string TabElementColor { get; set; }

		// Token: 0x17008F0F RID: 36623
		// (get) Token: 0x06037781 RID: 227201
		// (set) Token: 0x06037782 RID: 227202
		bool ShowRedDot { get; set; }

		// Token: 0x17008F10 RID: 36624
		// (get) Token: 0x06037783 RID: 227203
		// (set) Token: 0x06037784 RID: 227204
		bool IsDisable { get; set; }

		// Token: 0x17008F11 RID: 36625
		// (get) Token: 0x06037785 RID: 227205
		// (set) Token: 0x06037786 RID: 227206
		bool IsArrivedMax { get; set; }
	}
}
