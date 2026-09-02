using System;
using System.Runtime.CompilerServices;

// Token: 0x02002702 RID: 9986
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsDangoActorData : IRacingBetsDangoActorData
{
	// Token: 0x17001919 RID: 6425
	// (get) Token: 0x06013B35 RID: 80693 RVA: 0x0057D39D File Offset: 0x0057B59D
	// (set) Token: 0x06013B36 RID: 80694 RVA: 0x0057D3A5 File Offset: 0x0057B5A5
	public EUiModelUseWay UiModelUseWay { get; set; }

	// Token: 0x1700191A RID: 6426
	// (get) Token: 0x06013B37 RID: 80695 RVA: 0x0057D3AE File Offset: 0x0057B5AE
	// (set) Token: 0x06013B38 RID: 80696 RVA: 0x0057D3B6 File Offset: 0x0057B5B6
	public int DangoId { get; set; }

	// Token: 0x1700191B RID: 6427
	// (get) Token: 0x06013B39 RID: 80697 RVA: 0x0057D3BF File Offset: 0x0057B5BF
	// (set) Token: 0x06013B3A RID: 80698 RVA: 0x0057D3C7 File Offset: 0x0057B5C7
	public int Odds { get; set; }

	// Token: 0x1700191C RID: 6428
	// (get) Token: 0x06013B3B RID: 80699 RVA: 0x0057D3D0 File Offset: 0x0057B5D0
	// (set) Token: 0x06013B3C RID: 80700 RVA: 0x0057D3D8 File Offset: 0x0057B5D8
	public string DangoPointCase { get; set; }

	// Token: 0x1700191D RID: 6429
	// (get) Token: 0x06013B3D RID: 80701 RVA: 0x0057D3E1 File Offset: 0x0057B5E1
	// (set) Token: 0x06013B3E RID: 80702 RVA: 0x0057D3E9 File Offset: 0x0057B5E9
	public string DangoCamera { get; set; }

	// Token: 0x1700191E RID: 6430
	// (get) Token: 0x06013B3F RID: 80703 RVA: 0x0057D3F2 File Offset: 0x0057B5F2
	// (set) Token: 0x06013B40 RID: 80704 RVA: 0x0057D3FA File Offset: 0x0057B5FA
	public float DangoOffset { get; set; }

	// Token: 0x1700191F RID: 6431
	// (get) Token: 0x06013B41 RID: 80705 RVA: 0x0057D403 File Offset: 0x0057B603
	// (set) Token: 0x06013B42 RID: 80706 RVA: 0x0057D40B File Offset: 0x0057B60B
	public bool IsAbuDango { get; set; }
}
