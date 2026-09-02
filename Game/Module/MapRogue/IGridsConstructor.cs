using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200591F RID: 22815
	[NullableContext(1)]
	public interface IGridsConstructor
	{
		// Token: 0x1700941F RID: 37919
		// (get) Token: 0x06039E82 RID: 237186
		// (set) Token: 0x06039E83 RID: 237187
		List<IPathNode> Matrix { get; set; }

		// Token: 0x17009420 RID: 37920
		// (get) Token: 0x06039E84 RID: 237188
		// (set) Token: 0x06039E85 RID: 237189
		int Width { get; set; }

		// Token: 0x17009421 RID: 37921
		// (get) Token: 0x06039E86 RID: 237190
		// (set) Token: 0x06039E87 RID: 237191
		int Height { get; set; }
	}
}
