using System;
using System.Runtime.CompilerServices;

// Token: 0x02002C0D RID: 11277
public static class TrackDefine
{
	// Token: 0x0400AE0A RID: 44554
	public const int INVALID_TRACKDISTANCE = 0;

	// Token: 0x0400AE0B RID: 44555
	public const float MAX_A = 1176f;

	// Token: 0x0400AE0C RID: 44556
	public const float MARGIN_A = 1008f;

	// Token: 0x0400AE0D RID: 44557
	public const float MAX_B = 712.5f;

	// Token: 0x0400AE0E RID: 44558
	public const float MARGIN_B = 495f;

	// Token: 0x0400AE0F RID: 44559
	public const float CENTER_Y = 62.5f;

	// Token: 0x0400AE10 RID: 44560
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static readonly Vector2D center = Vector2D.Create(0.0, 62.5);

	// Token: 0x0400AE11 RID: 44561
	public const float RAD_2_DEG = 57.295776f;
}
