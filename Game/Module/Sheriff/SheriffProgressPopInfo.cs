using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FC8 RID: 20424
	public class SheriffProgressPopInfo : ISheriffProgressPopInfo
	{
		// Token: 0x17008A92 RID: 35474
		// (get) Token: 0x06034AAD RID: 215725 RVA: 0x00D34C38 File Offset: 0x00D32E38
		// (set) Token: 0x06034AAE RID: 215726 RVA: 0x00D34C40 File Offset: 0x00D32E40
		public SheriffProgress Progress { get; set; }

		// Token: 0x17008A93 RID: 35475
		// (get) Token: 0x06034AAF RID: 215727 RVA: 0x00D34C49 File Offset: 0x00D32E49
		// (set) Token: 0x06034AB0 RID: 215728 RVA: 0x00D34C51 File Offset: 0x00D32E51
		public bool NeedAnim { get; set; }
	}
}
