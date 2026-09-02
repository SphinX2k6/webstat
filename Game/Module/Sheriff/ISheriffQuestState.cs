using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FBF RID: 20415
	[NullableContext(1)]
	public interface ISheriffQuestState
	{
		// Token: 0x17008A84 RID: 35460
		// (get) Token: 0x06034A8C RID: 215692
		// (set) Token: 0x06034A8D RID: 215693
		List<int> UnFinishList { get; set; }

		// Token: 0x17008A85 RID: 35461
		// (get) Token: 0x06034A8E RID: 215694
		// (set) Token: 0x06034A8F RID: 215695
		List<int> TotalList { get; set; }
	}
}
