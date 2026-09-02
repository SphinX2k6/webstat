using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FAE RID: 20398
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffQuestionJsonConfig : ISheriffQuestionJsonConfig
	{
		// Token: 0x17008A5C RID: 35420
		// (get) Token: 0x06034A30 RID: 215600 RVA: 0x00D34876 File Offset: 0x00D32A76
		// (set) Token: 0x06034A31 RID: 215601 RVA: 0x00D3487E File Offset: 0x00D32A7E
		public int QuestionId { get; set; }

		// Token: 0x17008A5D RID: 35421
		// (get) Token: 0x06034A32 RID: 215602 RVA: 0x00D34887 File Offset: 0x00D32A87
		// (set) Token: 0x06034A33 RID: 215603 RVA: 0x00D3488F File Offset: 0x00D32A8F
		public List<ISheriffQuestionResultJsonConfig> ResultConfigs { get; set; } = new List<ISheriffQuestionResultJsonConfig>();
	}
}
