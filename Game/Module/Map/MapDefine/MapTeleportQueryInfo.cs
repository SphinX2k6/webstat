using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058DE RID: 22750
	[NullableContext(1)]
	[Nullable(0)]
	public class MapTeleportQueryInfo
	{
		// Token: 0x17009391 RID: 37777
		// (get) Token: 0x06039BCB RID: 236491 RVA: 0x00EA053F File Offset: 0x00E9E73F
		// (set) Token: 0x06039BCC RID: 236492 RVA: 0x00EA0547 File Offset: 0x00E9E747
		public int MarkId { get; set; }

		// Token: 0x17009392 RID: 37778
		// (get) Token: 0x06039BCD RID: 236493 RVA: 0x00EA0550 File Offset: 0x00E9E750
		// (set) Token: 0x06039BCE RID: 236494 RVA: 0x00EA0558 File Offset: 0x00E9E758
		public EMarkType MarkType { get; set; }

		// Token: 0x17009393 RID: 37779
		// (get) Token: 0x06039BCF RID: 236495 RVA: 0x00EA0561 File Offset: 0x00E9E761
		// (set) Token: 0x06039BD0 RID: 236496 RVA: 0x00EA0569 File Offset: 0x00E9E769
		public int MapId { get; set; }

		// Token: 0x17009394 RID: 37780
		// (get) Token: 0x06039BD1 RID: 236497 RVA: 0x00EA0572 File Offset: 0x00E9E772
		// (set) Token: 0x06039BD2 RID: 236498 RVA: 0x00EA057A File Offset: 0x00E9E77A
		public int InstanceDungeonId { get; set; }

		// Token: 0x17009395 RID: 37781
		// (get) Token: 0x06039BD3 RID: 236499 RVA: 0x00EA0583 File Offset: 0x00E9E783
		// (set) Token: 0x06039BD4 RID: 236500 RVA: 0x00EA058B File Offset: 0x00E9E78B
		public EMapGravityDirection Gravity { get; set; }

		// Token: 0x17009396 RID: 37782
		// (get) Token: 0x06039BD5 RID: 236501 RVA: 0x00EA0594 File Offset: 0x00E9E794
		// (set) Token: 0x06039BD6 RID: 236502 RVA: 0x00EA059C File Offset: 0x00E9E79C
		public int MultiMapId { get; set; }

		// Token: 0x17009397 RID: 37783
		// (get) Token: 0x06039BD7 RID: 236503 RVA: 0x00EA05A5 File Offset: 0x00E9E7A5
		// (set) Token: 0x06039BD8 RID: 236504 RVA: 0x00EA05AD File Offset: 0x00E9E7AD
		public int[] ConnectMultiMapIds { get; set; } = Array.Empty<int>();

		// Token: 0x17009398 RID: 37784
		// (get) Token: 0x06039BD9 RID: 236505 RVA: 0x00EA05B6 File Offset: 0x00E9E7B6
		// (set) Token: 0x06039BDA RID: 236506 RVA: 0x00EA05BE File Offset: 0x00E9E7BE
		public Vector WorldPosition { get; set; }
	}
}
