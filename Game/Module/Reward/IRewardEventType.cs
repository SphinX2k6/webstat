using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Reward
{
	// Token: 0x02005285 RID: 21125
	[NullableContext(1)]
	public interface IRewardEventType
	{
		// Token: 0x17008CEE RID: 36078
		// (get) Token: 0x06036070 RID: 221296
		Action HandleItemReward { get; }

		// Token: 0x17008CEF RID: 36079
		// (get) Token: 0x06036071 RID: 221297
		Action HandleAddFightDropInfo { get; }

		// Token: 0x17008CF0 RID: 36080
		// (get) Token: 0x06036072 RID: 221298
		Action HandleDeleteFightDropInfo { get; }
	}
}
