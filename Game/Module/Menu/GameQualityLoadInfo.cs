using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005765 RID: 22373
	[NullableContext(1)]
	[Nullable(0)]
	public class GameQualityLoadInfo : IGameQualityLoadInfo
	{
		// Token: 0x1700918E RID: 37262
		// (get) Token: 0x06038EF4 RID: 233204 RVA: 0x00E6C931 File Offset: 0x00E6AB31
		// (set) Token: 0x06038EF5 RID: 233205 RVA: 0x00E6C939 File Offset: 0x00E6AB39
		public string Desc { get; set; } = "";

		// Token: 0x1700918F RID: 37263
		// (get) Token: 0x06038EF6 RID: 233206 RVA: 0x00E6C942 File Offset: 0x00E6AB42
		// (set) Token: 0x06038EF7 RID: 233207 RVA: 0x00E6C94A File Offset: 0x00E6AB4A
		public int Percentage { get; set; }

		// Token: 0x17009190 RID: 37264
		// (get) Token: 0x06038EF8 RID: 233208 RVA: 0x00E6C953 File Offset: 0x00E6AB53
		// (set) Token: 0x06038EF9 RID: 233209 RVA: 0x00E6C95B File Offset: 0x00E6AB5B
		public string BarColor { get; set; } = "";
	}
}
