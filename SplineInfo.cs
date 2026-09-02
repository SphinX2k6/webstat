using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay.Common;

// Token: 0x020030CE RID: 12494
public class SplineInfo
{
	// Token: 0x0400CD9B RID: 52635
	public int SplineId;

	// Token: 0x0400CD9C RID: 52636
	[Nullable(2)]
	public GameSplineComponent SplineComp;

	// Token: 0x0400CD9D RID: 52637
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<PatrolPoint> VirtualSplinePoints;

	// Token: 0x0400CD9E RID: 52638
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<MoveCharacterConfig> SegmentsMoveConfig;

	// Token: 0x0400CD9F RID: 52639
	public bool IsLoop;

	// Token: 0x0400CDA0 RID: 52640
	public bool IsCircle;
}
