using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DD6 RID: 19926
	[NullableContext(1)]
	public interface ITrapDefenseResultViewInfo
	{
		// Token: 0x17008856 RID: 34902
		// (get) Token: 0x06033910 RID: 211216
		// (set) Token: 0x06033911 RID: 211217
		TrapDefenseChallengeResultNotify Notify { get; set; }

		// Token: 0x17008857 RID: 34903
		// (get) Token: 0x06033912 RID: 211218
		// (set) Token: 0x06033913 RID: 211219
		bool NeedShowViewAnim { get; set; }
	}
}
