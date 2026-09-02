using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roulette.View
{
	// Token: 0x02005013 RID: 20499
	[NullableContext(2)]
	[Nullable(0)]
	public class ItemRefreshData
	{
		// Token: 0x17008ACB RID: 35531
		// (get) Token: 0x06034D56 RID: 216406 RVA: 0x00D43D41 File Offset: 0x00D41F41
		// (set) Token: 0x06034D57 RID: 216407 RVA: 0x00D43D49 File Offset: 0x00D41F49
		public int ItemId { get; set; }

		// Token: 0x17008ACC RID: 35532
		// (get) Token: 0x06034D58 RID: 216408 RVA: 0x00D43D52 File Offset: 0x00D41F52
		// (set) Token: 0x06034D59 RID: 216409 RVA: 0x00D43D5A File Offset: 0x00D41F5A
		public bool NeedLock { get; set; }

		// Token: 0x17008ACD RID: 35533
		// (get) Token: 0x06034D5A RID: 216410 RVA: 0x00D43D63 File Offset: 0x00D41F63
		// (set) Token: 0x06034D5B RID: 216411 RVA: 0x00D43D6B File Offset: 0x00D41F6B
		public string Text { get; set; }
	}
}
