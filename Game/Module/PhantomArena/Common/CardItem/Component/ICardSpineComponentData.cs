using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x02005556 RID: 21846
	[NullableContext(1)]
	public interface ICardSpineComponentData
	{
		// Token: 0x17008F52 RID: 36690
		// (get) Token: 0x06037AC2 RID: 228034
		// (set) Token: 0x06037AC3 RID: 228035
		CardSpineData CardSpineData { get; set; }

		// Token: 0x17008F53 RID: 36691
		// (get) Token: 0x06037AC4 RID: 228036
		// (set) Token: 0x06037AC5 RID: 228037
		bool ShowSpine { get; set; }
	}
}
