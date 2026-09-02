using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FB1 RID: 20401
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffQuestionResultJsonConfig : ISheriffQuestionResultJsonConfig
	{
		// Token: 0x17008A64 RID: 35428
		// (get) Token: 0x06034A44 RID: 215620 RVA: 0x00D348CB File Offset: 0x00D32ACB
		// (set) Token: 0x06034A45 RID: 215621 RVA: 0x00D348D3 File Offset: 0x00D32AD3
		public List<int> ClueCombination { get; set; } = new List<int>();

		// Token: 0x17008A65 RID: 35429
		// (get) Token: 0x06034A46 RID: 215622 RVA: 0x00D348DC File Offset: 0x00D32ADC
		// (set) Token: 0x06034A47 RID: 215623 RVA: 0x00D348E4 File Offset: 0x00D32AE4
		public List<string> ReasoningStateId { get; set; } = new List<string>();

		// Token: 0x17008A66 RID: 35430
		// (get) Token: 0x06034A48 RID: 215624 RVA: 0x00D348ED File Offset: 0x00D32AED
		// (set) Token: 0x06034A49 RID: 215625 RVA: 0x00D348F5 File Offset: 0x00D32AF5
		public List<string> ResultDesc { get; set; } = new List<string>();

		// Token: 0x17008A67 RID: 35431
		// (get) Token: 0x06034A4A RID: 215626 RVA: 0x00D348FE File Offset: 0x00D32AFE
		// (set) Token: 0x06034A4B RID: 215627 RVA: 0x00D34906 File Offset: 0x00D32B06
		public int? NextQuestionId { get; set; }

		// Token: 0x17008A68 RID: 35432
		// (get) Token: 0x06034A4C RID: 215628 RVA: 0x00D3490F File Offset: 0x00D32B0F
		// (set) Token: 0x06034A4D RID: 215629 RVA: 0x00D34917 File Offset: 0x00D32B17
		public int? CaseProgressId { get; set; }

		// Token: 0x17008A69 RID: 35433
		// (get) Token: 0x06034A4E RID: 215630 RVA: 0x00D34920 File Offset: 0x00D32B20
		// (set) Token: 0x06034A4F RID: 215631 RVA: 0x00D34928 File Offset: 0x00D32B28
		public int? EndingId { get; set; }
	}
}
