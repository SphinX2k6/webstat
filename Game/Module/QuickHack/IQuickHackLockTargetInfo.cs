using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052F5 RID: 21237
	[NullableContext(1)]
	public interface IQuickHackLockTargetInfo
	{
		// Token: 0x17008D05 RID: 36101
		// (get) Token: 0x0603637D RID: 222077
		// (set) Token: 0x0603637E RID: 222078
		EQuickHackTargetType? HackType { get; set; }

		// Token: 0x17008D06 RID: 36102
		// (get) Token: 0x0603637F RID: 222079
		// (set) Token: 0x06036380 RID: 222080
		IEnumerable<EntityHandle> Targets { get; set; }
	}
}
