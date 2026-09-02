using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058DD RID: 22749
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRoadWaysMgrParams
	{
		// Token: 0x1700938E RID: 37774
		// (get) Token: 0x06039BC4 RID: 236484 RVA: 0x00EA0504 File Offset: 0x00E9E704
		// (set) Token: 0x06039BC5 RID: 236485 RVA: 0x00EA050C File Offset: 0x00E9E70C
		public int MapId { get; set; }

		// Token: 0x1700938F RID: 37775
		// (get) Token: 0x06039BC6 RID: 236486 RVA: 0x00EA0515 File Offset: 0x00E9E715
		// (set) Token: 0x06039BC7 RID: 236487 RVA: 0x00EA051D File Offset: 0x00E9E71D
		public int InstanceDungeonId { get; set; }

		// Token: 0x17009390 RID: 37776
		// (get) Token: 0x06039BC8 RID: 236488 RVA: 0x00EA0526 File Offset: 0x00E9E726
		// (set) Token: 0x06039BC9 RID: 236489 RVA: 0x00EA052E File Offset: 0x00E9E72E
		public UUIItem Container { get; set; }
	}
}
