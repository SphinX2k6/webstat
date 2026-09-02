using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005923 RID: 22819
	[NullableContext(1)]
	[Nullable(0)]
	public class NodeConstructor : INodeConstructor
	{
		// Token: 0x1700942C RID: 37932
		// (get) Token: 0x06039E9A RID: 237210 RVA: 0x00EA9331 File Offset: 0x00EA7531
		// (set) Token: 0x06039E9B RID: 237211 RVA: 0x00EA9339 File Offset: 0x00EA7539
		public int GridId { get; set; }

		// Token: 0x1700942D RID: 37933
		// (get) Token: 0x06039E9C RID: 237212 RVA: 0x00EA9342 File Offset: 0x00EA7542
		// (set) Token: 0x06039E9D RID: 237213 RVA: 0x00EA934A File Offset: 0x00EA754A
		public IPos Position { get; set; }

		// Token: 0x1700942E RID: 37934
		// (get) Token: 0x06039E9E RID: 237214 RVA: 0x00EA9353 File Offset: 0x00EA7553
		// (set) Token: 0x06039E9F RID: 237215 RVA: 0x00EA935B File Offset: 0x00EA755B
		public int Cost { get; set; }

		// Token: 0x1700942F RID: 37935
		// (get) Token: 0x06039EA0 RID: 237216 RVA: 0x00EA9364 File Offset: 0x00EA7564
		// (set) Token: 0x06039EA1 RID: 237217 RVA: 0x00EA936C File Offset: 0x00EA756C
		public bool Walkable { get; set; }
	}
}
