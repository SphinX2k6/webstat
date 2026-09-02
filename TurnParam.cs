using System;
using System.Runtime.CompilerServices;

// Token: 0x0200301C RID: 12316
[NullableContext(2)]
[Nullable(0)]
public class TurnParam : ITurnParam, IActionParamMap
{
	// Token: 0x170021DD RID: 8669
	// (get) Token: 0x06019206 RID: 102918 RVA: 0x007266F3 File Offset: 0x007248F3
	// (set) Token: 0x06019207 RID: 102919 RVA: 0x007266FB File Offset: 0x007248FB
	public Vector TargetLocation { get; set; }

	// Token: 0x170021DE RID: 8670
	// (get) Token: 0x06019208 RID: 102920 RVA: 0x00726704 File Offset: 0x00724904
	// (set) Token: 0x06019209 RID: 102921 RVA: 0x0072670C File Offset: 0x0072490C
	public Vector Direction { get; set; }

	// Token: 0x170021DF RID: 8671
	// (get) Token: 0x0601920A RID: 102922 RVA: 0x00726715 File Offset: 0x00724915
	// (set) Token: 0x0601920B RID: 102923 RVA: 0x0072671D File Offset: 0x0072491D
	public float? TurnSpeed { get; set; }

	// Token: 0x170021E0 RID: 8672
	// (get) Token: 0x0601920C RID: 102924 RVA: 0x00726726 File Offset: 0x00724926
	// (set) Token: 0x0601920D RID: 102925 RVA: 0x0072672E File Offset: 0x0072492E
	public bool? ContainZ { get; set; }

	// Token: 0x170021E1 RID: 8673
	// (get) Token: 0x0601920E RID: 102926 RVA: 0x00726737 File Offset: 0x00724937
	// (set) Token: 0x0601920F RID: 102927 RVA: 0x0072673F File Offset: 0x0072493F
	public float? MinTurnTimeSeconds { get; set; }
}
