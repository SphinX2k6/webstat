using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004EFB RID: 20219
	[NullableContext(1)]
	public interface ITargetDescribeAndScore
	{
		// Token: 0x17008A0F RID: 35343
		// (get) Token: 0x06034431 RID: 214065
		// (set) Token: 0x06034432 RID: 214066
		string DescribeTextKey { get; set; }

		// Token: 0x17008A10 RID: 35344
		// (get) Token: 0x06034433 RID: 214067
		// (set) Token: 0x06034434 RID: 214068
		int RewardId { get; set; }

		// Token: 0x17008A11 RID: 35345
		// (get) Token: 0x06034435 RID: 214069
		// (set) Token: 0x06034436 RID: 214070
		int Score { get; set; }
	}
}
