using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005954 RID: 22868
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueTipsData : IRogueTipsData
	{
		// Token: 0x1700945B RID: 37979
		// (get) Token: 0x06039F94 RID: 237460 RVA: 0x00EABF8A File Offset: 0x00EAA18A
		// (set) Token: 0x06039F95 RID: 237461 RVA: 0x00EABF92 File Offset: 0x00EAA192
		public string TextId { get; set; }

		// Token: 0x1700945C RID: 37980
		// (get) Token: 0x06039F96 RID: 237462 RVA: 0x00EABF9B File Offset: 0x00EAA19B
		// (set) Token: 0x06039F97 RID: 237463 RVA: 0x00EABFA3 File Offset: 0x00EAA1A3
		public string[] TextParam { get; set; }

		// Token: 0x1700945D RID: 37981
		// (get) Token: 0x06039F98 RID: 237464 RVA: 0x00EABFAC File Offset: 0x00EAA1AC
		// (set) Token: 0x06039F99 RID: 237465 RVA: 0x00EABFB4 File Offset: 0x00EAA1B4
		[Nullable(2)]
		public Action FinishCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
