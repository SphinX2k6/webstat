using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052F6 RID: 21238
	[NullableContext(1)]
	public interface IQuickHackOnScreenTargetInfo
	{
		// Token: 0x17008D07 RID: 36103
		// (get) Token: 0x06036381 RID: 222081
		// (set) Token: 0x06036382 RID: 222082
		Dictionary<int, int> TargetIdToIndexMap { get; set; }

		// Token: 0x17008D08 RID: 36104
		// (get) Token: 0x06036383 RID: 222083
		// (set) Token: 0x06036384 RID: 222084
		List<EntityHandle> Targets { get; set; }

		// Token: 0x17008D09 RID: 36105
		// (get) Token: 0x06036385 RID: 222085
		// (set) Token: 0x06036386 RID: 222086
		List<double> SignedScreenDistSquaredList { get; set; }

		// Token: 0x17008D0A RID: 36106
		// (get) Token: 0x06036387 RID: 222087
		// (set) Token: 0x06036388 RID: 222088
		List<double> DistSquaredList { get; set; }
	}
}
