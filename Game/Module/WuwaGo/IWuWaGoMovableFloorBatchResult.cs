using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AB0 RID: 19120
	[NullableContext(1)]
	public interface IWuWaGoMovableFloorBatchResult
	{
		// Token: 0x1700850C RID: 34060
		// (get) Token: 0x06031D97 RID: 204183
		bool Committed { get; }

		// Token: 0x1700850D RID: 34061
		// (get) Token: 0x06031D98 RID: 204184
		IReadOnlyList<int> MovedRoleIds { get; }
	}
}
