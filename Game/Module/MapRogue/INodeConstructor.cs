using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005922 RID: 22818
	[NullableContext(1)]
	public interface INodeConstructor
	{
		// Token: 0x17009428 RID: 37928
		// (get) Token: 0x06039E92 RID: 237202
		// (set) Token: 0x06039E93 RID: 237203
		int GridId { get; set; }

		// Token: 0x17009429 RID: 37929
		// (get) Token: 0x06039E94 RID: 237204
		// (set) Token: 0x06039E95 RID: 237205
		IPos Position { get; set; }

		// Token: 0x1700942A RID: 37930
		// (get) Token: 0x06039E96 RID: 237206
		// (set) Token: 0x06039E97 RID: 237207
		int Cost { get; set; }

		// Token: 0x1700942B RID: 37931
		// (get) Token: 0x06039E98 RID: 237208
		// (set) Token: 0x06039E99 RID: 237209
		bool Walkable { get; set; }
	}
}
