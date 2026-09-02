using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.SplineConstrainedDrag.Interface
{
	// Token: 0x02006AE7 RID: 27367
	[NullableContext(1)]
	public interface ISelectionMatCacheEntry
	{
		// Token: 0x1700A2F1 RID: 41713
		// (get) Token: 0x06043AC2 RID: 277186
		// (set) Token: 0x06043AC3 RID: 277187
		[Nullable(2)]
		ItemMaterialControllerActorData Asset { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700A2F2 RID: 41714
		// (get) Token: 0x06043AC4 RID: 277188
		// (set) Token: 0x06043AC5 RID: 277189
		HashSet<int> RefHolders { get; set; }
	}
}
