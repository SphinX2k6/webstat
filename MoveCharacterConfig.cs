using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020030C7 RID: 12487
[NullableContext(2)]
[Nullable(0)]
[RequiredMember]
public class MoveCharacterConfig
{
	// Token: 0x06019C0E RID: 105486 RVA: 0x00780688 File Offset: 0x0077E888
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public MoveCharacterConfig()
	{
	}

	// Token: 0x0400CD4F RID: 52559
	[Nullable(new byte[]
	{
		0,
		1,
		1,
		1
	})]
	[RequiredMember]
	public OneOf<MoveCharacterPoint, IList<MoveCharacterPoint>> Points;

	// Token: 0x0400CD50 RID: 52560
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public MoveCharacterPoint[] PointsArray;

	// Token: 0x0400CD51 RID: 52561
	[RequiredMember]
	public bool Navigation;

	// Token: 0x0400CD52 RID: 52562
	[RequiredMember]
	public bool ReturnFalseWhenNavigationFailed;

	// Token: 0x0400CD53 RID: 52563
	public bool? StrictNavigation;

	// Token: 0x0400CD54 RID: 52564
	[RequiredMember]
	public bool IsFly;

	// Token: 0x0400CD55 RID: 52565
	[RequiredMember]
	public bool DebugMode;

	// Token: 0x0400CD56 RID: 52566
	[RequiredMember]
	public bool Loop;

	// Token: 0x0400CD57 RID: 52567
	public bool? CircleMove;

	// Token: 0x0400CD58 RID: 52568
	public Action<ELevelEventState> Callback;

	// Token: 0x0400CD59 RID: 52569
	public bool? UsePreviousIndex;

	// Token: 0x0400CD5A RID: 52570
	public bool? UseNearestPoint;

	// Token: 0x0400CD5B RID: 52571
	public float? TurnSpeed;

	// Token: 0x0400CD5C RID: 52572
	public float? Distance;

	// Token: 0x0400CD5D RID: 52573
	public bool? StartWithInversePath;

	// Token: 0x0400CD5E RID: 52574
	public float? ReturnTimeoutFailed;

	// Token: 0x0400CD5F RID: 52575
	public int? StartIndex;

	// Token: 0x0400CD60 RID: 52576
	public bool? NavigateToStartPos;

	// Token: 0x0400CD61 RID: 52577
	public bool? ResetAllPoints;

	// Token: 0x0400CD62 RID: 52578
	public bool? NoAsyncPoint;

	// Token: 0x0400CD63 RID: 52579
	public bool? EnablePlayerAccurateMoveToTarget;

	// Token: 0x0400CD64 RID: 52580
	public Action OnResetLocationCallback;
}
