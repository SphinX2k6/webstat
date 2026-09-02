using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005E02 RID: 24066
	[NullableContext(1)]
	public interface IMachiningData : ICookItemData
	{
		// Token: 0x170098FD RID: 39165
		// (get) Token: 0x0603C912 RID: 248082
		// (set) Token: 0x0603C913 RID: 248083
		List<int> InteractiveList { get; set; }

		// Token: 0x170098FE RID: 39166
		// (get) Token: 0x0603C914 RID: 248084
		// (set) Token: 0x0603C915 RID: 248085
		List<int> UnlockList { get; set; }

		// Token: 0x170098FF RID: 39167
		// (get) Token: 0x0603C916 RID: 248086
		// (set) Token: 0x0603C917 RID: 248087
		int IsMachining { get; set; }
	}
}
