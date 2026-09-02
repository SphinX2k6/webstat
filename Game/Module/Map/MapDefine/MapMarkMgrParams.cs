using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058DC RID: 22748
	[NullableContext(1)]
	[Nullable(0)]
	public class MapMarkMgrParams
	{
		// Token: 0x17009388 RID: 37768
		// (get) Token: 0x06039BB7 RID: 236471 RVA: 0x00EA0496 File Offset: 0x00E9E696
		// (set) Token: 0x06039BB8 RID: 236472 RVA: 0x00EA049E File Offset: 0x00E9E69E
		public EMapType MapType { get; set; }

		// Token: 0x17009389 RID: 37769
		// (get) Token: 0x06039BB9 RID: 236473 RVA: 0x00EA04A7 File Offset: 0x00E9E6A7
		// (set) Token: 0x06039BBA RID: 236474 RVA: 0x00EA04AF File Offset: 0x00E9E6AF
		public int MapId { get; set; }

		// Token: 0x1700938A RID: 37770
		// (get) Token: 0x06039BBB RID: 236475 RVA: 0x00EA04B8 File Offset: 0x00E9E6B8
		// (set) Token: 0x06039BBC RID: 236476 RVA: 0x00EA04C0 File Offset: 0x00E9E6C0
		public int InstanceDungeonId { get; set; }

		// Token: 0x1700938B RID: 37771
		// (get) Token: 0x06039BBD RID: 236477 RVA: 0x00EA04C9 File Offset: 0x00E9E6C9
		// (set) Token: 0x06039BBE RID: 236478 RVA: 0x00EA04D1 File Offset: 0x00E9E6D1
		public UUIItem MarkContainer { get; set; }

		// Token: 0x1700938C RID: 37772
		// (get) Token: 0x06039BBF RID: 236479 RVA: 0x00EA04DA File Offset: 0x00E9E6DA
		// (set) Token: 0x06039BC0 RID: 236480 RVA: 0x00EA04E2 File Offset: 0x00E9E6E2
		public float MarkScale { get; set; }

		// Token: 0x1700938D RID: 37773
		// (get) Token: 0x06039BC1 RID: 236481 RVA: 0x00EA04EB File Offset: 0x00E9E6EB
		// (set) Token: 0x06039BC2 RID: 236482 RVA: 0x00EA04F3 File Offset: 0x00E9E6F3
		public EMapGravityDirection? Gravity { get; set; }
	}
}
