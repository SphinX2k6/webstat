using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A43 RID: 19011
	[NullableContext(1)]
	[Nullable(0)]
	public class PrepareLoadStruct : IPrepareLoadStruct
	{
		// Token: 0x1700847F RID: 33919
		// (get) Token: 0x06031A9D RID: 203421 RVA: 0x00C5F9B1 File Offset: 0x00C5DBB1
		// (set) Token: 0x06031A9E RID: 203422 RVA: 0x00C5F9B9 File Offset: 0x00C5DBB9
		public string ResourceId { get; set; } = "";

		// Token: 0x17008480 RID: 33920
		// (get) Token: 0x06031A9F RID: 203423 RVA: 0x00C5F9C2 File Offset: 0x00C5DBC2
		// (set) Token: 0x06031AA0 RID: 203424 RVA: 0x00C5F9CA File Offset: 0x00C5DBCA
		public Func<int> CacheCount { get; set; } = () => 0;
	}
}
