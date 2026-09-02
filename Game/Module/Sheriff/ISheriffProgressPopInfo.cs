using System;
using Aki.Config;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FC7 RID: 20423
	public interface ISheriffProgressPopInfo
	{
		// Token: 0x17008A90 RID: 35472
		// (get) Token: 0x06034AA9 RID: 215721
		// (set) Token: 0x06034AAA RID: 215722
		SheriffProgress Progress { get; set; }

		// Token: 0x17008A91 RID: 35473
		// (get) Token: 0x06034AAB RID: 215723
		// (set) Token: 0x06034AAC RID: 215724
		bool NeedAnim { get; set; }
	}
}
