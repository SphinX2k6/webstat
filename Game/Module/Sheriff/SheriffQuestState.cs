using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FC0 RID: 20416
	[NullableContext(1)]
	[Nullable(0)]
	public class SheriffQuestState : ISheriffQuestState
	{
		// Token: 0x17008A86 RID: 35462
		// (get) Token: 0x06034A90 RID: 215696 RVA: 0x00D34B2B File Offset: 0x00D32D2B
		// (set) Token: 0x06034A91 RID: 215697 RVA: 0x00D34B33 File Offset: 0x00D32D33
		public List<int> UnFinishList { get; set; } = new List<int>();

		// Token: 0x17008A87 RID: 35463
		// (get) Token: 0x06034A92 RID: 215698 RVA: 0x00D34B3C File Offset: 0x00D32D3C
		// (set) Token: 0x06034A93 RID: 215699 RVA: 0x00D34B44 File Offset: 0x00D32D44
		public List<int> TotalList { get; set; } = new List<int>();
	}
}
