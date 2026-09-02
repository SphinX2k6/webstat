using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Map.MapDefine
{
	// Token: 0x020058E3 RID: 22755
	public class QueryNearestTeleporterResult
	{
		// Token: 0x04020BEB RID: 134123
		public int TargetMarkId;

		// Token: 0x04020BEC RID: 134124
		public EMarkType TargetMarkType;

		// Token: 0x04020BED RID: 134125
		[Nullable(2)]
		public MapTeleportQueryInfo Info;

		// Token: 0x04020BEE RID: 134126
		public EQueryNearestTeleporterFailedReason? FailedReason;
	}
}
