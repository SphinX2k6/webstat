using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.MapMarkToggle
{
	// Token: 0x02004B9E RID: 19358
	[NullableContext(1)]
	public interface IMapMarkToggleItemData
	{
		// Token: 0x170086DE RID: 34526
		// (get) Token: 0x060328BC RID: 207036
		// (set) Token: 0x060328BD RID: 207037
		string NameId { get; set; }

		// Token: 0x170086DF RID: 34527
		// (get) Token: 0x060328BE RID: 207038
		// (set) Token: 0x060328BF RID: 207039
		Func<EToggleState> GetToggleResultCallback { get; set; }

		// Token: 0x170086E0 RID: 34528
		// (get) Token: 0x060328C0 RID: 207040
		// (set) Token: 0x060328C1 RID: 207041
		Func<EToggleState, bool> SetToggleStateCallback { get; set; }
	}
}
