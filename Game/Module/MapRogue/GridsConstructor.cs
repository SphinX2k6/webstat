using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005920 RID: 22816
	[NullableContext(1)]
	[Nullable(0)]
	public class GridsConstructor : IGridsConstructor
	{
		// Token: 0x17009422 RID: 37922
		// (get) Token: 0x06039E88 RID: 237192 RVA: 0x00EA92F6 File Offset: 0x00EA74F6
		// (set) Token: 0x06039E89 RID: 237193 RVA: 0x00EA92FE File Offset: 0x00EA74FE
		public List<IPathNode> Matrix { get; set; }

		// Token: 0x17009423 RID: 37923
		// (get) Token: 0x06039E8A RID: 237194 RVA: 0x00EA9307 File Offset: 0x00EA7507
		// (set) Token: 0x06039E8B RID: 237195 RVA: 0x00EA930F File Offset: 0x00EA750F
		public int Width { get; set; }

		// Token: 0x17009424 RID: 37924
		// (get) Token: 0x06039E8C RID: 237196 RVA: 0x00EA9318 File Offset: 0x00EA7518
		// (set) Token: 0x06039E8D RID: 237197 RVA: 0x00EA9320 File Offset: 0x00EA7520
		public int Height { get; set; }
	}
}
