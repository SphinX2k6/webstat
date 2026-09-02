using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Kurotato.View.PopupItemDetail
{
	// Token: 0x02005A8E RID: 23182
	[NullableContext(1)]
	[Nullable(0)]
	public class InfoItemData : IInfoItemData
	{
		// Token: 0x17009597 RID: 38295
		// (get) Token: 0x0603AA86 RID: 240262 RVA: 0x00EDD004 File Offset: 0x00EDB204
		// (set) Token: 0x0603AA87 RID: 240263 RVA: 0x00EDD00C File Offset: 0x00EDB20C
		public int Level { get; set; }

		// Token: 0x17009598 RID: 38296
		// (get) Token: 0x0603AA88 RID: 240264 RVA: 0x00EDD015 File Offset: 0x00EDB215
		// (set) Token: 0x0603AA89 RID: 240265 RVA: 0x00EDD01D File Offset: 0x00EDB21D
		public string Description { get; set; } = string.Empty;

		// Token: 0x17009599 RID: 38297
		// (get) Token: 0x0603AA8A RID: 240266 RVA: 0x00EDD026 File Offset: 0x00EDB226
		// (set) Token: 0x0603AA8B RID: 240267 RVA: 0x00EDD02E File Offset: 0x00EDB22E
		public int BuildLevel { get; set; }

		// Token: 0x1700959A RID: 38298
		// (get) Token: 0x0603AA8C RID: 240268 RVA: 0x00EDD037 File Offset: 0x00EDB237
		// (set) Token: 0x0603AA8D RID: 240269 RVA: 0x00EDD03F File Offset: 0x00EDB23F
		public bool IsArrowLevel { get; set; }
	}
}
