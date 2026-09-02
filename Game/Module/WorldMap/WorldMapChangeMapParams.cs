using System;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B34 RID: 19252
	public class WorldMapChangeMapParams
	{
		// Token: 0x0401D5D8 RID: 120280
		public int MarkId;

		// Token: 0x0401D5D9 RID: 120281
		public EMarkType MarkType;

		// Token: 0x0401D5DA RID: 120282
		public int MapId;

		// Token: 0x0401D5DB RID: 120283
		public bool? Focal;

		// Token: 0x0401D5DC RID: 120284
		public bool? FocusTween;

		// Token: 0x0401D5DD RID: 120285
		public EMapGravityDirection? Gravity;

		// Token: 0x0401D5DE RID: 120286
		public bool? NeedTempShow;
	}
}
