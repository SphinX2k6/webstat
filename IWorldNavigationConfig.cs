using System;
using System.Runtime.CompilerServices;

// Token: 0x02001A7A RID: 6778
[NullableContext(1)]
public interface IWorldNavigationConfig
{
	// Token: 0x17000FDE RID: 4062
	// (get) Token: 0x0600C1F3 RID: 49651
	// (set) Token: 0x0600C1F4 RID: 49652
	Vector SourcePosition { get; set; }

	// Token: 0x17000FDF RID: 4063
	// (get) Token: 0x0600C1F5 RID: 49653
	// (set) Token: 0x0600C1F6 RID: 49654
	Vector DestPosition { get; set; }

	// Token: 0x17000FE0 RID: 4064
	// (get) Token: 0x0600C1F7 RID: 49655
	// (set) Token: 0x0600C1F8 RID: 49656
	int MapId { get; set; }

	// Token: 0x17000FE1 RID: 4065
	// (get) Token: 0x0600C1F9 RID: 49657
	// (set) Token: 0x0600C1FA RID: 49658
	[Nullable(2)]
	BaseMoveComponent MoveComponent { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000FE2 RID: 4066
	// (get) Token: 0x0600C1FB RID: 49659
	// (set) Token: 0x0600C1FC RID: 49660
	int? DistanceThreshold { get; set; }

	// Token: 0x17000FE3 RID: 4067
	// (get) Token: 0x0600C1FD RID: 49661
	// (set) Token: 0x0600C1FE RID: 49662
	int? TryFindPathTimes { get; set; }

	// Token: 0x17000FE4 RID: 4068
	// (get) Token: 0x0600C1FF RID: 49663
	// (set) Token: 0x0600C200 RID: 49664
	[Nullable(2)]
	TWorldNavigationCallback Callback { [NullableContext(2)] get; [NullableContext(2)] set; }
}
