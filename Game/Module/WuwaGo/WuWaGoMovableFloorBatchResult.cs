using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AB1 RID: 19121
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class WuWaGoMovableFloorBatchResult : IWuWaGoMovableFloorBatchResult
	{
		// Token: 0x1700850E RID: 34062
		// (get) Token: 0x06031D99 RID: 204185 RVA: 0x00C79B58 File Offset: 0x00C77D58
		// (set) Token: 0x06031D9A RID: 204186 RVA: 0x00C79B60 File Offset: 0x00C77D60
		[RequiredMember]
		public bool Committed { get; set; }

		// Token: 0x1700850F RID: 34063
		// (get) Token: 0x06031D9B RID: 204187 RVA: 0x00C79B69 File Offset: 0x00C77D69
		// (set) Token: 0x06031D9C RID: 204188 RVA: 0x00C79B71 File Offset: 0x00C77D71
		[RequiredMember]
		public IReadOnlyList<int> MovedRoleIds { get; set; }

		// Token: 0x06031D9D RID: 204189 RVA: 0x00C79B7A File Offset: 0x00C77D7A
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public WuWaGoMovableFloorBatchResult()
		{
		}
	}
}
