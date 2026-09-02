using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200349E RID: 13470
[NullableContext(2)]
[Nullable(0)]
[RequiredMember]
public class SwitchSubLevelParams
{
	// Token: 0x0601C6B4 RID: 116404 RVA: 0x00884474 File Offset: 0x00882674
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public SwitchSubLevelParams()
	{
	}

	// Token: 0x0400E49E RID: 58526
	[Nullable(1)]
	[RequiredMember]
	public Dictionary<string, bool> LevelsWithVisible;

	// Token: 0x0400E49F RID: 58527
	[Nullable(1)]
	[RequiredMember]
	public IList<string> UnloadLevels;

	// Token: 0x0400E4A0 RID: 58528
	public EScreenEffectType ScreenEffect;

	// Token: 0x0400E4A1 RID: 58529
	public Vector Location;

	// Token: 0x0400E4A2 RID: 58530
	public Rotator Rotator;

	// Token: 0x0400E4A3 RID: 58531
	public Action<bool> FinishCallback;
}
