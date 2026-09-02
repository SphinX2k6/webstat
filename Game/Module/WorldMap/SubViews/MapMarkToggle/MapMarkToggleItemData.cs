using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.MapMarkToggle
{
	// Token: 0x02004BA1 RID: 19361
	[NullableContext(2)]
	[Nullable(0)]
	public class MapMarkToggleItemData : IMapMarkToggleItemData
	{
		// Token: 0x170086E1 RID: 34529
		// (get) Token: 0x060328D6 RID: 207062 RVA: 0x00CA7964 File Offset: 0x00CA5B64
		// (set) Token: 0x060328D7 RID: 207063 RVA: 0x00CA796C File Offset: 0x00CA5B6C
		[Nullable(1)]
		public string NameId { [NullableContext(1)] get; [NullableContext(1)] set; } = "";

		// Token: 0x170086E2 RID: 34530
		// (get) Token: 0x060328D8 RID: 207064 RVA: 0x00CA7975 File Offset: 0x00CA5B75
		// (set) Token: 0x060328D9 RID: 207065 RVA: 0x00CA797D File Offset: 0x00CA5B7D
		public Func<EToggleState> GetToggleResultCallback { get; set; }

		// Token: 0x170086E3 RID: 34531
		// (get) Token: 0x060328DA RID: 207066 RVA: 0x00CA7986 File Offset: 0x00CA5B86
		// (set) Token: 0x060328DB RID: 207067 RVA: 0x00CA798E File Offset: 0x00CA5B8E
		public Func<EToggleState, bool> SetToggleStateCallback { get; set; }
	}
}
