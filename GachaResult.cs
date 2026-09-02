using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001CF9 RID: 7417
[NullableContext(1)]
[Nullable(0)]
public class GachaResult
{
	// Token: 0x040067F3 RID: 26611
	[Nullable(2)]
	public GachaReward Proto_GachaReward;

	// Token: 0x040067F4 RID: 26612
	public IReadOnlyList<GachaReward> Proto_ExtraRewards = Array.Empty<GachaReward>();

	// Token: 0x040067F5 RID: 26613
	public bool IsNew = true;

	// Token: 0x040067F6 RID: 26614
	public IReadOnlyList<GachaReward> Proto_TransformRewards = Array.Empty<GachaReward>();

	// Token: 0x040067F7 RID: 26615
	[Nullable(2)]
	public GachaReward Proto_BottomExtraReward;
}
