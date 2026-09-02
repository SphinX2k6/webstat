using System;
using System.Runtime.CompilerServices;

// Token: 0x0200130F RID: 4879
[NullableContext(2)]
public interface IRollDiceParam
{
	// Token: 0x17000B2D RID: 2861
	// (get) Token: 0x060084B8 RID: 33976
	// (set) Token: 0x060084B9 RID: 33977
	float? AniProcess { get; set; }

	// Token: 0x17000B2E RID: 2862
	// (get) Token: 0x060084BA RID: 33978
	// (set) Token: 0x060084BB RID: 33979
	int? AniNum { get; set; }

	// Token: 0x17000B2F RID: 2863
	// (get) Token: 0x060084BC RID: 33980
	// (set) Token: 0x060084BD RID: 33981
	[Nullable(1)]
	int[] DicePoints { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000B30 RID: 2864
	// (get) Token: 0x060084BE RID: 33982
	// (set) Token: 0x060084BF RID: 33983
	bool? IsNormalTimer { get; set; }

	// Token: 0x17000B31 RID: 2865
	// (get) Token: 0x060084C0 RID: 33984
	// (set) Token: 0x060084C1 RID: 33985
	ERollDiceCameraMode? CameraMode { get; set; }

	// Token: 0x17000B32 RID: 2866
	// (get) Token: 0x060084C2 RID: 33986
	// (set) Token: 0x060084C3 RID: 33987
	string BpDiceCase { get; set; }

	// Token: 0x17000B33 RID: 2867
	// (get) Token: 0x060084C4 RID: 33988
	// (set) Token: 0x060084C5 RID: 33989
	string DiceCameraCase { get; set; }
}
