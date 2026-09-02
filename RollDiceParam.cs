using System;
using System.Runtime.CompilerServices;

// Token: 0x02001310 RID: 4880
[NullableContext(2)]
[Nullable(0)]
public class RollDiceParam : IRollDiceParam
{
	// Token: 0x17000B34 RID: 2868
	// (get) Token: 0x060084C6 RID: 33990 RVA: 0x00230252 File Offset: 0x0022E452
	// (set) Token: 0x060084C7 RID: 33991 RVA: 0x0023025A File Offset: 0x0022E45A
	public float? AniProcess { get; set; }

	// Token: 0x17000B35 RID: 2869
	// (get) Token: 0x060084C8 RID: 33992 RVA: 0x00230263 File Offset: 0x0022E463
	// (set) Token: 0x060084C9 RID: 33993 RVA: 0x0023026B File Offset: 0x0022E46B
	public int? AniNum { get; set; }

	// Token: 0x17000B36 RID: 2870
	// (get) Token: 0x060084CA RID: 33994 RVA: 0x00230274 File Offset: 0x0022E474
	// (set) Token: 0x060084CB RID: 33995 RVA: 0x0023027C File Offset: 0x0022E47C
	[Nullable(1)]
	public int[] DicePoints { [NullableContext(1)] get; [NullableContext(1)] set; } = Array.Empty<int>();

	// Token: 0x17000B37 RID: 2871
	// (get) Token: 0x060084CC RID: 33996 RVA: 0x00230285 File Offset: 0x0022E485
	// (set) Token: 0x060084CD RID: 33997 RVA: 0x0023028D File Offset: 0x0022E48D
	public bool? IsNormalTimer { get; set; }

	// Token: 0x17000B38 RID: 2872
	// (get) Token: 0x060084CE RID: 33998 RVA: 0x00230296 File Offset: 0x0022E496
	// (set) Token: 0x060084CF RID: 33999 RVA: 0x0023029E File Offset: 0x0022E49E
	public ERollDiceCameraMode? CameraMode { get; set; }

	// Token: 0x17000B39 RID: 2873
	// (get) Token: 0x060084D0 RID: 34000 RVA: 0x002302A7 File Offset: 0x0022E4A7
	// (set) Token: 0x060084D1 RID: 34001 RVA: 0x002302AF File Offset: 0x0022E4AF
	public string BpDiceCase { get; set; }

	// Token: 0x17000B3A RID: 2874
	// (get) Token: 0x060084D2 RID: 34002 RVA: 0x002302B8 File Offset: 0x0022E4B8
	// (set) Token: 0x060084D3 RID: 34003 RVA: 0x002302C0 File Offset: 0x0022E4C0
	public string DiceCameraCase { get; set; }
}
