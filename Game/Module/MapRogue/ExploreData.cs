using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005906 RID: 22790
	[NullableContext(1)]
	[Nullable(0)]
	public class ExploreData : IExploreData
	{
		// Token: 0x170093D5 RID: 37845
		// (get) Token: 0x06039D3B RID: 236859 RVA: 0x00EA4B99 File Offset: 0x00EA2D99
		// (set) Token: 0x06039D3C RID: 236860 RVA: 0x00EA4BA1 File Offset: 0x00EA2DA1
		public string TitleId { get; set; }

		// Token: 0x170093D6 RID: 37846
		// (get) Token: 0x06039D3D RID: 236861 RVA: 0x00EA4BAA File Offset: 0x00EA2DAA
		// (set) Token: 0x06039D3E RID: 236862 RVA: 0x00EA4BB2 File Offset: 0x00EA2DB2
		public string ValueTxt { get; set; }
	}
}
