using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AA0 RID: 19104
	[NullableContext(1)]
	[Nullable(0)]
	[RequiredMember]
	public class WuWaGoGridRelocationContext : IWuWaGoGridRelocationContext
	{
		// Token: 0x170084C4 RID: 33988
		// (get) Token: 0x06031D15 RID: 204053 RVA: 0x00C798B3 File Offset: 0x00C77AB3
		// (set) Token: 0x06031D16 RID: 204054 RVA: 0x00C798BB File Offset: 0x00C77ABB
		[RequiredMember]
		public WuWaGoGrid Grid { get; set; }

		// Token: 0x170084C5 RID: 33989
		// (get) Token: 0x06031D17 RID: 204055 RVA: 0x00C798C4 File Offset: 0x00C77AC4
		// (set) Token: 0x06031D18 RID: 204056 RVA: 0x00C798CC File Offset: 0x00C77ACC
		[RequiredMember]
		public Vector StartCoordinate { get; set; }

		// Token: 0x170084C6 RID: 33990
		// (get) Token: 0x06031D19 RID: 204057 RVA: 0x00C798D5 File Offset: 0x00C77AD5
		// (set) Token: 0x06031D1A RID: 204058 RVA: 0x00C798DD File Offset: 0x00C77ADD
		[RequiredMember]
		public Vector TargetCoordinate { get; set; }

		// Token: 0x06031D1B RID: 204059 RVA: 0x00C798E6 File Offset: 0x00C77AE6
		[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
		[CompilerFeatureRequired("RequiredMembers")]
		public WuWaGoGridRelocationContext()
		{
		}
	}
}
